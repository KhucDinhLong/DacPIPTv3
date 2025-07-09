using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.OldVersion
{
    [Table("DacContainerDetails")]
    public class DacContainerDetails
    {
        [Key]
        public int ID { get; set; }
        public int? ContainerId { get; set; }
        public string PackageCode { get; set; }
    }
}
