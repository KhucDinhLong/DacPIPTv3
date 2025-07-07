using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacRegion")]
    public class DacRegion
    {
        [Key]
        public int ID { get; set; }
        public string RegionCode { get; set; }
        public string RegionArea { get; set; }
        public bool? Active { get; set; }
        public string MotherRegion { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
