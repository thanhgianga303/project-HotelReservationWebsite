using System.Collections.Generic;
namespace HotelReservationWebsite.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string RoleDecribe { get; set; }
        public List<Account> ListAccount { get; set; }
    }

}