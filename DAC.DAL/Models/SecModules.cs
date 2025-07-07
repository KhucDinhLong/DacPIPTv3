using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("SecModules")]
    public class SecModules
    {
        [Key]
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string Note { get; set; }
    }
}
