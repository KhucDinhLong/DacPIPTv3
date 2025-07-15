using AnyClone;
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

namespace PIPT
{
    public partial class frmDacDistributeToStore : Form
    {
        #region Variables
        IDacExport2Service _exportService;
        IDacProductService _productService;
        IDacDistributeToStoreDetailsService _detailService;
        IDacStockService _stockService;
        IDacStoreService _storeService;
        ISecConfigService _configService;
        List<DacExport2VM> LstExportInfo;
        List<DacProductVM> LstProducts;
        List<DacStock> LstStock;
        List<DacStoreVM> LstStore;
        DacExport2VM originalObject;
        SecConfig AutoIncreaseCode;
        // --------------------
        #endregion
        #region Form's Events
        public frmDacDistributeToStore(IDacExport2Service exportService, IDacProductService productService, IDacDistributeToStoreDetailsService detailService, IDacStockService stockService, IDacStoreService storeService, ISecConfigService configService)
        {
            InitializeComponent();
            _exportService = exportService;
            _productService = productService;
            _detailService = detailService;
            _stockService = stockService;
            _storeService = storeService;
            _configService = configService;
        }
        private void frmDacDistributeToStore_Load(object sender, EventArgs e)
        {
            AutoIncreaseCode = _configService.GetByCode("AutoIncreaseOrder").ResponseData;
            LoadData();
        }

