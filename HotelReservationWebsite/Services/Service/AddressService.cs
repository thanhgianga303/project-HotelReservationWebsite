using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services.Service
{
    public class AddressService : IAddressService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public AddressService(IHttpClient httpClient)
        {
            _baseUrl = "http://localhost:5001/api/address";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Address>> GetAddresses(string searchString)
        {
            var url = _baseUrl + $"?searchString={searchString}";
            return await _httpClient.GetListAsync<Address>(url);
        }
        public async Task<Address> GetAddress(int id)
        {
            var url = _baseUrl + $"/{id}";
            return await _httpClient.GetAsync<Address>(url);
        }
        public async Task CreateAddress(Address address)
        {
            var url = _baseUrl;
            await _httpClient.PostAsync(url, address);
        }
        public async Task UpdateAddress(int id, Address address)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.PutAsync(url, address);
        }
        public async Task DeleteAddress(int id)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.DeleteAsync(url);
        }
    }
}