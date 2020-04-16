using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.DTOs
{
    public class HotelDTO
    {
        public int HotelID { get; set; }
        public string HotelCode { get; set; }
        public string HotelName { get; set; }
        public int HotelStatus { get; set; }
    }

}