using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("SecGroupUser")]
    public class SecGroupUser
    {
        public Guid GroupId { get; set; }
        public string LoginId { get; set; }
    }
}
