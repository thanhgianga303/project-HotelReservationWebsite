using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Models;
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
        // private readonly IApplicationUserRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        // private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationUserController(UserManager<ApplicationUser> userManager)
        // IApplicationUserRepository repository
        {
            _userManager = userManager;
            // _repository = repository;
        }
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAll()
        {
            var applicationUser = await _userManager.Users.ToListAsync();
            return Ok(applicationUser);
        }
        [HttpPost]
        public IActionResult Create(ApplicationUser _user)
        {
            // var findUser = await _userManager.FindByNameAsync(user.);
            // if(findUser)
            var user = new ApplicationUser
            {
                UserName = "giangcoi",
                CustomerID = _user.CustomerID
            };
            var result = _userManager.CreateAsync(user, "Pass123$").Result;
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
            return NoContent();
        }
    }
}