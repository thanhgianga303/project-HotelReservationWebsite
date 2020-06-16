
using System;

namespace BookingAPI.Models
{
    public class BookingItem
    {
        public BookingItem()
        {
        }
        public BookingItem(string hotelID, string hotelName,
                        string roomId, string roomName,
                        string address, string city,
                        string categoryName, DateTime checkIn,
                        string roomArea, string numberOfBeds,
                        string ownerId,
                        DateTime checkOut, string roomNumber,
                        int dayNumber, int cost,
                        decimal unitPrice, string imageUri)
        {
            HotelId = hotelID;
            HotelName = hotelName;
            RoomId = roomId;
            RoomName = roomName;
            RoomNumber = roomNumber;
            Address = address;
            City = city;
            RoomArea = roomArea;
            NumberOfBeds = numberOfBeds;
            OwnerId = ownerId;
            CategoryName = categoryName;
            CheckIn = checkIn;
            CheckOut = checkOut;
            DayNumber = dayNumber;
            Cost = cost;
            UnitPrice = unitPrice;
            ImageUri = imageUri;
        }

        public int Id { get; set; }
        public int BookingId { get; set; }
        public string HotelId { get; set; }
        public string RoomId { get; set; }
        public string HotelName { get; set; }
        public string RoomName { get; set; }
        public string RoomNumber { get; set; }
        public string ImageUri { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string RoomArea { get; set; }
        public string NumberOfBeds { get; set; }
        public string OwnerId { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int DayNumber { get; set; }
        public decimal Cost { get; set; }
        public virtual Booking Booking { get; set; }
    }
}