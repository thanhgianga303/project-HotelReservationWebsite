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
        private readonly IRoomCategoryService _categoryService;
        private readonly AppSettings _settings;
        public readonly IWebHostEnvironment _webHost;
        public HotelController(IHotelService hotelService,
                            ICityService cityService,
                            IRoomCategoryService categoryService,
                            IOptions<AppSettings> settings,
                            IWebHostEnvironment webHost)
        {
            _hotelService = hotelService;
            _cityService = cityService;
            _settings = settings.Value;
            _webHost = webHost;
            _categoryService = categoryService;
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
                HotelId = id,
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
            // Console.WriteLine("giangcoi" + id);
            await _hotelService.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HotelViewModel hotelVM)
        {
            if (hotelVM.ImageUrl == null)
            {
                hotelVM.Hotel.ImageUrl = hotelVM.ImageUrlDisplay;
                await _hotelService.UpdateHotel(hotelVM.Hotel.HotelID, hotelVM.Hotel);
            }
            else
            {
                hotelVM.Hotel.ImageUrl = hotelVM.ImageUrl.FileName;
                await _hotelService.UpdateHotel(hotelVM.Hotel.HotelID, hotelVM.Hotel);
                await UploadFileImg(hotelVM.ImageUrl);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id, string searchString)
        {
            var hotel = await _hotelService.GetHotel(id);
            var cities = await _cityService.GetCities(searchString);
            var hotelVM = new HotelViewModel
            {
                ImageUrlDisplay = hotel.ImageUrl,
                Cities = cities.ToList(),
                Hotel = ChangeUriPlaceholderHotel(hotel)
            };
            return View(hotelVM);
        }
        [HttpGet]
        public async Task<IActionResult> EditRoom(int roomId, int hotelId)
        {
            var room = await _hotelService.GetRoom(roomId, hotelId);
            var categories = await _categoryService.GetRoomCategories();
            var roomVM = new RoomViewModel
            {
                ImageUrlDisPlay = room.ImageUrl,
                RoomCategories = categories.ToList(),
                Room = ChangeUriPlaceholderRoom(room)
            };
            return View(roomVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditRoom(RoomViewModel roomVM)
        {
            if (roomVM.ImageUrl == null)
            {
                roomVM.Room.ImageUrl = roomVM.ImageUrlDisPlay;
                await _hotelService.UpdateRoom(roomVM.Room.RoomID, roomVM.Room.HotelID, roomVM.Room);
            }
            else
            {
                roomVM.Room.ImageUrl = roomVM.ImageUrl.FileName;
                await _hotelService.UpdateRoom(roomVM.Room.RoomID, roomVM.Room.HotelID, roomVM.Room);
                await UploadFileImg(roomVM.ImageUrl);
            }
            return RedirectToAction("EditRoom", new { roomId = roomVM.Room.RoomID, hotelId = roomVM.Room.HotelID });
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRoom(int roomId, int hotelId)
        {
            var room = await _hotelService.GetRoom(roomId, hotelId);
            var roomVM = new RoomViewModel
            {
                Room = ChangeUriPlaceholderRoom(room)
            };
            return View(roomVM);
        }
        [HttpGet]
        public async Task<IActionResult> CreateRoom(int id)
        {
            Console.WriteLine("idd" + id);
            var categories = await _categoryService.GetRoomCategories();
            // var hotel = await _hotelService.GetHotel(hotelId);
            var roomVM = new RoomViewModel
            {
                RoomCategories = categories.ToList(),
                HotelId = id
            };
            return View(roomVM);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomViewModel roomVM)
        {
            roomVM.Room.HotelID = roomVM.HotelId;
            roomVM.Room.ImageUrl = roomVM.ImageUrl.FileName;
            roomVM.Room.RoomStatus = 1;
            await _hotelService.CreateRoom(roomVM.Room);
            await UploadFileImg(roomVM.ImageUrl);
            return RedirectToAction("SeeRoomList", new { id = roomVM.Room.HotelID });
        }
        [HttpPost, ActionName("DeleteRoom")]
        public async Task<IActionResult> DeleteRoomConfirm(int roomId, int hotelId)
        {
            await _hotelService.DeleteRoom(roomId, hotelId);
            return RedirectToAction("SeeRoomList", new { id = hotelId });
        }
        private IList<Hotel> ChangeUriPlaceholderHotels(List<Hotel> hotels)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            // var imageUrl = "";
            hotels.ForEach(x =>
            {
                x.ImageUrl = baseUri + "/images/" + x.ImageUrl;
            });

            return hotels;
        }
        private Room ChangeUriPlaceholderRoom(Room room)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            room.ImageUrl = baseUri + "/images/" + room.ImageUrl;
            return room;
        }
        private Hotel ChangeUriPlaceholderHotel(Hotel hotel)
        {
            var baseUri = _settings.ExternalCatalogBaseUrl;
            hotel.ImageUrl = baseUri + "/images/" + hotel.ImageUrl;
            return hotel;
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