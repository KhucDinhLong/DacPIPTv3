using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class SecStockUser
    {
        [Key]
        public string StockID { get; set; }
        [Key]
        public string LoginID { get; set; }
    }

}
