using System.Security.Claims;

namespace HotelReservationWebsite.IServices
{
    public interface IIdentityService<T> where T : class
    {
        T Get(ClaimsPrincipal user);
    }
}