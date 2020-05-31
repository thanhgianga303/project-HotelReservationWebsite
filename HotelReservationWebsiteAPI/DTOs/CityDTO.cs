using System.Collections.Generic;
using HotelReservationWebsiteAPI.Models;

namespace HotelReservationWebsiteAPI.DTOs
{
    public class CityDTO
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public List<Hotel> Hotels { get; set; }

    }
}
