using AnyClone;
using DAC.Core;
using DAC.Core.Common;
using DAC.Core.Security;
using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacStore : Form
    {
        #region Variables
        IDacCustomerService _agencyService;
        IProvinceService _provinceService;
        IDacStoreService _storeService;
        List<DacCustomerVM> LstAgency;
        List<DacStoreVM> LstStore;
        List<Province> LstProvince;
        DacStoreVM originalObject;
        #endregion
        #region Form's Events
        public frmDacStore(IDacCustomerService agencyService, IProvinceService provinceService, IDacStoreService storeService)
        {
            InitializeComponent();
            _agencyService = agencyService;
            _storeService = storeService;
            _provinceService = provinceService;
        }
        private void frmDacStore_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var CurrentUser = Session.CurrentUser;
            if (CurrentUser != null)
            {
                LstAgency = _agencyService.GetAll().ResponseData ?? new List<DacCustomerVM>();
                LstStore = _storeService.GetAll().ResponseData?.ToList();
                if (!CurrentUser.isAdmin.HasValue || !CurrentUser.isAdmin.Value)
                {
                    LstStore = LstStore?.Where(x => x.AgencyCode == CurrentUser.AgencyCode)?.ToList();
                }
                LstProvince = _provinceService.GetAll().ResponseData ?? new List<Province>();
                lueAgency.Properties.DataSource = LstAgency;
                lueAgency.Properties.ValueMember = "Code";
                lueAgency.Properties.DisplayMember = "Name";
                lueProvince.Properties.DataSource = LstProvince;
                lueProvince.Properties.ValueMember = "Code";
                lueProvince.Properties.DisplayMember = "Name";
                gcStore.DataSource = LstStore;
                if (LstStore != null && LstStore.Any())
                {
                    gvStore.FocusedRowHandle = 0;
                    originalObject = LstStore[gvStore.FocusedRowHandle].Clone();
                }
                EnableControls(false);
            }
        }
        #endregion
        #region Functions on Form
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelStore.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonStore.DataMode == DataState.Edit)
            {
                txtStoreCode.Enabled = false;
            }
        }

        private bool ValidateData()
        {
            if (gvStore.FocusedRowHandle < 0 || LstStore == null || LstStore.Count - 1 < gvStore.FocusedRowHandle || LstStore[gvStore.FocusedRowHandle] == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu cần xử lý!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtStoreCode.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã cửa hàng!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStoreCode.Focus();
                return false;
            }
            if (ucDataButtonStore.DataMode == DataState.Insert && _storeService.GetByCode(txtStoreCode.Text).ResponseData != null)
            {
                MessageBox.Show("Mã cửa hàng này đã tồn tại!", "Thông báo" + Common.formSoftName);
                txtStoreCode.SelectAll();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtStoreName.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên cửa hàng!", "Thông báo" + Common.formSoftName);
                txtStoreName.Focus();
                return false;
            }
            return true;
        }
        
        private bool SaveData()
        {
            if (ValidateData())
            {
                DacStore store = CreateSaveData();
                if (ucDataButtonStore.DataMode == DataState.Insert)
                {
                    store = _storeService.Create(store).ResponseData;
                    return store != null && store.Id > 0;
                }
                else
                {
                    store = _storeService.Edit(store).ResponseData;
                    return store != null;
                }
            }
            return false;
        }

        private DacStore CreateSaveData()
        {
            DacStore store = new DacStore();
            store.Id = ucDataButtonStore.DataMode == DataState.Edit ? LstStore[gvStore.FocusedRowHandle].Id : 0;
            store.Code = ucDataButtonStore.DataMode == DataState.Insert ? txtStoreName.Text : LstStore[gvStore.FocusedRowHandle].Code;
            store.Name = txtStoreName.Text;
            store.Address = txtAddress.Text;
            store.ProvinceCode = lueProvince.EditValue?.ToString();
            store.ShopKeeper = txtShopKeeper.Text;
            store.AgencyCode = lueAgency.EditValue?.ToString();
            store.Email = txtEmail.Text;
            store.PhoneNum = txtPhoneNum.Text;
            store.Active = chkActive.Checked;
            store.Description = txtDescription.Text;
            store.MobileNum = txtMobileNum.Text;
            store.CreatedUser = ucDataButtonStore.DataMode == DataState.Insert ? CommonBS.CurrentUser.LoginID : LstStore[gvStore.FocusedRowHandle].CreatedUser;
            store.ModifiedUser = ucDataButtonStore.DataMode == DataState.Edit ? CommonBS.CurrentUser.LoginID : LstStore[gvStore.FocusedRowHandle].ModifiedUser;
            store.CreatedDate = ucDataButtonStore.DataMode == DataState.Insert ? DateTime.Now : LstStore[gvStore.FocusedRowHandle].CreatedDate;
            store.ModifiedDate = ucDataButtonStore.DataMode == DataState.Edit ? DateTime.Now : LstStore[gvStore.FocusedRowHandle].ModifiedDate;
            return store;
        }

        private void SaveStore()
        {
            if (SaveData())
            {
                if (ucDataButtonStore.DataMode == DataState.Insert)
                {
                    MessageBox.Show("Thêm mới cửa hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommonBO.Instance().TraceLogEvent("Save Store: " + txtStoreCode.Text + " - " + txtStoreName.Text, CommonBS.CurrentUser.LoginID);
                }
                else if (ucDataButtonStore.DataMode == DataState.Edit)
                {
                    MessageBox.Show("Cập nhật thông tin cửa hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Lưu nhật ký
                    CommonBO.Instance().TraceLogEvent("Edit Store: " + txtStoreCode.Text + " - " + txtStoreName.Text, CommonBS.CurrentUser.LoginID);
                }
                LoadData();
                ucDataButtonStore.DataMode = DataState.View;
            }
            else CommonBS.SaveNotSuccessfully();
        }

        private void gvStore_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvStore.FocusedRowHandle >= 0 && LstStore[gvStore.FocusedRowHandle] != null)
            {
                txtStoreCode.Text = LstStore[gvStore.FocusedRowHandle].Code;
                txtStoreName.Text = LstStore[gvStore.FocusedRowHandle].Name;
                txtAddress.Text = LstStore[gvStore.FocusedRowHandle].Address;
                lueProvince.EditValue = LstStore[gvStore.FocusedRowHandle].ProvinceCode;
                txtShopKeeper.Text = LstStore[gvStore.FocusedRowHandle].ShopKeeper;
                lueAgency.EditValue = LstStore[gvStore.FocusedRowHandle].AgencyCode;
                txtEmail.Text = LstStore[gvStore.FocusedRowHandle].Email;
                lblCreatedDate.Text = LstStore[gvStore.FocusedRowHandle].CreatedDate.HasValue ? LstStore[gvStore.FocusedRowHandle].CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                lblModifiedDate.Text = LstStore[gvStore.FocusedRowHandle].ModifiedDate.HasValue ? LstStore[gvStore.FocusedRowHandle].ModifiedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                txtDescription.Text = LstStore[gvStore.FocusedRowHandle].Description;
                txtPhoneNum.Text = LstStore[gvStore.FocusedRowHandle].PhoneNum;
                txtMobileNum.Text = LstStore[gvStore.FocusedRowHandle].MobileNum;
                chkActive.Checked = LstStore[gvStore.FocusedRowHandle].Active.HasValue ? LstStore[gvStore.FocusedRowHandle].Active.Value : false;
                originalObject = LstStore[gvStore.FocusedRowHandle].Clone();
            }
            else
            {
                originalObject = null;
            }
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonAgency_InsertHandler()
        {
            DacStoreVM NewStore = new DacStoreVM();
            NewStore.CreatedUser = CommonBS.CurrentUser.LoginID;
            NewStore.Active = true;
            LstStore.Add(NewStore);
            gcStore.RefreshDataSource();
            gvStore.FocusedRowHandle = LstStore.IndexOf(LstStore.Last());
            EnableControls(true);
            txtStoreCode.Focus();
        }

        private void ucDataButtonAgency_SaveHandler()
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveStore;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonAgency_EditHandler()
        {
            EnableControls(true);
            txtStoreName.Focus();
        }

        private void ucDataButtonAgency_DeleteHandler()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa cửa hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (gvStore.FocusedRowHandle < 0 || LstStore == null || LstStore.Count - 1 < gvStore.FocusedRowHandle || LstStore[gvStore.FocusedRowHandle] == null)
                {
                    MessageBox.Show("Không tìm thấy cửa hàng cần xóa!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_storeService.HasUsed(LstStore[gvStore.FocusedRowHandle].Code).ResponseData)
                {
                    MessageBox.Show("Cửa hàng này đã được sử dụng, bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool result = _storeService.Delete(LstStore[gvStore.FocusedRowHandle].Id).ResponseData;
                    if (result)
                    {
                        MessageBox.Show("Xóa cửa hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa cửa hàng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ucDataButtonAgency_CancelHandler()
        {
            EnableControls(false);
            if (ucDataButtonStore.DataMode == DataState.Insert)
            {
                if (gvStore.RowCount > 1)
                {
                    gvStore.DeleteRow(gvStore.FocusedRowHandle);
                    gvStore.FocusedRowHandle = 0;
                }
            }
            ucDataButtonStore.DataMode = DataState.View;
        }

        private void ucDataButtonAgency_CloseHandler()
        {
            if (ucDataButtonStore.DataMode == DataState.Insert || ucDataButtonStore.DataMode == DataState.Edit)
            {
                if (CommonBS.ConfirmChangedData() == DialogResult.Yes)
                {
                    if (SaveData() == false)
                        return;
                }
            }
            else
            {
                if (gvStore.FocusedRowHandle >= 0 && originalObject != null)
                {
                    LstStore[gvStore.FocusedRowHandle] = originalObject.Clone();
                    originalObject = null;
                    if (gvStore.FocusedRowHandle >= 0)
                    {
                        gvStore_FocusedRowChanged(ucDataButtonStore, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(gvStore.FocusedRowHandle, gvStore.FocusedRowHandle));
                    }
                }
            }
            Close();
        }
        private void ucDataButtonAgency_ExcelHandler()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Excel 2007-2016(*.xlsx)|*.xlsx";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                gvStore.ExportToXlsx(fileDialog.FileName);
            }
        }
        #endregion

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
        }
        private void CopyToGridControl(string data)
        {
            
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string FilePath = ofd.FileName;
                        if (!File.Exists(FilePath))
                        {
                            MessageBox.Show("File không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        var ImportedResult = _storeService.ImportFromExcel(FilePath, CommonBS.CurrentUser.LoginID);
                        if (ImportedResult.ex == null)
                        {
                            MessageBox.Show("Thêm thành công " + ImportedResult.ResponseData + " cửa hàng mới!" + ImportedResult.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra trong quá trình import dữ liệu: " + ImportedResult.ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, không thể hoàn thành thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
