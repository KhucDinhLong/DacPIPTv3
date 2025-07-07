using DAC.DAL.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PIPT.Report
{
    public partial class frmExportToAgencyDetailReport : Form
    {
        public DacDistributeToAgencyVM exportInfo;
        public frmExportToAgencyDetailReport()
        {
            InitializeComponent();
        }

        private void frmExportToAgencyDetailReport_Load(object sender, EventArgs e)
        {
            if (exportInfo != null)
            {
                lblOrderNumber.Text = exportInfo.OrderNumber;
                lblAgencyName.Text = exportInfo.AgencyName;
                lblProductName.Text = string.Join(",", exportInfo.LstDetails?.Select(x => x.ProductName)?.Distinct());
                lblQuantity.Text = exportInfo.Quantity.HasValue ? exportInfo.Quantity.Value.ToString() : string.Empty;
                lblStockName.Text = exportInfo.StockName;
                gcDacCode.DataSource = exportInfo.LstDetails;
            }
        }
    }
}
