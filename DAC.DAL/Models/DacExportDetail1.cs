using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacExportDetail1")]
    public class DacExportDetail1
    {
        [Key]
        public long Id { get; set; }
        public int? ExportId { get; set; }
        public string DacCode { get; set; }
        public string ProductCode { get; set; }
    }
}
