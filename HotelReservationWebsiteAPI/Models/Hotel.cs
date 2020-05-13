using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public string HotelCode { get; set; }
        public string HotelName { get; set; }
        public string ImageUrl { get; set; }
        public int HotelStatus { get; set; }
        public virtual List<Room> Rooms { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }

}