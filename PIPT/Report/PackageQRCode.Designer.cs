namespace PIPT.Report
{
    partial class PackageQRCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabelValuePackageCode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelValueProductCode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelValueQuantity = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelValueProductName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelQuantity = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelProductCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPackageCode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCodePackageCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelNgaySX = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabelNgaySX,
            this.xrLabelValuePackageCode,
            this.xrLabelValueProductCode,
            this.xrLabelValueQuantity,
            this.xrLabelValueProductName,
            this.xrLabelQuantity,
            this.xrLabelProductCode,
            this.lblPackageCode,
            this.xrBarCodePackageCode});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 226.7125F;
            this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabelValuePackageCode
            // 
            this.xrLabelValuePackageCode.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelValuePackageCode.Dpi = 254F;
            this.xrLabelValuePackageCode.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelValuePackageCode.LocationFloat = new DevExpress.Utils.PointFloat(312.6462F, 53.56428F);
            this.xrLabelValuePackageCode.Name = "xrLabelValuePackageCode";
            this.xrLabelValuePackageCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelValuePackageCode.SizeF = new System.Drawing.SizeF(147.3537F, 22.51228F);
            this.xrLabelValuePackageCode.StylePriority.UseBorders = false;
            this.xrLabelValuePackageCode.StylePriority.UseFont = false;
            this.xrLabelValuePackageCode.StylePriority.UseTextAlignment = false;
            this.xrLabelValuePackageCode.Text = "Mã thùng";
            this.xrLabelValuePackageCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabelValueProductCode
            // 
            this.xrLabelValueProductCode.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelValueProductCode.Dpi = 254F;
            this.xrLabelValueProductCode.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelValueProductCode.LocationFloat = new DevExpress.Utils.PointFloat(312.6462F, 90.51398F);
            this.xrLabelValueProductCode.Name = "xrLabelValueProductCode";
            this.xrLabelValueProductCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelValueProductCode.SizeF = new System.Drawing.SizeF(147.3536F, 22.51228F);
            this.xrLabelValueProductCode.StylePriority.UseBorders = false;
            this.xrLabelValueProductCode.StylePriority.UseFont = false;
            this.xrLabelValueProductCode.StylePriority.UseTextAlignment = false;
            this.xrLabelValueProductCode.Text = "Mã sản phẩm";
            this.xrLabelValueProductCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabelValueQuantity
            // 
            this.xrLabelValueQuantity.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelValueQuantity.Dpi = 254F;
            this.xrLabelValueQuantity.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelValueQuantity.LocationFloat = new DevExpress.Utils.PointFloat(312.6462F, 127.4637F);
            this.xrLabelValueQuantity.Name = "xrLabelValueQuantity";
            this.xrLabelValueQuantity.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelValueQuantity.SizeF = new System.Drawing.SizeF(147.3537F, 22.51228F);
            this.xrLabelValueQuantity.StylePriority.UseBorders = false;
            this.xrLabelValueQuantity.StylePriority.UseFont = false;
            this.xrLabelValueQuantity.StylePriority.UseTextAlignment = false;
            this.xrLabelValueQuantity.Text = "Số lượng";
            this.xrLabelValueQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabelValueProductName
            // 
            this.xrLabelValueProductName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelValueProductName.Dpi = 254F;
            this.xrLabelValueProductName.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelValueProductName.LocationFloat = new DevExpress.Utils.PointFloat(25F, 164.2711F);
            this.xrLabelValueProductName.Name = "xrLabelValueProductName";
            this.xrLabelValueProductName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelValueProductName.SizeF = new System.Drawing.SizeF(435F, 37.44142F);
            this.xrLabelValueProductName.StylePriority.UseBorders = false;
            this.xrLabelValueProductName.StylePriority.UseFont = false;
            this.xrLabelValueProductName.StylePriority.UseTextAlignment = false;
            this.xrLabelValueProductName.Text = "Tên sản phẩm";
            this.xrLabelValueProductName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabelQuantity
            // 
            this.xrLabelQuantity.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelQuantity.Dpi = 254F;
            this.xrLabelQuantity.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelQuantity.LocationFloat = new DevExpress.Utils.PointFloat(182.7264F, 127.4637F);
            this.xrLabelQuantity.Name = "xrLabelQuantity";
            this.xrLabelQuantity.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelQuantity.SizeF = new System.Drawing.SizeF(124.9588F, 22.51228F);
            this.xrLabelQuantity.StylePriority.UseBorders = false;
            this.xrLabelQuantity.StylePriority.UseFont = false;
            this.xrLabelQuantity.StylePriority.UseTextAlignment = false;
            this.xrLabelQuantity.Text = "Số lượng:";
            this.xrLabelQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabelProductCode
            // 
            this.xrLabelProductCode.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelProductCode.Dpi = 254F;
            this.xrLabelProductCode.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelProductCode.LocationFloat = new DevExpress.Utils.PointFloat(182.7264F, 90.51398F);
            this.xrLabelProductCode.Name = "xrLabelProductCode";
            this.xrLabelProductCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelProductCode.SizeF = new System.Drawing.SizeF(124.9588F, 22.51228F);
            this.xrLabelProductCode.StylePriority.UseBorders = false;
            this.xrLabelProductCode.StylePriority.UseFont = false;
            this.xrLabelProductCode.StylePriority.UseTextAlignment = false;
            this.xrLabelProductCode.Text = "Mã sản phẩm:";
            this.xrLabelProductCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblPackageCode
            // 
            this.lblPackageCode.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblPackageCode.Dpi = 254F;
            this.lblPackageCode.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageCode.LocationFloat = new DevExpress.Utils.PointFloat(182.7264F, 53.5643F);
            this.lblPackageCode.Name = "lblPackageCode";
            this.lblPackageCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblPackageCode.SizeF = new System.Drawing.SizeF(124.9588F, 22.51228F);
            this.lblPackageCode.StylePriority.UseBorders = false;
            this.lblPackageCode.StylePriority.UseFont = false;
            this.lblPackageCode.StylePriority.UseTextAlignment = false;
            this.lblPackageCode.Text = "Mã thùng:";
            this.lblPackageCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrBarCodePackageCode
            // 
            this.xrBarCodePackageCode.AutoModule = true;
            this.xrBarCodePackageCode.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrBarCodePackageCode.Dpi = 254F;
            this.xrBarCodePackageCode.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrBarCodePackageCode.LocationFloat = new DevExpress.Utils.PointFloat(20F, 10F);
            this.xrBarCodePackageCode.Module = 5.08F;
            this.xrBarCodePackageCode.Name = "xrBarCodePackageCode";
            this.xrBarCodePackageCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrBarCodePackageCode.ShowText = false;
            this.xrBarCodePackageCode.SizeF = new System.Drawing.SizeF(146F, 146F);
            this.xrBarCodePackageCode.StylePriority.UseBorders = false;
            this.xrBarCodePackageCode.StylePriority.UseFont = false;
            this.xrBarCodePackageCode.StylePriority.UsePadding = false;
            this.xrBarCodePackageCode.StylePriority.UseTextAlignment = false;
            qrCodeGenerator1.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
            this.xrBarCodePackageCode.Symbology = qrCodeGenerator1;
            this.xrBarCodePackageCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 23F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 23F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(182.7264F, 16.61458F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(124.9588F, 22.51228F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Ngày sản xuất:";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabelNgaySX
            // 
            this.xrLabelNgaySX.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabelNgaySX.Dpi = 254F;
            this.xrLabelNgaySX.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelNgaySX.LocationFloat = new DevExpress.Utils.PointFloat(312.6462F, 16.61458F);
            this.xrLabelNgaySX.Name = "xrLabelNgaySX";
            this.xrLabelNgaySX.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelNgaySX.SizeF = new System.Drawing.SizeF(147.3537F, 22.51228F);
            this.xrLabelNgaySX.StylePriority.UseBorders = false;
            this.xrLabelNgaySX.StylePriority.UseFont = false;
            this.xrLabelNgaySX.StylePriority.UseTextAlignment = false;
            this.xrLabelNgaySX.Text = "Ngày sản xuất";
            this.xrLabelNgaySX.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PackageQRCode
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(15, 15, 23, 23);
            this.PageHeight = 290;
            this.PageWidth = 490;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCodePackageCode;
        private DevExpress.XtraReports.UI.XRLabel lblPackageCode;
        private DevExpress.XtraReports.UI.XRLabel xrLabelProductCode;
        private DevExpress.XtraReports.UI.XRLabel xrLabelValuePackageCode;
        private DevExpress.XtraReports.UI.XRLabel xrLabelValueProductCode;
        private DevExpress.XtraReports.UI.XRLabel xrLabelValueQuantity;
        private DevExpress.XtraReports.UI.XRLabel xrLabelValueProductName;
        private DevExpress.XtraReports.UI.XRLabel xrLabelQuantity;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabelNgaySX;
    }
}
