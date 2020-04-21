using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservationWebsiteAPI.DTOs;
using HotelReservationWebsiteAPI.Models.IRepositories;

namespace HotelReservationWebsiteAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerController(IMapper mapper, ICustomerRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAll(string searchString = null)
        {
            var customers = await _repository.GetCustomers(searchString);
            var customersDTO = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);
            return Ok(customersDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetBy(int id)
        {
            var customer = await _repository.GetBy(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDTO = _mapper.Map<Customer, CustomerDTO>(customer);
            return Ok(customerDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
            await _repository.Add(customer);
            return CreatedAtAction(nameof(GetBy), new { id = customer.CustomerID }, customer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerDTO customerDTO)
        {
            if (id != customerDTO.CustomerID)
            {
                return BadRequest();
            }
            try
            {
                var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
                await _repository.Update(id, customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CustomerExists(id))
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
        private async Task<bool> CustomerExists(int id)
        {
            var customer = await _repository.GetBy(id);
            if (customer != null)
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
            var findCustomer = await _repository.GetBy(id);
            if (findCustomer == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }
    }
}