using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Techievibe.Hub.API.Authentication
{ 
    public class HmacStringRequirement : AuthorizationHandler<HmacStringRequirement>, IAuthorizationRequirement
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HmacStringRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var dobVal = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value;
            var dateOfBirth = Convert.ToDateTime(dobVal);
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            if (age >= 18)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
