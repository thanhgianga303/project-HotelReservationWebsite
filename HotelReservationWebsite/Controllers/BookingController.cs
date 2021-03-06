using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

namespace HotelReservationWebsite.Controllers
{
    public class BookingController : Controller
    {
        private readonly IIdentityService<Buyer> _identitySvc;
        private readonly IBookingService _bookingSvc;
        private readonly ICartService _cartSvc;
        private readonly AppSettings _settings;

        public BookingController(IBookingService bookingService, ICartService cartService,
            IIdentityService<Buyer> identityService, IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
            _identitySvc = identityService;
            _cartSvc = cartService;
            _bookingSvc = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var user = _identitySvc.Get(User);
            var bookings = await _bookingSvc.GetBookings(user.Id);
            bookings = bookings.Where(b => b.Status != BookingStatus.Canceled);
            return View(bookings);
        }

        public async Task<IActionResult> Create()
        {
            var user = _identitySvc.Get(User);
            var cart = await _cartSvc.GetCart(user);
            var booking = _cartSvc.MapCartToBooking(cart);
            booking.Total = cart.Total();
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking frmBooking, string stripeToken, string stripeEmail)
        {
            if (!ModelState.IsValid)
            {
                return View(frmBooking);
            }

            var user = _identitySvc.Get(User);

            var booking = ChangeUriSaveBooking(frmBooking);
            booking.BuyerId = user.Id;

            var chargeSvc = new ChargeService();
            var charge = chargeSvc.Create(new ChargeCreateOptions
            {
                Amount = (int)(booking.Total * 100),
                Currency = "usd",
                Description = $"Order Payment {frmBooking.Name}",
                ReceiptEmail = stripeEmail,
                Source = stripeToken
            });

            if (charge.Status == "succeeded")
            {
                int bookingId = await _bookingSvc.CreateBooking(booking);
                await _cartSvc.ClearCart(user);
                return RedirectToAction("Complete", new { id = booking.BookingId });
            }

            ViewData["message"] = "Payment cannot be processed, try again";

            return View(frmBooking);
        }

        public IActionResult Complete(int id, string userName)
        {
            return View(id);
        }

        public async Task<ActionResult<Booking>> Details(int id)
        {
            var booking = await _bookingSvc.GetBooking(id);
            var bookingView = ChangeUriPlaceholderBooking(booking);
            return View(bookingView);
        }
        public async Task<ActionResult<Booking>> Cancel(int id)
        {
            var booking = await _bookingSvc.GetBooking(id);
            var bookingView = ChangeUriPlaceholderBooking(booking);
            return View(bookingView);
        }
        [HttpPost, ActionName("Cancel")]
        public async Task<ActionResult<Booking>> CancelConfirm(int id)
        {
            var booking = await _bookingSvc.GetBooking(id);
            booking.Status = BookingStatus.Canceled;
            await _bookingSvc.UpdateBooking(id, booking);
            return RedirectToAction("Index");
        }
        private Booking ChangeUriPlaceholderBooking(Booking booking)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            List<BookingItem> items = booking.Items.ToList();
            items.ForEach(x =>
            {
                x.ImageUri = baseUri + "/images/" + x.ImageUri;
            });
            return booking;
        }
        private Booking ChangeUriSaveBooking(Booking booking)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            List<BookingItem> items = booking.Items.ToList();
            items.ForEach(x =>
            {
                x.ImageUri = x.ImageUri.Replace(baseUri + "/images/", "");
            });
            return booking;
        }
    }
}