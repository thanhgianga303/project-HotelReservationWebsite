using System.Threading.Tasks;
using HotelReservationWebsite.Services;
using Microsoft.AspNetCore.Mvc;
namespace HotelReservationWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var account = await _service.GetAll();
            return View(account);
        }
    }
}