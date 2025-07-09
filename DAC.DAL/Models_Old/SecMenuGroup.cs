using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.OldVersion
{
    [Table("SecMenuGroup")]
    public class SecMenuGroup
    {
        public Guid GroupID { get; set; }
        public string MenuID { get; set; }
    }
}
