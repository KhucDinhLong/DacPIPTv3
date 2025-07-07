using DAC.DAL;
using DAC.DAL.ViewModels;

namespace PIPT.Report
{
    public partial class PackageQRCode : DevExpress.XtraReports.UI.XtraReport
    {
        public PackageQRCode()
        {
            InitializeComponent();
        }

        public void CreateQRCode(DacPackageVM Package)
        {
            // Nội dung QRCode
            xrBarCodePackageCode.Text = Package.PackageCode;

            // Gán các giá trị khác
            xrLabelValuePackageCode.Text = Package.PackageCode;
            xrLabelValueProductCode.Text = Package.ProductCode;
            xrLabelValueProductName.Text = Package.Description;
            xrLabelValueQuantity.Text = Package.Quantity.ToString();
            xrLabelNgaySX.Text = Package.NgaySanXuat.HasValue ? Package.NgaySanXuat.Value.ToString("dd/MM/yyyy") : "";
        }
    }
}
