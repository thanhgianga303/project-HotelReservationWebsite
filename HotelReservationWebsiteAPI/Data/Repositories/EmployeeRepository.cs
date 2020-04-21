using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly HotelReservationWebsiteContext _context;
        public EmployeeRepository(HotelReservationWebsiteContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployees(string searchString = null)
        {
            var employees = from m in _context.Employees
                            select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(m => m.Email.Contains(searchString)
                 || m.EmployeeName.Contains(searchString) || m.Phone.Contains(searchString));
            }
            return await employees.ToListAsync();
        }
    }
}