using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacInventory")]
    public class DacInventory
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int? Quantity { get; set; }
        public int? Year { get; set; }
        public string StockId { get; set; }
        public string ProductName { get; set; }
        public string StockName { get; set; }
    }
}
