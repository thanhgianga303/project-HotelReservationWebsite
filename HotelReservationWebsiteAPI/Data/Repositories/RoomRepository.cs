using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly HotelReservationWebsiteContext _context;
        public RoomRepository(HotelReservationWebsiteContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Room>> GetRooms(string searchString = null)
        {
            var rooms = from m in _context.Rooms
                        select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                rooms = rooms.Where(m => m.RoomName.Contains(searchString)
                 || m.RoomNumber.ToString().Contains(searchString)
                || m.RoomStatus.ToString().Contains(searchString));
            }
            return await rooms.ToListAsync();
        }

    }
}