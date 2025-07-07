using DAC.Core.Services.Interfaces;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIPT.Report
{
    public partial class frmPackageDetailReport : Form
    {
        public DacPackageVM packageInfo;
        IDacPackageService _packageService;
        public frmPackageDetailReport(IDacPackageService packageService)
        {
            InitializeComponent();
            _packageService = packageService;
        }

        private void frmPackageDetailReport_Load(object sender, EventArgs e)
        {
            if (packageInfo != null)
            {
                lblPackageCode.Text = packageInfo.PackageCode;
                lblCreatedDate.Text = packageInfo.CreatedDate.HasValue ? packageInfo.CreatedDate.Value.ToString("dd-MM-yyyy") : string.Empty;
                lblProductName.Text = packageInfo.ProductName;
                lblBatch.Text = packageInfo.Batch;
                packageInfo = _packageService.GetDetail(packageInfo.Id)?.ResponseData;
                if (packageInfo != null)
                {
                    gcDacCode.DataSource = packageInfo.LstDetails;
                    lblQuantity.Text = packageInfo.RealityQuantity.ToString();
                }
            }
        }
    }
}
