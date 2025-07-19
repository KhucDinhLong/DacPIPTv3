using System;
using System.Collections.Generic;

namespace DAC.DAL.ViewModels
{
    public class DacExportVM
    {
        public int Id { get; set; }
        public string OriginalId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CustomerCode { get; set; }
        public double? Quantity { get; set; }
        public string Description { get; set; }
        public string StockCode { get; set; }
        public bool? Active { get; set; }
        public string CustomerName { get; set; }
        public string StockName { get; set; }
        public int RealityQuantity { get; set; }
        public string ProductName { get; set; }
        public int? CustomerLevel { get; set; }
        public List<DacExportDetailVM> LstDetails { get; set; }
    }
}
