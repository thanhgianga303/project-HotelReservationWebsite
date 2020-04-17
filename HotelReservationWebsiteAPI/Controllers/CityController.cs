using System.Collections;
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
    public class CityController : ControllerBase
    {
        private readonly HotelReservationWebsiteContext _context;
        private readonly IMapper _mapper;
        public CityController(HotelReservationWebsiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAll(string searchString = null)
        {
            var cities = from m in _context.Cities
                         select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                cities = cities.Where(m => m.CityCode.Contains(searchString) || m.CityName.Contains(searchString));
            }
            // IEnumerable city = _context.Cities.ToList().AsEnumerable();
            // return await _mapper.Map<List<City>, List<CityDTO>>(cities.ToListAsync());
            // cities.ToList();
            return await cities.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDTO>> GetBy(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return NotFound();
            return _mapper.Map<City, CityDTO>(city);
        }
        [HttpPost]
        public async Task<ActionResult<Account>> Create(CityDTO cityDTO)
        {
            var city = _mapper.Map<CityDTO, City>(cityDTO);
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBy), new { id = city.CityID }, city);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CityDTO cityDTO)
        {
            if (id != cityDTO.CityID)
            {
                return BadRequest();
            }

            try
            {
                _context.Cities.Update(_mapper.Map<CityDTO, City>(cityDTO));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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
        private bool CityExists(int id)
        {
            return _context.Cities.Any(m => m.CityID == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findCity = await _context.Cities.FindAsync(id);
            if (findCity == null)
            {
                return NotFound();
            }
            _context.Cities.Remove(findCity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}