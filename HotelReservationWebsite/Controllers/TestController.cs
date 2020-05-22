using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace HotelReservationWebsite.Controllers
{
    [AllowAnonymous]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}