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
    public partial class frmDacSellCount : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacSellCount _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacSellCount Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacSellCount();
            }
            return _instance;
        }

        public static frmDacSellCount Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacSellCount Instance(Form parent, bool isActivate)
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
        DacSellCount dacSellCount = new DacSellCount();
        DacSellCount selectedDacSellCount = new DacSellCount();
        List<DacSellCount> dacSellCountCollection = new List<DacSellCount>();
        DacSellCountCS dacSellCountCS = new DacSellCountCS();
        BindingList<DacSellCount> bdlDacSellCount;
        bool bIsDataBinding;
        #endregion
        #region Form's Events
        public frmDacSellCount()
        {
            InitializeComponent();
        }
        private void frmDacProduct_Load(object sender, EventArgs e)
        {
            DAC.DAL.DacDbAccess dacDb = new DAC.DAL.DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FactoryCode", string.Empty);
            DataTable dataTable = dacDb.ExecuteDataTable("spDacProduct_SelectAll");
            // Add source to Category
            gridLookUpEditProduct.Properties.DataSource = dataTable;
            // Get data from database
            dacSellCountCollection = dacSellCountCS.GetListSellCount(string.Empty, string.Empty, string.Empty);
            // Get BindingList DataSource
            AddObjectIntoBindingList(dacSellCountCollection);
        }
        #endregion
        #region Function on form
        private void AddObjectIntoBindingList(List<DacSellCount> SellCountCollection)
        {
            bdlDacSellCount = new BindingList<DacSellCount>();
            foreach (DacSellCount product in SellCountCollection)
            {
                bdlDacSellCount.Add(product);
            }
            SetDataSource();
        }
        private void SetDataSource()
        {
            CommonCore.ClearDataBinding(panelSellCount);
            // Binding data to Controls
            bIsDataBinding = true;
            textBoxUnitCode.DataBindings.Add("Text", bdlDacSellCount, "UnitCode");
            textBoxPromotionCode.DataBindings.Add("Text", bdlDacSellCount, "PromotionCode");
            gridLookUpEditProduct.DataBindings.Clear();
            gridLookUpEditProduct.DataBindings.Add("EditValue", bdlDacSellCount, "ProductCode");
            dateTimePickerSellDate.DataBindings.Clear();
            dateTimePickerSellDate.DataBindings.Add("Value", bdlDacSellCount, "SellDate");
            checkBoxTxtType.DataBindings.Clear();
            checkBoxTxtType.DataBindings.Add("Checked", bdlDacSellCount, "TxtType");
            checkBoxActive.DataBindings.Clear();
            checkBoxActive.DataBindings.Add("Checked", bdlDacSellCount, "Active");

            gridControlSellCount.DataSource = bdlDacSellCount;
            bIsDataBinding = false;
            EnableControls(bIsDataBinding);
        }
        private DacSellCount GetSelectedSellCount(string sCode)
        {
            foreach (DacSellCount sellCount in dacSellCountCollection)
            {
                if (sellCount.ProductCode == sCode)
                    return sellCount;
            }
            return null;
        }
        private bool IsSellCountCodeExists(string sCode)
        {
            foreach (DacSellCount sellCount in dacSellCountCollection)
            {
                if (sellCount.ProductCode == sCode.Trim().ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelSellCount.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonSellCount.DataMode == DataState.Edit)
            {
                textBoxUnitCode.Enabled = false;
                dateTimePickerSellDate.Enabled = false;
            }
        }
        private bool IsChangedData()
        {
            if (ucDataButtonSellCount.DataMode == DataState.Insert)
            {
                if (textBoxUnitCode.Text.Trim().Length > 0 || textBoxPromotionCode.Text.Trim().Length > 0)
                    return true;
                else
                    return false;
            }
            else if (ucDataButtonSellCount.DataMode == DataState.Edit)
            {
                if (selectedDacSellCount.UnitCode != textBoxUnitCode.Text.Trim()
                || selectedDacSellCount.PromotionCode != textBoxPromotionCode.Text.Trim()
                || selectedDacSellCount.ProductCode != (string)gridLookUpEditProduct.EditValue
                || selectedDacSellCount.Active != checkBoxActive.Checked)
                    return true;
                else
                    return false;
            }
            return false;
        }
        private bool IsDataOK()
        {
            if (textBoxUnitCode.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm.", "Thông báo" + Common.formSoftName);
                textBoxUnitCode.Focus();
                return false;
            }
            if (ucDataButtonSellCount.DataMode == DataState.Insert && IsSellCountCodeExists(textBoxUnitCode.Text))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại.", "Thông báo" + Common.formSoftName);
                textBoxUnitCode.Focus();
                textBoxUnitCode.SelectAll();
                return false;
            }
            if (textBoxPromotionCode.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm.", "Thông báo" + Common.formSoftName);
                textBoxPromotionCode.Focus();
                return false;
            }
            return true;
        }
        private bool SaveData()
        {
            if (IsDataOK() == false) return false;

            bool bResult = true;
            if (ucDataButtonSellCount.DataMode == DataState.Insert)
            {
                DacSellCount sellCount = new DacSellCount();
                sellCount.UnitCode = textBoxUnitCode.Text.Trim().ToUpper();
                sellCount.PromotionCode = textBoxPromotionCode.Text.Trim();
                sellCount.ProductCode = (string)gridLookUpEditProduct.EditValue;
                sellCount.SellDate = dateTimePickerSellDate.Value;
                sellCount.Memo = comboBoxEditMemo.Text;
                sellCount.TxtType = checkBoxTxtType.Checked;
                sellCount.Active = checkBoxActive.Checked;

                bResult = dacSellCountCS.Insert(sellCount);
            }
            else
            {
                // Update data in to databaseDacProduct
                selectedDacSellCount.UnitCode = textBoxUnitCode.Text.Trim();
                selectedDacSellCount.PromotionCode = textBoxPromotionCode.Text.Trim().ToUpper();
                selectedDacSellCount.ProductCode = (string)gridLookUpEditProduct.EditValue;
                selectedDacSellCount.SellDate = dateTimePickerSellDate.Value;
                selectedDacSellCount.EndDate = dateTimePickerEndDate.Value;
                selectedDacSellCount.TxtType = checkBoxTxtType.Checked;
                selectedDacSellCount.Active = checkBoxActive.Checked;

                bResult = dacSellCountCS.Update(selectedDacSellCount);
            }
            // Kiem tra luu thanh cong khong de load lai du lieu
            if (bResult)
            {
                // Get data from database
                dacSellCountCollection = dacSellCountCS.GetListSellCount(string.Empty, string.Empty, string.Empty);
                AddObjectIntoBindingList(dacSellCountCollection);
                CommonBS.SaveSuccessfully();
                ucDataButtonSellCount.DataMode = DataState.View;
                ucDataButtonSellCount.SetInsertFocus();
                EnableControls(false);
            }
            else CommonBS.SaveNotSuccessfully();

            return bResult;
        }
        private void SaveSellCount()
        {
            SaveData();
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonSellCount_InsertHandler()
        {
            bdlDacSellCount.AddNew();
            //CommonCore.ClearTextBox(panelSellCount);
            EnableControls(true);
            textBoxUnitCode.Focus();
            //Set focus for DataGridView
            gridViewSellCount.FocusedRowHandle = gridViewSellCount.GetVisibleRowHandle(gridViewSellCount.RowCount - 1);
        }

        private void ucDataButtonSellCount_SaveHandler()
        {
            // Lưu nhật ký
            CommonBO.Instance().TraceLogEvent("Save SellCount: " + textBoxUnitCode.Text + " - " + textBoxPromotionCode.Text + " - "
                + gridLookUpEditProduct.EditValue, CommonBS.CurrentUser.LoginID);
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveSellCount;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonSellCount_EditHandler()
        {
            // Lưu nhật ký
            CommonBO.Instance().TraceLogEvent("Edit SellCount: " + textBoxUnitCode.Text + " - " + textBoxPromotionCode.Text + " - "
                + gridLookUpEditProduct.EditValue, CommonBS.CurrentUser.LoginID);
            // Kiem tra xem co du lieu nao khong
            if (gridViewSellCount.RowCount == 0) return;
            // Lay du lieu de sua
            selectedDacSellCount = GetSelectedSellCount(gridViewSellCount.GetFocusedRowCellValue(gridColumnProductCode).ToString());
            EnableControls(true);
            textBoxPromotionCode.Focus();
        }

        private void ucDataButtonSellCount_DeleteHandler()
        {
            // Kiem tra xem co du lieu nao khong
            if (gridViewSellCount.RowCount == 0)
            {
                return;
            }
            // Lay du lieu de xoa
            selectedDacSellCount = GetSelectedSellCount(gridViewSellCount.GetFocusedRowCellValue(gridColumnProductCode).ToString());
            // Kiem tra moi lien quan voi du lieu khac neu co
            if (dacSellCountCS.Delete(selectedDacSellCount.Id))
            {
                // Lưu nhật ký
                CommonBO.Instance().TraceLogEvent("Delete SellCount: " + textBoxUnitCode.Text + " - " + textBoxPromotionCode.Text + " - "
                    + gridLookUpEditProduct.EditValue, CommonBS.CurrentUser.LoginID);
                CommonBS.DeleteSuccessfully();
                // Get data from database
                dacSellCountCollection = dacSellCountCS.GetListSellCount(string.Empty, string.Empty, string.Empty);
                AddObjectIntoBindingList(dacSellCountCollection);
            }
            else
                CommonBS.DeleteNotSuccessfully();
        }

        private void ucDataButtonSellCount_CancelHandler()
        {
            EnableControls(false);
            if(ucDataButtonSellCount.DataMode == DataState.Insert)
            {
                if (gridViewSellCount.RowCount > 1)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = gridControlSellCount.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            ucDataButtonSellCount.DataMode = DataState.View;
        }

        private void ucDataButtonSellCount_CloseHandler()
        {
            if (IsChangedData())
            {
                if (CommonBS.ConfirmChangedData() == DialogResult.Yes)
                {
                    if (SaveData() == false)
                        return;
                }
            }
            this.Close();
        }
        #endregion
    }
}
