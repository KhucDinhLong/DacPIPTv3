using DAC.Core;
using DAC.Core.Models;
using DAC.Core.Security;
using DAC.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmReportActivateAddingPoint : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmReportActivateAddingPoint _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmReportActivateAddingPoint Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmReportActivateAddingPoint();
            }
            return _instance;
        }

        public static frmReportActivateAddingPoint Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmReportActivateAddingPoint Instance(Form parent, bool isActivate)
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
        DacDbAccess dacDb = new DacDbAccess();
        DAC.Core.CustomerProductSeriCS customerProductSeriCS = new DAC.Core.CustomerProductSeriCS();
        CustomerProductSeriModel customerProductSeriModel = new CustomerProductSeriModel();
        #endregion
        public frmReportActivateAddingPoint()
        {
            InitializeComponent();
        }

        private void simpleButtonGetData_Click(object sender, EventArgs e)
        {
            dacDb.CreateNewSqlCommand();
             DataTable dataTableProductSeri = new DataTable();
            if (checkEditFromImportStock.Checked)
            {
                dacDb.AddParameter("@FrDate", dateEditFrom.EditValue);
                dacDb.AddParameter("@ToDate", dateEditTo.EditValue);
                dacDb.AddParameter("@ProductCode", textEdiProductCode.Text);
                dacDb.AddParameter("@InsertNumber", textEditOrderNumber.Text);
                dacDb.AddParameter("@LoginID", CommonBS.CurrentUser.LoginID);
                 dataTableProductSeri = dacDb.ExecuteDataTable("dbo.spDacInsertToWarehouse_ActivateAddingPoint");
            }
            else
            {
                dacDb.AddParameter("@FrDate", dateEditFrom.EditValue);
                dacDb.AddParameter("@ToDate", dateEditTo.EditValue);
                dacDb.AddParameter("@AgencyCode", textEditCustomerCode.Text);
                dacDb.AddParameter("@ProductCode", textEdiProductCode.Text);
                dacDb.AddParameter("@OrderNumber", textEditOrderNumber.Text);
                dacDb.AddParameter("@LoginID", CommonBS.CurrentUser.LoginID);
                dataTableProductSeri = dacDb.ExecuteDataTable("dbo.spDacDistributeToAgency_ActivateAddingPoint");
            }
            gridControlReport.DataSource = dataTableProductSeri;
            customerProductSeriModel.ProductSeriCollection = customerProductSeriCS.GetProductSeriCollection(dataTableProductSeri);
            if (dataTableProductSeri.Rows.Count > 0)
            {
                simpleButtonUpData.Enabled = true;
                labelControlTotalRecord.Text = String.Format("Tổng: {0:N0}", dataTableProductSeri.Rows.Count);
            }
            else
            {
                simpleButtonUpData.Enabled = false;
                labelControlTotalRecord.Text = String.Format("Tổng: {0:N0}", 0);
            }
        }

        private void simpleButtonExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Excel 2007-2016(*.xlsx)|*.xlsx";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //gridViewAgency.ExportToXlsx(@"\khachhang.xlsx");
                gridViewReport.ExportToXlsx(fileDialog.FileName);
            }
        }

        private void frmReportActivateAddingPoint_Load(object sender, EventArgs e)
        {
            dateEditFrom.EditValue = DateTime.Now;
            dateEditTo.EditValue = DateTime.Now;
        }

        private void simpleButtonUpData_Click(object sender, EventArgs e)
        {
            if(gridViewReport.RowCount > 0)
            {
                if(checkEditAgencyCode.Checked)
                {
                    AddAgencyProductSeriOnServer(customerProductSeriModel);
                }
                else
                {
                    this.AddCustomerProductSeriOnServer(customerProductSeriModel);
                }
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu!", "Thông báo");
            }
        }
        private async void AddCustomerProductSeriOnServer(CustomerProductSeriModel customerProductSeriModel)
        {
            if (InternetConnection.IsInternetConnected())
            {
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    bool IsSuccess = await apiHelper.AddCustomerProductSeriAsync(customerProductSeriModel);
                    if (!IsSuccess)
                    {
                        // Lưu thông tin xuất hàng chưa được upload
                        // để gửi lại sau.
                        //DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        //LogNotUploadCS.SaveLogNotUpload(customerProductSeriModel.DacDistributeToStore.ID, "DacDistributeToStore",
                        //    "Create", null, "Chưa tải dữ liệu lên được do không gọi được API");
                        MessageBox.Show("Chưa tải dữ liệu lên được do không gọi được API", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        simpleButtonUpData.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã được tải lên thành công! Tổng: " + customerProductSeriModel.ProductSeriCollection.Count + " Seri", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        simpleButtonUpData.Enabled = false;
                    }
                }
                catch (System.Net.Http.HttpRequestException rex)
                {
                    //DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                    //LogNotUploadCS.SaveLogNotUpload(customerProductSeriModel.DacDistributeToStore.ID, "DacDistributeToStore",
                    //    "Create", null, rex.Message);
                    MessageBox.Show("Lỗi:\n\r" + rex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    simpleButtonUpData.Enabled = true;
                }
            }
            else
            {
                //DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                //LogNotUploadCS.SaveLogNotUpload(customerProductSeriModel.DacDistributeToStore.ID, "DacDistributeToStore",
                //    "Create", null, "Chưa tải dữ liệu lên được do không có Internet");
                MessageBox.Show("Chưa tải dữ liệu lên được do không có Internet!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                simpleButtonUpData.Enabled = true;
            }
        }

        private async void AddAgencyProductSeriOnServer(CustomerProductSeriModel customerProductSeriModel)
        {
            if (InternetConnection.IsInternetConnected())
            {
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    bool IsSuccess = await apiHelper.AddAgencyProductSeriAsync(customerProductSeriModel);
                    if (!IsSuccess)
                    {
                        // Lưu thông tin xuất hàng chưa được upload
                        // để gửi lại sau.
                        //DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        //LogNotUploadCS.SaveLogNotUpload(customerProductSeriModel.DacDistributeToStore.ID, "DacDistributeToStore",
                        //    "Create", null, "Chưa tải dữ liệu lên được do không gọi được API");
                        MessageBox.Show("Chưa tải dữ liệu lên được do không gọi được API", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        simpleButtonUpData.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã được tải lên thành công! Tổng: " + customerProductSeriModel.ProductSeriCollection.Count + " Seri", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        simpleButtonUpData.Enabled = false;
                    }
                }
                catch (System.Net.Http.HttpRequestException rex)
                {
                    //DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                    //LogNotUploadCS.SaveLogNotUpload(customerProductSeriModel.DacDistributeToStore.ID, "DacDistributeToStore",
                    //    "Create", null, rex.Message);
                    MessageBox.Show("Lỗi:\n\r" + rex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    simpleButtonUpData.Enabled = true;
                }
            }
            else
            {
                //DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                //LogNotUploadCS.SaveLogNotUpload(customerProductSeriModel.DacDistributeToStore.ID, "DacDistributeToStore",
                //    "Create", null, "Chưa tải dữ liệu lên được do không có Internet");
                MessageBox.Show("Chưa tải dữ liệu lên được do không có Internet!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                simpleButtonUpData.Enabled = true;
            }
        }
    }
}
