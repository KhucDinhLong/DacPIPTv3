﻿using System;
using System.Collections.Generic;

namespace DAC.DAL.ViewModels
{
    public class DacCustomerVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ProvinceCode { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNum { get; set; }
        public string MobileNum { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string TaxCode { get; set; }
        public string JoinContact { get; set; }
        public string DependCode { get; set; }
        public string Region { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public string ParentName { get; set; }
        public int Level { get; set; }
        public List<DacStore> LstStore { get; set; }
    }
}
