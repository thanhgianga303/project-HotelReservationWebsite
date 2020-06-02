using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using System;

namespace HotelReservationWebsite.Services.Service
{
    public class CartService : ICartService
    {
        private readonly string _serviceBaseUrl;
        private readonly IHttpClient _httpClient;

        public CartService(IHttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _serviceBaseUrl = $"{appSettings.Value.CartUrl}/api/cart";
        }

        public async Task<Cart> GetCart(Buyer buyer)
        {
            var uri = _serviceBaseUrl + $"/{buyer.Id}";

            var cart = await _httpClient.GetAsync<Cart>(uri);

            return cart ?? new Cart { Id = buyer.Id };
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            var url = _serviceBaseUrl;
            return await _httpClient.PutAsync<Cart>(url, cart);
        }

        public async Task AddItemToCart(Buyer user, CartItem item)
        {
            var dem = 0;
            var cart = await GetCart(user);

            var itemFound = cart.Items.Find(x => x.HotelId == item.HotelId && x.RoomId == item.RoomId);

            if (itemFound == null)
            {
                cart.Items.Add(item);
                dem++;
            }
            await UpdateCart(cart);
        }

        // public Order MapCartToOrder(Cart cart)
        // {
        //     var order = new Order();

        //     foreach (var item in cart.Items)
        //     {
        //         order.Items.Add(new OrderItem
        //         {
        //             ProductId = int.Parse(item.ProductId),
        //             ProductName = item.ProductName,
        //             UnitPrice = item.UnitPrice,
        //             PictureUri = item.PictureUri,
        //             Units = item.Quantity
        //         });
        //         order.Total += item.Quantity * item.UnitPrice;
        //     }

        //     return order;
        // }

        public async Task ClearCart(Buyer buyer)
        {
            var uri = _serviceBaseUrl + $"/{buyer.Id}";

            await _httpClient.DeleteAsync(uri);
        }

        // public async Task<Cart> SetQuantities(Buyer user, Dictionary<string, int> quantities)
        // {
        //     var basket = await GetCart(user);

        //     basket.Items.ForEach(x =>
        //     {
        //         if (quantities.TryGetValue(x.Id, out var quantity))
        //         {
        //             x.Quantity = quantity;
        //         }
        //     });

        //     return basket;
        // }
    }
}