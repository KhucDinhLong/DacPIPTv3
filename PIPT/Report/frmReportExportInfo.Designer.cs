namespace PIPT
{
    partial class frmReportExportInfo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportExportInfo));
            this.dtpFrom = new DevExpress.XtraEditors.DateEdit();
            this.dtpTo = new DevExpress.XtraEditors.DateEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlTo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControCustomerCode = new DevExpress.XtraEditors.LabelControl();
            this.labelControlFrom = new DevExpress.XtraEditors.LabelControl();
            this.txtProductCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerCode = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gcReport = new DevExpress.XtraGrid.GridControl();
            this.gvReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgencyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.EditValue = new System.DateTime(2017, 2, 28, 0, 0, 0, 0);
            this.dtpFrom.Location = new System.Drawing.Point(118, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrom.Size = new System.Drawing.Size(101, 20);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpTo.EditValue = new System.DateTime(2017, 2, 28, 0, 0, 0, 0);
            this.dtpTo.Location = new System.Drawing.Point(320, 12);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Size = new System.Drawing.Size(113, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExcel);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.labelControlTo);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControCustomerCode);
            this.panelControl1.Controls.Add(this.labelControlFrom);
            this.panelControl1.Controls.Add(this.txtProductCode);
            this.panelControl1.Controls.Add(this.txtCustomerCode);
            this.panelControl1.Controls.Add(this.dtpFrom);
            this.panelControl1.Controls.Add(this.dtpTo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1205, 43);
            this.panelControl1.TabIndex = 7;
            // 
            // btnExcel
            // 
            this.btnExcel.ImageOptions.Image = global::PIPT.Properties.Resources.Excel;
            this.btnExcel.Location = new System.Drawing.Point(1090, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(103, 27);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.simpleButtonExcel_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(997, 8);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(87, 27);
            this.btnGetData.TabIndex = 4;
            this.btnGetData.Text = "Nhận dữ liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // labelControlTo
            // 
            this.labelControlTo.Location = new System.Drawing.Point(267, 15);
            this.labelControlTo.Name = "labelControlTo";
            this.labelControlTo.Size = new System.Drawing.Size(47, 13);
            this.labelControlTo.TabIndex = 2;
            this.labelControlTo.Text = "Đến ngày";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(714, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Mã sản phẩm";
            // 
            // labelControCustomerCode
            // 
            this.labelControCustomerCode.Location = new System.Drawing.Point(473, 15);
            this.labelControCustomerCode.Name = "labelControCustomerCode";
            this.labelControCustomerCode.Size = new System.Drawing.Size(72, 13);
            this.labelControCustomerCode.TabIndex = 2;
            this.labelControCustomerCode.Text = "Mã khách hàng";
            // 
            // labelControlFrom
            // 
            this.labelControlFrom.Location = new System.Drawing.Point(72, 15);
            this.labelControlFrom.Name = "labelControlFrom";
            this.labelControlFrom.Size = new System.Drawing.Size(40, 13);
            this.labelControlFrom.TabIndex = 2;
            this.labelControlFrom.Text = "Từ ngày";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(783, 12);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(142, 20);
            this.txtProductCode.TabIndex = 3;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(551, 12);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(131, 20);
            this.txtCustomerCode.TabIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcReport);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 43);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1205, 523);
            this.panelControl2.TabIndex = 2;
            // 
            // gcReport
            // 
            this.gcReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReport.Location = new System.Drawing.Point(2, 2);
            this.gcReport.MainView = this.gvReport;
            this.gcReport.Name = "gcReport";
            this.gcReport.Size = new System.Drawing.Size(1201, 519);
            this.gcReport.TabIndex = 6;
            this.gcReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReport});
            // 
            // gvReport
            // 
            this.gvReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrderNumber,
            this.colCreatedDate,
            this.colAgencyName,
            this.colProductName,
            this.colQuantity,
            this.colStockName});
            this.gvReport.GridControl = this.gcReport;
            this.gvReport.Name = "gvReport";
            this.gvReport.OptionsView.ShowAutoFilterRow = true;
            this.gvReport.OptionsView.ShowDetailButtons = false;
            this.gvReport.OptionsView.ShowGroupPanel = false;
            this.gvReport.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvReport_RowClick);
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.Caption = "Số lệnh";
            this.colOrderNumber.FieldName = "OrderNumber";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.Visible = true;
            this.colOrderNumber.VisibleIndex = 0;
            this.colOrderNumber.Width = 105;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Ngày xuất";
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 1;
            this.colCreatedDate.Width = 169;
            // 
            // colAgencyName
            // 
            this.colAgencyName.Caption = "Tên KH";
            this.colAgencyName.FieldName = "AgencyName";
            this.colAgencyName.Name = "colAgencyName";
            this.colAgencyName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAgencyName.Visible = true;
            this.colAgencyName.VisibleIndex = 2;
            this.colAgencyName.Width = 277;
            // 
            // colProductName
            // 
            this.colProductName.Caption = "Tên SP";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 3;
            this.colProductName.Width = 440;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Số lượng";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 4;
            this.colQuantity.Width = 61;
            // 
            // colStockName
            // 
            this.colStockName.Caption = "Kho xuất";
            this.colStockName.FieldName = "StockName";
            this.colStockName.Name = "colStockName";
            this.colStockName.Visible = true;
            this.colStockName.VisibleIndex = 5;
            this.colStockName.Width = 131;
            // 
            // frmReportExportInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 566);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportExportInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê thông tin xuất hàng";
            this.Load += new System.EventHandler(this.frmReportExportInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtpFrom;
        private DevExpress.XtraEditors.DateEdit dtpTo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.LabelControl labelControlTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControCustomerCode;
        private DevExpress.XtraEditors.LabelControl labelControlFrom;
        private DevExpress.XtraEditors.TextEdit txtProductCode;
        private DevExpress.XtraEditors.TextEdit txtCustomerCode;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gcReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReport;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAgencyName;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colStockName;
    }
}