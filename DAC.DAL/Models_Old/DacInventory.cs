using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.OldVersion
{
    [Table("DacInventory")]
    public class DacInventory
    {
        [Key]
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public int? Quantity { get; set; }
        public int? Year { get; set; }
        public string StockID { get; set; }
    }
}
