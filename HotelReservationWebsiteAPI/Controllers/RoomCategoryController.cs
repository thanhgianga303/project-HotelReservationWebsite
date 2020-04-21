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
    public class RoomCategoryController : ControllerBase
    {
        private readonly IRoomCategoryRepository _repository;
        private readonly IMapper _mapper;
        public RoomCategoryController(IMapper mapper, IRoomCategoryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomCategoryDTO>>> GetAll(string searchString = null)
        {
            var roomcategories = await _repository.GetRoomCategories(searchString);
            var roomcategoriesDTO = _mapper.Map<IEnumerable<RoomCategory>, IEnumerable<RoomCategoryDTO>>(roomcategories);
            return Ok(roomcategoriesDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomCategoryDTO>> GetBy(int id)
        {
            var roomcategory = await _repository.GetBy(id);
            if (roomcategory == null) return NotFound();
            var roomcategoryDTO = _mapper.Map<RoomCategory, RoomCategoryDTO>(roomcategory);
            return Ok(roomcategoryDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoomCategoryDTO roomCategoryDTO)
        {
            var roomcategory = _mapper.Map<RoomCategoryDTO, RoomCategory>(roomCategoryDTO);
            await _repository.Add(roomcategory);
            return CreatedAtAction(nameof(GetBy), new { id = roomcategory.RoomCategoryID }, roomcategory);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoomCategoryDTO roomCategoryDTO)
        {
            if (id != roomCategoryDTO.RoomCategoryID)
            {
                return BadRequest();
            }
            try
            {
                var roomcategory = _mapper.Map<RoomCategoryDTO, RoomCategory>(roomCategoryDTO);
                await _repository.Update(id, roomcategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RoomCategoryExists(id))
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
        private async Task<bool> RoomCategoryExists(int id)
        {
            var roomcategory = await _repository.GetBy(id);
            if (roomcategory != null)
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
            var findRoomcategory = await _repository.GetBy(id);
            if (findRoomcategory == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }
    }
}