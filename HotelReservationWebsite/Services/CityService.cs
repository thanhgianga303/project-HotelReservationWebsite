using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services
{
    public class CityService : ICityService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public CityService(IHttpClient httpClient)
        {
            _baseUrl = "http://localhost:5001/api/city";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<City>> GetCitys()
        {
            var url = _baseUrl;
            return await _httpClient.GetListAsync<City>(url);
        }
        public async Task<City> GetCity(int id)
        {
            var url = _baseUrl + $"/{id}";
            return await _httpClient.GetAsync<City>(url);
        }
        public async Task CreateCity(City city)
        {
            var url = _baseUrl;
            await _httpClient.PostAsync(url, city);
        }
        public async Task UpdateCity(int id, City city)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.PutAsync(url, city);
        }
        public async Task DeleteCity(int id)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.DeleteAsync(url);
        }
    }
}