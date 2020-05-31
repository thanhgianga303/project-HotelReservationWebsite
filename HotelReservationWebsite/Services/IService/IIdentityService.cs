using System.Security.Claims;

namespace HotelReservationWebsite.Services.IService
{
    public interface IIdentityService<T> where T : class
    {
        T Get(ClaimsPrincipal user);
    }
}