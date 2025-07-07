using DAC.Core;
using DAC.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacDeleteCode : Form
    {
        #region Variables
        IDacDistributeToAgencyService _exportToAgencyService;
        IDacDistributeToAgencyDetailsService _exportToAgencyDetailService;
        IDacDistributeToStoreService _exportToStoreService;
        IDacDistributeToStoreDetailsService _exportToStoreDetailService;
        IDacPackageService _packageService;
        IDacPackageDetailService _packageDetailService;
        IDacInsertToWarehouseService _importWarehouseService;
        IDacInsertToWarehouseDetailsService _importWarehouseDetailService;
        List<DacCodeItem> LstDacCode;
        // --------------------
        #endregion
        #region Form's Events
        public frmDacDeleteCode(IDacDistributeToAgencyService exportToAgencyService, IDacDistributeToAgencyDetailsService exportToAgencyDetailService
            , IDacDistributeToStoreService exportToStoreService, IDacDistributeToStoreDetailsService exportToStoreDetailService
            , IDacPackageService packageService, IDacPackageDetailService packageDetailService
            , IDacInsertToWarehouseService importWarehouseService, IDacInsertToWarehouseDetailsService importWarehouseDetailService)
        {
            InitializeComponent();
            _exportToAgencyService = exportToAgencyService;
            _exportToAgencyDetailService = exportToAgencyDetailService;
            _exportToStoreService = exportToStoreService;
            _exportToStoreDetailService = exportToStoreDetailService;
            _packageService = packageService;
            _packageDetailService = packageDetailService;
            _importWarehouseService = importWarehouseService;
            _importWarehouseDetailService = importWarehouseDetailService;
            LstDacCode = new List<DacCodeItem>();
            gcDacCode.DataSource = LstDacCode;
        }
        #endregion
        #region Function on form
        private void DeleteExportToAgency()
        {
            if (LstDacCode != null && LstDacCode.Any())
            {
                foreach (var item in LstDacCode)
                {
                    _exportToAgencyDetailService.DeleteByDacCode(item.DacCode);
                }
            }
        }
        private void DeleteExportToStore()
        {
            if (LstDacCode != null && LstDacCode.Any())
            {
                foreach (var item in LstDacCode)
                {
                    _exportToStoreDetailService.DeleteByDacCode(item.DacCode);
                }
            }
        }
        private void DeleteImportWarehouse()
        {
            if (LstDacCode != null && LstDacCode.Any())
            {
                foreach (var item in LstDacCode)
                {
                    _importWarehouseDetailService.DeleteByDacCode(item.DacCode);
                }
            }
        }
        private void DeletePakaged()
        {
            if (LstDacCode != null && LstDacCode.Any())
            {
                foreach (var item in LstDacCode)
                {
                    _packageDetailService.DeleteByDacCode(item.DacCode);
                }
            }
        }
        #endregion
        #region Buttons' Event
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            this.GetDacCode();
        }

        private void buttonDetailDelete_Click(object sender, EventArgs e)
        {
            if (LstDacCode == null || !LstDacCode.Any())
            {
                MessageBox.Show("Không có danh sách các mã QR cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chkDeleteProductFromAgency.Checked && !chkDeleteProductFromPackage.Checked && !chkDeleteProductFromStore.Checked && !chkDeleteProductFromWarehouse.Checked)
            {
                MessageBox.Show("Bạn chưa chọn danh sách cần xóa các mã QR!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa các mã QRCode trong danh sách? Lưu ý rằng việc xóa mã có thể thay đổi số lượng chỉ thị trong danh sách.", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (chkDeleteProductFromAgency.Checked)
                {
                    DeleteExportToAgency();
                }
                if (chkDeleteProductFromStore.Checked)
                {
                    DeleteExportToStore();
                }
                if (chkDeleteProductFromWarehouse.Checked)
                {
                    DeleteImportWarehouse();
                }
                if (chkDeleteProductFromPackage.Checked)
                {
                    DeletePakaged();
                }
                LstDacCode.Clear();
                MessageBox.Show("Xóa các mã QR thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gcDacCode.RefreshDataSource();
            }
        }

        private void textBoxDacCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.GetDacCode();
            }
        }

        private void GetDacCode()
        {
            string InputCode = txtDacCode.Text.Trim();
            if (InputCode.Length >= 7)
            {
                string serial = CommonCore.GetSerialFromScanner(InputCode);
                string PackageType = serial.Substring(0, 3);
                switch (PackageType)
                {
                    case "PKG":
                        break;
                    default:
                        if (LstDacCode != null && LstDacCode.FirstOrDefault(x => x.DacCode == InputCode) == null)
                        {
                            LstDacCode.Add(new DacCodeItem { DacCode = InputCode });
                            gcDacCode.RefreshDataSource();
                            txtDacCode.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Mã QR này đã được quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }
        #endregion
    }

    public class DacCodeItem
    {
        public string DacCode { get; set; }
    }
}
