using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("DacDistributeToFactoryDetails")]
    public class DacDistributeToFactoryDetails
    {
        [Key]
        public long ID { get; set; }
        public int? DistributorID { get; set; }
        public string DacCode { get; set; }
        public string ProductCode { get; set; }
    }
}
