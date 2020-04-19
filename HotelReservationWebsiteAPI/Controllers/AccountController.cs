using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.DTOs;
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
        private readonly IMapper _mapper;
        public AccountController(HotelReservationWebsiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAll(string searchString = null)
        {
            var accounts = from m in _context.Accounts
                           select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                accounts = accounts.Where(m => m.Username.Contains(searchString)
                || m.AccountStatus.ToString().Contains(searchString));
            }
            var accountsDTO = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountDTO>>(await accounts.ToListAsync());
            return Ok(accountsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetBy(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }
            var accountDTO = _mapper.Map<Account, AccountDTO>(account);
            return Ok(accountDTO);
        }
        [HttpPost]
        public async Task<ActionResult<Account>> Create(AccountDTO accountDTO)
        {
            var account = _mapper.Map<AccountDTO, Account>(accountDTO);
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBy), new { id = account.AccountID }, account);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AccountDTO accountDTO)
        {
            if (id != accountDTO.AccountID)
            {
                return BadRequest();
            }

            try
            {
                _context.Accounts.Update(_mapper.Map<AccountDTO, Account>(accountDTO));
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