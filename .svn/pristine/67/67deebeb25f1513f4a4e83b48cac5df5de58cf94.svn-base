using DAC.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacLogBook : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacLogBook _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacLogBook Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacLogBook();
            }
            return _instance;
        }

        public static frmDacLogBook Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacLogBook Instance(Form parent, bool isActivate)
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
        public frmDacLogBook()
        {
            InitializeComponent();
        }

        private void frmDacLogBook_Load(object sender, EventArgs e)
        {
            dateEditFrom.EditValue = DateTime.Now;
            dateEditTo.EditValue = DateTime.Now;
        }

        private void simpleButtonGetData_Click(object sender, EventArgs e)
        {
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FrDate", dateEditFrom.EditValue);
            dacDb.AddParameter("@ToDate", dateEditTo.EditValue);
            DataTable dataTableReport = new DataTable();
            dataTableReport = dacDb.ExecuteDataTable("dbo.spDacLogBook_Select");
            gridControlReport.DataSource = dataTableReport;
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
    }
}
