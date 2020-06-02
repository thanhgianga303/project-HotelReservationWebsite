using System;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Microsoft.AspNetCore.Mvc;
// using Polly.CircuitBreaker;
namespace HotelReservationWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IIdentityService<Buyer> _identityService;
        public CartController(ICartService cartService, IIdentityService<Buyer> identityService)
        {
            _cartService = cartService;
            _identityService = identityService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(Room room)
        {
            // Console.WriteLine("adasd1" + hotel.HotelID);
            var newCartItem = new CartItem
            {
                Id = Guid.NewGuid().ToString(),
                HotelId = room.HotelID.ToString(),
                RoomId = room.RoomID.ToString(),
                RoomName = room.RoomName,
                RoomNumber = room.RoomNumber.ToString(),
                CategoryName = room.RoomCategory.CategoryName,
                HotelName = room.Hotel.HotelName,
                Address = room.Hotel.Address,
                City = room.Hotel.City.CityName,
                UnitPrice = room.UnitPrice,
                ImageUrl = room.ImageUrl,
            };
            var buyer = _identityService.Get(User);
            // System.Diagnostics.Debug.WriteLine(newCartItem);
            // Console.WriteLine()
            await _cartService.AddItemToCart(buyer, newCartItem);

            return RedirectToAction("Index", "Home");
        }
    }
}