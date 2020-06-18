using System;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationWebsite.Controllers
{

    [Authorize(Roles = "Lessors,Managers,Administrators")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHotelService _hotelService;
        private readonly IBookingService _bookingService;
        public AdminController(IUserService userService, IHotelService hotelService, IBookingService bookingService)
        {
            _userService = userService;
            _hotelService = hotelService;
            _bookingService = bookingService;
        }
        public async Task<IActionResult> Index()
        {
            var adminView = new AdminViewModel
            {
                NumberOfHotels = await NumberOfHotels(),
                NumberOfBookings = await NumberOfBookings(),
                NumberOfCustomers = await NumberOfCustomers(),
                totalTransactionAmount = await TotalTransactionAmount()
            };
            return View(adminView);
        }
        private async Task<int> NumberOfCustomers()
        {
            var users = await _userService.GetUsers();
            users = users.Where(u => u.Role != "Managers" && u.Role != "Administrators").ToList();
            return users.Count();
        }
        private async Task<int> NumberOfHotels()
        {
            var hotels = await _hotelService.GetHotels("");
            return hotels.Count();
        }
        private async Task<int> NumberOfBookings()
        {
            var bookings = await _bookingService.GetBookings();
            return bookings.Count();
        }
        private async Task<decimal> TotalTransactionAmount()
        {
            var bookings = await _bookingService.GetBookings();
            decimal _total = 0;
            foreach (var booking in bookings)
            {
                _total += booking.Total;
            }
            return _total;
        }
    }
}