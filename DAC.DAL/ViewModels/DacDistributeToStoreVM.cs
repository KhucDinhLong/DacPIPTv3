using System;
using System.Collections.Generic;

namespace DAC.DAL.ViewModels
{
    public class DacDistributeToStoreVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string StoreCode { get; set; }
        public string ProductName { get; set; }
        public double? Quantity { get; set; }
        public string Description { get; set; }
        public string StockCode { get; set; }
        public bool? Active { get; set; }
        public string StoreName { get; set; }
        public string StockName { get; set; }
        public int RealityQuantity { get; set; }
        public List<DacDistributeToStoreDetailsVM> LstDetails { get; set; }
    }
}
