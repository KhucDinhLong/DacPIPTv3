using DAC.Core;
using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmReportImExStockInThisYear : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmReportImExStockInThisYear _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmReportImExStockInThisYear Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmReportImExStockInThisYear();
            }
            return _instance;
        }

        public static frmReportImExStockInThisYear Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmReportImExStockInThisYear Instance(Form parent, bool isActivate)
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
        public frmReportImExStockInThisYear()
        {
            InitializeComponent();
        }

        private void simpleButtonGetData_Click(object sender, EventArgs e)
        {
            DataTable dataTableInventory = new DataTable();
            if (cbbStock.SelectedIndex != 0)
                dataTableInventory = Inventory.GetInventoryInThisYear(dateEditFrom.EditValue.ToString(), cbbStock.SelectedValue.ToString());
            else
                dataTableInventory = Inventory.GetInventoryInThisYear(dateEditFrom.EditValue.ToString(), "");
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

        private void frmReportImExStockInThisYear_Load(object sender, EventArgs e)
        {
            dateEditFrom.EditValue = DateTime.Now;
            DacStockCS dacStockCS = new DacStockCS();
            List<DacStock> LstStock = dacStockCS.GetAllActiveStock();
            DacStock firstItem = new DacStock();
            firstItem.Name = "Tất cả";
            LstStock.Insert(0, firstItem);
            cbbStock.DataSource = LstStock;
            cbbStock.DisplayMember = "Name";
            cbbStock.ValueMember = "Code";
        }
    }
}
