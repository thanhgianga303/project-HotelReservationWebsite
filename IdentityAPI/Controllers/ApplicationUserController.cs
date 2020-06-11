using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdentityAPI.DTOs;
using IdentityAPI.Models;
using IdentityAPI.Models.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        // private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationUserController(UserManager<ApplicationUser> userManager, IApplicationUserRepository repository, IMapper mapper)

        {
            _userManager = userManager;
            _repository = repository;
            _mapper = mapper;
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
        public async Task<IActionResult> Create(ApplicationUserDTO applicationDto)
        {
            var user = _mapper.Map<ApplicationUserDTO, ApplicationUser>(applicationDto);
            await _repository.Create(user);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ApplicationUserDTO applicationDto)
        {
            var user = _mapper.Map<ApplicationUserDTO, ApplicationUser>(applicationDto);
            await _repository.Update(id, user);
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