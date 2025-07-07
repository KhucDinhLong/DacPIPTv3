using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacInsertToWarehouseDetails")]
    public class DacInsertToWarehouseDetails
    {
        [Key]
        public long Id { get; set; }
        public int? InsertID { get; set; }
        public string DacCode { get; set; }
        public byte? Status { get; set; }
    }
}
