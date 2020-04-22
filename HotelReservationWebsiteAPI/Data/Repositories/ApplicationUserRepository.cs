using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Infrastructure;
using HotelReservationWebsiteAPI.Models;
using HotelReservationWebsiteAPI.Models.InputModel;
using HotelReservationWebsiteAPI.Models.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HotelReservationWebsiteAPI.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ICustomerRepository _repository;
        private readonly HotelReservationWebsiteContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserRepository(UserManager<ApplicationUser> userManager, ICustomerRepository repository, HotelReservationWebsiteContext context)
        {
            _userManager = userManager;
            _repository = repository;
            _context = context;
        }
        public async Task<IEnumerable<ApplicationUser>> GetApplicationUsers()
        {
            var applicationUsers = await _userManager.Users.ToListAsync();
            return applicationUsers;
        }
        public async Task Create(InputUserModel _input)
        {
            var customer = new Customer
            {
                CustomerName = _input.FullName,
                DateOfBirth = Convert.ToDateTime(_input.DateOfBirth),
                IdentityCard = _input.IdentityCard,
                Email = _input.Email,
                Phone = _input.Phone,
                Address = _input.Address
            };
            await _repository.Add(customer);
            var findCustomer = _context.Customers.Where(m => m.Email.Contains(_input.Email)
                                && m.Phone.Contains(_input.Phone)
                                && m.IdentityCard.Contains(_input.IdentityCard));
            var id = findCustomer.FirstOrDefault();
            var user = new ApplicationUser
            {
                CustomerID = id.CustomerID,
                UserName = _input.Username,
                Email = _input.Email,
                PhoneNumber = _input.Phone
            };
            var result = _userManager.CreateAsync(user, _input.Password).Result;
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
        }
        public async Task<ApplicationUser> GetBy(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
        public async Task Update(string id, InputChangeInfoModel _input)
        {

            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.UserName = _input.Username;
                user.PasswordHash = _input.Password;
                user.Email = _input.Email;
                user.PhoneNumber = _input.Phone;
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

