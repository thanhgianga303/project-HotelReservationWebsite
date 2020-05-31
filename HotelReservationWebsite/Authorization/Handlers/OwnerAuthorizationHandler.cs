using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using HotelReservationWebsite.Models;
using HotelReservationWebsite.Services.IService;
using System;

namespace HotelReservationWebsite.Authorization.Handlers
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
            // Console.WriteLine("test" + user.Id + " and " + resource.OwnerID);
            if (user.Id == resource.OwnerID)
            {

                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}