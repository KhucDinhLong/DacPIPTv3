using DAC.Core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace PIPT.Agency
{
    public partial class frmDacDeleteCode : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacDeleteCode _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacDeleteCode Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacDeleteCode();
            }
            return _instance;
        }

        public static frmDacDeleteCode Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacDeleteCode Instance(Form parent, bool isActivate)
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
        BindingList<DacPackageDetails> bdlPackageDetails = new BindingList<DacPackageDetails>();
        DacPackageDetailsCollection packageDetailsCollection = new DacPackageDetailsCollection();
        DacContainerDetailsCS dacContainerDetailsCS = new DacContainerDetailsCS();
        DacPackageDetailsCS dacPackageDetailsCS = new DacPackageDetailsCS();
        DacDistributeToAgencyDetailsCS dacDistributeToAgencyDetailsCS = new DacDistributeToAgencyDetailsCS();
        DacDistributeToStoreDetailsCS dacDistributeToStoreDetailsCS = new DacDistributeToStoreDetailsCS();
        // Check Box Select All
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;
        // --------------------
        #endregion
        #region Form's Events
        public frmDacDeleteCode()
        {
            InitializeComponent();
        }

        private void frmDacDeleteCode_Load(object sender, EventArgs e)
        {
            // Init Events For Select All CheckBox
            AddHeaderCheckBox();

            HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            dataGridViewDetails.CellValueChanged += new DataGridViewCellEventHandler(dataGridViewDetails_CellValueChanged);
            dataGridViewDetails.CurrentCellDirtyStateChanged += new EventHandler(dataGridViewDetails_CurrentCellDirtyStateChanged);
            dataGridViewDetails.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridViewDetails_CellPainting);

            textBoxDacCode.Focus();
        }
        #endregion
        #region Function on form
        private void AddObjectDetailsIntoBindingList(DacPackageDetailsCollection distributeDetailsCollection)
        {
            bdlPackageDetails = new BindingList<DacPackageDetails>();
            foreach (DacPackageDetails distributeDetail in distributeDetailsCollection)
            {
                bdlPackageDetails.Add(distributeDetail);
            }
            SetDistributeDetailsDataSource();
        }
        private void SetDistributeDetailsDataSource()
        {
            dataGridViewDetails.DataSource = bdlPackageDetails;

            TotalCheckBoxes = dataGridViewDetails.RowCount;
            TotalCheckedCheckBoxes = 0;
        }
        private void AddPackageDetails(DacPackageDetails packageDetails)
        {
            // Kiem tra su ton tai cua ma QRCode
            foreach (DacPackageDetails detail in packageDetailsCollection)
            {
                // Neu co roi thi thoat luon khoi ham.
                if (detail.DacCode == packageDetails.DacCode)
                    return;
            }
            packageDetailsCollection.Add(packageDetails);
            labelProductCount.Text = String.Format("Số đối tượng đã thêm: {0:0,0}", packageDetailsCollection.Count);
            AddObjectDetailsIntoBindingList(packageDetailsCollection);
            //Set focus on DataGridView
            if (dataGridViewDetails.Rows.Count > 0)
            {
                dataGridViewDetails.CurrentCell = dataGridViewDetails.Rows[dataGridViewDetails.Rows.Count - 1].Cells["ColumnDacCode"];
                dataGridViewDetails.Rows[dataGridViewDetails.Rows.Count - 1].Cells["ColumnDacCode"].Selected = true;
            }
            // Select all checkboxs
            HeaderCheckBox.Checked = true;
            HeaderCheckBoxClick(HeaderCheckBox);
        }
        private async void DeleteDistributeToStoreDetailsOnServer(string DacCode)
        {
            if (InternetConnection.IsInternetConnected())
            {
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    bool IsSuccess = await apiHelper.DeleteDistributeToStoreDetailsAsync(DacCode);
                    if (!IsSuccess)
                    {
                        // Lưu thông tin xuất hàng chưa được upload
                        // để gửi lại sau.
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.SaveLogNotUpload("DistributeToStoreDetails.ID.ToString()", "DacDistributeToStoreDetails",
                            "Delete", DacCode, "Chưa xóa được dữ liệu do không gọi được API");
                    }
                }
                catch (HttpRequestException rex)
                {
                    DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                    LogNotUploadCS.SaveLogNotUpload("DistributeToStoreDetails.ID.ToString()", "DacDistributeToStoreDetails",
                        "Delete", DacCode, rex.Message);
                }
            }
            else
            {
                DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                LogNotUploadCS.SaveLogNotUpload("DistributeToStoreDetails.ID.ToString()", "DacDistributeToStoreDetails",
                    "Delete", DacCode, "Chưa xóa được dữ liệu do không có Internet");
            }
        }
        #endregion
        #region Buttons' Event
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            AddPackageDetails(new DacPackageDetails(-1, -1, CommonCore.GetSerialFromScanner(textBoxDacCode.Text.Trim()), string.Empty));
            textBoxDacCode.Text = string.Empty;
        }

        private void buttonDetailDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa mã QRCode?", "Thong bao - Xoa ma QRCode", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (DataGridViewRow Row in dataGridViewDetails.Rows)
                    if (((DataGridViewCheckBoxCell)Row.Cells["IsSelected"]).Value != null)
                    {
                        if ((bool)((DataGridViewCheckBoxCell)Row.Cells["IsSelected"]).Value)
                        {
                            DacPackageDetails packageDetails = (DacPackageDetails)Row.DataBoundItem;

                            if (packageDetails.DacCode.Length > 0)
                            {
                                // Xoa tren Database
                                //dacPackageDetailsCS.Delete(packageDetails.ID);
                                if(checkEditDeletePackageFromContainer.Checked)
                                {
                                    // delete Package from Container
                                    dacContainerDetailsCS.Delete(packageDetails.DacCode);
                                }
                                if(checkEditDeleteProductFromPackage.Checked)
                                {
                                    // delete DacCode from Package
                                    dacPackageDetailsCS.Delete(packageDetails.DacCode);
                                }
                                if (checkEditDeleteProductFromAgency.Checked)
                                {
                                    // delete DacCode from Agency
                                    dacDistributeToAgencyDetailsCS.Delete(packageDetails.DacCode);
                                }
                                if (checkEditDeleteProductFromStore.Checked)
                                {
                                    // delete DacCode from Store
                                    dacDistributeToStoreDetailsCS.Delete(packageDetails.DacCode);

                                    // delete DacCode from Store on Server
                                    this.DeleteDistributeToStoreDetailsOnServer(packageDetails.DacCode);
                                }
                            }
                        }
                    }
                //foreach (DacPackageDetails packageDetails in detailsCollection)
                //{
                //    bdlPackageDetails.Remove(packageDetails);
                //    packageDetailsCollection.Remove(packageDetails);
                //}
                //bdlPackageDetails.ResetBindings();
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
                    AddPackageDetails(new DacPackageDetails(-1, -1, serial, string.Empty));
                    textBoxDacCode.Text = string.Empty;
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
            if(e.KeyCode == Keys.Space)
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
            if(RCheckBox != null)
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
