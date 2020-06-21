using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationWebsite.Controllers
{
    [Authorize(Roles = "Renters,Lessors,Managers,Administrators")]
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}