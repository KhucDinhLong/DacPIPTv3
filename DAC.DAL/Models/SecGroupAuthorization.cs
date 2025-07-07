using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("SecGroupAuthorization")]
    public class SecGroupAuthorization
    {
        public Guid GroupId { get; set; }
        public Guid AuthorizationId { get; set; }
    }
}
