using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HotelReservationWebsite.Controllers
{
    public class BookingManagerController : Controller
    {
        private readonly IIdentityService<Buyer> _identitySvc;
        private readonly IBookingService _bookingSvc;
        private readonly ICartService _cartSvc;
        private readonly AppSettings _settings;

        public BookingManagerController(IBookingService bookingService, ICartService cartService,
            IIdentityService<Buyer> identityService, IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
            _identitySvc = identityService;
            _cartSvc = cartService;
            _bookingSvc = bookingService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var user = _identitySvc.Get(User);
            var bookings = await _bookingSvc.GetBookings();
            foreach (var booking in bookings)
            {
                booking.Items = ChangeUriPlaceholderBooking(booking.Items.Where(i => i.HotelId == id.ToString()).ToList());
            }
            return View(bookings);
        }
        // public async Task<ActionResult<Booking>> Details(int id)
        // {
        //     var booking = await _bookingSvc.GetBooking(id);
        //     var bookingView = ChangeUriPlaceholderBooking(booking);
        //     return View(bookingView);
        // }
        private List<BookingItem> ChangeUriPlaceholderBooking(List<BookingItem> items)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            items.ForEach(x =>
            {
                x.ImageUri = baseUri + "/images/" + x.ImageUri;
            });
            return items;
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