using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.DTOs;
using HotelReservationWebsiteAPI.Infrastructure;

namespace HotelReservationWebsiteAPI.Models.IRepositories
{
    public interface ICityRepository : IRepository<City>
    {
        Task<IEnumerable<City>> GetCities(string searchString = null);
    }
}