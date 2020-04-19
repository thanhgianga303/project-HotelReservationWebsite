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
    public class HotelController : ControllerBase
    {
        private readonly HotelReservationWebsiteContext _context;
        private readonly IMapper _mapper;
        public HotelController(HotelReservationWebsiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetAll(string searchString)
        {
            var hotels = from m in _context.Hotels
                         select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(m => m.HotelName.Contains(searchString) || m.HotelCode.Contains(searchString) || m.HotelStatus.ToString().Contains(searchString));
            }
            var hotelsDTO = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(await hotels.ToListAsync());
            return Ok(hotelsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetBy(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            var hotelDTO = _mapper.Map<Hotel, HotelDTO>(hotel);
            return Ok(hotelDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(HotelDTO hotelDTO)
        {
            var hotel = _mapper.Map<HotelDTO, Hotel>(hotelDTO);
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HotelDTO hotelDTO)
        {
            if (id != hotelDTO.HotelID)
            {
                return NotFound();
            }
            try
            {
                _context.Hotels.Update(_mapper.Map<HotelDTO, Hotel>(hotelDTO));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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
        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(m => m.HotelID == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findHotel = await _context.Hotels.FindAsync(id);
            if (findHotel == null)
            {
                return NotFound();
            }
            _context.Hotels.Remove(findHotel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}