using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.OldVersion
{
    [Table("DacAgency")]
    public class DacAgency
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ProvinceCode { get; set; }
        public string OwnerName { get; set; }
        public string TaxCode { get; set; }
        public string PhoneNum { get; set; }
        public string MobileNum { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string JoinContact { get; set; }
        public string DependCode { get; set; }
        public string Region { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public bool? Active { get; set; }
    }
}
