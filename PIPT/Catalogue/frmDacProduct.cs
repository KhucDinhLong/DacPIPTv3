using AnyClone;
using DAC.Core;
using DAC.Core.Security;
using DAC.Core.Services.Interfaces;
using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacProduct : Form
    {
        #region Variables
        IDacProductService _productService;
        IDacProductCategoryService _categoryService;
        List<DacProductVM> LstProduct;
        List<DacProductCategory> LstProductCategory;
        DacProductVM originalObject;
        #endregion
        #region Form's Events
        public frmDacProduct(IDacProductService productService, IDacProductCategoryService categoryService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
        }
        private void frmDacProduct_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion
        #region Function on form
        private void LoadData()
        {
            LstProduct = _productService.GetAll().ResponseData ?? new List<DacProductVM>();
            gcProduct.DataSource = LstProduct;
            if (LstProduct != null && LstProduct.Any())
            {
                gvProduct.FocusedRowHandle = 0;
                originalObject = LstProduct[gvProduct.FocusedRowHandle];
            }
            LstProductCategory = _categoryService.GetAll().ResponseData?.ToList();
            lueProductCategory.Properties.DataSource = LstProductCategory;
            lueProductCategory.Properties.ValueMember = "Id";
            lueProductCategory.Properties.DisplayMember = "Name";
            EnableControls(false);
        }
        
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelProduct.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonProduct.DataMode == DataState.Edit)
            {
                txtProductCode.Enabled = false;
            }
        }
        
        private bool ValidateData()
        {
            if (gvProduct.FocusedRowHandle < 0 || LstProduct == null || LstProduct.Count - 1 < gvProduct.FocusedRowHandle || LstProduct[gvProduct.FocusedRowHandle] == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu cần xử lý!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductCode.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductCode.Focus();
                return false;
            }
            if (ucDataButtonProduct.DataMode == DataState.Insert && _productService.GetByCode(txtProductCode.Text).ResponseData != null)
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại!", "Thông báo" + Common.formSoftName);
                txtProductCode.Focus();
                txtProductCode.SelectAll();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm!", "Thông báo" + Common.formSoftName);
                txtProductName.Focus();
                return false;
            }
            return true;
        }
        private bool SaveData()
        {
            if (ValidateData())
            {
                DacProduct product = CreateSaveData();
                if (ucDataButtonProduct.DataMode == DataState.Insert)
                {
                    product = _productService.Create(product).ResponseData;
                    return product != null && product.Id > 0;
                }
                else
                {
                    product = _productService.Edit(product).ResponseData;
                    return product != null;
                }
            }
            return false;
        }

        private DacProduct CreateSaveData()
        {
            DacProduct product = new DacProduct();
            product.Id = ucDataButtonProduct.DataMode == DataState.Edit ? LstProduct[gvProduct.FocusedRowHandle].Id : 0;
            product.Code = ucDataButtonProduct.DataMode == DataState.Insert ? txtProductCode.Text : LstProduct[gvProduct.FocusedRowHandle].Code;
            product.Name = txtProductName.Text;
            product.ProductCategoryId = lueProductCategory.EditValue as int?;
            product.RegisterNumber = txtRegisterNumber.Text;
            product.Manufacture = txtManufacture.Text;
            product.GeneralFormat = txtGeneralFormat.Text;
            product.Active = chkActive.Checked;
            product.Remark = rtxtRemark.Text;
            product.CreatedUser = ucDataButtonProduct.DataMode == DataState.Insert ? CommonBS.CurrentUser.LoginID : LstProduct[gvProduct.FocusedRowHandle].CreatedUser;
            product.ModifiedUser = ucDataButtonProduct.DataMode == DataState.Edit ? CommonBS.CurrentUser.LoginID : LstProduct[gvProduct.FocusedRowHandle].ModifiedUser;
            product.CreatedDate = ucDataButtonProduct.DataMode == DataState.Insert ? DateTime.Now : LstProduct[gvProduct.FocusedRowHandle].CreatedDate;
            product.ModifiedDate = ucDataButtonProduct.DataMode == DataState.Edit ? DateTime.Now : LstProduct[gvProduct.FocusedRowHandle].ModifiedDate;
            return product;
        }

        private void SaveProduct()
        {
            if(SaveData())
            {
                if (ucDataButtonProduct.DataMode == DataState.Insert)
                {
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommonBO.Instance().TraceLogEvent("Save Product: " + txtProductCode.Text + " - " + txtProductName.Text + " - "
                        + lueProductCategory.EditValue, CommonBS.CurrentUser.LoginID);
                }
                else if (ucDataButtonProduct.DataMode == DataState.Edit)
                {
                    MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Lưu nhật ký
                    CommonBO.Instance().TraceLogEvent("Edit Product: " + txtProductCode.Text + " - " + txtProductName.Text + " - "
                        + lueProductCategory.EditValue, CommonBS.CurrentUser.LoginID);
                }
                LoadData();
                ucDataButtonProduct.DataMode = DataState.View;
            }
            else CommonBS.SaveNotSuccessfully();
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonProduct_InsertHandler()
        {
            DacProductVM NewProduct = new DacProductVM();
            NewProduct.CreatedUser = CommonBS.CurrentUser.LoginID;
            NewProduct.Active = true;
            LstProduct.Add(NewProduct);
            gcProduct.RefreshDataSource();
            gvProduct.FocusedRowHandle = LstProduct.IndexOf(LstProduct.Last());
            EnableControls(true);
            txtProductCode.Focus();
        }

        private void ucDataButtonProduct_SaveHandler()
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveProduct;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonProduct_EditHandler()
        {
            EnableControls(true);
            txtProductName.Focus();
        }

        private void ucDataButtonProduct_DeleteHandler()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (gvProduct.FocusedRowHandle < 0 || LstProduct == null || LstProduct.Count - 1 < gvProduct.FocusedRowHandle || LstProduct[gvProduct.FocusedRowHandle] == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần xóa!", "Thông báo" + Common.formSoftName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_productService.HasUsed(LstProduct[gvProduct.FocusedRowHandle].Code).ResponseData)
                {
                    MessageBox.Show("Sản phẩm này đã được sử dụng, bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool result = _productService.Delete(LstProduct[gvProduct.FocusedRowHandle].Id).ResponseData;
                    if (result)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ucDataButtonProduct_CancelHandler()
        {
            EnableControls(false);
            if(ucDataButtonProduct.DataMode == DataState.Insert)
            {
                if (gvProduct.RowCount > 1)
                {
                    gvProduct.DeleteRow(gvProduct.FocusedRowHandle);
                    gvProduct.FocusedRowHandle = 0;
                }
            }
            else
            {
                if (gvProduct.FocusedRowHandle >= 0 && originalObject != null)
                {
                    LstProduct[gvProduct.FocusedRowHandle] = originalObject.Clone();
                    originalObject = null;
                    if (gvProduct.FocusedRowHandle >= 0)
                    {
                        gvProduct_FocusedRowChanged(ucDataButtonProduct, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(gvProduct.FocusedRowHandle, gvProduct.FocusedRowHandle));
                    }
                }
            }
            ucDataButtonProduct.DataMode = DataState.View;
        }

        private void ucDataButtonProduct_CloseHandler()
        {
            if (ucDataButtonProduct.DataMode == DataState.Insert || ucDataButtonProduct.DataMode == DataState.Edit)
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

        private void gvProduct_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvProduct.FocusedRowHandle >= 0 && LstProduct[gvProduct.FocusedRowHandle] != null)
            {
                txtProductCode.Text = LstProduct[gvProduct.FocusedRowHandle].Code;
                txtProductName.Text = LstProduct[gvProduct.FocusedRowHandle].Name;
                lueProductCategory.EditValue = LstProduct[gvProduct.FocusedRowHandle].ProductCategoryId;
                txtRegisterNumber.Text = LstProduct[gvProduct.FocusedRowHandle].RegisterNumber;
                txtManufacture.Text = LstProduct[gvProduct.FocusedRowHandle].Manufacture;
                txtGeneralFormat.Text = LstProduct[gvProduct.FocusedRowHandle].GeneralFormat;
                lblCreatedDate.Text = LstProduct[gvProduct.FocusedRowHandle].CreatedDate.HasValue ? LstProduct[gvProduct.FocusedRowHandle].CreatedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                lblModifiedDate.Text = LstProduct[gvProduct.FocusedRowHandle].ModifiedDate.HasValue ? LstProduct[gvProduct.FocusedRowHandle].ModifiedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                rtxtRemark.Text = LstProduct[gvProduct.FocusedRowHandle].Remark;
                chkActive.Checked = LstProduct[gvProduct.FocusedRowHandle].Active.HasValue ? LstProduct[gvProduct.FocusedRowHandle].Active.Value : false;
                originalObject = LstProduct[gvProduct.FocusedRowHandle].Clone();
            }
            else
            {
                originalObject = null;
            }
        }
    }
}
