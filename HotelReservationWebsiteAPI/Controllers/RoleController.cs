using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationWebsiteAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        public readonly HotelReservationWebsiteContext _context;
        public RoleController(HotelReservationWebsiteContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetBy(int id)
        {
            var findRole = await _context.Roles.FindAsync(id);
            if (findRole == null)
            {
                return NotFound();
            }
            return findRole;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Role role)
        {
            if (id != role.RoleID)
            {
                return BadRequest();
            }
            try
            {
                _context.Roles.Update(role);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findRole = await _context.Roles.FindAsync(id);
            if (findRole == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(findRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool RoleExists(int id)
        {
            return _context.Roles.Any(m => m.RoleID == id);
        }
    }
}