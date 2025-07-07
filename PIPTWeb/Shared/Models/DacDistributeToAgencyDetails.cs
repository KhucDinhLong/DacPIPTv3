using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class DacDistributeToAgencyDetails
    {
        [Key]
        public long ID { get; set; }
        public int? DistributorID { get; set; }
        public string DacCode { get; set; }
        public string ProductCode { get; set; }
        public long? Quantity { get; set; }
    }
}
