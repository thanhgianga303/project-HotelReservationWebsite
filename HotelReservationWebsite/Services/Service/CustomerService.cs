using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public CustomerService(IHttpClient httpClient)
        {
            _baseUrl = "http://localhost:5001/api/customer";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Customer>> GetCustomers(string searchString)
        {
            var url = _baseUrl + $"?searchString={searchString}";
            return await _httpClient.GetListAsync<Customer>(url);
        }
        public async Task<Customer> GetCustomer(int id)
        {
            var url = _baseUrl + $"/{id}";
            return await _httpClient.GetAsync<Customer>(url);
        }
        public async Task CreateCustomer(Customer customer)
        {
            var url = _baseUrl;
            await _httpClient.PostAsync(url, customer);
        }
        public async Task UpdateCustomer(int id, Customer customer)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.PutAsync(url, customer);
        }
        public async Task DeleteCustomer(int id)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.DeleteAsync(url);
        }
    }
}