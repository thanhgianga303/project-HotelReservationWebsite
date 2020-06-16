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
    public class RoomCategoryController : Controller
    {
        private readonly IRoomCategoryService _service;
        public RoomCategoryController(IRoomCategoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var roomcategories = await _service.GetRoomCategories();
            var roomcategoryVM = new RoomCategoryViewModel
            {
                RoomCategories = roomcategories.ToList()
            };
            return View(roomcategoryVM);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var roomcategory = await _service.GetRoomCategory(id);
            return View(roomcategory);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var roomcategory = await _service.GetRoomCategory(id);
            return View(roomcategory);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, RoomCategory roomCategory)
        {
            if (id != roomCategory.RoomCategoryID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateRoomCategory(id, roomCategory);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var roomCategory = await _service.GetRoomCategory(id);
            return View(roomCategory);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _service.DeleteRoomCategory(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoomCategory roomCategory)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateRoomCategory(roomCategory);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}