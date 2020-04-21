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
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;
        public AddressController(IMapper mapper, IAddressRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAll(string searchString)
        {
            var addresses = await _repository.GetAddresses(searchString);
            var addressesDTO = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressDTO>>(addresses);
            return Ok(addressesDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetBy(int id)
        {
            var findAddress = await _repository.GetBy(id);
            if (findAddress == null)
            {
                return NotFound();
            }
            var addressDTO = _mapper.Map<Address, AddressDTO>(findAddress);
            return Ok(addressDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddressDTO addressDTO)
        {
            var address = _mapper.Map<AddressDTO, Address>(addressDTO);
            await _repository.Add(address);
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
                var address = _mapper.Map<AddressDTO, Address>(addressDTO);
                await _repository.Update(id, address);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AddressExists(id))
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

        private async Task<bool> AddressExists(int id)
        {
            var address = await _repository.GetBy(id);
            if (address != null)
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
            var findAddress = await _repository.GetBy(id);
            if (findAddress == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }

    }
}