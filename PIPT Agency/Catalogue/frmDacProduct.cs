using DAC.Core;
using DAC.Core.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PIPT.Agency
{
    public partial class frmDacProduct : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacProduct _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacProduct Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacProduct();
            }
            return _instance;
        }

        public static frmDacProduct Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacProduct Instance(Form parent, bool isActivate)
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
        DacProduct dacProduct = new DacProduct();
        DacProduct selectedDacProduct = new DacProduct();
        DacProductCollection dacProductCollection = new DacProductCollection();
        DacProductCS dacProductCS = new DacProductCS();
        BindingList<DacProduct> bdlDacProduct;
        bool bIsGetDataFromServer = false;
        bool bIsDataBinding;
        #endregion
        #region Form's Events
        public frmDacProduct()
        {
            InitializeComponent();
        }
        private void frmDacProduct_Load(object sender, EventArgs e)
        {
            DAC.DAL.DacDbAccess dacDb = new DAC.DAL.DacDbAccess();
            dacDb.CreateNewSqlCommand();
            DataTable dataTable = dacDb.ExecuteDataTable("spDacProductCategory_SelectAll");
            // Add source to Category
            gridLookUpEditCategory.Properties.DataSource = dataTable;
            // Get data from database
            dacProductCollection = dacProductCS.GetListProduct();
            // Get BindingList DataSource
            AddObjectIntoBindingList(dacProductCollection);
        }
        #endregion
        #region Function on form
        private void AddObjectIntoBindingList(DacProductCollection ProductCollection)
        {
            bdlDacProduct = new BindingList<DacProduct>();
            foreach (DacProduct product in ProductCollection)
            {
                bdlDacProduct.Add(product);
            }
            SetDataSource();
        }
        private void SetDataSource()
        {
            CommonCore.ClearDataBinding(panelProduct);
            // Binding data to Controls
            bIsDataBinding = true;
            textBoxCode.DataBindings.Add("Text", bdlDacProduct, "Code");
            textBoxName.DataBindings.Add("Text", bdlDacProduct, "Name");
            gridLookUpEditCategory.DataBindings.Clear();
            gridLookUpEditCategory.DataBindings.Add("EditValue", bdlDacProduct, "ProductCategoryId");
            textBoxRegisterNumber.DataBindings.Add("Text", bdlDacProduct, "RegisterNumber");
            textBoxManufacture.DataBindings.Add("Text", bdlDacProduct, "Size");
            textBoxGeneralFormat.DataBindings.Add("Text", bdlDacProduct, "GeneralFormat");
            richTextBoxRemark.DataBindings.Add("Text", bdlDacProduct, "Remark");
            dateTimePickerCreatedDate.DataBindings.Clear();
            dateTimePickerCreatedDate.DataBindings.Add("Value", bdlDacProduct, "CreatedDate");
            dateTimePickerModifiedDate.DataBindings.Clear();
            dateTimePickerModifiedDate.DataBindings.Add("Value", bdlDacProduct, "ModifiedDate");
            checkBoxActive.DataBindings.Clear();
            checkBoxActive.DataBindings.Add("Checked", bdlDacProduct, "Active");

            gridControlProduct.DataSource = bdlDacProduct;
            bIsDataBinding = false;
            EnableControls(false);
        }
        private DacProduct GetSelectedProduct(string sCode)
        {
            foreach (DacProduct product in dacProductCollection)
            {
                if (product.Code == sCode)
                    return product;
            }
            return null;
        }
        private bool IsProductCodeExists(string sCode)
        {
            foreach (DacProduct product in dacProductCollection)
            {
                if (product.Code == sCode.Trim().ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelProduct.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonProduct.DataMode == DataState.Edit)
            {
                textBoxCode.Enabled = false;
                dateTimePickerCreatedDate.Enabled = false;
            }
        }
        private bool IsChangedData()
        {
            if (ucDataButtonProduct.DataMode == DataState.Insert)
            {
                if (textBoxCode.Text.Trim().Length > 0 || textBoxName.Text.Trim().Length > 0)
                    return true;
                else
                    return false;
            }
            else if (ucDataButtonProduct.DataMode == DataState.Edit)
            {
                if (selectedDacProduct.Code != textBoxCode.Text.Trim()
                || selectedDacProduct.Name != textBoxName.Text.Trim()
                || selectedDacProduct.ProductCategoryId != (int)gridLookUpEditCategory.EditValue
                || selectedDacProduct.RegisterNumber != textBoxRegisterNumber.Text.Trim()
                || selectedDacProduct.Size != textBoxManufacture.Text.Trim()
                || selectedDacProduct.Remark != richTextBoxRemark.Text.Trim()
                || selectedDacProduct.Active != checkBoxActive.Checked)
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
                MessageBox.Show("Bạn chưa nhập mã sản phẩm.", "Thông báo" + Common.formSoftName);
                textBoxCode.Focus();
                return false;
            }
            if (ucDataButtonProduct.DataMode == DataState.Insert && IsProductCodeExists(textBoxCode.Text))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại.", "Thông báo" + Common.formSoftName);
                textBoxCode.Focus();
                textBoxCode.SelectAll();
                return false;
            }
            if (textBoxName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm.", "Thông báo" + Common.formSoftName);
                textBoxName.Focus();
                return false;
            }
            return true;
        }
        private bool SaveData()
        {
            if (IsDataOK() == false) return false;

            bool bResult = true;
            if (ucDataButtonProduct.DataMode == DataState.Insert)
            {
                DacProduct product = new DacProduct();
                product.Code = textBoxCode.Text.Trim().ToUpper();
                product.Name = textBoxName.Text.Trim();
                product.ProductUnitId = 1;
                product.ProductCategoryId = (int)gridLookUpEditCategory.EditValue;
                product.RegisterNumber = textBoxRegisterNumber.Text.Trim();
                product.Size = textBoxManufacture.Text.Trim();
                product.Remark = richTextBoxRemark.Text.Trim();
                product.CreatedDate = dateTimePickerCreatedDate.Value;
                product.Manufacture = textBoxManufacture.Text.Trim();
                product.GeneralFormat = textBoxGeneralFormat.Text.Trim();
                product.CreatedUser = CommonBS.CurrentUser.LoginID;
                product.ModifiedDate = dateTimePickerModifiedDate.Value;
                product.ModifiedUser = string.Empty;
                product.Active = checkBoxActive.Checked;

                bResult = dacProductCS.Insert(product);
            }
            else
            {
                // Update data in to databaseDacProduct
                selectedDacProduct.Code = textBoxCode.Text.Trim().ToUpper();
                selectedDacProduct.Name = textBoxName.Text.Trim();
                selectedDacProduct.ProductUnitId = 1;
                selectedDacProduct.ProductCategoryId = (int)gridLookUpEditCategory.EditValue;
                selectedDacProduct.RegisterNumber = textBoxRegisterNumber.Text.Trim();
                selectedDacProduct.Size = textBoxManufacture.Text.Trim();
                selectedDacProduct.Remark = richTextBoxRemark.Text.Trim();
                selectedDacProduct.CreatedDate = dateTimePickerCreatedDate.Value;
                selectedDacProduct.Manufacture = textBoxManufacture.Text.Trim();
                selectedDacProduct.GeneralFormat = textBoxGeneralFormat.Text.Trim();
                selectedDacProduct.ModifiedDate = dateTimePickerModifiedDate.Value;
                selectedDacProduct.ModifiedUser = CommonBS.CurrentUser.LoginID;
                selectedDacProduct.Active = checkBoxActive.Checked;

                bResult = dacProductCS.Update(selectedDacProduct);
            }
            // Kiem tra luu thanh cong khong de load lai du lieu
            if (bResult)
            {
                // Get data from database
                dacProductCollection = dacProductCS.GetListProduct();
                AddObjectIntoBindingList(dacProductCollection);
                CommonBS.SaveSuccessfully();
                ucDataButtonProduct.DataMode = DataState.View;
                ucDataButtonProduct.SetInsertFocus();
                EnableControls(false);
            }
            else CommonBS.SaveNotSuccessfully();

            return bResult;
        }
        private void SaveProduct()
        {
            SaveData();
        }

        private async void GetAllProduct()
        {
            ApiHelper apiHelper = new ApiHelper();
            try
            {
                // Get BindingList DataSource
                dacProductCollection = await apiHelper.GetProductAsync();
                AddObjectIntoBindingList(dacProductCollection);
            }
            catch (HttpRequestException rex)
            {
                MessageBox.Show("Lỗi khi nhận dữ liệu: \r\n" + rex.Message, this.Text);
            }
        }

        private async void GetAllProduct(int Id)
        {
            ApiHelper apiHelper = new ApiHelper();
            try
            {
                // Get BindingList DataSource
                dacProductCollection = await apiHelper.GetProductAsync(Id);
                AddObjectIntoBindingList(dacProductCollection);
            }
            catch (HttpRequestException rex)
            {
                MessageBox.Show("Lỗi khi nhận dữ liệu: \r\n" + rex.Message, this.Text);
            }
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonProduct_InsertHandler()
        {
            bdlDacProduct.AddNew();
            //CommonCore.ClearTextBox(panelProduct);
            EnableControls(true);
            textBoxCode.Focus();
            //Set focus for DataGridView
            gridViewProduct.FocusedRowHandle = gridViewProduct.GetVisibleRowHandle(gridViewProduct.RowCount - 1);
        }

        private void ucDataButtonProduct_SaveHandler()
        {
            if (bIsGetDataFromServer)
            {
                bool bResult = false;
                // Luu du lieu nhan duoc tu Server ve Database
                if (dacProductCollection.Count > 0)
                {
                    foreach (DacProduct Product in dacProductCollection)
                    {
                        bResult = dacProductCS.Insert(Product, Product.Id);
                    }
                }
                if (bResult)
                {
                    CommonBS.SaveSuccessfully();
                }
                bIsGetDataFromServer = false;
                ucDataButtonProduct.DataMode = DataState.View;
            }
            else
            {
                Common objCommon = new Common();
                objCommon.CurrentForm = this;
                objCommon.CurrentFormMethodInvoker = SaveProduct;
                objCommon.App_ShowWaitForm(DataState.Insert);
            }
        }

        private void ucDataButtonProduct_EditHandler()
        {
            // Kiem tra xem co du lieu nao khong
            if (gridViewProduct.RowCount == 0) return;
            // Lay du lieu de sua
            selectedDacProduct = GetSelectedProduct(gridViewProduct.GetFocusedRowCellValue(gridColumnCode).ToString());
            EnableControls(true);
            textBoxName.Focus();
        }

        private void ucDataButtonProduct_DeleteHandler()
        {
            // Kiem tra xem co du lieu nao khong
            if (gridViewProduct.RowCount == 0)
            {
                return;
            }
            // Lay du lieu de xoa
            selectedDacProduct = GetSelectedProduct(gridViewProduct.GetFocusedRowCellValue(gridColumnCode).ToString());
            // Kiem tra moi lien quan voi du lieu khac neu co
            if (dacProductCS.Delete(selectedDacProduct.Code))
            {
                CommonBS.DeleteSuccessfully();
                // Get data from database
                dacProductCollection = dacProductCS.GetListProduct();
                AddObjectIntoBindingList(dacProductCollection);
            }
            else
                CommonBS.DeleteNotSuccessfully();
        }

        private void ucDataButtonProduct_CancelHandler()
        {
            EnableControls(false);
            if (ucDataButtonProduct.DataMode == DataState.Insert)
            {
                if (gridViewProduct.RowCount > 1)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = gridControlProduct.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            ucDataButtonProduct.DataMode = DataState.View;
        }

        private void ucDataButtonProduct_CloseHandler()
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

        private void buttonGetAllProduct_Click(object sender, EventArgs e)
        {
            dacProductCollection = dacProductCS.GetListProduct();
            if (dacProductCollection.Count <= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn chưa có sản phẩm nào! \r\nBạn có muốn nhận sản phẩm từ server?", this.Text, MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    // Get Product
                    this.GetAllProduct();
                }
            }
            else
            {
                // Get ID max
                int IdMax = 0;
                foreach (DacProduct product in dacProductCollection)
                {
                    if (product.Id > IdMax)
                    {
                        IdMax = product.Id;
                    }
                }
                // Get Product from ID
                this.GetAllProduct(IdMax);
            }
            bIsGetDataFromServer = true;
            ucDataButtonProduct.DataMode = DataState.Insert;
        }
        #endregion
    }
}