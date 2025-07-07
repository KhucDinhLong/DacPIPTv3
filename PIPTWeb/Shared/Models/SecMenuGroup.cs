using System;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class SecMenuGroup
    {
        [Key]
        public Guid GroupID { get; set; }
        [Key]
        public string MenuID { get; set; }
    }
}
