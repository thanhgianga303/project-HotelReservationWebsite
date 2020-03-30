using System;

namespace HotelReservationWebsite.Models
{
    public class Custommer
    {
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

}