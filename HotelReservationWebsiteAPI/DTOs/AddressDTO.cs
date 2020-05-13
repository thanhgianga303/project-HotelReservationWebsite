using HotelReservationWebsiteAPI.Models;

namespace HotelReservationWebsiteAPI.DTOs
{
    public class AddressDTO
    {
        public int AddressID { get; set; }
        public int CityID { get; set; }
        public int HotelID { get; set; }
        public string HotelAddress { get; set; }
        public City City { get; set; }
    }

}