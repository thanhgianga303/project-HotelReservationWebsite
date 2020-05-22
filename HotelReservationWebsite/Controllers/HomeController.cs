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

            var hotelVM = new HotelViewModel
            {
                SearchString = searchString,
                Hotels = ChangeUriPlaceholder(hotels.ToList())
            };
            return View(hotelVM);
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
        public IActionResult Privacy()
        {
            return View();
        }
    }
}