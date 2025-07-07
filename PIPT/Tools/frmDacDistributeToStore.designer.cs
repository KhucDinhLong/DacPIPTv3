namespace PIPT
{
    partial class frmDacDistributeToStore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacDistributeToStore));
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDacCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExport = new DevExpress.XtraGrid.GridControl();
            this.gvExport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProvinceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelAddDacCode = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lueProduct = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddSerialCode = new System.Windows.Forms.Button();
            this.txtToSeri = new System.Windows.Forms.TextBox();
            this.txtFrSeri = new System.Windows.Forms.TextBox();
            this.ToSeriLabel = new System.Windows.Forms.Label();
            this.FrSeriLabel = new System.Windows.Forms.Label();
            this.btnDetailDelete = new System.Windows.Forms.Button();
            this.btnUpdateDetail = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtDacCode = new System.Windows.Forms.TextBox();
            this.labelSearchCode = new System.Windows.Forms.Label();
            this.panelDistributeToStore = new System.Windows.Forms.Panel();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lueStock = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelDacStock = new System.Windows.Forms.Label();
            this.lueStore = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditAgencyView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.dtCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelOrderNumber = new System.Windows.Forms.Label();
            this.labelAgency = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblRealityQuantity = new System.Windows.Forms.Label();
            this.ucDataButtonStore = new PIPT.ucDataButton();
            this.groupBoxProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExport)).BeginInit();
            this.panelAddDacCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panelDistributeToStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditAgencyView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Controls.Add(this.gcDetail);
            this.groupBoxProduct.Controls.Add(this.gcExport);
            this.groupBoxProduct.Controls.Add(this.panelAddDacCode);
            this.groupBoxProduct.Controls.Add(this.panelDistributeToStore);
            this.groupBoxProduct.Controls.Add(this.btnRefresh);
            this.groupBoxProduct.Controls.Add(this.lblRealityQuantity);
            this.groupBoxProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProduct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProduct.Location = new System.Drawing.Point(0, 0);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Size = new System.Drawing.Size(814, 546);
            this.groupBoxProduct.TabIndex = 1;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "Thông tin cửa hàng";
            // 
            // gcDetail
            // 
            this.gcDetail.Location = new System.Drawing.Point(452, 136);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.Size = new System.Drawing.Size(356, 388);
            this.gcDetail.TabIndex = 16;
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
            this.gvDetail.OptionsSelection.CheckBoxSelectorColumnWidth = 50;
            this.gvDetail.OptionsSelection.MultiSelect = true;
            this.gvDetail.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colDacCode
            // 
            this.colDacCode.Caption = "QRCode";
            this.colDacCode.FieldName = "DacCode";
            this.colDacCode.Name = "colDacCode";
            this.colDacCode.Visible = true;
            this.colDacCode.VisibleIndex = 1;
            // 
            // colProductName
            // 
            this.colProductName.Caption = "Sản phẩm";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 2;
            // 
            // gcExport
            // 
            this.gcExport.EmbeddedNavigator.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gcExport.Location = new System.Drawing.Point(4, 217);
            this.gcExport.MainView = this.gvExport;
            this.gcExport.Name = "gcExport";
            this.gcExport.Size = new System.Drawing.Size(442, 323);
            this.gcExport.TabIndex = 7;
            this.gcExport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExport});
            // 
            // gvExport
            // 
            this.gvExport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnOrder,
            this.gridColumnStoreCode,
            this.gridColumnStockID,
            this.gridColumnQuantity,
            this.gridColumnCreatedDate,
            this.gridColumActive,
            this.gridColumnProvinceCode,
            this.gridColumnDescription});
            this.gvExport.GridControl = this.gcExport;
            this.gvExport.Name = "gvExport";
            this.gvExport.OptionsBehavior.Editable = false;
            this.gvExport.OptionsView.ShowAutoFilterRow = true;
            this.gvExport.OptionsView.ShowGroupPanel = false;
            this.gvExport.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvExport_FocusedRowChanged);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "Id";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Width = 97;
            // 
            // gridColumnOrder
            // 
            this.gridColumnOrder.Caption = "Lệnh";
            this.gridColumnOrder.FieldName = "OrderNumber";
            this.gridColumnOrder.Name = "gridColumnOrder";
            this.gridColumnOrder.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnOrder.Visible = true;
            this.gridColumnOrder.VisibleIndex = 0;
            this.gridColumnOrder.Width = 51;
            // 
            // gridColumnStoreCode
            // 
            this.gridColumnStoreCode.Caption = "Mã CH";
            this.gridColumnStoreCode.FieldName = "StoreCode";
            this.gridColumnStoreCode.Name = "gridColumnStoreCode";
            this.gridColumnStoreCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnStoreCode.Visible = true;
            this.gridColumnStoreCode.VisibleIndex = 1;
            this.gridColumnStoreCode.Width = 59;
            // 
            // gridColumnStockID
            // 
            this.gridColumnStockID.Caption = "Mã kho";
            this.gridColumnStockID.FieldName = "StockID";
            this.gridColumnStockID.Name = "gridColumnStockID";
            this.gridColumnStockID.Visible = true;
            this.gridColumnStockID.VisibleIndex = 2;
            this.gridColumnStockID.Width = 60;
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
            this.gridColumnCreatedDate.Width = 70;
            // 
            // gridColumActive
            // 
            this.gridColumActive.Caption = "Active";
            this.gridColumActive.FieldName = "Active";
            this.gridColumActive.Name = "gridColumActive";
            this.gridColumActive.Visible = true;
            this.gridColumActive.VisibleIndex = 6;
            this.gridColumActive.Width = 41;
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
            this.gridColumnDescription.Width = 92;
            // 
            // panelAddDacCode
            // 
            this.panelAddDacCode.Controls.Add(this.label1);
            this.panelAddDacCode.Controls.Add(this.lueProduct);
            this.panelAddDacCode.Controls.Add(this.btnAddSerialCode);
            this.panelAddDacCode.Controls.Add(this.txtToSeri);
            this.panelAddDacCode.Controls.Add(this.txtFrSeri);
            this.panelAddDacCode.Controls.Add(this.ToSeriLabel);
            this.panelAddDacCode.Controls.Add(this.FrSeriLabel);
            this.panelAddDacCode.Controls.Add(this.btnDetailDelete);
            this.panelAddDacCode.Controls.Add(this.btnUpdateDetail);
            this.panelAddDacCode.Controls.Add(this.btnEnter);
            this.panelAddDacCode.Controls.Add(this.txtDacCode);
            this.panelAddDacCode.Controls.Add(this.labelSearchCode);
            this.panelAddDacCode.Location = new System.Drawing.Point(448, 14);
            this.panelAddDacCode.Name = "panelAddDacCode";
            this.panelAddDacCode.Size = new System.Drawing.Size(361, 115);
            this.panelAddDacCode.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 19;
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
            this.lueProduct.Size = new System.Drawing.Size(291, 20);
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
            this.btnAddSerialCode.Location = new System.Drawing.Point(319, 39);
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
            this.txtToSeri.Location = new System.Drawing.Point(202, 39);
            this.txtToSeri.Name = "txtToSeri";
            this.txtToSeri.Size = new System.Drawing.Size(111, 23);
            this.txtToSeri.TabIndex = 11;
            this.txtToSeri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToSeri_KeyPress);
            // 
            // txtFrSeri
            // 
            this.txtFrSeri.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrSeri.Location = new System.Drawing.Point(50, 39);
            this.txtFrSeri.Name = "txtFrSeri";
            this.txtFrSeri.Size = new System.Drawing.Size(115, 23);
            this.txtFrSeri.TabIndex = 10;
            this.txtFrSeri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrSeri_KeyPress);
            // 
            // ToSeriLabel
            // 
            this.ToSeriLabel.AutoSize = true;
            this.ToSeriLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToSeriLabel.Location = new System.Drawing.Point(171, 44);
            this.ToSeriLabel.Name = "ToSeriLabel";
            this.ToSeriLabel.Size = new System.Drawing.Size(25, 13);
            this.ToSeriLabel.TabIndex = 9;
            this.ToSeriLabel.Text = "=>";
            // 
            // FrSeriLabel
            // 
            this.FrSeriLabel.AutoSize = true;
            this.FrSeriLabel.Location = new System.Drawing.Point(3, 44);
            this.FrSeriLabel.Name = "FrSeriLabel";
            this.FrSeriLabel.Size = new System.Drawing.Size(41, 13);
            this.FrSeriLabel.TabIndex = 10;
            this.FrSeriLabel.Text = "Từ Seri";
            // 
            // btnDetailDelete
            // 
            this.btnDetailDelete.Image = global::PIPT.Properties.Resources.Delete1616;
            this.btnDetailDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailDelete.Location = new System.Drawing.Point(249, 88);
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
            this.btnEnter.Location = new System.Drawing.Point(292, 6);
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
            this.txtDacCode.Size = new System.Drawing.Size(176, 23);
            this.txtDacCode.TabIndex = 8;
            this.txtDacCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDacCode_KeyPress);
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
            // panelDistributeToStore
            // 
            this.panelDistributeToStore.Controls.Add(this.chkActive);
            this.panelDistributeToStore.Controls.Add(this.txtDescription);
            this.panelDistributeToStore.Controls.Add(this.lblProduct);
            this.panelDistributeToStore.Controls.Add(this.lueStock);
            this.panelDistributeToStore.Controls.Add(this.labelDacStock);
            this.panelDistributeToStore.Controls.Add(this.lueStore);
            this.panelDistributeToStore.Controls.Add(this.txtQuantity);
            this.panelDistributeToStore.Controls.Add(this.txtOrderNumber);
            this.panelDistributeToStore.Controls.Add(this.dtCreatedDate);
            this.panelDistributeToStore.Controls.Add(this.labelDescription);
            this.panelDistributeToStore.Controls.Add(this.labelProduct);
            this.panelDistributeToStore.Controls.Add(this.labelCreatedDate);
            this.panelDistributeToStore.Controls.Add(this.labelQuantity);
            this.panelDistributeToStore.Controls.Add(this.labelOrderNumber);
            this.panelDistributeToStore.Controls.Add(this.labelAgency);
            this.panelDistributeToStore.Location = new System.Drawing.Point(3, 14);
            this.panelDistributeToStore.Name = "panelDistributeToStore";
            this.panelDistributeToStore.Size = new System.Drawing.Size(442, 168);
            this.panelDistributeToStore.TabIndex = 9;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(72, 144);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(97, 17);
            this.chkActive.TabIndex = 19;
            this.chkActive.Text = "Còn hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(241, 91);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(198, 70);
            this.txtDescription.TabIndex = 4;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(72, 68);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(0, 13);
            this.lblProduct.TabIndex = 18;
            // 
            // lueStock
            // 
            this.lueStock.EditValue = "";
            this.lueStock.Location = new System.Drawing.Point(283, 9);
            this.lueStock.Name = "lueStock";
            this.lueStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStock.Properties.DisplayMember = "Name";
            this.lueStock.Properties.ImmediatePopup = true;
            this.lueStock.Properties.NullText = "";
            this.lueStock.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueStock.Properties.PopupView = this.gridView2;
            this.lueStock.Properties.ValueMember = "Code";
            this.lueStock.Size = new System.Drawing.Size(156, 20);
            this.lueStock.TabIndex = 1;
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
            this.labelDacStock.Location = new System.Drawing.Point(225, 14);
            this.labelDacStock.Name = "labelDacStock";
            this.labelDacStock.Size = new System.Drawing.Size(52, 13);
            this.labelDacStock.TabIndex = 17;
            this.labelDacStock.Text = "Chọn kho";
            // 
            // lueStore
            // 
            this.lueStore.EditValue = "";
            this.lueStore.Location = new System.Drawing.Point(72, 39);
            this.lueStore.Name = "lueStore";
            this.lueStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStore.Properties.DisplayMember = "Name";
            this.lueStore.Properties.ImmediatePopup = true;
            this.lueStore.Properties.NullText = "";
            this.lueStore.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueStore.Properties.PopupView = this.gridLookUpEditAgencyView;
            this.lueStore.Properties.ValueMember = "Code";
            this.lueStore.Size = new System.Drawing.Size(367, 20);
            this.lueStore.TabIndex = 2;
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
            this.txtQuantity.Location = new System.Drawing.Point(72, 91);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(80, 21);
            this.txtQuantity.TabIndex = 3;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(72, 11);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(121, 21);
            this.txtOrderNumber.TabIndex = 0;
            // 
            // dtCreatedDate
            // 
            this.dtCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCreatedDate.Location = new System.Drawing.Point(72, 118);
            this.dtCreatedDate.Name = "dtCreatedDate";
            this.dtCreatedDate.Size = new System.Drawing.Size(100, 21);
            this.dtCreatedDate.TabIndex = 5;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(192, 94);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ghi chú";
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(12, 68);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(54, 13);
            this.labelProduct.TabIndex = 4;
            this.labelProduct.Text = "Sản phẩm";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(15, 121);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(15, 94);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(49, 13);
            this.labelQuantity.TabIndex = 4;
            this.labelQuantity.Text = "Số lượng";
            // 
            // labelOrderNumber
            // 
            this.labelOrderNumber.AutoSize = true;
            this.labelOrderNumber.Location = new System.Drawing.Point(11, 14);
            this.labelOrderNumber.Name = "labelOrderNumber";
            this.labelOrderNumber.Size = new System.Drawing.Size(55, 13);
            this.labelOrderNumber.TabIndex = 4;
            this.labelOrderNumber.Text = "Lệnh xuất";
            // 
            // labelAgency
            // 
            this.labelAgency.AutoSize = true;
            this.labelAgency.Location = new System.Drawing.Point(12, 42);
            this.labelAgency.Name = "labelAgency";
            this.labelAgency.Size = new System.Drawing.Size(54, 13);
            this.labelAgency.TabIndex = 4;
            this.labelAgency.Text = "Cửa hàng";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::PIPT.Properties.Resources.refresh16x16;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(367, 188);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblRealityQuantity
            // 
            this.lblRealityQuantity.AutoSize = true;
            this.lblRealityQuantity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealityQuantity.Location = new System.Drawing.Point(445, 527);
            this.lblRealityQuantity.Name = "lblRealityQuantity";
            this.lblRealityQuantity.Size = new System.Drawing.Size(132, 13);
            this.lblRealityQuantity.TabIndex = 4;
            this.lblRealityQuantity.Text = "Số sản phẩm đã thêm:";
            // 
            // ucDataButtonStore
            // 
            this.ucDataButtonStore.AddNewVisible = true;
            this.ucDataButtonStore.CancelVisible = true;
            this.ucDataButtonStore.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonStore.DeleteVisible = true;
            this.ucDataButtonStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonStore.EditVisible = true;
            this.ucDataButtonStore.ExcelVisible = false;
            this.ucDataButtonStore.IsContitnue = true;
            this.ucDataButtonStore.LanguageVisible = false;
            this.ucDataButtonStore.Location = new System.Drawing.Point(0, 546);
            this.ucDataButtonStore.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonStore.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonStore.MultiLanguageVisible = false;
            this.ucDataButtonStore.Name = "ucDataButtonStore";
            this.ucDataButtonStore.PrintVisible = false;
            this.ucDataButtonStore.ReportVisible = false;
            this.ucDataButtonStore.SaveVisible = true;
            this.ucDataButtonStore.Size = new System.Drawing.Size(814, 34);
            this.ucDataButtonStore.TabIndex = 17;
            this.ucDataButtonStore.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStore_InsertHandler);
            this.ucDataButtonStore.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStore_EditHandler);
            this.ucDataButtonStore.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStore_SaveHandler);
            this.ucDataButtonStore.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStore_DeleteHandler);
            this.ucDataButtonStore.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStore_CancelHandler);
            this.ucDataButtonStore.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStore_CloseHandler);
            // 
            // frmDacDistributeToStore
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(814, 580);
            this.Controls.Add(this.groupBoxProduct);
            this.Controls.Add(this.ucDataButtonStore);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDacDistributeToStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân phối hàng hóa đến cửa hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDacDistributeToStore_FormClosing);
            this.Load += new System.EventHandler(this.frmDacDistributeToStore_Load);
            this.groupBoxProduct.ResumeLayout(false);
            this.groupBoxProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExport)).EndInit();
            this.panelAddDacCode.ResumeLayout(false);
            this.panelAddDacCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panelDistributeToStore.ResumeLayout(false);
            this.panelDistributeToStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditAgencyView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonStore;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private System.Windows.Forms.Panel panelDistributeToStore;
        private System.Windows.Forms.DateTimePicker dtCreatedDate;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.Label labelAgency;
        private System.Windows.Forms.Panel panelAddDacCode;
        private System.Windows.Forms.TextBox txtDacCode;
        private System.Windows.Forms.Label labelSearchCode;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label labelOrderNumber;
        private System.Windows.Forms.Label lblRealityQuantity;
        private DevExpress.XtraEditors.GridLookUpEdit lueStore;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditAgencyView;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.GridControl gcExport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStoreCode;
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
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAddSerialCode;
        private System.Windows.Forms.TextBox txtToSeri;
        private System.Windows.Forms.TextBox txtFrSeri;
        private System.Windows.Forms.Label ToSeriLabel;
        private System.Windows.Forms.Label FrSeriLabel;
        private DevExpress.XtraEditors.GridLookUpEdit lueProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.GridLookUpEdit lueStock;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private System.Windows.Forms.Label labelDacStock;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStockID;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TextBox txtDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDacCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private System.Windows.Forms.CheckBox chkActive;
    }
}