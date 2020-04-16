using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationWebsite.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
        public IActionResult Hotel()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }
        public IActionResult Promotion()
        {
            return View();
        }
        public IActionResult BookingDetails()
        {
            return View();
        }
        public IActionResult RoomCagotery()
        {
            return View();
        }
        public IActionResult Role()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult Customer()
        {
            return View();
        }
        public IActionResult Employee()
        {
            return View();
        }
    }
}