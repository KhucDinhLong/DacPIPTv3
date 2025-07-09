using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.OldVersion
{
    [Table("DacStock")]
    public class DacStock
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Mobi { get; set; }
        public string Manager { get; set; }
        public string BranchID { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
    }
}
