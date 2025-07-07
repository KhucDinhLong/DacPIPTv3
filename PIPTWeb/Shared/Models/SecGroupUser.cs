using System;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class SecGroupUser
    {
        [Key]
        public Guid GroupID { get; set; }
        [Key]
        public string LoginID { get; set; }
    }
}
