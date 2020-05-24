using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IRoomCategoryService
    {
        Task<IEnumerable<RoomCategory>> GetRoomCategories();
        Task<RoomCategory> GetRoomCategory(int id);
        Task CreateRoomCategory(RoomCategory RoomCategory);
        Task UpdateRoomCategory(int id, RoomCategory RoomCategory);
        Task DeleteRoomCategory(int id);
    }
}