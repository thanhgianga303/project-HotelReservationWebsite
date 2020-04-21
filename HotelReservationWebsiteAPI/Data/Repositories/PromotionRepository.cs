using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class PromotionRepository : Repository<Promotion>, IPromotionRepository
    {
        private readonly HotelReservationWebsiteContext _context;
        public PromotionRepository(HotelReservationWebsiteContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Promotion>> GetPromotions(string searchString = null)
        {
            var promotions = from m in _context.Promotions
                             select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                promotions = promotions.Where(m => m.PromotionCode.Contains(searchString)
                || m.FormOfPromotion.Contains(searchString)
                || m.PromotionStatus.ToString().Contains(searchString));
            }
            return await promotions.ToListAsync();
        }
    }
}