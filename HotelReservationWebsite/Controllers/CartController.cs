using System;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
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
        public async Task<IActionResult> Index(Cart cart, string action)
        {
            var user = _identityService.Get(User);
            if (action == "Delete All")
            {
                await _cartService.ClearCart(user);
            }

            if (action == "Checkout")
            {
                return RedirectToAction("Create", "Booking");
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(RoomViewModel roomVM, Room room)
        {
            Console.WriteLine("testcccc" + room.Hotel.OwnerID);
            var newCartItem = new CartItem
            {
                Id = Guid.NewGuid().ToString(),
                HotelId = room.HotelID.ToString(),
                RoomId = room.RoomID.ToString(),
                RoomName = room.RoomName,
                RoomNumber = room.RoomNumber.ToString(),
                CategoryName = room.RoomCategoryName,
                HotelName = room.Hotel.HotelName,
                Address = room.Hotel.Address,
                City = room.Hotel.City,
                RoomArea = room.RoomArea,
                NumberOfBeds = room.NumberOfBeds,
                OwnerId = room.Hotel.OwnerID,
                UnitPrice = room.UnitPrice,
                ImageUrl = room.ImageUrl,
                CheckIn = roomVM.CheckIn,
                CheckOut = roomVM.CheckOut
            };
            var renter = _identityService.Get(User);
            await _cartService.AddItemToCart(renter, newCartItem);

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteItem(CartItem cartItem)
        {
            var renter = _identityService.Get(User);
            await _cartService.DeleteItem(renter, cartItem.Id);
            return RedirectToAction("Index", "Cart");
        }
    }
}