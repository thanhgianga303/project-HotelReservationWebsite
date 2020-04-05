using System;

namespace HotelReservationWebsiteAPI.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int AccountID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }
    }

}