using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly HotelReservationWebsiteContext _context;
        public CustomerRepository(HotelReservationWebsiteContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetCustomers(string searchString = null)
        {
            var customers = from m in _context.Customers
                            select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(m => m.CustomerCode.Contains(searchString)
                 || m.CustomerName.Contains(searchString)
                 || m.Email.Contains(searchString)
                 || m.IdentityCard.Contains(searchString)
                 || m.Email.Contains(searchString)
                 || m.Phone.Contains(searchString));
            }
            return await customers.ToListAsync();
        }
    }
}