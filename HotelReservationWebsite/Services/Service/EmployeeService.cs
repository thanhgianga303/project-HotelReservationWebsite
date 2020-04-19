using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public EmployeeService(IHttpClient httpClient)
        {
            _baseUrl = "http://localhost:5001/api/employee";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetEmployees(string searchString)
        {
            var url = _baseUrl + $"?searchString={searchString}";
            return await _httpClient.GetListAsync<Employee>(url);
        }
        public async Task<Employee> GetEmployee(int id)
        {
            var url = _baseUrl + $"/{id}";
            return await _httpClient.GetAsync<Employee>(url);
        }
        public async Task CreateEmployee(Employee employee)
        {
            var url = _baseUrl;
            await _httpClient.PostAsync(url, employee);
        }
        public async Task UpdateEmployee(int id, Employee employee)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.PutAsync(url, employee);
        }
        public async Task DeleteEmployee(int id)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.DeleteAsync(url);
        }
    }
}