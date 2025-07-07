using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("SecGroups")]
    public class SecGroups
    {
        [Key]
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public string Note { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
