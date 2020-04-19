using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers(string searchString);
        Task<Customer> GetCustomer(int id);
        Task CreateCustomer(Customer Customer);
        Task UpdateCustomer(int id, Customer Customer);
        Task DeleteCustomer(int id);
    }
}