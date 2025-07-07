using DAC.Core.Security;
using DAC.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacLockDistributor : Form
    {
        DacDbAccess dacDb = new DacDbAccess();
        DataTable dataTableDacDistributeToAgency;
        DataTable dtInsertToWareHouse;
        public frmDacLockDistributor()
        {
            InitializeComponent();
            dtpToDate.Value = dtpToDate.Value.AddDays(1);
            tabCtr.SelectedTab = tabDistributeToAgency;
        }

        private void buttonQueryData_Click(object sender, EventArgs e)
        {
            string FrDate = dtpFrDate.Value.ToString("yyyy-MM-dd");
            string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");
            //Get list distribute
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FrDate", FrDate);
            dacDb.AddParameter("@ToDate", ToDate);
            dacDb.AddParameter("@AgencyCode", txtAgencyCode.Text);
            dacDb.AddParameter("@ProductCode", txtProductCode.Text);
            dacDb.AddParameter("@LoginID", CommonBS.CurrentUser.LoginID);

            dataTableDacDistributeToAgency = new DataTable();
            dataTableDacDistributeToAgency = dacDb.ExecuteDataTable("dbo.spDacDistributeToAgency_SelectQuantity");
            dataTableDacDistributeToAgency.TableName = "DacDistributeToAgency";
            dataTableDacDistributeToAgency.Columns.Remove("ProvinceCode");
            dataTableDacDistributeToAgency.Columns.Remove("DacCode");
            dataTableDacDistributeToAgency.Columns.Remove("DetailID");

            //Get list inserttowarehouse
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FrDate", FrDate);
            dacDb.AddParameter("@ToDate", ToDate);
            dacDb.AddParameter("@ProductCode", txtProductCode.Text);
            dacDb.AddParameter("@LoginID", CommonBS.CurrentUser.LoginID);

            dtInsertToWareHouse = new DataTable();
            dtInsertToWareHouse = dacDb.ExecuteDataTable("spDacInsertToWarehouse_SelectQuantity");
            dtInsertToWareHouse.TableName = "DacInsertToWareHouse";
            dataGridViewDistributeToAgency.DataSource = dataTableDacDistributeToAgency;
            dtInsertToWareHouse.Columns.Remove("DacCode");
            dtInsertToWareHouse.Columns.Remove("DetailID");
            dtInsertToWareHouse.Columns.Remove("Description");
            dgvInsertToWarehouse.DataSource = dtInsertToWareHouse;
            if (tabCtr.SelectedTab == tabDistributeToAgency)
            {
                if (dataTableDacDistributeToAgency.Rows.Count > 0)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
                labelAmount.Text = "Số lượng đơn hàng: " + dataTableDacDistributeToAgency.Rows.Count;
            }
            else
            {
                if (dtInsertToWareHouse.Rows.Count > 0)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
                labelAmount.Text = "Số lượng đơn hàng: " + dtInsertToWareHouse.Rows.Count;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (tabCtr.SelectedTab == tabDistributeToAgency)
            {
                if (dataTableDacDistributeToAgency.Rows.Count > 0)
                {
                    try
                    {
                        int iUpdated = 0;
                        DAC.Core.DacDistributeToAgencyCS distributeToAgencyCS = new DAC.Core.DacDistributeToAgencyCS();
                        foreach (DataRow dr in dataTableDacDistributeToAgency.Rows)
                        {
                            if (dr.RowState == DataRowState.Modified)
                            {
                                int iID = (int)dr["ID"];
                                bool bActive = (bool)dr["Active"];
                                distributeToAgencyCS.Update(iID, bActive);
                                iUpdated += 1;
                            }
                        }
                        MessageBox.Show("Bạn đã khóa các lệnh thành công!", "Thông báo");
                        labelAmount.Text = "Số lượng đơn hàng: " + dataTableDacDistributeToAgency.Rows.Count + " (thay đổi " + iUpdated + "/" + dataTableDacDistributeToAgency.Rows.Count + ")";
                    }
                    catch
                    {
                        MessageBox.Show("Lưu bản ghi thất bại!", "Thông báo");
                    }
                }
            }
            else
            {
                if (dtInsertToWareHouse.Rows.Count > 0)
                {
                    try
                    {
                        int iUpdated = 0;
                        DAC.Core.DacInsertToWarehouseCS insertToWarehouseCS = new DAC.Core.DacInsertToWarehouseCS();
                        foreach (DataRow dr in dtInsertToWareHouse.Rows)
                        {
                            if (dr.RowState == DataRowState.Modified)
                            {
                                int iID = (int)dr["ID"];
                                bool bActive = (bool)dr["Active"];
                                insertToWarehouseCS.Update(iID, bActive);
                                iUpdated += 1;
                            }
                        }
                        MessageBox.Show("Bạn đã khóa các lệnh thành công!", "Thông báo");
                        labelAmount.Text = "Số lượng đơn hàng: " + dataTableDacDistributeToAgency.Rows.Count + " (thay đổi " + iUpdated + "/" + dataTableDacDistributeToAgency.Rows.Count + ")";
                    }
                    catch
                    {
                        MessageBox.Show("Lưu bản ghi thất bại!", "Thông báo");
                    }
                }
            }
        }

        private void checkBoxCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dataTableDacDistributeToAgency.Rows)
            {
                    dr["Active"] = chkCheckAll.Checked;
            }
        }

        private void tabCtr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCtr.SelectedTab == tabDistributeToAgency)
            {
                if (dataGridViewDistributeToAgency != null && dataGridViewDistributeToAgency.Rows.Count > 0)
                {
                    labelAmount.Text = "Số lượng đơn hàng: " + dataTableDacDistributeToAgency.Rows.Count;
                    btnSave.Enabled = true;
                }
                else
                {
                    labelAmount.Text = "Số lượng đơn hàng: 00";
                    btnSave.Enabled = false;
                } 
            }
            else
            {
                if (dtInsertToWareHouse != null && dtInsertToWareHouse.Rows.Count > 0)
                {
                    labelAmount.Text = "Số lượng đơn hàng: " + dtInsertToWareHouse.Rows.Count;
                    btnSave.Enabled = true;
                }
                else
                {
                    labelAmount.Text = "Số lượng đơn hàng: 00";
                    btnSave.Enabled = false;
                }
            }
        }
    }
}
