using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationWebsite.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public int CityID { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 60")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please enter the format: the first letter must be uppercase, the letter has no number")]
        public string HotelName { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 60")]
        [RegularExpression(@"^[0-9]+[a-zA-Z""'\s-]*$")]
        public string Address { get; set; }
        public int NumberofReservation { get; set; }
        public HotelStatus HotelStatus { get; set; }
        public string OwnerID { get; set; }
        public List<Room> Rooms { get; set; }
        public City City { get; set; }
    }
    public enum HotelStatus
    {
        Submitted = 0,
        Approved = 1,
        Rejected = 2
    }

}