using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacProductQuery")]
    public class DacProductQuery
    {
        [Key]
        public int Id { get; set; }
        public long? QueryRecID { get; set; }
        public string PhoneNumber { get; set; }
        public string UnitCode { get; set; }
        public string DacCode { get; set; }
        public byte? QueryStatus { get; set; }
        public DateTime? QueryDate { get; set; }
    }
}
