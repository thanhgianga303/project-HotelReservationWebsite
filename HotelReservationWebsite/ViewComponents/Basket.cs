using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using HotelReservationWebsite.ViewModels;
using Polly.CircuitBreaker;
using System;

namespace HotelReservationWebsite.ViewComponents
{
    public class Basket : ViewComponent
    {
        private readonly ICartService _cartSvc;

        public Basket(ICartService cartSvc)
        {
            _cartSvc = cartSvc;
        }

        public async Task<IViewComponentResult> InvokeAsync(Buyer user)
        {
            var vm = new CartComponentViewModel();

            try
            {
                var cart = await _cartSvc.GetCart(user);
                vm.ItemsInCart = cart.Items.Count();
                // vm.TotalCost = cart.Total();
            }
            catch (BrokenCircuitException)
            {
                ViewBag.IsCartInoperative = true;
            }
            Console.WriteLine("number" + vm.ItemsInCart);

            return View(vm);
        }
    }
}