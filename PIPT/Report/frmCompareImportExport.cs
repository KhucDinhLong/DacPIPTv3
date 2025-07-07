using DAC.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmCompareImportExport : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmCompareImportExport _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmCompareImportExport Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmCompareImportExport();
            }
            return _instance;
        }

        public static frmCompareImportExport Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmCompareImportExport Instance(Form parent, bool isActivate)
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
        #endregion
        public frmCompareImportExport()
        {
            InitializeComponent();
        }

        private void simpleButtonGetData_Click(object sender, EventArgs e)
        {
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FrDate", dateEditFrom.EditValue);
            dacDb.AddParameter("@ToDate", dateEditTo.EditValue);
            dacDb.AddParameter("@AgencyCode", textEditCustomerCode.Text);
            dacDb.AddParameter("@ProductCode", textEdiProductCode.Text);
            DataTable dataTableAgency = new DataTable();
            if (checkBoxByImport.Checked)
            {
                dataTableAgency = dacDb.ExecuteDataTable("spDacInsertToWarehouseDetails_LeftJoinAgency");
            }
            else
            {
                dataTableAgency = dacDb.ExecuteDataTable("spDacDistributeToAgencyDetails_LeftJoinStock");
            }
            gridControlReport.DataSource = dataTableAgency;
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

        private void frmCompareImportExport_Load(object sender, EventArgs e)
        {
            dateEditFrom.EditValue = DateTime.Now;
            dateEditTo.EditValue = DateTime.Now.AddDays(1);
        }
    }
}
