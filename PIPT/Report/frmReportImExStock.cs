using DAC.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmReportImExStock : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmReportImExStock _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmReportImExStock Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmReportImExStock();
            }
            return _instance;
        }

        public static frmReportImExStock Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmReportImExStock Instance(Form parent, bool isActivate)
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
        public frmReportImExStock()
        {
            InitializeComponent();
        }

        private void simpleButtonGetData_Click(object sender, EventArgs e)
        {
            DataTable dataTableInventory = new DataTable();
            dataTableInventory = DAC.Core.Inventory.GetInventory(dateEditFrom.EditValue.ToString(), dateEditTo.EditValue.ToString(), textEdiProductCode.Text);
            gridControlReport.DataSource = dataTableInventory;
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

        private void frmReportImExStock_Load(object sender, EventArgs e)
        {
            dateEditFrom.EditValue = DateTime.Now;
            dateEditTo.EditValue = DateTime.Now.AddDays(1);
        }

        private void simpleButtonOpeningStock_Click(object sender, EventArgs e)
        {
            DateTime dateTimeFr = (DateTime)dateEditFrom.EditValue;
            DateTime dateTimeTo = (DateTime)dateEditTo.EditValue;
            string dateFr = dateTimeFr.Date.ToString("yyyy-MM-dd");
            string dateTo = dateTimeTo.Date.ToString("yyyy-MM-dd");
            dateFr = dateFr.Substring(5, 5);
            dateTo = dateTo.Substring(5, 5);
            if (dateFr == "01-01" && dateTo == "12-31")
            {
                // Năm tiếp theo
                int iYear = dateTimeTo.Year + 1;
                // Get all Products
                DataTable dataTableProduct = DAC.Core.Inventory.GetProduct();
                // Nhận hàng tồn kho từ đầu năm
                DataTable dataTableInventory = new DataTable();
                dataTableInventory = DAC.Core.Inventory.GetInventory(dateEditFrom.EditValue.ToString(), dateEditTo.EditValue.ToString(), textEdiProductCode.Text);
                // Gộp hai bảng lại
                DataTable dataTableOpeningStock = DAC.Core.DataTableHelper.JoinTwoDataTablesOnOneColumn(dataTableProduct, dataTableInventory, "ProductCode", DAC.Core.DataTableHelper.JoinType.Left);
                dataTableOpeningStock.Columns.Remove("Quantity");
                dataTableOpeningStock.Columns.Add(new DataColumn { ColumnName = "Year", DataType = typeof(int) });
                foreach (DataRow dr in dataTableOpeningStock.Rows)
                {
                    if (dr["TonCuoi"] == DBNull.Value)
                    {
                        dr["TonCuoi"] = 0;
                    }
                    dr["Year"] = iYear;
                }
                dataTableOpeningStock.Columns["TonCuoi"].ColumnName = "Quantity";
                dataTableOpeningStock.TableName = "DacInventory";
                // Lưu vào bảng tồn.
                try
                {
                    dacDb.PerformBulkCopy(dataTableOpeningStock, new string[] { "ProductCode", "Quantity", "Year" });
                    MessageBox.Show("Bạn đã chuyển tồn kho sang năm mới thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn ngày từ 01/01 - 31/12 mới chuyển tồn kho sang năm mới được", "Thông báo");
            }
        }
    }
}
