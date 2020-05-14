using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HotelReservationWebsite.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly AppSettings _settings;
        public HotelController(IHotelService hotelService, IOptions<AppSettings> settings)
        {
            _hotelService = hotelService;
            _settings = settings.Value;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var hotels = await _hotelService.GetHotels(searchString);
            var hotelsVM = new HotelViewModel
            {
                Hotels = ChangeUriPlaceholder(hotels.ToList())
            };
            return View(hotelsVM);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Hotel hotel)
        {
            await _hotelService.CreateHotel(hotel);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var hotel = await _hotelService.GetHotel(id);
            return View(hotel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            Console.WriteLine("giangcoi" + id);
            await _hotelService.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
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
    }
}