using System;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class SecGroupAuthorization
    {
        [Key]
        public Guid GroupID { get; set; }
        [Key]
        public Guid AuthorizationID { get; set; }
    }
}
