namespace HotelReservationWebsiteAPI.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public int CityID { get; set; }
        public int HotelID { get; set; }
        public string HotelAddress { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual City City { get; set; }
    }

}