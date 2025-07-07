using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacDistributeToAgency")]
    public class DacDistributeToAgency
    {
        [Key]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string AgencyCode { get; set; }
        public double? Quantity { get; set; }
        public string Description { get; set; }
        public string StockCode { get; set; }
        public bool? Active { get; set; }
    }
}
