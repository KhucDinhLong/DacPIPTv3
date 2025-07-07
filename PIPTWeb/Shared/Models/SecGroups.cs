using System;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class SecGroups
    {
        [Key]
        public Guid GroupID { get; set; }
        public string GroupName { get; set; }
        public string Note { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
