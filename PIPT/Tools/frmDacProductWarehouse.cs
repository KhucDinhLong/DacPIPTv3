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
    public partial class frmDacProductWarehouse : Form
    {
        #region Variables
        IDacInsertToWarehouseService _importService;
        IDacProductService _productService;
        IDacInsertToWarehouseDetailsService _detailService;
        IDacStockService _stockService;
        ISecConfigService _configService;
        List<DacInsertToWarehouseVM> LstImportInfo;
        List<DacProductVM> LstProducts;
        List<DacStock> LstStock;
        SecConfig AutoIncreaseCode;
        DacInsertToWarehouseVM originalObject;
        #endregion
        #region Form's Events
        public frmDacProductWarehouse(IDacInsertToWarehouseService importService, IDacProductService productService, IDacInsertToWarehouseDetailsService detailService, IDacStockService stockService, ISecConfigService configService)
        {
            InitializeComponent();
            _importService = importService;
            _productService = productService;
            _detailService = detailService;
            _stockService = stockService;
            _configService = configService;
        }

        private void frmDacProductWarehouse_Load(object sender, EventArgs e)
        {
            AutoIncreaseCode = _configService.GetByCode("AutoIncreaseWarehouse").ResponseData;
            LoadData();
        }

        private void frmDacProductWarehouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ucDataButtonWarehouse.DataMode == DataState.Insert || ucDataButtonWarehouse.DataMode == DataState.Edit)
            {
                if (CommonCore.FormClosing("Bạn chưa lưu phiếu nhập kho này. Bạn có muốn lưu lại?"))
                {
                    SaveData();
                }
            }
        }

        private void gvWarehouse_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvWarehouse.FocusedRowHandle >= 0)
            {
                BindDataToControl(LstImportInfo[gvWarehouse.FocusedRowHandle]);
                if (LstImportInfo[gvWarehouse.FocusedRowHandle].Id > 0)
                {
                    LstImportInfo[gvWarehouse.FocusedRowHandle] = _importService.GetDetail(LstImportInfo[gvWarehouse.FocusedRowHandle].Id).ResponseData;
                    originalObject = LstImportInfo[gvWarehouse.FocusedRowHandle].Clone();
                }
                else
                {
                    LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails = new List<DacInsertToWarehouseDetails>();
                    originalObject = null;
                }
                if (gvWarehouse.FocusedRowHandle >= 0 && LstImportInfo != null && LstImportInfo.Count > gvWarehouse.FocusedRowHandle && LstImportInfo[gvWarehouse.FocusedRowHandle] != null)
                {
                    gcDetail.DataSource = LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails;
                    gcDetail.RefreshDataSource();
                    lblQuantity.Text = "Số sản phẩm đã thêm: " + LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count;
                }
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
                AddDetail();
            }
        }

        private void txtFrSeri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string DacCode = txtFrSeri.Text.Trim();
                if (DacCode.Length >= 7)
                {
                    string serial = CommonCore.GetSerialFromScanner(DacCode);
                    txtFrSeri.Text = serial;
                    txtToSeri.Focus();
                }
            }
        }

        private void txtToSeri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
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
        }
        #endregion

        #region Function on form

        private void LoadData()
        {
            LstImportInfo = _importService.GetAll().ResponseData ?? new List<DacInsertToWarehouseVM>();
            LstStock = _stockService.GetAll().ResponseData;
            if (!Session.CurrentUser.isAdmin.HasValue || !Session.CurrentUser.isAdmin.Value)
            {
                LstStock = LstStock?.Where(x => x.AgencyCode == Session.CurrentUser.AgencyCode)?.ToList();
            }
            lueDacStock.Properties.DataSource = LstStock;
            lueDacStock.Properties.ValueMember = "Code";
            lueDacStock.Properties.DisplayMember = "Name";
            gcWarehouse.DataSource = LstImportInfo;
            if (LstImportInfo != null && LstImportInfo.Any())
            {
                gvWarehouse.FocusedRowHandle = 0;
            }
            LstProducts = _productService.GetAll().ResponseData.Where(x => x.Active.HasValue && x.Active.Value)?.ToList();
            lueProduct.Properties.DataSource = LstProducts;
            lueProduct.Properties.ValueMember = "Code";
            lueProduct.Properties.DisplayMember = "Name";
            EnableControls(false);
            if (gvWarehouse.FocusedRowHandle <= 0)
            {
                gvWarehouse_FocusedRowChanged(ucDataButtonWarehouse, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
            }
        }

        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelInsertToWarehouse.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonWarehouse.DataMode == DataState.Edit)
            {
                txtOrderNumber.Enabled = false;
            }
        }

        private bool ValidateData()
        {
            if (gvWarehouse.FocusedRowHandle < 0 || LstImportInfo[gvWarehouse.FocusedRowHandle] == null)
            {
                MessageBox.Show("Chưa chọn dòng dữ liệu cần xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gvWarehouse.FocusedRowHandle = 0;
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
            {
                MessageBox.Show("Chưa có số lệnh nhập kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails == null
                || LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count != int.Parse(txtQuantity.Text))
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
                DacInsertToWarehouseVM importInfoVM = LstImportInfo[gvWarehouse.FocusedRowHandle];
                importInfoVM = CreateSaveData(importInfoVM);
                var invalidProduct = _importService.InvalidProductCode(importInfoVM);
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
                else
                {
                    if (importInfoVM.Id <= 0)
                    {
                        if (_importService.GetByCode(importInfoVM.InsertNumber).ResponseData != null)
                        {
                            MessageBox.Show("Mã lệnh này đã được sử dụng! " + invalidProduct.ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var response = _importService.Create(importInfoVM);
                            importInfoVM = response.ResponseData;
                            if (importInfoVM != null && importInfoVM.Id > 0)
                            {
                                CommonBO.Instance().TraceLogEvent("Save import warehouse: " + txtOrderNumber.Text + " - " + lueProduct.EditValue + " - "
                                    + LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count, CommonBS.CurrentUser.LoginID);
                                MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ucDataButtonWarehouse.DataMode = DataState.View;
                                if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
                                {
                                    MessageBox.Show(response.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                LoadData();
                                gcWarehouse.Enabled = true;
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
                        importInfoVM = _importService.Edit(importInfoVM).ResponseData;
                        if (importInfoVM != null && importInfoVM.Id > 0)
                        {
                            CommonBO.Instance().TraceLogEvent("Edit import warehouse: " + txtOrderNumber.Text + " - " + lueProduct.EditValue + " - "
                                + LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count, CommonBS.CurrentUser.LoginID);
                            MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucDataButtonWarehouse.DataMode = DataState.View;
                            LoadData();
                            gcWarehouse.Enabled = true;
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

        private DacInsertToWarehouseVM CreateSaveData(DacInsertToWarehouseVM importInfoVM)
        {
            importInfoVM.Id = ucDataButtonWarehouse.DataMode == DataState.Insert ? 0 : importInfoVM.Id;
            importInfoVM.InsertNumber = ucDataButtonWarehouse.DataMode == DataState.Edit ? importInfoVM.InsertNumber : txtOrderNumber.Text;
            importInfoVM.ProductCode = lueProduct.EditValue != null ? lueProduct.EditValue.ToString() : string.Empty;
            importInfoVM.Quantity = int.Parse(txtQuantity.Text);
            importInfoVM.Description = txtDescription.Text;
            importInfoVM.Active = true;
            importInfoVM.CreatedDate = DateTime.Now;
            importInfoVM.StockCode = lueDacStock.EditValue?.ToString();
            return importInfoVM;
        }

        private void BindDataToControl(DacInsertToWarehouseVM importInfoVM)
        {
            txtOrderNumber.Text = importInfoVM.InsertNumber;
            lueProduct.EditValue = importInfoVM.ProductCode;
            txtQuantity.Text = importInfoVM.Quantity?.ToString();
            dtpCreatedDate.Value = importInfoVM.CreatedDate.HasValue ? importInfoVM.CreatedDate.Value : DateTime.Now;
            txtDescription.Text = importInfoVM.Description;
            lueDacStock.EditValue = importInfoVM.StockCode;
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
                        var NewDetail = new DacInsertToWarehouseDetails();
                        NewDetail.DacCode = String.Format("{0}{1:" + CommonBO.GetSecConfig("SeriLength").Pattern + "}", sPreSeri, i);
                        if (_detailService.GetByDacCode(NewDetail.DacCode).ResponseData != null)
                        {
                            MessageBox.Show("Mã QR đã được nhập kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        else
                        {
                            if (LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == NewDetail.DacCode) != null)
                            {
                                MessageBox.Show("Mã QR đã được quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else if (ucDataButtonWarehouse.DataMode != DataState.View && Quantity > 0 && LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count == Quantity)
                            {
                                MessageBox.Show("Đã đạt đến số lượng chỉ định, bạn không thể quét thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else
                            {
                                LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Add(NewDetail);
                            }
                        }
                    }
                    gcDetail.RefreshDataSource();
                    lblQuantity.Text = "Số sản phẩm đã thêm: " + LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count;
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
                    var NewDetail = new DacInsertToWarehouseDetails();
                    NewDetail.DacCode = serial;
                    if (_detailService.GetByDacCode(NewDetail.DacCode).ResponseData != null)
                    {
                        MessageBox.Show("Mã QR đã được nhập kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == NewDetail.DacCode) != null)
                        {
                            MessageBox.Show("Mã QR đã được quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ucDataButtonWarehouse.DataMode != DataState.View && Quantity > 0 && LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count == Quantity)
                        {
                            MessageBox.Show("Đã đạt đến số lượng chỉ định, bạn không thể quét thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Add(NewDetail);
                            gcDetail.RefreshDataSource();
                            lblQuantity.Text = "Số sản phẩm đã thêm: " + LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count;
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

        #endregion

        #region Buttons' Event
        private void ucDataButtonWarehouse_InsertHandler()
        {
            DacInsertToWarehouseVM importInfo = new DacInsertToWarehouseVM();
            if (AutoIncreaseCode != null && AutoIncreaseCode.Value == "true")
            {
                importInfo.InsertNumber = _importService.GenerateNewCode().ResponseData;
            }
            LstImportInfo.Add(importInfo);
            gcWarehouse.RefreshDataSource();
            gvWarehouse.FocusedRowHandle = LstImportInfo.IndexOf(LstImportInfo.Last());
            EnableControls(true);
            gcWarehouse.Enabled = false;
        }

        private void ucDataButtonWarehouse_SaveHandler()
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveDelegate;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonWarehouse_EditHandler()
        {
            if (gvWarehouse.FocusedRowHandle >= 0)
            {
                //chkAutoPrintStamp.Enabled = false;
                gcWarehouse.Enabled = false;
                EnableControls(true);
            }
        }

        private void ucDataButtonWarehouse_DeleteHandler()
        {
            if (gvWarehouse.FocusedRowHandle >= 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa phiếu nhập đã chọn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var result = _importService.Delete(LstImportInfo[gvWarehouse.FocusedRowHandle].Id).ResponseData;
                    if (result)
                    {
                        StringBuilder sContent = new StringBuilder();
                        sContent.Append("Xóa phiếu nhập kho " + LstImportInfo[gvWarehouse.FocusedRowHandle].Id);
                        sContent.Append("-");
                        sContent.Append(LstImportInfo[gvWarehouse.FocusedRowHandle].ProductCode);
                        sContent.Append("-");
                        sContent.Append(LstImportInfo[gvWarehouse.FocusedRowHandle].CreatedDate.Value.ToString("dd/MM/yyyy"));
                        if (LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails != null && LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Any())
                        {
                            sContent.Append(". Xóa các mã: ");
                            foreach (var detail in LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails)
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

        private void ucDataButtonWarehouse_CancelHandler()
        {
            ucDataButtonWarehouse.DataMode = DataState.View;
            if (gvWarehouse.FocusedRowHandle >= 0 && originalObject != null)
            {
                LstImportInfo[gvWarehouse.FocusedRowHandle] = originalObject.Clone();
            }
            LoadData();
            gcWarehouse.Enabled = true;
            gcWarehouse.RefreshDataSource();
        }

        private void ucDataButtonWarehouse_CloseHandler()
        {
            if (ucDataButtonWarehouse.DataMode == DataState.Insert || ucDataButtonWarehouse.DataMode == DataState.Edit)
            {
                if (CommonCore.FormClosing("Bạn chưa lưu phiếu nhập kho này. Bạn có muốn lưu lại?"))
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
                if (gvWarehouse.FocusedRowHandle >= 0 && LstImportInfo[gvWarehouse.FocusedRowHandle] != null && LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails != null)
                {
                    if (MessageBox.Show("Lưu ý rằng việc thêm các mã QR có thể sẽ cập nhật lại số lượng chỉ định trong phiếu nhập kho này. " +
                        "Bạn có xác nhận muốn tiếp tục?", "Xác nhận cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var LstNewDetail = LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Where(x => x.Id <= 0)?.ToList();
                        if (LstNewDetail != null && LstNewDetail.Any())
                        {
                            StringBuilder sContent = new StringBuilder();
                            sContent.Append("Thêm các mã: ");
                            for (int i = 0; i < LstNewDetail.Count; i++)
                            {
                                LstNewDetail[i].InsertID = LstImportInfo[gvWarehouse.FocusedRowHandle].Id;
                            }
                            if (_detailService.AddRange(LstNewDetail).ResponseData)
                            {
                                lblQuantity.Text = "Số sản phẩm đã thêm: " + LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count;
                                sContent.Append(string.Join(",", LstNewDetail.Select(x => x.DacCode)?.ToList()));
                                try
                                {
                                    if (LstImportInfo[gvWarehouse.FocusedRowHandle] != null)
                                    {
                                        var EditedPackage = _importService.GetDetail(LstImportInfo[gvWarehouse.FocusedRowHandle].Id).ResponseData;
                                        if (EditedPackage != null)
                                        {
                                            LstImportInfo[gvWarehouse.FocusedRowHandle].Quantity = EditedPackage.RealityQuantity;
                                            if (_importService.Edit(LstImportInfo[gvWarehouse.FocusedRowHandle]).ResponseData != null)
                                            {
                                                txtQuantity.Text = LstImportInfo[gvWarehouse.FocusedRowHandle].Quantity.ToString();
                                                gcWarehouse.RefreshDataSource();
                                            }

                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Thêm thành công " + LstNewDetail.Count + " mã đã quét nhưng chưa cập nhật được số lượng chỉ định của phiếu nhập kho! " + ex.Message
                                        , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                sContent.Append("vào phiếu nhập " + LstImportInfo[gvWarehouse.FocusedRowHandle].Id);
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
                if (gvWarehouse.FocusedRowHandle >= 0 && SelectedIndex != null && SelectedIndex.Length > 0)
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa các mã QR code đã chọn? Lưu ý rằng việc xóa các mã QR có thể sẽ cập nhật lại số lượng chỉ định trong phiếu nhập kho này. " +
                        "Bạn có xác nhận muốn tiếp tục?", "Xác nhận xóa mã", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (SelectedIndex.Length == LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count)
                        {
                            if (MessageBox.Show("Nếu bạn xóa tất cả mã QR trong phiếu nhập kho, phiếu này sẽ bị xóa. Bạn có chắc chắn muốn xóa?", "Xác nhận xóa mã"
                                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                ucDataButtonWarehouse_DeleteHandler();
                            }
                        }
                        else
                        {
                            StringBuilder sContent = new StringBuilder();
                            sContent.Append("Xóa mã: ");
                            var LstDelete = LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails
                                .Where(x => SelectedIndex.Contains(LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.IndexOf(x)))?.Select(x => x.DacCode)?.ToList();
                            if (LstDelete != null)
                            {
                                var result = _detailService.DeleteByDacCode(LstDelete).ResponseData;
                                if (result)
                                {
                                    sContent.Append(string.Join(",", LstDelete));
                                    for (int i = 0; i < LstDelete.Count; i++)
                                    {
                                        var RemoveDetail = LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == LstDelete[i]);
                                        if (RemoveDetail != null)
                                        {
                                            LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Remove(RemoveDetail);
                                        }
                                    }
                                    for (int i = 0; i < SelectedIndex.Length; i++)
                                    {
                                        gvDetail.UnselectRow(SelectedIndex[i]);
                                    }
                                    lblQuantity.Text = "Số sản phẩm đã thêm: " + LstImportInfo[gvWarehouse.FocusedRowHandle].LstDetails.Count;
                                    if (LstImportInfo[gvWarehouse.FocusedRowHandle] != null)
                                    {
                                        var EditedPackage = _importService.GetDetail(LstImportInfo[gvWarehouse.FocusedRowHandle].Id).ResponseData;
                                        if (EditedPackage != null)
                                        {
                                            LstImportInfo[gvWarehouse.FocusedRowHandle].Quantity = EditedPackage.RealityQuantity;
                                            txtQuantity.Text = LstImportInfo[gvWarehouse.FocusedRowHandle].Quantity.ToString();
                                            gcWarehouse.RefreshDataSource();
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
            AddDetail();
        }

        private void btnAddSerialCode_Click(object sender, EventArgs e)
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

        private void ucDataButtonWarehouse_PrintHandler()
        {
            if (gvWarehouse.FocusedRowHandle >= 0 && LstImportInfo[gvWarehouse.FocusedRowHandle] != null)
            {
                PIPT.Report.PackageQRCode rpt = new PIPT.Report.PackageQRCode();
                DacInsertToWarehouseVM importInfo = LstImportInfo[gvWarehouse.FocusedRowHandle];
            }
        }
        #endregion
    }
}
