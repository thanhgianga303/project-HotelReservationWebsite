using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly HotelReservationWebsiteContext _context;
        public CityRepository(HotelReservationWebsiteContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> GetCities(string searchString = null)
        {
            var cities = from m in _context.Cities
                         select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                cities = cities.Where(m => m.CityName.Contains(searchString));
            }
            return await cities.ToListAsync();
        }
    }
}