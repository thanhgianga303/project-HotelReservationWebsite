using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly HotelReservationWebsiteContext _context;
        public AccountRepository(HotelReservationWebsiteContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Account>> GetAccounts(string searchString = null)
        {
            var accounts = from m in _context.Accounts
                           select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                accounts = accounts.Where(m => m.Username.Contains(searchString)
                || m.AccountStatus.ToString().Contains(searchString));
            }
            return await accounts.ToListAsync();
        }
    }
}