using DAC.Core;
using DAC.Core.Security;
using DAC.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacDistributeToFactory : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacDistributeToFactory _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacDistributeToFactory Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacDistributeToFactory();
            }
            return _instance;
        }

        public static frmDacDistributeToFactory Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacDistributeToFactory Instance(Form parent, bool isActivate)
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
        List<DacExport1> distributeToFactoryCollection = new List<DacExport1>();
        List<DacExportDetail1> distributeDetailsCollection = new List<DacExportDetail1>();
        BindingList<DacExport1> bdlDistributeToFactory;
        BindingList<DacExportDetail1> bdlDistributeDetails;
        DacDistributeToFactoryCS distributeToFactoryCS = new DacDistributeToFactoryCS();
        DacDistributeToFactoryDetailsCS dacDistributeDetailsCS = new DacDistributeToFactoryDetailsCS();
        // DataView for Agency table
        DataView dvFactory;
        // DataView for Product table
        DataView dvProduct;
        int iCurrentID = 0;
        // Check Box Select All
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;
        // --------------------
        #endregion
        #region Form's Events
        public frmDacDistributeToFactory()
        {
            InitializeComponent();
        }
        private void frmDacDistributeToFactory_Load(object sender, EventArgs e)
        {
            InitData();
            InitLookUp();
            // Get Max order number
            textBoxOrderNumber.Text = this.GetMaxOrderNumber();
            // Get distributeToAgencyCollection from database
            // -----------------------------------------
            // Dinh lai thoi gia de load du lieu tai day
            // -----------------------------------------
            distributeToFactoryCollection = distributeToFactoryCS.GetListDistributeToFactory(
                DateTime.Parse(CommonBO.GetSecConfig("DateStartGettingData").Value),
                DateTime.Now, string.Empty, string.Empty);
            //AddObjectDistributorIntoBindingList(distributeToFactoryCollection);
            // Get data from database
            //AddObjectDetailsIntoBindingList(DacExportDetail1);
            EnableControls(false);

            // Init Events For Select All CheckBox
            AddHeaderCheckBox();

            HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            dataGridViewDetails.CellValueChanged += new DataGridViewCellEventHandler(dataGridViewDetails_CellValueChanged);
            dataGridViewDetails.CurrentCellDirtyStateChanged += new EventHandler(dataGridViewDetails_CurrentCellDirtyStateChanged);
            dataGridViewDetails.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridViewDetails_CellPainting);

            //SetDistributeDetailsDataSource()
            // -----------------------------
        }

        private void frmDacDistributeToFactory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ucDataButtonAgency.DataMode == DataState.Insert)
            {
                if (CommonCore.FormClosing("Bạn chưa lưu đơn hàng xuất này. Bạn có muốn lưu lại?"))
                {
                    //Luu lai du lieu xong thoat form;
                    this.SaveData();
                }
            }
        }
        #endregion
        #region Function on form
        private void InitData()
        {
            DAC.DAL.DacDbAccess dacDb = new DAC.DAL.DacDbAccess();
            dacDb.CreateNewSqlCommand();
            DataSet ds = new DataSet("Factory_Product");
            DataTable dataTable = dacDb.ExecuteDataTable("spDacFactory_SelectAll");
            // Add table Agency
            dataTable.TableName = "Factories";
            ds.Tables.Add(dataTable);

            dataTable = dacDb.ExecuteDataTable("spProvince_SelectAll");
            comboBoxProvince.DataSource = dataTable;
            comboBoxProvince.DisplayMember = "Name";
            comboBoxProvince.ValueMember = "Code";
            dacDb.AddParameter("@FactoryCode", string.Empty);
            dataTable = dacDb.ExecuteDataTable("spDacProduct_SelectAll");
            // Add table Product
            dataTable.TableName = "Products";
            ds.Tables.Add(dataTable);

            DataViewManager dvm = new DataViewManager(ds);
            dvFactory = dvm.CreateDataView(ds.Tables["Factories"]);
            dvProduct = dvm.CreateDataView(ds.Tables["Products"]);
        }
        private void InitLookUp()
        {
            // The data source for the dropdown rows
            gridLookUpEditFactory.Properties.DataSource = dvFactory;
            gridLookUpEditProduct.Properties.DataSource = dvProduct;
            gridLookUpEditProductChoose.Properties.DataSource = dvProduct;
        }
        private void AddObjectDistributorIntoBindingList(List<DacExport1> DistributeToFactoryCollection)
        {
            bdlDistributeToFactory = new BindingList<DacExport1>();
            foreach (DacExport1 DistributeToFactory in DistributeToFactoryCollection)
            {
                bdlDistributeToFactory.Add(DistributeToFactory);
            }
            SetDataSource();
        }
        private void SetDataSource()
        {
            CommonCore.ClearDataBinding(panelDistributeToFactory);
            // Binding data to Controls
            textBoxOrderNumber.DataBindings.Add("Text", bdlDistributeToFactory, "OrderNumber");
            comboBoxProvince.DataBindings.Clear();
            comboBoxProvince.DataBindings.Add("SelectedValue", bdlDistributeToFactory, "ProvinceCode");
            textBoxQuantity.DataBindings.Add("Text", bdlDistributeToFactory, "Quantity");
            gridLookUpEditFactory.DataBindings.Clear();
            gridLookUpEditFactory.DataBindings.Add("EditValue", bdlDistributeToFactory, "FactoryCode");
            //gridLookUpEditProduct.DataBindings.Clear();
            //gridLookUpEditProduct.DataBindings.Add("EditValue", bdlDistributeToAgency, "ProductCode");
            richTextBoxDescription.DataBindings.Add("Text", bdlDistributeToFactory, "Description");
            dateTimePickerCreatedDate.DataBindings.Clear();
            dateTimePickerCreatedDate.DataBindings.Add("Value", bdlDistributeToFactory, "CreatedDate");
            checkBoxActive.DataBindings.Clear();
            checkBoxActive.DataBindings.Add("Checked", bdlDistributeToFactory, "Active");
            // Huy su kien SelectionChanged truoc khi gan DataSource
            this.gridViewDistributor.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDistributor_FocusedRowChanged);
            gridControlDistributor.DataSource = bdlDistributeToFactory;
            this.gridViewDistributor.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDistributor_FocusedRowChanged);
            if (bdlDistributeToFactory.Count > 0)
            {
                this.GetDetailData();
            }
            EnableControls(false);
        }
        private void AddObjectDetailsIntoBindingList(List<DacExportDetail1> distributeDetailsCollection)
        {
            bdlDistributeDetails = new BindingList<DacExportDetail1>();
            foreach (DacExportDetail1 distributeDetail in distributeDetailsCollection)
            {
                bdlDistributeDetails.Add(distributeDetail);
            }
            SetDistributeDetailsDataSource();
        }
        private void SetDistributeDetailsDataSource()
        {
            gridLookUpEditProduct.DataBindings.Clear();
            gridLookUpEditProduct.DataBindings.Add("EditValue", bdlDistributeDetails, "ProductCode");
            dataGridViewDetails.DataSource = bdlDistributeDetails;

            TotalCheckBoxes = dataGridViewDetails.RowCount;
            TotalCheckedCheckBoxes = 0;
        }
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelDistributeToFactory.Controls)
            {
                if (ctrl.Name != "checkEditKeepOrder")
                    ctrl.Enabled = bIsEnabled;
            }
        }
        private bool IsChangedData()
        {
            if (ucDataButtonAgency.DataMode == DataState.Insert)
            {
            }
            else if (ucDataButtonAgency.DataMode == DataState.Edit)
            {
                //if (selectedDacProduct.ProductUnitId != (int)comboBoxAgency.SelectedValue
                //|| selectedDacProduct.ProductCategoryId != (int)comboBoxProvince.SelectedValue
                //|| selectedDacProduct.Remark != richTextBoxDescription.Text.Trim()
                //|| selectedDacProduct.Active != checkBoxActive.Checked)
                //    return true;
                //else
                //    return false;
            }
            return false;
        }
        private bool IsDataOK()
        {
            if (gridLookUpEditFactory.Properties.GetIndexByKeyValue(gridLookUpEditFactory.EditValue) < 0)
            {
                MessageBox.Show("Bạn chưa chọn mã Xưởng sản xuất nào.", "Thông báo" + Common.formSoftName);
                gridLookUpEditFactory.Focus();
                return false;
            }
            //if (comboBoxProvince.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Đại lý bạn chọn chưa có mã tỉnh, bạn phải cập nhật mã tỉnh!.", "Thông báo" + Common.formSoftName);
            //    comboBoxProvince.Focus();
            //    return false;
            //}
            if (dataGridViewDetails.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập bất kỳ mã an ninh nào.", "Thông báo" + Common.formSoftName);
                textBoxDacCode.Focus();
                return false;
            }
            return true;
        }
        private bool SaveData()
        {
            if (IsDataOK() == false) return false;

            bool bResult = true;
            if (ucDataButtonAgency.DataMode == DataState.Insert)
            {
                DacExport1 distributeToFactory = new DacExport1();

                distributeToFactory.OrderNumber = textBoxOrderNumber.Text;
                // Kiem tra lai OrderNumber
                if (System.Configuration.ConfigurationManager.AppSettings["AutoIncreaseOrder"].ToString() == "true")
                {
                    if (this.GetMaxOrderNumber() != distributeToFactory.OrderNumber)
                    {
                        distributeToFactory.OrderNumber = this.GetMaxOrderNumber();
                        textBoxOrderNumber.Text = distributeToFactory.OrderNumber;
                    }
                }
                distributeToFactory.CreatedDate = dateTimePickerCreatedDate.Value;
                distributeToFactory.CustomerCode = string.Empty; // comboBoxProvince.SelectedValue.ToString();
                distributeToFactory.Quantity = Convert.ToDouble(textBoxQuantity.Text);
                distributeToFactory.Description = richTextBoxDescription.Text;
                distributeToFactory.Active = checkBoxActive.Checked;

                bResult = distributeToFactoryCS.Insert(distributeToFactory, ref iCurrentID);
                if (bResult)
                {
                    gridViewDistributor.SetFocusedRowCellValue(gridColumnID, iCurrentID);
                    // Doi lai ID da luu trong database
                    for (int i = 0; i < distributeDetailsCollection.Count; i++)
                    {
                        distributeDetailsCollection[i].ExportId = iCurrentID;
                    }
                    // Convert list to datatable
                    DataTable dataTable = CommonCore.GetDataTable(distributeDetailsCollection, typeof(DacExportDetail1));
                    dataTable.TableName = "DacDistributeToFactoryDetails"; // Ten bang trong CSDL
                    DacDistributeToFactoryDetailsCS dacDistributeDetailsCS = new DacDistributeToFactoryDetailsCS();
                    // Khai bao mang cac cot trong bang du lieu can mapping
                    string[] sColumnName = new string[] { "DistributorID", "DacCode", "ProductCode" };
                    CommonCore.PerformBulkCopy(dataTable, sColumnName);
                    bResult = true;
                }
            }
            else
            {
                // Update data in to DacDistributeToFactory
                DacExport1 distributeToFactory = new DacExport1();
                distributeToFactory = (DacExport1)gridViewDistributor.GetRow(gridViewDistributor.FocusedRowHandle);
                // Update to DataBase
                bResult = distributeToFactoryCS.Update(distributeToFactory);
            }
            // Kiem tra luu thanh cong khong de load lai du lieu
            if (bResult)
            {
                if (ucDataButtonAgency.DataMode == DataState.Insert)
                {
                    // Get distributeToAgencyCollection from database
                    // -----------------------------------------
                    // Dinh lai thoi gia de load du lieu tai day
                    // -----------------------------------------
                    distributeToFactoryCollection = distributeToFactoryCS.GetListDistributeToFactory(
                        DateTime.Parse(CommonBO.GetSecConfig("DateStartGettingData").Value),
                        DateTime.Now, string.Empty, string.Empty);
                    AddObjectDistributorIntoBindingList(distributeToFactoryCollection);
                    // Get data from database
                    AddObjectDetailsIntoBindingList(distributeDetailsCollection);
                    // CommonBS.SaveSuccessfully();
                }
                ucDataButtonAgency.DataMode = DataState.View;
                ucDataButtonAgency.SetInsertFocus();
                EnableControls(false);
                this.GetDetailData();
            }
            else CommonBS.SaveNotSuccessfully();

            return bResult;
        }
        private void SaveDistributeToAgency()
        {
            SaveData();
        }
        private void AddDistributDetails(DacExportDetail1 distributeDetails)
        {
            // Kiem tra su ton tai cua ma QRCode
            foreach (DacExportDetail1 detail in distributeDetailsCollection)
            {
                // Neu co roi thi thoat luon khoi ham.
                if (detail.DacCode == distributeDetails.DacCode)
                {
                    MessageBox.Show("Mã QRCode này đã tồn tại trong CSDL. \r\nBạn không thể thêm QRCode được nữa!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }
            // Kiem tra trong database
            List<DacExportDetail1> detailsCollection = dacDistributeDetailsCS.GetDistributeDetails(distributeDetails.DacCode);
            if (detailsCollection.Count > 0)
            {
                MessageBox.Show("Mã QRCode này đã tồn tại trong CSDL. \r\nBạn không thể thêm QRCode được nữa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            // Kiem tra neu khong phai dang Insert thi lay ID cua dong dang focus.
            if (ucDataButtonAgency.DataMode != DataState.Insert)
            {
                int iDistributorID = (int)gridViewDistributor.GetFocusedRowCellValue(gridColumnID);
                // Gan lai ID cho DistributeDetails
                distributeDetails.ExportId = iDistributorID;
            }
            distributeDetailsCollection.Add(distributeDetails);
            labelProductCount.Text = String.Format("Số sản phẩm đã thêm: {0:0,0}", distributeDetailsCollection.Count);
            textBoxQuantity.Text = distributeDetailsCollection.Count.ToString();
            AddObjectDetailsIntoBindingList(distributeDetailsCollection);
            //Set focus on DataGridView
            if (dataGridViewDetails.Rows.Count > 0)
            {
                dataGridViewDetails.CurrentCell = dataGridViewDetails.Rows[dataGridViewDetails.Rows.Count - 1].Cells[2];
                dataGridViewDetails.Rows[dataGridViewDetails.Rows.Count - 1].Cells[2].Selected = true;
            }
        }

        private void gridViewDistributor_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetailData();
        }

        private void GetDetailData()
        {
            if (gridViewDistributor.RowCount == 0)
                return;
            if (gridViewDistributor.FocusedRowHandle < 0)
                return;
            try
            {
                DacDistributeToFactoryDetailsCS distributeDetailsCS = new DacDistributeToFactoryDetailsCS();
                int iDistributorID = (int)gridViewDistributor.GetRowCellValue(gridViewDistributor.FocusedRowHandle, "ID");
                distributeDetailsCollection = distributeDetailsCS.GetDistributeDetails(iDistributorID);
                AddObjectDetailsIntoBindingList(distributeDetailsCollection);
                labelProductCount.Text = String.Format("Số sản phẩm đã thêm: {0:0,0}", distributeDetailsCollection.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PIPT - Thông báo");
                return;
            }
        }
        // Get Max order number
        private string GetMaxOrderNumber()
        {
            string OrderNumber = string.Empty;
            SecConfig secConfig = CommonBO.GetSecConfig("AutoIncreaseFactory");
            if (secConfig.Value == "true")
            {
                OrderNumber = DacDistributeToFactoryCS.GetMaxOrderNumber();
            }
            return OrderNumber;
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonProduct_InsertHandler()
        {
            // Lay gia tri Agency va Product de giu lai
            string AgencyCode = gridLookUpEditFactory.EditValue.ToString();
            string ProductCode = gridLookUpEditProduct.EditValue.ToString();
            string Order = textBoxOrderNumber.Text;
            //bdlDistributeToAgency.AddNew();
            DevExpress.XtraGrid.Views.Grid.GridView view = gridControlDistributor.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
            view.AddNewRow();
            gridControlDistributor.RefreshDataSource();
            EnableControls(true);
            //Set focus for DataGridView
            gridViewDistributor.FocusedRowHandle = gridViewDistributor.GetVisibleRowHandle(gridViewDistributor.RowCount - 1);
            // Kiem tra neu giu lai lenh thi khong tang lenh len nua
            if (checkEditKeepOrder.Checked)
            {
                textBoxOrderNumber.Text = Order;
                gridLookUpEditFactory.EditValue = AgencyCode;
                gridLookUpEditProduct.EditValue = ProductCode;
            }
            else
            {
                // Get Max order number
                textBoxOrderNumber.Text = this.GetMaxOrderNumber();
            }
        }

        private void ucDataButtonProduct_SaveHandler()
        {
            // Cảnh báo chưa chọn KH
            // Lưu nhật ký
            CommonBO.Instance().TraceLogEvent("Lưu phân phối đến Đại lý: " + textBoxOrderNumber.Text + " - "
                + textBoxQuantity.Text + " - " + gridLookUpEditFactory.EditValue, CommonBS.CurrentUser.LoginID);
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveDistributeToAgency;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonProduct_EditHandler()
        {
            // Lưu nhật ký
            CommonBO.Instance().TraceLogEvent("Sửa phân phối đến Đại lý: " + textBoxOrderNumber.Text + " - "
                + textBoxQuantity.Text + " - " + gridLookUpEditFactory.EditValue, CommonBS.CurrentUser.LoginID);
            // Kiem tra xem co du lieu nao khong
            if (dataGridViewDetails.Rows.Count == 0) return;
            // Lay du lieu de sua
            EnableControls(true);
        }

        private void ucDataButtonProduct_DeleteHandler()
        {
            // Kiem tra xem co du lieu nao khong
            if (dataGridViewDetails.Rows.Count == 0)
            {
                return;
            }
            // Lay du lieu de xoa
            int ID = (int)gridViewDistributor.GetFocusedRowCellValue(gridColumnID);
            if (ID > -1)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa mục này?", "Thong bao", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    distributeToFactoryCS.Delete(ID);
                    try
                    {
                        // Lưu nhật ký
                        CommonBO.Instance().TraceLogEvent("Xóa phân phối đến Đại lý: ID = " + ID + " - " + textBoxOrderNumber.Text + " - "
                            + textBoxQuantity.Text + " - " + gridLookUpEditFactory.EditValue, CommonBS.CurrentUser.LoginID);
                        DevExpress.XtraGrid.Views.Grid.GridView view = gridControlDistributor.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                        view.DeleteRow(view.FocusedRowHandle);
                    }
                    catch
                    {
                        return;
                    }
                }
            }
            // Kiem tra moi lien quan voi du lieu khac neu co
        }

        private void ucDataButtonProduct_CancelHandler()
        {
            EnableControls(false);
            if (ucDataButtonAgency.DataMode == DataState.Insert)
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = gridControlDistributor.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                view.DeleteRow(view.FocusedRowHandle);
            }
            // Gan lai trang thai view
            ucDataButtonAgency.DataMode = DataState.View;
            //Set focus for DataGridView
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

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (gridLookUpEditProductChoose.Properties.GetIndexByKeyValue(gridLookUpEditProductChoose.EditValue) >= 0)
            {
                var NewDetail = new DacExportDetail1();
                NewDetail.ExportId = gridLookUpEditFactory.Properties.GetIndexByKeyValue(gridLookUpEditFactory.EditValue);
                NewDetail.DacCode = CommonCore.GetSerialFromScanner(textBoxDacCode.Text.Trim());
                NewDetail.ProductCode = gridLookUpEditProductChoose.EditValue.ToString();
                AddDistributDetails(NewDetail);
                textBoxDacCode.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào, hãy chọn một sản phẩm để tiếp tục!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void buttonUpdateDetail_Click(object sender, EventArgs e)
        {
            try
            {
                int iQuantity = 0;
                string sContent = string.Empty;
                foreach (DacExportDetail1 details in distributeDetailsCollection)
                {
                    if (details.Id == 0)
                    {
                        dacDistributeDetailsCS.Insert(details);
                        iQuantity += 1;
                        sContent += details.DacCode + "-" + details.ProductCode + ", ";
                    }
                }
                if (iQuantity > 0 && distributeDetailsCollection[0].ExportId.HasValue)
                {
                    // Lưu nhật ký
                    CommonBO.Instance().TraceLogEvent("Thêm QRCode vào lệnh phân phối đến Đại lý: " + textBoxOrderNumber.Text + " - "
                        + textBoxQuantity.Text + " - " + gridLookUpEditFactory.EditValue + " - " + sContent, CommonBS.CurrentUser.LoginID);
                    distributeToFactoryCS.Update(distributeDetailsCollection[0].ExportId.Value, iQuantity);
                }
                this.GetDetailData();
                MessageBox.Show("Bạn đã thêm các mã QRCode thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Có lỗi đã xảy ra khi thêm các mã QRCode!", "Thông báo");
            }
        }

        private void buttonDetailDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa mã QRCode đã chọn?", "Thong bao - Xoa ma QRCode", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sContent = string.Empty;
                List<DacExportDetail1> detailsCollection = new List<DacExportDetail1>();
                foreach (DataGridViewRow Row in dataGridViewDetails.Rows)
                    if (((DataGridViewCheckBoxCell)Row.Cells["IsSelected"]).Value != null)
                    {
                        if ((bool)((DataGridViewCheckBoxCell)Row.Cells["IsSelected"]).Value)
                        {
                            DacExportDetail1 distributeDetails = (DacExportDetail1)Row.DataBoundItem;
                            detailsCollection.Add(distributeDetails);
                            if (distributeDetails.Id > 0)
                            {
                                // Xoa tren Database
                                dacDistributeDetailsCS.Delete(distributeDetails.Id);
                                sContent += distributeDetails.DacCode + "-" + distributeDetails.ProductCode + ", ";
                            }
                        }
                    }
                // Lưu nhật ký
                CommonBO.Instance().TraceLogEvent("Xóa QRCode khỏi lệnh phân phối đến Xưởng SX: " + textBoxOrderNumber.Text + " - "
                    + textBoxQuantity.Text + " - " + gridLookUpEditFactory.EditValue + " - " + sContent, CommonBS.CurrentUser.LoginID);
                foreach (DacExportDetail1 distributeDetails in detailsCollection)
                {
                    bdlDistributeDetails.Remove(distributeDetails);
                    distributeDetailsCollection.Remove(distributeDetails);
                }
                bdlDistributeDetails.ResetBindings();
            }
        }

        private void textBoxDacCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string DacCode = textBoxDacCode.Text.Trim();
                if (DacCode.Length >= 7)
                {
                    string serial = CommonCore.GetSerialFromScanner(DacCode);
                    string PackageType = DacCode.Substring(0, 3);
                    switch (PackageType)
                    {
                        case "PKG":
                        case "CON":
                            DacPackageDetailsCS dacPackageDetailsCS = new DacPackageDetailsCS();
                            List<DacPackageDetails> PackageDetailsCollection = dacPackageDetailsCS.GetPackageDetails(DacCode, PackageType);
                            if (PackageDetailsCollection.Count > 0)
                            {
                                foreach (DacPackageDetails packageDetails in PackageDetailsCollection)
                                {
                                    var NewDetail = new DacExportDetail1();
                                    NewDetail.ExportId = gridLookUpEditFactory.Properties.GetIndexByKeyValue(gridLookUpEditFactory.EditValue);
                                    NewDetail.DacCode = packageDetails.DacCode;
                                    AddDistributDetails(NewDetail);
                                    textBoxDacCode.Text = string.Empty;
                                }
                            }
                            break;
                        default:
                            if (gridLookUpEditProductChoose.Properties.GetIndexByKeyValue(gridLookUpEditProductChoose.EditValue) >= 0)
                            {
                                var NewDetail = new DacExportDetail1();
                                NewDetail.ExportId = gridLookUpEditFactory.Properties.GetIndexByKeyValue(gridLookUpEditFactory.EditValue);
                                NewDetail.DacCode = serial;
                                NewDetail.ProductCode = gridLookUpEditProductChoose.EditValue.ToString();
                                AddDistributDetails(NewDetail);
                                textBoxDacCode.Text = string.Empty;
                            }
                            else
                            {
                                //MessageBox.Show("Bạn chưa chọn sản phẩm nào, hãy chọn một sản phẩm để tiếp tục!", "Thông báo", MessageBoxButtons.OK);
                                var NewDetail = new DacExportDetail1();
                                NewDetail.ExportId = gridLookUpEditFactory.Properties.GetIndexByKeyValue(gridLookUpEditFactory.EditValue);
                                NewDetail.DacCode = serial;
                                AddDistributDetails(NewDetail);
                                textBoxDacCode.Text = string.Empty;
                            }
                            break;
                    }
                }
            }
        }

        private void buttonRefreshAgency_Click(object sender, EventArgs e)
        {
            InitData();
            InitLookUp();
        }

        private void GetRangSerialNumber(string frSerie, string toSerie)
        {
            try
            {
                string sPreSeriValue = ConfigurationManager.AppSettings["PreSeri"].ToString();
                string[] sPreSeris = sPreSeriValue.Split(',');
                string sPreSeri = string.Empty;
                if (sPreSeriValue.Length > 0)
                {
                    foreach (string PreSeri in sPreSeris)
                    {
                        if (frSerie.Contains(PreSeri.Trim()))
                        {
                            sPreSeri = PreSeri.Trim();
                            break;
                        }
                    }
                }
                long iFrSerie = 0;
                long iToSerie = 0;
                if (sPreSeri.Length == 0)
                {
                    iFrSerie = Convert.ToInt64(frSerie);
                    iToSerie = Convert.ToInt64(toSerie);
                }
                else
                {
                    sPreSeri = frSerie.Substring(0, sPreSeri.Length);
                    iFrSerie = Convert.ToInt64(frSerie.Substring(sPreSeri.Length, frSerie.Length - sPreSeri.Length));
                    iToSerie = Convert.ToInt64(toSerie.Substring(sPreSeri.Length, toSerie.Length - sPreSeri.Length));
                }
                if (iToSerie > iFrSerie)
                {
                    for (long i = iFrSerie; i <= iToSerie; i++)
                    {
                        var NewDetail = new DacExportDetail1();
                        NewDetail.ExportId = gridLookUpEditFactory.Properties.GetIndexByKeyValue(gridLookUpEditFactory.EditValue);
                        NewDetail.DacCode = String.Format("{0}{1:0000000000}", sPreSeri, i);
                        NewDetail.ProductCode = gridLookUpEditProductChoose.EditValue.ToString();
                        AddDistributDetails(NewDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void FrSeriTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string DacCode = FrSeriTextBox.Text.Trim();
                if (DacCode.Length >= 7)
                {
                    string serial = CommonCore.GetSerialFromScanner(DacCode);
                    FrSeriTextBox.Text = serial;
                    ToSeriTextBox.Focus();
                }
            }
        }

        private void ToSeriTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string DacCode = ToSeriTextBox.Text.Trim();
                if (DacCode.Length >= 7)
                {
                    string serial = CommonCore.GetSerialFromScanner(DacCode);
                    ToSeriTextBox.Text = serial;
                    //if (gridLookUpEditProductChoose.Properties.GetIndexByKeyValue(gridLookUpEditProductChoose.EditValue) >= 0)
                    //{
                        GetRangSerialNumber(FrSeriTextBox.Text, ToSeriTextBox.Text);
                        ToSeriTextBox.Text = string.Empty;
                        FrSeriTextBox.Text = string.Empty;
                        FrSeriTextBox.Focus();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Bạn chưa chọn sản phẩm nào, hãy chọn một sản phẩm để tiếp tục!", "Thông báo", MessageBoxButtons.OK);
                    //}
                }
            }
        }
        #endregion
        #region Events For Select All CheckBox
        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();

            HeaderCheckBox.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.dataGridViewDetails.Controls.Add(HeaderCheckBox);
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }
        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dataGridViewDetails.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["IsSelected"]).Value = HCheckBox.Checked;

            dataGridViewDetails.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }

        private void dataGridViewDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }

        private void dataGridViewDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewDetails.CurrentCell is DataGridViewCheckBoxCell)
                dataGridViewDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridViewDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsHeaderCheckBoxClicked)
                RowCheckBoxClick((DataGridViewCheckBoxCell)dataGridViewDetails[e.ColumnIndex, e.RowIndex]);
        }

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            //Get the column header cell bounds
            Rectangle oRectangle = this.dataGridViewDetails.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox.Location = oPoint;
        }

        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modify Counter;
                if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
                    TotalCheckedCheckBoxes++;
                else if (TotalCheckedCheckBoxes > 0)
                    TotalCheckedCheckBoxes--;

                //Change state of the header CheckBox;
                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    HeaderCheckBox.Checked = false;
                else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
                    HeaderCheckBox.Checked = true;
            }
        }

        #endregion

    }
}
