using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services.Service
{
    public class PromotionService : IPromotionService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public PromotionService(IHttpClient httpClient)
        {
            _baseUrl = "http://localhost:5001/api/promotion";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Promotion>> GetPromotions(string searchString)
        {
            var url = _baseUrl + $"?searchString={searchString}";
            return await _httpClient.GetListAsync<Promotion>(url);
        }
        public async Task<Promotion> GetPromotion(int id)
        {
            var url = _baseUrl + $"/{id}";
            return await _httpClient.GetAsync<Promotion>(url);
        }
        public async Task CreatePromotion(Promotion promotion)
        {
            var url = _baseUrl;
            await _httpClient.PostAsync(url, promotion);
        }
        public async Task UpdatePromotion(int id, Promotion promotion)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.PutAsync(url, promotion);
        }
        public async Task DeletePromotion(int id)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.DeleteAsync(url);
        }
    }
}