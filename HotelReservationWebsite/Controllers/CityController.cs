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
    [Area("Admin")]
    public class CityController : Controller
    {

        private readonly ICityService _service;
        public CityController(ICityService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var cities = await _service.GetCities(searchString);
            var cityVM = new CityViewModel
            {
                SearchString = searchString,
                Cities = cities.ToList()
            };
            return View(cityVM);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var city = await _service.GetCity(id);
            return View(city);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var city = await _service.GetCity(id);
            return View(city);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, City city)
        {
            if (id != city.CityID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateCity(id, city);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var city = await _service.GetCity(id);
            return View(city);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _service.DeleteCity(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateCity(city);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}