        private void frmDacDistributeToStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ucDataButtonStore.DataMode == DataState.Insert)
            {
                if (CommonCore.FormClosing("Bạn chưa lưu đơn hàng xuất này. Bạn có muốn lưu lại?"))
                {
                    //Luu lai du lieu xong thoat form;
                    this.SaveData();
                }
            }
        }

        private void gvExport_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvExport.FocusedRowHandle >= 0)
            {
                if (LstExportInfo[gvExport.FocusedRowHandle].Id > 0)
                {
                    LstExportInfo[gvExport.FocusedRowHandle] = _exportService.GetDetail(LstExportInfo[gvExport.FocusedRowHandle].Id).ResponseData;
                    originalObject = LstExportInfo[gvExport.FocusedRowHandle].Clone();
                }
                else
                {
                    LstExportInfo[gvExport.FocusedRowHandle].LstDetails = new List<DacDistributeToStoreDetailsVM>();
                    originalObject = null;
                }
                if (gvExport.FocusedRowHandle >= 0 && LstExportInfo != null && LstExportInfo.Count > gvExport.FocusedRowHandle && LstExportInfo[gvExport.FocusedRowHandle] != null)
                {
                    gcDetail.DataSource = LstExportInfo[gvExport.FocusedRowHandle].LstDetails;
                    gcDetail.RefreshDataSource();
                    lblRealityQuantity.Text = "Số sản phẩm đã thêm: " + LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count;
                }
                BindDataToControl(LstExportInfo[gvExport.FocusedRowHandle]);
            }
            else
            {
                originalObject = null;
                gcDetail.DataSource = null;
                gcDetail.RefreshDataSource();
            }
        }

        private void textBoxDacCode_KeyPress(object sender, KeyPressEventArgs e)
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
            LstExportInfo = _exportService.GetAll().ResponseData ?? new List<DacExport2VM>();
            gcExport.DataSource = LstExportInfo;
            if (LstExportInfo != null && LstExportInfo.Any())
            {
                gvExport.FocusedRowHandle = 0;
            }
            EnableControls(false);
            if (gvExport.FocusedRowHandle <= 0)
            {
                gvExport_FocusedRowChanged(ucDataButtonStore, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
            }
        }

        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelDistributeToStore.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonStore.DataMode == DataState.Edit)
            {
                txtOrderNumber.Enabled = false;
            }
        }

        private bool ValidateData()
        {
            if (gvExport.FocusedRowHandle < 0 || LstExportInfo[gvExport.FocusedRowHandle] == null)
            {
                MessageBox.Show("Chưa chọn dòng dữ liệu cần xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gvExport.FocusedRowHandle = 0;
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
            {
                MessageBox.Show("Chưa có số lệnh xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOrderNumber.Focus();
                return false;
            }
            if (lueProduct.EditValue == null || string.IsNullOrWhiteSpace(lueProduct.EditValue.ToString().Trim()))
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueProduct.Focus();
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
            if (LstExportInfo[gvExport.FocusedRowHandle].LstDetails == null
                || LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count != int.Parse(txtQuantity.Text))
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
                DacExport2VM exportInfoVM = LstExportInfo[gvExport.FocusedRowHandle];
                exportInfoVM = CreateSaveData(exportInfoVM);
                if (exportInfoVM != null && exportInfoVM.LstDetails != null)
                {
                    foreach (var detail in exportInfoVM.LstDetails)
                    {
                        var invalidProduct = _exportService.InvalidProductCode(detail.DacCode, detail.ProductCode);
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
                        if (_exportService.GetByCode(exportInfoVM.OrderNumber).ResponseData != null)
                        {
                            MessageBox.Show("Mã lệnh này đã được sử dụng! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var response = _exportService.Create(exportInfoVM);
                            exportInfoVM = response.ResponseData;
                            if (exportInfoVM != null && exportInfoVM.Id > 0)
                            {
                                CommonBO.Instance().TraceLogEvent("Save export to store: " + txtOrderNumber.Text + " - " + lueProduct.EditValue + " - "
                                    + LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count, CommonBS.CurrentUser.LoginID);
                                MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ucDataButtonStore.DataMode = DataState.View;
                                if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
                                {
                                    MessageBox.Show(response.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                LoadData();
                                gcExport.Enabled = true;
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
                            CommonBO.Instance().TraceLogEvent("Edit export to store: " + txtOrderNumber.Text + " - " + lueProduct.EditValue + " - "
                                + LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count, CommonBS.CurrentUser.LoginID);
                            MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucDataButtonStore.DataMode = DataState.View;
                            LoadData();
                            gcExport.Enabled = true;
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

        private DacExport2VM CreateSaveData(DacExport2VM exportInfoVM)
        {
            exportInfoVM.Id = ucDataButtonStore.DataMode == DataState.Insert ? 0 : exportInfoVM.Id;
            exportInfoVM.OrderNumber = ucDataButtonStore.DataMode == DataState.Edit ? exportInfoVM.OrderNumber : txtOrderNumber.Text;
            exportInfoVM.CustomerCode = lueStore.EditValue.ToString();
            exportInfoVM.Quantity = int.Parse(txtQuantity.Text);
            exportInfoVM.Description = txtDescription.Text;
            exportInfoVM.Active = true;
            exportInfoVM.CreatedDate = DateTime.Now;
            exportInfoVM.StockCode = lueStock.EditValue?.ToString();
            return exportInfoVM;
        }

        private void BindDataToControl(DacExport2VM exportInfoVM)
        {
            txtOrderNumber.Text = exportInfoVM.OrderNumber;
            txtQuantity.Text = exportInfoVM.Quantity?.ToString();
            dtCreatedDate.Value = exportInfoVM.CreatedDate.HasValue ? exportInfoVM.CreatedDate.Value : DateTime.Now;
            txtDescription.Text = exportInfoVM.Description;
            lueStock.EditValue = exportInfoVM.StockCode;
            lueStore.EditValue = exportInfoVM.CustomerCode;
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
                        var NewDetail = new DacDistributeToStoreDetailsVM();
                        NewDetail.DacCode = String.Format("{0}{1:" + CommonBO.GetSecConfig("SeriLength").Pattern + "}", sPreSeri, i);
                        NewDetail.ProductCode = lueProduct.EditValue.ToString();
                        NewDetail.ProductName = lueProduct.Text;
                        if (_detailService.GetByDacCode(NewDetail.DacCode).ResponseData != null)
                        {
                            MessageBox.Show("Mã QR đã được xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        else
                        {
                            var invalidProduct = _exportService.InvalidProductCode(NewDetail.DacCode, NewDetail.ProductCode);
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
                            else if (LstExportInfo[gvExport.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == NewDetail.DacCode) != null)
                            {
                                MessageBox.Show("Mã QR đã được quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else if (ucDataButtonStore.DataMode != DataState.View && Quantity > 0 && LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count == Quantity)
                            {
                                MessageBox.Show("Đã đạt đến số lượng chỉ định, bạn không thể quét thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else
                            {
                                LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Add(NewDetail);
                            }
                        }
                    }
                    gcDetail.RefreshDataSource();
                    lblRealityQuantity.Text = "Số sản phẩm đã thêm: " + LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count;
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
                    var NewDetail = new DacDistributeToStoreDetailsVM();
                    NewDetail.DacCode = serial;
                    NewDetail.ProductCode = lueProduct.EditValue.ToString();
                    NewDetail.ProductName = lueProduct.Text;
                    if (_detailService.GetByDacCode(NewDetail.DacCode).ResponseData != null)
                    {
                        MessageBox.Show("Mã QR đã được xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var invalidProduct = _exportService.InvalidProductCode(NewDetail.DacCode, NewDetail.ProductCode);
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
                        else if (LstExportInfo[gvExport.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == NewDetail.DacCode) != null)
                        {
                            MessageBox.Show("Mã QR đã được quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ucDataButtonStore.DataMode != DataState.View && Quantity > 0 && LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count == Quantity)
                        {
                            MessageBox.Show("Đã đạt đến số lượng chỉ định, bạn không thể quét thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Add(NewDetail);
                            gcDetail.RefreshDataSource();
                            lblRealityQuantity.Text = "Số sản phẩm đã thêm: " + LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count;
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
            if (LstExportInfo != null && gvExport.FocusedRowHandle >= 0 && LstExportInfo.Count > gvExport.FocusedRowHandle && LstExportInfo[gvExport.FocusedRowHandle].LstDetails != null)
            {
                var LstProductName = LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Select(x => x.ProductName)?.Distinct()?.ToList();
                lblProduct.Text = LstProductName != null ? string.Join(",", LstProductName) : null;
            }
        }

        private void SetSelectControlDataSource()
        {
            LstStock = _stockService.GetAll().ResponseData;
            if (!Session.CurrentUser.isAdmin.HasValue || !Session.CurrentUser.isAdmin.Value)
            {
                LstStock = LstStock?.Where(x => x.AgencyCode == Session.CurrentUser.AgencyCode)?.ToList();
            }
            lueStock.Properties.DataSource = LstStock;
            lueStock.Properties.ValueMember = "Code";
            lueStock.Properties.DisplayMember = "Name";
            LstStore = _storeService.GetAll().ResponseData;
            if (!Session.CurrentUser.isAdmin.HasValue || !Session.CurrentUser.isAdmin.Value)
            {
                LstStore = LstStore?.Where(x => x.AgencyCode == Session.CurrentUser.AgencyCode)?.ToList();
            }
            lueStore.Properties.DataSource = LstStore;
            lueStore.Properties.ValueMember = "Code";
            lueStore.Properties.DisplayMember = "Name";
            LstProducts = _productService.GetAll().ResponseData.Where(x => x.Active.HasValue && x.Active.Value)?.ToList();
            lueProduct.Properties.DataSource = LstProducts;
            lueProduct.Properties.ValueMember = "Code";
            lueProduct.Properties.DisplayMember = "Name";
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonStore_InsertHandler()
        {
            DacExport2VM exportInfo = new DacExport2VM();
            if (AutoIncreaseCode != null && AutoIncreaseCode.Value == "true")
            {
                exportInfo.OrderNumber = _exportService.GenerateNewCode().ResponseData;
            }
            LstExportInfo.Add(exportInfo);
            gcExport.RefreshDataSource();
            gvExport.FocusedRowHandle = LstExportInfo.IndexOf(LstExportInfo.Last());
            EnableControls(true);
            gcExport.Enabled = false;
        }

        private void ucDataButtonStore_SaveHandler()
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveDelegate;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonStore_EditHandler()
        {
            if (LstExportInfo != null && LstExportInfo.Any() && gvExport.FocusedRowHandle >= 0)
            {
                //chkAutoPrintStamp.Enabled = false;
                gcExport.Enabled = false;
                EnableControls(true);
            }
        }

        private void ucDataButtonStore_DeleteHandler()
        {
            if (gvExport.FocusedRowHandle >= 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa phiếu xuất đã chọn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var result = _exportService.Delete(LstExportInfo[gvExport.FocusedRowHandle].Id).ResponseData;
                    if (result)
                    {
                        StringBuilder sContent = new StringBuilder();
                        sContent.Append("Xóa phiếu xuất " + LstExportInfo[gvExport.FocusedRowHandle].OrderNumber);
                        sContent.Append("-");
                        sContent.Append(LstExportInfo[gvExport.FocusedRowHandle].CustomerCode);
                        sContent.Append("-");
                        sContent.Append(LstExportInfo[gvExport.FocusedRowHandle].CreatedDate.Value.ToString("dd/MM/yyyy"));
                        if (LstExportInfo[gvExport.FocusedRowHandle].LstDetails != null && LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Any())
                        {
                            sContent.Append(". Xóa các mã: ");
                            foreach (var detail in LstExportInfo[gvExport.FocusedRowHandle].LstDetails)
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

        private void ucDataButtonStore_CancelHandler()
        {
            ucDataButtonStore.DataMode = DataState.View;
            if (gvExport.FocusedRowHandle >= 0 && originalObject != null)
            {
                LstExportInfo[gvExport.FocusedRowHandle] = originalObject.Clone();
            }
            LoadData();
            gcExport.Enabled = true;
            gcExport.RefreshDataSource();
        }

        private void ucDataButtonStore_CloseHandler()
        {
            if (ucDataButtonStore.DataMode == DataState.Insert || ucDataButtonStore.DataMode == DataState.Edit)
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
                if (gvExport.FocusedRowHandle >= 0 && LstExportInfo[gvExport.FocusedRowHandle] != null && LstExportInfo[gvExport.FocusedRowHandle].LstDetails != null)
                {
                    if (MessageBox.Show("Lưu ý rằng việc thêm các mã QR có thể sẽ cập nhật lại số lượng chỉ định trong phiếu xuất này. " +
                        "Bạn có xác nhận muốn tiếp tục?", "Xác nhận cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var LstNewDetail = LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Where(x => x.Id <= 0)?.Select(x => new DacDistributeToStoreDetails
                        {
                            Id = x.Id,
                            DistributeToStoreId = x.DistributeToStoreId,
                            DacCode = x.DacCode,
                            ProductCode = lueProduct.EditValue.ToString()
                        })?.ToList();
                        if (LstNewDetail != null && LstNewDetail.Any())
                        {
                            StringBuilder sContent = new StringBuilder();
                            sContent.Append("Thêm các mã: ");
                            for (int i = 0; i < LstNewDetail.Count; i++)
                            {
                                LstNewDetail[i].DistributeToStoreId = LstExportInfo[gvExport.FocusedRowHandle].Id;
                            }
                            if (_detailService.AddRange(LstNewDetail).ResponseData)
                            {
                                lblRealityQuantity.Text = "Số sản phẩm đã thêm: " + LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count;
                                sContent.Append(string.Join(",", LstNewDetail.Select(x => x.DacCode)?.ToList()));
                                if (LstExportInfo[gvExport.FocusedRowHandle] != null)
                                {
                                    var EditedPackage = _exportService.GetDetail(LstExportInfo[gvExport.FocusedRowHandle].Id).ResponseData;
                                    if (EditedPackage != null)
                                    {
                                        LstExportInfo[gvExport.FocusedRowHandle].Quantity = EditedPackage.RealityQuantity;
                                        txtQuantity.Text = LstExportInfo[gvExport.FocusedRowHandle].Quantity.ToString();
                                        gcExport.RefreshDataSource();
                                    }
                                }
                                sContent.Append("vào phiếu xuất " + LstExportInfo[gvExport.FocusedRowHandle].Id);
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
                if (gvExport.FocusedRowHandle >= 0 && SelectedIndex != null && SelectedIndex.Length > 0)
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa các mã QR code đã chọn? Lưu ý rằng việc xóa các mã QR có thể sẽ cập nhật lại số lượng chỉ định trong phiếu xuất này. " +
                        "Bạn có xác nhận muốn tiếp tục?", "Xác nhận xóa mã", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (SelectedIndex.Length == LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count)
                        {
                            if (MessageBox.Show("Nếu bạn xóa tất cả mã QR trong phiếu xuất, phiếu này sẽ bị xóa. Bạn có chắc chắn muốn xóa?", "Xác nhận xóa mã"
                                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                ucDataButtonStore_DeleteHandler();
                            }
                        }
                        else
                        {
                            StringBuilder sContent = new StringBuilder();
                            sContent.Append("Xóa mã: ");
                            var LstDelete = LstExportInfo[gvExport.FocusedRowHandle].LstDetails
                                .Where(x => SelectedIndex.Contains(LstExportInfo[gvExport.FocusedRowHandle].LstDetails.IndexOf(x)))?.Select(x => x.DacCode)?.ToList();
                            if (LstDelete != null)
                            {
                                var result = _detailService.DeleteByDacCode(LstDelete).ResponseData;
                                if (result)
                                {
                                    sContent.Append(string.Join(",", LstDelete));
                                    for (int i = 0; i < LstDelete.Count; i++)
                                    {
                                        var RemoveDetail = LstExportInfo[gvExport.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == LstDelete[i]);
                                        if (RemoveDetail != null)
                                        {
                                            LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Remove(RemoveDetail);
                                        }
                                    }
                                    for (int i = 0; i < SelectedIndex.Length; i++)
                                    {
                                        gvDetail.UnselectRow(SelectedIndex[i]);
                                    }
                                    lblRealityQuantity.Text = "Số sản phẩm đã thêm: " + LstExportInfo[gvExport.FocusedRowHandle].LstDetails.Count;
                                    if (LstExportInfo[gvExport.FocusedRowHandle] != null)
                                    {
                                        var EditedPackage = _exportService.GetDetail(LstExportInfo[gvExport.FocusedRowHandle].Id).ResponseData;
                                        if (EditedPackage != null)
                                        {
                                            LstExportInfo[gvExport.FocusedRowHandle].Quantity = EditedPackage.RealityQuantity;
                                            txtQuantity.Text = LstExportInfo[gvExport.FocusedRowHandle].Quantity.ToString();
                                            gcExport.RefreshDataSource();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi đã xảy ra khi xóa các mã QRCode.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            gcDetail.RefreshDataSource();
                            MessageBox.Show("Xóa thành công " + SelectedIndex.Length + " mã đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        #endregion
    }
}