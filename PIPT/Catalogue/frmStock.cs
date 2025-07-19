using AnyClone;
using DAC.Core;
using DAC.Core.Common;
using DAC.Core.Security;
using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmStock : Form
    {
        #region Variables
        IDacCustomerService _agencyService;
        IDacStockService _stockService;
        List<DacCustomerVM> LstAgency;
        List<DacStock> LstStock;
        DacStock originalObject;
        #endregion
        #region Form's Events
        public frmStock(IDacCustomerService agencyService, IDacStockService stockService)
        {
            InitializeComponent();
            _agencyService = agencyService;
            _stockService = stockService;
        }
        private void frmStock_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void gvStock_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvStock.FocusedRowHandle >= 0 && LstStock[gvStock.FocusedRowHandle] != null)
            {
                txtCode.Text = LstStock[gvStock.FocusedRowHandle].Code;
                txtName.Text = LstStock[gvStock.FocusedRowHandle].Name;
                txtAddress.Text = LstStock[gvStock.FocusedRowHandle].Address;
                txtContact.Text = LstStock[gvStock.FocusedRowHandle].Contact;
                lueAgency.EditValue = LstStock[gvStock.FocusedRowHandle].AgencyCode;
                txtEmail.Text = LstStock[gvStock.FocusedRowHandle].Email;
                txtManager.Text = LstStock[gvStock.FocusedRowHandle].Manager;
                txtFax.Text = LstStock[gvStock.FocusedRowHandle].Fax;
                txtDescription.Text = LstStock[gvStock.FocusedRowHandle].Description;
                txtPhone.Text = LstStock[gvStock.FocusedRowHandle].Telephone;
                txtMobile.Text = LstStock[gvStock.FocusedRowHandle].Mobi;
                chkActive.Checked = LstStock[gvStock.FocusedRowHandle].Active.HasValue ? LstStock[gvStock.FocusedRowHandle].Active.Value : false;
                originalObject = LstStock[gvStock.FocusedRowHandle].Clone();
            }
            else
            {
                originalObject = null;
            }
        }
        #endregion
        #region Function on form
        private void LoadData()
        {
            var CurrentUser = Session.CurrentUser;
            if (CurrentUser != null)
            {
                LstAgency = _agencyService.GetAll().ResponseData ?? new List<DacCustomerVM>();
                LstStock = _stockService.GetAll().ResponseData?.ToList();
                if (!CurrentUser.isAdmin.HasValue || !CurrentUser.isAdmin.Value)
                {
                    LstStock = LstStock?.Where(x => x.AgencyCode == CurrentUser.CustomerCode)?.ToList();
                }
                lueAgency.Properties.DataSource = LstAgency;
                lueAgency.Properties.ValueMember = "Code";
                lueAgency.Properties.DisplayMember = "Name";
                gcStock.DataSource = LstStock;
                if (LstStock != null && LstStock.Any())
                {
                    gvStock.FocusedRowHandle = 0;
                    originalObject = LstStock[gvStock.FocusedRowHandle].Clone();
                }
                EnableControls(false);
            }
        }

        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelStock.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonStock.DataMode == DataState.Edit)
            {
                txtCode.Enabled = false;
            }
        }

        private bool ValidateData()
        {
            if (gvStock.FocusedRowHandle < 0 || LstStock == null || LstStock.Count - 1 < gvStock.FocusedRowHandle || LstStock[gvStock.FocusedRowHandle] == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu cần xử lý!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã kho!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return false;
            }
            if (ucDataButtonStock.DataMode == DataState.Insert && _stockService.GetByCode(txtCode.Text).ResponseData != null)
            {
                MessageBox.Show("Mã kho này đã tồn tại!", "Thông báo" + Common.formSoftName);
                txtCode.SelectAll();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên kho!", "Thông báo" + Common.formSoftName);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private bool SaveData()
        {
            if (ValidateData())
            {
                DacStock stock = CreateSaveData();
                if (ucDataButtonStock.DataMode == DataState.Insert)
                {
                    stock = _stockService.Create(stock).ResponseData;
                    return stock != null && stock.Id > 0;
                }
                else
                {
                    stock = _stockService.Edit(stock).ResponseData;
                    return stock != null;
                }
            }
            return false;
        }

        private DacStock CreateSaveData()
        {
            DacStock stock = new DacStock();
            stock.Id = ucDataButtonStock.DataMode == DataState.Edit ? LstStock[gvStock.FocusedRowHandle].Id : 0;
            stock.Code = ucDataButtonStock.DataMode == DataState.Insert ? txtCode.Text : LstStock[gvStock.FocusedRowHandle].Code;
            stock.Name = txtName.Text;
            stock.Address = txtAddress.Text;
            stock.Manager = txtManager.Text;
            stock.AgencyCode = lueAgency.EditValue?.ToString();
            stock.Email = txtEmail.Text;
            stock.Telephone = txtPhone.Text;
            stock.Active = chkActive.Checked;
            stock.Description = txtDescription.Text;
            stock.Mobi = txtMobile.Text;
            stock.Contact = txtContact.Text;
            stock.Fax = txtFax.Text;
            return stock;
        }

        private void SaveStock()
        {
            if (SaveData())
            {
                if (ucDataButtonStock.DataMode == DataState.Insert)
                {
                    MessageBox.Show("Thêm mới kho hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommonBO.Instance().TraceLogEvent("Save Stock: " + txtCode.Text + " - " + txtName.Text, Session.CurrentUser.LoginID);
                }
                else if (ucDataButtonStock.DataMode == DataState.Edit)
                {
                    MessageBox.Show("Cập nhật thông tin kho hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Lưu nhật ký
                    CommonBO.Instance().TraceLogEvent("Edit Stock: " + txtCode.Text + " - " + txtName.Text, Session.CurrentUser.LoginID);
                }
                LoadData();
                ucDataButtonStock.DataMode = DataState.View;
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonStock_InsertHandler()
        {
            DacStock NewStock = new DacStock();
            NewStock.Active = true;
            LstStock.Add(NewStock);
            gcStock.RefreshDataSource();
            gvStock.FocusedRowHandle = LstStock.IndexOf(LstStock.Last());
            EnableControls(true);
            txtCode.Focus();
        }

        private void ucDataButtonlStock_SaveHandler()
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveStock;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonStock_EditHandler()
        {
            EnableControls(true);
            txtName.Focus();
        }

        private void ucDataButtonStock_DeleteHandler()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa kho hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (gvStock.FocusedRowHandle < 0 || LstStock == null || LstStock.Count - 1 < gvStock.FocusedRowHandle || LstStock[gvStock.FocusedRowHandle] == null)
                {
                    MessageBox.Show("Không tìm thấy kho hàng cần xóa!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_stockService.HasUsed(LstStock[gvStock.FocusedRowHandle].Code).ResponseData)
                {
                    MessageBox.Show("Kho hàng này đã được sử dụng, bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool result = _stockService.Delete(LstStock[gvStock.FocusedRowHandle].Id).ResponseData;
                    if (result)
                    {
                        MessageBox.Show("Xóa kho hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa kho hàng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ucDataButtonStock_CancelHandler()
        {
            EnableControls(false);
            if (ucDataButtonStock.DataMode == DataState.Insert)
            {
                if (gvStock.RowCount > 1)
                {
                    gvStock.DeleteRow(gvStock.FocusedRowHandle);
                    gvStock.FocusedRowHandle = 0;
                }
            }
            else
            {
                if (gvStock.FocusedRowHandle >= 0 && originalObject != null)
                {
                    LstStock[gvStock.FocusedRowHandle] = originalObject.Clone();
                    originalObject = null;
                    if (gvStock.FocusedRowHandle >= 0)
                    {
                        gvStock_FocusedRowChanged(ucDataButtonStock, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(gvStock.FocusedRowHandle, gvStock.FocusedRowHandle));
                    }
                }
            }
            ucDataButtonStock.DataMode = DataState.View;
        }

        private void ucDataButtonStock_CloseHandler()
        {
            if (ucDataButtonStock.DataMode == DataState.Insert || ucDataButtonStock.DataMode == DataState.Edit)
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
