using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models.InputModel;

namespace HotelReservationWebsiteAPI.Models.IRepositories
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetApplicationUsers();
        Task Create(InputUserModel input);
        Task CreateCustomer(InputUserModel input);
        Task CreateEmployee(InputUserModel input);
        Task Update(string id, InputChangeInfoModel input);
        Task Delete(string id);
        Task<ApplicationUser> GetBy(string id);
    }
}