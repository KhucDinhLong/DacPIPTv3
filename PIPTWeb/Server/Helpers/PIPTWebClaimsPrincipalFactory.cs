using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PIPTWeb.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PIPTWeb.Server.Helpers
{
    public class PIPTWebClaimsPrincipalFactory : UserClaimsPrincipalFactory<SecUsers, SecRoles>
    {
        public PIPTWebClaimsPrincipalFactory(
            UserManager<SecUsers> userManager,
            RoleManager<SecRoles> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {}

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(SecUsers user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            List<Claim> claims = new List<Claim>();
            foreach(var role in RoleManager.Roles)
            {
                if (await UserManager.IsInRoleAsync(user, role.Name))
                {
                    var roleClaims = await RoleManager.GetClaimsAsync(role);
                    if(roleClaims.Any())
                    {
                        claims.AddRange(roleClaims);
                    }
                }
            }
            if(claims.Count >= 0)
            {
                identity.AddClaims(claims);
            }
            return identity;
        }
    }
}
