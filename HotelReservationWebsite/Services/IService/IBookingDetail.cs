using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IBookingDetailService
    {
        Task<IEnumerable<BookingDetail>> GetBookingDetails(string searchString);
        // string genre, string searchString1
        Task<BookingDetail> GetBookingDetail(int id);
        Task CreateBookingDetail(BookingDetail BookingDetail);
        Task UpdateBookingDetail(int id, BookingDetail BookingDetail);
        Task DeleteBookingDetail(int id);
    }
}