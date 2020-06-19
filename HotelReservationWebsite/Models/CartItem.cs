using System;

namespace HotelReservationWebsite.Models
{
    public class CartItem
    {
        public string Id { get; set; }
        public string HotelId { get; set; }
        public string RoomId { get; set; }
        public string HotelName { get; set; }
        public string RoomName { get; set; }
        public string RoomNumber { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string RoomArea { get; set; }
        public string NumberOfBeds { get; set; }
        public string OwnerId { get; set; }
        public string City { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public TimeSpan dayNumber()
        {
            return CheckOut.Subtract(CheckIn);
        }
        public decimal cost()
        {
            return Int32.Parse(dayNumber().Days.ToString()) * UnitPrice * Int32.Parse(RoomNumber);
        }
    }
}