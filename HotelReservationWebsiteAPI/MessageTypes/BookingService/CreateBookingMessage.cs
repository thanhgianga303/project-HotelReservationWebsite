using System;
using System.Collections.Generic;

namespace MessageTypes.BookingService
{
    public class CreateBookingMessage
    {
        public int BookingId { get; set; }
        public virtual IEnumerable<BookingItemDTO> Items { get; set; }
    }
    public class BookingItemDTO
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string HotelId { get; set; }
        public string RoomId { get; set; }
        public string HotelName { get; set; }
        public string RoomName { get; set; }
        public string RoomNumber { get; set; }
        public string ImageUri { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string RoomArea { get; set; }
        public string NumberOfBeds { get; set; }
        public string OwnerId { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int DayNumber { get; set; }
        public decimal Cost { get; set; }
    }
}
