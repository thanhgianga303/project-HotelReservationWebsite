using System.Collections.Generic;
namespace HotelReservationWebsiteAPI.Models
{
    public class RoomCategory
    {
        public int RoomCategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Room> Rooms { get; set; }
    }

}