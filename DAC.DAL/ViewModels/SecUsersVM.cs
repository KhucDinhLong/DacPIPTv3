using System;
using System.Collections.Generic;

namespace DAC.DAL.ViewModels
{
    public class SecUsersVM
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? LockedUser { get; set; }
        public DateTime? LockedDate { get; set; }
        public string LockedReason { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastChangedPassword { get; set; }
        public DateTime? DeadlineOfUsing { get; set; }
        public string CustomerCode { get; set; }
        public List<SecGroups> LstGroup { get; set; }
        public string CustomerName { get; set; }
        public bool? isAdmin { get; set; }
        public int? Level { get; set; }
    }
}
