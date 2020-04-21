using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;

namespace HotelReservationWebsiteAPI.Models.IRepositories
{
    public interface IBookingDetailRepository : IRepository<BookingDetail>
    {
        Task<IEnumerable<BookingDetail>> GetBookingDetails(string searchString = null);
    }
}