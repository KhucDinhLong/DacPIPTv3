using DAC.Core;
using DAC.DAL;
using System.Collections.Generic;

namespace PIPT.Package
{
    public partial class XtraReportPackage : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportPackage()
        {
            InitializeComponent();
        }

        public void GetDataToPrint(List<DacPackage> packageCollection)
        {
            objectDataSource1.DataSource = packageCollection;
        }
    }
}
