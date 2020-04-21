using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class BookingDetailRepository : Repository<BookingDetail>, IBookingDetailRepository
    {
        private readonly HotelReservationWebsiteContext _context;
        public BookingDetailRepository(HotelReservationWebsiteContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookingDetail>> GetBookingDetails(string searchString = null)
        {
            var bookingdetails = from m in _context.BookingDetails
                                 select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                bookingdetails = bookingdetails.Where(m => m.BookingDetailStatus.ToString().Contains(searchString));
            }
            return await bookingdetails.ToListAsync();
        }
    }
}