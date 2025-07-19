using DAC.Core;
using DAC.Core.Common;
using DAC.Core.Security;
using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnyClone;

namespace PIPT
{
    public partial class frmDacDistributeToAgency : Form
    {
        #region Variables
        IDacExportProcessService _exportService;
        IDacProductService _productService;
        IDacExportDetailProcessService _detailService;
        IDacStockService _stockService;
        IDacCustomerService _customerService;
        ISecConfigService _configService;
        List<DacExportVM> LstExportInfo;
        List<DacProductVM> LstProducts;
        List<DacStock> LstStock;
        List<DacCustomerVM> LstAgency;
        DacExportVM originalObject;
        SecConfig AutoIncreaseCode;
        SecConfig UseStock;
        // --------------------
        #endregion
        #region Form's Events
        public frmDacDistributeToAgency(IDacExportProcessService exportService, IDacProductService productService, IDacExportDetailProcessService detailService, IDacStockService stockService, IDacCustomerService customerService, ISecConfigService configService)
        {
            InitializeComponent();
            _exportService = exportService;
            _productService = productService;
            _detailService = detailService;
            _stockService = stockService;
            _customerService = customerService;
            _configService = configService;
            _exportService.UserLevel = Session.CurrentUser.Level.Value;
        }
        private void frmDacDistributeToAgency_Load(object sender, EventArgs e)
        {
            AutoIncreaseCode = _configService.GetByCode("AutoIncreaseOrder").ResponseData;
            UseStock = _configService.GetByCode("UseStock").ResponseData;
            LoadData();
        }

