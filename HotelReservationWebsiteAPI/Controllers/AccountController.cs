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
    public class AccountController : ControllerBase
    {
        private readonly HotelReservationWebsiteContext _context;
        public AccountController(HotelReservationWebsiteContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAll()
        {
            return await _context.Account.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetBy(int id)
        {
            var movie = await _context.Account.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
        [HttpPost]
        public async Task<ActionResult<Account>> Create(Account account)
        {
            _context.Account.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Account account)
        {
            if (id != account.AccountID)
            {
                return BadRequest();
            }

            try
            {
                _context.Account.Update(account);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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
        private bool AccountExists(int id)
        {
            return _context.Account.Any(m => m.AccountID == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var account = await _context.Account.FindAsync(id);
            if (account != null)
            {
                _context.Account.Remove(account);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }
    }

}