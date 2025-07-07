using DAC.Core.Services.Interfaces;
using DAC.DAL.ViewModels;
using PIPT.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmReportPackage : Form
    {
        #region Variables
        IDacPackageService _packageService;
        List<DacPackageVM> LstInfo;
        #endregion
        public frmReportPackage(IDacPackageService packageService)
        {
            InitializeComponent();
            _packageService = packageService;
        }

        private void frmReportPackage_Load(object sender, EventArgs e)
        {
            dtpFrom.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.EditValue = DateTime.Now;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Excel 2007-2016(*.xlsx)|*.xlsx";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //gridViewAgency.ExportToXlsx(@"\khachhang.xlsx");
                gvReport.ExportToXlsx(fileDialog.FileName);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (dtpFrom.EditValue != null && dtpTo.EditValue != null && DateTime.Parse(dtpFrom.EditValue.ToString()) > DateTime.Parse(dtpTo.EditValue.ToString()))
            {
                MessageBox.Show("Khoảng thời gian không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFrom.Focus();
                return;
            }
            LstInfo = _packageService.GetAll()?.ResponseData;
            if (LstInfo != null)
            {
                LstInfo = LstInfo.Where(x => (dtpFrom.EditValue == null || x.CreatedDate.HasValue && x.CreatedDate.Value >= DateTime.Parse(dtpFrom.EditValue.ToString()).Date)
                                            && (dtpTo.EditValue == null || x.CreatedDate.HasValue && x.CreatedDate.Value <= DateTime.Parse(dtpTo.EditValue.ToString()).AddDays(1).Date)
                                            && (string.IsNullOrWhiteSpace(txtPackageCode.Text)
                                                || (!string.IsNullOrWhiteSpace(x.PackageCode) && x.PackageCode.ToLower().Contains(txtPackageCode.Text.Trim().ToLower())))
                                            && (string.IsNullOrWhiteSpace(txtProductCode.Text)
                                                || (!string.IsNullOrWhiteSpace(x.ProductCode) && x.ProductCode.ToLower().Contains(txtProductCode.Text.Trim().ToLower()))
                                                || (!string.IsNullOrWhiteSpace(x.ProductName) && x.ProductName.ToLower().Contains(txtProductCode.Text.Trim().ToLower()))))?.ToList();
            }
            gcReport.DataSource = LstInfo;
            gcReport.RefreshDataSource();
        }

        private void gvReport_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0 && LstInfo != null && LstInfo.Count > e.RowHandle)
            {
                frmPackageDetailReport frmDetail = new frmPackageDetailReport(_packageService);
                frmDetail.packageInfo = LstInfo[e.RowHandle];
                frmDetail.ShowDialog();
            }
        }
    }
}
