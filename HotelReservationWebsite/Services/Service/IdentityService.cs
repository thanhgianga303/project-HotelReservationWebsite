using System.Security.Claims;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Services.Service
{
    public class IdentityService : IIdentityService<Buyer>
    {
        public Buyer Get(ClaimsPrincipal user)
        {
            return new Buyer
            {
                Id = user.FindFirstValue("sub")
            };
        }
    }
}