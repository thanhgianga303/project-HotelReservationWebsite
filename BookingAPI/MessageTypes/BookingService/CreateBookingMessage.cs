using System.Collections.Generic;
using BookingAPI.DTOs;

namespace MessageTypes.BookingService
{
    public class CreateBookingMessage
    {
        public int BookingId { get; set; }
        public virtual IEnumerable<BookingItemDTO> Items { get; set; }
    }
}
