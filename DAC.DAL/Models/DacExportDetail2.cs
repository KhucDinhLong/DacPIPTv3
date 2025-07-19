using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacExportDetail2")]
    public class DacExportDetail2
    {
        [Key]
        public long Id { get; set; }
        public int? ExportId { get; set; }
        public string DacCode { get; set; }
        public string ProductCode { get; set; }
    }
}
