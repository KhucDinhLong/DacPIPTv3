using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("SecConfig")]
    public class SecConfig
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Pattern { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
    }
}
