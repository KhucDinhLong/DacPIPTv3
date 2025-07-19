using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacExport1")]
    public class DacExport1
    {
        [Key]
        public int Id { get; set; }
        public string OriginalId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CustomerCode { get; set; }
        public double? Quantity { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string StockCode { get; set; }
    }
}
