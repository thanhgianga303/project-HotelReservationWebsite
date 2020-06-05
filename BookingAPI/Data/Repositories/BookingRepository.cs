using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingAPI.Infrastructure.Repositories;
using BookingAPI.Models;

namespace BookingAPI.Data.Repositories
{
    public class BookingRepository : EFRepository<Booking>, IBookingRepository
    {
        public BookingRepository(BookingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetByBuyerAsync(string buyerId)
        {
            return await Context.Bookings
                .Where(o => o.BuyerId == buyerId)
                .ToListAsync();
        }

        private BookingContext Context => Database as BookingContext;
    }
}