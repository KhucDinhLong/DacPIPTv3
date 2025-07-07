using System;
using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class DacLogBook
    {
        [Key]
        public long ID { get; set; }
        public string ComputerName { get; set; }
        public string IPAddress { get; set; }
        public string WindowsUser { get; set; }
        public string LogAction { get; set; }
        public string LogDescription { get; set; }
        public string LogContent { get; set; }
        public string FormName { get; set; }
        public string UserName { get; set; }
        public DateTime? LogTime { get; set; }
        public int? CustomerId { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}
