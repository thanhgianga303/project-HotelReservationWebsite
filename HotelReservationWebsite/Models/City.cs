using System.Collections.Generic;
namespace HotelReservationWebsite.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public List<Hotel> Hotels { get; set; }
    }

}