        private void frmDacDistributeToAgency_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ucDataButtonAgency.DataMode == DataState.Insert)
            {
                if (CommonCore.FormClosing("Bạn chưa lưu đơn hàng xuất này. Bạn có muốn lưu lại?"))
                {
                    //Luu lai du lieu xong thoat form;
                    this.SaveData();
                }
            }
        }

        private void gvExportInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvExportInfo.FocusedRowHandle >= 0)
            {
                if (LstExportInfo[gvExportInfo.FocusedRowHandle].Id > 0)
                {
                    LstExportInfo[gvExportInfo.FocusedRowHandle] = _exportService.GetDetail(LstExportInfo[gvExportInfo.FocusedRowHandle].Id, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value).ResponseData;
                    originalObject = LstExportInfo[gvExportInfo.FocusedRowHandle].Clone();
                }
                else
                {
                    LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails = new List<DacExportDetailVM>();
                    originalObject = null;
                }
                if (gvExportInfo.FocusedRowHandle >= 0 && LstExportInfo != null && LstExportInfo.Count > gvExportInfo.FocusedRowHandle && LstExportInfo[gvExportInfo.FocusedRowHandle] != null)
                {
                    gcDetail.DataSource = LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails;
                    gcDetail.RefreshDataSource();
                    lblQuantity.Text = "Số sản phẩm đã thêm: " + LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count;
                }
                BindDataToControl(LstExportInfo[gvExportInfo.FocusedRowHandle]);
            }
            else
            {
                originalObject = null;
                gcDetail.DataSource = null;
                gcDetail.RefreshDataSource();
            }
        }

        private void txtDacCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (SelectedProduct())
                {
                    AddDetail();
                }
                else
                {
                    txtDacCode.Text = string.Empty;
                }
            }
        }

        private void txtFrSeri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (SelectedProduct())
                {
                    string DacCode = txtFrSeri.Text.Trim();
                    if (DacCode.Length >= 7)
                    {
                        string serial = CommonCore.GetSerialFromScanner(DacCode);
                        txtFrSeri.Text = serial;
                        txtToSeri.Focus();
                    }
                }
                else
                {
                    txtFrSeri.Text = string.Empty;
                }
            }
        }

        private void txtToSeri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (SelectedProduct())
                {
                    string DacCode = txtToSeri.Text.Trim();
                    if (DacCode.Length >= 7)
                    {
                        string serial = CommonCore.GetSerialFromScanner(DacCode);
                        txtToSeri.Text = serial;
                        GetRangSerialNumber(txtFrSeri.Text, txtToSeri.Text);
                        txtToSeri.Text = string.Empty;
                        txtFrSeri.Text = string.Empty;
                        txtFrSeri.Focus();
                    }
                }
                else
                {
                    txtFrSeri.Text = string.Empty;
                    txtToSeri.Text = string.Empty;
                }
            }
        }
        #endregion
        #region Function on form
        private void LoadData()
        {
            SetSelectControlDataSource();
            LstExportInfo = _exportService.GetAll().ResponseData ?? new List<DacExportVM>();
            gcExportInfo.DataSource = LstExportInfo;
            if (LstExportInfo != null && LstExportInfo.Any())
            {
                gvExportInfo.FocusedRowHandle = 0;
            }
            EnableControls(false);
            if (gvExportInfo.FocusedRowHandle <= 0)
            {
                gvExportInfo_FocusedRowChanged(ucDataButtonAgency, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
            }
            lblStock.Visible = UseStock != null && UseStock.Value == "true";
            lueDacStock.Visible = UseStock != null && UseStock.Value == "true";
        }

        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelDistributeToAgency.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonAgency.DataMode == DataState.Edit)
            {
                txtOrderNumber.Enabled = false;
            }
        }

        private bool ValidateData()
        {
            if (gvExportInfo.FocusedRowHandle < 0 || LstExportInfo[gvExportInfo.FocusedRowHandle] == null)
            {
                MessageBox.Show("Chưa chọn dòng dữ liệu cần xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gvExportInfo.FocusedRowHandle = 0;
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
            {
                MessageBox.Show("Chưa có số lệnh xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOrderNumber.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng chỉ định!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return false;
            }
            try
            {
                if (int.Parse(txtQuantity.Text) <= 0)
                {
                    MessageBox.Show("Số lượng chỉ định phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantity.Focus();
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Số lượng chỉ định không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return false;
            }
            if (LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails == null
                || LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count != int.Parse(txtQuantity.Text))
            {
                MessageBox.Show("Số lượng mã quét vào không khớp với số lượng sản phẩm chỉ định trong phiếu này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return false;
            }
            return true;
        }

        private void SaveDelegate()
        {
            SaveData();
        }

        private bool SaveData()
        {
            if (ValidateData())
            {
                DacExportVM exportInfoVM = LstExportInfo[gvExportInfo.FocusedRowHandle];
                exportInfoVM = CreateSaveData(exportInfoVM);
                if (exportInfoVM != null && exportInfoVM.LstDetails != null)
                {
                    foreach (var detail in exportInfoVM.LstDetails)
                    {
                        var invalidProduct = _exportService.InvalidProductCode(detail.DacCode, detail.ProductCode, exportInfoVM.CustomerLevel.Value);
                        if (invalidProduct.ResponseData)
                        {
                            if (invalidProduct.ex != null)
                            {
                                MessageBox.Show("Có lỗi xảy ra khi kiểm tra tính hợp lệ của sản phẩm! " + invalidProduct.ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(invalidProduct.ErrorMessage))
                                {
                                    MessageBox.Show(invalidProduct.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            return false;
                        }
                    }
                    if (exportInfoVM.Id <= 0)
                    {
                        if (_exportService.GetByCode(exportInfoVM.OrderNumber, exportInfoVM.CustomerLevel.Value).ResponseData != null)
                        {
                            MessageBox.Show("Mã lệnh này đã được sử dụng! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var response = _exportService.Create(exportInfoVM);
                            exportInfoVM = response.ResponseData;
                            if (exportInfoVM != null && exportInfoVM.Id > 0)
                            {
                                CommonBO.Instance().TraceLogEvent("Save export to agency: " + txtOrderNumber.Text + " - " + lueProduct.EditValue + " - "
                                    + LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count, CommonBS.CurrentUser.LoginID);
                                MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ucDataButtonAgency.DataMode = DataState.View;
                                if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
                                {
                                    MessageBox.Show(response.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                LoadData();
                                gcExportInfo.Enabled = true;
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Lưu dữ liệu không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        exportInfoVM = _exportService.Edit(exportInfoVM).ResponseData;
                        if (exportInfoVM != null && exportInfoVM.Id > 0)
                        {
                            CommonBO.Instance().TraceLogEvent("Edit export to agency: " + txtOrderNumber.Text + " - " + lueProduct.EditValue + " - "
                                + LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count, CommonBS.CurrentUser.LoginID);
                            MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucDataButtonAgency.DataMode = DataState.View;
                            LoadData();
                            gcExportInfo.Enabled = true;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật dữ liệu không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        private DacExportVM CreateSaveData(DacExportVM exportInfoVM)
        {
            exportInfoVM.Id = ucDataButtonAgency.DataMode == DataState.Insert ? 0 : exportInfoVM.Id;
            exportInfoVM.OrderNumber = ucDataButtonAgency.DataMode == DataState.Edit ? exportInfoVM.OrderNumber : txtOrderNumber.Text;
            exportInfoVM.CustomerCode = lueAgency.EditValue.ToString();
            exportInfoVM.Quantity = int.Parse(txtQuantity.Text);
            exportInfoVM.Description = txtDescription.Text;
            exportInfoVM.Active = true;
            exportInfoVM.CreatedDate = DateTime.Now;
            exportInfoVM.StockCode = lueDacStock.EditValue?.ToString();
            return exportInfoVM;
        }

        private void BindDataToControl(DacExportVM exportInfoVM)
        {
            txtOrderNumber.Text = exportInfoVM.OrderNumber;
            txtQuantity.Text = exportInfoVM.Quantity?.ToString();
            dtpCreatedDate.Value = exportInfoVM.CreatedDate.HasValue ? exportInfoVM.CreatedDate.Value : DateTime.Now;
            txtDescription.Text = exportInfoVM.Description;
            lueDacStock.EditValue = exportInfoVM.StockCode;
            lueAgency.EditValue = exportInfoVM.CustomerCode;
            SetProductName();
        }

        private void GetRangSerialNumber(string frSerie, string toSerie)
        {
            try
            {
                string sPreSeriValue = ConfigurationManager.AppSettings["PreSeri"].ToString();
                string[] sPreSeris = sPreSeriValue.Split(',');
                string sPreSeri = string.Empty;
                if (sPreSeriValue.Length > 0)
                {
                    foreach (string PreSeri in sPreSeris)
                    {
                        if (frSerie.Contains(PreSeri.Trim()))
                        {
                            sPreSeri = PreSeri.Trim();
                            break;
                        }
                    }
                }
                long iFrSerie = 0;
                long iToSerie = 0;
                if (sPreSeri.Length == 0)
                {
                    iFrSerie = Convert.ToInt64(frSerie);
                    iToSerie = Convert.ToInt64(toSerie);
                }
                else
                {
                    sPreSeri = frSerie.Substring(0, sPreSeri.Length);
                    iFrSerie = Convert.ToInt64(frSerie.Substring(sPreSeri.Length, frSerie.Length - sPreSeri.Length));
                    iToSerie = Convert.ToInt64(toSerie.Substring(sPreSeri.Length, toSerie.Length - sPreSeri.Length));
                }
                int Quantity = 0;
                string QuantityStr = txtQuantity.Text;
                try
                {
                    Quantity = int.Parse(QuantityStr);
                }
                catch
                {
                }
                if (iToSerie >= iFrSerie)
                {
                    for (long i = iFrSerie; i <= iToSerie; i++)
                    {
                        var NewDetail = new DacExportDetailVM();
                        NewDetail.DacCode = String.Format("{0}{1:" + CommonBO.GetSecConfig("SeriLength").Pattern + "}", sPreSeri, i);
                        NewDetail.ProductCode = lueProduct.EditValue.ToString();
                        NewDetail.ProductName = lueProduct.Text;
                        if (_detailService.GetByDacCode(NewDetail.DacCode, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value).ResponseData != null)
                        {
                            MessageBox.Show("Mã QR đã được xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        else if (!_detailService.Exportable(NewDetail.DacCode, Session.CurrentUser.CustomerCode, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value).ResponseData)
                        {
                            MessageBox.Show("Mã QR chưa được xuất đến, không thể xuất đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        else
                        {
                            var invalidProduct = _exportService.InvalidProductCode(NewDetail.DacCode, NewDetail.ProductCode, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value);
                            if (invalidProduct.ResponseData)
                            {
                                if (invalidProduct.ex != null)
                                {
                                    MessageBox.Show("Có lỗi xảy ra khi kiểm tra tính hợp lệ của sản phẩm! " + invalidProduct.ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (!string.IsNullOrWhiteSpace(invalidProduct.ErrorMessage))
                                    {
                                        MessageBox.Show(invalidProduct.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                            }
                            else if (LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == NewDetail.DacCode) != null)
                            {
                                MessageBox.Show("Mã QR đã được quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else if (ucDataButtonAgency.DataMode != DataState.View && Quantity > 0 && LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count == Quantity)
                            {
                                MessageBox.Show("Đã đạt đến số lượng chỉ định, bạn không thể quét thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else
                            {
                                LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Add(NewDetail);
                            }
                        }
                    }
                    gcDetail.RefreshDataSource();
                    lblQuantity.Text = "Số sản phẩm đã thêm: " + LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDetail()
        {
            string DacCode = txtDacCode.Text.Trim();
            if (DacCode.Length >= 7)
            {
                int Quantity = 0;
                string QuantityStr = txtQuantity.Text;
                try
                {
                    Quantity = int.Parse(QuantityStr);
                }
                catch
                {
                }
                string serial = CommonCore.GetSerialFromScanner(DacCode);
                try
                {
                    int.Parse(serial);
                    var NewDetail = new DacExportDetailVM();
                    NewDetail.DacCode = serial;
                    NewDetail.ProductCode = lueProduct.EditValue.ToString();
                    NewDetail.ProductName = lueProduct.Text;
                    if (_detailService.GetByDacCode(NewDetail.DacCode, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value).ResponseData != null)
                    {
                        MessageBox.Show("Mã QR đã được xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!_detailService.Exportable(NewDetail.DacCode, Session.CurrentUser.CustomerCode, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value).ResponseData)
                    {
                        MessageBox.Show("Mã QR chưa được xuất đến, không thể xuất đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var invalidProduct = _exportService.InvalidProductCode(NewDetail.DacCode, NewDetail.ProductCode, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value);
                        if (invalidProduct.ResponseData)
                        {
                            if (invalidProduct.ex != null)
                            {
                                MessageBox.Show("Có lỗi xảy ra khi kiểm tra tính hợp lệ của sản phẩm! " + invalidProduct.ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(invalidProduct.ErrorMessage))
                                {
                                    MessageBox.Show(invalidProduct.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else if (LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == NewDetail.DacCode) != null)
                        {
                            MessageBox.Show("Mã QR đã được quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ucDataButtonAgency.DataMode != DataState.View && Quantity > 0 && LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count == Quantity)
                        {
                            MessageBox.Show("Đã đạt đến số lượng chỉ định, bạn không thể quét thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Add(NewDetail);
                            gcDetail.RefreshDataSource();
                            lblQuantity.Text = "Số sản phẩm đã thêm: " + LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count;
                        }
                    }
                    txtDacCode.Text = string.Empty;
                }
                catch
                {
                    MessageBox.Show("Tem không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDacCode.Focus();
                }
            }
        }

        private bool SelectedProduct()
        {
            if (lueProduct.EditValue == null || lueProduct.EditValue.ToString() == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void SetProductName()
        {
            if (LstExportInfo != null && gvExportInfo.FocusedRowHandle >= 0 && LstExportInfo.Count > gvExportInfo.FocusedRowHandle && LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails != null)
            {
                var LstProductName = LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Select(x => x.ProductName)?.Distinct()?.ToList();
                lblProduct.Text = LstProductName != null ? string.Join(",", LstProductName) : null;
            }
        }

        private void SetSelectControlDataSource()
        {
            LstStock = _stockService.GetAll().ResponseData;
            lueDacStock.Properties.DataSource = LstStock;
            lueDacStock.Properties.ValueMember = "Code";
            lueDacStock.Properties.DisplayMember = "Name";
            LstAgency = _customerService.GetAll().ResponseData;
            if (!Session.CurrentUser.isAdmin.HasValue || !Session.CurrentUser.isAdmin.Value)
            {
                LstStock = LstStock?.Where(x => x.AgencyCode == Session.CurrentUser.CustomerCode)?.ToList();
                LstAgency = LstAgency?.Where(x => x.DependCode == Session.CurrentUser.CustomerCode)?.ToList();
            }
            lueAgency.Properties.DataSource = LstAgency;
            lueAgency.Properties.ValueMember = "Code";
            lueAgency.Properties.DisplayMember = "Name";
            LstProducts = _productService.GetAll().ResponseData.Where(x => x.Active.HasValue && x.Active.Value)?.ToList();
            lueProduct.Properties.DataSource = LstProducts;
            lueProduct.Properties.ValueMember = "Code";
            lueProduct.Properties.DisplayMember = "Name";
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonAgency_InsertHandler()
        {
            DacExportVM exportInfo = new DacExportVM();
            LstExportInfo.Add(exportInfo);
            gcExportInfo.RefreshDataSource();
            gvExportInfo.FocusedRowHandle = LstExportInfo.IndexOf(LstExportInfo.Last());
            EnableControls(true);
            gcExportInfo.Enabled = false;
        }

        private void ucDataButtonAgency_SaveHandler()
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveDelegate;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonAgency_EditHandler()
        {
            if (LstExportInfo != null && LstExportInfo.Any() && gvExportInfo.FocusedRowHandle >= 0)
            {
                //chkAutoPrintStamp.Enabled = false;
                gcExportInfo.Enabled = false;
                EnableControls(true);
            }
        }

        private void ucDataButtonAgency_DeleteHandler()
        {
            if (gvExportInfo.FocusedRowHandle >= 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa phiếu xuất đã chọn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var result = _exportService.Delete(LstExportInfo[gvExportInfo.FocusedRowHandle].Id, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value).ResponseData;
                    if (result)
                    {
                        StringBuilder sContent = new StringBuilder();
                        sContent.Append("Xóa phiếu xuất " + LstExportInfo[gvExportInfo.FocusedRowHandle].OrderNumber);
                        sContent.Append("-");
                        sContent.Append(LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerCode);
                        sContent.Append("-");
                        sContent.Append(LstExportInfo[gvExportInfo.FocusedRowHandle].CreatedDate.Value.ToString("dd/MM/yyyy"));
                        if (LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails != null && LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Any())
                        {
                            sContent.Append(". Xóa các mã: ");
                            foreach (var detail in LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails)
                            {
                                sContent.Append(detail.DacCode);
                                sContent.Append(", ");
                            }
                        }
                        // Lưu nhật ký
                        CommonBO.Instance().TraceLogEvent(sContent.ToString(), CommonBS.CurrentUser.LoginID);
                        MessageBox.Show("Xóa phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ucDataButtonAgency_CancelHandler()
        {
            ucDataButtonAgency.DataMode = DataState.View;
            if (gvExportInfo.FocusedRowHandle >= 0 && originalObject != null)
            {
                LstExportInfo[gvExportInfo.FocusedRowHandle] = originalObject.Clone();
            }
            LoadData();
            gcExportInfo.Enabled = true;
            gcExportInfo.RefreshDataSource();
        }

        private void ucDataButtonAgency_CloseHandler()
        {
            if (ucDataButtonAgency.DataMode == DataState.Insert || ucDataButtonAgency.DataMode == DataState.Edit)
            {
                if (CommonCore.FormClosing("Bạn chưa lưu phiếu xuất này. Bạn có muốn lưu lại?"))
                {
                    if (SaveData())
                    {
                        Close();
                    }
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnUpdateDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvExportInfo.FocusedRowHandle >= 0 && LstExportInfo[gvExportInfo.FocusedRowHandle] != null && LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails != null)
                {
                    if (MessageBox.Show("Lưu ý rằng việc thêm các mã QR có thể sẽ cập nhật lại số lượng chỉ định trong phiếu xuất này. " +
                        "Bạn có xác nhận muốn tiếp tục?", "Xác nhận cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var LstNewDetail = LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Where(x => x.Id <= 0)?.ToList();
                        if (LstNewDetail != null && LstNewDetail.Any())
                        {
                            StringBuilder sContent = new StringBuilder();
                            sContent.Append("Thêm các mã: ");
                            for (int i = 0; i < LstNewDetail.Count; i++)
                            {
                                LstNewDetail[i].ExportId = LstExportInfo[gvExportInfo.FocusedRowHandle].Id;
                            }
                            if (_detailService.AddRange(LstNewDetail, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value).ResponseData)
                            {
                                lblQuantity.Text = "Số sản phẩm đã thêm: " + LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count;
                                sContent.Append(string.Join(",", LstNewDetail.Select(x => x.DacCode)?.ToList()));
                                if (LstExportInfo[gvExportInfo.FocusedRowHandle] != null)
                                {
                                    var EditedPackage = _exportService.GetDetail(LstExportInfo[gvExportInfo.FocusedRowHandle].Id, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value).ResponseData;
                                    if (EditedPackage != null)
                                    {
                                        LstExportInfo[gvExportInfo.FocusedRowHandle].Quantity = EditedPackage.RealityQuantity;
                                        txtQuantity.Text = LstExportInfo[gvExportInfo.FocusedRowHandle].Quantity.ToString();
                                        gcExportInfo.RefreshDataSource();

                                    }
                                }
                                sContent.Append("vào phiếu xuất " + LstExportInfo[gvExportInfo.FocusedRowHandle].Id);
                                CommonBO.Instance().TraceLogEvent(sContent.ToString(), CommonBS.CurrentUser.LoginID);
                                MessageBox.Show("Thêm thành công " + LstNewDetail.Count + " mã đã quét.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                gcDetail.RefreshDataSource();
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi đã xảy ra khi thêm các mã QRCode.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi đã xảy ra khi thêm các mã QRCode: " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetailDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int[] SelectedIndex = gvDetail.GetSelectedRows();
                if (gvExportInfo.FocusedRowHandle >= 0 && SelectedIndex != null && SelectedIndex.Length > 0)
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa các mã QR code đã chọn? Lưu ý rằng việc xóa các mã QR có thể sẽ cập nhật lại số lượng chỉ định trong phiếu xuất này. " +
                        "Bạn có xác nhận muốn tiếp tục?", "Xác nhận xóa mã", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (SelectedIndex.Length == LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count)
                        {
                            if (MessageBox.Show("Nếu bạn xóa tất cả mã QR trong phiếu xuất, phiếu này sẽ bị xóa. Bạn có chắc chắn muốn xóa?", "Xác nhận xóa mã"
                                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                ucDataButtonAgency_DeleteHandler();
                            }
                        }
                        else
                        {
                            StringBuilder sContent = new StringBuilder();
                            sContent.Append("Xóa mã: ");
                            var LstDelete = LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails
                                .Where(x => SelectedIndex.Contains(LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.IndexOf(x)))?.Select(x => x.DacCode)?.ToList();
                            int ExceptCount = 0;
                            if (LstDelete != null)
                            {
                                var result = _detailService.DeleteByDacCode(LstDelete, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value);
                                if (result.ResponseData)
                                {
                                    if (!string.IsNullOrWhiteSpace(result.ErrorMessage))
                                    {
                                        string[] arrExported = result.ErrorMessage.Split(',');
                                        if (arrExported.Length > 0)
                                        {
                                            foreach (var item in arrExported)
                                            {
                                                var exported = LstDelete.FirstOrDefault(x => x == item);
                                                if (exported != null)
                                                {
                                                    LstDelete.Remove(exported);
                                                }
                                            }
                                        }
                                    }
                                    sContent.Append(string.Join(",", LstDelete));
                                    for (int i = 0; i < LstDelete.Count; i++)
                                    {
                                        var RemoveDetail = LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == LstDelete[i]);
                                        if (RemoveDetail != null)
                                        {
                                            LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Remove(RemoveDetail);
                                        }
                                    }
                                    for (int i = 0; i < SelectedIndex.Length; i++)
                                    {
                                        gvDetail.UnselectRow(SelectedIndex[i]);
                                    }
                                    lblQuantity.Text = "Số sản phẩm đã thêm: " + LstExportInfo[gvExportInfo.FocusedRowHandle].LstDetails.Count;
                                    if (LstExportInfo[gvExportInfo.FocusedRowHandle] != null)
                                    {
                                        var EditedInfo = _exportService.GetDetail(LstExportInfo[gvExportInfo.FocusedRowHandle].Id, LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel.Value).ResponseData;
                                        if (EditedInfo != null)
                                        {
                                            LstExportInfo[gvExportInfo.FocusedRowHandle].Quantity = EditedInfo.RealityQuantity;
                                            txtQuantity.Text = LstExportInfo[gvExportInfo.FocusedRowHandle].Quantity.ToString();
                                            gcExportInfo.RefreshDataSource();
                                        }
                                    }
                                    if (!string.IsNullOrWhiteSpace(result.ErrorMessage))
                                    {
                                        string[] arrExcept = result.ErrorMessage.Split(',');
                                        if (arrExcept != null)
                                        {
                                            ExceptCount = arrExcept.Length;
                                        }
                                        MessageBox.Show("Không thể xóa các mã " + result.ErrorMessage + " do khách hàng đã xuất! Các mã còn lại trong danh sách đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi đã xảy ra khi xóa các mã QRCode.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            gcDetail.RefreshDataSource();
                            MessageBox.Show("Xóa thành công " + (SelectedIndex.Length - ExceptCount) + "/" + SelectedIndex.Length + " mã đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Lưu nhật ký
                            CommonBO.Instance().TraceLogEvent(sContent.ToString(), CommonBS.CurrentUser.LoginID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (SelectedProduct())
            {
                AddDetail();
            }
            else
            {
                txtDacCode.Text = string.Empty;
            }
        }

        private void btnAddSerialCode_Click(object sender, EventArgs e)
        {
            if (SelectedProduct())
            {
                string DacCode = txtToSeri.Text.Trim();
                if (DacCode.Length >= 7)
                {
                    string serial = CommonCore.GetSerialFromScanner(DacCode);
                    txtToSeri.Text = serial;
                    GetRangSerialNumber(txtFrSeri.Text, txtToSeri.Text);
                    txtToSeri.Text = string.Empty;
                    txtFrSeri.Text = string.Empty;
                    txtFrSeri.Focus();
                }
            }
            else
            {
                txtToSeri.Text = string.Empty;
                txtFrSeri.Text = string.Empty;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetSelectControlDataSource();
        }

        private void ucDataButtonAgency_ExcelHandler()
        {

        }

        private void ucDataButtonAgency_PrintHandler()
        {

        }
        #endregion

        private void lueAgency_EditValueChanged(object sender, EventArgs e)
        {
            if (ucDataButtonAgency.DataMode == DataState.Insert)
            {
                if (lueAgency.EditValue != null && LstExportInfo != null && gvExportInfo.FocusedRowHandle >= 0 && LstExportInfo.Count > gvExportInfo.FocusedRowHandle && LstAgency != null)
                {
                    var selectedCustomer = LstAgency.FirstOrDefault(x => x.Code == lueAgency.EditValue.ToString());
                    if (selectedCustomer != null)
                    {
                        LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel = selectedCustomer.Level;
                        if (AutoIncreaseCode != null && AutoIncreaseCode.Value == "true" && ucDataButtonAgency.DataMode == DataState.Insert)
                        {
                            LstExportInfo[gvExportInfo.FocusedRowHandle].OrderNumber = _exportService.GenerateNewCode(selectedCustomer.Level).ResponseData;
                            txtOrderNumber.Text = LstExportInfo[gvExportInfo.FocusedRowHandle].OrderNumber;
                        }
                    }
                }
            }
            else if (ucDataButtonAgency.DataMode == DataState.Edit)
            {
                if (lueAgency.EditValue == null || LstAgency == null || LstAgency.FirstOrDefault(x => x.Code == lueAgency.EditValue.ToString()).Level != LstExportInfo[gvExportInfo.FocusedRowHandle].CustomerLevel)
                {
                    MessageBox.Show("Khách hàng không cùng cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (originalObject != null && !string.IsNullOrWhiteSpace(originalObject.CustomerCode))
                    {
                        lueAgency.EditValue = originalObject.CustomerCode;
                    }
                }
            }
        }
    }
}
