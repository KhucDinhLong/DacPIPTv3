using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("DacSellCount")]
    public class DacSellCount
    {
        [Key]
        public int Id { get; set; }
        public string UnitCode { get; set; }
        public int? SellCount { get; set; }
        public long? StartingNumber { get; set; }
        public DateTime? SellDate { get; set; }
        public bool? TxtType { get; set; }
        public string PromotionCode { get; set; }
        public string ProductCode { get; set; }
        public string Memo { get; set; }
        public bool? snyn { get; set; }
        public string snbegin { get; set; }
        public string snend { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Active { get; set; }

        public DacSellCount()
        {
            Id = -1;
            UnitCode = string.Empty;
            SellDate = DateTime.Now;
            TxtType = true;
            PromotionCode = string.Empty;
            ProductCode = string.Empty;
            Memo = string.Empty;
            Active = true;

            // Cac phan chua su dung
            SellCount = 0;
            StartingNumber = 0;
            snyn = false;
            snbegin = string.Empty;
            snend = string.Empty;
            EndDate = DateTime.Now;
        }
    }
    //public class DacSellCountCollection : List<DacSellCount> { }
}
