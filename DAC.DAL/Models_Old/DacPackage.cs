using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("DacPackage")]
    public class DacPackage
    {
        [Key]
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string PackageCode { get; set; }
        public string ProductCode { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public string FactoryCode { get; set; }
        public string Batch { get; set; }
        public string PersonPackaged { get; set; }
        public bool? Active { get; set; }
    }
}
