using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.InputModel;
using HotelReservationWebsiteAPI.Models.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationWebsiteAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        // private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationUserController(UserManager<ApplicationUser> userManager, IApplicationUserRepository repository)

        {
            _userManager = userManager;
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAll()
        {
            var applicationUsers = await _repository.GetApplicationUsers();
            return Ok(applicationUsers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetBy(string id)
        {
            var applicationUser = await _repository.GetBy(id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return Ok(applicationUser);
        }
        [HttpPost]
        public async Task<IActionResult> Create(InputUserModel _input)
        {
            await _repository.Create(_input);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(InputUserModel _input)
        {
            await _repository.CreateCustomer(_input);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(InputUserModel _input)
        {
            await _repository.CreateEmployee(_input);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, InputChangeInfoModel _input)
        {
            await _repository.Update(id, _input);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}