namespace PIPT
{
    partial class frmReportWarehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportWarehouse));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gcReport = new DevExpress.XtraGrid.GridControl();
            this.gvReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInsertNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlTo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlFrom = new DevExpress.XtraEditors.LabelControl();
            this.txtProductCode = new DevExpress.XtraEditors.TextEdit();
            this.dtpFrom = new DevExpress.XtraEditors.DateEdit();
            this.dtpTo = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcReport);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 51);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1070, 512);
            this.panelControl2.TabIndex = 4;
            // 
            // gcReport
            // 
            this.gcReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReport.Location = new System.Drawing.Point(2, 2);
            this.gcReport.MainView = this.gvReport;
            this.gcReport.Name = "gcReport";
            this.gcReport.Size = new System.Drawing.Size(1066, 508);
            this.gcReport.TabIndex = 5;
            this.gcReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReport});
            // 
            // gvReport
            // 
            this.gvReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInsertNumber,
            this.colCreatedDate,
            this.colProductCode,
            this.colProductName,
            this.colQuantity,
            this.colStockID,
            this.colStockName});
            this.gvReport.GridControl = this.gcReport;
            this.gvReport.Name = "gvReport";
            this.gvReport.OptionsView.ShowAutoFilterRow = true;
            this.gvReport.OptionsView.ShowDetailButtons = false;
            this.gvReport.OptionsView.ShowGroupPanel = false;
            this.gvReport.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvReport_RowClick);
            // 
            // colInsertNumber
            // 
            this.colInsertNumber.Caption = "Số Lệnh";
            this.colInsertNumber.FieldName = "InsertNumber";
            this.colInsertNumber.Name = "colInsertNumber";
            this.colInsertNumber.Visible = true;
            this.colInsertNumber.VisibleIndex = 0;
            this.colInsertNumber.Width = 123;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Ngày tạo";
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 1;
            this.colCreatedDate.Width = 125;
            // 
            // colProductCode
            // 
            this.colProductCode.Caption = "Mã sản phẩm";
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 2;
            this.colProductCode.Width = 143;
            // 
            // colProductName
            // 
            this.colProductName.Caption = "Tên sản phẩm";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 3;
            this.colProductName.Width = 374;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Số lượng";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 4;
            this.colQuantity.Width = 74;
            // 
            // colStockID
            // 
            this.colStockID.Caption = "Mã kho";
            this.colStockID.FieldName = "StockID";
            this.colStockID.Name = "colStockID";
            this.colStockID.Visible = true;
            this.colStockID.VisibleIndex = 5;
            this.colStockID.Width = 100;
            // 
            // colStockName
            // 
            this.colStockName.Caption = "Tên kho";
            this.colStockName.FieldName = "StockName";
            this.colStockName.Name = "colStockName";
            this.colStockName.Visible = true;
            this.colStockName.VisibleIndex = 6;
            this.colStockName.Width = 109;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExcel);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.labelControlTo);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControlFrom);
            this.panelControl1.Controls.Add(this.txtProductCode);
            this.panelControl1.Controls.Add(this.dtpFrom);
            this.panelControl1.Controls.Add(this.dtpTo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1070, 51);
            this.panelControl1.TabIndex = 3;
            // 
            // btnExcel
            // 
            this.btnExcel.ImageOptions.Image = global::PIPT.Properties.Resources.Excel;
            this.btnExcel.Location = new System.Drawing.Point(953, 11);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(87, 27);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(860, 12);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(87, 27);
            this.btnGetData.TabIndex = 3;
            this.btnGetData.Text = "Nhận dữ liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // labelControlTo
            // 
            this.labelControlTo.Location = new System.Drawing.Point(341, 18);
            this.labelControlTo.Name = "labelControlTo";
            this.labelControlTo.Size = new System.Drawing.Size(47, 13);
            this.labelControlTo.TabIndex = 2;
            this.labelControlTo.Text = "Đến ngày";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(573, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Sản phẩm";
            // 
            // labelControlFrom
            // 
            this.labelControlFrom.Location = new System.Drawing.Point(91, 18);
            this.labelControlFrom.Name = "labelControlFrom";
            this.labelControlFrom.Size = new System.Drawing.Size(40, 13);
            this.labelControlFrom.TabIndex = 2;
            this.labelControlFrom.Text = "Từ ngày";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(626, 15);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(142, 20);
            this.txtProductCode.TabIndex = 2;
            // 
            // dtpFrom
            // 
            this.dtpFrom.EditValue = new System.DateTime(2017, 2, 28, 0, 0, 0, 0);
            this.dtpFrom.Location = new System.Drawing.Point(137, 15);
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
            this.dtpTo.EditValue = new System.DateTime(2025, 6, 25, 16, 43, 26, 0);
            this.dtpTo.Location = new System.Drawing.Point(394, 15);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Size = new System.Drawing.Size(113, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // frmReportWarehouse
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1070, 563);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportWarehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sản phẩm trong kho";
            this.Load += new System.EventHandler(this.frmReportWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gcReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReport;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.LabelControl labelControlTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControlFrom;
        private DevExpress.XtraEditors.TextEdit txtProductCode;
        private DevExpress.XtraEditors.DateEdit dtpFrom;
        private DevExpress.XtraEditors.DateEdit dtpTo;
        private DevExpress.XtraGrid.Columns.GridColumn colInsertNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colStockID;
        private DevExpress.XtraGrid.Columns.GridColumn colStockName;
    }
}