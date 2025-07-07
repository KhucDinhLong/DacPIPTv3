namespace PIPT
{
    partial class frmDacProductWarehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacProductWarehouse));
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDacCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkPrintType = new System.Windows.Forms.CheckBox();
            this.gcWarehouse = new DevExpress.XtraGrid.GridControl();
            this.gvWarehouse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelAddDacCode = new System.Windows.Forms.Panel();
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
            this.panelInsertToWarehouse = new System.Windows.Forms.Panel();
            this.lueDacStock = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelDacStock = new System.Windows.Forms.Label();
            this.lueProduct = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditProductView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelOrderNumber = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.ucDataButtonWarehouse = new PIPT.ucDataButton();
            this.groupBoxProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWarehouse)).BeginInit();
            this.panelAddDacCode.SuspendLayout();
            this.panelInsertToWarehouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDacStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProductView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Controls.Add(this.gcDetail);
            this.groupBoxProduct.Controls.Add(this.chkPrintType);
            this.groupBoxProduct.Controls.Add(this.gcWarehouse);
            this.groupBoxProduct.Controls.Add(this.panelAddDacCode);
            this.groupBoxProduct.Controls.Add(this.panelInsertToWarehouse);
            this.groupBoxProduct.Controls.Add(this.lblQuantity);
            this.groupBoxProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProduct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProduct.Location = new System.Drawing.Point(0, 0);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Size = new System.Drawing.Size(804, 545);
            this.groupBoxProduct.TabIndex = 3;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "Nhập sản phẩm vào kho";
            // 
            // gcDetail
            // 
            this.gcDetail.Location = new System.Drawing.Point(492, 118);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.Size = new System.Drawing.Size(300, 405);
            this.gcDetail.TabIndex = 16;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colDacCode});
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsSelection.MultiSelect = true;
            this.gvDetail.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "ID";
            this.colId.Name = "colId";
            // 
            // colDacCode
            // 
            this.colDacCode.Caption = "QR code";
            this.colDacCode.FieldName = "DacCode";
            this.colDacCode.Name = "colDacCode";
            this.colDacCode.Visible = true;
            this.colDacCode.VisibleIndex = 1;
            // 
            // chkPrintType
            // 
            this.chkPrintType.AutoSize = true;
            this.chkPrintType.Checked = true;
            this.chkPrintType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrintType.Location = new System.Drawing.Point(6, 158);
            this.chkPrintType.Name = "chkPrintType";
            this.chkPrintType.Size = new System.Drawing.Size(78, 17);
            this.chkPrintType.TabIndex = 15;
            this.chkPrintType.Text = "In theo SL ";
            this.chkPrintType.UseVisualStyleBackColor = true;
            // 
            // gcWarehouse
            // 
            this.gcWarehouse.EmbeddedNavigator.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gcWarehouse.Location = new System.Drawing.Point(6, 181);
            this.gcWarehouse.MainView = this.gvWarehouse;
            this.gcWarehouse.Name = "gcWarehouse";
            this.gcWarehouse.Size = new System.Drawing.Size(479, 358);
            this.gcWarehouse.TabIndex = 12;
            this.gcWarehouse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWarehouse});
            // 
            // gvWarehouse
            // 
            this.gvWarehouse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnOrder,
            this.gridColumProductCode,
            this.gridColumnStockID,
            this.gridColumnQuantity,
            this.gridColumnCreatedDate,
            this.gridColumActive,
            this.gridColumnDescription});
            this.gvWarehouse.GridControl = this.gcWarehouse;
            this.gvWarehouse.Name = "gvWarehouse";
            this.gvWarehouse.OptionsBehavior.Editable = false;
            this.gvWarehouse.OptionsView.ShowAutoFilterRow = true;
            this.gvWarehouse.OptionsView.ShowDetailButtons = false;
            this.gvWarehouse.OptionsView.ShowGroupPanel = false;
            this.gvWarehouse.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvWarehouse_FocusedRowChanged);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            this.gridColumnID.Width = 47;
            // 
            // gridColumnOrder
            // 
            this.gridColumnOrder.Caption = "Mã Nhập";
            this.gridColumnOrder.FieldName = "InsertNumber";
            this.gridColumnOrder.Name = "gridColumnOrder";
            this.gridColumnOrder.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnOrder.Visible = true;
            this.gridColumnOrder.VisibleIndex = 1;
            this.gridColumnOrder.Width = 60;
            // 
            // gridColumProductCode
            // 
            this.gridColumProductCode.Caption = "Mã SP";
            this.gridColumProductCode.FieldName = "ProductCode";
            this.gridColumProductCode.Name = "gridColumProductCode";
            this.gridColumProductCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumProductCode.Visible = true;
            this.gridColumProductCode.VisibleIndex = 2;
            this.gridColumProductCode.Width = 80;
            // 
            // gridColumnStockID
            // 
            this.gridColumnStockID.Caption = "Mã kho";
            this.gridColumnStockID.FieldName = "StockID";
            this.gridColumnStockID.Name = "gridColumnStockID";
            this.gridColumnStockID.Visible = true;
            this.gridColumnStockID.VisibleIndex = 3;
            this.gridColumnStockID.Width = 63;
            // 
            // gridColumnQuantity
            // 
            this.gridColumnQuantity.Caption = "Số lượng";
            this.gridColumnQuantity.FieldName = "Quantity";
            this.gridColumnQuantity.Name = "gridColumnQuantity";
            this.gridColumnQuantity.Visible = true;
            this.gridColumnQuantity.VisibleIndex = 4;
            this.gridColumnQuantity.Width = 83;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Ngày tạo";
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 5;
            this.gridColumnCreatedDate.Width = 77;
            // 
            // gridColumActive
            // 
            this.gridColumActive.Caption = "Active";
            this.gridColumActive.FieldName = "Active";
            this.gridColumActive.Name = "gridColumActive";
            this.gridColumActive.Visible = true;
            this.gridColumActive.VisibleIndex = 6;
            this.gridColumActive.Width = 51;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Description";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            // 
            // panelAddDacCode
            // 
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
            this.panelAddDacCode.Location = new System.Drawing.Point(491, 14);
            this.panelAddDacCode.Name = "panelAddDacCode";
            this.panelAddDacCode.Size = new System.Drawing.Size(306, 97);
            this.panelAddDacCode.TabIndex = 10;
            // 
            // btnAddSerialCode
            // 
            this.btnAddSerialCode.Location = new System.Drawing.Point(271, 41);
            this.btnAddSerialCode.Name = "btnAddSerialCode";
            this.btnAddSerialCode.Size = new System.Drawing.Size(35, 23);
            this.btnAddSerialCode.TabIndex = 8;
            this.btnAddSerialCode.Text = "+";
            this.btnAddSerialCode.UseVisualStyleBackColor = true;
            this.btnAddSerialCode.Click += new System.EventHandler(this.btnAddSerialCode_Click);
            // 
            // txtToSeri
            // 
            this.txtToSeri.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToSeri.Location = new System.Drawing.Point(173, 41);
            this.txtToSeri.Name = "txtToSeri";
            this.txtToSeri.Size = new System.Drawing.Size(85, 23);
            this.txtToSeri.TabIndex = 7;
            this.txtToSeri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToSeri_KeyPress);
            // 
            // txtFrSeri
            // 
            this.txtFrSeri.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrSeri.Location = new System.Drawing.Point(51, 41);
            this.txtFrSeri.Name = "txtFrSeri";
            this.txtFrSeri.Size = new System.Drawing.Size(85, 23);
            this.txtFrSeri.TabIndex = 6;
            this.txtFrSeri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrSeri_KeyPress);
            // 
            // ToSeriLabel
            // 
            this.ToSeriLabel.AutoSize = true;
            this.ToSeriLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToSeriLabel.Location = new System.Drawing.Point(142, 46);
            this.ToSeriLabel.Name = "ToSeriLabel";
            this.ToSeriLabel.Size = new System.Drawing.Size(25, 13);
            this.ToSeriLabel.TabIndex = 9;
            this.ToSeriLabel.Text = "=>";
            // 
            // FrSeriLabel
            // 
            this.FrSeriLabel.AutoSize = true;
            this.FrSeriLabel.Location = new System.Drawing.Point(4, 46);
            this.FrSeriLabel.Name = "FrSeriLabel";
            this.FrSeriLabel.Size = new System.Drawing.Size(41, 13);
            this.FrSeriLabel.TabIndex = 10;
            this.FrSeriLabel.Text = "Từ Seri";
            // 
            // btnDetailDelete
            // 
            this.btnDetailDelete.Image = global::PIPT.Properties.Resources.Delete1616;
            this.btnDetailDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailDelete.Location = new System.Drawing.Point(201, 70);
            this.btnDetailDelete.Name = "btnDetailDelete";
            this.btnDetailDelete.Size = new System.Drawing.Size(105, 24);
            this.btnDetailDelete.TabIndex = 5;
            this.btnDetailDelete.Text = "Xóa QRCode";
            this.btnDetailDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetailDelete.UseVisualStyleBackColor = true;
            this.btnDetailDelete.Click += new System.EventHandler(this.btnDetailDelete_Click);
            // 
            // btnUpdateDetail
            // 
            this.btnUpdateDetail.Image = global::PIPT.Properties.Resources.update1616;
            this.btnUpdateDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateDetail.Location = new System.Drawing.Point(51, 70);
            this.btnUpdateDetail.Name = "btnUpdateDetail";
            this.btnUpdateDetail.Size = new System.Drawing.Size(84, 24);
            this.btnUpdateDetail.TabIndex = 5;
            this.btnUpdateDetail.Text = "Cập nhật";
            this.btnUpdateDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateDetail.UseVisualStyleBackColor = true;
            this.btnUpdateDetail.Click += new System.EventHandler(this.btnUpdateDetail_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Image = global::PIPT.Properties.Resources.submit1616;
            this.btnEnter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnter.Location = new System.Drawing.Point(244, 7);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(62, 28);
            this.btnEnter.TabIndex = 5;
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
            this.txtDacCode.Size = new System.Drawing.Size(127, 23);
            this.txtDacCode.TabIndex = 0;
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
            // panelInsertToWarehouse
            // 
            this.panelInsertToWarehouse.Controls.Add(this.lueDacStock);
            this.panelInsertToWarehouse.Controls.Add(this.labelDacStock);
            this.panelInsertToWarehouse.Controls.Add(this.lueProduct);
            this.panelInsertToWarehouse.Controls.Add(this.txtQuantity);
            this.panelInsertToWarehouse.Controls.Add(this.txtOrderNumber);
            this.panelInsertToWarehouse.Controls.Add(this.txtDescription);
            this.panelInsertToWarehouse.Controls.Add(this.dtpCreatedDate);
            this.panelInsertToWarehouse.Controls.Add(this.labelDescription);
            this.panelInsertToWarehouse.Controls.Add(this.labelProduct);
            this.panelInsertToWarehouse.Controls.Add(this.labelCreatedDate);
            this.panelInsertToWarehouse.Controls.Add(this.label2);
            this.panelInsertToWarehouse.Controls.Add(this.labelOrderNumber);
            this.panelInsertToWarehouse.Location = new System.Drawing.Point(3, 14);
            this.panelInsertToWarehouse.Name = "panelInsertToWarehouse";
            this.panelInsertToWarehouse.Size = new System.Drawing.Size(482, 138);
            this.panelInsertToWarehouse.TabIndex = 9;
            // 
            // lueDacStock
            // 
            this.lueDacStock.EditValue = "";
            this.lueDacStock.Location = new System.Drawing.Point(322, 12);
            this.lueDacStock.Name = "lueDacStock";
            this.lueDacStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDacStock.Properties.DisplayMember = "Name";
            this.lueDacStock.Properties.ImmediatePopup = true;
            this.lueDacStock.Properties.NullText = "";
            this.lueDacStock.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueDacStock.Properties.PopupView = this.gridView1;
            this.lueDacStock.Properties.ValueMember = "Code";
            this.lueDacStock.Size = new System.Drawing.Size(147, 20);
            this.lueDacStock.TabIndex = 14;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCode,
            this.gridColumnName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            this.labelDacStock.Location = new System.Drawing.Point(264, 15);
            this.labelDacStock.Name = "labelDacStock";
            this.labelDacStock.Size = new System.Drawing.Size(52, 13);
            this.labelDacStock.TabIndex = 13;
            this.labelDacStock.Text = "Chọn kho";
            // 
            // lueProduct
            // 
            this.lueProduct.EditValue = "";
            this.lueProduct.Location = new System.Drawing.Point(72, 38);
            this.lueProduct.Name = "lueProduct";
            this.lueProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProduct.Properties.DisplayMember = "Name";
            this.lueProduct.Properties.ImmediatePopup = true;
            this.lueProduct.Properties.NullText = "";
            this.lueProduct.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueProduct.Properties.PopupView = this.gridLookUpEditProductView;
            this.lueProduct.Properties.ValueMember = "Code";
            this.lueProduct.Size = new System.Drawing.Size(397, 20);
            this.lueProduct.TabIndex = 10;
            // 
            // gridLookUpEditProductView
            // 
            this.gridLookUpEditProductView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColCode,
            this.gridColName});
            this.gridLookUpEditProductView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditProductView.Name = "gridLookUpEditProductView";
            this.gridLookUpEditProductView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditProductView.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditProductView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColCode
            // 
            this.gridColCode.Caption = "Product Code";
            this.gridColCode.FieldName = "Code";
            this.gridColCode.Name = "gridColCode";
            this.gridColCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColCode.Visible = true;
            this.gridColCode.VisibleIndex = 0;
            this.gridColCode.Width = 35;
            // 
            // gridColName
            // 
            this.gridColName.Caption = "Product Name";
            this.gridColName.FieldName = "Name";
            this.gridColName.Name = "gridColName";
            this.gridColName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColName.Visible = true;
            this.gridColName.VisibleIndex = 1;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(72, 64);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(117, 21);
            this.txtQuantity.TabIndex = 9;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(72, 11);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(117, 21);
            this.txtOrderNumber.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(72, 93);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(397, 37);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.Text = "";
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedDate.Location = new System.Drawing.Point(376, 64);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(93, 21);
            this.dtpCreatedDate.TabIndex = 6;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(9, 93);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ghi chú";
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(9, 41);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(54, 13);
            this.labelProduct.TabIndex = 4;
            this.labelProduct.Text = "Sản phẩm";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(319, 67);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số lượng";
            // 
            // labelOrderNumber
            // 
            this.labelOrderNumber.AutoSize = true;
            this.labelOrderNumber.Location = new System.Drawing.Point(9, 14);
            this.labelOrderNumber.Name = "labelOrderNumber";
            this.labelOrderNumber.Size = new System.Drawing.Size(58, 13);
            this.labelOrderNumber.TabIndex = 4;
            this.labelOrderNumber.Text = "Lệnh Nhập";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(494, 526);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(132, 13);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Số sản phẩm đã thêm:";
            // 
            // ucDataButtonWarehouse
            // 
            this.ucDataButtonWarehouse.AddNewVisible = true;
            this.ucDataButtonWarehouse.CancelVisible = true;
            this.ucDataButtonWarehouse.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonWarehouse.DeleteVisible = true;
            this.ucDataButtonWarehouse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonWarehouse.EditVisible = true;
            this.ucDataButtonWarehouse.ExcelVisible = false;
            this.ucDataButtonWarehouse.IsContitnue = true;
            this.ucDataButtonWarehouse.LanguageVisible = false;
            this.ucDataButtonWarehouse.Location = new System.Drawing.Point(0, 545);
            this.ucDataButtonWarehouse.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonWarehouse.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonWarehouse.MultiLanguageVisible = false;
            this.ucDataButtonWarehouse.Name = "ucDataButtonWarehouse";
            this.ucDataButtonWarehouse.PrintVisible = true;
            this.ucDataButtonWarehouse.ReportVisible = false;
            this.ucDataButtonWarehouse.SaveVisible = true;
            this.ucDataButtonWarehouse.Size = new System.Drawing.Size(804, 34);
            this.ucDataButtonWarehouse.TabIndex = 2;
            this.ucDataButtonWarehouse.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonWarehouse_InsertHandler);
            this.ucDataButtonWarehouse.PrintHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonWarehouse_PrintHandler);
            this.ucDataButtonWarehouse.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonWarehouse_EditHandler);
            this.ucDataButtonWarehouse.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonWarehouse_SaveHandler);
            this.ucDataButtonWarehouse.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonWarehouse_DeleteHandler);
            this.ucDataButtonWarehouse.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonWarehouse_CancelHandler);
            this.ucDataButtonWarehouse.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonWarehouse_CloseHandler);
            // 
            // frmDacProductWarehouse
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(804, 579);
            this.Controls.Add(this.groupBoxProduct);
            this.Controls.Add(this.ucDataButtonWarehouse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDacProductWarehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hàng hóa vào kho";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDacProductWarehouse_FormClosing);
            this.Load += new System.EventHandler(this.frmDacProductWarehouse_Load);
            this.groupBoxProduct.ResumeLayout(false);
            this.groupBoxProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWarehouse)).EndInit();
            this.panelAddDacCode.ResumeLayout(false);
            this.panelAddDacCode.PerformLayout();
            this.panelInsertToWarehouse.ResumeLayout(false);
            this.panelInsertToWarehouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDacStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProductView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProduct;
        private DevExpress.XtraGrid.GridControl gcWarehouse;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWarehouse;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumActive;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private System.Windows.Forms.Panel panelAddDacCode;
        private System.Windows.Forms.Button btnDetailDelete;
        private System.Windows.Forms.Button btnUpdateDetail;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtDacCode;
        private System.Windows.Forms.Label labelSearchCode;
        private System.Windows.Forms.Panel panelInsertToWarehouse;
        private DevExpress.XtraEditors.GridLookUpEdit lueProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditProductView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpCreatedDate;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelOrderNumber;
        private System.Windows.Forms.Label lblQuantity;
        private ucDataButton ucDataButtonWarehouse;
        private System.Windows.Forms.Button btnAddSerialCode;
        private System.Windows.Forms.TextBox txtToSeri;
        private System.Windows.Forms.TextBox txtFrSeri;
        private System.Windows.Forms.Label ToSeriLabel;
        private System.Windows.Forms.Label FrSeriLabel;
        private DevExpress.XtraEditors.GridLookUpEdit lueDacStock;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private System.Windows.Forms.Label labelDacStock;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStockID;
        private System.Windows.Forms.CheckBox chkPrintType;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDacCode;
    }
}