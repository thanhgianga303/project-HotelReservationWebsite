using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservationWebsiteAPI.DTOs;

namespace HotelReservationWebsiteAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly HotelReservationWebsiteContext _context;
        private readonly IMapper _mapper;
        public CustomerController(HotelReservationWebsiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAll(string searchString = null)
        {
            var customers = from m in _context.Customers
                            select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(m => m.CustomerCode.Contains(searchString)
                 || m.CustomerName.Contains(searchString)
                 || m.Email.Contains(searchString)
                 || m.IdentityCard.Contains(searchString)
                 || m.Email.Contains(searchString)
                 || m.Phone.Contains(searchString));
            }
            var customersDTO = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(await customers.ToListAsync());
            return Ok(customersDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetBy(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
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
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
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
                _context.Customers.Update(_mapper.Map<CustomerDTO, Customer>(customerDTO));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(m => m.CustomerID == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findCustomer = await _context.Customers.FindAsync(id);
            if (findCustomer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(findCustomer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}