using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacProductUnit")]
    public class DacProductUnit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
    }
}
