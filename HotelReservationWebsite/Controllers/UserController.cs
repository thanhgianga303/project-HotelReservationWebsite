using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationWebsite.Authorization;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace HotelReservationWebsite.Controllers
{
    [Authorize(Roles = "Lessors,Managers,Administrators")]
    public class UserController : Controller
    {
        private readonly IIdentityService<Buyer> _identityService;
        private readonly IUserService _service;
        public UserController(IUserService service, IIdentityService<Buyer> identityService)
        {
            _service = service;
            _identityService = identityService;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var users = await _service.GetUsers();
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole) ||
                                User.IsInRole(Constants.ManagersRole);
            if (!isAuthorized)
            {
                var userId = _identityService.Get(User).Id;
                users = users.Where(h => h.Id == userId).ToList();
            }
            var userVm = new UserViewModel
            {
                Users = users.ToList()
            };
            return View(userVm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {

            var isAuthorized = User.IsInRole(Constants.AdministratorsRole) ||
                                User.IsInRole(Constants.ManagersRole);
            if (!isAuthorized)
            {
                var userId = _identityService.Get(User).Id;
                if (id != userId)
                {
                    return Forbid();
                }
            }
            var user = await _service.GetUser(id);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole);
            if (!isAuthorized)
            {
                var userId = _identityService.Get(User).Id;
                if (id != userId)
                {
                    return Forbid();
                }
            }
            var user = await _service.GetUser(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, User user)
        {
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole);
            if (!isAuthorized)
            {
                var userId = _identityService.Get(User).Id;
                if (id != userId)
                {
                    return Forbid();
                }
            }
            if (id != user.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateUser(id, user);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole);
            if (!isAuthorized)
            {
                var userId = _identityService.Get(User).Id;
                if (id != userId)
                {
                    return Forbid();
                }
            }
            var user = await _service.GetUser(id);
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole);
            if (!isAuthorized)
            {
                var userId = _identityService.Get(User).Id;
                if (id != userId)
                {
                    return Forbid();
                }
            }
            await _service.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole);
            if (!isAuthorized)
            {
                return Forbid();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole);
            if (!isAuthorized)
            {
                return Forbid();
            }
            if (ModelState.IsValid)
            {
                if (user.Gender.ToString() == "Male")
                {
                    user.Gender = Gender.Male;
                }
                else
                {
                    if (user.Gender.ToString() == "Female")
                    {
                        user.Gender = Gender.Female;
                    }
                }
                await _service.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}