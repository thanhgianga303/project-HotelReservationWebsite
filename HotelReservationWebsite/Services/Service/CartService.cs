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
            var cart = await GetCart(user);

            var itemFound = cart.Items.Find(x => x.HotelId == item.HotelId && x.RoomId == item.RoomId);

            if (itemFound == null)
            {
                cart.Items.Add(item);
            }
            await UpdateCart(cart);
        }
        public async Task DeleteItem(Buyer user, string id)
        {
            var cart = await GetCart(user);
            var itemFound = cart.Items.Find(x => x.Id == id);
            if (itemFound != null)
            {
                cart.Items.Remove(itemFound);
            }
            await UpdateCart(cart);
        }

        public Booking MapCartToBooking(Cart cart)
        {
            var booking = new Booking();

            foreach (var item in cart.Items)
            {
                booking.Items.Add(new BookingItem
                {
                    HotelId = item.HotelId,
                    HotelName = item.HotelName,
                    RoomId = item.RoomId,
                    RoomName = item.RoomName,
                    RoomNumber = item.RoomNumber,
                    ImageUri = item.ImageUrl,
                    Address = item.Address,
                    City = item.City,
                    RoomArea = item.RoomArea,
                    NumberOfBeds = item.NumberOfBeds,
                    OwnerId = item.OwnerId,
                    CategoryName = item.CategoryName,
                    UnitPrice = item.UnitPrice,
                    CheckIn = item.CheckIn,
                    CheckOut = item.CheckOut,
                    DayNumber = item.dayNumber().Days,
                    Cost = item.cost(),
                });
            }

            return booking;
        }

        public async Task ClearCart(Buyer buyer)
        {
            var uri = _serviceBaseUrl + $"/{buyer.Id}";

            await _httpClient.DeleteAsync(uri);
        }
    }
}