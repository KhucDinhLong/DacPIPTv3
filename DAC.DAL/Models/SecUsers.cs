using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("SecUsers")]
    public class SecUsers
    {
        [Key]
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? LockedUser { get; set; }
        public DateTime? LockedDate { get; set; }
        public string LockedReason { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastChangedPassword { get; set; }
        public DateTime? DeadlineOfUsing { get; set; }
        public string AgencyCode { get; set; }
    }
}
