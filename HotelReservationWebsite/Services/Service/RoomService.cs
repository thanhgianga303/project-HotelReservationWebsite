using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services.Service
{
    public class RoomService : IRoomService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public RoomService(IHttpClient httpClient)
        {
            _baseUrl = "http://localhost:5001/api/room";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Room>> GetRooms(string searchString)
        {
            var url = _baseUrl + $"?searchString={searchString}";
            return await _httpClient.GetListAsync<Room>(url);
        }
        public async Task<Room> GetRoom(int id)
        {
            var url = _baseUrl + $"/{id}";
            return await _httpClient.GetAsync<Room>(url);
        }
        public async Task CreateRoom(Room room)
        {
            var url = _baseUrl;
            await _httpClient.PostAsync(url, room);
        }
        public async Task UpdateRoom(int id, Room room)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.PutAsync(url, room);
        }
        public async Task DeleteRoom(int id)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.DeleteAsync(url);
        }
    }
}