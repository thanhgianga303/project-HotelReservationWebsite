using System.Collections.Generic;
using System.Threading.Tasks;
using RoomCategoryAPI.Infrastructure;
using RoomCategoryAPI.Models;
using RoomCategoryAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace RoomCategoryAPI.Data.Repositories
{
    public class RoomCategoryRepository : Repository<RoomCategory>, IRoomCategoryRepository
    {
        private readonly RoomCategoryContext _context;
        public RoomCategoryRepository(RoomCategoryContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RoomCategory>> GetRoomCategories()
        {
            var roomcategories = from m in _context.RoomCategories
                                 select m;
            return await roomcategories.ToListAsync();
        }
    }
}