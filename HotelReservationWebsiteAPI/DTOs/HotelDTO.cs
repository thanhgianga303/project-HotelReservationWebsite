using System.Collections.Generic;
using HotelReservationWebsiteAPI.Models;

namespace HotelReservationWebsiteAPI.DTOs
{
    public class HotelDTO
    {
        public int HotelID { get; set; }
        public int CityID { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public HotelStatus HotelStatus { get; set; }
        public string OwnerID { get; set; }
        public int NumberofReservation { get; set; }
        public List<Room> Rooms { get; set; }
        public City City { get; set; }
    }
}