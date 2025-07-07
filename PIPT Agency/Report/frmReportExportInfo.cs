using DAC.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace PIPT.Agency
{
    public partial class frmReportExportInfo : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmReportExportInfo _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmReportExportInfo Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmReportExportInfo();
            }
            return _instance;
        }

        public static frmReportExportInfo Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmReportExportInfo Instance(Form parent, bool isActivate)
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
        public frmReportExportInfo()
        {
            InitializeComponent();
        }

        private void simpleButtonGetData_Click(object sender, EventArgs e)
{
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FrDate", dateEditFrom.EditValue);
            dacDb.AddParameter("@ToDate", dateEditTo.EditValue);
            dacDb.AddParameter("@StoreCode", textEditCustomerCode.Text);
            dacDb.AddParameter("@ProductCode", textEdiProductCode.Text);
            DataTable dataTableAgency = new DataTable();
            switch(comboBoxEditChooseType.SelectedIndex)
            {
                case 0: // Xuat ra the ma qrcodestring sProductCode = string.Empty;
                    dataTableAgency = dacDb.ExecuteDataTable("dbo.spDacDistributeToStore_SelectJoin");
                    break;
                case 1: // Xuat ra theo so luong
                    dataTableAgency = dacDb.ExecuteDataTable("dbo.spDacDistributeToStore_SelectQuantity");
                    break;
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

        private void frmReportExportInfo_Load(object sender, EventArgs e)
        {
            dateEditFrom.EditValue = DateTime.Now;
            dateEditTo.EditValue = DateTime.Now;
        }
    }
}
