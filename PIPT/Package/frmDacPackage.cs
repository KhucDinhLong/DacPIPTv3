using AnyClone;
using DAC.Core;
using DAC.Core.Security;
using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacPackage : Form
    {
        #region Variables
        IDacPackageService _packageService;
        IDacProductService _productService;
        IDacPackageDetailService _packageDetailService;
        ISecConfigService _configService;
        List<DacPackageVM> LstPackages;
        List<DacProductVM> LstProducts;
        SecConfig AutoIncreasePackage;
        string AutoModeStatus = string.Empty;
        DacPackageVM originalObject;
        #endregion

        public frmDacPackage(IDacPackageService packageService, IDacProductService productService, IDacPackageDetailService packageDetailService, ISecConfigService configService)
        {
            InitializeComponent();
            _packageService = packageService;
            _productService = productService;
            _packageDetailService = packageDetailService;
            _configService = configService;
        }

        #region Form's Events
        private void frmDacPackage_Load(object sender, EventArgs e)
        {
            AutoIncreasePackage = _configService.GetByCode("AutoIncreasePackage").ResponseData;
            LoadData();
        }

        private void LoadData()
        {
            LstPackages = _packageService.GetAll().ResponseData ?? new List<DacPackageVM>();
            gcPackage.DataSource = LstPackages;
            if (LstPackages != null && LstPackages.Any())
            {
                gvPackage.FocusedRowHandle = 0;
            }
            LstProducts = _productService.GetAll().ResponseData.Where(x => x.Active.HasValue && x.Active.Value)?.ToList();
            lueProduct.Properties.DataSource = LstProducts;
            lueProduct.Properties.ValueMember = "Code";
            lueProduct.Properties.DisplayMember = "Name";
            EnableControls(false);
            if (gvPackage.FocusedRowHandle <= 0)
            {
                gridViewPackage_FocusedRowChanged(ucDataButtonPackage, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
            }
        }

        private void frmDacPackage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ucDataButtonPackage.DataMode == DataState.Insert || ucDataButtonPackage.DataMode == DataState.Edit)
            {
                if (MessageBox.Show("Dữ liệu chưa được lưu trữ, bạn có muốn lưu lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveData();
                }
            }
        }

        private void gridViewPackage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvPackage.FocusedRowHandle >= 0)
            {
                BindDataToControl(LstPackages[gvPackage.FocusedRowHandle]);
                if (LstPackages[gvPackage.FocusedRowHandle].Id > 0)
                {
                    LstPackages[gvPackage.FocusedRowHandle] = _packageService.GetDetail(LstPackages[gvPackage.FocusedRowHandle].Id).ResponseData;
                    originalObject = LstPackages[gvPackage.FocusedRowHandle].Clone();
                }
                else
                {
                    LstPackages[gvPackage.FocusedRowHandle].LstDetails = new List<DacPackageDetails>();
                    originalObject = null;
                }
                if (gvPackage.FocusedRowHandle >= 0 && LstPackages != null && LstPackages.Count > gvPackage.FocusedRowHandle && LstPackages[gvPackage.FocusedRowHandle] != null)
                {
                    gcDetail.DataSource = LstPackages[gvPackage.FocusedRowHandle].LstDetails;
                    gcDetail.RefreshDataSource();
                    lblProductCount.Text = "Số sản phẩm đã thêm: " + LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count;
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

        private void chkAutoPrintStamp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoPrintStamp.Checked)
            {
                if (ucDataButtonPackage.DataMode == DataState.Insert || ucDataButtonPackage.DataMode == DataState.Edit)
                {
                    MessageBox.Show("Dữ liệu hiện tại chưa được lưu, vui lòng lưu hoặc hủy bỏ trước khi sử dụng tính năng này!", "Thông báo"
                        , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                gcPackage.Enabled = false;
                txtPackageCode.Text = string.Empty;
                txtPackageCode.Enabled = false;
                chkKeepProduct.Checked = true;
                chkKeepProduct.Enabled = false;
                txtQuantity.Enabled = true;
                string sSoLuong = ConfigurationManager.AppSettings["PackagedNumber"];
                try
                {
                    int Quantity = int.Parse(sSoLuong);
                    txtQuantity.Text = sSoLuong;
                }
                catch
                {
                }
                txtBatch.Text = string.Empty;
                txtBatch.Enabled = true;
                lueProduct.EditValue = null;
                lueProduct.Enabled = true;
                txtPersonPackaged.Text = string.Empty;
                txtPersonPackaged.Enabled = true;
                txtFactory.Text = string.Empty;
                txtFactory.Enabled = true;
                dtpCreatedDate.Enabled = true;
                dtpCreatedDate.Value = DateTime.Now;
                txtDescription.Text = string.Empty;
                txtDescription.Enabled = true;
                chkPreview.Checked = false;
                chkPreview.Enabled = false;
                txtDacCode.Text = string.Empty;
                txtDacCode.Enabled = false;
                txtFrSeri.Text = string.Empty;
                txtFrSeri.Enabled = false;
                txtToSeri.Text = string.Empty;
                txtToSeri.Enabled = false;
                btnEnter.Enabled = false;
                btnAddSerialCode.Enabled = false;
                btnUpdateDetail.Enabled = false;
                btnDetailDelete.Enabled = false;
                gcDetail.Enabled = false;
                ucDataButtonPackage.Visible = false;
                btnStart.Visible = true;
            }
            else
            {
                if (gvPackage.FocusedRowHandle >= 0 && LstPackages[gvPackage.FocusedRowHandle] != null && LstPackages[gvPackage.FocusedRowHandle].Id == 0)
                {
                    if (MessageBox.Show("Thùng gần nhất chưa được lưu, Bạn có chắc chắn muốn dừng lại?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        AutoModeStatus = "End";
                        LstPackages.RemoveAt(gvPackage.FocusedRowHandle);
                        gcPackage.RefreshDataSource();
                        EnableControls(false);
                        gcPackage.Enabled = true;
                        gvPackage.FocusedRowHandle = gvPackage.RowCount > 0 ? 0 : -1;
                        txtFrSeri.Enabled = true;
                        txtToSeri.Enabled = true;
                        btnEnter.Enabled = true;
                        btnAddSerialCode.Enabled = true;
                        btnUpdateDetail.Enabled = true;
                        btnDetailDelete.Enabled = true;
                        gcDetail.Enabled = true;
                        ucDataButtonPackage.Visible = true;
                        btnStart.Enabled = true;
                        btnStart.Visible = false;
                        ucDataButtonPackage.DataMode = DataState.View;
                    }
                    else
                    {
                        chkAutoPrintStamp.CheckedChanged -= chkAutoPrintStamp_CheckedChanged;
                        chkAutoPrintStamp.Checked = true;
                        chkAutoPrintStamp.CheckedChanged += chkAutoPrintStamp_CheckedChanged;
                        txtDacCode.Focus();
                    }
                }
            }
        }

        private void lueProduct_EditValueChanged(object sender, EventArgs e)
        {
            if (lueProduct.EditValue != null && !string.IsNullOrEmpty(lueProduct.EditValue.ToString())
                && (ucDataButtonPackage.DataMode == DataState.Insert || chkAutoPrintStamp.Checked))
            {
                DacProductVM SelectedProduct = LstProducts.FirstOrDefault(x => x.Code == lueProduct.EditValue.ToString());
                if (SelectedProduct != null)
                {
                    txtPackageCode.Text = GetMaxPackage(SelectedProduct.Size);
                }
            }
        }
        #endregion
        #region Function on form
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelPackage.Controls)
            {
                if (ctrl.Name != "chkAutoPrintStamp" && ctrl.Name != "chkPreview" && ctrl.Name != "dtpNgaySX")
                    ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonPackage.DataMode == DataState.Edit)
            {
                txtPackageCode.Enabled = false;
            }
        }

        private bool ValidateData()
        {
            if (gvPackage.FocusedRowHandle < 0 || LstPackages[gvPackage.FocusedRowHandle] == null)
            {
                MessageBox.Show("Chưa chọn dòng dữ liệu cần xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gvPackage.FocusedRowHandle = 0;
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPackageCode.Text))
            {
                MessageBox.Show("Chưa tạo được mã thùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPackageCode.Focus();
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
            if (!chkAutoPrintStamp.Checked
                && (LstPackages[gvPackage.FocusedRowHandle].LstDetails == null
                || LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count != int.Parse(txtQuantity.Text)))
            {
                MessageBox.Show("Số lượng mã quét vào không khớp với số lượng sản phẩm chỉ định trong thùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DacPackageVM packageVM = LstPackages[gvPackage.FocusedRowHandle];
                packageVM = CreateSaveData(packageVM);
                var invalidProduct = _packageService.InvalidProductCode(packageVM);
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
                    if (packageVM.Id <= 0)
                    {
                        if (_packageService.Exist(packageVM.PackageCode).ResponseData)
                        {
                            MessageBox.Show("Mã thùng đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPackageCode.Focus();
                            return false;
                        }
                        var response = _packageService.Create(packageVM);
                        packageVM = response.ResponseData;
                        if (packageVM != null && packageVM.Id > 0)
                        {
                            CommonBO.Instance().TraceLogEvent("Save Container: " + txtPackageCode.Text + " - " + lueProduct.EditValue + " - "
                                + LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count, CommonBS.CurrentUser.LoginID);
                            MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucDataButtonPackage.DataMode = DataState.View;
                            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
                            {
                                MessageBox.Show(response.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            LoadData();
                            gcPackage.Enabled = true;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Lưu dữ liệu không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        packageVM = _packageService.Edit(packageVM).ResponseData;
                        if (packageVM != null && packageVM.Id > 0)
                        {
                            CommonBO.Instance().TraceLogEvent("Save Container: " + txtPackageCode.Text + " - " + lueProduct.EditValue + " - "
                                + LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count, CommonBS.CurrentUser.LoginID);
                            MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucDataButtonPackage.DataMode = DataState.View;
                            LoadData();
                            gcPackage.Enabled = true;
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

        private DacPackageVM CreateSaveData(DacPackageVM packageVM)
        {
            packageVM.Id = ucDataButtonPackage.DataMode == DataState.Insert ? 0 : packageVM.Id;
            packageVM.PackageCode = ucDataButtonPackage.DataMode == DataState.Edit ? packageVM.PackageCode : txtPackageCode.Text;
            packageVM.ProductCode = lueProduct.EditValue != null ? lueProduct.EditValue.ToString() : string.Empty;
            packageVM.Batch = txtBatch.Text;
            packageVM.Quantity = int.Parse(txtQuantity.Text);
            packageVM.PersonPackaged = txtPersonPackaged.Text;
            packageVM.Description = txtDescription.Text;
            packageVM.Active = true;
            packageVM.CreatedDate = DateTime.Now;
            packageVM.FactoryCode = txtFactory.Text;
            packageVM.NgaySanXuat = dtpNgaySX.Value;
            return packageVM;
        }

        private void BindDataToControl(DacPackageVM packageVM)
        {
            txtPackageCode.Text = packageVM != null ? packageVM.PackageCode : string.Empty;
            txtBatch.Text = packageVM != null ? packageVM.Batch : string.Empty;
            lueProduct.EditValue = packageVM != null ? packageVM.ProductCode : string.Empty;
            txtQuantity.Text = packageVM != null ? packageVM.Quantity.HasValue ? packageVM.Quantity.Value.ToString() : string.Empty : string.Empty;
            txtPersonPackaged.Text = packageVM != null ? packageVM.PersonPackaged : string.Empty;
            txtFactory.Text = packageVM != null ? packageVM.FactoryCode : string.Empty;
            txtDescription.Text = packageVM != null ? packageVM.Description : string.Empty;
            dtpCreatedDate.Value = packageVM != null ? packageVM.CreatedDate.HasValue ? packageVM.CreatedDate.Value : DateTime.Now : DateTime.Now;
        }
        // Get Max Package
        private string GetMaxPackage(string Size)
        {
            // Lấy ra phần ký tự là dấu hiệu cho biết là thùng
            StringBuilder sbPackage = new StringBuilder();
            foreach (char item in AutoIncreasePackage.Pattern.ToCharArray())
            {
                if (char.IsLetter(item))
                    sbPackage.Append(item);
            }
            if (AutoIncreasePackage.Value == "true")
            {
                string MaxPackageCode = _packageService.GetMaxPackage(sbPackage.ToString().ToUpper(), Size).ResponseData;
                if (!string.IsNullOrWhiteSpace(MaxPackageCode))
                {
                    return MaxPackageCode;
                }
            }
            return AutoIncreasePackage.Pattern;
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
                        var NewDetail = new DacPackageDetails();
                        NewDetail.DacCode = String.Format("{0}{1:" + CommonBO.GetSecConfig("SeriLength").Pattern + "}", sPreSeri, i);
                        if (_packageDetailService.GetByDacCode(NewDetail.DacCode).ResponseData != null)
                        {
                            MessageBox.Show("Mã QR đã được đóng thùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        else
                        {
                            if (LstPackages[gvPackage.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == NewDetail.DacCode) != null)
                            {
                                MessageBox.Show("Mã QR đã được quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else if (ucDataButtonPackage.DataMode != DataState.View && Quantity > 0 && LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count == Quantity)
                            {
                                MessageBox.Show("Đã đạt đến số lượng chỉ định, bạn không thể quét thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else
                            {
                                LstPackages[gvPackage.FocusedRowHandle].LstDetails.Add(NewDetail);
                            }
                        }
                    }
                    gcDetail.RefreshDataSource();
                    lblProductCount.Text = "Số sản phẩm đã thêm: " + LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    var NewDetail = new DacPackageDetails();
                    NewDetail.DacCode = serial;
                    if (_packageDetailService.GetByDacCode(NewDetail.DacCode).ResponseData != null)
                    {
                        MessageBox.Show("Mã QR đã được đóng thùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (LstPackages[gvPackage.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == NewDetail.DacCode) != null)
                        {
                            MessageBox.Show("Mã QR đã được quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ucDataButtonPackage.DataMode != DataState.View && Quantity > 0 && LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count == Quantity)
                        {
                            MessageBox.Show("Đã đạt đến số lượng chỉ định, bạn không thể quét thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            LstPackages[gvPackage.FocusedRowHandle].LstDetails.Add(NewDetail);
                            gcDetail.RefreshDataSource();
                            lblProductCount.Text = "Số sản phẩm đã thêm: " + LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count;
                        }
                    }
                    txtDacCode.Text = string.Empty;
                    if (AutoModeStatus == "Playing")
                    {
                        var PackageNumberStr = txtQuantity.Text;
                        int PackageNumber = 0;
                        try
                        {
                            PackageNumber = int.Parse(PackageNumberStr);
                        }
                        catch
                        {
                        }
                        if (gvPackage.FocusedRowHandle >= 0 && LstPackages[gvPackage.FocusedRowHandle] != null
                            && LstPackages[gvPackage.FocusedRowHandle].LstDetails != null
                            && LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count == PackageNumber)
                        {
                            try
                            {
                                var NewPackage = CreateSaveData(LstPackages[gvPackage.FocusedRowHandle]);
                                if (_packageService.Exist(NewPackage.PackageCode).ResponseData)
                                {
                                    MessageBox.Show("Mã thùng đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    chkAutoPrintStamp.Checked = false;
                                }
                                NewPackage = _packageService.Create(NewPackage).ResponseData;
                                if (NewPackage != null && NewPackage.Id > 0)
                                {
                                    CommonBO.Instance().TraceLogEvent("Save Container: " + txtPackageCode.Text + " - " + lueProduct.EditValue + " - "
                                        + LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count, CommonBS.CurrentUser.LoginID);
                                    LoadData();
                                    ucDataButtonPackage.DataMode = DataState.View;
                                    var SelectedProduct = LstProducts.FirstOrDefault(x => x.Code == lueProduct.EditValue?.ToString());
                                    if (SelectedProduct != null)
                                    {
                                        string Size = SelectedProduct.Size?.ToString();
                                        txtPackageCode.Text = GetMaxPackage(Size);
                                    }
                                    ucDataButtonPackage_PrintHandler();
                                    StartAutoPrintMode();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtDacCode.Focus();
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Tem không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDacCode.Focus();
                }
            }
        }

        private void StartAutoPrintMode()
        {
            if (!ValidateData())
            {
                return;
            }
            DacPackageVM NewPackage = new DacPackageVM();
            NewPackage = CreateSaveData(NewPackage);
            NewPackage.LstDetails = new List<DacPackageDetails>();
            LstPackages.Add(NewPackage);
            gcPackage.RefreshDataSource();
            gvPackage.FocusedRowHandle = LstPackages.IndexOf(LstPackages.Last());
            EnableControls(false);
            AutoModeStatus = "Playing";
            txtDacCode.Enabled = true;
            ucDataButtonPackage.DataMode = DataState.Insert;
            btnStart.Enabled = false;
            txtDacCode.Focus();
        }
        #endregion
        private void ucDataButtonPackage_InsertHandler()
        {
            chkAutoPrintStamp.Enabled = false;
            // Lay gia tri Product va So luong de giu lai
            string ProductCode = lueProduct.EditValue?.ToString();
            string sSoLuong = ConfigurationManager.AppSettings["PackagedNumber"];
            txtQuantity.Text = sSoLuong;
            DacPackageVM NewPackage = new DacPackageVM();
            LstPackages.Add(NewPackage);
            gcPackage.RefreshDataSource();
            gvPackage.FocusedRowHandle = LstPackages.IndexOf(LstPackages.Last());
            EnableControls(true);
            gcPackage.Enabled = false;
            if (chkKeepProduct.Checked || AutoModeStatus == "Playing")
            {
                lueProduct.EditValue = ProductCode;
                if (lueProduct.EditValue != null && !string.IsNullOrEmpty(lueProduct.EditValue.ToString()))
                {
                    var SelectedProduct = LstProducts.FirstOrDefault(x => x.Code == lueProduct.EditValue.ToString());
                    if (SelectedProduct != null)
                    {
                        txtPackageCode.Text = GetMaxPackage(SelectedProduct.Size);
                    }
                }
            }
        }

        private void ucDataButtonPackage_SaveHandler()
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveDelegate;
            objCommon.App_ShowWaitForm(DataState.Insert);
            chkAutoPrintStamp.Enabled = true;
        }

        private void ucDataButtonPackage_EditHandler()
        {
            if (gvPackage.FocusedRowHandle >= 0)
            {
                chkAutoPrintStamp.Enabled = false;
                // Kiem tra quyen de Sua, Xoa hoac Them mã QR khi lenh xuat duoc khoa
                bool bActive = (bool)gvPackage.GetRowCellValue(gvPackage.FocusedRowHandle, "Active");
                if (!bActive) // Neu la false thi kiem tra quyen
                {
                    if (!CommonBS.IsAdminUser)
                    {
                        MessageBox.Show("Bạn không có quyền sửa thùng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ucDataButtonPackage.DataMode = DataState.View;
                        return;
                    }
                }
                gcPackage.Enabled = false;
                EnableControls(true);
            }
        }

        private void ucDataButtonPackage_DeleteHandler()
        {
            // Kiem tra quyen de Sua, Xoa hoac Them mã QR khi lenh xuat duoc khoa
            bool bActive = (bool)gvPackage.GetRowCellValue(gvPackage.FocusedRowHandle, "Active");
            if (!bActive) // Neu la false thi kiem tra quyen
            {
                if (!CommonBS.IsAdminUser)
                {
                    MessageBox.Show("Bạn không có quyền xóa thùng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucDataButtonPackage.DataMode = DataState.View;
                    return;
                }
            }
            if (gvPackage.FocusedRowHandle >= 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa thùng đã chọn?", "Xác nhận xóa thùng", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var result = _packageService.Delete(LstPackages[gvPackage.FocusedRowHandle].Id).ResponseData;
                    if (result)
                    {
                        StringBuilder sContent = new StringBuilder();
                        sContent.Append("Xóa thùng " + LstPackages[gvPackage.FocusedRowHandle].PackageCode);
                        sContent.Append("-");
                        sContent.Append(LstPackages[gvPackage.FocusedRowHandle].ProductCode);
                        sContent.Append("-");
                        sContent.Append(LstPackages[gvPackage.FocusedRowHandle].CreatedDate.Value.ToString("dd/MM/yyyy"));
                        if (LstPackages[gvPackage.FocusedRowHandle].LstDetails != null && LstPackages[gvPackage.FocusedRowHandle].LstDetails.Any())
                        {
                            sContent.Append(". Xóa các mã: ");
                            foreach (var detail in LstPackages[gvPackage.FocusedRowHandle].LstDetails)
                            {
                                sContent.Append(detail.DacCode);
                                sContent.Append(", ");
                            }
                        }
                        // Lưu nhật ký
                        CommonBO.Instance().TraceLogEvent(sContent.ToString(), CommonBS.CurrentUser.LoginID);
                        MessageBox.Show("Xóa thùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();

                    }
                    else
                    {
                        MessageBox.Show("Xóa thùng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ucDataButtonPackage_CancelHandler()
        {
            ucDataButtonPackage.DataMode = DataState.View;
            if (gvPackage.FocusedRowHandle >= 0 && originalObject != null)
            {
                LstPackages[gvPackage.FocusedRowHandle] = originalObject.Clone();
            }
            LoadData();
            gcPackage.Enabled = true;
            gcPackage.RefreshDataSource();
        }

        private void ucDataButtonPackage_CloseHandler()
        {
            if (ucDataButtonPackage.DataMode == DataState.Insert || ucDataButtonPackage.DataMode == DataState.Edit)
            {
                if (CommonCore.FormClosing("Bạn chưa lưu thùng này. Bạn có muốn lưu lại?"))
                {
                    if (SaveData())
                    {
                        Close();
                    }
                }
            }
            else
            {
                Close();
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            AddDetail();
        }

        private void buttonUpdateDetail_Click(object sender, EventArgs e)
        {
            // Kiem tra quyen de Sua, Xoa hoac Them mã QR khi lenh xuat duoc khoa
            bool? bActive = LstPackages[gvPackage.FocusedRowHandle].Active;
            if (!bActive.HasValue || !bActive.Value) // Neu la false thi kiem tra quyen
            {
                if (!CommonBS.IsAdminUser)
                {
                    MessageBox.Show("Bạn không có quyền sửa thùng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucDataButtonPackage.DataMode = DataState.View;
                    return;
                }
            }
            try
            {
                if (gvPackage.FocusedRowHandle >= 0 && LstPackages[gvPackage.FocusedRowHandle] != null && LstPackages[gvPackage.FocusedRowHandle].LstDetails != null)
                {
                    if (MessageBox.Show("Lưu ý rằng việc thêm các mã QR có thể sẽ cập nhật lại số lượng chỉ định trong thùng này. " +
                        "Bạn có xác nhận muốn tiếp tục?", "Xác nhận cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var LstNewDetail = LstPackages[gvPackage.FocusedRowHandle].LstDetails.Where(x => x.Id <= 0)?.ToList();
                        if (LstNewDetail != null && LstNewDetail.Any())
                        {
                            StringBuilder sContent = new StringBuilder();
                            sContent.Append("Thêm các mã: ");
                            for (int i = 0; i < LstNewDetail.Count; i++)
                            {
                                LstNewDetail[i].PackageId = LstPackages[gvPackage.FocusedRowHandle].Id;
                            }
                            if (_packageDetailService.AddRange(LstNewDetail).ResponseData)
                            {
                                lblProductCount.Text = "Số sản phẩm đã thêm: " + LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count;
                                sContent.Append(string.Join(",", LstNewDetail.Select(x => x.DacCode)?.ToList()));
                                try
                                {
                                    if (LstPackages[gvPackage.FocusedRowHandle] != null)
                                    {
                                        var EditedPackage = _packageService.GetDetail(LstPackages[gvPackage.FocusedRowHandle].Id).ResponseData;
                                        if (EditedPackage != null)
                                        {
                                            LstPackages[gvPackage.FocusedRowHandle].Quantity = EditedPackage.RealityQuantity;
                                            if (_packageService.Edit(LstPackages[gvPackage.FocusedRowHandle]).ResponseData != null)
                                            {
                                                txtQuantity.Text = LstPackages[gvPackage.FocusedRowHandle].Quantity.ToString();
                                                gcPackage.RefreshDataSource();
                                            }

                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Thêm thành công " + LstNewDetail.Count + " mã đã quét nhưng chưa cập nhật được số lượng chỉ định của thùng! " + ex.Message
                                        , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                sContent.Append("vào thùng " + LstPackages[gvPackage.FocusedRowHandle].PackageCode);
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

        private void buttonDetailDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiem tra quyen de Sua, Xoa hoac Them mã QR khi lenh xuat duoc khoa
                bool? bActive = LstPackages[gvPackage.FocusedRowHandle].Active;
                if (!bActive.HasValue || !bActive.Value) // Neu la false thi kiem tra quyen
                {
                    if (!CommonBS.IsAdminUser)
                    {
                        MessageBox.Show("Bạn không có quyền xóa thùng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ucDataButtonPackage.DataMode = DataState.View;
                        return;
                    }
                }
                int[] SelectedIndex = gvDetail.GetSelectedRows();
                if (gvPackage.FocusedRowHandle >= 0 && SelectedIndex != null && SelectedIndex.Length > 0)
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa các mã QR code đã chọn? Lưu ý rằng việc xóa các mã QR có thể sẽ cập nhật lại số lượng chỉ định trong thùng này. " +
                        "Bạn có xác nhận muốn tiếp tục?", "Xác nhận xóa mã", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (SelectedIndex.Length == LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count)
                        {
                            if (MessageBox.Show("Nếu bạn xóa tất cả mã QR trong thùng, thùng này sẽ bị xóa. Bạn có chắc chắn muốn xóa?", "Xác nhận xóa mã"
                                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                ucDataButtonPackage_DeleteHandler();
                            }
                        }
                        else
                        {
                            StringBuilder sContent = new StringBuilder();
                            sContent.Append("Xóa mã: ");
                            var LstDelete = LstPackages[gvPackage.FocusedRowHandle].LstDetails
                                .Where(x => SelectedIndex.Contains(LstPackages[gvPackage.FocusedRowHandle].LstDetails.IndexOf(x)))?.Select(x => x.DacCode)?.ToList();
                            if (LstDelete != null)
                            {
                                var result = _packageDetailService.DeleteByDacCode(LstDelete).ResponseData;
                                if (result)
                                {
                                    sContent.Append(string.Join(",", LstDelete));
                                    for (int i = 0; i < LstDelete.Count; i++)
                                    {
                                        var RemoveDetail = LstPackages[gvPackage.FocusedRowHandle].LstDetails.FirstOrDefault(x => x.DacCode == LstDelete[i]);
                                        if (RemoveDetail != null)
                                        {
                                            LstPackages[gvPackage.FocusedRowHandle].LstDetails.Remove(RemoveDetail);
                                        }
                                    }
                                    for (int i = 0; i < SelectedIndex.Length; i++)
                                    {
                                        gvDetail.UnselectRow(SelectedIndex[i]);
                                    }
                                    lblProductCount.Text = "Số sản phẩm đã thêm: " + LstPackages[gvPackage.FocusedRowHandle].LstDetails.Count;
                                    if (LstPackages[gvPackage.FocusedRowHandle] != null)
                                    {
                                        var EditedPackage = _packageService.GetDetail(LstPackages[gvPackage.FocusedRowHandle].Id).ResponseData;
                                        if (EditedPackage != null)
                                        {
                                            LstPackages[gvPackage.FocusedRowHandle].Quantity = EditedPackage.RealityQuantity;
                                            txtQuantity.Text = LstPackages[gvPackage.FocusedRowHandle].Quantity.ToString();
                                            gcPackage.RefreshDataSource();
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

        private void ucDataButtonPackage_PrintHandler()
        {
            if (gvPackage.FocusedRowHandle >= 0 && LstPackages[gvPackage.FocusedRowHandle] != null)
            {
                PIPT.Report.PackageQRCode rpt = new PIPT.Report.PackageQRCode();
                DacPackageVM Package = LstPackages[gvPackage.FocusedRowHandle];
                Package.NgaySanXuat = dtpNgaySX.Value;
                Package.Description = lueProduct.Text;
                rpt.CreateQRCode(Package);
                if (chkPreview.Checked)
                {
                    rpt.ShowPreview();
                }
                else
                {
                    rpt.CreateDocument();
                    rpt.Print();
                }
            }
        }

        private void addSerialCodeButton_Click(object sender, EventArgs e)
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartAutoPrintMode();
        }
    }
}
