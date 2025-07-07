using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("SecStockUser")]
    public class SecStockUser
    {
        public string StockID { get; set; }
        public string LoginID { get; set; }
    }
}
