using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationWebsite.ViewModels
{
    public class HotelViewModel
    {
        public string SearchString { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int hotelID { get; set; }
        public string ImageUrlDisplay { get; set; }
        [Required]
        public IFormFile ImageUrl { get; set; }
        public IFormFile ChangeImageUrl { get; set; }
        public Hotel Hotel { get; set; }
        public IList<Hotel> Hotels { get; set; }
        public enum HotelStatus
        {
            Submitted = 0,
            Approved = 1,
            Rejected = 2
        }
    }


}