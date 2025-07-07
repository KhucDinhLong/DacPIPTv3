using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Client.PolicyProvider
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if(context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // Tài khoản quản trị, có full quyền
            var IsAdmin = context.User.FindFirst("IsAdmin")?.Value;
            if(!string.IsNullOrEmpty(IsAdmin) && IsAdmin.ToLower() == "true")
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            if(requirement.Permission.Contains("Permissions"))
            {
                var permissions = context.User.Claims.Where(c => c.Type == "Permissions"
                && c.Value == requirement.Permission && c.Issuer == "LOCAL AUTHORITY");
                //var username = context.User.FindFirst("FullName")?.Value;
                if(permissions.Any())
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            else if (requirement.Permission.Contains("Routers"))
            {
                var routers = context.User.Claims.Where(c => c.Type == "Routers"
                && c.Value == requirement.Permission && c.Issuer == "LOCAL AUTHORITY");
                if (routers.Any())
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}
