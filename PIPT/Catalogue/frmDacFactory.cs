using DAC.Core;
using DAC.Core.Security;
using DAC.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacFactory : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacFactory _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacFactory Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacFactory();
            }
            return _instance;
        }

        public static frmDacFactory Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacFactory Instance(Form parent, bool isActivate)
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
        DacFactory dacFactory = new DacFactory();
        DacFactory selectedDacFactory = new DacFactory();
        List<DacFactory> dacFactoryCollection = new List<DacFactory>();
        DacFactoryCS dacFactoryBS = new DacFactoryCS();
        BindingList<DacFactory> bdlDacFactory;
        bool bIsDataBinding = false;
        bool bIsPastedData = false;
        #endregion
        #region Form's Events
        public frmDacFactory()
        {
            InitializeComponent();
        }
        private void frmDacFactory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsRegion.DacRegion' table. You can move, or remove it, as needed.
            DAC.DAL.DacDbAccess dacDb = new DAC.DAL.DacDbAccess();
            dacDb.CreateNewSqlCommand();
            // Get data from database
            dacFactoryCollection = dacFactoryBS.GetListFactory();
            // Get BindingList DataSource
            AddObjectIntoBindingList(dacFactoryCollection);

            if (bIsDataBinding)
            {
                // Có ít nhất 1 row.
                //gridLookUpEditRegion.EditValue = 
            }
        }
        #endregion
        #region Functions on Form
        private void AddObjectIntoBindingList(List<DacFactory> FactoryCollection)
        {
            bdlDacFactory = new BindingList<DacFactory>();
            foreach (DacFactory factory in FactoryCollection)
            {
                bdlDacFactory.Add(factory);
            }
            SetDataSource();
        }
        private void SetDataSource()
        {
            CommonCore.ClearDataBinding(panelAgency);
            // Binding data to Controls
            bIsDataBinding = true;
            textBoxCode.DataBindings.Add("Text", bdlDacFactory, "Code");
            textBoxName.DataBindings.Add("Text", bdlDacFactory, "Name");
            textBoxAddress.DataBindings.Add("Text", bdlDacFactory, "Address");
            textBoxOwnerName.DataBindings.Add("Text", bdlDacFactory, "OwnerName");
            textBoxMobileNum.DataBindings.Add("Text", bdlDacFactory, "MobileNum");
            textBoxEmail.DataBindings.Add("Text", bdlDacFactory, "Email");
            richTextBoxDescription.DataBindings.Add("Text", bdlDacFactory, "Description");
            dateTimePickerCreatedDate.DataBindings.Clear();
            dateTimePickerCreatedDate.DataBindings.Add("Value", bdlDacFactory, "CreatedDate");
            dateTimePickerModifiedDate.DataBindings.Clear();
            dateTimePickerModifiedDate.DataBindings.Add("Value", bdlDacFactory, "ModifiedDate");
            checkBoxActive.DataBindings.Clear();
            checkBoxActive.DataBindings.Add("Checked", bdlDacFactory, "Active");

            gridControlFactory.DataSource = bdlDacFactory;
            bIsDataBinding = false;
            EnableControls(false);
        }
        private DacFactory GetSelectedFactory(string sCode)
        {
            foreach (DacFactory factory in dacFactoryCollection)
            {
                if (factory.Code == sCode)
                    return factory;
            }
            return null;
        }
        private bool IsStoreCodeExists(string sCode)
        {
            foreach (DacFactory factory in dacFactoryCollection)
            {
                if (factory.Code == sCode.Trim().ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelAgency.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonAgency.DataMode == DataState.Edit)
            {
                textBoxCode.Enabled = false;
                dateTimePickerCreatedDate.Enabled = false;
            }
        }
        private bool IsChangedData()
        {
            if (ucDataButtonAgency.DataMode == DataState.Insert)
            {
                if (textBoxCode.Text.Trim().Length > 0 || textBoxName.Text.Trim().Length > 0)
                    return true;
                else
                    return false;
            }
            else if (ucDataButtonAgency.DataMode == DataState.Edit)
            {
                if (selectedDacFactory.Code != textBoxCode.Text.Trim()
                || selectedDacFactory.Name != textBoxName.Text.Trim()
                || selectedDacFactory.Address != textBoxAddress.Text.Trim()
                || selectedDacFactory.OwnerName != textBoxOwnerName.Text.Trim()
                || selectedDacFactory.MobileNum != textBoxMobileNum.Text.Trim()
                || selectedDacFactory.Email != textBoxEmail.Text.Trim()
                || selectedDacFactory.Description != richTextBoxDescription.Text.Trim()
                || selectedDacFactory.Active != checkBoxActive.Checked)
                    return true;
                else
                    return false;
            }
            return false;
        }
        private bool IsDataOK()
        {
            if (textBoxCode.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã đại lý.", "Thông báo" + Common.formSoftName);
                textBoxCode.Focus();
                return false;
            }
            if (ucDataButtonAgency.DataMode == DataState.Insert && IsStoreCodeExists(textBoxCode.Text))
            {
                MessageBox.Show("Mã đại lý này đã tồn tại.", "Thông báo" + Common.formSoftName);
                textBoxCode.Focus();
                textBoxCode.SelectAll();
                return false;
            }
            if (textBoxName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên đại lý.", "Thông báo" + Common.formSoftName);
                textBoxName.Focus();
                return false;
            }
            return true;
        }
        private void SaveCopiedData()
        {
            DacFactory factory = new DacFactory();
            factory.Code = textBoxCode.Text.Trim().ToUpper();
            factory.Name = textBoxName.Text.Trim();
            factory.Address = textBoxAddress.Text.Trim();
            factory.OwnerName = textBoxOwnerName.Text.Trim();
            factory.MobileNum = textBoxMobileNum.Text.Trim();
            factory.Email = textBoxEmail.Text.Trim();
            factory.Description = richTextBoxDescription.Text.Trim();
            factory.CreatedDate = dateTimePickerCreatedDate.Value;
            factory.CreatedUser = CommonBS.CurrentUser.LoginID;
            factory.ModifiedDate = dateTimePickerModifiedDate.Value;
            factory.ModifiedUser = string.Empty;
            factory.Active = checkBoxActive.Checked;

            dacFactoryBS.Insert(factory);
        }
        private bool SaveData()
        {
            if (IsDataOK() == false) return false;

            bool bResult = true;
            if (ucDataButtonAgency.DataMode == DataState.Insert)
            {
                DacFactory factory = new DacFactory();
                factory.Code = textBoxCode.Text.Trim().ToUpper();
                factory.Name = textBoxName.Text.Trim();
                factory.Address = textBoxAddress.Text.Trim();
                factory.OwnerName = textBoxOwnerName.Text.Trim();
                factory.MobileNum = textBoxMobileNum.Text.Trim();
                factory.Email = textBoxEmail.Text.Trim();
                factory.Description = richTextBoxDescription.Text.Trim();
                factory.CreatedDate = dateTimePickerCreatedDate.Value;
                factory.CreatedUser = CommonBS.CurrentUser.LoginID;
                factory.ModifiedDate = dateTimePickerModifiedDate.Value;
                factory.ModifiedUser = string.Empty;
                factory.Active = checkBoxActive.Checked;

                bResult = dacFactoryBS.Insert(factory);
            }
            else
            {
                // Update data in to databaseDacAgency
                selectedDacFactory.Code = textBoxCode.Text.Trim().ToUpper();
                selectedDacFactory.Name = textBoxName.Text.Trim();
                selectedDacFactory.Address = textBoxAddress.Text.Trim();
                selectedDacFactory.OwnerName = textBoxOwnerName.Text.Trim();
                selectedDacFactory.MobileNum = textBoxMobileNum.Text.Trim();
                selectedDacFactory.Email = textBoxEmail.Text.Trim();
                selectedDacFactory.Description = richTextBoxDescription.Text.Trim();
                selectedDacFactory.CreatedDate = dateTimePickerCreatedDate.Value;
                selectedDacFactory.ModifiedDate = DateTime.Now;
                selectedDacFactory.ModifiedUser = CommonBS.CurrentUser.LoginID;
                selectedDacFactory.Active = checkBoxActive.Checked;

                bResult = dacFactoryBS.Update(selectedDacFactory);
            }
            // Kiem tra luu thanh cong khong de load lai du lieu
            if (bResult)
            {
                // Get data from database
                dacFactoryCollection = dacFactoryBS.GetListFactory();
                AddObjectIntoBindingList(dacFactoryCollection);
                CommonBS.SaveSuccessfully();
                ucDataButtonAgency.DataMode = DataState.View;
                ucDataButtonAgency.SetInsertFocus();
                EnableControls(false);
            }
            else CommonBS.SaveNotSuccessfully();

            return bResult;
        }
        private void SaveStore()
        {
            SaveData();
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonAgency_InsertHandler()
        {
            bdlDacFactory.AddNew();
            //CommonCore.ClearTextBox(panelAgency);
            EnableControls(true);
            textBoxCode.Focus();
            //Set focus for DataGridView
            gridViewFactory.FocusedRowHandle = gridViewFactory.GetVisibleRowHandle(gridViewFactory.RowCount - 1);
        }

        private void ucDataButtonAgency_SaveHandler()
        {
            // Neu nut buttonPaste duoc nhan bIsPastedData = true
            if (bIsPastedData)
            {
                int iContent = 0;
                // Thuc hien luu cac Row vua paste vao
                int gridViewAgencyRowCount = gridViewFactory.RowCount;
                for (int i = 0; i < gridViewAgencyRowCount; i++)
                {
                    object valueCell = gridViewFactory.GetRowCellValue(i, gridColumnID);
                    if (valueCell.ToString() == "-1")
                    {
                        // Set Focus Row for DataGridView
                        gridViewFactory.FocusedRowHandle = gridViewFactory.GetVisibleRowHandle(i);
                        //DacAgency agency = new DacAgency();
                        //agency = (DacAgency)gridViewAgency.GetRow(i);
                        //Save Pasted Data();
                        SaveCopiedData();
                        gridViewFactory.SetRowCellValue(i, gridColumnID, 0);
                        iContent += 1;
                    }
                }
                // Lưu nhật ký
                CommonBO.Instance().TraceLogEvent("Save Factory: " + iContent + " bản ghi từ excel", CommonBS.CurrentUser.LoginID);
                ucDataButtonAgency.DataMode = DataState.View;
            }
            else
            {
                // Lưu nhật ký
                CommonBO.Instance().TraceLogEvent("Save Factory: " + textBoxCode.Text + " - " + textBoxName.Text + " - "
                    + textBoxAddress.Text + " - " + selectedDacFactory.OwnerName + " - " + selectedDacFactory.MobileNum, CommonBS.CurrentUser.LoginID);
                Common objCommon = new Common();
                objCommon.CurrentForm = this;
                objCommon.CurrentFormMethodInvoker = SaveStore;
                objCommon.App_ShowWaitForm(DataState.Insert);
            }
            bIsPastedData = false;
        }

        private void ucDataButtonAgency_EditHandler()
        {
            // Lưu nhật ký
            CommonBO.Instance().TraceLogEvent("Edit Agency: " + textBoxCode.Text + " - " + textBoxName.Text + " - "
                + textBoxAddress.Text + " - " + selectedDacFactory.OwnerName + " - " + selectedDacFactory.MobileNum, CommonBS.CurrentUser.LoginID);
            // Kiem tra xem co du lieu nao khong
            if (gridViewFactory.RowCount == 0) return;
            // Lay du lieu de sua
            selectedDacFactory = GetSelectedFactory(gridViewFactory.GetFocusedRowCellValue(gridColumnCode).ToString());
            EnableControls(true);
            textBoxName.Focus();
        }

        private void ucDataButtonAgency_DeleteHandler()
        {
            // Kiem tra xem co du lieu nao khong
            if (gridViewFactory.RowCount == 0)
            {
                return;
            }
            string ID = gridViewFactory.GetRowCellValue(gridViewFactory.FocusedRowHandle, gridColumnID).ToString();
            if (ID == "-1")
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = gridControlFactory.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                view.DeleteRow(view.FocusedRowHandle);
            }
            else
            {
                // Lay du lieu de xoa
                selectedDacFactory = GetSelectedFactory(gridViewFactory.GetFocusedRowCellValue(gridColumnCode).ToString());
                // Kiem tra moi lien quan voi du lieu khac neu co
                if (dacFactoryBS.Delete(selectedDacFactory.Code))
                {
                    // Lưu nhật ký
                    CommonBO.Instance().TraceLogEvent("Delete Factory: " + selectedDacFactory.Code + " - " + selectedDacFactory.Name + " - "
                            + selectedDacFactory.Address + " - " + selectedDacFactory.OwnerName + " - " + selectedDacFactory.MobileNum, CommonBS.CurrentUser.LoginID);
                    CommonBS.DeleteSuccessfully();
                    // Get data from database
                    dacFactoryCollection = dacFactoryBS.GetListFactory();
                    AddObjectIntoBindingList(dacFactoryCollection);
                }
                else
                    CommonBS.DeleteNotSuccessfully();
            }
        }

        private void ucDataButtonAgency_CancelHandler()
        {
            EnableControls(false);
            if (ucDataButtonAgency.DataMode == DataState.Insert)
            {
                if (gridViewFactory.RowCount > 1)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = gridControlFactory.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            ucDataButtonAgency.DataMode = DataState.View;
        }

        private void ucDataButtonAgency_CloseHandler()
        {
            //if (IsChangedData())
            //{
            //    if (CommonBS.ConfirmChangedData() == DialogResult.Yes)
            //    {
            //        if (SaveData() == false)
            //            return;
            //    }
            //}
            this.Close();
        }
        private void ucDataButtonAgency_ExcelHandler()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Excel 2007-2016(*.xlsx)|*.xlsx";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //gridViewAgency.ExportToXlsx(@"\khachhang.xlsx");
                gridViewFactory.ExportToXlsx(fileDialog.FileName);
            }
        }
        #endregion

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string[] datas = Common.ClipBoardData.Split('\n');
            if (datas.Length < 1) return;
            foreach (string data in datas)
            {
                CopyToGridControl(data);
            }
            bIsPastedData = true;
            ucDataButtonAgency.DataMode = DataState.Insert;
        }
        private void CopyToGridControl(string data)
        {
            if (data == string.Empty) return;
            string[] rowData = data.Split(new char[] { '\r', '\x09' });
            try
            {
                string sCode = rowData[1].ToString();
                // Kiem tra su ton tai cua ma KH
                if (Common.CheckExistCode(sCode, gridViewFactory, gridColumnCode))
                {
                    MessageBox.Show("Mã " + sCode + " đã tồn tại!", "Thông báo");
                    return;
                }
                DacFactory factory = new DacFactory();
                factory.ID = -1;
                factory.Code = sCode;
                factory.Name = rowData[2];
                factory.Address = rowData[3];
                factory.OwnerName = rowData[4];
                factory.MobileNum = rowData[5];
                factory.Email = rowData[6];
                factory.CreatedUser = CommonBS.CurrentUser.LoginID;
                try
                {
                    factory.CreatedDate = DateTime.Parse(rowData[8]);
                }
                catch
                {
                    factory.CreatedDate = DateTime.Now;
                }
                factory.ModifiedDate = DateTime.Now;
                factory.ModifiedUser = string.Empty;
                factory.Description = rowData[11];
                factory.Active = true;
                // Add row in to GridControl
                bdlDacFactory.Add(factory);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Dữ liệu đã sao chép không đúng định dạng");
            }
        }
    }
}
