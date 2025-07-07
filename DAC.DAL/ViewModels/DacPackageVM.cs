using System;
using System.Collections.Generic;

namespace DAC.DAL.ViewModels
{
    public class DacPackageVM 
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string PackageCode { get; set; }
        public string ProductCode { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string FactoryCode { get; set; }
        public string Batch { get; set; }
        public string PersonPackaged { get; set; }
        public DateTime? NgaySanXuat { get; set; }
        public int RealityQuantity { get; set; }
        public string ProductName { get; set; }
        public List<DacPackageDetails> LstDetails { get; set; }
    }
}
