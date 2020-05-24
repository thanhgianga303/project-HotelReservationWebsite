using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotels(string searchString);
        Task<Hotel> GetHotel(int id);
        Task<Room> GetRoom(int roomId, int hotelId);
        Task CreateRoom(Room room);
        Task UpdateRoom(int roomId, int hotelId, Room room);
        Task DeleteRoom(int roomId, int hotelId);
        Task CreateHotel(Hotel Hotel);
        Task UpdateHotel(int id, Hotel Hotel);
        Task DeleteHotel(int id);
    }
}