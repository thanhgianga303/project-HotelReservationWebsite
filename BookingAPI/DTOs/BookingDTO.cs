using System;
using System.Collections.Generic;
using BookingAPI.Models;

namespace BookingAPI.DTOs
{
    public class BookingDTO
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
        public IEnumerable<BookingItem> Items { get; set; } = new List<BookingItem>();
    }
}