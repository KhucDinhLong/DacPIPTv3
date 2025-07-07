using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("SecMenu")]
    public class SecMenu
    {
        [Key]
        public string MenuID { get; set; }
        public int? MenuPosition { get; set; }
        public string MenuValue { get; set; }
        public string MenuFiliationID { get; set; }
        public string FormName { get; set; }
    }
}
