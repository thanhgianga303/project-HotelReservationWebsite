using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.ViewModels
{
    public class EmployeeViewModel
    {
        public string SearchString { get; set; }
        public string Genre { get; set; }
        public int pageIndex { get; set; }
        public Employee Employee { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}