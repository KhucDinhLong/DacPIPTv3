using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.OldVersion
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
