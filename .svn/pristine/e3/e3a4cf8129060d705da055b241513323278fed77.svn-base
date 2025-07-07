using DAC.Core;
using DAC.Core.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.Net.Http;
using System.Windows.Forms;

namespace PIPT.Agency
{
    public partial class frmDacStore : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacStore _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacStore Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacStore();
            }
            return _instance;
        }

        public static frmDacStore Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacStore Instance(Form parent, bool isActivate)
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
        DacStore dacStore = new DacStore();
        DacStore selectedDacStore = new DacStore();
        DacStoreCollection dacStoreCollection = new DacStoreCollection();
        DacStoreCS dacStoreCS = new DacStoreCS();
        BindingList<DacStore> bdlDacStore;
        bool bIsDataBinding = false;
        bool bIsGetDataFromServer = false;
        string AgencyCode = string.Empty, ProvinceCode = string.Empty;
        #endregion
        #region Form's Events
        public frmDacStore()
        {
            InitializeComponent();
        }
        private void frmDacAgency_Load(object sender, EventArgs e)
        {
            DAC.DAL.DacDbAccess dacDb = new DAC.DAL.DacDbAccess();
            dacDb.CreateNewSqlCommand();
            DataTable dataTable = dacDb.ExecuteDataTable("spProvince_SelectAll");
            comboBoxProvince.DataSource = dataTable;
            comboBoxProvince.DisplayMember = "Name";
            comboBoxProvince.ValueMember = "Code";
            // Get data from database
            dacStoreCollection = dacStoreCS.GetListStore();
            // Get BindingList DataSource
            AddObjectIntoBindingList(dacStoreCollection);
            // Get AgencyCode & ProvinceCode
            GetAgencyInfo();
        }
        #endregion
        #region Functions on Form
        private void AddObjectIntoBindingList(DacStoreCollection StoreCollection)
        {
            bdlDacStore = new BindingList<DacStore>();
            foreach (DacStore product in StoreCollection)
            {
                bdlDacStore.Add(product);
            }
            SetDataSource();
        }
        private void SetDataSource()
        {
            CommonCore.ClearDataBinding(panelStore);
            // Binding data to Controls
            bIsDataBinding = true;
            textBoxCode.DataBindings.Add("Text", bdlDacStore, "Code");
            textBoxName.DataBindings.Add("Text", bdlDacStore, "Name");
            textBoxAddress.DataBindings.Add("Text", bdlDacStore, "Address");
            comboBoxProvince.DataBindings.Clear();
            comboBoxProvince.DataBindings.Add("SelectedValue", bdlDacStore, "ProvinceCode");
            textBoxAgencyCode.DataBindings.Add("Text", bdlDacStore, "AgencyCode");
            textBoxShopKeeper.DataBindings.Add("Text", bdlDacStore, "ShopKeeper");
            textBoxPhoneNum.DataBindings.Add("Text", bdlDacStore, "PhoneNum");
            textBoxMobileNum.DataBindings.Add("Text", bdlDacStore, "MobileNum");
            textBoxEmail.DataBindings.Add("Text", bdlDacStore, "Email");
            richTextBoxDescription.DataBindings.Add("Text", bdlDacStore, "Description");
            dateTimePickerCreatedDate.DataBindings.Clear();
            dateTimePickerCreatedDate.DataBindings.Add("Value", bdlDacStore, "CreatedDate");
            checkBoxActive.DataBindings.Clear();
            checkBoxActive.DataBindings.Add("Checked", bdlDacStore, "Active");

            dataGridViewStore.DataSource = bdlDacStore;
            bIsDataBinding = false;
            EnableControls(bIsDataBinding);
        }
        private DacStore GetSelectedStore(string sCode)
        {
            foreach (DacStore store in dacStoreCollection)
            {
                if (store.Code == sCode)
                    return store;
            }
            return null;
        }
        private bool IsStoreCodeExists(string sCode)
        {
            foreach (DacStore store in dacStoreCollection)
            {
                if (store.Code == sCode.Trim().ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelStore.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
            if (ucDataButtonStore.DataMode == DataState.Edit)
            {
                textBoxCode.Enabled = false;
                dateTimePickerCreatedDate.Enabled = false;
            }
        }
        private bool IsChangedData()
        {
            if (ucDataButtonStore.DataMode == DataState.Insert)
            {
                if (textBoxCode.Text.Trim().Length > 0 || textBoxName.Text.Trim().Length > 0)
                    return true;
                else
                    return false;
            }
            else if (ucDataButtonStore.DataMode == DataState.Edit)
            {
                if (selectedDacStore.Code != textBoxCode.Text.Trim()
                || selectedDacStore.Name != textBoxName.Text.Trim()
                || selectedDacStore.Address != textBoxAddress.Text.Trim()
                || selectedDacStore.ProvinceCode != comboBoxProvince.SelectedValue.ToString()
                || selectedDacStore.ShopKeeper != textBoxShopKeeper.Text.Trim()
                || selectedDacStore.PhoneNum != textBoxPhoneNum.Text.Trim()
                || selectedDacStore.MobileNum != textBoxMobileNum.Text.Trim()
                || selectedDacStore.Email != textBoxEmail.Text.Trim()
                || selectedDacStore.Description != richTextBoxDescription.Text.Trim()
                || selectedDacStore.Active != checkBoxActive.Checked)
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
            if (ucDataButtonStore.DataMode == DataState.Insert && IsStoreCodeExists(textBoxCode.Text))
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
        private bool SaveData()
        {
            if (IsDataOK() == false) return false;

            bool bResult = true;
            if (ucDataButtonStore.DataMode == DataState.Insert)
            {
                DacStore store = new DacStore();
                store.Code = textBoxCode.Text.Trim().ToUpper();
                store.Name = textBoxName.Text.Trim();
                store.Address = textBoxAddress.Text.Trim();
                store.ProvinceCode = comboBoxProvince.SelectedValue.ToString();
                store.AgencyCode = textBoxAgencyCode.Text.Trim();
                store.ShopKeeper = textBoxShopKeeper.Text.Trim();
                store.PhoneNum = textBoxPhoneNum.Text.Trim();
                store.MobileNum = textBoxMobileNum.Text.Trim();
                store.Email = textBoxEmail.Text.Trim();
                store.Description = richTextBoxDescription.Text.Trim();
                store.CreatedDate = dateTimePickerCreatedDate.Value;
                store.Active = checkBoxActive.Checked;

                bResult = dacStoreCS.Insert(store);
                //if(bResult)
                    // Upload to server
                    //this.UploadStoreToServer(store);
            }
            else
            {
                // Update data in to databaseDacstore
                selectedDacStore.Code = textBoxCode.Text.Trim().ToUpper();
                selectedDacStore.Name = textBoxName.Text.Trim();
                selectedDacStore.Address = textBoxAddress.Text.Trim();
                selectedDacStore.ProvinceCode = comboBoxProvince.SelectedValue.ToString();
                selectedDacStore.ShopKeeper = textBoxShopKeeper.Text.Trim();
                selectedDacStore.AgencyCode = textBoxAgencyCode.Text.Trim();
                selectedDacStore.PhoneNum = textBoxPhoneNum.Text.Trim();
                selectedDacStore.MobileNum = textBoxMobileNum.Text.Trim();
                selectedDacStore.Email = textBoxEmail.Text.Trim();
                selectedDacStore.Description = richTextBoxDescription.Text.Trim();
                selectedDacStore.CreatedDate = dateTimePickerCreatedDate.Value;
                selectedDacStore.Active = checkBoxActive.Checked;

                bResult = dacStoreCS.Update(selectedDacStore);
                //if (bResult)
                    // Update to Server
                    //this.UpdateStoreOnServer(selectedDacStore);
            }
            // Kiem tra luu thanh cong khong de load lai du lieu
            if (bResult)
            {
                // Get data from database
                dacStoreCollection = dacStoreCS.GetListStore();
                AddObjectIntoBindingList(dacStoreCollection);
                CommonBS.SaveSuccessfully();
                ucDataButtonStore.DataMode = DataState.View;
                ucDataButtonStore.SetInsertFocus();
                EnableControls(false);
            }
            else CommonBS.SaveNotSuccessfully();

            return bResult;
        }
        private void SaveStore()
        {
            SaveData();
        }
        private void GetAgencyInfo()
        {
            DacAgencyCS agencyCS = new DacAgencyCS();
            DacAgencyCollection agencyCollection = agencyCS.GetListAgency();
            if (agencyCollection.Count > 0)
            {
                AgencyCode = agencyCollection[0].Code;
                ProvinceCode = agencyCollection[0].ProvinceCode;
            }
        }
        private async void GetAllStore(string _AgencyCode)
        {
            ApiHelper apiHelper = new ApiHelper();
            try
            {
                // Get BindingList DataSource
                dacStoreCollection = await apiHelper.GetStoreAsync(_AgencyCode);
                AddObjectIntoBindingList(dacStoreCollection);
            }
            catch (HttpRequestException rex)
            {
                MessageBox.Show("Lỗi khi nhận dữ liệu: \r\n" + rex.Message, this.Text);
            }
        }
        private async void GetAllStore(int ID, string _AgencyCode)
        {
            ApiHelper apiHelper = new ApiHelper();
            try
            {
                // Get BindingList DataSource
                dacStoreCollection = await apiHelper.GetStoreAsync(ID, _AgencyCode);
                AddObjectIntoBindingList(dacStoreCollection);
            }
            catch (HttpRequestException rex)
            {
                MessageBox.Show("Lỗi khi nhận dữ liệu: \r\n" + rex.Message, this.Text);
            }
        }
        private async void UploadStoreToServer(DAC.Core.Models.DacStoreViewModel dacStoreViewModel)
        {
            ApiHelper apiHelper = new ApiHelper();
            bool IsSuccess = await apiHelper.AddStoreAsync(dacStoreViewModel);
            if (IsSuccess)
            {
                MessageBox.Show("Đã Upload tất cả danh sách lên máy chủ!", this.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa upload được dữ liệu lên máy chủ. Vui lòng thử lại sau!", this.Text);
            }
        }
        private async void UploadStoreToServer(DacStore store)
        {
            ApiHelper apiHelper = new ApiHelper();
            bool IsSuccess = await apiHelper.AddStoreAsync(store);
            if (!IsSuccess)
            {
                MessageBox.Show("Bạn chưa upload được dữ liệu lên máy chủ. Vui lòng thử lại sau!", this.Text);
                // Lưu lại bảng để Upload dữ liệu lên sau

            }
        }
        private async void UpdateStoreOnServer(DacStore store)
        {
            ApiHelper apiHelper = new ApiHelper();
            bool IsSuccess = await apiHelper.UpdateStoreAsync(store);
            if (!IsSuccess)
            {
                MessageBox.Show("Bạn chưa xóa được dữ liệu trên máy chủ. Vui lòng thử lại sau!", this.Text);
            }
        }
        private async void DeleteStoreOnServer(string Code, string AgencyCode)
        {
            ApiHelper apiHelper = new ApiHelper();
            bool IsSuccess = await apiHelper.DeleteStoreAsync(Code, AgencyCode);
            if (!IsSuccess)
            {
                MessageBox.Show("Bạn chưa xóa được dữ liệu trên máy chủ. Vui lòng thử lại sau!", this.Text);
            }
        }

        #endregion
        #region Buttons' Event
        private void ucDataButtonStore_InsertHandler()
        {
            bdlDacStore.AddNew();
            //CommonCore.ClearTextBox(panelStore);
            EnableControls(true);
            textBoxCode.Focus();
            //Set focus for DataGridView
            if (dataGridViewStore.Rows.Count > 0)
            {
                int iCurrentRowIndex = dataGridViewStore.Rows.Count - 1;
                dataGridViewStore.CurrentCell = dataGridViewStore.Rows[iCurrentRowIndex].Cells[1];
                dataGridViewStore.Rows[iCurrentRowIndex].Selected = true;
            }
            comboBoxProvince.SelectedValue = ProvinceCode;
            textBoxAgencyCode.Text = AgencyCode;
        }

        private void ucDataButtonStore_SaveHandler()
        {

            if (bIsGetDataFromServer)
            {
                bool bResult = false;
                // Luu du lieu nhan duoc tu Server ve Database
                if (dacStoreCollection.Count > 0)
                {
                    foreach (DacStore Store in dacStoreCollection)
                    {
                        bResult = dacStoreCS.Insert(Store, Store.ID);
                    }
                }
                if (bResult)
                {
                    CommonBS.SaveSuccessfully();
                }
                bIsGetDataFromServer = false;
                ucDataButtonStore.DataMode = DataState.View;
            }
            else
            {
                Common objCommon = new Common();
                objCommon.CurrentForm = this;
                objCommon.CurrentFormMethodInvoker = SaveStore;
                objCommon.App_ShowWaitForm(DataState.Insert);
            }
        }

        private void ucDataButtonStore_EditHandler()
        {
            // Kiem tra xem co du lieu nao khong
            if (dataGridViewStore.Rows.Count == 0) return;
            // Lay du lieu de sua
            selectedDacStore = GetSelectedStore(dataGridViewStore.CurrentRow.Cells[ColumnCode.Name].Value.ToString());
            EnableControls(true);
            textBoxName.Focus();
        }

        private void ucDataButtonStore_DeleteHandler()
        {
            // Kiem tra xem co du lieu nao khong
            if (dataGridViewStore.Rows.Count == 0)
            {
                return;
            }
            // Lay du lieu de xoa
            selectedDacStore = GetSelectedStore(dataGridViewStore.CurrentRow.Cells[ColumnCode.Name].Value.ToString());
            // Kiem tra moi lien quan voi du lieu khac neu co
            if (dacStoreCS.Delete(selectedDacStore.Code, string.Empty))
            {
                CommonBS.DeleteSuccessfully();
                // Get data from database
                dacStoreCollection = dacStoreCS.GetListStore();
                AddObjectIntoBindingList(dacStoreCollection);
                // Delete data On Server
                //this.DeleteStoreOnServer(selectedDacStore.Code, selectedDacStore.AgencyCode);
            }
            else
                CommonBS.DeleteNotSuccessfully();
        }

        private void ucDataButtonStore_CancelHandler()
        {
            EnableControls(false);
            if (ucDataButtonStore.DataMode == DataState.Insert)
            {
                if (dataGridViewStore.Rows.Count > 1)
                {
                    dataGridViewStore.Rows.RemoveAt(dataGridViewStore.CurrentRow.Index);
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

        private void getAllStoreButton_Click(object sender, EventArgs e)
        {
            //Lưu dữ liệu lên máy chủ
            //DAC.Core.Models.DacStoreViewModel dacStoreViewModel = new DAC.Core.Models.DacStoreViewModel();
            //dacStoreViewModel.DacStoreCollection = dacStoreCollection;
            //this.UploadStoreToServer(dacStoreViewModel);
            if(AgencyCode == string.Empty)
            {
                MessageBox.Show("Bạn chưa có thông tin đại lý. Hãy liên hệ để lấy mã đại lý của mình!", this.Text);
                return;
            }
            if(!InternetConnection.IsInternetConnected())
            {
                MessageBox.Show("Bạn không có kết nối internet. Hãy kiểm tra mạng hoặc thử lại sau!", this.Text);
                return;
            }
            dacStoreCollection = dacStoreCS.GetListStore();
            if (dacStoreCollection.Count <= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn chưa nhà thuốc / cửa hàng nào! \r\nBạn có muốn nhận từ server?", this.Text, MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    // Get Store
                    this.GetAllStore(AgencyCode);
                }
            }
            else
            {
                // Get ID max
                int IdMax = 0;
                foreach (DacStore store in dacStoreCollection)
                {
                    if (store.ID > IdMax)
                    {
                        IdMax = store.ID;
                    }
                }
                // Get Store from ID
                this.GetAllStore(IdMax, AgencyCode);
            }
            bIsGetDataFromServer = true;
            ucDataButtonStore.DataMode = DataState.Insert;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dacStoreCollection = dacStoreCS.GetListStore(textBoxSearchCode.Text.Trim().ToUpper(), textBoxSearchName.Text, textBoxSearchMobileNum.Text);
            AddObjectIntoBindingList(dacStoreCollection);
        }
        #endregion
    }
}
