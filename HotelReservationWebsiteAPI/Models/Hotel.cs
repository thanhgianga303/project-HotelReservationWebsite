using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public int CityID { get; set; }
        public int AplicationUserID { get; set; }
        public string HotelCode { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public int HotelStatus { get; set; }
        public string OwnerId { get; set; }
        public virtual List<Room> Rooms { get; set; }
        public virtual City City { get; set; }
    }

}