using System.Collections.Generic;
namespace HotelReservationWebsite.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public int CityID { get; set; }
        public string HotelName { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public HotelStatus HotelStatus { get; set; }
        public string OwnerID { get; set; }
        public List<Room> Rooms { get; set; }
        public City City { get; set; }
    }
    public enum HotelStatus
    {
        Submitted = 0,
        Approved = 1,
        Rejected = 2
    }

}