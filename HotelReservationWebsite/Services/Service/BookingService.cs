using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsite.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using Microsoft.Extensions.Options;


namespace HotelReservationWebsite.Services.Service
{
    public class BookingService : IBookingService
    {
        private readonly string _serviceBaseUrl;
        private readonly IHttpClient _httpClient;

        public BookingService(IHttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _serviceBaseUrl = $"{appSettings.Value.BookingUrl}/api/booking";
        }

        public async Task<int> CreateBooking(Booking booking)
        {
            var uri = _serviceBaseUrl;

            var bookingOut = await _httpClient.PostAsync<Booking>(uri, booking);

            return bookingOut.BookingId;
        }

        public async Task<Booking> GetBooking(int id)
        {
            var uri = _serviceBaseUrl + $"/{id}";

            return await _httpClient.GetAsync<Booking>(uri);
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            var uri = _serviceBaseUrl;

            return await _httpClient.GetListAsync<Booking>(uri);
        }

        public async Task<IEnumerable<Booking>> GetBookings(string userId)
        {
            var uri = _serviceBaseUrl + $"/buyerid/{userId}"; ;

            return await _httpClient.GetListAsync<Booking>(uri);
        }
        public async Task UpdateBooking(int id, Booking booking)
        {
            var uri = _serviceBaseUrl + $"/{id}";
            await _httpClient.PutAsync(uri, booking);
        }
    }
}