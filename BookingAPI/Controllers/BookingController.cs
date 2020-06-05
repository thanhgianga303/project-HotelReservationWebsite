using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using BookingAPI.DTOs;
using BookingAPI.Models;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppSettings _settings;
        private readonly IBookingRepository _bookingRepo;
        private readonly IMapper _mapper;

        public BookingController(IBookingRepository bookingRepo, IOptions<AppSettings> settings, IMapper mapper)
        {
            _settings = settings.Value;
            _bookingRepo = bookingRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookingDTO>> GetBookings()
        {
            var bookings = await _bookingRepo.GetAllAsync();

            return _mapper.Map<IEnumerable<Booking>, IEnumerable<BookingDTO>>(bookings);
        }

        [HttpGet("buyerId/{buyerId}")]
        public async Task<IEnumerable<BookingDTO>> GetBookings(string buyerId)
        {
            var bookings = await _bookingRepo.GetByBuyerAsync(buyerId);

            return _mapper.Map<IEnumerable<Booking>, IEnumerable<BookingDTO>>(bookings);
        }

        [HttpGet("{id}")]
        public async Task<BookingDTO> GetBooking(int id)
        {
            var booking = await _bookingRepo.GetByAsync(id);

            return _mapper.Map<Booking, BookingDTO>(booking);
        }

        [HttpPost]
        public async Task<ActionResult<BookingDTO>> CreateBooking(BookingDTO bookingDTO)
        {
            var booking = _mapper.Map<BookingDTO, Booking>(bookingDTO);
            booking.Status = BookingStatus.Booked;
            booking.BookingDate = DateTime.UtcNow;

            await _bookingRepo.AddAsync(booking);
            bookingDTO = _mapper.Map<Booking, BookingDTO>(booking);

            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, bookingDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _bookingRepo.GetByAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            await _bookingRepo.DeleteAsync(booking);

            return NoContent();
        }
    }
}