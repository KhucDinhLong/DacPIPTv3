using DAC.Core.Services.Interfaces;
using DAC.DAL.ViewModels;
using PIPT.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmReportExportInfo : Form
    {
        #region Variables
        IDacExportService _exportService;
        List<DacExportVM> LstInfo;
        #endregion
        public frmReportExportInfo(IDacExportService exportService)
        {
            InitializeComponent();
            _exportService = exportService;
        }

        private void frmReportExportInfo_Load(object sender, EventArgs e)
        {
            dtpFrom.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.EditValue = DateTime.Now;
        }

        private void simpleButtonExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Excel 2007-2016(*.xlsx)|*.xlsx";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
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
            LstInfo = _exportService.GetAll()?.ResponseData;
            if (LstInfo != null)
            {
                for (int i = 0; i < LstInfo.Count; i++)
                {
                    LstInfo[i] = _exportService.GetDetail(LstInfo[i].Id)?.ResponseData;
                }
                LstInfo = LstInfo.Where(x => (dtpFrom.EditValue == null || x.CreatedDate.HasValue && x.CreatedDate.Value >= DateTime.Parse(dtpFrom.EditValue.ToString()).Date)
                                            && (dtpTo.EditValue == null || x.CreatedDate.HasValue && x.CreatedDate.Value <= DateTime.Parse(dtpTo.EditValue.ToString()).AddDays(1).Date)
                                            && (string.IsNullOrWhiteSpace(txtCustomerCode.Text)
                                                || (!string.IsNullOrWhiteSpace(x.CustomerCode) && x.CustomerCode.ToLower().Contains(txtCustomerCode.Text.Trim().ToLower()))
                                                || (!string.IsNullOrWhiteSpace(x.AgencyName) && x.AgencyName.ToLower().Contains(txtCustomerCode.Text.Trim().ToLower()))))?.ToList();
                if (!string.IsNullOrWhiteSpace(txtProductCode.Text))
                {
                    LstInfo = LstInfo.Where(x => (string.IsNullOrWhiteSpace(txtProductCode.Text)
                                                || (x.LstDetails != null && x.LstDetails.FirstOrDefault(y => !string.IsNullOrWhiteSpace(y.ProductCode) && y.ProductCode.ToLower().Contains(txtProductCode.Text.Trim().ToLower())) != null)
                                                || (x.LstDetails != null && x.LstDetails.FirstOrDefault(y => !string.IsNullOrWhiteSpace(y.ProductName) && y.ProductName.ToLower().Contains(txtProductCode.Text.Trim().ToLower())) != null)))?.ToList();
                    for (int i = 0; i < LstInfo.Count; i++)
                    {
                        if (LstInfo[i] != null)
                        {
                            LstInfo[i].LstDetails = LstInfo[i].LstDetails?.Where(x => !string.IsNullOrWhiteSpace(x.ProductCode) && (x.ProductCode.ToLower().Contains(txtProductCode.Text.Trim().ToLower())
                            || x.ProductName.ToLower().Contains(txtProductCode.Text.Trim().ToLower())))?.ToList();
                            LstInfo[i].Quantity = LstInfo[i].LstDetails != null ? LstInfo[i].LstDetails.Count : 0;
                            LstInfo[i].ProductName = LstInfo[i].LstDetails != null ? string.Join(",", LstInfo[i].LstDetails.Select(x => x.ProductName).Distinct()) : string.Empty;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < LstInfo.Count; i++)
                    {
                        LstInfo[i] = _exportService.GetDetail(LstInfo[i].Id)?.ResponseData;
                    }
                }
            }
            gcReport.DataSource = LstInfo;
            gcReport.RefreshDataSource();
        }

        private void gvReport_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0 && LstInfo != null && LstInfo.Count > e.RowHandle)
            {
                frmExportToAgencyDetailReport frmDetail = new frmExportToAgencyDetailReport();
                frmDetail.exportInfo = LstInfo[e.RowHandle];
                frmDetail.ShowDialog();
            }
        }
    }
}
