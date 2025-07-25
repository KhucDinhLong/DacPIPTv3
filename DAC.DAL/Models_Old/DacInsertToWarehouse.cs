﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL.OldVersion
{
    [Table("DacInsertToWarehouse")]
    public class DacInsertToWarehouse
    {
        [Key]
        public int ID { get; set; }
        public string InsertNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ProductCode { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public int? OutputType { get; set; }
        public string StockId { get; set; }
    }
}
