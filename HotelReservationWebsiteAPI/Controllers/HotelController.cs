using System;
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
    [Route("api/[controller]/[action]")]
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
            var hotels = await _repository.GetHotels(searchString);
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
        [HttpGet("roomid={roomID}&hotelid={hotelID}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int roomID, int hotelID)
        {
            var room = await _repository.GetRoom(roomID, hotelID);
            if (room == null)
            {
                Console.WriteLine("test 11");
                return NotFound();
            }
            var roomDTO = _mapper.Map<Room, RoomDTO>(room);
            return Ok(roomDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(HotelDTO hotelDTO)
        {
            var hotel = _mapper.Map<HotelDTO, Hotel>(hotelDTO);
            await _repository.Add(hotel);
            return CreatedAtAction(nameof(GetBy), new { id = hotel.HotelID }, hotel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomDTO roomDTO)
        {
            var room = _mapper.Map<RoomDTO, Room>(roomDTO);
            await _repository.AddRoom(room);
            return CreatedAtAction(nameof(GetRoom), new { roomID = room.RoomID, hotelID = room.HotelID }, room);
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
        [HttpPut("roomid={roomID}&hotelid={hotelID}")]
        public async Task<IActionResult> UpdateRoom(int roomId, int hotelId, RoomDTO roomDTO)
        {
            if (roomId != roomDTO.RoomID && hotelId != roomDTO.HotelID)
            {
                return NotFound();
            }
            try
            {
                var room = _mapper.Map<RoomDTO, Room>(roomDTO);
                await _repository.UpdateRoom(room);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RoomExists(roomId, hotelId))
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
        private async Task<bool> RoomExists(int roomId, int hotelId)
        {
            var hotel = await _repository.GetRoom(roomId, hotelId);
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
        [HttpDelete("roomid={roomID}&hotelid={hotelID}")]
        public async Task<IActionResult> DeleteRoom(int roomId, int hotelId)
        {
            var findRoom = await _repository.GetRoom(roomId, hotelId);
            if (findRoom == null)
            {
                Console.WriteLine("test");
                return NotFound();
            }
            await _repository.DeleteRoom(findRoom);
            return NoContent();
        }
    }
}