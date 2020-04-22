using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IEnumerable<ApplicationUser>> GetApplicationUsers()
        {
            var applicationUsers = await _userManager.Users.ToListAsync();
            return applicationUsers;
        }
    }
}