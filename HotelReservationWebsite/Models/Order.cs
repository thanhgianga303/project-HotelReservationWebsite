using System;
using System.Collections.Generic;

namespace HotelReservationWebsite.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public string Address { get; set; }
        public string PaymentAuthCode { get; set; }
        public decimal Total { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime CardExpiration { get; set; }
        public string CardExpirationShort { get; set; }
        public string CardSecurityNumber { get; set; }
        public int CardType { get; set; }
        public string StripeToken { get; set; }
        public IList<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

    public enum OrderStatus
    {
        Preparing = 1,
        Shipped = 2,
        Delivered = 3
    }
}