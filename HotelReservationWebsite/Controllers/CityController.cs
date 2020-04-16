using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Services;
using HotelReservationWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace HotelReservationWebsite.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _service;
        public CityController(ICityService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var cities = await _service.GetCitys();
            var cityVM = new CityViewModel
            {
                Cities = cities.ToList()
            };
            return View(cityVM);
        }
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}