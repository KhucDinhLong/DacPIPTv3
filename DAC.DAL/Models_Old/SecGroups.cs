using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("SecGroups")]
    public class SecGroups
    {
        [Key]
        public Guid GroupID { get; set; }
        public string GroupName { get; set; }
        public string Note { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
