using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        private readonly HotelReservationWebsiteContext _context;
        public HotelRepository(HotelReservationWebsiteContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Hotel>> GetHotels(string searchString = null)
        {
            var hotels = from m in _context.Hotels
                         select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(m => m.HotelName.Contains(searchString)
             || m.HotelCode.Contains(searchString)
             || m.HotelStatus.ToString().Contains(searchString));
            }
            return await hotels.ToListAsync();
        }
        public async Task<Room> GetRoom(int hotelID, int roomID)
        {
            var room = _context.Rooms.Where(r => r.HotelID == hotelID && r.RoomID == roomID);
            return await room.FirstOrDefaultAsync();
        }
    }
}