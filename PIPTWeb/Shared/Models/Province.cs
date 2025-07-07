using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
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
