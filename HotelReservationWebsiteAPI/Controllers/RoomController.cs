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
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;
        public RoomController(IMapper mapper, IRoomRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetAll(string searchString = null)
        {
            var rooms = await _repository.GetRooms(searchString);
            var roomsDTO = _mapper.Map<IEnumerable<Room>, IEnumerable<RoomDTO>>(rooms);
            return Ok(roomsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetBy(int id)
        {
            var room = await _repository.GetBy(id);
            if (room == null)
            {
                return NotFound();
            }
            var roomDTO = _mapper.Map<Room, RoomDTO>(room);
            return Ok(roomDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoomDTO roomDTO)
        {
            var room = _mapper.Map<RoomDTO, Room>(roomDTO);
            await _repository.Add(room);
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
                var room = _mapper.Map<RoomDTO, Room>(roomDTO);
                await _repository.Update(id, room);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RoomExists(id))
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

        private async Task<bool> RoomExists(int id)
        {
            var room = await _repository.GetBy(id);
            if (room != null)
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
            var findRoom = await _repository.GetBy(id);
            if (findRoom == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }

    }
}