using System;

namespace DAC.DAL.ViewModels
{
    public class DacProductVM
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ProductUnitId { get; set; }
        public string Size { get; set; }
        public string RegisterNumber { get; set; }
        public int? ProductCategoryId { get; set; }
        public string Remark { get; set; }
        public bool? Active { get; set; }
        public string Manufacture { get; set; }
        public string GeneralFormat { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public string UnitName { get; set; }
        public string CategoryName { get; set; }
    }
}
