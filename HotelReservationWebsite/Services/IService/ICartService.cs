using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface ICartService
    {
        Task<Cart> GetCart(Buyer buyer);
        Task AddItemToCart(Buyer buyer, CartItem cartItem);
        // Task<Cart> SetQuantities(Buyer user, Dictionary<string, int> quantities);
        Task DeleteItem(Buyer buyer, string id);
        Task<Cart> UpdateCart(Cart cart);
    }
}