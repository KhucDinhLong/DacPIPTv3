using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacDistributeToStoreDetails")]
    public class DacDistributeToStoreDetails
    {
        [Key]
        public long Id { get; set; }
        public int? DistributeToStoreId { get; set; }
        public string DacCode { get; set; }
        public string ProductCode { get; set; }
    }
}
