using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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

            return View(bookings);
        }

        public async Task<IActionResult> Create()
        {
            var user = _identitySvc.Get(User);
            var cart = await _cartSvc.GetCart(user);
            var booking = _cartSvc.MapCartToBooking(cart);
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking frmBooking)
        {
            if (!ModelState.IsValid)
            {
                return View(frmBooking);
            }

            var user = _identitySvc.Get(User);
            var booking = frmBooking;
            booking.BuyerId = user.Id;

            // var chargeSvc = new ChargeService();
            // var charge = chargeSvc.Create(new ChargeCreateOptions
            // {
            //     Amount = (int)(order.Total * 100),
            //     Currency = "usd",
            //     Description = $"Order Payment {order.UserName}",
            //     ReceiptEmail = order.UserName,
            //     Source = order.StripeToken
            // });

            var succeeded = true;
            // if (charge.Status == "succeeded")
            if (succeeded)
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

        public async Task<ActionResult<Booking>> Details(int bookingId)
        {
            var booking = await _bookingSvc.GetBooking(bookingId);

            return View(booking);
        }
    }
}