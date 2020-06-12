using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public UserService(IHttpClient httpClient)
        {
            _baseUrl = "http://localhost:5000/api/applicationuser";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var url = _baseUrl;
            return await _httpClient.GetListAsync<User>(url);
        }
        public async Task<User> GetUser(string id)
        {
            var url = _baseUrl + $"/{id}";
            return await _httpClient.GetAsync<User>(url);
        }
        public async Task CreateUser(User user)
        {
            var url = _baseUrl;
            await _httpClient.PostAsync(url, user);
        }
        public async Task UpdateUser(string id, User user)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.PutAsync(url, user);
        }
        public async Task DeleteUser(string id)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.DeleteAsync(url);
        }
    }
}