using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.OldVersion
{
    [Table("SecStockUser")]
    public class SecStockUser
    {
        public string StockID { get; set; }
        public string LoginID { get; set; }
    }
}
