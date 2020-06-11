using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityAPI.Models;
using IdentityAPI.Models.IRepositories;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace IdentityAPI.Data.Repositories
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
        public async Task Create(ApplicationUser _user)
        {
            var user = await _userManager.FindByNameAsync(_user.UserName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = _user.UserName,
                    Email = _user.Email,
                    PhoneNumber = _user.PhoneNumber,
                    FullName = _user.FullName,
                    IdentityCard = _user.IdentityCard,
                    DateOfBirth = _user.DateOfBirth,
                    Address = _user.Address,
                    Gender = _user.Gender
                };
                var result = _userManager.CreateAsync(user, _user.PasswordHash).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                // await _userManager.AddToRoleAsync(user, "Customer");
                // var customerName = _user.FullName + "";
                // var dateOfBirth = Convert.ToDateTime(_user.DateOfBirth) + "";
                // var identityCard = _user.IdentityCard + "";
                // var email = _user.Email + "";
                // var phone = _user.PhoneNumber + "";
                // var address = _user.Address + "";
                // result = _userManager.AddClaimsAsync(user, new Claim[]{
                //         new Claim(JwtClaimTypes.Name, customerName),
                //         new Claim(JwtClaimTypes.BirthDate, dateOfBirth),
                //         new Claim("IdentityCard", identityCard),
                //         new Claim(JwtClaimTypes.Email, email),
                //         new Claim(JwtClaimTypes.PhoneNumber, phone),
                //         new Claim(JwtClaimTypes.Address, address)
                //       }).Result;
                // if (!result.Succeeded)
                // {
                //     throw new Exception(result.Errors.First().Description);
                // }
            }
        }
        public async Task<ApplicationUser> GetBy(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
        public async Task Update(string id, ApplicationUser _user)
        {

            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.UserName = _user.UserName;
                user.PasswordHash = _user.PasswordHash;
                user.Email = _user.Email;
                user.PhoneNumber = _user.PhoneNumber;
                await _userManager.UpdateAsync(user);
            }
        }
        public async Task Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }

    }
}

