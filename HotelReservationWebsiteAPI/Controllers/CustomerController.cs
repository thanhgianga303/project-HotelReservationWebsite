using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationWebsiteAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public readonly HotelReservationWebsiteContext _context;
        public CustomerController(HotelReservationWebsiteContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetBy(int id)
        {
            var findCustomer = await _context.Customers.FindAsync(id);
            if (findCustomer == null)
            {
                return NotFound();
            }
            return findCustomer;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return BadRequest();
            }
            try
            {
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
            return NoContent();
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