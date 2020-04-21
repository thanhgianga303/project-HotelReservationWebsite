using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationWebsiteAPI.Data;
using HotelReservationWebsiteAPI.DTOs;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
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
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;
        public AccountController(IMapper mapper, IAccountRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAll(string searchString = null)
        {
            var accounts = await _repository.GetAccounts(searchString);
            var accountsDTO = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountDTO>>(accounts);
            return Ok(accountsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetBy(int id)
        {
            var account = await _repository.GetBy(id);

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
            await _repository.Add(account);
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
                var account = _mapper.Map<AccountDTO, Account>(accountDTO);
                await _repository.Update(id, account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AccountExists(id))
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
        private async Task<bool> AccountExists(int id)
        {
            var account = await _repository.GetBy(id);
            if (account != null)
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
            var findAccount = await _repository.GetBy(id);
            if (findAccount == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }


    }

}