using DAC.Core;
using DAC.Core.CoreService;
using DAC.Core.Security;
using DAC.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacInventory : Form
    {
        #region Variables
        List<DacInventory> dacInventoryCollection = new List<DacInventory>();
        DacInventoryCS dacInventoryCS = new DacInventoryCS();
        BindingList<DacInventory> bdlDacInventory;
        bool bIsDataBinding = false;
        #endregion
        #region Form's Events
        
        public frmDacInventory()
        {
            InitializeComponent();
        }
        private void frmDacInventory_Load(object sender, EventArgs e)
        {
            DacProductCS productCS = new DacProductCS();
            List<DacProduct> LstProduct = productCS.GetListProduct();
            cbbProduct.DataSource = LstProduct;
            cbbProduct.DisplayMember = "Name";
            cbbProduct.ValueMember = "Code";
            DacStockCS stockCS = new DacStockCS();
            List<DacStock> LstStock = stockCS.GetAllActiveStock();
            cbbStock.DataSource = LstStock;
            cbbStock.DisplayMember = "Name";
            cbbStock.ValueMember = "Code";
            // Get data from database
            dacInventoryCollection = dacInventoryCS.ListAllInventoryHasStock();
            // Get BindingList DataSource
            AddObjectIntoBindingList(dacInventoryCollection);
        }
        #endregion
        #region Functions on Form
        private void AddObjectIntoBindingList(List<DacInventory> dacInventoryCollection)
        {
            bdlDacInventory = new BindingList<DacInventory>();
            foreach (DacInventory inventory in dacInventoryCollection)
            {
                bdlDacInventory.Add(inventory);
            }
            SetDataSource();
        }
        private void SetDataSource()
        {
            CommonCore.ClearDataBindingWithComboBox(panelStore);
            // Binding data to Controls
            bIsDataBinding = true;
            cbbProduct.DataBindings.Add("SelectedValue", bdlDacInventory, "ProductCode");
            cbbStock.DataBindings.Add("SelectedValue", bdlDacInventory, "StockID");
            txtQuantity.DataBindings.Add("Text", bdlDacInventory, "Quantity");
            txtYear.DataBindings.Add("Text", bdlDacInventory, "Year");
            grvInventory.DataSource = bdlDacInventory;
            bIsDataBinding = false;
            EnableControls(bIsDataBinding);
        }
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelStore.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
        }
        
        private bool IsDataOK()
        {
            if (cbbProduct.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm.", "Thông báo" + Common.formSoftName);
                cbbProduct.Focus();
                return false;
            }
            if (txtQuantity.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền số lượng tồn.", "Thông báo" + Common.formSoftName);
                txtQuantity.Focus();
                return false;
            }
            try
            {
                int.Parse(txtQuantity.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("Số lượng tồn không đúng.", "Thông báo" + Common.formSoftName);
                txtQuantity.Focus();
                return false;
            }
            if (txtYear.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền năm.", "Thông báo" + Common.formSoftName);
                txtYear.Focus();
                return false;
            }
            try
            {
                int.Parse(txtYear.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("Năm không đúng.", "Thông báo" + Common.formSoftName);
                txtYear.Focus();
                return false;
            }
            string pattern = @"^\d{4}$";
            if (!Regex.IsMatch(txtYear.Text.Trim(), pattern))
            {
                MessageBox.Show("Năm không đúng.", "Thông báo" + Common.formSoftName);
                txtYear.Focus();
                return false;
            }
            return true;
        }
        private bool SaveData()
        {
            if (IsDataOK() == false) return false;

            bool bResult = true;
            if(ucDataButtonStore.DataMode == DataState.Insert)
            {
                DacInventory inventory = new DacInventory();
                inventory.ProductCode = cbbProduct.SelectedValue.ToString();
                inventory.StockId = cbbStock.SelectedValue != null ? cbbStock.SelectedValue.ToString() : string.Empty;
                inventory.Quantity = int.Parse(txtQuantity.Text.Trim());
                inventory.Year = int.Parse(txtYear.Text.Trim());

                bResult = dacInventoryCS.Insert(inventory);
            }
            else
            {
                // Update data in to databaseDacstore
                DacInventory inventory = grvInventory.CurrentRow.DataBoundItem as DacInventory;
                if (inventory != null)
                {
                    inventory.Quantity = int.Parse(txtQuantity.Text.Trim());
                    bResult = dacInventoryCS.Update(inventory);
                }
            }
            // Kiem tra luu thanh cong khong de load lai du lieu
            if (bResult)
            {
                // Get data from database
                dacInventoryCollection = dacInventoryCS.ListAllInventoryHasStock();
                AddObjectIntoBindingList(dacInventoryCollection);
                CommonBS.SaveSuccessfully();
                ucDataButtonStore.DataMode = DataState.View;
                ucDataButtonStore.SetInsertFocus();
                EnableControls(false);
            }
            else CommonBS.SaveNotSuccessfully();

            return bResult;
        }
        private void SaveCatalogue()
        {
            SaveData();
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonStore_InsertHandler()
        {
            bdlDacInventory.AddNew();
            //CommonCore.ClearTextBox(panelStore);
            EnableControls(true);
            //Set focus for DataGridView
            if (grvInventory.Rows.Count > 0)
            {
                int iCurrentRowIndex = grvInventory.Rows.Count - 1;
                grvInventory.CurrentCell = grvInventory.Rows[iCurrentRowIndex].Cells["colProductName"];
                grvInventory.Rows[iCurrentRowIndex].Selected = true;
            }
        }

        private void ucDataButtonStore_SaveHandler()
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveCatalogue;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonStore_EditHandler()
        {
            // Kiem tra xem co du lieu nao khong
            if (grvInventory.Rows.Count == 0) return;
            txtQuantity.Enabled = true;
        }

        private void ucDataButtonStore_DeleteHandler()
        {
            // Kiem tra xem co du lieu nao khong
            if (grvInventory.Rows.Count == 0)
            {
                return;
            }
            // Confirm
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Thông báo"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            // Lay du lieu de xoa
            DacInventory inventory = grvInventory.CurrentRow.DataBoundItem as DacInventory;
            if (inventory != null)
            {
                if (dacInventoryCS.Delete(inventory))
                {
                    CommonBS.DeleteSuccessfully();
                    // Get data from database
                    dacInventoryCollection = dacInventoryCS.ListAllInventoryHasStock();
                    AddObjectIntoBindingList(dacInventoryCollection);
                }
                else
                    CommonBS.DeleteNotSuccessfully();
            }
        }

        private void ucDataButtonStore_CancelHandler()
        {
            EnableControls(false);
            if (ucDataButtonStore.DataMode == DataState.Insert)
            {
                if (grvInventory.Rows.Count > 1)
                {
                    grvInventory.Rows.RemoveAt(grvInventory.CurrentRow.Index);
                }
            }
            ucDataButtonStore.DataMode = DataState.View;
        }

        private void ucDataButtonStore_CloseHandler()
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

        private bool IsChangedData()
        {
            if (ucDataButtonStore.DataMode == DataState.Insert)
            {
                if (cbbProduct.Text.Trim().Length > 0 || cbbStock.Text.Trim().Length > 0 || txtQuantity.Text.Trim().Length > 0 || txtYear.Text.Trim().Length > 0)
                    return true;
                else
                    return false;
            }
            else if (ucDataButtonStore.DataMode == DataState.Edit)
            {
                DacInventory inventory = grvInventory.CurrentRow.DataBoundItem as DacInventory;
                if (inventory != null)
                {
                    if (inventory.Quantity != int.Parse(txtQuantity.Text.Trim()))
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        #endregion
    }
}
