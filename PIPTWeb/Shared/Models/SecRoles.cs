using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class SecRoles : IdentityRole
    {
        public int? CustomerId { set; get; }
    }
}
