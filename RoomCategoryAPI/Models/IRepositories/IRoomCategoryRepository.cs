using System.Collections.Generic;
using System.Threading.Tasks;
using RoomCategoryAPI.Infrastructure;

namespace RoomCategoryAPI.Models.IRepositories
{
    public interface IRoomCategoryRepository : IRepository<RoomCategory>
    {
        Task<IEnumerable<RoomCategory>> GetRoomCategories();
    }
}