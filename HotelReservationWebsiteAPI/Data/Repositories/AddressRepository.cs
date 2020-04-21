using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly HotelReservationWebsiteContext _context;
        public AddressRepository(HotelReservationWebsiteContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Address>> GetAddresses(string searchString = null)
        {
            var addresses = from m in _context.Addresses
                            select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                addresses = addresses.Where(m => m.HotelAddress.Contains(searchString));
            }
            return await addresses.ToListAsync();
        }
    }
}