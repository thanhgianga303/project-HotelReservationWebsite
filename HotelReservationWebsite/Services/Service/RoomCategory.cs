using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services.Service
{
    public class RoomCategoryService : IRoomCategoryService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public RoomCategoryService(IHttpClient httpClient)
        {
            _baseUrl = "http://localhost:5001/api/roomcategory";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<RoomCategory>> GetRoomCategories()
        {
            var url = _baseUrl;
            return await _httpClient.GetListAsync<RoomCategory>(url);
        }
        public async Task<RoomCategory> GetRoomCategory(int id)
        {
            var url = _baseUrl + $"/{id}";
            return await _httpClient.GetAsync<RoomCategory>(url);
        }
        public async Task CreateRoomCategory(RoomCategory roomCategory)
        {
            var url = _baseUrl;
            await _httpClient.PostAsync(url, roomCategory);
        }
        public async Task UpdateRoomCategory(int id, RoomCategory roomCategory)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.PutAsync(url, roomCategory);
        }
        public async Task DeleteRoomCategory(int id)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.DeleteAsync(url);
        }
    }
}