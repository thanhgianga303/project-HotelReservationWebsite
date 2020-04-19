using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.ViewModels
{
    public class CustomerViewModel
    {
        public string SearchString { get; set; }
        public string Genre { get; set; }
        public int pageIndex { get; set; }
        public Customer Customer { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}