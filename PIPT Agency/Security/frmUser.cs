using DAC.Core;
using DAC.Core.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIPT.Agency
{
    public partial class frmUser : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmUser _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmUser Instance()
        {
            if(_instance == null || _instance.IsDisposed)
            {
                _instance = new frmUser();
            }
            return _instance;
        }

        public static frmUser Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmUser Instance(Form parent, bool isActivate)
        {
            _instance = Instance(parent);
            if(isActivate)
            {
                _instance.WindowState = FormWindowState.Normal;
                _instance.Show();
                _instance.Activate();
            }
            return _instance;
        }
        #endregion
        #region "Variables"
        private UserBS userBS;
        private GroupBS groupBS;
        private User objSelectedUser;
        private UserCollection userCollection;
        private GroupUserBS groupUserBS;
        private List<GroupUser> lstInitialGroupUser = new List<GroupUser>();
        private List<GroupUser> lstAddedGroupUser = new List<GroupUser>();
        private List<GroupUser> lstDeletedGroupUser = new List<GroupUser>();

        private bool bIsBindingData = true;
        private bool bIsClosed = false;
        private DateTime dtmNow;
        private DateTime dtmMaxDate = new DateTime(9999, 12, 31);
        private Common objCommon = new Common();
        #endregion
        #region Form's Events
        public frmUser()
        {
            InitializeComponent();
            objCommon.CurrentForm = this;
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            userBS = new UserBS();
            groupBS = new GroupBS();
            groupUserBS = new GroupUserBS();

            dataGridViewUser.AutoGenerateColumns = false;

            SetGridViewDataSource();
            SetDataForCheckListGroup();

            SetAuthorization();
        }
        private void frmUser_Shown(object sender, EventArgs e)
        {
            bIsBindingData = false;
            EnableControls(false);

            if (dataGridViewUser.RowCount > 0)
            {
                dataGridViewUser.ClearSelection();
                dataGridViewUser.Rows[0].Selected = true;
            }
        }
        #endregion
        #region Functions
        private void SetAuthorization()
        {
            ucDataButtonUser.AddNewVisible = userBS.IsAuthorized(UserBS.UserAction.Insert);
            ucDataButtonUser.AddNewVisible = userBS.IsAuthorized(UserBS.UserAction.Update);
            ucDataButtonUser.AddNewVisible = userBS.IsAuthorized(UserBS.UserAction.Delete);
            //ucDataButtonUser.MultiLanguageVisible = userBS.IsAuthorized(UserBS.UserAction.MultilangUI);
        }
        private void SetGridViewDataSource()
        {
            userCollection = userBS.GetListUser();
            dataGridViewUser.DataSource = userCollection;
        }

        private void SetDataForCheckListGroup()
        {
            string sText = String.Empty;
            GroupCollection groupCollection = groupBS.GetListOfGroup();
            foreach(Group group in groupCollection)
            {
                CheckedListBoxItem checkedListBox = new CheckedListBoxItem();
                checkedListBox.Text = group.GroupName;
                checkedListBox.Tag = group;
                chkLstGroup.Items.Add(checkedListBox);

                if(sText.Length < checkedListBox.Text.Length)
                {
                    sText = checkedListBox.Text;
                }
            }

            SizeF stringSize = new SizeF();
            Graphics g = this.CreateGraphics();
            stringSize = g.MeasureString(sText, chkLstGroup.Font);
            chkLstGroup.ColumnWidth = (int)stringSize.Width + 20;
        }

        private void ClearCheckedGroups()
        {
            for (int i = 0; i < chkLstGroup.Items.Count; i++)
                chkLstGroup.SetItemChecked(i, false);
        }

        private void SetCheckedGroupsForSelectedUser()
        {
            ClearCheckedGroups();
            for (int i = 0; i < lstInitialGroupUser.Count; i++)
            {
                for (int j = 0; j < chkLstGroup.Items.Count; j++)
                {
                    CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.Items[j];

                    if (((Group)item.Tag).GroupID == lstInitialGroupUser[i].GroupID)
                    {
                        chkLstGroup.SetItemChecked(j, true);
                        break;
                    }
                }
            }
        }
        private User GetSelectedUser(string sLoginID)
        {
            foreach (User objUser in userCollection)
            {
                if (objUser.LoginID == sLoginID)
                    return objUser;
            }

            return null;
        }

        private bool IsUserNameExists(string sLoginID)
        {
            foreach (User objUser in userCollection)
            {
                if (objUser.LoginID.ToLower() == sLoginID)
                    return true;
            }

            return false;
        }
        private void DisplayText()
        {
            if (objSelectedUser != null)
            {
                txtUserName.Text = objSelectedUser.LoginID;
                txtPassword.Text = objSelectedUser.Password;
                txtEmployeeName.Text = objSelectedUser.FullName;
                txtEmail.Text = objSelectedUser.Email;
                chkLocked.Checked = objSelectedUser.LockedUser;
                txtLockedReason.Text = objSelectedUser.LockedReason;

                if (objSelectedUser.DeadlineOfUsing == dtmMaxDate)
                    dtpEndDate.Checked = false;
                else
                {
                    dtpEndDate.Checked = true;
                    dtpEndDate.Value = objSelectedUser.DeadlineOfUsing;
                }
            }
            else
            {
                ClearText();
            }
        }

        private void DisplayText(string sUserName)
        {
            objSelectedUser = GetSelectedUser(sUserName);
            DisplayText();
        }
        private void ClearText()
        {
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtConfirmPassword.Text = String.Empty;
            txtEmployeeName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            chkLocked.Checked = false;
            txtLockedReason.Text = String.Empty;
            dtpEndDate.Checked = false;
        }
        private void EnableControls(bool bIsEnabled)
        {
            if (ucDataButtonUser.DataMode != DataState.Edit)
                txtUserName.Enabled = bIsEnabled;
            txtPassword.Enabled = bIsEnabled;
            txtConfirmPassword.Enabled = bIsEnabled;
            txtEmployeeName.Enabled = bIsEnabled;
            txtEmail.Enabled = bIsEnabled;
            chkLocked.Enabled = bIsEnabled;
            txtLockedReason.Enabled = (bIsEnabled && chkLocked.Checked);
            dtpEndDate.Enabled = bIsEnabled;
            chkLstGroup.Enabled = bIsEnabled;
            chkLstGroup.ClearSelected();

            if (bIsEnabled)
                chkLstGroup.BackColor = Color.White;
            else
                chkLstGroup.BackColor = Color.FromName("Control");
        }
        /// <summary>
        /// Check list of initial group has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsGroupListChanged()
        {
            Group objGroup;
            //1.1. Update Inserted Group-User List
            for (int i = 0; i < chkLstGroup.CheckedItems.Count; i++)
            {
                bool bIsExists = false;
                CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.CheckedItems[i];
                objGroup = (Group)item.Tag;

                for (int j = 0; j < lstInitialGroupUser.Count; j++)
                {
                    if (lstInitialGroupUser[j].GroupID == objGroup.GroupID)
                    {
                        bIsExists = true;
                        break;
                    }
                }

                if (!bIsExists)
                    return true;
            }

            //1.2 Update Deleted Group-UserID List
            for (int i = 0; i < lstInitialGroupUser.Count; i++)
            {
                bool bIsExists = false;
                for (int j = 0; j < chkLstGroup.CheckedItems.Count; j++)
                {
                    CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.CheckedItems[j];
                    objGroup = (Group)item.Tag;
                    if (lstInitialGroupUser[i].GroupID == objGroup.GroupID)
                    {
                        bIsExists = true;
                        break;
                    }
                }

                if (!bIsExists)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Check data has been changed when user close Form ?
        /// </summary>
        /// <returns></returns>
        private bool IsChangedData()
        {
            if (ucDataButtonUser.DataMode == DataState.Insert)
            {
                if (txtUserName.Text.Trim().Length > 0 || txtPassword.Text.Trim().Length > 0)
                    return true;
                else
                    return false;
            }
            else if (ucDataButtonUser.DataMode == DataState.Edit)
            {
                if (objSelectedUser.Password != txtPassword.Text.Trim()
                    || objSelectedUser.FullName != txtEmployeeName.Text.Trim()
                    || objSelectedUser.Email != txtEmail.Text.Trim()
                    || objSelectedUser.LockedUser != chkLocked.Checked
                    || objSelectedUser.LockedReason != txtLockedReason.Text.Trim()
                    || (dtpEndDate.Checked && objSelectedUser.DeadlineOfUsing.Date == dtpEndDate.Value.Date)
                    || (!dtpEndDate.Checked && objSelectedUser.DeadlineOfUsing.Date != dtmMaxDate.Date)
                    || IsGroupListChanged())
                    return true;
                else
                    return false;

            }

            return false;
        }

        /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên người dùng.", "Thông báo" + Common.formSoftName);
                txtUserName.Focus();
                return false;
            }
            if (ucDataButtonUser.DataMode == DataState.Insert && IsUserNameExists(txtUserName.Text.ToLower()))
            {
                MessageBox.Show("Tên tài khoản này đã tồn tại.", "Thông báo" + Common.formSoftName);
                txtUserName.Focus();
                return false;
            }

            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu.", "Thông báo" + Common.formSoftName);
                txtPassword.Focus();
                return false;
            }
            if (txtConfirmPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập lại mật khẩu.", "Thông báo" + Common.formSoftName);
                txtConfirmPassword.Focus();
                return false;
            }
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Mật khẩu bạn nhập không trùng nhau.", "Thông báo" + Common.formSoftName);
                txtConfirmPassword.Focus();
                return false;
            }
            if (txtEmployeeName.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên.", "Thông báo" + Common.formSoftName);
                txtEmployeeName.Focus();
                return false;
            }
            if (txtEmail.Text.Trim().Length > 0 && !CommonBS.CheckEmailAddress(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.", "Thông báo" + Common.formSoftName);
                txtEmail.Focus();
                return false;
            }
            if (chkLstGroup.CheckedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhóm người dùng.", "Thông báo" + Common.formSoftName);
                chkLstGroup.Focus();
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
            bool bResult = true;
            dtmNow = CommonBS.GetServerTime();

            Group objGroup;
            GroupUser objGroupUser;
            List<GroupUser> lstInsertedGroupUser = new List<GroupUser>();

            if (ucDataButtonUser.DataMode == DataState.Insert)
            {
                if (IsDataOK() == false) return false;
                User objUser = new User();

                objUser.LoginID = txtUserName.Text.Trim();
                objUser.Password = CommonCore.EncryptString(txtPassword.Text.Trim(), CommonCore.PASS_PHRASE);
                objUser.FullName = txtEmployeeName.Text.Trim();
                objUser.Email = txtEmail.Text.Trim();
                objUser.LockedReason = txtLockedReason.Text;
                objUser.LockedUser = chkLocked.Checked;
                objUser.CreatedDate = dtmNow;
                if (dtpEndDate.Checked)
                    objUser.DeadlineOfUsing = dtpEndDate.Value.Date;
                else
                    objUser.DeadlineOfUsing = dtmMaxDate.Date;

                //Add User-Group
                for (int i = 0; i < chkLstGroup.CheckedItems.Count; i++)
                {
                    CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.CheckedItems[i];
                    objGroup = (Group)item.Tag;

                    objGroupUser = new GroupUser();
                    objGroupUser.LoginID = txtUserName.Text.Trim();
                    objGroupUser.GroupID = objGroup.GroupID;

                    lstInsertedGroupUser.Add(objGroupUser);
                }

                bResult = userBS.Insert(objUser, lstInsertedGroupUser);
            }
            else
            {
                //1. Update List of Deleted Group-User and Inserted Group-User
                lstAddedGroupUser.Clear();
                lstDeletedGroupUser.Clear();

                //1.1. Update Inserted Group-User List
                for (int i = 0; i < chkLstGroup.CheckedItems.Count; i++)
                {
                    bool bIsExists = false;
                    CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.CheckedItems[i];
                    objGroup = (Group)item.Tag;

                    for (int j = 0; j < lstInitialGroupUser.Count; j++)
                    {
                        if (lstInitialGroupUser[j].GroupID == objGroup.GroupID)
                        {
                            bIsExists = true;
                            break;
                        }
                    }

                    if (!bIsExists)
                    {
                        objGroupUser = new GroupUser();
                        objGroupUser.LoginID = txtUserName.Text.Trim();
                        objGroupUser.GroupID = objGroup.GroupID;

                        lstInsertedGroupUser.Add(objGroupUser);
                    }
                }

                //1.2 Update Deleted Group-UserID List
                for (int i = 0; i < lstInitialGroupUser.Count; i++)
                {
                    bool bIsExists = false;
                    for (int j = 0; j < chkLstGroup.CheckedItems.Count; j++)
                    {
                        CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.CheckedItems[j];
                        objGroup = (Group)item.Tag;
                        if (lstInitialGroupUser[i].GroupID == objGroup.GroupID)
                        {
                            bIsExists = true;
                            break;
                        }
                    }

                    if (!bIsExists)
                        lstDeletedGroupUser.Add(lstInitialGroupUser[i]);
                }

                //2. Update User
                objSelectedUser = userBS.GetUserByID(objSelectedUser.LoginID);
                objSelectedUser.FullName = txtEmployeeName.Text.Trim();
                objSelectedUser.Email = txtEmail.Text.Trim();
                objSelectedUser.LockedUser = chkLocked.Checked;
                if (chkLocked.Checked)
                    objSelectedUser.LockedReason = txtLockedReason.Text;
                else
                    objSelectedUser.LockedReason = string.Empty;

                if (dtpEndDate.Checked)
                    objSelectedUser.DeadlineOfUsing = dtpEndDate.Value.Date;
                else
                    objSelectedUser.DeadlineOfUsing = dtmMaxDate.Date;

                bResult = userBS.Update(objSelectedUser, lstInsertedGroupUser, lstDeletedGroupUser);
            }

            if (bResult)
            {
                if (bIsClosed == false)
                {
                    bIsBindingData = true;

                    SetGridViewDataSource();

                    //Refresh lstInitialGroupUserID
                    lstInitialGroupUser = groupUserBS.GetListOfGroupUserByUserID(txtUserName.Text.Trim());

                    for (int i = 0; i < dataGridViewUser.RowCount; i++)
                    {
                        if (dataGridViewUser.Rows[i].Cells[LoginID.Name].Value.ToString() == txtUserName.Text)
                        {
                            dataGridViewUser.CurrentCell = dataGridViewUser.Rows[i].Cells[0];
                            break;
                        }
                    }

                    bIsBindingData = false;
                }

                CommonBS.SaveSuccessfully();
                ucDataButtonUser.DataMode = DataState.View;
                ucDataButtonUser.SetInsertFocus();
                EnableControls(false);
            }
            else
                CommonBS.SaveNotSuccessfully();

            return bResult;
        }
        #endregion
        #region Buttons click
        private void ucDataButtonUser_InsertHander()
        {
            ClearText();
            ClearCheckedGroups();
            EnableControls(true);
            txtUserName.Focus();
        }
        private void chkLocked_CheckedChanged(object sender, EventArgs e)
        {
            if (ucDataButtonUser.DataMode != DataState.View)
                txtLockedReason.Enabled = chkLocked.Checked;
        }

        private void ucDataButtonUser_EditHandler()
        {
            if (dataGridViewUser.SelectedRows == null && dataGridViewUser.SelectedRows.Count == 0)
                return;
            EnableControls(true);
            txtPassword.Focus();
            if (dataGridViewUser.SelectedRows.Count > 1)
            {
                for (int i = 1; i < dataGridViewUser.SelectedRows.Count; i++)
                {
                    dataGridViewUser.SelectedRows[i].Selected = false;
                }
            }
        }

        private void ucDataButtonUser_DeleteHandler()
        {
            objCommon.CurrentFormMethodInvoker = DeleteUser;
            objCommon.App_ShowWaitForm(DataState.Delete);
        }
        private void DeleteUser()
        {
            if (dataGridViewUser.SelectedRows.Count > 0)
            {
                if (CommonBS.ConfirmDeletion() == DialogResult.Yes)
                {
                    List<string> lstDeletedUserName = new List<string>();
                    List<GroupUser> lstGroupUser = new List<GroupUser>();
                    User objUser;
                    DataGridViewSelectedRowCollection nRow = dataGridViewUser.SelectedRows;
                    foreach (DataGridViewRow row in nRow)
                    {
                        // Add deleted user
                        objUser = userBS.GetUserByID(CommonCore.ConvertToString(row.Cells[LoginID.Name].Value));
                        if (CommonBS.CurrentUser != null && objUser.FullName == CommonBS.CurrentUser.FullName)
                        {
                            MessageBox.Show("Không được xóa người dùng [" + objUser.LoginID + "].", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        lstDeletedUserName.Add(objUser.LoginID);

                        // Add deleted Group-User object
                        lstGroupUser = groupUserBS.GetListOfGroupUserByUserID(objUser.LoginID);
                    }

                    int nIndex = dataGridViewUser.SelectedRows[0].Index;
                    if (userBS.Delete(lstDeletedUserName, lstGroupUser))
                    {
                        bIsBindingData = true;
                        SetGridViewDataSource();
                        bIsBindingData = false;

                        // Set selected Row
                        if (dataGridViewUser.RowCount > 0)
                        {
                            if (nRow.Count > 1)
                            {
                                nIndex = 0;
                            }
                            else if (dataGridViewUser.RowCount <= nIndex)
                            {
                                nIndex--;
                            }

                            dataGridViewUser.ClearSelection();
                            dataGridViewUser.CurrentCell = dataGridViewUser.Rows[nIndex].Cells[1];
                        }
                        else
                        {
                            objSelectedUser = null;
                        }
                        CommonBS.DeleteSuccessfully();
                    }
                    else
                    {
                        CommonBS.DeleteNotSuccessfully();
                    }
                }
            }
        }

        private void ucDataButtonUser_CancelHandler()
        {
            if (ucDataButtonUser.DataMode == DataState.Edit)
            {
                DisplayText();

                SetCheckedGroupsForSelectedUser();
            }
            else
            {
                if (dataGridViewUser.SelectedRows.Count > 0)
                {
                    DisplayText();
                    SetCheckedGroupsForSelectedUser();
                }
                else
                {
                    ClearText();
                    ClearCheckedGroups();
                }
            }

            EnableControls(false);
            ucDataButtonUser.DataMode = DataState.View;
        }

        private void ucDataButtonUser_SaveHandler()
        {
            objCommon.CurrentFormMethodInvoker = SaveUser;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void SaveUser()
        {
            SaveData();
        }

        private void ucDataButtonUser_CloseHandler()
        {
            if (IsChangedData())
            {
                if (CommonBS.ConfirmChangedData() == DialogResult.Yes)
                {
                    bIsClosed = true;
                    if (SaveData() == false)
                        return;
                }
            }

            this.Close();
        }
        #endregion

        private void dataGridViewUser_SelectionChanged(object sender, EventArgs e)
        {
            if (bIsBindingData || dataGridViewUser.SelectedRows.Count == 0) return;

            if (ucDataButtonUser.DataMode == DataState.Insert)
            {
                ucDataButtonUser.DataMode = DataState.View;
                EnableControls(false);
            }

            DisplayText(dataGridViewUser.SelectedRows[0].Cells[LoginID.Name].Value.ToString());

            //Get data from DB
            lstInitialGroupUser = groupUserBS.GetListOfGroupUserByUserID(txtUserName.Text.Trim());

            //Set checked for CheckedListBox
            SetCheckedGroupsForSelectedUser();
        }

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu.", "Thông báo" + Common.formSoftName);
                txtPassword.Focus();
                return;
            }
            if (txtConfirmPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập lại mật khẩu.", "Thông báo" + Common.formSoftName);
                txtConfirmPassword.Focus();
                return;
            }
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Mật khẩu bạn nhập không trùng nhau.", "Thông báo" + Common.formSoftName);
                txtConfirmPassword.Focus();
                return;
            }
            if (dataGridViewUser.SelectedRows.Count >= 0)
            {
                string sLoginID = dataGridViewUser.CurrentRow.Cells["LoginID"].Value.ToString();
                User currentUser = userBS.GetUserByID(sLoginID);
                currentUser.Password = CommonCore.EncryptString(txtPassword.Text.Trim(), CommonCore.PASS_PHRASE);
                currentUser.LastChangedPassword = DateTime.Now;
                if (userBS.UpdatePassword(currentUser))
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công.", "Thông báo" + Common.formSoftName);
                }
                else
                {
                    MessageBox.Show("Thay đổi mật khẩu không thành công.", "Thông báo" + Common.formSoftName);
                }
            }
        }
    }
}
