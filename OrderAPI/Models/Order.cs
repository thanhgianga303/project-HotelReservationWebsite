using System;
using System.Collections.Generic;

namespace OrderAPI.Models
{

    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BookingDate { get; set; }
        public OrderStatus Status { get; set; }
        // public string Address { get; set; }
        public string PaymentAuthCode { get; set; }
        public decimal Total { get; set; }
        public virtual IEnumerable<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
    public enum OrderStatus
    {
        CheckedIn = 1,
        CheckedOut = 2,
    }
}