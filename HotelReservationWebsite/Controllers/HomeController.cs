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
        private readonly IBookingService _bookingService;
        public HomeController(IHotelService service, IBookingService bookingService, IOptions<AppSettings> settings)
        {
            _service = service;
            _bookingService = bookingService;
            _settings = settings.Value;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString)
        {
            var hotels = await _service.GetHotels(searchString);
            hotels = hotels.Where(h => h.HotelStatus == HotelStatus.Approved);
            DateTime dayCheckIn = DateTime.Today.AddDays(1);
            DateTime dayCheckOut = DateTime.Today.AddDays(2);

            var bookings = await _bookingService.GetBookings();
            bookings = bookings.Where(b => b.Status != BookingStatus.Canceled && b.Status != BookingStatus.checkedOut);
            foreach (var booking in bookings)
            {
                booking.Items = booking.Items.Where(i => (dayCheckIn >= i.CheckIn && dayCheckOut <= i.CheckOut)
                || (dayCheckIn < i.CheckIn && dayCheckOut > i.CheckIn)
                || (dayCheckIn < i.CheckOut && dayCheckOut > i.CheckOut)).ToList();

                foreach (var item in booking.Items)
                {
                    foreach (var hotel in hotels)
                    {
                        foreach (var room in hotel.Rooms)
                        {
                            if (room.HotelID == Int32.Parse(item.HotelId) && room.RoomID == Int32.Parse(item.RoomId))
                            {
                                room.RoomNumber = room.RoomNumber - Int32.Parse(item.RoomNumber);
                            }
                        }
                    }
                }
            }





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

            var bookings = await _bookingService.GetBookings();
            bookings = bookings.Where(b => b.Status != BookingStatus.Canceled && b.Status != BookingStatus.checkedOut);
            foreach (var booking in bookings)
            {
                booking.Items = booking.Items.Where(i => (hotelVM.CheckIn >= i.CheckIn && hotelVM.CheckOut <= i.CheckOut)
                || (hotelVM.CheckIn < i.CheckIn && hotelVM.CheckOut > i.CheckIn)
                || (hotelVM.CheckIn < i.CheckOut && hotelVM.CheckOut > i.CheckOut)).ToList();

                foreach (var item in booking.Items)
                {
                    foreach (var hotel in hotels)
                    {
                        // hotel.Rooms = hotel.Rooms.Where(a => (a.HotelID != Int32.Parse(item.HotelId))
                        //  || (a.RoomID != Int32.Parse(item.RoomId))).ToList();
                        foreach (var room in hotel.Rooms)
                        {
                            if (room.HotelID == Int32.Parse(item.HotelId) && room.RoomID == Int32.Parse(item.RoomId))
                            {
                                room.RoomNumber = room.RoomNumber - Int32.Parse(item.RoomNumber);
                            }
                        }
                    }
                }
            }

            var newhotelVM = new HotelViewModel
            {
                CheckIn = hotelVM.CheckIn,
                CheckOut = hotelVM.CheckOut,
                SearchString = hotelVM.SearchString,
                Hotels = ChangeUriPlaceholder(hotels.ToList())
            };
            return View(newhotelVM);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Details(HotelViewModel hotelViewModel, Hotel hotel)
        {
            var findHotel = await _service.GetHotel(hotel.HotelID);

            var bookings = await _bookingService.GetBookings();
            bookings = bookings.Where(b => b.Status != BookingStatus.Canceled && b.Status != BookingStatus.checkedOut);
            foreach (var booking in bookings)
            {
                booking.Items = booking.Items.Where(i => (hotelViewModel.CheckIn >= i.CheckIn && hotelViewModel.CheckOut <= i.CheckOut)
                 || (hotelViewModel.CheckIn < i.CheckIn && hotelViewModel.CheckOut > i.CheckIn)
                 || (hotelViewModel.CheckIn < i.CheckOut && hotelViewModel.CheckOut > i.CheckOut)).ToList();

                foreach (var item in booking.Items)
                {

                    // findHotel.Rooms = findHotel.Rooms.Where(a => (a.HotelID != Int32.Parse(item.HotelId))
                    //  || (a.RoomID != Int32.Parse(item.RoomId))).ToList();
                    foreach (var room in findHotel.Rooms)
                    {
                        if (room.HotelID == Int32.Parse(item.HotelId) && room.RoomID == Int32.Parse(item.RoomId))
                        {
                            room.RoomNumber = room.RoomNumber - Int32.Parse(item.RoomNumber);
                            // Console.WriteLine();
                        }
                    }
                }
            }
            var roomVM = new RoomViewModel()
            {
                CheckIn = hotelViewModel.CheckIn,
                CheckOut = hotelViewModel.CheckOut,
                SearchString = hotelViewModel.SearchString,
                Rooms = ChangeUriPlaceholderRooms(findHotel.Rooms)
            };
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
                if (x.RoomNumber > 0)
                {
                    x.NumberOfRoomsBooked = 1;
                }
                else
                {
                    x.NumberOfRoomsBooked = 0;
                }
            });

            return rooms;
        }
    }
}