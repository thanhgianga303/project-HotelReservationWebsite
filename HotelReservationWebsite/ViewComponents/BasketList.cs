using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;

namespace HotelReservationWebsite.ViewComponents
{
    public class BasketList : ViewComponent
    {
        private readonly ICartService _cartSvc;

        public BasketList(ICartService cartSvc)
        {
            _cartSvc = cartSvc;
        }

        public async Task<IViewComponentResult> InvokeAsync(Buyer user)
        {
            var cart = await _cartSvc.GetCart(user);

            return View(cart);
        }

    }
}