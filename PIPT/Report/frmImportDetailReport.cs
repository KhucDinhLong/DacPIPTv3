using DAC.Core.Services.Interfaces;
using DAC.DAL.ViewModels;
using System.Windows.Forms;

namespace PIPT.Report
{
    public partial class frmImportDetailReport : Form
    {
        public DacInsertToWarehouseVM importInfo;
        IDacInsertToWarehouseService _importService;
        public frmImportDetailReport(IDacInsertToWarehouseService importService)
        {
            InitializeComponent();
            _importService = importService;
        }

        private void ImportDetailReport_Load(object sender, System.EventArgs e)
        {
            if (importInfo != null)
            {
                lblInsertNumber.Text = importInfo.InsertNumber;
                lblCreatedDate.Text = importInfo.CreatedDate.HasValue ? importInfo.CreatedDate.Value.ToString("dd-MM-yyyy") : string.Empty;
                lblProductName.Text = importInfo.ProductName;
                lblStockCode.Text = importInfo.StockCode;
                lblStockName.Text = importInfo.StockName;
                importInfo = _importService.GetDetail(importInfo.Id)?.ResponseData;
                if (importInfo != null)
                {
                    gcDacCode.DataSource = importInfo.LstDetails;
                    lblQuantity.Text = importInfo.RealityQuantity.HasValue ? importInfo.RealityQuantity.Value.ToString() : "";
                }
            }
        }
    }
}
