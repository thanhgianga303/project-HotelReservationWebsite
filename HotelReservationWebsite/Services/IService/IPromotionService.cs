using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> GetPromotions(string searchString);
        Task<Promotion> GetPromotion(int id);
        Task CreatePromotion(Promotion Promotion);
        Task UpdatePromotion(int id, Promotion Promotion);
        Task DeletePromotion(int id);
    }
}