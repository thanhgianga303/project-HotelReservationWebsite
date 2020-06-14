using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace HotelReservationWebsite.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var users = await _service.GetUsers();
            var userVm = new UserViewModel
            {
                Users = users.ToList()
            };
            return View(userVm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var user = await _service.GetUser(id);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _service.GetUser(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, User user)
        {
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
            var user = await _service.GetUser(id);
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            await _service.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
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