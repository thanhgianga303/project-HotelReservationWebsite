using System;
using System.Collections.Generic;

namespace HotelReservationWebsite.Models
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
        //Stripe
        public decimal Total { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime CardExpiration { get; set; }
        public string CardExpirationShort { get; set; }
        public string CardSecurityNumber { get; set; }
        public int CardType { get; set; }
        public string StripeToken { get; set; }
        public IList<BookingItem> Items { get; set; } = new List<BookingItem>();
    }


    public enum BookingStatus
    {
        Booked = 0,
        checkedIn = 1,
        checkedOut = 2
    }
}