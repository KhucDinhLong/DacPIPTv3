using Microsoft.AspNetCore.Authorization;

namespace PIPTWeb.Client.PolicyProvider
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; set; }
        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
