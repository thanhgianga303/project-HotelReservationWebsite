using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.ViewModels
{
    public class AddressViewModel
    {
        public string SearchString { get; set; }
        public string Genre { get; set; }
        public int pageIndex { get; set; }
        public Address Address { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}