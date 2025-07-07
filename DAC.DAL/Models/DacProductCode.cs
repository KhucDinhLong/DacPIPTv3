using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacProductCode")]
    public class DacProductCode
    {
        [Key]
        public long Id { get; set; }
        public string DacCode { get; set; }
        public string Series { get; set; }
    }
}
