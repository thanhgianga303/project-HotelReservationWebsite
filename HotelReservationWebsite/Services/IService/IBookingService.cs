using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetBookings();
        Task<IEnumerable<Booking>> GetBookings(string userId);
        Task<int> CreateBooking(Booking booking);
        Task<Booking> GetBooking(int id);
        Task UpdateBooking(int id, Booking booking);
    }
}