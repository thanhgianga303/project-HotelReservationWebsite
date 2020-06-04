using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationWebsite.Controllers
{

    [Authorize(Roles = "Lessors,Managers,Administrators")]
    public class AdminController : Controller
    {
        // [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}