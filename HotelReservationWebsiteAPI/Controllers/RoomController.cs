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
    public class RoomController : ControllerBase
    {
        private readonly HotelReservationWebsiteContext _context;
        private readonly IMapper _mapper;
        public RoomController(HotelReservationWebsiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAll()
        {
            return await _context.Rooms.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetBy(int id)
        {
            var findRoom = await _context.Rooms.FindAsync(id);
            if (findRoom == null)
            {
                return NotFound();
            }
            return _mapper.Map<Room, RoomDTO>(findRoom);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoomDTO roomDTO)
        {
            var room = _mapper.Map<RoomDTO, Room>(roomDTO);
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBy), new { id = room.RoomID }, room);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoomDTO roomDTO)
        {
            if (id != roomDTO.RoomID)
            {
                return BadRequest();
            }
            try
            {
                _context.Rooms.Update(_mapper.Map<RoomDTO, Room>(roomDTO));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(m => m.RoomID == id);
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