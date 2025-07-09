using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.OldVersion
{
    [Table("SecGroupUser")]
    public class SecGroupUser
    {
        public Guid GroupID { get; set; }
        public string LoginID { get; set; }
    }
}
