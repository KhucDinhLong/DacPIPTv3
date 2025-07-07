namespace PIPT
{
    partial class frmDacStore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacStore));
            this.groupBoxStore = new System.Windows.Forms.GroupBox();
            this.gcStore = new DevExpress.XtraGrid.GridControl();
            this.gvStore = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProvinceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnShopKeeper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMobileNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAgencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifiedUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelSearchAgency = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.panelStore = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblModifiedDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lueAgency = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditViewAgencyCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColAgencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAgencyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueProvince = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditViewProvince = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridLookUpColumnProvinceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpColumnProvinceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtStoreCode = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.labelPhoneNum = new System.Windows.Forms.Label();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.labelMobileNum = new System.Windows.Forms.Label();
            this.txtShopKeeper = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMobileNum = new System.Windows.Forms.TextBox();
            this.labelModifiedDate = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.labelShopKeeper = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ucDataButtonStore = new PIPT.ucDataButton();
            this.groupBoxStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStore)).BeginInit();
            this.panelSearchAgency.SuspendLayout();
            this.panelStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewAgencyCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProvince.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewProvince)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxStore
            // 
            this.groupBoxStore.Controls.Add(this.gcStore);
            this.groupBoxStore.Controls.Add(this.panelSearchAgency);
            this.groupBoxStore.Controls.Add(this.panelStore);
            this.groupBoxStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStore.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStore.Name = "groupBoxStore";
            this.groupBoxStore.Size = new System.Drawing.Size(1078, 478);
            this.groupBoxStore.TabIndex = 1;
            this.groupBoxStore.TabStop = false;
            this.groupBoxStore.Text = "Thông tin khách hàng";
            // 
            // gcStore
            // 
            this.gcStore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcStore.Location = new System.Drawing.Point(3, 158);
            this.gcStore.MainView = this.gvStore;
            this.gcStore.Name = "gcStore";
            this.gcStore.Size = new System.Drawing.Size(1072, 317);
            this.gcStore.TabIndex = 11;
            this.gcStore.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStore});
            // 
            // gvStore
            // 
            this.gvStore.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnCode,
            this.gridColumnName,
            this.gridColumnAddress,
            this.gridColumnProvinceCode,
            this.gridColumnShopKeeper,
            this.gridColumnPhoneNum,
            this.gridColumnMobileNum,
            this.gridColumnEmail,
            this.gridColumnAgencyCode,
            this.gridColumnCreatedUser,
            this.gridColumnCreatedDate,
            this.gridColumnModifiedDate,
            this.gridColumnModifiedUser,
            this.gridColumnDescription,
            this.gridColumnActive});
            this.gvStore.GridControl = this.gcStore;
            this.gvStore.Name = "gvStore";
            this.gvStore.OptionsView.ShowAutoFilterRow = true;
            this.gvStore.OptionsView.ShowDetailButtons = false;
            this.gvStore.OptionsView.ShowGroupPanel = false;
            this.gvStore.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvStore_FocusedRowChanged);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            this.gridColumnID.Width = 34;
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "Mã KH";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 1;
            this.gridColumnCode.Width = 53;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Tên KH";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 2;
            this.gridColumnName.Width = 107;
            // 
            // gridColumnAddress
            // 
            this.gridColumnAddress.Caption = "Địa chỉ";
            this.gridColumnAddress.FieldName = "Address";
            this.gridColumnAddress.Name = "gridColumnAddress";
            this.gridColumnAddress.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnAddress.Visible = true;
            this.gridColumnAddress.VisibleIndex = 3;
            this.gridColumnAddress.Width = 120;
            // 
            // gridColumnProvinceCode
            // 
            this.gridColumnProvinceCode.Caption = "Mã tỉnh";
            this.gridColumnProvinceCode.FieldName = "ProvinceCode";
            this.gridColumnProvinceCode.Name = "gridColumnProvinceCode";
            this.gridColumnProvinceCode.Visible = true;
            this.gridColumnProvinceCode.VisibleIndex = 4;
            this.gridColumnProvinceCode.Width = 50;
            // 
            // gridColumnShopKeeper
            // 
            this.gridColumnShopKeeper.Caption = "Chủ cửa hàng";
            this.gridColumnShopKeeper.FieldName = "ShopKeeper";
            this.gridColumnShopKeeper.Name = "gridColumnShopKeeper";
            this.gridColumnShopKeeper.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnShopKeeper.Visible = true;
            this.gridColumnShopKeeper.VisibleIndex = 5;
            this.gridColumnShopKeeper.Width = 91;
            // 
            // gridColumnPhoneNum
            // 
            this.gridColumnPhoneNum.Caption = "Điện thoại";
            this.gridColumnPhoneNum.FieldName = "PhoneNum";
            this.gridColumnPhoneNum.Name = "gridColumnPhoneNum";
            this.gridColumnPhoneNum.Visible = true;
            this.gridColumnPhoneNum.VisibleIndex = 6;
            this.gridColumnPhoneNum.Width = 98;
            // 
            // gridColumnMobileNum
            // 
            this.gridColumnMobileNum.Caption = "Di động";
            this.gridColumnMobileNum.FieldName = "MobileNum";
            this.gridColumnMobileNum.Name = "gridColumnMobileNum";
            this.gridColumnMobileNum.Visible = true;
            this.gridColumnMobileNum.VisibleIndex = 7;
            this.gridColumnMobileNum.Width = 67;
            // 
            // gridColumnEmail
            // 
            this.gridColumnEmail.Caption = "Email";
            this.gridColumnEmail.FieldName = "Email";
            this.gridColumnEmail.Name = "gridColumnEmail";
            this.gridColumnEmail.Visible = true;
            this.gridColumnEmail.VisibleIndex = 8;
            this.gridColumnEmail.Width = 76;
            // 
            // gridColumnAgencyCode
            // 
            this.gridColumnAgencyCode.Caption = "Mã ĐL phụ thuộc";
            this.gridColumnAgencyCode.FieldName = "AgencyCode";
            this.gridColumnAgencyCode.Name = "gridColumnAgencyCode";
            this.gridColumnAgencyCode.Visible = true;
            this.gridColumnAgencyCode.VisibleIndex = 9;
            this.gridColumnAgencyCode.Width = 55;
            // 
            // gridColumnCreatedUser
            // 
            this.gridColumnCreatedUser.Caption = "Người tạo";
            this.gridColumnCreatedUser.FieldName = "CreatedUser";
            this.gridColumnCreatedUser.Name = "gridColumnCreatedUser";
            this.gridColumnCreatedUser.Visible = true;
            this.gridColumnCreatedUser.VisibleIndex = 10;
            this.gridColumnCreatedUser.Width = 53;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Ngày tạo";
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 11;
            this.gridColumnCreatedDate.Width = 59;
            // 
            // gridColumnModifiedDate
            // 
            this.gridColumnModifiedDate.Caption = "Ngày sửa";
            this.gridColumnModifiedDate.FieldName = "ModifiedDate";
            this.gridColumnModifiedDate.Name = "gridColumnModifiedDate";
            this.gridColumnModifiedDate.Visible = true;
            this.gridColumnModifiedDate.VisibleIndex = 12;
            this.gridColumnModifiedDate.Width = 46;
            // 
            // gridColumnModifiedUser
            // 
            this.gridColumnModifiedUser.Caption = "Người sửa";
            this.gridColumnModifiedUser.FieldName = "ModifiedUser";
            this.gridColumnModifiedUser.Name = "gridColumnModifiedUser";
            this.gridColumnModifiedUser.Visible = true;
            this.gridColumnModifiedUser.VisibleIndex = 13;
            this.gridColumnModifiedUser.Width = 36;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Ghi chú";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 14;
            this.gridColumnDescription.Width = 61;
            // 
            // gridColumnActive
            // 
            this.gridColumnActive.Caption = "Active";
            this.gridColumnActive.FieldName = "Active";
            this.gridColumnActive.Name = "gridColumnActive";
            this.gridColumnActive.Visible = true;
            this.gridColumnActive.VisibleIndex = 15;
            this.gridColumnActive.Width = 48;
            // 
            // panelSearchAgency
            // 
            this.panelSearchAgency.Controls.Add(this.btnImport);
            this.panelSearchAgency.Controls.Add(this.btnPaste);
            this.panelSearchAgency.Location = new System.Drawing.Point(851, 119);
            this.panelSearchAgency.Name = "panelSearchAgency";
            this.panelSearchAgency.Size = new System.Drawing.Size(196, 33);
            this.panelSearchAgency.TabIndex = 10;
            // 
            // btnImport
            // 
            this.btnImport.Image = global::PIPT.Properties.Resources.Excel;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(122, 6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(71, 24);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Image = global::PIPT.Properties.Resources.Excel;
            this.btnPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaste.Location = new System.Drawing.Point(3, 6);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(71, 24);
            this.btnPaste.TabIndex = 3;
            this.btnPaste.Text = "Paste";
            this.btnPaste.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // panelStore
            // 
            this.panelStore.Controls.Add(this.txtDescription);
            this.panelStore.Controls.Add(this.lblModifiedDate);
            this.panelStore.Controls.Add(this.lblCreatedDate);
            this.panelStore.Controls.Add(this.lueAgency);
            this.panelStore.Controls.Add(this.lueProvince);
            this.panelStore.Controls.Add(this.txtStoreCode);
            this.panelStore.Controls.Add(this.chkActive);
            this.panelStore.Controls.Add(this.labelEmail);
            this.panelStore.Controls.Add(this.txtAddress);
            this.panelStore.Controls.Add(this.labelPhoneNum);
            this.panelStore.Controls.Add(this.txtStoreName);
            this.panelStore.Controls.Add(this.labelMobileNum);
            this.panelStore.Controls.Add(this.txtShopKeeper);
            this.panelStore.Controls.Add(this.labelDescription);
            this.panelStore.Controls.Add(this.label4);
            this.panelStore.Controls.Add(this.txtMobileNum);
            this.panelStore.Controls.Add(this.labelModifiedDate);
            this.panelStore.Controls.Add(this.labelCreatedDate);
            this.panelStore.Controls.Add(this.txtPhoneNum);
            this.panelStore.Controls.Add(this.labelShopKeeper);
            this.panelStore.Controls.Add(this.txtEmail);
            this.panelStore.Controls.Add(this.labelName);
            this.panelStore.Controls.Add(this.labelCode);
            this.panelStore.Controls.Add(this.label5);
            this.panelStore.Controls.Add(this.label3);
            this.panelStore.Location = new System.Drawing.Point(3, 20);
            this.panelStore.Name = "panelStore";
            this.panelStore.Size = new System.Drawing.Size(842, 132);
            this.panelStore.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(610, 55);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(229, 21);
            this.txtDescription.TabIndex = 16;
            // 
            // lblModifiedDate
            // 
            this.lblModifiedDate.AutoSize = true;
            this.lblModifiedDate.Location = new System.Drawing.Point(607, 31);
            this.lblModifiedDate.Name = "lblModifiedDate";
            this.lblModifiedDate.Size = new System.Drawing.Size(0, 13);
            this.lblModifiedDate.TabIndex = 15;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(607, 10);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(0, 13);
            this.lblCreatedDate.TabIndex = 14;
            // 
            // lueAgency
            // 
            this.lueAgency.EditValue = "";
            this.lueAgency.Location = new System.Drawing.Point(362, 30);
            this.lueAgency.Name = "lueAgency";
            this.lueAgency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAgency.Properties.DisplayMember = "Name";
            this.lueAgency.Properties.ImmediatePopup = true;
            this.lueAgency.Properties.NullText = "";
            this.lueAgency.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueAgency.Properties.PopupView = this.gridLookUpEditViewAgencyCode;
            this.lueAgency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueAgency.Properties.ValueMember = "Code";
            this.lueAgency.Size = new System.Drawing.Size(168, 20);
            this.lueAgency.TabIndex = 13;
            // 
            // gridLookUpEditViewAgencyCode
            // 
            this.gridLookUpEditViewAgencyCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColAgencyCode,
            this.gridColAgencyName});
            this.gridLookUpEditViewAgencyCode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditViewAgencyCode.Name = "gridLookUpEditViewAgencyCode";
            this.gridLookUpEditViewAgencyCode.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditViewAgencyCode.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditViewAgencyCode.OptionsView.ShowGroupPanel = false;
            // 
            // gridColAgencyCode
            // 
            this.gridColAgencyCode.Caption = "Mã đại lý";
            this.gridColAgencyCode.FieldName = "Code";
            this.gridColAgencyCode.Name = "gridColAgencyCode";
            this.gridColAgencyCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColAgencyCode.Visible = true;
            this.gridColAgencyCode.VisibleIndex = 0;
            this.gridColAgencyCode.Width = 80;
            // 
            // gridColAgencyName
            // 
            this.gridColAgencyName.Caption = "Tên đại lý";
            this.gridColAgencyName.FieldName = "Name";
            this.gridColAgencyName.Name = "gridColAgencyName";
            this.gridColAgencyName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColAgencyName.Visible = true;
            this.gridColAgencyName.VisibleIndex = 1;
            this.gridColAgencyName.Width = 304;
            // 
            // lueProvince
            // 
            this.lueProvince.EditValue = "";
            this.lueProvince.Location = new System.Drawing.Point(64, 84);
            this.lueProvince.Name = "lueProvince";
            this.lueProvince.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProvince.Properties.DisplayMember = "Name";
            this.lueProvince.Properties.ImmediatePopup = true;
            this.lueProvince.Properties.NullText = "";
            this.lueProvince.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueProvince.Properties.PopupView = this.gridLookUpEditViewProvince;
            this.lueProvince.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueProvince.Properties.ValueMember = "Code";
            this.lueProvince.Size = new System.Drawing.Size(142, 20);
            this.lueProvince.TabIndex = 12;
            // 
            // gridLookUpEditViewProvince
            // 
            this.gridLookUpEditViewProvince.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridLookUpColumnProvinceCode,
            this.gridLookUpColumnProvinceName});
            this.gridLookUpEditViewProvince.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditViewProvince.Name = "gridLookUpEditViewProvince";
            this.gridLookUpEditViewProvince.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditViewProvince.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditViewProvince.OptionsView.ShowGroupPanel = false;
            // 
            // gridLookUpColumnProvinceCode
            // 
            this.gridLookUpColumnProvinceCode.Caption = "Mã";
            this.gridLookUpColumnProvinceCode.FieldName = "Code";
            this.gridLookUpColumnProvinceCode.Name = "gridLookUpColumnProvinceCode";
            this.gridLookUpColumnProvinceCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridLookUpColumnProvinceCode.Visible = true;
            this.gridLookUpColumnProvinceCode.VisibleIndex = 0;
            this.gridLookUpColumnProvinceCode.Width = 100;
            // 
            // gridLookUpColumnProvinceName
            // 
            this.gridLookUpColumnProvinceName.Caption = "Tỉnh thành";
            this.gridLookUpColumnProvinceName.FieldName = "Name";
            this.gridLookUpColumnProvinceName.Name = "gridLookUpColumnProvinceName";
            this.gridLookUpColumnProvinceName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridLookUpColumnProvinceName.Visible = true;
            this.gridLookUpColumnProvinceName.VisibleIndex = 1;
            this.gridLookUpColumnProvinceName.Width = 284;
            // 
            // txtStoreCode
            // 
            this.txtStoreCode.Location = new System.Drawing.Point(64, 4);
            this.txtStoreCode.Name = "txtStoreCode";
            this.txtStoreCode.Size = new System.Drawing.Size(100, 21);
            this.txtStoreCode.TabIndex = 0;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(725, 6);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(97, 17);
            this.chkActive.TabIndex = 10;
            this.chkActive.Text = "Còn hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(322, 58);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "E-mail";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(64, 56);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(195, 21);
            this.txtAddress.TabIndex = 2;
            // 
            // labelPhoneNum
            // 
            this.labelPhoneNum.AutoSize = true;
            this.labelPhoneNum.Location = new System.Drawing.Point(300, 86);
            this.labelPhoneNum.Name = "labelPhoneNum";
            this.labelPhoneNum.Size = new System.Drawing.Size(56, 13);
            this.labelPhoneNum.TabIndex = 4;
            this.labelPhoneNum.Text = "Điện thoại";
            // 
            // txtStoreName
            // 
            this.txtStoreName.Location = new System.Drawing.Point(64, 30);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(195, 21);
            this.txtStoreName.TabIndex = 1;
            // 
            // labelMobileNum
            // 
            this.labelMobileNum.AutoSize = true;
            this.labelMobileNum.Location = new System.Drawing.Point(558, 85);
            this.labelMobileNum.Name = "labelMobileNum";
            this.labelMobileNum.Size = new System.Drawing.Size(43, 13);
            this.labelMobileNum.TabIndex = 4;
            this.labelMobileNum.Text = "Di động";
            // 
            // txtShopKeeper
            // 
            this.txtShopKeeper.Location = new System.Drawing.Point(362, 4);
            this.txtShopKeeper.Name = "txtShopKeeper";
            this.txtShopKeeper.Size = new System.Drawing.Size(126, 21);
            this.txtShopKeeper.TabIndex = 4;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(559, 58);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ghi chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đại lý cấp trên";
            // 
            // txtMobileNum
            // 
            this.txtMobileNum.Location = new System.Drawing.Point(610, 82);
            this.txtMobileNum.Name = "txtMobileNum";
            this.txtMobileNum.Size = new System.Drawing.Size(108, 21);
            this.txtMobileNum.TabIndex = 6;
            // 
            // labelModifiedDate
            // 
            this.labelModifiedDate.AutoSize = true;
            this.labelModifiedDate.Location = new System.Drawing.Point(536, 31);
            this.labelModifiedDate.Name = "labelModifiedDate";
            this.labelModifiedDate.Size = new System.Drawing.Size(65, 13);
            this.labelModifiedDate.TabIndex = 4;
            this.labelModifiedDate.Text = "Sửa lần cuối";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(550, 7);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(362, 83);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(126, 21);
            this.txtPhoneNum.TabIndex = 5;
            // 
            // labelShopKeeper
            // 
            this.labelShopKeeper.AutoSize = true;
            this.labelShopKeeper.Location = new System.Drawing.Point(279, 7);
            this.labelShopKeeper.Name = "labelShopKeeper";
            this.labelShopKeeper.Size = new System.Drawing.Size(77, 13);
            this.labelShopKeeper.TabIndex = 4;
            this.labelShopKeeper.Text = "Chủ nhà thuốc";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(362, 55);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(126, 21);
            this.txtEmail.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(16, 33);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Tên KH";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(21, 7);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(37, 13);
            this.labelCode.TabIndex = 4;
            this.labelCode.Text = "Mã KH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tỉnh / TP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa chỉ";
            // 
            // ucDataButtonStore
            // 
            this.ucDataButtonStore.AddNewVisible = true;
            this.ucDataButtonStore.CancelVisible = true;
            this.ucDataButtonStore.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonStore.DeleteVisible = true;
            this.ucDataButtonStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonStore.EditVisible = true;
            this.ucDataButtonStore.ExcelVisible = true;
            this.ucDataButtonStore.IsContitnue = true;
            this.ucDataButtonStore.LanguageVisible = false;
            this.ucDataButtonStore.Location = new System.Drawing.Point(0, 478);
            this.ucDataButtonStore.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonStore.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonStore.MultiLanguageVisible = false;
            this.ucDataButtonStore.Name = "ucDataButtonStore";
            this.ucDataButtonStore.PrintVisible = false;
            this.ucDataButtonStore.ReportVisible = false;
            this.ucDataButtonStore.SaveVisible = true;
            this.ucDataButtonStore.Size = new System.Drawing.Size(1078, 34);
            this.ucDataButtonStore.TabIndex = 0;
            this.ucDataButtonStore.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_InsertHandler);
            this.ucDataButtonStore.ExcelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_ExcelHandler);
            this.ucDataButtonStore.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_EditHandler);
            this.ucDataButtonStore.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_SaveHandler);
            this.ucDataButtonStore.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_DeleteHandler);
            this.ucDataButtonStore.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_CancelHandler);
            this.ucDataButtonStore.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_CloseHandler);
            // 
            // frmDacStore
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1078, 512);
            this.Controls.Add(this.groupBoxStore);
            this.Controls.Add(this.ucDataButtonStore);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDacStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục nhà thuốc / cửa hàng";
            this.Load += new System.EventHandler(this.frmDacStore_Load);
            this.groupBoxStore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStore)).EndInit();
            this.panelSearchAgency.ResumeLayout(false);
            this.panelStore.ResumeLayout(false);
            this.panelStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewAgencyCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProvince.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewProvince)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonStore;
        private System.Windows.Forms.GroupBox groupBoxStore;
        private System.Windows.Forms.Panel panelStore;
        private System.Windows.Forms.TextBox txtStoreCode;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label labelPhoneNum;
        private System.Windows.Forms.TextBox txtStoreName;
        private System.Windows.Forms.Label labelMobileNum;
        private System.Windows.Forms.TextBox txtShopKeeper;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox txtMobileNum;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.Label labelShopKeeper;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelSearchAgency;
        private System.Windows.Forms.Button btnPaste;
        private DevExpress.XtraGrid.GridControl gcStore;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStore;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProvinceCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnShopKeeper;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPhoneNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAgencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifiedUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActive;
        private DevExpress.XtraEditors.GridLookUpEdit lueProvince;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditViewProvince;
        private DevExpress.XtraGrid.Columns.GridColumn gridLookUpColumnProvinceCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridLookUpColumnProvinceName;
        private System.Windows.Forms.Label labelModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMobileNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmail;
        private DevExpress.XtraEditors.GridLookUpEdit lueAgency;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditViewAgencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAgencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAgencyName;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblModifiedDate;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.TextBox txtDescription;
    }
}