using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("DacInsertToWarehouseDetails")]
    public class DacInsertToWarehouseDetails
    {
        [Key]
        public long ID { get; set; }
        public int? InsertID { get; set; }
        public string DacCode { get; set; }
        public byte? Status { get; set; }
    }
}
