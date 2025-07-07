using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("DacFactory")]
    public class DacFactory
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OwnerName { get; set; }
        public string MobileNum { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public bool? Active { get; set; }
    }
}
