using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetRooms(string searchString);
        Task<Room> GetRoom(int id);
        Task CreateRoom(Room Room);
        Task UpdateRoom(int id, Room Room);
        Task DeleteRoom(int id);
    }
}