using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationWebsiteAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
            return await _context.Accounts.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetBy(int id)
        {
            var findAccount = await _context.Accounts.FindAsync(id);

            if (findAccount == null)
            {
                return NotFound();
            }

            return Ok(findAccount);
        }
        [HttpPost]
        public async Task<ActionResult<Account>> Create(Account account)
        {
            _context.Accounts.Add(account);
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
                _context.Accounts.Update(account);
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
            return _context.Accounts.Any(m => m.AccountID == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var findAccount = await _context.Accounts.FindAsync(id);
            if (findAccount == null)
            {
                return NotFound();
            }
            _context.Accounts.Remove(findAccount);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }

}