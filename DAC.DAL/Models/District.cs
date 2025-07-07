using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string ProvinceCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }
}
