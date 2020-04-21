using System.Collections;
using System.Collections.Generic;
// using System.Collections.Generic;
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
    public class CityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _repository;
        public CityController(IMapper mapper, ICityRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetAll(string searchString = null)
        {
            var cities = await _repository.GetCities(searchString);
            var citiesDTO = _mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(cities);
            return Ok(citiesDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDTO>> GetBy(int id)
        {
            var city = await _repository.GetBy(id);
            if (city == null) return NotFound();
            var cityDTO = _mapper.Map<City, CityDTO>(city);
            return Ok(cityDTO);
        }
        [HttpPost]
        public async Task<ActionResult<City>> Create(CityDTO cityDTO)
        {
            var city = _mapper.Map<CityDTO, City>(cityDTO);
            await _repository.Add(city);
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
                var city = _mapper.Map<CityDTO, City>(cityDTO);
                await _repository.Update(id, city);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CityExists(id))
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
        private async Task<bool> CityExists(int id)
        {
            var city = await _repository.GetBy(id);
            if (city != null)
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
            var findCity = await _repository.GetBy(id);
            if (findCity == null)
            {
                return NotFound();
            }
            await _repository.Delete(findCity.CityID);
            return NoContent();
        }
    }
}