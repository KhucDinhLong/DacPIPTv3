using System;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class DacContainer
    {
        [Key]
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ContainerCode { get; set; }
        public string ProductCode { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public int? CustomerId { get; set; }
    }
}
