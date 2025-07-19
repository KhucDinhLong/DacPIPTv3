using DAC.DAL;
using System;
using System.Collections.Generic;

namespace DAC.Core.Models
{
    public class DacDistributeToStoreViewModel
    {
        public DacExport2 DacDistributeToStore { get; set; }
        public List<DacExportDetail2> StoreDetailsCollection { get; set; }
    }

    public class DacStoreViewModel
    {
        public List<DacStore> DacStoreCollection { get; set; }
    }

    public class DacStoreDetailsViewModel
    {
        public List<DacExportDetail2> StoreDetailsCollection { get; set; }
    }

    public class AgencyTrackViewModel
    {
        public ProductModel ProductModel { get; set; }
        public DistributeToAgencyModel DistributeToAgencyModel { get; set; }
        public DistributeToStoreModel DistributeToStoreModel { get; set; }
    }

    public class CustomerProductSeriModel
    {
        public CustomerProductSeriCollection ProductSeriCollection { get; set; }
    }

    #region Define Model Classes
    public class ProductModel
    {
        public int Id { get; set; } = -1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int ProductUnitId { get; set; } = 1;
        public string Size { get; set; } = string.Empty;
        public string RegisterNumber { get; set; } = string.Empty;
        public string ProductCategoryName { get; set; } = string.Empty;
        public string Manufacture { get; set; } = string.Empty;
        public string GeneralFormat { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;
        public string CreatedUser { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedUser { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
    }

    public class DistributeToAgencyModel
    {
        public int ID { get; set; } = -1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string AgencyCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string MobileNum { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string ProvinceName { get; set; } = string.Empty;
        public string DacCode { get; set; } = string.Empty;
        public string DetailID { get; set; } = string.Empty;
        public string DependCode { get; set; } = string.Empty;
        public string JoinContact { get; set; } = string.Empty;
        public string TaxCode { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }

    public class DistributeToStoreModel
    {
        public string ID { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string StoreCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string MobileNum { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string DacCode { get; set; } = string.Empty;
        public string DetailID { get; set; } = string.Empty;
    }
    #endregion

}