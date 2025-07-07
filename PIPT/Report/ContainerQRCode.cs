using DAC.Core;
using DAC.DAL;

namespace PIPT.Report
{
    public partial class ContainerQRCode : DevExpress.XtraReports.UI.XtraReport
    {
        public ContainerQRCode()
        {
            InitializeComponent();
        }

        public void CreateQRCode(DacContainer Container)
        {
            // Nội dung QRCode
            xrBarCodeContainerCode.Text = Container.ContainerCode;

            // Gán các giá trị khác
            xrLabelValueCreatedDate.Text = Container.CreatedDate.HasValue ? Container.CreatedDate.Value.ToShortDateString() : "";
            xrLabelValueContainerCode.Text = Container.ContainerCode;
            xrLabelValueProductCode.Text = Container.ProductCode;
            xrLabelValueProductName.Text = Container.Description;
            xrLabelValueQuantity.Text = Container.Quantity.ToString();
        }
    }
}
