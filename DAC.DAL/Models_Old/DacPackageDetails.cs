using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("DacPackageDetails")]
    public class DacPackageDetails
    {
        [Key]
        public int ID { get; set; }
        public int? PackageId { get; set; }
        public string DacCode { get; set; }
    }
}
