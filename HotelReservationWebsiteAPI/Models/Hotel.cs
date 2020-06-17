using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public HotelStatus HotelStatus { get; set; }
        public string OwnerId { get; set; }
        public int NumberofReservation { get; set; }
        public virtual List<Room> Rooms { get; set; }
    }
    public enum HotelStatus
    {
        Submitted = 0,
        Approved = 1,
        Rejected = 2
    }

}