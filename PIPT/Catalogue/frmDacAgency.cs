using AnyClone;
using DAC.Core;
using DAC.Core.Common;
using DAC.Core.Security;
using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacAgency : Form
    {
        #region Variables
        IDacCustomerService _agencyService;
        IProvinceService _provinceService;
        IDacRegionService _regionService;
        List<DacCustomerVM> LstAllAgency;
        List<DacCustomerVM> LstAgency;
        List<DacRegion> LstRegion;
        List<Province> LstProvince;
        DacCustomerVM originalObject;
        #endregion
        #region Form's Events
        public frmDacAgency(IDacCustomerService agencyService, IProvinceService provinceService, IDacRegionService regionService)
        {
            InitializeComponent();
            _agencyService = agencyService;
            _provinceService = provinceService;
            _regionService = regionService;
        }
        private void frmDacAgency_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            LstAllAgency = _agencyService.GetAll().ResponseData?.ToList();
            LstRegion = _regionService.GetAll().ResponseData ?? new List<DacRegion>();
            LstProvince = _provinceService.GetAll().ResponseData ?? new List<Province>();
            lueProvince.Properties.DataSource = LstProvince;
            lueProvince.Properties.ValueMember = "Code";
            lueProvince.Properties.DisplayMember = "Name";
            lueRegion.Properties.DataSource = LstRegion;
            lueRegion.Properties.ValueMember = "Code";
            lueRegion.Properties.DisplayMember = "Name";
            if (!Session.CurrentUser.isAdmin.HasValue || !Session.CurrentUser.isAdmin.Value)
            {
                lblDependCode.Visible = false;
                lueDependCode.Visible = false;
                LstAgency = LstAllAgency?.Where(x => x.DependCode == Session.CurrentUser.CustomerCode)?.ToList();
            }
            else
            {
                lblDependCode.Visible = true;
                lueDependCode.Visible = true;
                lueDependCode.Properties.DataSource = LstAllAgency ?? new List<DacCustomerVM>();
                lueDependCode.Properties.ValueMember = "Code";
                lueDependCode.Properties.DisplayMember = "Name";
                LstAgency = LstAllAgency;
            }
            gcAgency.DataSource = LstAgency;
            if (LstAgency != null && LstAgency.Any())
            {
                gvAgency.FocusedRowHandle = 0;
                originalObject = LstAgency[gvAgency.FocusedRowHandle];
            }
            EnableControls(false);
        }
        #endregion
        #region Functions on Form
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelAgency.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonAgency.DataMode == DataState.Edit)
            {
                txtAgencyCode.Enabled = false;
            }
        }

        private bool ValidateData()
        {
            if (gvAgency.FocusedRowHandle < 0 || LstAgency == null || LstAgency.Count - 1 < gvAgency.FocusedRowHandle || LstAgency[gvAgency.FocusedRowHandle] == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu cần xử lý!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAgencyCode.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã đại lý!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAgencyCode.Focus();
                return false;
            }
            if (ucDataButtonAgency.DataMode == DataState.Insert && _agencyService.GetByCode(txtAgencyCode.Text).ResponseData != null)
            {
                MessageBox.Show("Mã đại lý này đã tồn tại!", "Thông báo" + Common.formSoftName);
                txtAgencyCode.SelectAll();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAgencyName.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên đại lý!", "Thông báo" + Common.formSoftName);
                txtAgencyName.Focus();
                return false;
            }
            return true;
        }

        private bool SaveData()
        {
            if (ValidateData())
            {
                DacCustomer agency = CreateSaveData();
                if (ucDataButtonAgency.DataMode == DataState.Insert)
                {
                    agency = _agencyService.Create(agency).ResponseData;
                    return agency != null && agency.Id > 0;
                }
                else
                {
                    agency = _agencyService.Edit(agency).ResponseData;
                    return agency != null;
                }
            }
            return false;
        }

        private DacCustomer CreateSaveData()
        {
            DacCustomer agency = new DacCustomer();
            agency.Id = ucDataButtonAgency.DataMode == DataState.Edit ? LstAgency[gvAgency.FocusedRowHandle].Id : 0;
            agency.Code = ucDataButtonAgency.DataMode == DataState.Insert ? txtAgencyCode.Text : LstAgency[gvAgency.FocusedRowHandle].Code;
            agency.Name = txtAgencyName.Text;
            agency.Address = txtAddress.Text;
            agency.ProvinceCode = lueProvince.EditValue?.ToString();
            agency.Region = lueRegion.EditValue?.ToString();
            agency.OwnerName = txtOwnerName.Text;
            agency.TaxCode = txtTaxCode.Text;
            agency.JoinContact = txtJoinContact.Text;
            agency.DependCode = Session.CurrentUser.isAdmin.HasValue && Session.CurrentUser.isAdmin.Value ? lueDependCode.EditValue?.ToString() : Session.CurrentUser.CustomerCode;
            agency.Email = txtEmail.Text;
            agency.Active = chkActive.Checked;
            agency.Description = txtDescription.Text;
            agency.PhoneNum = txtPhoneNum.Text;
            agency.MobileNum = txtMobileNum.Text;
            agency.CreatedUser = ucDataButtonAgency.DataMode == DataState.Insert ? CommonBS.CurrentUser.LoginID : LstAgency[gvAgency.FocusedRowHandle].CreatedUser;
            agency.ModifiedUser = ucDataButtonAgency.DataMode == DataState.Edit ? CommonBS.CurrentUser.LoginID : LstAgency[gvAgency.FocusedRowHandle].ModifiedUser;
            agency.CreatedDate = ucDataButtonAgency.DataMode == DataState.Insert ? DateTime.Now : LstAgency[gvAgency.FocusedRowHandle].CreatedDate;
            agency.ModifiedDate = ucDataButtonAgency.DataMode == DataState.Edit ? DateTime.Now : LstAgency[gvAgency.FocusedRowHandle].ModifiedDate;
            return agency;
        }

        private void SaveAgency()
        {
            if (SaveData())
            {
                if (ucDataButtonAgency.DataMode == DataState.Insert)
                {
                    MessageBox.Show("Thêm mới đại lý thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommonBO.Instance().TraceLogEvent("Save Agency: " + txtAgencyCode.Text + " - " + txtAgencyName.Text, CommonBS.CurrentUser.LoginID);
                }
                else if (ucDataButtonAgency.DataMode == DataState.Edit)
                {
                    MessageBox.Show("Cập nhật thông tin đại lý thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Lưu nhật ký
                    CommonBO.Instance().TraceLogEvent("Edit Agency: " + txtAgencyCode.Text + " - " + txtAgencyName.Text, CommonBS.CurrentUser.LoginID);
                }
                LoadData();
                ucDataButtonAgency.DataMode = DataState.View;
            }
            else CommonBS.SaveNotSuccessfully();
        }

        private void gvAgency_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvAgency.FocusedRowHandle >= 0 && LstAgency[gvAgency.FocusedRowHandle] != null)
            {
                txtAgencyCode.Text = LstAgency[gvAgency.FocusedRowHandle].Code;
                txtAgencyName.Text = LstAgency[gvAgency.FocusedRowHandle].Name;
                txtAddress.Text = LstAgency[gvAgency.FocusedRowHandle].Address;
                lueProvince.EditValue = LstAgency[gvAgency.FocusedRowHandle].ProvinceCode;
                lueRegion.EditValue = LstAgency[gvAgency.FocusedRowHandle].Region;
                txtOwnerName.Text = LstAgency[gvAgency.FocusedRowHandle].OwnerName;
                txtTaxCode.Text = LstAgency[gvAgency.FocusedRowHandle].TaxCode;
                txtJoinContact.Text = LstAgency[gvAgency.FocusedRowHandle].JoinContact;
                lueDependCode.EditValue = LstAgency[gvAgency.FocusedRowHandle].DependCode;
                txtEmail.Text = LstAgency[gvAgency.FocusedRowHandle].Email;
                lblCreatedDate.Text = LstAgency[gvAgency.FocusedRowHandle].CreatedDate.HasValue ? LstAgency[gvAgency.FocusedRowHandle].CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                lblModifiedDate.Text = LstAgency[gvAgency.FocusedRowHandle].ModifiedDate.HasValue ? LstAgency[gvAgency.FocusedRowHandle].ModifiedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                txtDescription.Text = LstAgency[gvAgency.FocusedRowHandle].Description;
                txtPhoneNum.Text = LstAgency[gvAgency.FocusedRowHandle].PhoneNum;
                txtMobileNum.Text = LstAgency[gvAgency.FocusedRowHandle].MobileNum;
                chkActive.Checked = LstAgency[gvAgency.FocusedRowHandle].Active.HasValue ? LstAgency[gvAgency.FocusedRowHandle].Active.Value : false;
                originalObject = LstAgency[gvAgency.FocusedRowHandle].Clone();
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
            DacCustomerVM NewAgency = new DacCustomerVM();
            NewAgency.CreatedUser = CommonBS.CurrentUser.LoginID;
            NewAgency.Active = true;
            LstAgency.Add(NewAgency);
            gcAgency.RefreshDataSource();
            gvAgency.FocusedRowHandle = LstAgency.IndexOf(LstAgency.Last());
            EnableControls(true);
            txtAgencyCode.Focus();
        }

        private void ucDataButtonAgency_SaveHandler()
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveAgency;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonAgency_EditHandler()
        {
            EnableControls(true);
            txtAgencyCode.Focus();
        }

        private void ucDataButtonAgency_DeleteHandler()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa đại lý này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (gvAgency.FocusedRowHandle < 0 || LstAgency == null || LstAgency.Count - 1 < gvAgency.FocusedRowHandle || LstAgency[gvAgency.FocusedRowHandle] == null)
                {
                    MessageBox.Show("Không tìm thấy đại lý cần xóa!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_agencyService.HasUsed(LstAgency[gvAgency.FocusedRowHandle].Code).ResponseData)
                {
                    MessageBox.Show("Đại lý này đã được sử dụng, bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool result = _agencyService.Delete(LstAgency[gvAgency.FocusedRowHandle].Id).ResponseData;
                    if (result)
                    {
                        MessageBox.Show("Xóa đại lý thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đại lý không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ucDataButtonAgency_CancelHandler()
        {
            EnableControls(false);
            if (ucDataButtonAgency.DataMode == DataState.Insert)
            {
                if (gvAgency.RowCount > 1)
                {
                    gvAgency.DeleteRow(gvAgency.FocusedRowHandle);
                    gvAgency.FocusedRowHandle = 0;
                }
            }
            else
            {
                if (gvAgency.FocusedRowHandle >= 0 && originalObject != null)
                {
                    LstAgency[gvAgency.FocusedRowHandle] = originalObject.Clone();
                    originalObject = null;
                    if (gvAgency.FocusedRowHandle >= 0)
                    {
                        gvAgency_FocusedRowChanged(ucDataButtonAgency, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(gvAgency.FocusedRowHandle, gvAgency.FocusedRowHandle));
                    }
                }
            }
            ucDataButtonAgency.DataMode = DataState.View;
        }

        private void ucDataButtonAgency_CloseHandler()
        {
            if (ucDataButtonAgency.DataMode == DataState.Insert || ucDataButtonAgency.DataMode == DataState.Edit)
            {
                if (CommonBS.ConfirmChangedData() == DialogResult.Yes)
                {
                    if (SaveData() == false)
                        return;
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
                gvAgency.ExportToXlsx(fileDialog.FileName);
            }
        }
        #endregion

        private void buttonImport_Click(object sender, EventArgs e)
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
                        var ImportedResult = _agencyService.ImportFromExcel(FilePath, CommonBS.CurrentUser.LoginID);
                        if (ImportedResult.ex == null)
                        {
                            MessageBox.Show("Thêm thành công " + ImportedResult.ResponseData + " đại lý mới!" + ImportedResult.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
