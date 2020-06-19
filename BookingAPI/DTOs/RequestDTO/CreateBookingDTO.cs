using System.Collections.Generic;

namespace BookingAPI.DTOs.RequestDTO
{
    public class CreateBookingDTO
    {
        public IEnumerable<BookingItem> Items { get; set; }
    }
    public class BookingItem
    {
        public int HotelId { get; set; }
    }
}
