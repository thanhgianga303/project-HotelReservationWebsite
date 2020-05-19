using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services;
using HotelReservationWebsite.IServices;

namespace HotelReservationWebsite.Authorization
{
    public class OwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Hotel>
    {
        private readonly IIdentityService<Buyer> _identityService;

        public OwnerAuthorizationHandler(IIdentityService<Buyer> identityService)
        {
            _identityService = identityService;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Hotel resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }

            var user = _identityService.Get(context.User);
            if (user.Id == resource.OwnerID)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}