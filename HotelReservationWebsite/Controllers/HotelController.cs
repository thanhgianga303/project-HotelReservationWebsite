using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HotelReservationWebsite.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly ICityService _cityService;
        // private readonly IRoomService _roomService;
        private readonly AppSettings _settings;
        public readonly IWebHostEnvironment _webHost;
        public HotelController(IHotelService hotelService,
                            ICityService cityService,
                            IOptions<AppSettings> settings,
                            IWebHostEnvironment webHost)
        {
            _hotelService = hotelService;
            _cityService = cityService;
            _settings = settings.Value;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var hotels = await _hotelService.GetHotels(searchString);
            var hotelsVM = new HotelViewModel
            {
                Hotels = ChangeUriPlaceholderHotels(hotels.ToList())
            };
            return View(hotelsVM);
        }
        [HttpGet]
        public async Task<IActionResult> SeeRoomList(int id)
        {
            var hotel = await _hotelService.GetHotel(id);
            var roomVM = new RoomViewModel
            {
                // Hotels = ChangeUriPlaceholder(hotels.ToList())
                Rooms = ChangeUriPlaceholderRooms(hotel.Rooms)
            };
            return View(roomVM);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsRoom(int roomID, int hotelID)
        {
            var room = await _hotelService.GetRoom(roomID, hotelID);
            var roomChange = ChangeUriPlaceholderRoom(room);
            return View(roomChange);
        }
        [HttpGet]
        public async Task<IActionResult> Create(string searchString)
        {
            var cities = await _cityService.GetCities(searchString);
            var hotelsVM = new HotelViewModel
            {
                Cities = cities.ToList()
            };
            return View(hotelsVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(HotelViewModel hotelVM)
        {
            hotelVM.Hotel.ImageUrl = hotelVM.ImageUrl.FileName;
            await _hotelService.CreateHotel(hotelVM.Hotel);
            await UploadFileImg(hotelVM.ImageUrl);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var hotel = await _hotelService.GetHotel(id);
            return View(hotel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            Console.WriteLine("giangcoi" + id);
            await _hotelService.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }
        private IList<Hotel> ChangeUriPlaceholderHotels(List<Hotel> hotels)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            // var imageUrl = "";
            hotels.ForEach(x =>
            {

                // imageUrl = x.ImageUrl;
                x.ImageUrl = baseUri + "/images/" + x.ImageUrl;

            });

            return hotels;
        }
        private Room ChangeUriPlaceholderRoom(Room room)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            // var imageUrl = "";
            room.ImageUrl = baseUri + "/images/" + room.ImageUrl;
            return room;
        }
        private IList<Room> ChangeUriPlaceholderRooms(List<Room> rooms)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            rooms.ForEach(x =>
            {

                x.ImageUrl = baseUri + "/images/" + x.ImageUrl;

            });

            return rooms;
        }
        private async Task UploadFileImg(IFormFile imgFile)
        {
            var saveImg = Path.Combine(_webHost.WebRootPath, "images", imgFile.FileName);
            string imgExt = Path.GetExtension(imgFile.FileName);
            if (imgExt == ".jpg" || imgExt == ".png")
            {
                using (var upLoading = new FileStream(saveImg, FileMode.Create))
                {
                    await imgFile.CopyToAsync(upLoading);
                    ViewData["Message"] = "The Selected File" + imgFile.FileName + "Is Save Successfully";
                }
            }
            else
            {
                ViewData["Message"] = "Only The Image File Types .jpg & .png are allowed";
            }
        }
    }
}