using Microsoft.AspNetCore.Identity;
using System;

namespace PIPTWeb.Shared.Models
{
    public class SecUsers : IdentityUser
    {
        public int? AgencyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsAdmin { get; set; }
        public string Avatar { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
