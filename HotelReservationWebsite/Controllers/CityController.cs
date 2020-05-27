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
            await _service.CreateCity(city);
            send(city);
            return RedirectToAction(nameof(Index));
        }
        public void send(City city)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                // var a = new User("12312344", "123");
                var message = JsonConvert.SerializeObject(city); //Chuyển a thành chuỗi json
                // var message = "Hello World!";
                // var body = Encoding.UTF8.GetBytes(message);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            // Console.WriteLine(" Press [enter] to exit.");
            // Console.ReadLine();
        }


    }
}