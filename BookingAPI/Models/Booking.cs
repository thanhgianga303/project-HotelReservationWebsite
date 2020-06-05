using System;
using System.Collections.Generic;

namespace BookingAPI.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string BuyerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string IdentityCard { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }
        public string PaymentAuthCode { get; set; }
        public decimal Total { get; set; }
        public virtual IEnumerable<BookingItem> Items { get; set; } = new List<BookingItem>();
    }

    public enum BookingStatus
    {
        Booked = 0,
        checkedIn = 1,
        checkedOut = 2
    }
}