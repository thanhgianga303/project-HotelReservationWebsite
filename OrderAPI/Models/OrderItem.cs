using OrderAPI.Infrastructure.Exceptions;

namespace OrderAPI.Models
{
    public class OrderItem
    {
        public OrderItem()
        {
        }
        public OrderItem(int hotelId, string hotelName,
        int roomId, string roomName,
        int addressId, string addressName,
        decimal unitPrice, string pictureUri)
        {
            HotelId = hotelId;
            HotelName = hotelName;
            RoomId = roomId;
            RoomName = roomName;
            AddressId = addressId;
            AddressName = addressName;
            UnitPrice = unitPrice;
            PictureUri = pictureUri;
        }

        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string PictureUri { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int AddressId { get; set; }
        public string AddressName { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public void SetPictureUri(string pictureUri)
        {
            PictureUri = pictureUri;
        }
    }
}