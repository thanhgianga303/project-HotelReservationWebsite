using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace HotelReservationWebsite.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly AppSettings _settings;
        private readonly IHotelService _service;
        public HomeController(IHotelService service, IOptions<AppSettings> settings)
        {
            _service = service;
            _settings = settings.Value;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var hotels = await _service.GetHotels(searchString);
            hotels = hotels.Where(h => h.HotelStatus == HotelStatus.Approved);
            var hotelVM = new HotelViewModel
            {
                SearchString = searchString,
                Hotels = ChangeUriPlaceholder(hotels.ToList())
            };
            return View(hotelVM);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var hotel = await _service.GetHotel(id);
            var roomVM = new RoomViewModel()
            {
                Rooms = ChangeUriPlaceholderRooms(hotel.Rooms)
            };
            return View(roomVM);
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