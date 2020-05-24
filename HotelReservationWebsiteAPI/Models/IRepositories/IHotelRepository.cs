using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;

namespace HotelReservationWebsiteAPI.Models.IRepositories
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetHotels(string searchString = null);
        Task<Room> GetRoom(int hotelID, int roomID);
        // Task<Room> CreateRoom(int hotelID, int roomID);
    }
}