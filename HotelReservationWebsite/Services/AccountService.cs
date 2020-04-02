using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public AccountService(HttpClient httpClient)
        {
            _baseUrl = "http://localhost:5000/api/account";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Account>> GetAll()
        {
            var url = _baseUrl;
            var responseString = await _httpClient.GetStringAsync(url);
            var response = JsonConvert.DeserializeObject<IEnumerable<Account>>(responseString);
            return response;
        }
    }
}