using System;
using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int AccountID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityCard { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<BookingDetail> BookingDetails { get; set; }
        public Account Account { get; set; }
    }

}