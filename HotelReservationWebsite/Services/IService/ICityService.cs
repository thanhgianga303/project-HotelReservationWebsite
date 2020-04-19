using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCities(string searchString);
        Task<City> GetCity(int id);
        Task CreateCity(City City);
        Task UpdateCity(int id, City City);
        Task DeleteCity(int id);
    }
}