using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationWebsite.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string BuyerId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 60")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please enter the format: the first letter must be uppercase, the letter has no number")]
        public string Name { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 11")]
        [RegularExpression(@"^[0][0-9]{9,10}$", ErrorMessage = "Please enter the number")]
        public string Phone { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Length must be between 3 to 60")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Please enter the number")]
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