using DAC.Core.Security;
using System;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmGroup : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmGroup _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmGroup Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmGroup();
            }
            return _instance;
        }

        public static frmGroup Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmGroup Instance(Form parent, bool isActivate)
        {
            _instance = Instance(parent);
            if (isActivate)
            {
                _instance.WindowState = FormWindowState.Normal;
                _instance.Show();
                _instance.Activate();
            }
            return _instance;
        }
        #endregion
        #region Variables
        bool blnIsDataBinding = true;
        bool blnIsClosing = false;
        GroupBS groupBS = new GroupBS();
        #endregion
        #region Form's Events
        
        public frmGroup()
        {
            InitializeComponent();
        }

        private void frmGroup_Load(object sender, System.EventArgs e)
        {
            dataGridViewGroup.AutoGenerateColumns = false;
            SetDataSource();
            EnableControls(false);
            SetAuthorization();
        }

        private void SetAuthorization()
        {
            ucDataButtonGroup.AddNewVisible = groupBS.IsAuthorized(GroupBS.GroupAction.Insert);
            ucDataButtonGroup.EditVisible = groupBS.IsAuthorized(GroupBS.GroupAction.Update);
            ucDataButtonGroup.DeleteVisible = groupBS.IsAuthorized(GroupBS.GroupAction.Delete);
            //ucDataButtonGroup.MultiLanguageVisible = groupBS.IsAuthorized(GroupBS.GroupAction.MultilangUI);
        }
        
        private void SetDataSource()
        {
            blnIsDataBinding = true;
            GroupCollection groupCollection = groupBS.GetListOfGroup();
            dataGridViewGroup.DataSource = groupCollection;
            blnIsDataBinding = false;
        }
        /// <summary>
        /// Display Text
        /// </summary>
        private void DisplayText()
        {
            txtGroupName.Text = dataGridViewGroup.SelectedRows[0].Cells[GroupName.Name].Value.ToString();
            txtNote.Text = dataGridViewGroup.SelectedRows[0].Cells[Note.Name].Value.ToString();
            checkBoxAdmin.Checked = Convert.ToBoolean(dataGridViewGroup.SelectedRows[0].Cells[IsAdmin.Name].Value);
        }
        /// <summary>
        /// Clear Text
        /// </summary>
        private void ClearText()
        {
            txtGroupName.Text = string.Empty;
            txtNote.Text = string.Empty;
        }
        /// <summary>
        /// Is Data Ok
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            if(txtGroupName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập nhóm người dùng.", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Enable Controls
        /// </summary>
        /// <param name="bln"></param>
        private void EnableControls(bool bln)
        {
            txtGroupName.Enabled = bln;
            txtNote.Enabled = bln;
            if (CommonBS.IsAdminUser)
            {
                checkBoxAdmin.Enabled = bln;
            }
        }
        /// <summary>
        /// Check data has been changed?
        /// </summary>
        /// <returns></returns>
        private bool IsChangedData()
        {
            if (ucDataButtonGroup.DataMode == DataState.Edit)
            {
                DataGridViewRow modifiedRow = dataGridViewGroup.SelectedRows[0];

                if (modifiedRow.Cells[GroupName.Name].Value.ToString() != txtGroupName.Text.Trim()
                    || modifiedRow.Cells[Note.Name].Value.ToString() != txtNote.Text.Trim())
                    return true;

            }
            else if (ucDataButtonGroup.DataMode == DataState.Edit)
            {
                if (txtGroupName.Text.Trim() != string.Empty
                    || txtNote.Text.Trim() != string.Empty)
                    return true;
            }

            return false;
        }

        private void SaveData()
        {
            if (IsDataOK() == false) return;

            Group objGroup = new Group();
            Guid groupID;
            bool bResult = false;

            objGroup.GroupName = txtGroupName.Text.Trim();
            objGroup.Note = txtNote.Text.Trim();

            if(ucDataButtonGroup.DataMode == DataState.Insert)
            {
                groupID = Guid.NewGuid();
                objGroup.GroupID = groupID;
                objGroup.IsAdmin = checkBoxAdmin.Checked;

                bResult = groupBS.Insert(objGroup);
            }
            else
            {
                DataGridViewRow modifiedRow = dataGridViewGroup.SelectedRows[0];
                groupID = (Guid)modifiedRow.Cells[GroupID.Name].Value;
                objGroup.GroupID = groupID;
                objGroup.IsAdmin = (bool)modifiedRow.Cells[IsAdmin.Name].Value;

                bResult = groupBS.Update(objGroup);
            }
            if(bResult)
            {
                CommonBS.SaveSuccessfully();

                //If user is closing form.
                if (blnIsClosing) return;

                SetDataSource();

                //Set selected row
                for(int i = 0; i < dataGridViewGroup.RowCount; i++)
                {
                    if((Guid)dataGridViewGroup.Rows[i].Cells[GroupID.Name].Value == groupID)
                    {
                        dataGridViewGroup.CurrentCell = dataGridViewGroup.Rows[i].Cells[1];
                        break;
                    }
                }

                ucDataButtonGroup.DataMode = DataState.View;
            }
            else
            {
                CommonBS.SaveNotSuccessfully();
                return;
            }
        }
        #endregion

        #region Button Events
        private void ucDataButtonGroup_InsertHandler()
        {
            EnableControls(true);
            ClearText();

            txtGroupName.Focus();
        }

        private void ucDataButtonGroup_EditHandler()
        {
            EnableControls(true);
            
            txtGroupName.Focus();
        }

        private void ucDataButtonGroup_DeleteHandler()
        {
            if (CommonBS.ConfirmDeletion() == DialogResult.No) return;

            for(int i = 0; i < dataGridViewGroup.SelectedRows.Count; i++)
            {
                if((bool)dataGridViewGroup.SelectedRows[i].Cells[IsAdmin.Name].Value)
                {
                    //Admin group is not allowed to delete
                    MessageBox.Show(string.Format("Nhóm [{0}] là nhóm quản trị bạn không được phép xoá.", dataGridViewGroup.SelectedRows[i].Cells[GroupName.Name].Value.ToString()), "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            for(int i = 0; i < dataGridViewGroup.SelectedRows.Count; i++)
            {
                groupBS.Delete((Guid)dataGridViewGroup.SelectedRows[i].Cells[GroupID.Name].Value);
            }

            SetDataSource();
            if(dataGridViewGroup.RowCount > 0)
            {
                dataGridViewGroup.CurrentCell =null;
                dataGridViewGroup.CurrentCell = dataGridViewGroup.Rows[0].Cells[1];
            }
        }

        private void ucDataButtonGroup_CancelHandler()
        {
            if (ucDataButtonGroup.DataMode == DataState.Edit)
            {
                DisplayText();
            }
            else
            {
                if (dataGridViewGroup.SelectedRows.Count > 0)
                    DisplayText();
                else
                    ClearText();
            }

            EnableControls(false); 
        }

        private void ucDataButtonGroup_SaveHandler()
        {
            //--- Start Displaying wait form
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveData;
            objCommon.App_ShowWaitForm(DataState.Insert);
            //--- End
            EnableControls(false);
        }

        private void ucDataButtonGroup_CloseHandler()
        {
            if (IsChangedData() && CommonBS.ConfirmChangedData() == DialogResult.Yes)
            {
                SaveData();
            }

            this.Close();
        }
        #endregion

        private void dataGridViewGroup_SelectionChanged(object sender, EventArgs e)
        {
            if (blnIsDataBinding || dataGridViewGroup.SelectedRows.Count == 0) return;

            DisplayText();
        }


    }
}
