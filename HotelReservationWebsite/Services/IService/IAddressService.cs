using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAddresses(string searchString);
        Task<Address> GetAddress(int id);
        Task CreateAddress(Address Address);
        Task UpdateAddress(int id, Address Address);
        Task DeleteAddress(int id);
    }
}