using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using System;

namespace HotelReservationWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _settings;
        private readonly IHotelService _service;
        public HomeController(IHotelService service, IOptions<AppSettings> settings)
        {
            _service = service;
            _settings = settings.Value;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString)
        {
            var hotels = await _service.GetHotels(searchString);
            hotels = hotels.Where(h => h.HotelStatus == HotelStatus.Approved);
            DateTime dayCheckIn = DateTime.Today.AddDays(1);
            DateTime dayCheckOut = DateTime.Today.AddDays(2);
            var hotelVM = new HotelViewModel
            {
                CheckIn = dayCheckIn,
                CheckOut = dayCheckOut,
                SearchString = searchString,
                Hotels = ChangeUriPlaceholder(hotels.ToList())
            };
            return View(hotelVM);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(HotelViewModel hotelVM)
        {
            var hotels = await _service.GetHotels(hotelVM.SearchString);
            hotels = hotels.Where(h => h.HotelStatus == HotelStatus.Approved);
            var newhotelVM = new HotelViewModel
            {
                CheckIn = hotelVM.CheckIn,
                CheckOut = hotelVM.CheckOut,
                SearchString = hotelVM.SearchString,
                Hotels = ChangeUriPlaceholder(hotels.ToList())
            };
            return View(newhotelVM);
        }
        public void checkBooking(DateTime checkIn, DateTime checkOut)
        {
            //var bookingList=_serviceBooking.GetBookings()
            //for(var item in bookingList )
            //
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Details(HotelViewModel hotelViewModel, Hotel hotel)
        {
            var findHotel = await _service.GetHotel(hotel.HotelID);
            var roomVM = new RoomViewModel()
            {
                CheckIn = hotelViewModel.CheckIn,
                CheckOut = hotelViewModel.CheckOut,
                SearchString = hotelViewModel.SearchString,
                Rooms = ChangeUriPlaceholderRooms(findHotel.Rooms)
            };
            Console.WriteLine("mama" + roomVM.CheckIn);
            Console.WriteLine("meme" + hotelViewModel.CheckIn);
            return View(roomVM);
        }
        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
        private IList<Hotel> ChangeUriPlaceholder(List<Hotel> hotels)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            // var imageUrl = "";
            hotels.ForEach(x =>
            {

                // imageUrl = x.ImageUrl;
                x.ImageUrl = baseUri + "/images/" + x.ImageUrl;

            });

            return hotels;
        }
        private IList<Room> ChangeUriPlaceholderRooms(List<Room> rooms)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            rooms.ForEach(x =>
            {

                x.ImageUrl = baseUri + "/images/" + x.ImageUrl;

            });

            return rooms;
        }
    }
}