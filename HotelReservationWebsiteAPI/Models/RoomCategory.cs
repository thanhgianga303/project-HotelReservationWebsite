using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.Models
{
    public class RoomCategory
    {
        public int RoomCategoryID { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public double UnitPrice { get; set; }
        public List<Room> Rooms { get; set; }
    }

}