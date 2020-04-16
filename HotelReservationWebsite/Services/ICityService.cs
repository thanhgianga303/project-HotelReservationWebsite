using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCitys();
        // string genre, string searchString1
        Task<City> GetCity(int id);
        Task CreateCity(City City);
        Task UpdateCity(int id, City City);
        Task DeleteCity(int id);
    }
}