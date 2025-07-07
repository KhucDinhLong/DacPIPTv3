using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.Models_Old
{
    [Table("Province")]
    public class Province
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string NationallityCode { get; set; }
        public string PostalCode { get; set; }
        public bool? Active { get; set; }
    }
}
