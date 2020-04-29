using System.Security.Claims;

namespace HotelReservationWebsite.Services
{
    public interface IIdentityService<T> where T : class
    {
        T Get(ClaimsPrincipal user);
    }
}