using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string id);
        Task CreateUser(User User);
        Task UpdateUser(string id, User User);
        Task DeleteUser(string id);
    }
}