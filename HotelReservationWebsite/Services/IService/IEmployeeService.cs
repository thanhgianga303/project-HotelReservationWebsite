using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.IService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees(string searchString);
        Task<Employee> GetEmployee(int id);
        Task CreateEmployee(Employee Employee);
        Task UpdateEmployee(int id, Employee Employee);
        Task DeleteEmployee(int id);
    }
}