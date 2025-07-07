using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("SecMenuGroup")]
    public class SecMenuGroup
    {
        public Guid GroupID { get; set; }
        public string MenuID { get; set; }
    }
}
