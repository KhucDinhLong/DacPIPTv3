using DAC.Core;
using DAC.Core.Common;
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
        IDacExportDetailProcessService _exportDetailService;
        IDacCustomerService _agencyService;
        IDacStoreService _storeService;
        bool visibleExportGroup;
        bool visibleExportGroup1;
        bool visibleExportGroup2;
        bool visibleExportGroup3;
        #endregion
        #region Form's Events
        public frmDacChecking(IDacPackageService packageService, IDacProductService productService, IDacExportDetailProcessService exportDetailService
            , IDacCustomerService agencyService, IDacStoreService storeService)
        {
            InitializeComponent();
            _packageService = packageService;
            _productService = productService;
            _exportDetailService = exportDetailService;
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
            string ExportProductCode = string.Empty;
            string PackageProductCode = string.Empty;
            var ExportInfo = _exportDetailService.GetExportInfo(sDacCode)?.ResponseData;
            var PackageInfo = _packageService.GetInfo(sDacCode)?.ResponseData;
            if (PackageInfo != null)
            {
                txtPackageCreateDate.Text = PackageInfo.CreatedDate.HasValue ? PackageInfo.CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                txtPackageCode.Text = PackageInfo.PackageCode;
                txtQuantity.Text = PackageInfo.Quantity.HasValue ? PackageInfo.Quantity.Value.ToString() : string.Empty;
                txtBatch.Text = PackageInfo.Batch;
                txtPersonPackage.Text = PackageInfo.PersonPackaged;
                grPackage.Visible = true;
                sProductCode = PackageInfo.ProductCode;
            }
            else
            {
                grPackage.Visible = false;
            }
            if (ExportToAgencyInfo != null)
            {
                txtNgayXuat.Text = ExportToAgencyInfo.CreatedDate.HasValue ? ExportToAgencyInfo.CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                txtAgencyCode.Text = ExportToAgencyInfo.CustomerCode;
                var agency = _agencyService.GetByCode(ExportToAgencyInfo.CustomerCode)?.ResponseData;
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
                txtStoreCode.Text = ExportToAgencyInfo.CustomerCode;
                var store = _storeService.GetByCode(ExportToStoreInfo.CustomerCode)?.ResponseData;
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
            if (!string.IsNullOrWhiteSpace(ExportProductCode))
            {
                var product = _productService.GetByCode(ExportProductCode)?.ResponseData;
                if (product != null)
                {
                    txtProductCode.Text = product.Code;
                    txtProductName.Text = product.Name;
                    txtProductRegisterNumber.Text = product.RegisterNumber;
                    txtProductManufacture.Text = product.Manufacture;
                    txtProductGeneralFormat.Text = product.GeneralFormat;
                    grProduct.Visible = true;
                }
                else
                {
                    grProduct.Visible = false;
                }
            }
            else
            {
                grProduct.Visible = false;
            }


        }

        private void frmDacChecking_Load(object sender, EventArgs e)
        {
            if ((Session.CurrentUser.isAdmin.HasValue && Session.CurrentUser.isAdmin.Value) || Session.CurrentUser.Level == 4)
            {
                visibleExportGroup = visibleExportGroup1 = visibleExportGroup2 = visibleExportGroup3 = true;
            }
            else
            {
                switch (Session.CurrentUser.Level.Value)
                {
                    case 1:
                        visibleExportGroup = true;
                        visibleExportGroup1 = visibleExportGroup2 = visibleExportGroup3 = false;
                        break;
                    case 2:
                        visibleExportGroup = visibleExportGroup1 = true;
                        visibleExportGroup2 = visibleExportGroup3 = false;
                        break;
                    case 3:
                        visibleExportGroup = visibleExportGroup1 = visibleExportGroup2 = true;
                        visibleExportGroup3 = false;
                        break;
                    default:
                        break;
                }
            }
            grExport.Visible = visibleExportGroup;
            grExport1.Visible = visibleExportGroup1;
            grExport2.Visible = visibleExportGroup2;
            grExport3.Visible = visibleExportGroup3;
        }
    }
}
