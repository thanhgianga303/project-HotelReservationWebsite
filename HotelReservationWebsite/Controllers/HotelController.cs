using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsite.Authorization;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HotelReservationWebsite.Controllers
{

    [Authorize(Roles = "Lessors,Managers,Administrators")]
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IRoomCategoryService _categoryService;
        private readonly IIdentityService<Buyer> _identityService;
        private readonly IAuthorizationService _authorizationService;
        private readonly AppSettings _settings;
        public readonly IWebHostEnvironment _webHost;
        public HotelController(IHotelService hotelService,
                            IRoomCategoryService categoryService,
                            IOptions<AppSettings> settings,
                            IWebHostEnvironment webHost,
                            IIdentityService<Buyer> identityService,
                            IAuthorizationService authorizationService)
        {
            _hotelService = hotelService;
            _settings = settings.Value;
            _webHost = webHost;
            _categoryService = categoryService;
            _identityService = identityService;
            _authorizationService = authorizationService;
        }
        public async Task<IActionResult> Index(string SearchString)
        {
            var hotels = await _hotelService.GetHotels(SearchString);
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole) ||
                                User.IsInRole(Constants.ManagersRole);
            if (!isAuthorized)
            {
                var userId = _identityService.Get(User).Id;
                hotels = hotels.Where(h => h.OwnerID == userId).ToList();
            }
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelViewModel hotelVM)
        {
            if (ModelState.IsValid)
            {
                hotelVM.Hotel.OwnerID = _identityService.Get(User).Id;
                hotelVM.Hotel.ImageUrl = hotelVM.ImageUrl.FileName;
                await _hotelService.CreateHotel(hotelVM.Hotel);
                await UploadFileImg(hotelVM.ImageUrl);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var hotel = await _hotelService.GetHotel(id);
            var hotelVM = new HotelViewModel()
            {
                ImageUrlDisplay = hotel.ImageUrl,
                Hotel = ChangeUriPlaceholderHotel(hotel)
            };

            return View(hotelVM);
        }
        [HttpPost]
        public async Task<IActionResult> Approve(HotelViewModel hotelVM)
        {
            var isAuthorize = await _authorizationService.AuthorizeAsync(User, hotelVM.Hotel, HotelOperations.Approve);
            if (!isAuthorize.Succeeded)
            {
                return Forbid();
            }
            hotelVM.Hotel.HotelStatus = HotelStatus.Approved;
            hotelVM.Hotel.ImageUrl = hotelVM.ImageUrlDisplay;
            await _hotelService.UpdateHotel(hotelVM.Hotel.HotelID, hotelVM.Hotel);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Reject(HotelViewModel hotelVM)
        {
            var isAuthorize = await _authorizationService.AuthorizeAsync(User, hotelVM.Hotel, HotelOperations.Reject);
            if (!isAuthorize.Succeeded)
            {
                return Forbid();
            }
            hotelVM.Hotel.HotelStatus = HotelStatus.Rejected;
            hotelVM.Hotel.ImageUrl = hotelVM.ImageUrlDisplay;
            await _hotelService.UpdateHotel(hotelVM.Hotel.HotelID, hotelVM.Hotel);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var hotel = ChangeUriPlaceholderHotel(await _hotelService.GetHotel(id));
            return View(hotel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var hotel = await _hotelService.GetHotel(id);

            var isAuthorize = await _authorizationService.AuthorizeAsync(User, hotel, HotelOperations.Delete);
            if (!isAuthorize.Succeeded)
            {
                return Forbid();
            }
            await _hotelService.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HotelViewModel hotelVM)
        {
            var isAuthorize = await _authorizationService.AuthorizeAsync(User, hotelVM.Hotel, HotelOperations.Update);
            if (!isAuthorize.Succeeded)
            {
                return Forbid();
            }

            if (hotelVM.ChangeImageUrl == null)
            {
                hotelVM.Hotel.ImageUrl = hotelVM.ImageUrlDisplay;
                await _hotelService.UpdateHotel(hotelVM.Hotel.HotelID, hotelVM.Hotel);
                return RedirectToAction("Index");
            }
            else
            {
                hotelVM.Hotel.ImageUrl = hotelVM.ChangeImageUrl.FileName;
                await _hotelService.UpdateHotel(hotelVM.Hotel.HotelID, hotelVM.Hotel);
                await UploadFileImg(hotelVM.ChangeImageUrl);
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id, string searchString)
        {
            var hotel = await _hotelService.GetHotel(id);
            var hotelVM = new HotelViewModel
            {
                ImageUrlDisplay = hotel.ImageUrl,
                Hotel = ChangeUriPlaceholderHotel(hotel)
            };
            return View(hotelVM);
        }
        [HttpGet]
        public async Task<IActionResult> EditRoom(int roomId, int hotelId)
        {
            var room = await _hotelService.GetRoom(roomId, hotelId);
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole);
            if (!isAuthorized)
            {
                var userId = _identityService.Get(User).Id;
                if (room.OwnerId != userId)
                {
                    return Forbid();
                }
            }
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
            var isAuthorize = await _authorizationService.AuthorizeAsync(User, roomVM.Room, HotelOperations.Update);
            if (!isAuthorize.Succeeded)
            {
                return Forbid();
            }
            if (roomVM.ChangeImageUrl == null)
            {
                roomVM.Room.ImageUrl = roomVM.ImageUrlDisPlay;
                await _hotelService.UpdateRoom(roomVM.Room.RoomID, roomVM.Room.HotelID, roomVM.Room);
            }
            else
            {
                roomVM.Room.ImageUrl = roomVM.ChangeImageUrl.FileName;
                await _hotelService.UpdateRoom(roomVM.Room.RoomID, roomVM.Room.HotelID, roomVM.Room);
                await UploadFileImg(roomVM.ChangeImageUrl);
            }
            return RedirectToAction("EditRoom", new { roomId = roomVM.Room.RoomID, hotelId = roomVM.Room.HotelID });
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRoom(int roomId, int hotelId)
        {
            var room = await _hotelService.GetRoom(roomId, hotelId);
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole);
            if (!isAuthorized)
            {
                var userId = _identityService.Get(User).Id;
                if (room.OwnerId != userId)
                {
                    return Forbid();
                }
            }
            var roomVM = new RoomViewModel
            {
                Room = ChangeUriPlaceholderRoom(room)
            };
            return View(roomVM);
        }
        [HttpGet]
        public async Task<IActionResult> CreateRoom(int id)
        {
            var isAuthorized = User.IsInRole(Constants.AdministratorsRole);
            if (!isAuthorized)
            {
                var userId = _identityService.Get(User).Id;
                var hotel = await _hotelService.GetHotel(id);
                if (hotel.OwnerID != userId)
                {
                    return Forbid();
                }
            }
            var categories = await _categoryService.GetRoomCategories();
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
            var userId = _identityService.Get(User).Id;
            roomVM.Room.HotelID = roomVM.HotelId;
            roomVM.Room.ImageUrl = roomVM.ImageUrl.FileName;
            roomVM.Room.RoomStatus = 1;
            roomVM.Room.OwnerId = userId;
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