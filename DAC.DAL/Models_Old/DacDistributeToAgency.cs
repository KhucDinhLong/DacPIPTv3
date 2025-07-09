using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.OldVersion
{
    [Table("DacDistributeToAgency")]
    public class DacDistributeToAgency
    {
        [Key]
        public int ID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ProvinceCode { get; set; }
        public string AgencyCode { get; set; }
        public string ProductCode { get; set; }
        public double? Quantity { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string StockID { get; set; }
    }
}
