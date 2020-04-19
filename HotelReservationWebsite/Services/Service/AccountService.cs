using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services.Service
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public AccountService(IHttpClient httpClient)
        {
            _baseUrl = "http://localhost:5001/api/account";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Account>> GetAccounts(string searchString)
        {
            var url = _baseUrl + $"?searchString={searchString}";
            return await _httpClient.GetListAsync<Account>(url);
        }
        public async Task<Account> GetAccount(int id)
        {
            var url = _baseUrl + $"/{id}";
            return await _httpClient.GetAsync<Account>(url);
        }
        public async Task CreateAccount(Account account)
        {
            var url = _baseUrl;
            await _httpClient.PostAsync(url, account);
        }
        public async Task UpdateAccount(int id, Account account)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.PutAsync(url, account);
        }
        public async Task DeleteAccount(int id)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.DeleteAsync(url);
        }
    }
}