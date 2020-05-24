using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class RoomCategoryRepository : Repository<RoomCategory>, IRoomCategoryRepository
    {
        private readonly HotelReservationWebsiteContext _context;
        public RoomCategoryRepository(HotelReservationWebsiteContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RoomCategory>> GetRoomCategories()
        {
            var roomcategories = from m in _context.RoomCategories
                                 select m;
            // if (!string.IsNullOrEmpty(searchString))
            // {
            //     roomcategories = roomcategories.Where(m => m.CategoryName.Contains(searchString)
            //      || m.CategoryCode.Contains(searchString));
            // }
            return await roomcategories.ToListAsync();
        }
    }
}