using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccounts(string searchString);
        Task<Account> GetAccount(int id);
        Task CreateAccount(Account Account);
        Task UpdateAccount(int id, Account Account);
        Task DeleteAccount(int id);
    }
}