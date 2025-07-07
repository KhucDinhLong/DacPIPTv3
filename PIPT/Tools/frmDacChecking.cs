using DAC.Core;
using DAC.Core.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacChecking : Form
    {
        #region Variables
        IDacPackageService _packageService;
        IDacProductService _productService;
        IDacDistributeToAgencyDetailsService _exportToAgencyDetailService;
        IDacDistributeToStoreDetailsService _exportToStoreDetailService;
        IDacAgencyService _agencyService;
        IDacStoreService _storeService;
        #endregion
        #region Form's Events
        public frmDacChecking(IDacPackageService packageService, IDacProductService productService, IDacDistributeToAgencyDetailsService exportToAgencyDetailService
            , IDacDistributeToStoreDetailsService exportToStoreDetailService, IDacAgencyService agencyService, IDacStoreService storeService)
        {
            InitializeComponent();
            _packageService = packageService;
            _productService = productService;
            _exportToAgencyDetailService = exportToAgencyDetailService;
            _exportToStoreDetailService = exportToStoreDetailService;
            _agencyService = agencyService;
            _storeService = storeService;
        }
        #endregion

        private void textBoxDacCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                string serial = CommonCore.GetSerialFromScanner(txtDacCode.Text);
                txtDacCode.Text = serial;
                GetInfo(serial);
            }
        }

        private void buttonChecking_Click(object sender, EventArgs e)
        {
            GetInfo(txtDacCode.Text);
        }

        public void GetInfo(string sDacCode)
        {
            string sProductCode = string.Empty;
            var ExportToAgencyInfo = _exportToAgencyDetailService.GetExportInfo(sDacCode)?.ResponseData;
            var ExportToStoreInfo = _exportToStoreDetailService.GetExportInfo(sDacCode)?.ResponseData;
            var PackageInfo = _packageService.GetInfo(sDacCode)?.ResponseData;
            if (PackageInfo != null)
            {
                txtPackageCreateDate.Text = PackageInfo.CreatedDate.HasValue ? PackageInfo.CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                txtPackageCode.Text = PackageInfo.PackageCode;
                txtPackageProductCode.Text = PackageInfo.ProductCode;
                txtPackageProductName.Text = PackageInfo.ProductName;
                txtQuantity.Text = PackageInfo.Quantity.HasValue ? PackageInfo.Quantity.Value.ToString() : string.Empty;
                txtBatch.Text = PackageInfo.Batch;
                txtFactory.Text = PackageInfo.FactoryCode;
                txtPersonPackage.Text = PackageInfo.PersonPackaged;
                grbPackageInfo.Visible = true;
                sProductCode = PackageInfo.ProductCode;
            }
            else
            {
                grbPackageInfo.Visible = false;
            }
            if (ExportToAgencyInfo != null)
            {
                txtNgayXuat.Text = ExportToAgencyInfo.CreatedDate.HasValue ? ExportToAgencyInfo.CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                txtAgencyCode.Text = ExportToAgencyInfo.AgencyCode;
                var agency = _agencyService.GetByCode(ExportToAgencyInfo.AgencyCode)?.ResponseData;
                if (agency != null)
                {
                    txtAgencyName.Text = agency.Name;
                    txtAgencyAddress.Text = agency.Address;
                    txtAgencyOwner.Text = agency.OwnerName;
                    txtAgencyMobile.Text = agency.MobileNum;
                    txtAgencyEmail.Text = agency.Email;
                    txtAgencyProvince.Text = agency.ProvinceCode;
                    
                    txtAgencyDependCode.Text = agency.DependCode;
                    txtAgencyJoinContact.Text = agency.JoinContact;
                    txtAgencyPhoneNum.Text = agency.PhoneNum;
                    txtAgencyRegion.Text = agency.Region;
                    txtDescription.Text = agency.Description;
                    var detail = _exportToAgencyDetailService.GetByDacCode(sDacCode)?.ResponseData;
                    if (detail != null)
                    {
                        txtAgencyPCode.Text = detail.ProductCode;
                        sProductCode = detail.ProductCode;
                    }
                    groupBoxAgency.Visible = true;
                }
            }
            else
            {
                groupBoxAgency.Visible = false;
            }
            if (ExportToStoreInfo != null)
            {
                txtStoreDateExport.Text = ExportToAgencyInfo.CreatedDate.HasValue ? ExportToAgencyInfo.CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                txtStoreCode.Text = ExportToAgencyInfo.AgencyCode;
                var store = _storeService.GetByCode(ExportToStoreInfo.StoreCode)?.ResponseData;
                if (store != null)
                {
                    txtStoreName.Text = store.Name;
                    txtStoreAddress.Text = store.Address;
                    txtStoreOwner.Text = store.ShopKeeper;
                    txtStoreMobile.Text = store.MobileNum;
                    txtStoreEmail.Text = store.Email;
                    var detail = _exportToStoreDetailService.GetByDacCode(sDacCode)?.ResponseData;
                    if (detail != null)
                    {
                        txtStorePCode.Text = detail.ProductCode;
                        sProductCode = detail.ProductCode;
                    }
                    groupBoxStore.Visible = true;
                }
            }
            else
            {
                groupBoxStore.Visible = false;
            }
            if (!string.IsNullOrWhiteSpace(sProductCode))
            {
                var product = _productService.GetByCode(sProductCode)?.ResponseData;
                if (product != null)
                {
                    txtProductCode.Text = product.Code;
                    txtProductName.Text = product.Name;
                    txtProductRegisterNumber.Text = product.RegisterNumber;
                    txtProductManufacture.Text = product.Manufacture;
                    txtProductGeneralFormat.Text = product.GeneralFormat;
                    groupBoxProduct.Visible = true;
                }
                else
                {
                    groupBoxProduct.Visible = false;
                }
            }
            else
            {
                groupBoxProduct.Visible = false;
            }
            
                
        }
    }
}
