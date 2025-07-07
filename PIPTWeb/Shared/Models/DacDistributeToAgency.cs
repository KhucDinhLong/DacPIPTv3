using System;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class DacDistributeToAgency
    {
        [Key]
        public int ID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ProvinceCode { get; set; }
        public int? SrcAgencyId { get; set; }
        public int? DesAgencyId { get; set; }
        public string ProductCode { get; set; }
        public double? Quantity { get; set; }
        public string Description { get; set; }
        public string StockID { get; set; }
        public bool? Active { get; set; }
        public int? CustomerId { get; set; }
    }
}
