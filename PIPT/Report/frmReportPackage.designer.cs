namespace PIPT
{
    partial class frmReportPackage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportPackage));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gcReport = new DevExpress.XtraGrid.GridControl();
            this.gvReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPackageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonPackaged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlTo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlFrom = new DevExpress.XtraEditors.LabelControl();
            this.txtPackageCode = new DevExpress.XtraEditors.TextEdit();
            this.txtProductCode = new DevExpress.XtraEditors.TextEdit();
            this.dtpFrom = new DevExpress.XtraEditors.DateEdit();
            this.dtpTo = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackageCode.Properties)).BeginInit();
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
            this.panelControl2.Location = new System.Drawing.Point(0, 44);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1152, 486);
            this.panelControl2.TabIndex = 4;
            // 
            // gcReport
            // 
            this.gcReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReport.Location = new System.Drawing.Point(2, 2);
            this.gcReport.MainView = this.gvReport;
            this.gcReport.Name = "gcReport";
            this.gcReport.Size = new System.Drawing.Size(1148, 482);
            this.gcReport.TabIndex = 7;
            this.gcReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReport});
            // 
            // gvReport
            // 
            this.gvReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCreatedDate,
            this.colPackageCode,
            this.colProductName,
            this.colQuantity,
            this.colBatch,
            this.colPersonPackaged,
            this.colDescription});
            this.gvReport.GridControl = this.gcReport;
            this.gvReport.Name = "gvReport";
            this.gvReport.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvReport.OptionsSelection.MultiSelect = true;
            this.gvReport.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvReport.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gvReport.OptionsView.ShowAutoFilterRow = true;
            this.gvReport.OptionsView.ShowDetailButtons = false;
            this.gvReport.OptionsView.ShowGroupPanel = false;
            this.gvReport.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvReport_RowClick);
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Ngày tạo";
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 1;
            this.colCreatedDate.Width = 116;
            // 
            // colPackageCode
            // 
            this.colPackageCode.Caption = "Mã thùng";
            this.colPackageCode.FieldName = "PackageCode";
            this.colPackageCode.Name = "colPackageCode";
            this.colPackageCode.Visible = true;
            this.colPackageCode.VisibleIndex = 2;
            this.colPackageCode.Width = 112;
            // 
            // colProductName
            // 
            this.colProductName.Caption = "Sản phẩm";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 3;
            this.colProductName.Width = 330;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Số lượng";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 4;
            this.colQuantity.Width = 65;
            // 
            // colBatch
            // 
            this.colBatch.Caption = "Số lô";
            this.colBatch.FieldName = "Batch";
            this.colBatch.Name = "colBatch";
            this.colBatch.Visible = true;
            this.colBatch.VisibleIndex = 5;
            this.colBatch.Width = 90;
            // 
            // colPersonPackaged
            // 
            this.colPersonPackaged.Caption = "Người đóng";
            this.colPersonPackaged.FieldName = "PersonPackaged";
            this.colPersonPackaged.Name = "colPersonPackaged";
            this.colPersonPackaged.Visible = true;
            this.colPersonPackaged.VisibleIndex = 6;
            this.colPersonPackaged.Width = 121;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Ghi chú";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 7;
            this.colDescription.Width = 266;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExcel);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.labelControlTo);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControlFrom);
            this.panelControl1.Controls.Add(this.txtPackageCode);
            this.panelControl1.Controls.Add(this.txtProductCode);
            this.panelControl1.Controls.Add(this.dtpFrom);
            this.panelControl1.Controls.Add(this.dtpTo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1152, 44);
            this.panelControl1.TabIndex = 3;
            // 
            // btnExcel
            // 
            this.btnExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.ImageOptions.Image")));
            this.btnExcel.Location = new System.Drawing.Point(1053, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(87, 27);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(960, 8);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(87, 27);
            this.btnGetData.TabIndex = 5;
            this.btnGetData.Text = "Nhận dữ liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // labelControlTo
            // 
            this.labelControlTo.Location = new System.Drawing.Point(170, 14);
            this.labelControlTo.Name = "labelControlTo";
            this.labelControlTo.Size = new System.Drawing.Size(47, 13);
            this.labelControlTo.TabIndex = 2;
            this.labelControlTo.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(342, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Mã thùng";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(515, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Sản phẩm";
            // 
            // labelControlFrom
            // 
            this.labelControlFrom.Location = new System.Drawing.Point(17, 14);
            this.labelControlFrom.Name = "labelControlFrom";
            this.labelControlFrom.Size = new System.Drawing.Size(40, 13);
            this.labelControlFrom.TabIndex = 2;
            this.labelControlFrom.Text = "Từ ngày";
            // 
            // txtPackageCode
            // 
            this.txtPackageCode.Location = new System.Drawing.Point(393, 11);
            this.txtPackageCode.Name = "txtPackageCode";
            this.txtPackageCode.Size = new System.Drawing.Size(116, 20);
            this.txtPackageCode.TabIndex = 2;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(568, 12);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(116, 20);
            this.txtProductCode.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.EditValue = new System.DateTime(2017, 2, 28, 0, 0, 0, 0);
            this.dtpFrom.Location = new System.Drawing.Point(63, 12);
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
            this.dtpTo.Location = new System.Drawing.Point(223, 11);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Size = new System.Drawing.Size(113, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // frmReportPackage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1152, 530);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sản phẩm đóng thùng";
            this.Load += new System.EventHandler(this.frmReportPackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackageCode.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colPackageCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPackageCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colBatch;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonPackaged;
    }
}