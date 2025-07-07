using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using DAC.DAL;
using DAC.Core;

namespace PIPT.Package
{
    public partial class XtraReportPackageQR : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportPackageQR()
        {
            InitializeComponent();
        }
        public void GetDataToPrint(List<DacPackage> packageCollection)
        {
            objectDataSource1.DataSource = packageCollection;
        }
    }
}
