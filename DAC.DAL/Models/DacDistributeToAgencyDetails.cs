using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacDistributeToAgencyDetails")]
    public class DacDistributeToAgencyDetails
    {
        [Key]
        public long Id { get; set; }
        public int? DistributeToAgencyId { get; set; }
        public string DacCode { get; set; }
        public string ProductCode { get; set; }
    }
}
