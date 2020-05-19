using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using HotelReservationWebsite.Models;

namespace HotelReservationWebsite.Authorization
{
    public class AdministratorsAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Hotel>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Hotel resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(Constants.AdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}