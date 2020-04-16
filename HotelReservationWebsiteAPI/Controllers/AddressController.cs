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
    public class AddressController : ControllerBase
    {
        private readonly HotelReservationWebsiteContext _context;
        private readonly IMapper _mapper;
        public AddressController(HotelReservationWebsiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAll()
        {
            return await _context.Addresses.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetBy(int id)
        {
            var findAddress = await _context.Addresses.FindAsync(id);
            if (findAddress == null)
            {
                return NotFound();
            }
            return _mapper.Map<Address, AddressDTO>(findAddress);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddressDTO addressDTO)
        {
            var address = _mapper.Map<AddressDTO, Address>(addressDTO);
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBy), new { id = address.AddressID }, address);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddressDTO addressDTO)
        {
            if (id != addressDTO.AddressID)
            {
                return BadRequest();
            }
            try
            {
                _context.Addresses.Update(_mapper.Map<AddressDTO, Address>(addressDTO));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(m => m.AddressID == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findAddress = await _context.Addresses.FindAsync(id);
            if (findAddress == null)
            {
                return NotFound();
            }
            _context.Addresses.Remove(findAddress);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}