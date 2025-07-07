using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacProduct")]
    public class DacProduct
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ProductUnitId { get; set; }
        public string Size { get; set; }
        public string RegisterNumber { get; set; }
        public int? ProductCategoryId { get; set; }
        public string Remark { get; set; }
        public bool? Active { get; set; }
        public string Manufacture { get; set; }
        public string GeneralFormat { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
