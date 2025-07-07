using DAC.Core;
using DAC.Core.Security;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacGetData : Form
    {
        DataTable dataTableDacQueryRec;
        public frmDacGetData()
        {
            InitializeComponent();
        }

        private void buttonQueryData_Click(object sender, EventArgs e)
        {
            // Cung co o su kien buttonGetSerial_Click
            // va mot loi goi o btnGetSerial_Click (Project PIPT.Track)
            PIPT.Track.dacws.DacResultInfo dacResultInfo = new PIPT.Track.dacws.DacResultInfo();
            PIPT.Track.dacws.WSACShowResult acResult = new PIPT.Track.dacws.WSACShowResult();
            acResult.AuthHeaderValue = new PIPT.Track.dacws.AuthHeader();
            acResult.AuthHeaderValue.UserName = ConfigurationManager.AppSettings["Username"].ToString();
            acResult.AuthHeaderValue.Password = ConfigurationManager.AppSettings["Password"].ToString();

            // Nhan QueryRecID moi nhat
            int QueryRecID = DAC.Core.CommonCore.GetMaxQueryRecID();

            string FrDate = dtpFrDate.Value.ToString("yyyy-MM-dd");
            string ToDate = dtpToDate.Value.ToString("yyyy-MM-dd");
            string UnitCode = txtUnitCode.Text;

            dataTableDacQueryRec = new DataTable();
            dataTableDacQueryRec = acResult.GetDataQueryRec(FrDate, ToDate, UnitCode, QueryRecID);
            dataTableDacQueryRec.TableName = "DacProductQuery";
            if(dataTableDacQueryRec.Rows.Count > 0)
            {
                btnSave.Enabled = true;
                btnSave.Focus();
            }
            else
            {
                btnSave.Enabled = false;
            }
            dataGridViewLoadDacQueryCode.DataSource = dataTableDacQueryRec;
            labelAmount.Text = "SL: " + dataTableDacQueryRec.Rows.Count; 
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dataTableDacQueryRec.Rows.Count > 0)
            {
                string[] arrColumn = { "QueryRecID", "PhoneNumber", "UnitCode", "DacCode", "QueryStatus", "QueryDate" };
                DAC.DAL.DacDbAccess dacDbAccess = new DAC.DAL.DacDbAccess();
                try
                {
                    dacDbAccess.PerformBulkCopy(dataTableDacQueryRec, arrColumn);
                    MessageBox.Show(String.Format("Đã lưu {0:0,0} bản ghi thành công!", dataTableDacQueryRec.Rows.Count), "Thông báo");

                    // Tai lai du lieu xuong luoi ben duoi
                    GetDataCorrectDacCode(dtpFrDate.Value.ToString("yyyy-MM-dd"), dtpToDate.Value.ToString("yyyy-MM-dd"), string.Empty, string.Empty);
                }
                catch
                {
                    MessageBox.Show("Lưu bản ghi thất bại!", "Thông báo");
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            GetDataCorrectDacCode(dtpFrDate.Value.ToString("yyyy-MM-dd"), dtpToDate.Value.ToString("yyyy-MM-dd"), txtSearchDacCode.Text.Trim(), txtSearchPhone.Text.Trim());
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            Common objCommon = new Common();
            objCommon.CurrentForm = this;
            objCommon.CurrentFormMethodInvoker = this.ExportToExcel;
            objCommon.App_ShowWaitForm(DataState.Load);
        }

        private void ExportToExcel()
        {
            string workBookPath = Application.StartupPath + @"\Export.xlsx";
            string formatText = "PhoneNumber DacCode";
            CommonCore.ExportToExcel(dataTableDacQueryRec, workBookPath, formatText);
        }

        private void GetDataCorrectDacCode(string FrDate, string ToDate, string DacCode, string PhoneNumber)
        {
            dataTableDacQueryRec = new DataTable();
            dataTableDacQueryRec = DAC.Core.CommonCore.DacProductQuery(FrDate, ToDate, DacCode, PhoneNumber);
            dataGridViewDacQueryCode.DataSource = dataTableDacQueryRec;
            labelAmount.Text = "SL: " + dataTableDacQueryRec.Rows.Count;
            if(dataTableDacQueryRec.Rows.Count > 0)
            {
                btnExcel.Visible = true;
            }
            else
            {
                btnExcel.Visible = false;
            }
        }
    }
}
