using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.DTOs;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationWebsiteAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _repository;
        public HotelController(IMapper mapper, IHotelRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetAll(string searchString)
        {
            var hotels = await _repository.GetAll();
            var hotelsDTO = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
            return Ok(hotelsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetBy(int id)
        {
            var hotel = await _repository.GetBy(id);
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
            await _repository.Add(hotel);
            return CreatedAtAction(nameof(GetBy), new { id = hotel.HotelID }, hotel);
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
                var hotel = _mapper.Map<HotelDTO, Hotel>(hotelDTO);
                await _repository.Update(id, hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
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
        private async Task<bool> HotelExists(int id)
        {
            var hotel = await _repository.GetBy(id);
            if (hotel != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findHotel = await _repository.GetBy(id);
            if (findHotel == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }
    }
}