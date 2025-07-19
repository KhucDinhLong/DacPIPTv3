using DAC.Core;
using DAC.Core.Common;
using DAC.Core.Security;
using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmUser : Form
    {
        #region "Variables"
        private ISecUsersService _userService;
        private IDacCustomerService _agencyService;
        private ISecGroupsService _groupService;
        private List<DacCustomerVM> LstAgency;
        private List<SecUsersVM> LstUser;
        private List<SecGroups> LstGroup;
        #endregion
        #region Form's Events
        public frmUser(ISecUsersService userService, IDacCustomerService agencyService, ISecGroupsService groupsService)
        {
            InitializeComponent();
            _userService = userService;
            _agencyService = agencyService;
            _groupService = groupsService;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            if (LstUser == null || gvUser.FocusedRowHandle < 0 || LstUser.Count <= gvUser.FocusedRowHandle)
            {
                MessageBox.Show("Không tìm thấy tài khoản cần reset mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var UpdateResult = _userService.ResetPassword(LstUser[gvUser.FocusedRowHandle].LoginID, CommonUtils.EncryptString(txtPassword.Text));
            if (UpdateResult.ResponseData)
            {
                MessageBox.Show("Reset mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Reset mật khẩu không thành công! " + UpdateResult.ex?.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (LstUser != null && LstUser.Any() && gvUser.FocusedRowHandle >= 0 && LstUser.Count >= gvUser.FocusedRowHandle)
            {
                txtUserName.Text = LstUser[gvUser.FocusedRowHandle].LoginID;
                txtEmployeeName.Text = LstUser[gvUser.FocusedRowHandle].FullName;
                txtEmail.Text = LstUser[gvUser.FocusedRowHandle].Email;
                lueAgency.EditValue = LstUser[gvUser.FocusedRowHandle].CustomerCode;
                chkLocked.Checked = LstUser[gvUser.FocusedRowHandle].LockedUser.HasValue ? LstUser[gvUser.FocusedRowHandle].LockedUser.Value : false;
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
                dtpEndDate.Value = LstUser[gvUser.FocusedRowHandle].DeadlineOfUsing.HasValue ? LstUser[gvUser.FocusedRowHandle].DeadlineOfUsing.Value : dtpEndDate.MaxDate;
                if (LstGroup != null && LstGroup.Any())
                {
                    for (int i = 0; i < LstGroup.Count; i++)
                    {
                        if (LstUser[gvUser.FocusedRowHandle].LstGroup?.FirstOrDefault(x => x.GroupId == LstGroup[i].GroupId) != null)
                        {
                            chkLstGroup.SetItemChecked(i, true);
                        }
                        else
                        {
                            chkLstGroup.SetItemChecked(i, false);
                        }
                    }
                }
            }
        }

        private void chkLocked_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ucDataButtonUser.DataMode != DataState.View)
                txtLockedReason.Enabled = chkLocked.Checked;
        }
        #endregion
        #region Functions
        private void LoadData()
        {
            LstUser = _userService.GetAll().ResponseData;
            LstAgency = _agencyService.GetAll().ResponseData;
            LstGroup = _groupService.GetAll().ResponseData;
            SetDataForCheckListGroup();
            lueAgency.Properties.DataSource = LstAgency;
            lueAgency.Properties.ValueMember = "Code";
            lueAgency.Properties.DisplayMember = "Name";
            gcUser.DataSource = LstUser;
            if (LstUser != null && LstUser.Any())
            {
                gvUser.FocusedRowHandle = 0;
            }
            EnableControls(false);
        }

        private void SetDataForCheckListGroup()
        {
            if (LstGroup != null && LstGroup.Any())
            {
                chkLstGroup.Items.Clear();
                string sText = String.Empty;
                for (int i = 0; i < LstGroup.Count; i++)
                {
                    CheckedListBoxItem checkedListBox = new CheckedListBoxItem();
                    checkedListBox.Text = LstGroup[i].GroupName;
                    checkedListBox.Tag = LstGroup[i];
                    chkLstGroup.Items.Add(checkedListBox);
                    if (sText.Length < checkedListBox.Text.Length)
                    {
                        sText = checkedListBox.Text;
                    }
                }

                SizeF stringSize = new SizeF();
                Graphics g = this.CreateGraphics();
                stringSize = g.MeasureString(sText, chkLstGroup.Font);
                chkLstGroup.ColumnWidth = (int)stringSize.Width + 20;
            }
        }

        private void EnableControls(bool bIsEnabled)
        {
            if (ucDataButtonUser.DataMode != DataState.Edit)
                txtUserName.Enabled = bIsEnabled;
            else
                txtUserName.Enabled = false;
            txtEmployeeName.Enabled = bIsEnabled;
            txtEmail.Enabled = bIsEnabled;
            chkLocked.Enabled = bIsEnabled;
            txtLockedReason.Enabled = chkLocked.Checked && bIsEnabled;
            dtpEndDate.Enabled = bIsEnabled;
            chkLstGroup.Enabled = bIsEnabled;
            lueAgency.Enabled = bIsEnabled;
            if (bIsEnabled)
                chkLstGroup.BackColor = Color.White;
            else
                chkLstGroup.BackColor = Color.FromName("Control");
        }

        /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return false;
            }
            if (ucDataButtonUser.DataMode == DataState.Insert && _userService.Exists(txtUserName.Text).ResponseData)
            {
                MessageBox.Show("Tên tài khoản này đã tồn tại!", "Thông báo" + Common.formSoftName);
                txtUserName.Focus();
                return false;
            }

            if (ucDataButtonUser.DataMode == DataState.Insert && txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmployeeName.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Save data into DB
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            if (ValidateData())
            {
                SecUsersVM user = CreateSaveData();
                if (ucDataButtonUser.DataMode == DataState.Insert)
                {
                    user = _userService.Create(user).ResponseData;
                }
                else
                {
                    user = _userService.Edit(user).ResponseData;
                }
                return user != null;
            }
            return false;
        }

        private SecUsersVM CreateSaveData()
        {
            SecUsersVM user = new SecUsersVM();
            user.LoginID = txtUserName.Text;
            user.Password = ucDataButtonUser.DataMode == DataState.Insert ? CommonUtils.EncryptString(txtPassword.Text) : LstUser[gvUser.FocusedRowHandle].Password;
            user.FullName = txtEmployeeName.Text;
            user.Email = txtEmail.Text;
            user.CustomerCode = lueAgency.EditValue?.ToString();
            user.LockedUser = chkLocked.Checked;
            user.Email = txtEmail.Text;
            user.DeadlineOfUsing = dtpEndDate.Value;
            user.LockedReason = txtLockedReason.Text;
            user.LockedDate = chkLocked.Checked ? (DateTime?)DateTime.Now : null;
            user.CreatedDate = ucDataButtonUser.DataMode == DataState.Insert ? DateTime.Now : LstUser[gvUser.FocusedRowHandle].CreatedDate;
            if (chkLstGroup.CheckedIndices != null && chkLstGroup.CheckedIndices.Count > 0)
            {
                user.LstGroup = new List<SecGroups>();
                for (int i = 0; i < chkLstGroup.CheckedIndices.Count; i++)
                {
                    var checkedItem = (CheckedListBoxItem)chkLstGroup.Items[chkLstGroup.CheckedIndices[i]];
                    var group = LstGroup.FirstOrDefault(x => x.GroupId == ((SecGroups)checkedItem.Tag).GroupId);
                    if (group != null)
                    {
                        user.LstGroup.Add(group);
                    }
                }
            }
            return user;
        }
        #endregion
        #region Buttons click
        private void ucDataButtonUser_InsertHander()
        {
            EnableControls(true);
            SecUsersVM NewUser = new SecUsersVM();
            NewUser.LockedUser = false;
            LstUser.Add(NewUser);
            gcUser.RefreshDataSource();
            gvUser.FocusedRowHandle = LstUser.IndexOf(LstUser.Last());
            txtUserName.Focus();
        }

        private void ucDataButtonUser_EditHandler()
        {
            EnableControls(true);
            txtUserName.Focus();
        }

        private void ucDataButtonUser_DeleteHandler()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (gvUser.FocusedRowHandle < 0 || LstUser == null || LstUser.Count - 1 < gvUser.FocusedRowHandle || LstUser[gvUser.FocusedRowHandle] == null)
                {
                    MessageBox.Show("Không tìm thấy người dùng cần xóa!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool result = _userService.Delete(LstUser[gvUser.FocusedRowHandle].LoginID).ResponseData;
                if (result)
                {
                    MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa người dùng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ucDataButtonUser_CancelHandler()
        {
            EnableControls(false);
            if (ucDataButtonUser.DataMode == DataState.Insert)
            {
                if (gvUser.RowCount > 1)
                {
                    gvUser.DeleteRow(gvUser.FocusedRowHandle);
                }
            }
            ucDataButtonUser.DataMode = DataState.View;
        }

        private void ucDataButtonUser_SaveHandler()
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveUser;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void SaveUser()
        {
            if (SaveData())
            {
                if (ucDataButtonUser.DataMode == DataState.Insert)
                {
                    MessageBox.Show("Thêm mới người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommonBO.Instance().TraceLogEvent("Save user: " + txtUserName.Text, CommonBS.CurrentUser.LoginID);
                }
                else if (ucDataButtonUser.DataMode == DataState.Edit)
                {
                    MessageBox.Show("Cập nhật thông tin người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Lưu nhật ký
                    CommonBO.Instance().TraceLogEvent("Edit Store: " + txtUserName.Text, CommonBS.CurrentUser.LoginID);
                }
                LoadData();
                ucDataButtonUser.DataMode = DataState.View;
            }
            else CommonBS.SaveNotSuccessfully();
        }

        private void ucDataButtonUser_CloseHandler()
        {
            if (ucDataButtonUser.DataMode == DataState.Insert || ucDataButtonUser.DataMode == DataState.Edit)
            {
                if (CommonBS.ConfirmChangedData() == DialogResult.Yes)
                {
                    if (SaveData() == false)
                        return;
                }
            }
            Close();
        }
        #endregion
    }
}
