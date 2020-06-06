using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface ICartService
    {
        Task<Cart> GetCart(Buyer buyer);
        Task AddItemToCart(Buyer buyer, CartItem cartItem);
        Booking MapCartToBooking(Cart cart);
        Task DeleteItem(Buyer buyer, string id);
        Task ClearCart(Buyer user);
        Task<Cart> UpdateCart(Cart cart);
    }
}