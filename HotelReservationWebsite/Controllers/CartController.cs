using System;
using System.Threading.Tasks;
using HotelReservationWebsite.IServices;
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
        public async Task<IActionResult> AddToCart(Hotel hotel)
        {
            Console.WriteLine("adasd1" + hotel.HotelID);
            var newCartItem = new CartItem
            {
                Id = Guid.NewGuid().ToString(),
                HotelId = hotel.HotelID.ToString(),
                HotelName = hotel.HotelName,
                ImageUrl = hotel.ImageUrl
            };
            var buyer = _identityService.Get(User);
            // System.Diagnostics.Debug.WriteLine(newCartItem);
            await _cartService.AddItemToCart(buyer, newCartItem);

            return RedirectToAction("Index", "Home");
            // return View();
        }
    }
}