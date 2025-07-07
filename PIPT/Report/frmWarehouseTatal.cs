using System;
using System.Data;
using System.Windows.Forms;
using DAC.Core;
using DAC.Core.Security;

namespace PIPT
{
    public partial class frmWarehouseTatal : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmWarehouseTatal _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmWarehouseTatal Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmWarehouseTatal();
            }
            return _instance;
        }

        public static frmWarehouseTatal Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmWarehouseTatal Instance(Form parent, bool isActivate)
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
        DataTable dataTableDacWarehouseTotal;
        #endregion
        public frmWarehouseTatal()
        {
            InitializeComponent();
        }

        private void frmWarehouseTatal_Load(object sender, EventArgs e)
        {
            dateTimePickerFrDate.Value = DateTime.Parse(DateTime.Now.Year + "/01/01");
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = GetWarehouseTotal;
            objCommon.App_ShowWaitForm(DataState.Load);
        }

        private void buttonExportToExcel_Click(object sender, EventArgs e)
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = this.ExportToExcel;
            objCommon.App_ShowWaitForm(DataState.Load);
        }

        private void ExportToExcel()
        {
            string workBookPath = Application.StartupPath + @"\Export.xlsx";
            string formatText = "DacCode Series SoDT MaAnNinh";
            CommonCore.ExportToExcel(dataTableDacWarehouseTotal, workBookPath, formatText);
        }

        private void GetWarehouseTotal()
        {
            string DacCode = textBoxDacCode.Text.Trim();
            string QRCode = textBoxQRCode.Text.Trim();
            DateTime FrDate = DateTime.MinValue;
            DateTime ToDate = DateTime.MinValue;
            FrDate = dateTimePickerFrDate.Value;
            string sToDate = dateTimePickerToDate.Value.ToString("yyyy-MM-dd") + " 23:59:59.999";
            ToDate = DateTime.Parse(sToDate);
            string TenKH = textBoxTenKH.Text.Trim();
            string TenSP = textBoxTenSP.Text.Trim();
            string SoDT = textBoxSoDT.Text.Trim();
            if (checkBoxByDistributeToAgency.Checked)
            {
                DacDistributeToAgencyDetailsCS AgencyDetailsCS = new DacDistributeToAgencyDetailsCS();
                dataTableDacWarehouseTotal = AgencyDetailsCS.DacDistributeToAgencyTotal(DacCode, QRCode, FrDate, ToDate, TenKH, TenSP, SoDT, CommonBS.CurrentUser.LoginID);
            }
            else if (checkBoxCusSMS.Checked)
            {
                DacDistributeToAgencyDetailsCS AgencyDetailsCS = new DacDistributeToAgencyDetailsCS();
                dataTableDacWarehouseTotal = AgencyDetailsCS.DacDistributeToAgencyCusSMS(DacCode, QRCode, FrDate, ToDate, TenKH, TenSP, SoDT);
            }
            else
            {
                DacInsertToWarehouseDetailsCS WarehouseDetailsCS = new DacInsertToWarehouseDetailsCS();
                dataTableDacWarehouseTotal = WarehouseDetailsCS.DacWarehouseTotal(DacCode, QRCode, FrDate, ToDate, TenKH, TenSP, SoDT, CommonBS.CurrentUser.LoginID);
            }
            dataGridViewWarehouseTatal.DataSource = dataTableDacWarehouseTotal;
        }
        //a.DacCode, a.Series, c.CreatedDate as NgayNhap, ag.CreatedDate AS NgayXuat, kh.Code As MaKH,
        //kh.Name as TenKH, c.ProductCode as MaSP, d.Name as TenSP, p.Code as MaTinh, p.Name as Tinh,
        //pq.QueryDate as NgayKH, pq.PhoneNumber as SoDT, pq.DacCode as MaAnNinh, b.[Status] As TrangThai
    }
}
