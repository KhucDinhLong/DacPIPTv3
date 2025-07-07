using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class SecFormUsers
    {
        [Key]
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? LockedUser { get; set; }
        public DateTime? LockedDate { get; set; }
        public string LockedReason { get; set; }
        public DateTime? LastLogIn { get; set; }
        public DateTime? LastChangedPassword { get; set; }
        public DateTime? DeadlineOfUsing { get; set; }
        public int? CustomerId { get; set; }
        public int? AgencyId { get; set; }
    }
}
