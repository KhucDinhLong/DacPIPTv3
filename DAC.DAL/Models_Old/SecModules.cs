using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("SecModules")]
    public class SecModules
    {
        [Key]
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string Note { get; set; }
    }
}
