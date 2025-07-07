using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("SecMenuGroup")]
    public class SecMenuGroup
    {
        public Guid GroupId { get; set; }
        public string MenuId { get; set; }
    }
}
