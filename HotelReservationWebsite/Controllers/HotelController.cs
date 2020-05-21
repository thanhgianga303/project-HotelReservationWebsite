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
        private readonly AppSettings _settings;
        public readonly IWebHostEnvironment _webHost;
        public HotelController(IHotelService hotelService, IOptions<AppSettings> settings, IWebHostEnvironment webHost)
        {
            _hotelService = hotelService;
            _settings = settings.Value;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var hotels = await _hotelService.GetHotels(searchString);
            var hotelsVM = new HotelViewModel
            {
                Hotels = ChangeUriPlaceholder(hotels.ToList())
            };
            return View(hotelsVM);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Hotel hotel, IFormFile ImageUrl)
        {
            hotel.ImageUrl = ImageUrl.FileName;
            Console.WriteLine("giangcoi123" + hotel.ImageUrl);
            await _hotelService.CreateHotel(hotel);
            await UploadFileImg(ImageUrl);
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
        private IList<Hotel> ChangeUriPlaceholder(List<Hotel> hotels)
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