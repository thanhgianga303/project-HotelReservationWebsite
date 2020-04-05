using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string RoleDecribe { get; set; }
        public List<Account> Accounts { get; set; }
    }

}