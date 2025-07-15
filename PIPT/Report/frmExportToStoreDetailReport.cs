using DAC.DAL.ViewModels;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PIPT.Report
{
    public partial class frmExportToStoreDetailReport : Form
    {
        public DacExport2VM exportInfo;
        public frmExportToStoreDetailReport()
        {
            InitializeComponent();
        }

        private void frmExportToStoreDetailReport_Load(object sender, EventArgs e)
        {
            if (exportInfo != null)
            {
                lblOrderNumber.Text = exportInfo.OrderNumber;
                lblCustomer.Text = exportInfo.StoreName;
                lblProduct.Text = string.Join(",", exportInfo.LstDetails?.Select(x => x.ProductName)?.Distinct());
                lblQuantity.Text = exportInfo.Quantity.HasValue ? exportInfo.Quantity.Value.ToString() : string.Empty;
                lblStock.Text = exportInfo.StockName;
                gcDacCode.DataSource = exportInfo.LstDetails;
            }
        }
    }
}
