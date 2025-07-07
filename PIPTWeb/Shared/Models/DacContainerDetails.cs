using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class DacContainerDetails
    {
        [Key]
        public long ID { get; set; }
        public int? ContainerId { get; set; }
        public string PackageCode { get; set; }
    }
}
