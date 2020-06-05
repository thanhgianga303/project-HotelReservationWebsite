using System.Collections.Generic;
using System.Threading.Tasks;
using BookingAPI.Infrastructure.Repositories;
using BookingAPI.Models;

namespace BookingAPI.Models
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetByBuyerAsync(string buyerId);
    }
}