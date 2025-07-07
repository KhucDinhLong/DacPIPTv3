using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacInsertToWarehouse")]
    public class DacInsertToWarehouse
    {
        [Key]
        public int Id { get; set; }
        public string InsertNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ProductCode { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public string StockCode { get; set; }
        public bool? Active { get; set; }
        public int? OutputType { get; set; }
    }
}
