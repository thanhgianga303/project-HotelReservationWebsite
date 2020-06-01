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
                hotels = hotels.Where(m => m.HotelName.ToLower().Contains(searchString.ToLower())
                || m.Address.ToLower().Contains(searchString.ToLower())
                || m.City.CityName.ToLower().Contains(searchString.ToLower())
             );
            }
            return await hotels.ToListAsync();
        }
        public async Task<Room> GetRoom(int roomID, int hotelID)
        {
            var room = _context.Rooms.Where(r => r.HotelID == hotelID && r.RoomID == roomID);
            return await room.FirstOrDefaultAsync();
        }
        public async Task AddRoom(Room room)
        {
            await _context.AddAsync(room);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRoom(Room room)
        {
            _context.Update(room);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRoom(Room room)
        {
            _context.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}