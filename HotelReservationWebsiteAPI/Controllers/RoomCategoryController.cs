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
    public class RoomCategoryController : ControllerBase
    {
        private readonly HotelReservationWebsiteContext _context;
        private readonly IMapper _mapper;
        public RoomCategoryController(HotelReservationWebsiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomCategoryDTO>>> GetAll(string searchString = null)
        {
            var roomcategories = from m in _context.RoomCategories
                                 select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                roomcategories = roomcategories.Where(m => m.CategoryName.Contains(searchString)
                 || m.CategoryCode.Contains(searchString));
            }
            var roomcategoriesDTO = _mapper.Map<IEnumerable<RoomCategory>, IEnumerable<RoomCategoryDTO>>(await roomcategories.ToListAsync());
            return Ok(roomcategoriesDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomCategoryDTO>> GetBy(int id)
        {
            var roomcategory = await _context.RoomCategories.FindAsync(id);
            if (roomcategory == null) return NotFound();
            var roomcategoryDTO = _mapper.Map<RoomCategory, RoomCategoryDTO>(roomcategory);
            return Ok(roomcategoryDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoomCategoryDTO roomCategoryDTO)
        {
            var roomcategory = _mapper.Map<RoomCategoryDTO, RoomCategory>(roomCategoryDTO);
            _context.RoomCategories.Add(roomcategory);
            await _context.SaveChangesAsync();
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
                _context.RoomCategories.Update(_mapper.Map<RoomCategoryDTO, RoomCategory>(roomCategoryDTO));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomCategoryExists(id))
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
        private bool RoomCategoryExists(int id)
        {
            return _context.RoomCategories.Any(m => m.RoomCategoryID == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findRoomcategory = await _context.RoomCategories.FindAsync(id);
            if (findRoomcategory == null)
            {
                return NotFound();
            }
            _context.RoomCategories.Remove(findRoomcategory);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}