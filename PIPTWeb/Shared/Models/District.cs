using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class District
    {
        [Key]
        public int ID { get; set; }
        public string ProvinceCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }
}
