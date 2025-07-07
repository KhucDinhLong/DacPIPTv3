namespace PIPT
{
    partial class frmDacPackage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacPackage));
            this.groupBoxPackage = new System.Windows.Forms.GroupBox();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDacCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPackage = new DevExpress.XtraGrid.GridControl();
            this.gvPackage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPackageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelAddDacCode = new System.Windows.Forms.Panel();
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
            this.panelPackage = new System.Windows.Forms.Panel();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.dtpNgaySX = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAutoPrintStamp = new System.Windows.Forms.CheckBox();
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersonPackaged = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPreview = new DevExpress.XtraEditors.CheckEdit();
            this.chkKeepProduct = new DevExpress.XtraEditors.CheckEdit();
            this.lueProduct = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditProductView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPackageCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelPackageCode = new System.Windows.Forms.Label();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.ucDataButtonPackage = new PIPT.ucDataButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBoxPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPackage)).BeginInit();
            this.panelAddDacCode.SuspendLayout();
            this.panelPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreview.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKeepProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProductView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPackage
            // 
            this.groupBoxPackage.Controls.Add(this.gcDetail);
            this.groupBoxPackage.Controls.Add(this.gcPackage);
            this.groupBoxPackage.Controls.Add(this.panelAddDacCode);
            this.groupBoxPackage.Controls.Add(this.panelPackage);
            this.groupBoxPackage.Controls.Add(this.lblProductCount);
            this.groupBoxPackage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPackage.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPackage.Name = "groupBoxPackage";
            this.groupBoxPackage.Size = new System.Drawing.Size(730, 546);
            this.groupBoxPackage.TabIndex = 1;
            this.groupBoxPackage.TabStop = false;
            this.groupBoxPackage.Text = "Thông tin thùng hàng";
            // 
            // gcDetail
            // 
            this.gcDetail.Location = new System.Drawing.Point(417, 113);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.Size = new System.Drawing.Size(310, 411);
            this.gcDetail.TabIndex = 14;
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
            this.gvDetail.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gvDetail.OptionsSelection.MultiSelect = true;
            this.gvDetail.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "ID";
            this.colId.MaxWidth = 50;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 1;
            this.colId.Width = 50;
            // 
            // colDacCode
            // 
            this.colDacCode.Caption = "Mã QR";
            this.colDacCode.FieldName = "DacCode";
            this.colDacCode.Name = "colDacCode";
            this.colDacCode.Visible = true;
            this.colDacCode.VisibleIndex = 2;
            // 
            // gcPackage
            // 
            this.gcPackage.EmbeddedNavigator.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gcPackage.Location = new System.Drawing.Point(0, 193);
            this.gcPackage.MainView = this.gvPackage;
            this.gcPackage.Name = "gcPackage";
            this.gcPackage.Size = new System.Drawing.Size(410, 331);
            this.gcPackage.TabIndex = 13;
            this.gcPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPackage});
            // 
            // gvPackage
            // 
            this.gvPackage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnPackageCode,
            this.gridColumProductCode,
            this.gridColumnQuantity,
            this.gridColumnCreatedDate,
            this.gridColumActive,
            this.gridColumnDescription});
            this.gvPackage.GridControl = this.gcPackage;
            this.gvPackage.Name = "gvPackage";
            this.gvPackage.OptionsBehavior.Editable = false;
            this.gvPackage.OptionsDetail.EnableMasterViewMode = false;
            this.gvPackage.OptionsView.ShowAutoFilterRow = true;
            this.gvPackage.OptionsView.ShowDetailButtons = false;
            this.gvPackage.OptionsView.ShowGroupPanel = false;
            this.gvPackage.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewPackage_FocusedRowChanged);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            // 
            // gridColumnPackageCode
            // 
            this.gridColumnPackageCode.Caption = "Mã thùng";
            this.gridColumnPackageCode.FieldName = "PackageCode";
            this.gridColumnPackageCode.Name = "gridColumnPackageCode";
            this.gridColumnPackageCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnPackageCode.Visible = true;
            this.gridColumnPackageCode.VisibleIndex = 1;
            this.gridColumnPackageCode.Width = 118;
            // 
            // gridColumProductCode
            // 
            this.gridColumProductCode.Caption = "Mã SP";
            this.gridColumProductCode.FieldName = "ProductCode";
            this.gridColumProductCode.Name = "gridColumProductCode";
            this.gridColumProductCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumProductCode.Visible = true;
            this.gridColumProductCode.VisibleIndex = 2;
            this.gridColumProductCode.Width = 71;
            // 
            // gridColumnQuantity
            // 
            this.gridColumnQuantity.Caption = "Số lượng";
            this.gridColumnQuantity.FieldName = "Quantity";
            this.gridColumnQuantity.Name = "gridColumnQuantity";
            this.gridColumnQuantity.Visible = true;
            this.gridColumnQuantity.VisibleIndex = 3;
            this.gridColumnQuantity.Width = 50;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Ngày tạo";
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 4;
            this.gridColumnCreatedDate.Width = 69;
            // 
            // gridColumActive
            // 
            this.gridColumActive.Caption = "Active";
            this.gridColumActive.FieldName = "Active";
            this.gridColumActive.Name = "gridColumActive";
            this.gridColumActive.Visible = true;
            this.gridColumActive.VisibleIndex = 5;
            this.gridColumActive.Width = 42;
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
            this.panelAddDacCode.Controls.Add(this.btnDetailDelete);
            this.panelAddDacCode.Controls.Add(this.btnUpdateDetail);
            this.panelAddDacCode.Controls.Add(this.btnEnter);
            this.panelAddDacCode.Controls.Add(this.txtDacCode);
            this.panelAddDacCode.Controls.Add(this.ToSeriLabel);
            this.panelAddDacCode.Controls.Add(this.FrSeriLabel);
            this.panelAddDacCode.Controls.Add(this.labelSearchCode);
            this.panelAddDacCode.Location = new System.Drawing.Point(419, 14);
            this.panelAddDacCode.Name = "panelAddDacCode";
            this.panelAddDacCode.Size = new System.Drawing.Size(308, 92);
            this.panelAddDacCode.TabIndex = 10;
            // 
            // btnAddSerialCode
            // 
            this.btnAddSerialCode.Location = new System.Drawing.Point(270, 38);
            this.btnAddSerialCode.Name = "btnAddSerialCode";
            this.btnAddSerialCode.Size = new System.Drawing.Size(35, 23);
            this.btnAddSerialCode.TabIndex = 18;
            this.btnAddSerialCode.Text = "+";
            this.btnAddSerialCode.UseVisualStyleBackColor = true;
            this.btnAddSerialCode.Click += new System.EventHandler(this.addSerialCodeButton_Click);
            // 
            // txtToSeri
            // 
            this.txtToSeri.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToSeri.Location = new System.Drawing.Point(172, 38);
            this.txtToSeri.Name = "txtToSeri";
            this.txtToSeri.Size = new System.Drawing.Size(90, 23);
            this.txtToSeri.TabIndex = 17;
            this.txtToSeri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToSeri_KeyPress);
            // 
            // txtFrSeri
            // 
            this.txtFrSeri.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrSeri.Location = new System.Drawing.Point(50, 38);
            this.txtFrSeri.Name = "txtFrSeri";
            this.txtFrSeri.Size = new System.Drawing.Size(90, 23);
            this.txtFrSeri.TabIndex = 16;
            this.txtFrSeri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrSeri_KeyPress);
            // 
            // btnDetailDelete
            // 
            this.btnDetailDelete.Image = global::PIPT.Properties.Resources.Delete1616;
            this.btnDetailDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailDelete.Location = new System.Drawing.Point(200, 67);
            this.btnDetailDelete.Name = "btnDetailDelete";
            this.btnDetailDelete.Size = new System.Drawing.Size(105, 24);
            this.btnDetailDelete.TabIndex = 20;
            this.btnDetailDelete.Text = "Xóa QRCode";
            this.btnDetailDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetailDelete.UseVisualStyleBackColor = true;
            this.btnDetailDelete.Click += new System.EventHandler(this.buttonDetailDelete_Click);
            // 
            // btnUpdateDetail
            // 
            this.btnUpdateDetail.Image = global::PIPT.Properties.Resources.update1616;
            this.btnUpdateDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateDetail.Location = new System.Drawing.Point(50, 67);
            this.btnUpdateDetail.Name = "btnUpdateDetail";
            this.btnUpdateDetail.Size = new System.Drawing.Size(84, 24);
            this.btnUpdateDetail.TabIndex = 19;
            this.btnUpdateDetail.Text = "Cập nhật";
            this.btnUpdateDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateDetail.UseVisualStyleBackColor = true;
            this.btnUpdateDetail.Click += new System.EventHandler(this.buttonUpdateDetail_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Image = global::PIPT.Properties.Resources.submit1616;
            this.btnEnter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnter.Location = new System.Drawing.Point(243, 7);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(62, 28);
            this.btnEnter.TabIndex = 15;
            this.btnEnter.Text = "Nhận";
            this.btnEnter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // txtDacCode
            // 
            this.txtDacCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDacCode.Location = new System.Drawing.Point(110, 10);
            this.txtDacCode.Name = "txtDacCode";
            this.txtDacCode.Size = new System.Drawing.Size(127, 23);
            this.txtDacCode.TabIndex = 14;
            this.txtDacCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDacCode_KeyPress);
            // 
            // ToSeriLabel
            // 
            this.ToSeriLabel.AutoSize = true;
            this.ToSeriLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToSeriLabel.Location = new System.Drawing.Point(143, 43);
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
            this.labelSearchCode.Location = new System.Drawing.Point(3, 14);
            this.labelSearchCode.Name = "labelSearchCode";
            this.labelSearchCode.Size = new System.Drawing.Size(101, 13);
            this.labelSearchCode.TabIndex = 4;
            this.labelSearchCode.Text = "Quét mã hoặc nhập";
            // 
            // panelPackage
            // 
            this.panelPackage.Controls.Add(this.txtQuantity);
            this.panelPackage.Controls.Add(this.dtpNgaySX);
            this.panelPackage.Controls.Add(this.label4);
            this.panelPackage.Controls.Add(this.chkAutoPrintStamp);
            this.panelPackage.Controls.Add(this.txtFactory);
            this.panelPackage.Controls.Add(this.txtBatch);
            this.panelPackage.Controls.Add(this.label3);
            this.panelPackage.Controls.Add(this.txtPersonPackaged);
            this.panelPackage.Controls.Add(this.label2);
            this.panelPackage.Controls.Add(this.label1);
            this.panelPackage.Controls.Add(this.chkPreview);
            this.panelPackage.Controls.Add(this.chkKeepProduct);
            this.panelPackage.Controls.Add(this.lueProduct);
            this.panelPackage.Controls.Add(this.txtPackageCode);
            this.panelPackage.Controls.Add(this.txtDescription);
            this.panelPackage.Controls.Add(this.dtpCreatedDate);
            this.panelPackage.Controls.Add(this.labelDescription);
            this.panelPackage.Controls.Add(this.labelProduct);
            this.panelPackage.Controls.Add(this.labelCreatedDate);
            this.panelPackage.Controls.Add(this.labelQuantity);
            this.panelPackage.Controls.Add(this.labelPackageCode);
            this.panelPackage.Location = new System.Drawing.Point(3, 14);
            this.panelPackage.Name = "panelPackage";
            this.panelPackage.Size = new System.Drawing.Size(410, 173);
            this.panelPackage.TabIndex = 9;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(72, 64);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 21);
            this.txtQuantity.TabIndex = 20;
            // 
            // dtpNgaySX
            // 
            this.dtpNgaySX.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySX.Location = new System.Drawing.Point(102, 145);
            this.dtpNgaySX.Name = "dtpNgaySX";
            this.dtpNgaySX.Size = new System.Drawing.Size(105, 21);
            this.dtpNgaySX.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Ngày sản xuất:";
            // 
            // chkAutoPrintStamp
            // 
            this.chkAutoPrintStamp.AutoSize = true;
            this.chkAutoPrintStamp.Location = new System.Drawing.Point(215, 147);
            this.chkAutoPrintStamp.Name = "chkAutoPrintStamp";
            this.chkAutoPrintStamp.Size = new System.Drawing.Size(98, 17);
            this.chkAutoPrintStamp.TabIndex = 11;
            this.chkAutoPrintStamp.Text = "In tem tự động";
            this.chkAutoPrintStamp.UseVisualStyleBackColor = true;
            this.chkAutoPrintStamp.CheckedChanged += new System.EventHandler(this.chkAutoPrintStamp_CheckedChanged);
            // 
            // txtFactory
            // 
            this.txtFactory.Location = new System.Drawing.Point(72, 91);
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Size = new System.Drawing.Size(80, 21);
            this.txtFactory.TabIndex = 7;
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(319, 12);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(80, 21);
            this.txtBatch.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Số lô";
            // 
            // txtPersonPackaged
            // 
            this.txtPersonPackaged.Location = new System.Drawing.Point(245, 67);
            this.txtPersonPackaged.Name = "txtPersonPackaged";
            this.txtPersonPackaged.Size = new System.Drawing.Size(162, 21);
            this.txtPersonPackaged.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Người đóng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nhà máy";
            // 
            // chkPreview
            // 
            this.chkPreview.Location = new System.Drawing.Point(334, 145);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Properties.Caption = "Xem trước";
            this.chkPreview.Size = new System.Drawing.Size(73, 19);
            this.chkPreview.TabIndex = 12;
            // 
            // chkKeepProduct
            // 
            this.chkKeepProduct.Location = new System.Drawing.Point(187, 12);
            this.chkKeepProduct.Name = "chkKeepProduct";
            this.chkKeepProduct.Properties.Caption = "Giữ sản phẩm";
            this.chkKeepProduct.Size = new System.Drawing.Size(90, 19);
            this.chkKeepProduct.TabIndex = 2;
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
            this.lueProduct.Size = new System.Drawing.Size(335, 20);
            this.lueProduct.TabIndex = 4;
            this.lueProduct.EditValueChanged += new System.EventHandler(this.lueProduct_EditValueChanged);
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
            // txtPackageCode
            // 
            this.txtPackageCode.Location = new System.Drawing.Point(72, 11);
            this.txtPackageCode.Name = "txtPackageCode";
            this.txtPackageCode.Size = new System.Drawing.Size(109, 21);
            this.txtPackageCode.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(245, 105);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(162, 38);
            this.txtDescription.TabIndex = 9;
            this.txtDescription.Text = "";
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedDate.Location = new System.Drawing.Point(72, 118);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(109, 21);
            this.dtpCreatedDate.TabIndex = 8;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(197, 105);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ghi chú";
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(12, 41);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(54, 13);
            this.labelProduct.TabIndex = 4;
            this.labelProduct.Text = "Sản phẩm";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(15, 124);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(17, 67);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(49, 13);
            this.labelQuantity.TabIndex = 4;
            this.labelQuantity.Text = "Số lượng";
            // 
            // labelPackageCode
            // 
            this.labelPackageCode.AutoSize = true;
            this.labelPackageCode.Location = new System.Drawing.Point(14, 15);
            this.labelPackageCode.Name = "labelPackageCode";
            this.labelPackageCode.Size = new System.Drawing.Size(52, 13);
            this.labelPackageCode.TabIndex = 4;
            this.labelPackageCode.Text = "Mã thùng";
            // 
            // lblProductCount
            // 
            this.lblProductCount.AutoSize = true;
            this.lblProductCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCount.Location = new System.Drawing.Point(422, 527);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(132, 13);
            this.lblProductCount.TabIndex = 4;
            this.lblProductCount.Text = "Số sản phẩm đã thêm:";
            // 
            // ucDataButtonPackage
            // 
            this.ucDataButtonPackage.AddNewVisible = true;
            this.ucDataButtonPackage.CancelVisible = true;
            this.ucDataButtonPackage.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonPackage.DeleteVisible = true;
            this.ucDataButtonPackage.EditVisible = true;
            this.ucDataButtonPackage.ExcelVisible = false;
            this.ucDataButtonPackage.IsContitnue = true;
            this.ucDataButtonPackage.LanguageVisible = false;
            this.ucDataButtonPackage.Location = new System.Drawing.Point(0, 546);
            this.ucDataButtonPackage.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonPackage.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonPackage.MultiLanguageVisible = false;
            this.ucDataButtonPackage.Name = "ucDataButtonPackage";
            this.ucDataButtonPackage.PrintVisible = true;
            this.ucDataButtonPackage.ReportVisible = false;
            this.ucDataButtonPackage.SaveVisible = true;
            this.ucDataButtonPackage.Size = new System.Drawing.Size(730, 34);
            this.ucDataButtonPackage.TabIndex = 22;
            this.ucDataButtonPackage.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonPackage_InsertHandler);
            this.ucDataButtonPackage.PrintHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonPackage_PrintHandler);
            this.ucDataButtonPackage.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonPackage_EditHandler);
            this.ucDataButtonPackage.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonPackage_SaveHandler);
            this.ucDataButtonPackage.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonPackage_DeleteHandler);
            this.ucDataButtonPackage.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonPackage_CancelHandler);
            this.ucDataButtonPackage.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonPackage_CloseHandler);
            // 
            // btnStart
            // 
            this.btnStart.Image = global::PIPT.Properties.Resources.Button_Play_icon_16x16;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(12, 552);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(84, 24);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // frmDacPackage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(730, 580);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBoxPackage);
            this.Controls.Add(this.ucDataButtonPackage);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDacPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin đóng thùng sản phẩm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDacPackage_FormClosing);
            this.Load += new System.EventHandler(this.frmDacPackage_Load);
            this.groupBoxPackage.ResumeLayout(false);
            this.groupBoxPackage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPackage)).EndInit();
            this.panelAddDacCode.ResumeLayout(false);
            this.panelAddDacCode.PerformLayout();
            this.panelPackage.ResumeLayout(false);
            this.panelPackage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreview.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKeepProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProductView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonPackage;
        private System.Windows.Forms.GroupBox groupBoxPackage;
        private System.Windows.Forms.Panel panelPackage;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpCreatedDate;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.Panel panelAddDacCode;
        private System.Windows.Forms.TextBox txtDacCode;
        private System.Windows.Forms.Label labelSearchCode;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtPackageCode;
        private System.Windows.Forms.Label labelPackageCode;
        private System.Windows.Forms.Label lblProductCount;
        private DevExpress.XtraEditors.GridLookUpEdit lueProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditProductView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColName;
        private DevExpress.XtraGrid.GridControl gcPackage;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPackage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPackageCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumActive;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantity;
        private DevExpress.XtraEditors.CheckEdit chkKeepProduct;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Button btnDetailDelete;
        private System.Windows.Forms.Button btnUpdateDetail;
        private System.Windows.Forms.Button btnAddSerialCode;
        private System.Windows.Forms.TextBox txtToSeri;
        private System.Windows.Forms.TextBox txtFrSeri;
        private System.Windows.Forms.Label ToSeriLabel;
        private System.Windows.Forms.Label FrSeriLabel;
        private DevExpress.XtraEditors.CheckEdit chkPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersonPackaged;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFactory;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkAutoPrintStamp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private System.Windows.Forms.DateTimePicker dtpNgaySX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuantity;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDacCode;
    }
}