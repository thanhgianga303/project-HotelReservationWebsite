namespace HotelReservationWebsiteAPI.DTOs
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccountStatus { get; set; }
    }

}