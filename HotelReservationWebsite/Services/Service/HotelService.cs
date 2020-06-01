using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;

namespace HotelReservationWebsite.Services.Service
{
    public class HotelService : IHotelService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public HotelService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseUrl = "http://localhost:5001/api/hotel";
        }
        public async Task<IEnumerable<Hotel>> GetHotels(string searchString)
        {
            // var url = _baseUrl + $"?searchString={searchString}";
            var url = _baseUrl + $"/getall?searchString={searchString}";
            return await _httpClient.GetListAsync<Hotel>(url);
        }
        public async Task<Hotel> GetHotel(int id)
        {
            var url = _baseUrl + $"/getby/{id}";
            return await _httpClient.GetAsync<Hotel>(url);
        }
        public async Task CreateHotel(Hotel hotel)
        {
            var url = _baseUrl + "/create";
            await _httpClient.PostAsync(url, hotel);
        }
        public async Task UpdateHotel(int id, Hotel hotel)
        {
            var url = _baseUrl + $"/update/{id}";
            await _httpClient.PutAsync(url, hotel);
        }
        public async Task DeleteHotel(int id)
        {
            var url = _baseUrl + $"/delete/{id}";
            await _httpClient.DeleteAsync(url);
        }
        public async Task<Room> GetRoom(int roomId, int hotelId)
        {
            var url = _baseUrl + $"/getroom/roomid={roomId}&hotelid={hotelId}";
            return await _httpClient.GetAsync<Room>(url);
        }
        public async Task CreateRoom(Room room)
        {
            var url = _baseUrl + $"/createroom";
            await _httpClient.PostAsync(url, room);
        }
        public async Task UpdateRoom(int roomId, int hotelId, Room room)
        {
            var url = _baseUrl + $"/updateroom/roomid={roomId}&hotelid={hotelId}";
            await _httpClient.PutAsync(url, room);
        }
        public async Task DeleteRoom(int roomId, int hotelId)
        {
            var url = _baseUrl + $"/deleteroom/roomid={roomId}&hotelid={hotelId}";
            await _httpClient.DeleteAsync(url);
        }
    }
}