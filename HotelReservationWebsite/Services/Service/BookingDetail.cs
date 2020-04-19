using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Newtonsoft.Json;


namespace HotelReservationWebsite.Services.Service
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public BookingDetailService(IHttpClient httpClient)
        {
            _baseUrl = "http://localhost:5001/api/bookingdetail";
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<BookingDetail>> GetBookingDetails(string searchString)
        {
            var url = _baseUrl + $"?searchString={searchString}";
            return await _httpClient.GetListAsync<BookingDetail>(url);
        }
        public async Task<BookingDetail> GetBookingDetail(int id)
        {
            var url = _baseUrl + $"/{id}";
            return await _httpClient.GetAsync<BookingDetail>(url);
        }
        public async Task CreateBookingDetail(BookingDetail bookingDetail)
        {
            var url = _baseUrl;
            await _httpClient.PostAsync(url, bookingDetail);
        }
        public async Task UpdateBookingDetail(int id, BookingDetail bookingDetail)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.PutAsync(url, bookingDetail);
        }
        public async Task DeleteBookingDetail(int id)
        {
            var url = _baseUrl + $"/{id}";
            await _httpClient.DeleteAsync(url);
        }
    }
}