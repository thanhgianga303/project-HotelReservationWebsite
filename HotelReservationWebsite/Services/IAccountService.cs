
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAll();
    }
}