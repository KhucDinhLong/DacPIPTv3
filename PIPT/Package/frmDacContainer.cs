using DAC.Core;
using DAC.Core.Security;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DAC.DAL;
using System.Collections.Generic;

namespace PIPT
{
    public partial class frmDacContainer : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacContainer _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacContainer Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacContainer();
            }
            return _instance;
        }

        public static frmDacContainer Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacContainer Instance(Form parent, bool isActivate)
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
        List<DacContainer> containerCollection = new List<DacContainer>();
        List<DacContainerDetails> containerDetailsCollection = new List<DacContainerDetails>();
        BindingList<DacContainer> bdlContainer;
        BindingList<DacContainerDetails> bdlContainerDetails;
        DacContainerCS containerCS = new DacContainerCS();
        DacContainerDetailsCS dacContainerDetailsCS = new DacContainerDetailsCS();
        SecConfig secConfig = CommonBO.GetSecConfig("AutoIncreaseContainer");
        // DataView for Product table
        DataView dvProduct;
        int iCurrentID = 0;
        public string ProductCode = string.Empty;
        public int iQuantity = 0;
        // Check Box Select All
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;
        string ContainerCode = string.Empty;
        // --------------------
        #endregion
        #region Form's Events
        public frmDacContainer()
        {
            InitializeComponent();
        }
        private void frmDacContainer_Load(object sender, EventArgs e)
        {
            InitData();
            InitLookUp();
            // Get Max order number

            ContainerCode = this.GetMaxContainer();
            // Get ContainerCollection from database
            // -----------------------------------------
            // Dinh lai thoi gia de load du lieu tai day
            // -----------------------------------------
            containerCollection = containerCS.GetListContainer(
                DateTime.Parse(CommonBO.GetSecConfig("DateStartGettingData").Value),
                DateTime.Now, string.Empty, string.Empty);
            AddObjectContainerIntoBindingList(containerCollection);
            // Get data from database
            AddObjectDetailsIntoBindingList(containerDetailsCollection);
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

        private void frmDacContainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ucDataButtonContainer.DataMode == DataState.Insert)
            {
                if (CommonCore.FormClosing("Bạn chưa lưu thùng này. Bạn có muốn lưu lại?"))
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
            dacDb.AddParameter("@FactoryCode", string.Empty);
            DataSet ds = new DataSet("Agency_Product");
            DataTable dataTable = dataTable = dacDb.ExecuteDataTable("spDacProduct_SelectAll");
            // Add table Product
            dataTable.TableName = "Products";
            ds.Tables.Add(dataTable);

            DataViewManager dvm = new DataViewManager(ds);
            dvProduct = dvm.CreateDataView(ds.Tables["Products"]);
        }
        private void InitLookUp()
        {
            // The data source for the dropdown rows
            gridLookUpEditProduct.Properties.DataSource = dvProduct;
        }
        private void AddObjectContainerIntoBindingList(List<DacContainer> ContainerCollection)
        {
            bdlContainer = new BindingList<DacContainer>();
            foreach (DacContainer Container in ContainerCollection)
            {
                bdlContainer.Add(Container);
            }
            SetDataSource();
        }
        private void SetDataSource()
        {
            CommonCore.ClearDataBinding(panelContainer);
            // Binding data to Controls
            textBoxQuantity.DataBindings.Add("Text", bdlContainer, "Quantity");
            textBoxContainerCode.DataBindings.Add("Text", bdlContainer, "ContainerCode");
            gridLookUpEditProduct.DataBindings.Clear();
            gridLookUpEditProduct.DataBindings.Add("EditValue", bdlContainer, "ProductCode");
            richTextBoxDescription.DataBindings.Add("Text", bdlContainer, "Description");
            dateTimePickerCreatedDate.DataBindings.Clear();
            dateTimePickerCreatedDate.DataBindings.Add("Value", bdlContainer, "CreatedDate");
            checkBoxActive.DataBindings.Clear();
            checkBoxActive.DataBindings.Add("Checked", bdlContainer, "Active");
            // Huy su kien SelectionChanged truoc khi gan DataSource
            this.gridViewContainer.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewContainer_FocusedRowChanged);
            gridControlContainer.DataSource = bdlContainer;
            this.gridViewContainer.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewContainer_FocusedRowChanged);
            if (bdlContainer.Count > 0)
            {
                this.GetDetailData();
            }
            EnableControls(false);
        }
        private void AddObjectDetailsIntoBindingList(List<DacContainerDetails> distributeDetailsCollection)
        {
            bdlContainerDetails = new BindingList<DacContainerDetails>();
            foreach (DacContainerDetails distributeDetail in distributeDetailsCollection)
            {
                bdlContainerDetails.Add(distributeDetail);
            }
            SetDistributeDetailsDataSource();
        }
        private void SetDistributeDetailsDataSource()
        {
            dataGridViewDetails.DataSource = bdlContainerDetails;

            TotalCheckBoxes = dataGridViewDetails.RowCount;
            TotalCheckedCheckBoxes = 0;
        }
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelContainer.Controls)
            {
                if (ctrl.Name != "checkEditKeepProduct" && ctrl.Name != "checkEditPreview")
                    ctrl.Enabled = bIsEnabled;
            }
        }
        private bool IsChangedData()
        {
            if (ucDataButtonContainer.DataMode == DataState.Insert)
            {
            }
            else if (ucDataButtonContainer.DataMode == DataState.Edit)
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
            if (gridLookUpEditProduct.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn mã thùng sản phẩm.", "Thông báo" + Common.formSoftName);
                gridLookUpEditProduct.Focus();
                return false;
            }
            if (dataGridViewDetails.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập bất kỳ mã qrcode nào.", "Thông báo" + Common.formSoftName);
                textBoxDacCode.Focus();
                return false;
            }
            return true;
        }
        private bool SaveData()
        {
            if (IsDataOK() == false) return false;

            bool bResult = true;
            if (ucDataButtonContainer.DataMode == DataState.Insert)
            {
                DacContainer container = new DacContainer();

                container.CreatedDate = dateTimePickerCreatedDate.Value;
                container.ContainerCode = textBoxContainerCode.Text;
                // Kiem tra lai ContainerCode
                if (secConfig.Value == "true")
                {
                    if (this.GetMaxContainer() != textBoxContainerCode.Text)
                    {
                        container.ContainerCode = this.GetMaxContainer();
                        textBoxContainerCode.Text = container.ContainerCode;
                    }
                }
                container.ProductCode = gridLookUpEditProduct.EditValue.ToString();
                container.Quantity = Convert.ToInt32(textBoxQuantity.Text);
                container.Description = richTextBoxDescription.Text;
                container.Active = checkBoxActive.Checked;

                bResult = containerCS.Insert(container, ref iCurrentID);
                if (bResult)
                {
                    gridViewContainer.SetFocusedRowCellValue(gridColumnID, iCurrentID);
                    // Doi lai ID da luu trong database
                    for (int i = 0; i < containerDetailsCollection.Count; i++)
                    {
                        containerDetailsCollection[i].ContainerId = iCurrentID;
                    }
                    // Convert list to datatable
                    DataTable dataTable = CommonCore.GetDataTable(containerDetailsCollection, typeof(DacContainerDetails));
                    dataTable.TableName = "DacContainerDetails"; // Ten bang trong CSDL
                    // Khai bao mang cac cot trong bang du lieu can mapping
                    string[] sColumnName = new string[] { "ContainerId", "PackageCode" };
                    CommonCore.PerformBulkCopy(dataTable, sColumnName);
                    bResult = true;
                }
            }
            else
            {
                // Update data in to DacContainer
                DacContainer container = new DacContainer();
                container = (DacContainer)gridViewContainer.GetRow(gridViewContainer.FocusedRowHandle);
                // Update to DataBase
                bResult = containerCS.Update(container);
            }
            // Kiem tra luu thanh cong khong de load lai du lieu
            if (bResult)
            {
                if (ucDataButtonContainer.DataMode == DataState.Insert)
                {
                    // Get ContainerCollection from database
                    // -----------------------------------------
                    // Dinh lai thoi gia de load du lieu tai day
                    // -----------------------------------------
                    containerCollection = containerCS.GetListContainer(
                        DateTime.Parse(CommonBO.GetSecConfig("DateStartGettingData").Value),
                        DateTime.Now, string.Empty, string.Empty);
                    AddObjectContainerIntoBindingList(containerCollection);
                    // Get data from database
                    AddObjectDetailsIntoBindingList(containerDetailsCollection);
                    // CommonBS.SaveSuccessfully();
                }
                ucDataButtonContainer.DataMode = DataState.View;
                ucDataButtonContainer.SetInsertFocus();
                EnableControls(false);
            }
            else CommonBS.SaveNotSuccessfully();

            return bResult;
        }
        private void SaveContainer()
        {
            SaveData();
        }
        private void AddContainerDetails(DacContainerDetails containerDetails)
        {
            // Kiem tra su ton tai cua ma QRCode
            foreach (DacContainerDetails detail in containerDetailsCollection)
            {
                // Neu co roi thi thoat luon khoi ham.
                if (detail.PackageCode == containerDetails.PackageCode)
                {
                    MessageBox.Show("Mã QRCode này đã tồn tại trong CSDL. \r\nBạn không thể thêm QRCode được nữa!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }
            // Kiem tra trong database
            List<DacContainerDetails> detailsCollection = dacContainerDetailsCS.GetContainerDetails(containerDetails.PackageCode);
            if (detailsCollection.Count > 0)
            {
                MessageBox.Show("Mã QRCode này đã tồn tại trong CSDL. \r\nBạn không thể thêm QRCode được nữa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            // Kiem tra neu khong phai dang Insert thi lay ID cua dong dang focus.
            if (ucDataButtonContainer.DataMode != DataState.Insert)
            {
                int iContainerId = (int)gridViewContainer.GetFocusedRowCellValue(gridColumnID);
                // Gan lai ID cho DistributeDetails
                containerDetails.ContainerId = iContainerId;
            }
            int iQuantity = Convert.ToInt32(textBoxQuantity.Text);
            int iCurrentQuantity = containerDetailsCollection.Count + 1;
            if (iCurrentQuantity <= iQuantity)
            {
                containerDetailsCollection.Add(containerDetails);
                labelProductCount.Text = String.Format("Số sản phẩm đã thêm: {0:0,0}", containerDetailsCollection.Count);
                //textBoxQuantity.Text = containerDetailsCollection.Count.ToString();
                AddObjectDetailsIntoBindingList(containerDetailsCollection);
                //Set focus on DataGridView
                if (dataGridViewDetails.Rows.Count > 0)
                {
                    dataGridViewDetails.CurrentCell = dataGridViewDetails.Rows[dataGridViewDetails.Rows.Count - 1].Cells[2];
                    dataGridViewDetails.Rows[dataGridViewDetails.Rows.Count - 1].Cells[2].Selected = true;
                }
            }
            else
            {
                MessageBox.Show("Số lượng sản phẩm vượt quá số lượng trong thùng. \r\nBạn không thể thêm QRCode được nữa!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void gridViewContainer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.GetDetailData();
        }
        private void GetDetailData()
        {
            if (gridViewContainer.RowCount == 0)
            { return; }
            try
            {
                DacContainerDetailsCS containerDetailsCS = new DacContainerDetailsCS();
                int iContainerId = (int)gridViewContainer.GetRowCellValue(gridViewContainer.FocusedRowHandle, "ID");
                containerDetailsCollection = containerDetailsCS.GetContainerDetails(iContainerId);
                AddObjectDetailsIntoBindingList(containerDetailsCollection);
                labelProductCount.Text = String.Format("Số sản phẩm đã thêm: {0:0,0}", containerDetailsCollection.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PIPT - Thông báo");
                return;
            }
        }
        // Get Max Container
        private string GetMaxContainer()
        {
            string MaxContainerCode = "CON"; // mã đầu ký hiệu cho kiện
            if (secConfig.Value == "true")
            {
                MaxContainerCode = DacContainerCS.GetMaxContainer();
            }
            else
            {
                MaxContainerCode = MaxContainerCode + String.Format("{0}{1:00}{2:00}{3:00}", DateTime.Now.Date.Year.ToString().Substring(2, 2), DateTime.Now.Date.Month, DateTime.Now.Date.Day, DateTime.Now.Date.Second);
            }
            return MaxContainerCode;
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
                        var NewDetail = new DacContainerDetails();
                        NewDetail.PackageCode = String.Format("{0}{1:" + CommonBO.GetSecConfig("SeriLength").Pattern + "}", sPreSeri, i);
                        AddContainerDetails(NewDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void CreateContainterFromPackage(List<DacContainerDetails> distributeDetailsCollection)
        {
            this.ucDataButtonProduct_InsertHandler();
            ucDataButtonContainer.DataMode = DataState.Insert;
            this.gridLookUpEditProduct.EditValue = ProductCode;
            this.textBoxQuantity.Text = iQuantity.ToString();
            foreach(DacContainerDetails containerDetail in distributeDetailsCollection)
            {
                this.AddContainerDetails(containerDetail);
            }
        }
        #endregion
        #region Buttons' Event
        private void ucDataButtonProduct_InsertHandler()
        {
            // Lay gia tri Product va So luong de giu lai
            string ProductCode = gridLookUpEditProduct.EditValue.ToString();
            string sSoLuong = textBoxQuantity.Text;
            //bdlContainer.AddNew();
            DevExpress.XtraGrid.Views.Grid.GridView view = gridControlContainer.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
            view.AddNewRow();
            gridControlContainer.RefreshDataSource();
            EnableControls(true);
            //Set focus for DataGridView
            gridViewContainer.FocusedRowHandle = gridViewContainer.GetVisibleRowHandle(gridViewContainer.RowCount - 1);
            // Kiem tra neu giu lai lenh thi khong tang lenh len nua
            if (checkEditKeepProduct.Checked)
            {
                textBoxContainerCode.Text = ContainerCode;
                gridLookUpEditProduct.EditValue = ProductCode;
                textBoxQuantity.Text = sSoLuong;
            }
            else
            {
                // Get Max order number
                textBoxQuantity.Text = sSoLuong;
                textBoxContainerCode.Text = this.GetMaxContainer();
            }
        }

        private void ucDataButtonProduct_SaveHandler()
        {
            // Lưu nhật ký
            CommonBO.Instance().TraceLogEvent("Save Container: " + textBoxContainerCode.Text + " - " + gridLookUpEditProduct.EditValue + " - "
                + textBoxQuantity.Text, CommonBS.CurrentUser.LoginID);
            ContainerCode = textBoxContainerCode.Text;
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = SaveContainer;
            objCommon.App_ShowWaitForm(DataState.Insert);
        }

        private void ucDataButtonProduct_EditHandler()
        {
            // Lưu nhật ký
            CommonBO.Instance().TraceLogEvent("Edit Container: " + textBoxContainerCode.Text + " - " + gridLookUpEditProduct.EditValue + " - "
                + textBoxQuantity.Text, CommonBS.CurrentUser.LoginID);
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
            int ID = (int)gridViewContainer.GetFocusedRowCellValue(gridColumnID);
            if (ID > -1)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa mục này?", "Thong bao", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    containerCS.Delete(ID);
                    // Lưu nhật ký
                    CommonBO.Instance().TraceLogEvent("Delete Container: ID = " + ID + " - " + textBoxContainerCode.Text + " - " + gridLookUpEditProduct.EditValue + " - "
                + textBoxQuantity.Text, CommonBS.CurrentUser.LoginID);
                    try
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView view = gridControlContainer.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
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
            if (ucDataButtonContainer.DataMode == DataState.Insert)
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = gridControlContainer.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                view.DeleteRow(view.FocusedRowHandle);
            }
            // Gan lai trang thai view
            ucDataButtonContainer.DataMode = DataState.View;
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
            var NewDetail = new DacContainerDetails();
            NewDetail.PackageCode = CommonCore.GetSerialFromScanner(textBoxDacCode.Text.Trim());
            AddContainerDetails(NewDetail);
            textBoxDacCode.Text = string.Empty;
        }

        private void buttonUpdateDetail_Click(object sender, EventArgs e)
        {
            try
            {
                string sContent = string.Empty;
                foreach (DacContainerDetails details in containerDetailsCollection)
                {
                    if (details.ID == 0)
                    {
                        dacContainerDetailsCS.Insert(details);
                        sContent += details.PackageCode + ", ";
                    }
                }
                // Lưu nhật ký
                CommonBO.Instance().TraceLogEvent(sContent, CommonBS.CurrentUser.LoginID);
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
                List<DacContainerDetails> detailsCollection = new List<DacContainerDetails>();
                foreach (DataGridViewRow Row in dataGridViewDetails.Rows)
                    if (((DataGridViewCheckBoxCell)Row.Cells["IsSelected"]).Value != null)
                    {
                        if ((bool)((DataGridViewCheckBoxCell)Row.Cells["IsSelected"]).Value)
                        {
                            DacContainerDetails containerDetails = (DacContainerDetails)Row.DataBoundItem;
                            detailsCollection.Add(containerDetails);
                            if (containerDetails.ID > 0)
                            {
                                // Xoa tren Database
                                dacContainerDetailsCS.Delete(containerDetails.ID);
                                sContent += containerDetails.PackageCode + ", ";
                            }
                        }
                    }
                // Lưu nhật ký
                CommonBO.Instance().TraceLogEvent("Xóa các mã: " + sContent, CommonBS.CurrentUser.LoginID);
                foreach (DacContainerDetails containerDetails in detailsCollection)
                {
                    bdlContainerDetails.Remove(containerDetails);
                    containerDetailsCollection.Remove(containerDetails);
                }
                bdlContainerDetails.ResetBindings();
            }
        }

        private void textBoxDacCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string DacCode = textBoxDacCode.Text.Trim();
                if (DacCode.Length >= 8)
                {
                    string serial = CommonCore.GetSerialFromScanner(DacCode);
                    var NewDetail = new DacContainerDetails();
                    NewDetail.PackageCode = serial;
                    AddContainerDetails(NewDetail);
                    textBoxDacCode.Text = string.Empty;
                }
            }
        }

        private void ucDataButtonContainer_PrintHandler()
        {
            PIPT.Report.ContainerQRCode rpt = new PIPT.Report.ContainerQRCode();
            DacContainer Container = (DacContainer)gridViewContainer.GetRow(gridViewContainer.FocusedRowHandle);
            Container.Description = gridLookUpEditProduct.Text;
            rpt.CreateQRCode(Container);

            if (checkEditPreview.Checked)
            {
                rpt.ShowPreview();
            }
            else
            {
                rpt.CreateDocument();
                rpt.Print();
            }
        }

        private void addSerialCodeButton_Click(object sender, EventArgs e)
        {
            string DacCode = ToSeriTextBox.Text.Trim();
            if (DacCode.Length >= 8)
            {
                string serial = CommonCore.GetSerialFromScanner(DacCode);
                ToSeriTextBox.Text = serial;
                GetRangSerialNumber(FrSeriTextBox.Text, ToSeriTextBox.Text);
                ToSeriTextBox.Text = string.Empty;
                FrSeriTextBox.Text = string.Empty;
                FrSeriTextBox.Focus();
            }
        }

        private void FrSeriTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string DacCode = FrSeriTextBox.Text.Trim();
                if (DacCode.Length >= 8)
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
                if (DacCode.Length >= 8)
                {
                    string serial = CommonCore.GetSerialFromScanner(DacCode);
                    ToSeriTextBox.Text = serial;
                    GetRangSerialNumber(FrSeriTextBox.Text, ToSeriTextBox.Text);
                    ToSeriTextBox.Text = string.Empty;
                    FrSeriTextBox.Text = string.Empty;
                    FrSeriTextBox.Focus();
                }
            }
        }

        private void textBoxContainerCode_Click(object sender, EventArgs e)
        {
            if (textBoxContainerCode.Text.Length > 3)
            {
                textBoxContainerCode.SelectionStart = 3;
                textBoxContainerCode.SelectionLength = textBoxContainerCode.Text.Length;
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
