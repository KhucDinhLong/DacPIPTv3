using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("DacContainer")]
    public class DacContainer
    {
        [Key]
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ContainerCode { get; set; }
        public string ProductCode { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
    }
}
