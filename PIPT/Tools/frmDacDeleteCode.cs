using DAC.Core;
using DAC.Core.Common;
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
        IDacExportDetailProcessService _exportDetailService;
        IDacPackageDetailService _packageDetailService;
        IDacInsertToWarehouseDetailsService _importDetailService;
        List<DacCodeItem> LstDacCode;
        // --------------------
        #endregion
        #region Form's Events
        public frmDacDeleteCode(IDacExportDetailProcessService exportToAgencyDetailService, IDacPackageDetailService packageDetailService, IDacInsertToWarehouseDetailsService importDetailService)
        {
            InitializeComponent();
            _exportDetailService = exportToAgencyDetailService;
            _packageDetailService = packageDetailService;
            _importDetailService = importDetailService;
            LstDacCode = new List<DacCodeItem>();
            gcDacCode.DataSource = LstDacCode;
        }
        #endregion
        #region Function on form
        private List<string> DeleteExport()
        {
            var LstDeleted = new List<string>();
            if (LstDacCode != null && LstDacCode.Any())
            {
                foreach (var item in LstDacCode)
                {
                    var response = _exportDetailService.DeleteByDacCode(item.DacCode, Session.CurrentUser.Level.Value);
                    if (response.ErrorMessage == "exported")
                    {
                        MessageBox.Show("Không thể xóa mã " + item.DacCode + " do khách hàng đã xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LstDeleted.Add(item.DacCode);
                    }
                }
            }
            return LstDeleted;
        }
        
        private void DeleteImportWarehouse()
        {
            if (LstDacCode != null && LstDacCode.Any())
            {
                foreach (var item in LstDacCode)
                {
                    _importDetailService.DeleteByDacCode(item.DacCode);
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
            if (Session.CurrentUser.isAdmin.HasValue && Session.CurrentUser.isAdmin.Value)
            {
                MessageBox.Show("Quản trị viên không thể xóa dữ liệu trong các danh sách được tạo bởi người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LstDacCode == null || !LstDacCode.Any())
            {
                MessageBox.Show("Không có danh sách các mã QR cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chkDeleteProductFromAgency.Checked && !chkDeleteProductFromPackage.Checked && !chkDeleteProductFromWarehouse.Checked)
            {
                MessageBox.Show("Bạn chưa chọn loại danh sách cần xóa các mã QR!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa các mã QRCode trong danh sách? Lưu ý rằng việc xóa mã có thể thay đổi số lượng chỉ thị trong danh sách" +
                ". Trong trường hợp tất cả mã QR trong danh sách đã bị xóa, thông tin chung về danh sách cũng sẽ bị xóa", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                List<string> LstDeletedExport = null;
                if (chkDeleteProductFromAgency.Checked)
                {
                    LstDeletedExport = DeleteExport();
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
                if (LstDeletedExport != null && LstDeletedExport.Any())
                {
                    MessageBox.Show("Xóa các mã QR: " + string.Join(", ", LstDeletedExport) + " thành công khỏi các đơn hàng đã xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
