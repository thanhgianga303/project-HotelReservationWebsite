using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace HotelReservationWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IAddressService _addressService;
        public HomeController(IHotelService hotelService,IAddressService addressService)
        {
            _hotelService = hotelService;
            _addressService=addressService;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var hotels = await _service.GetHotels(searchString);
            
            var hotelVM = new HotelViewModel
            {
                SearchString = searchString,
                Hotels = hotels.ToList(),
                
            };
            return View(hotelVM);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}