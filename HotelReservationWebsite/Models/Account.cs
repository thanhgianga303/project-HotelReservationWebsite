namespace HotelReservationWebsite.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccountStatus { get; set; }
        public Customer Customer { get; set; }
        public Role Role { get; set; }
        public Employee Employee { get; set; }
    }

}