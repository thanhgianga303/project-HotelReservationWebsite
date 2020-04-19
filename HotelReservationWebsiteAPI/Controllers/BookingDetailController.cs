using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.DTOs;
using HotelReservationWebsiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationWebsiteAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingDetailController : ControllerBase
    {
        private readonly HotelReservationWebsiteContext _context;
        private readonly IMapper _mapper;
        public BookingDetailController(HotelReservationWebsiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetailDTO>>> GetAll(string searchString = null)
        {
            var bookingdetails = from m in _context.BookingDetails
                                 select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                bookingdetails = bookingdetails.Where(m => m.BookingDetailStatus.ToString().Contains(searchString));
            }
            var bookingdetailsDTO = _mapper.Map<IEnumerable<BookingDetail>, IEnumerable<BookingDetailDTO>>(await bookingdetails.ToListAsync());
            return Ok(bookingdetailsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetailDTO>> GetBy(int id)
        {
            var bookingdetail = await _context.BookingDetails.FindAsync(id);
            if (bookingdetail == null)
            {
                return NotFound();
            }
            var bookingdetailDTO = _mapper.Map<BookingDetail, BookingDetailDTO>(bookingdetail);
            return Ok(bookingdetailDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingDetailDTO bookingdetailDTO)
        {
            var bookingdetail = _mapper.Map<BookingDetailDTO, BookingDetail>(bookingdetailDTO);
            _context.BookingDetails.Add(bookingdetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBy), new { id = bookingdetail.BookingDetailID }, bookingdetail);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookingDetailDTO bookingdetailDTO)
        {
            if (id != bookingdetailDTO.BookingDetailID)
            {
                return BadRequest();
            }
            try
            {
                _context.BookingDetails.Update(_mapper.Map<BookingDetailDTO, BookingDetail>(bookingdetailDTO));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool BookingDetailExists(int id)
        {
            return _context.BookingDetails.Any(m => m.BookingDetailID == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findRoom = await _context.Rooms.FindAsync(id);
            if (findRoom == null)
            {
                return NotFound();
            }
            _context.Rooms.Remove(findRoom);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}