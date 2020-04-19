using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IRoomCategoryService
    {
        Task<IEnumerable<RoomCategory>> GetRoomCategories(string searchString);
        // string genre, string searchString1
        Task<RoomCategory> GetRoomCategory(int id);
        Task CreateRoomCategory(RoomCategory RoomCategory);
        Task UpdateRoomCategory(int id, RoomCategory RoomCategory);
        Task DeleteRoomCategory(int id);
    }
}