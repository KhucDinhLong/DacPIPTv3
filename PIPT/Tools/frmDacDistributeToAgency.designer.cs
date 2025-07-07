namespace PIPT
{
    partial class frmDacDistributeToAgency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacDistributeToAgency));
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDacCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkPrintType = new System.Windows.Forms.CheckBox();
            this.gcExportInfo = new DevExpress.XtraGrid.GridControl();
            this.gvExportInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAgencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProvinceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelAddDacCode = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lueProduct = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddSerialCode = new System.Windows.Forms.Button();
            this.txtToSeri = new System.Windows.Forms.TextBox();
            this.txtFrSeri = new System.Windows.Forms.TextBox();
            this.btnDetailDelete = new System.Windows.Forms.Button();
            this.btnUpdateDetail = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtDacCode = new System.Windows.Forms.TextBox();
            this.ToSeriLabel = new System.Windows.Forms.Label();
            this.FrSeriLabel = new System.Windows.Forms.Label();
            this.labelSearchCode = new System.Windows.Forms.Label();
            this.panelDistributeToAgency = new System.Windows.Forms.Panel();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lueDacStock = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelDacStock = new System.Windows.Forms.Label();
            this.lueAgency = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditAgencyView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelOrderNumber = new System.Windows.Forms.Label();
            this.labelAgency = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.ucDataButtonAgency = new PIPT.ucDataButton();
            this.groupBoxProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExportInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExportInfo)).BeginInit();
            this.panelAddDacCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panelDistributeToAgency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDacStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditAgencyView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Controls.Add(this.gcDetail);
            this.groupBoxProduct.Controls.Add(this.chkPrintType);
            this.groupBoxProduct.Controls.Add(this.gcExportInfo);
            this.groupBoxProduct.Controls.Add(this.btnRefresh);
            this.groupBoxProduct.Controls.Add(this.panelAddDacCode);
            this.groupBoxProduct.Controls.Add(this.panelDistributeToAgency);
            this.groupBoxProduct.Controls.Add(this.lblQuantity);
            this.groupBoxProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProduct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProduct.Location = new System.Drawing.Point(0, 0);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Size = new System.Drawing.Size(874, 546);
            this.groupBoxProduct.TabIndex = 1;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "Thông tin khách hàng";
            // 
            // gcDetail
            // 
            this.gcDetail.Location = new System.Drawing.Point(479, 133);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.Size = new System.Drawing.Size(389, 391);
            this.gcDetail.TabIndex = 18;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDacCode,
            this.colProductName});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsSelection.MultiSelect = true;
            this.gvDetail.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colDacCode
            // 
            this.colDacCode.Caption = "QR Code";
            this.colDacCode.FieldName = "DacCode";
            this.colDacCode.Name = "colDacCode";
            this.colDacCode.Visible = true;
            this.colDacCode.VisibleIndex = 1;
            this.colDacCode.Width = 89;
            // 
            // colProductName
            // 
            this.colProductName.Caption = "Sản phẩm";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 2;
            this.colProductName.Width = 233;
            // 
            // chkPrintType
            // 
            this.chkPrintType.AutoSize = true;
            this.chkPrintType.Checked = true;
            this.chkPrintType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrintType.Location = new System.Drawing.Point(6, 199);
            this.chkPrintType.Name = "chkPrintType";
            this.chkPrintType.Size = new System.Drawing.Size(105, 17);
            this.chkPrintType.TabIndex = 16;
            this.chkPrintType.Text = "In theo số lượng";
            this.chkPrintType.UseVisualStyleBackColor = true;
            // 
            // gcExportInfo
            // 
            this.gcExportInfo.EmbeddedNavigator.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gcExportInfo.Location = new System.Drawing.Point(3, 222);
            this.gcExportInfo.MainView = this.gvExportInfo;
            this.gcExportInfo.Name = "gcExportInfo";
            this.gcExportInfo.Size = new System.Drawing.Size(469, 302);
            this.gcExportInfo.TabIndex = 17;
            this.gcExportInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExportInfo});
            // 
            // gvExportInfo
            // 
            this.gvExportInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnOrder,
            this.gridColumnAgencyCode,
            this.gridColumnStockID,
            this.gridColumnQuantity,
            this.gridColumnCreatedDate,
            this.gridColumActive,
            this.gridColumnProvinceCode,
            this.gridColumnDescription});
            this.gvExportInfo.GridControl = this.gcExportInfo;
            this.gvExportInfo.Name = "gvExportInfo";
            this.gvExportInfo.OptionsBehavior.Editable = false;
            this.gvExportInfo.OptionsView.ShowAutoFilterRow = true;
            this.gvExportInfo.OptionsView.ShowDetailButtons = false;
            this.gvExportInfo.OptionsView.ShowGroupPanel = false;
            this.gvExportInfo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvExportInfo_FocusedRowChanged);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Width = 44;
            // 
            // gridColumnOrder
            // 
            this.gridColumnOrder.Caption = "Lệnh";
            this.gridColumnOrder.FieldName = "OrderNumber";
            this.gridColumnOrder.Name = "gridColumnOrder";
            this.gridColumnOrder.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnOrder.Visible = true;
            this.gridColumnOrder.VisibleIndex = 0;
            this.gridColumnOrder.Width = 58;
            // 
            // gridColumnAgencyCode
            // 
            this.gridColumnAgencyCode.Caption = "Mã ĐL";
            this.gridColumnAgencyCode.FieldName = "AgencyCode";
            this.gridColumnAgencyCode.Name = "gridColumnAgencyCode";
            this.gridColumnAgencyCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnAgencyCode.Visible = true;
            this.gridColumnAgencyCode.VisibleIndex = 1;
            this.gridColumnAgencyCode.Width = 66;
            // 
            // gridColumnStockID
            // 
            this.gridColumnStockID.Caption = "Mã kho";
            this.gridColumnStockID.FieldName = "StockID";
            this.gridColumnStockID.Name = "gridColumnStockID";
            this.gridColumnStockID.Visible = true;
            this.gridColumnStockID.VisibleIndex = 2;
            this.gridColumnStockID.Width = 73;
            // 
            // gridColumnQuantity
            // 
            this.gridColumnQuantity.Caption = "Số lượng";
            this.gridColumnQuantity.FieldName = "Quantity";
            this.gridColumnQuantity.Name = "gridColumnQuantity";
            this.gridColumnQuantity.Visible = true;
            this.gridColumnQuantity.VisibleIndex = 3;
            this.gridColumnQuantity.Width = 51;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Ngày tạo";
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 5;
            this.gridColumnCreatedDate.Width = 66;
            // 
            // gridColumActive
            // 
            this.gridColumActive.Caption = "Active";
            this.gridColumActive.FieldName = "Active";
            this.gridColumActive.Name = "gridColumActive";
            this.gridColumActive.Visible = true;
            this.gridColumActive.VisibleIndex = 6;
            this.gridColumActive.Width = 42;
            // 
            // gridColumnProvinceCode
            // 
            this.gridColumnProvinceCode.Caption = "Province Code";
            this.gridColumnProvinceCode.FieldName = "ProvinceCode";
            this.gridColumnProvinceCode.Name = "gridColumnProvinceCode";
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Ghi chú";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 4;
            this.gridColumnDescription.Width = 95;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::PIPT.Properties.Resources.refresh16x16;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(375, 193);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelAddDacCode
            // 
            this.panelAddDacCode.Controls.Add(this.label1);
            this.panelAddDacCode.Controls.Add(this.lueProduct);
            this.panelAddDacCode.Controls.Add(this.btnAddSerialCode);
            this.panelAddDacCode.Controls.Add(this.txtToSeri);
            this.panelAddDacCode.Controls.Add(this.txtFrSeri);
            this.panelAddDacCode.Controls.Add(this.btnDetailDelete);
            this.panelAddDacCode.Controls.Add(this.btnUpdateDetail);
            this.panelAddDacCode.Controls.Add(this.btnEnter);
            this.panelAddDacCode.Controls.Add(this.txtDacCode);
            this.panelAddDacCode.Controls.Add(this.ToSeriLabel);
            this.panelAddDacCode.Controls.Add(this.FrSeriLabel);
            this.panelAddDacCode.Controls.Add(this.labelSearchCode);
            this.panelAddDacCode.Location = new System.Drawing.Point(478, 14);
            this.panelAddDacCode.Name = "panelAddDacCode";
            this.panelAddDacCode.Size = new System.Drawing.Size(390, 115);
            this.panelAddDacCode.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sản phẩm";
            // 
            // lueProduct
            // 
            this.lueProduct.EditValue = "";
            this.lueProduct.Location = new System.Drawing.Point(63, 65);
            this.lueProduct.Name = "lueProduct";
            this.lueProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProduct.Properties.DisplayMember = "Name";
            this.lueProduct.Properties.ImmediatePopup = true;
            this.lueProduct.Properties.NullText = "";
            this.lueProduct.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueProduct.Properties.PopupView = this.gridView1;
            this.lueProduct.Properties.ValueMember = "Code";
            this.lueProduct.Size = new System.Drawing.Size(321, 20);
            this.lueProduct.TabIndex = 13;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Product Code";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 35;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Product Name";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // btnAddSerialCode
            // 
            this.btnAddSerialCode.Location = new System.Drawing.Point(349, 38);
            this.btnAddSerialCode.Name = "btnAddSerialCode";
            this.btnAddSerialCode.Size = new System.Drawing.Size(35, 23);
            this.btnAddSerialCode.TabIndex = 12;
            this.btnAddSerialCode.Text = "+";
            this.btnAddSerialCode.UseVisualStyleBackColor = true;
            this.btnAddSerialCode.Click += new System.EventHandler(this.btnAddSerialCode_Click);
            // 
            // txtToSeri
            // 
            this.txtToSeri.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToSeri.Location = new System.Drawing.Point(215, 37);
            this.txtToSeri.Name = "txtToSeri";
            this.txtToSeri.Size = new System.Drawing.Size(128, 23);
            this.txtToSeri.TabIndex = 11;
            this.txtToSeri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToSeri_KeyPress);
            // 
            // txtFrSeri
            // 
            this.txtFrSeri.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrSeri.Location = new System.Drawing.Point(50, 38);
            this.txtFrSeri.Name = "txtFrSeri";
            this.txtFrSeri.Size = new System.Drawing.Size(128, 23);
            this.txtFrSeri.TabIndex = 10;
            this.txtFrSeri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrSeri_KeyPress);
            // 
            // btnDetailDelete
            // 
            this.btnDetailDelete.Image = global::PIPT.Properties.Resources.Delete1616;
            this.btnDetailDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailDelete.Location = new System.Drawing.Point(279, 86);
            this.btnDetailDelete.Name = "btnDetailDelete";
            this.btnDetailDelete.Size = new System.Drawing.Size(105, 24);
            this.btnDetailDelete.TabIndex = 15;
            this.btnDetailDelete.Text = "Xóa QRCode";
            this.btnDetailDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetailDelete.UseVisualStyleBackColor = true;
            this.btnDetailDelete.Click += new System.EventHandler(this.btnDetailDelete_Click);
            // 
            // btnUpdateDetail
            // 
            this.btnUpdateDetail.Image = global::PIPT.Properties.Resources.update1616;
            this.btnUpdateDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateDetail.Location = new System.Drawing.Point(6, 88);
            this.btnUpdateDetail.Name = "btnUpdateDetail";
            this.btnUpdateDetail.Size = new System.Drawing.Size(84, 24);
            this.btnUpdateDetail.TabIndex = 14;
            this.btnUpdateDetail.Text = "Cập nhật";
            this.btnUpdateDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateDetail.UseVisualStyleBackColor = true;
            this.btnUpdateDetail.Click += new System.EventHandler(this.btnUpdateDetail_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Image = global::PIPT.Properties.Resources.submit1616;
            this.btnEnter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnter.Location = new System.Drawing.Point(322, 7);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(62, 28);
            this.btnEnter.TabIndex = 9;
            this.btnEnter.Text = "Nhận";
            this.btnEnter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtDacCode
            // 
            this.txtDacCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDacCode.Location = new System.Drawing.Point(110, 10);
            this.txtDacCode.Name = "txtDacCode";
            this.txtDacCode.Size = new System.Drawing.Size(206, 23);
            this.txtDacCode.TabIndex = 8;
            this.txtDacCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDacCode_KeyPress);
            // 
            // ToSeriLabel
            // 
            this.ToSeriLabel.AutoSize = true;
            this.ToSeriLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToSeriLabel.Location = new System.Drawing.Point(184, 42);
            this.ToSeriLabel.Name = "ToSeriLabel";
            this.ToSeriLabel.Size = new System.Drawing.Size(25, 13);
            this.ToSeriLabel.TabIndex = 4;
            this.ToSeriLabel.Text = "=>";
            // 
            // FrSeriLabel
            // 
            this.FrSeriLabel.AutoSize = true;
            this.FrSeriLabel.Location = new System.Drawing.Point(3, 43);
            this.FrSeriLabel.Name = "FrSeriLabel";
            this.FrSeriLabel.Size = new System.Drawing.Size(41, 13);
            this.FrSeriLabel.TabIndex = 4;
            this.FrSeriLabel.Text = "Từ Seri";
            // 
            // labelSearchCode
            // 
            this.labelSearchCode.AutoSize = true;
            this.labelSearchCode.Location = new System.Drawing.Point(3, 15);
            this.labelSearchCode.Name = "labelSearchCode";
            this.labelSearchCode.Size = new System.Drawing.Size(101, 13);
            this.labelSearchCode.TabIndex = 4;
            this.labelSearchCode.Text = "Quét mã hoặc nhập";
            // 
            // panelDistributeToAgency
            // 
            this.panelDistributeToAgency.Controls.Add(this.lblProduct);
            this.panelDistributeToAgency.Controls.Add(this.label2);
            this.panelDistributeToAgency.Controls.Add(this.txtDescription);
            this.panelDistributeToAgency.Controls.Add(this.lueDacStock);
            this.panelDistributeToAgency.Controls.Add(this.labelDacStock);
            this.panelDistributeToAgency.Controls.Add(this.lueAgency);
            this.panelDistributeToAgency.Controls.Add(this.txtQuantity);
            this.panelDistributeToAgency.Controls.Add(this.txtOrderNumber);
            this.panelDistributeToAgency.Controls.Add(this.dtpCreatedDate);
            this.panelDistributeToAgency.Controls.Add(this.chkActive);
            this.panelDistributeToAgency.Controls.Add(this.labelDescription);
            this.panelDistributeToAgency.Controls.Add(this.labelCreatedDate);
            this.panelDistributeToAgency.Controls.Add(this.labelQuantity);
            this.panelDistributeToAgency.Controls.Add(this.labelOrderNumber);
            this.panelDistributeToAgency.Controls.Add(this.labelAgency);
            this.panelDistributeToAgency.Location = new System.Drawing.Point(3, 14);
            this.panelDistributeToAgency.Name = "panelDistributeToAgency";
            this.panelDistributeToAgency.Size = new System.Drawing.Size(469, 173);
            this.panelDistributeToAgency.TabIndex = 9;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(72, 68);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(0, 13);
            this.lblProduct.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Sản phẩm";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(238, 89);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(228, 73);
            this.txtDescription.TabIndex = 7;
            // 
            // lueDacStock
            // 
            this.lueDacStock.EditValue = "";
            this.lueDacStock.Location = new System.Drawing.Point(345, 11);
            this.lueDacStock.Name = "lueDacStock";
            this.lueDacStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDacStock.Properties.DisplayMember = "Name";
            this.lueDacStock.Properties.ImmediatePopup = true;
            this.lueDacStock.Properties.NullText = "";
            this.lueDacStock.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueDacStock.Properties.PopupView = this.gridView2;
            this.lueDacStock.Properties.ValueMember = "Code";
            this.lueDacStock.Size = new System.Drawing.Size(121, 20);
            this.lueDacStock.TabIndex = 1;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCode,
            this.gridColumnName});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "Mã kho";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 0;
            this.gridColumnCode.Width = 35;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Tên kho";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            // 
            // labelDacStock
            // 
            this.labelDacStock.AutoSize = true;
            this.labelDacStock.Location = new System.Drawing.Point(287, 15);
            this.labelDacStock.Name = "labelDacStock";
            this.labelDacStock.Size = new System.Drawing.Size(52, 13);
            this.labelDacStock.TabIndex = 15;
            this.labelDacStock.Text = "Chọn kho";
            // 
            // lueAgency
            // 
            this.lueAgency.EditValue = "";
            this.lueAgency.Location = new System.Drawing.Point(72, 39);
            this.lueAgency.Name = "lueAgency";
            this.lueAgency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAgency.Properties.DisplayMember = "Name";
            this.lueAgency.Properties.ImmediatePopup = true;
            this.lueAgency.Properties.NullText = "";
            this.lueAgency.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueAgency.Properties.PopupView = this.gridLookUpEditAgencyView;
            this.lueAgency.Properties.ValueMember = "Code";
            this.lueAgency.Size = new System.Drawing.Size(394, 20);
            this.lueAgency.TabIndex = 2;
            // 
            // gridLookUpEditAgencyView
            // 
            this.gridLookUpEditAgencyView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.gridColumnAddress});
            this.gridLookUpEditAgencyView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditAgencyView.Name = "gridLookUpEditAgencyView";
            this.gridLookUpEditAgencyView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditAgencyView.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditAgencyView.OptionsView.ShowGroupPanel = false;
            // 
            // colCode
            // 
            this.colCode.Caption = "Agency Code";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 80;
            // 
            // colName
            // 
            this.colName.Caption = "Agency Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 150;
            // 
            // gridColumnAddress
            // 
            this.gridColumnAddress.Caption = "Address";
            this.gridColumnAddress.FieldName = "Address";
            this.gridColumnAddress.Name = "gridColumnAddress";
            this.gridColumnAddress.Visible = true;
            this.gridColumnAddress.VisibleIndex = 2;
            this.gridColumnAddress.Width = 154;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(72, 89);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(80, 21);
            this.txtQuantity.TabIndex = 4;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(72, 11);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(113, 21);
            this.txtOrderNumber.TabIndex = 0;
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedDate.Location = new System.Drawing.Point(72, 117);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(100, 21);
            this.dtpCreatedDate.TabIndex = 5;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(72, 144);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(97, 17);
            this.chkActive.TabIndex = 6;
            this.chkActive.Text = "Còn hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(190, 89);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ghi chú";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(15, 123);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(17, 92);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(49, 13);
            this.labelQuantity.TabIndex = 4;
            this.labelQuantity.Text = "Số lượng";
            // 
            // labelOrderNumber
            // 
            this.labelOrderNumber.AutoSize = true;
            this.labelOrderNumber.Location = new System.Drawing.Point(11, 15);
            this.labelOrderNumber.Name = "labelOrderNumber";
            this.labelOrderNumber.Size = new System.Drawing.Size(55, 13);
            this.labelOrderNumber.TabIndex = 4;
            this.labelOrderNumber.Text = "Lệnh xuất";
            // 
            // labelAgency
            // 
            this.labelAgency.AutoSize = true;
            this.labelAgency.Location = new System.Drawing.Point(3, 42);
            this.labelAgency.Name = "labelAgency";
            this.labelAgency.Size = new System.Drawing.Size(63, 13);
            this.labelAgency.TabIndex = 4;
            this.labelAgency.Text = "Khách hàng";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(481, 527);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(132, 13);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Số sản phẩm đã thêm:";
            // 
            // ucDataButtonAgency
            // 
            this.ucDataButtonAgency.AddNewVisible = true;
            this.ucDataButtonAgency.CancelVisible = true;
            this.ucDataButtonAgency.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonAgency.DeleteVisible = true;
            this.ucDataButtonAgency.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonAgency.EditVisible = true;
            this.ucDataButtonAgency.ExcelVisible = false;
            this.ucDataButtonAgency.IsContitnue = true;
            this.ucDataButtonAgency.LanguageVisible = false;
            this.ucDataButtonAgency.Location = new System.Drawing.Point(0, 546);
            this.ucDataButtonAgency.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonAgency.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonAgency.MultiLanguageVisible = false;
            this.ucDataButtonAgency.Name = "ucDataButtonAgency";
            this.ucDataButtonAgency.PrintVisible = false;
            this.ucDataButtonAgency.ReportVisible = false;
            this.ucDataButtonAgency.SaveVisible = true;
            this.ucDataButtonAgency.Size = new System.Drawing.Size(874, 34);
            this.ucDataButtonAgency.TabIndex = 19;
            this.ucDataButtonAgency.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_InsertHandler);
            this.ucDataButtonAgency.PrintHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_PrintHandler);
            this.ucDataButtonAgency.ExcelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_ExcelHandler);
            this.ucDataButtonAgency.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_EditHandler);
            this.ucDataButtonAgency.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_SaveHandler);
            this.ucDataButtonAgency.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_DeleteHandler);
            this.ucDataButtonAgency.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_CancelHandler);
            this.ucDataButtonAgency.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_CloseHandler);
            // 
            // frmDacDistributeToAgency
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(874, 580);
            this.Controls.Add(this.groupBoxProduct);
            this.Controls.Add(this.ucDataButtonAgency);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDacDistributeToAgency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân phối hàng hóa đến khách hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDacDistributeToAgency_FormClosing);
            this.Load += new System.EventHandler(this.frmDacDistributeToAgency_Load);
            this.groupBoxProduct.ResumeLayout(false);
            this.groupBoxProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExportInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExportInfo)).EndInit();
            this.panelAddDacCode.ResumeLayout(false);
            this.panelAddDacCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panelDistributeToAgency.ResumeLayout(false);
            this.panelDistributeToAgency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDacStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditAgencyView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonAgency;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private System.Windows.Forms.Panel panelDistributeToAgency;
        private System.Windows.Forms.DateTimePicker dtpCreatedDate;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.Label labelAgency;
        private System.Windows.Forms.Panel panelAddDacCode;
        private System.Windows.Forms.TextBox txtDacCode;
        private System.Windows.Forms.Label labelSearchCode;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label labelOrderNumber;
        private System.Windows.Forms.Label lblQuantity;
        private DevExpress.XtraEditors.GridLookUpEdit lueAgency;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditAgencyView;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.GridControl gcExportInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExportInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAgencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumActive;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProvinceCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Button btnDetailDelete;
        private System.Windows.Forms.Button btnUpdateDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAddress;
        private System.Windows.Forms.Button btnAddSerialCode;
        private System.Windows.Forms.TextBox txtToSeri;
        private System.Windows.Forms.TextBox txtFrSeri;
        private System.Windows.Forms.Label ToSeriLabel;
        private System.Windows.Forms.Label FrSeriLabel;
        private DevExpress.XtraEditors.GridLookUpEdit lueProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Button btnRefresh;
        private DevExpress.XtraEditors.GridLookUpEdit lueDacStock;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private System.Windows.Forms.Label labelDacStock;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStockID;
        private System.Windows.Forms.CheckBox chkPrintType;
        private System.Windows.Forms.TextBox txtDescription;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDacCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label2;
    }
}