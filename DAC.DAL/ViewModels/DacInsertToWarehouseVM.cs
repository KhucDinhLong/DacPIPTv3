using System;
using System.Collections.Generic;

namespace DAC.DAL.ViewModels
{
    public class DacInsertToWarehouseVM
    {
        public int Id { get; set; }
        public string InsertNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ProductCode { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public string StockCode { get; set; }
        public bool? Active { get; set; }
        public int? OutputType { get; set; }
        public int? RealityQuantity { get; set; }
        public string ProductName { get; set; }
        public string StockName { get; set; }
        public List<DacInsertToWarehouseDetails> LstDetails { get; set; }
    }
}
