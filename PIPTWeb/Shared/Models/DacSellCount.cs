using System;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class DacSellCount
    {
        [Key]
        public int ID { get; set; }
        public string UnitCode { get; set; }
        public int? SellCount { get; set; }
        public long? StartingNumber { get; set; }
        public DateTime? SellDate { get; set; }
        public int? TxtType { get; set; }
        public string PromotionCode { get; set; }
        public string ProductCode { get; set; }
        public string Memo { get; set; }
        public bool? snyn { get; set; }
        public string snbegin { get; set; }
        public string snend { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Active { get; set; }
        public int? CustomerId { get; set; }
    }
}
