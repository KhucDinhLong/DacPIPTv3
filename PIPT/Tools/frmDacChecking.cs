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
        #endregion
        #region Form's Events
        public frmDacChecking(IDacPackageService packageService, IDacProductService productService, IDacExportDetailProcessService exportDetailService)
        {
            InitializeComponent();
            _packageService = packageService;
            _productService = productService;
            _exportDetailService = exportDetailService;
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
            int CustomerLevel = Session.CurrentUser.Level == 0 ? 4 : Session.CurrentUser.Level.Value;
            for (int i = 1; i <= CustomerLevel; i++)
            {
                var ExportInfo = _exportDetailService.GetExportInfo(sDacCode, i)?.ResponseData;
                if (ExportInfo != null)
                {
                    ExportProductCode = ExportInfo.ProductName;
                    switch (i)
                    {
                        case 1:
                            txtOrderNumber.Text = ExportInfo.OrderNumber;
                            txtCustomerName.Text = ExportInfo.CustomerName;
                            txtExportDate.Text = ExportInfo.CreatedDate.Value.ToString("dd/MM/yyyy");
                            grExport.Visible = Session.CurrentUser.Level == 0 || Session.CurrentUser.Level == i;
                            break;
                        case 2:
                            txtOrderNumber1.Text = ExportInfo.OrderNumber;
                            txtCustomerName1.Text = ExportInfo.CustomerName;
                            txtExportDate1.Text = ExportInfo.CreatedDate.Value.ToString("dd/MM/yyyy");
                            grExport1.Visible = Session.CurrentUser.Level == 0 || Session.CurrentUser.Level == i;
                            break;
                        case 3:
                            txtOrderNumber2.Text = ExportInfo.OrderNumber;
                            txtCustomerName2.Text = ExportInfo.CustomerName;
                            txtExportDate2.Text = ExportInfo.CreatedDate.Value.ToString("dd/MM/yyyy");
                            grExport2.Visible = Session.CurrentUser.Level == 0 || Session.CurrentUser.Level == i;
                            break;
                        case 4:
                            txtOrderNumber3.Text = ExportInfo.OrderNumber;
                            txtCustomerName3.Text = ExportInfo.CustomerName;
                            txtExportDate3.Text = ExportInfo.CreatedDate.Value.ToString("dd/MM/yyyy");
                            grExport3.Visible = Session.CurrentUser.Level == 0 || Session.CurrentUser.Level == i;
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 1:
                            grExport.Visible = false;
                            break;
                        case 2:
                            grExport1.Visible = false;
                            break;
                        case 3:
                            grExport2.Visible = false;
                            break;
                        case 4:
                            grExport3.Visible = false;
                            break;
                    }
                }
            }
            var PackageInfo = _packageService.GetInfo(sDacCode)?.ResponseData;
            if (PackageInfo != null)
            {
                txtPackageCreateDate.Text = PackageInfo.CreatedDate.HasValue ? PackageInfo.CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                txtPackageCode.Text = PackageInfo.PackageCode;
                txtQuantity.Text = PackageInfo.Quantity.HasValue ? PackageInfo.Quantity.Value.ToString() : string.Empty;
                txtBatch.Text = PackageInfo.Batch;
                txtPersonPackage.Text = PackageInfo.PersonPackaged;
                txtPackageProductCode.Text = PackageInfo.ProductCode;
                txtPackageProductName.Text = PackageInfo.ProductName;
                grPackage.Visible = true;
            }
            else
            {
                grPackage.Visible = false;
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
    }
}
