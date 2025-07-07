using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("SecStockUser")]
    public class SecStockUser
    {
        public string StockId { get; set; }
        public string LoginId { get; set; }
    }
}
