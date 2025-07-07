using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("SecMenu")]
    public class SecMenu
    {
        [Key]
        public string MenuId { get; set; }
        public int? MenuPosition { get; set; }
        public string MenuValue { get; set; }
        public string MenuFiliationID { get; set; }
        public string FormName { get; set; }
    }
}
