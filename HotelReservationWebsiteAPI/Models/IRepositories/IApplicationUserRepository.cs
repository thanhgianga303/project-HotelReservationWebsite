using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;

namespace HotelReservationWebsiteAPI.Models.IRepositories
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetApplicationUsers();
    }
}