using DAC.Core.Security;
using DAC.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacLockPackage : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacLockPackage _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacLockPackage Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacLockPackage();
            }
            return _instance;
        }

        public static frmDacLockPackage Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacLockPackage Instance(Form parent, bool isActivate)
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
        DacDbAccess dacDb = new DacDbAccess();
        DataTable dtDacPackage;
        public frmDacLockPackage()
        {
            InitializeComponent();
            dtpToDate.Value = dtpToDate.Value.AddDays(1);
        }

        private void buttonQueryData_Click(object sender, EventArgs e)
        {
            DateTime FrDate = dtpFrDate.Value.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
            DateTime ToDate = dtpToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@From", FrDate);
            dacDb.AddParameter("@To", ToDate);
            dacDb.AddParameter("@PackageCode", txtPackageCode.Text);
            dacDb.AddParameter("@ProductName", txtProductName.Text);

            dtDacPackage = new DataTable();
            dtDacPackage = dacDb.ExecuteDataTable("dbo.spDacPackage_SelectByDateRange");
            dtDacPackage.TableName = "DacPackage";
            if (dtDacPackage.Rows.Count > 0)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
            dgvListPackage.DataSource = dtDacPackage;
            lblAmount.Text = "Số lượng thùng: " + dtDacPackage.Rows.Count;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dtDacPackage.Rows.Count > 0)
            {
                try
                {
                    int iUpdated = 0;
                    DAC.Core.DacPackageCS packageCS = new DAC.Core.DacPackageCS();
                    foreach (DataRow dr in dtDacPackage.Rows)
                    {
                        if (dr.RowState == DataRowState.Modified)
                        {
                            int iID = (int)dr["ID"];
                            bool bActive = (bool)dr["Active"];
                            packageCS.Update(iID, bActive);
                            iUpdated += 1;
                        }
                    }
                    MessageBox.Show("Bạn đã khóa các lệnh thành công!", "Thông báo");
                    lblAmount.Text = "Số lượng đơn hàng: " + dtDacPackage.Rows.Count + " (thay đổi " + iUpdated + "/" + dtDacPackage.Rows.Count + ")";
                }
                catch
                {
                    MessageBox.Show("Lưu bản ghi thất bại!", "Thông báo");
                }
            }
        }

        private void checkBoxCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dtDacPackage.Rows)
            {
                    dr["Active"] = chkAll.Checked;
            }
        }
    }
}
