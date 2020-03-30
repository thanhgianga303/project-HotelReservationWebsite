namespace HotelReservationWebsite.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public int CityID { get; set; }
        public int HotelID { get; set; }
        public string HotelAddress { get; set; }
        public Hotel Hotel { get; set; }
        public City City { get; set; }
    }

}