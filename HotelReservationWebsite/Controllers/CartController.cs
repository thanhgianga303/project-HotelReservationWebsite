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
            var renter = _identityService.Get(User);
            await _cartService.AddItemToCart(renter, newCartItem);

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteItem(CartItem cartItem)
        {
            Console.WriteLine("daaaass");
            var renter = _identityService.Get(User);
            await _cartService.DeleteItem(renter, cartItem.Id);
            return RedirectToAction("Index", "Cart");
        }
    }
}