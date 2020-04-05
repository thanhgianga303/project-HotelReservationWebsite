using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public List<Address> Addresses { get; set; }
    }

}