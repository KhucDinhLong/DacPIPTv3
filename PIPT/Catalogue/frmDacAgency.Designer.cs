namespace PIPT
{
    partial class frmDacAgency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacAgency));
            this.groupBoxStore = new System.Windows.Forms.GroupBox();
            this.gcAgency = new DevExpress.XtraGrid.GridControl();
            this.gvAgency = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProvinceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnJoinContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTaxCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMobileNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDependCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRegion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifiedUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelSearchAgency = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.panelAgency = new System.Windows.Forms.Panel();
            this.lblModifiedDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lueAgency = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueProvince = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditViewProvince = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridLookUpColumnProvinceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpColumnProvinceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueRegion = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditViewAgency = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnRegionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRegionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtAgencyCode = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.labelPhoneNum = new System.Windows.Forms.Label();
            this.txtAgencyName = new System.Windows.Forms.TextBox();
            this.labelMobileNum = new System.Windows.Forms.Label();
            this.txtJoinContact = new System.Windows.Forms.TextBox();
            this.txtTaxCode = new System.Windows.Forms.TextBox();
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMobileNum = new System.Windows.Forms.TextBox();
            this.labelModifiedDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelTaxCode = new System.Windows.Forms.Label();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.labelShopKeeper = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ucDataButtonAgency = new PIPT.ucDataButton();
            this.groupBoxStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAgency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAgency)).BeginInit();
            this.panelSearchAgency.SuspendLayout();
            this.panelAgency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProvince.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewProvince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueRegion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewAgency)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxStore
            // 
            this.groupBoxStore.Controls.Add(this.gcAgency);
            this.groupBoxStore.Controls.Add(this.panelSearchAgency);
            this.groupBoxStore.Controls.Add(this.panelAgency);
            this.groupBoxStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStore.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStore.Name = "groupBoxStore";
            this.groupBoxStore.Size = new System.Drawing.Size(1078, 478);
            this.groupBoxStore.TabIndex = 1;
            this.groupBoxStore.TabStop = false;
            this.groupBoxStore.Text = "Thông tin khách hàng";
            // 
            // gcAgency
            // 
            this.gcAgency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcAgency.Location = new System.Drawing.Point(3, 158);
            this.gcAgency.MainView = this.gvAgency;
            this.gcAgency.Name = "gcAgency";
            this.gcAgency.Size = new System.Drawing.Size(1072, 317);
            this.gcAgency.TabIndex = 11;
            this.gcAgency.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAgency});
            // 
            // gvAgency
            // 
            this.gvAgency.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnCode,
            this.gridColumnName,
            this.gridColumnAddress,
            this.gridColumnProvinceCode,
            this.gridColumnJoinContact,
            this.gridColumnOwnerName,
            this.gridColumnTaxCode,
            this.gridColumnPhoneNum,
            this.gridColumnMobileNum,
            this.gridColumnEmail,
            this.gridColumnDependCode,
            this.gridColumnRegion,
            this.gridColumnCreatedUser,
            this.gridColumnModifiedDate,
            this.gridColumnCreatedDate,
            this.gridColumnModifiedUser,
            this.gridColumnDescription,
            this.gridColumnActive});
            this.gvAgency.GridControl = this.gcAgency;
            this.gvAgency.Name = "gvAgency";
            this.gvAgency.OptionsView.ShowAutoFilterRow = true;
            this.gvAgency.OptionsView.ShowDetailButtons = false;
            this.gvAgency.OptionsView.ShowGroupPanel = false;
            this.gvAgency.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvAgency_FocusedRowChanged);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            this.gridColumnID.Width = 24;
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "Mã KH";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 1;
            this.gridColumnCode.Width = 39;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Tên KH";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 2;
            this.gridColumnName.Width = 54;
            // 
            // gridColumnAddress
            // 
            this.gridColumnAddress.Caption = "Địa chỉ";
            this.gridColumnAddress.FieldName = "Address";
            this.gridColumnAddress.Name = "gridColumnAddress";
            this.gridColumnAddress.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnAddress.Visible = true;
            this.gridColumnAddress.VisibleIndex = 3;
            this.gridColumnAddress.Width = 68;
            // 
            // gridColumnProvinceCode
            // 
            this.gridColumnProvinceCode.Caption = "Mã tỉnh";
            this.gridColumnProvinceCode.FieldName = "ProvinceCode";
            this.gridColumnProvinceCode.Name = "gridColumnProvinceCode";
            this.gridColumnProvinceCode.Visible = true;
            this.gridColumnProvinceCode.VisibleIndex = 4;
            this.gridColumnProvinceCode.Width = 29;
            // 
            // gridColumnJoinContact
            // 
            this.gridColumnJoinContact.Caption = "Hợp đồng tham gia";
            this.gridColumnJoinContact.FieldName = "JoinContact";
            this.gridColumnJoinContact.Name = "gridColumnJoinContact";
            this.gridColumnJoinContact.Visible = true;
            this.gridColumnJoinContact.VisibleIndex = 5;
            this.gridColumnJoinContact.Width = 39;
            // 
            // gridColumnOwnerName
            // 
            this.gridColumnOwnerName.Caption = "Người đại diện";
            this.gridColumnOwnerName.FieldName = "OwnerName";
            this.gridColumnOwnerName.Name = "gridColumnOwnerName";
            this.gridColumnOwnerName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnOwnerName.Visible = true;
            this.gridColumnOwnerName.VisibleIndex = 6;
            this.gridColumnOwnerName.Width = 29;
            // 
            // gridColumnTaxCode
            // 
            this.gridColumnTaxCode.Caption = "Mã số thuế";
            this.gridColumnTaxCode.FieldName = "TaxCode";
            this.gridColumnTaxCode.Name = "gridColumnTaxCode";
            this.gridColumnTaxCode.Visible = true;
            this.gridColumnTaxCode.VisibleIndex = 7;
            this.gridColumnTaxCode.Width = 29;
            // 
            // gridColumnPhoneNum
            // 
            this.gridColumnPhoneNum.Caption = "Điện thoại";
            this.gridColumnPhoneNum.FieldName = "PhoneNum";
            this.gridColumnPhoneNum.Name = "gridColumnPhoneNum";
            this.gridColumnPhoneNum.Visible = true;
            this.gridColumnPhoneNum.VisibleIndex = 8;
            this.gridColumnPhoneNum.Width = 28;
            // 
            // gridColumnMobileNum
            // 
            this.gridColumnMobileNum.Caption = "Di động";
            this.gridColumnMobileNum.FieldName = "MobileNum";
            this.gridColumnMobileNum.Name = "gridColumnMobileNum";
            this.gridColumnMobileNum.Visible = true;
            this.gridColumnMobileNum.VisibleIndex = 9;
            this.gridColumnMobileNum.Width = 31;
            // 
            // gridColumnEmail
            // 
            this.gridColumnEmail.Caption = "Email";
            this.gridColumnEmail.FieldName = "Email";
            this.gridColumnEmail.Name = "gridColumnEmail";
            this.gridColumnEmail.Visible = true;
            this.gridColumnEmail.VisibleIndex = 10;
            this.gridColumnEmail.Width = 36;
            // 
            // gridColumnDependCode
            // 
            this.gridColumnDependCode.Caption = "Mã ĐL cấp trên";
            this.gridColumnDependCode.FieldName = "DependCode";
            this.gridColumnDependCode.Name = "gridColumnDependCode";
            this.gridColumnDependCode.Visible = true;
            this.gridColumnDependCode.VisibleIndex = 11;
            this.gridColumnDependCode.Width = 42;
            // 
            // gridColumnRegion
            // 
            this.gridColumnRegion.Caption = "KV / Miền";
            this.gridColumnRegion.FieldName = "Region";
            this.gridColumnRegion.Name = "gridColumnRegion";
            this.gridColumnRegion.Visible = true;
            this.gridColumnRegion.VisibleIndex = 12;
            this.gridColumnRegion.Width = 36;
            // 
            // gridColumnCreatedUser
            // 
            this.gridColumnCreatedUser.Caption = "Người tạo";
            this.gridColumnCreatedUser.FieldName = "CreatedUser";
            this.gridColumnCreatedUser.Name = "gridColumnCreatedUser";
            this.gridColumnCreatedUser.Visible = true;
            this.gridColumnCreatedUser.VisibleIndex = 13;
            this.gridColumnCreatedUser.Width = 38;
            // 
            // gridColumnModifiedDate
            // 
            this.gridColumnModifiedDate.Caption = "Ngày sửa";
            this.gridColumnModifiedDate.FieldName = "ModifiedDate";
            this.gridColumnModifiedDate.Name = "gridColumnModifiedDate";
            this.gridColumnModifiedDate.Visible = true;
            this.gridColumnModifiedDate.VisibleIndex = 14;
            this.gridColumnModifiedDate.Width = 39;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Ngày tạo";
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 15;
            this.gridColumnCreatedDate.Width = 46;
            // 
            // gridColumnModifiedUser
            // 
            this.gridColumnModifiedUser.Caption = "Người sửa";
            this.gridColumnModifiedUser.FieldName = "ModifiedUser";
            this.gridColumnModifiedUser.Name = "gridColumnModifiedUser";
            this.gridColumnModifiedUser.Visible = true;
            this.gridColumnModifiedUser.VisibleIndex = 16;
            this.gridColumnModifiedUser.Width = 33;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Ghi chú";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 17;
            this.gridColumnDescription.Width = 30;
            // 
            // gridColumnActive
            // 
            this.gridColumnActive.Caption = "Active";
            this.gridColumnActive.FieldName = "Active";
            this.gridColumnActive.Name = "gridColumnActive";
            this.gridColumnActive.Visible = true;
            this.gridColumnActive.VisibleIndex = 18;
            this.gridColumnActive.Width = 26;
            // 
            // panelSearchAgency
            // 
            this.panelSearchAgency.Controls.Add(this.btnImport);
            this.panelSearchAgency.Controls.Add(this.btnPaste);
            this.panelSearchAgency.Location = new System.Drawing.Point(851, 67);
            this.panelSearchAgency.Name = "panelSearchAgency";
            this.panelSearchAgency.Size = new System.Drawing.Size(198, 85);
            this.panelSearchAgency.TabIndex = 10;
            // 
            // btnImport
            // 
            this.btnImport.Image = global::PIPT.Properties.Resources.Excel;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(124, 57);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(71, 24);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Image = global::PIPT.Properties.Resources.Excel;
            this.btnPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaste.Location = new System.Drawing.Point(3, 57);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(71, 24);
            this.btnPaste.TabIndex = 3;
            this.btnPaste.Text = "Paste";
            this.btnPaste.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // panelAgency
            // 
            this.panelAgency.Controls.Add(this.lblModifiedDate);
            this.panelAgency.Controls.Add(this.lblCreatedDate);
            this.panelAgency.Controls.Add(this.txtDescription);
            this.panelAgency.Controls.Add(this.lueAgency);
            this.panelAgency.Controls.Add(this.lueProvince);
            this.panelAgency.Controls.Add(this.lueRegion);
            this.panelAgency.Controls.Add(this.txtAgencyCode);
            this.panelAgency.Controls.Add(this.chkActive);
            this.panelAgency.Controls.Add(this.labelEmail);
            this.panelAgency.Controls.Add(this.txtAddress);
            this.panelAgency.Controls.Add(this.labelPhoneNum);
            this.panelAgency.Controls.Add(this.txtAgencyName);
            this.panelAgency.Controls.Add(this.labelMobileNum);
            this.panelAgency.Controls.Add(this.txtJoinContact);
            this.panelAgency.Controls.Add(this.txtTaxCode);
            this.panelAgency.Controls.Add(this.txtOwnerName);
            this.panelAgency.Controls.Add(this.labelDescription);
            this.panelAgency.Controls.Add(this.label4);
            this.panelAgency.Controls.Add(this.txtMobileNum);
            this.panelAgency.Controls.Add(this.labelModifiedDate);
            this.panelAgency.Controls.Add(this.label2);
            this.panelAgency.Controls.Add(this.labelCreatedDate);
            this.panelAgency.Controls.Add(this.labelTaxCode);
            this.panelAgency.Controls.Add(this.txtPhoneNum);
            this.panelAgency.Controls.Add(this.labelShopKeeper);
            this.panelAgency.Controls.Add(this.txtEmail);
            this.panelAgency.Controls.Add(this.labelName);
            this.panelAgency.Controls.Add(this.labelCode);
            this.panelAgency.Controls.Add(this.label1);
            this.panelAgency.Controls.Add(this.label5);
            this.panelAgency.Controls.Add(this.label3);
            this.panelAgency.Location = new System.Drawing.Point(3, 20);
            this.panelAgency.Name = "panelAgency";
            this.panelAgency.Size = new System.Drawing.Size(842, 132);
            this.panelAgency.TabIndex = 9;
            // 
            // lblModifiedDate
            // 
            this.lblModifiedDate.AutoSize = true;
            this.lblModifiedDate.Location = new System.Drawing.Point(595, 33);
            this.lblModifiedDate.Name = "lblModifiedDate";
            this.lblModifiedDate.Size = new System.Drawing.Size(0, 13);
            this.lblModifiedDate.TabIndex = 16;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(593, 7);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(0, 13);
            this.lblCreatedDate.TabIndex = 15;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(592, 56);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(247, 21);
            this.txtDescription.TabIndex = 14;
            // 
            // lueAgency
            // 
            this.lueAgency.EditValue = "";
            this.lueAgency.Location = new System.Drawing.Point(374, 84);
            this.lueAgency.Name = "lueAgency";
            this.lueAgency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAgency.Properties.DisplayMember = "Name";
            this.lueAgency.Properties.ImmediatePopup = true;
            this.lueAgency.Properties.NullText = "";
            this.lueAgency.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueAgency.Properties.PopupView = this.gridView1;
            this.lueAgency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueAgency.Properties.ValueMember = "Code";
            this.lueAgency.Size = new System.Drawing.Size(142, 20);
            this.lueAgency.TabIndex = 13;
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
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tỉnh thành";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 284;
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
            // lueRegion
            // 
            this.lueRegion.EditValue = "";
            this.lueRegion.Location = new System.Drawing.Point(64, 108);
            this.lueRegion.Name = "lueRegion";
            this.lueRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueRegion.Properties.DisplayMember = "RegionArea";
            this.lueRegion.Properties.ImmediatePopup = true;
            this.lueRegion.Properties.NullText = "";
            this.lueRegion.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueRegion.Properties.PopupView = this.gridLookUpEditViewAgency;
            this.lueRegion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueRegion.Properties.ValueMember = "RegionCode";
            this.lueRegion.Size = new System.Drawing.Size(142, 20);
            this.lueRegion.TabIndex = 11;
            // 
            // gridLookUpEditViewAgency
            // 
            this.gridLookUpEditViewAgency.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnRegionCode,
            this.gridColumnRegionName});
            this.gridLookUpEditViewAgency.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditViewAgency.Name = "gridLookUpEditViewAgency";
            this.gridLookUpEditViewAgency.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditViewAgency.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditViewAgency.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnRegionCode
            // 
            this.gridColumnRegionCode.Caption = "Mã";
            this.gridColumnRegionCode.FieldName = "RegionCode";
            this.gridColumnRegionCode.Name = "gridColumnRegionCode";
            this.gridColumnRegionCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnRegionCode.Visible = true;
            this.gridColumnRegionCode.VisibleIndex = 0;
            this.gridColumnRegionCode.Width = 100;
            // 
            // gridColumnRegionName
            // 
            this.gridColumnRegionName.Caption = "Khu vực";
            this.gridColumnRegionName.FieldName = "RegionArea";
            this.gridColumnRegionName.Name = "gridColumnRegionName";
            this.gridColumnRegionName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnRegionName.Visible = true;
            this.gridColumnRegionName.VisibleIndex = 1;
            this.gridColumnRegionName.Width = 284;
            // 
            // txtAgencyCode
            // 
            this.txtAgencyCode.Location = new System.Drawing.Point(64, 4);
            this.txtAgencyCode.Name = "txtAgencyCode";
            this.txtAgencyCode.Size = new System.Drawing.Size(100, 21);
            this.txtAgencyCode.TabIndex = 0;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(742, 6);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(97, 17);
            this.chkActive.TabIndex = 10;
            this.chkActive.Text = "Còn hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(334, 111);
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
            this.labelPhoneNum.Location = new System.Drawing.Point(530, 85);
            this.labelPhoneNum.Name = "labelPhoneNum";
            this.labelPhoneNum.Size = new System.Drawing.Size(56, 13);
            this.labelPhoneNum.TabIndex = 4;
            this.labelPhoneNum.Text = "Điện thoại";
            // 
            // txtAgencyName
            // 
            this.txtAgencyName.Location = new System.Drawing.Point(64, 30);
            this.txtAgencyName.Name = "txtAgencyName";
            this.txtAgencyName.Size = new System.Drawing.Size(195, 21);
            this.txtAgencyName.TabIndex = 1;
            // 
            // labelMobileNum
            // 
            this.labelMobileNum.AutoSize = true;
            this.labelMobileNum.Location = new System.Drawing.Point(543, 111);
            this.labelMobileNum.Name = "labelMobileNum";
            this.labelMobileNum.Size = new System.Drawing.Size(43, 13);
            this.labelMobileNum.TabIndex = 4;
            this.labelMobileNum.Text = "Di động";
            // 
            // txtJoinContact
            // 
            this.txtJoinContact.Location = new System.Drawing.Point(374, 56);
            this.txtJoinContact.Name = "txtJoinContact";
            this.txtJoinContact.Size = new System.Drawing.Size(126, 21);
            this.txtJoinContact.TabIndex = 4;
            // 
            // txtTaxCode
            // 
            this.txtTaxCode.Location = new System.Drawing.Point(374, 30);
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Size = new System.Drawing.Size(126, 21);
            this.txtTaxCode.TabIndex = 4;
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.Location = new System.Drawing.Point(374, 4);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(126, 21);
            this.txtOwnerName.TabIndex = 4;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(544, 58);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ghi chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đại lý cấp trên";
            // 
            // txtMobileNum
            // 
            this.txtMobileNum.Location = new System.Drawing.Point(592, 108);
            this.txtMobileNum.Name = "txtMobileNum";
            this.txtMobileNum.Size = new System.Drawing.Size(126, 21);
            this.txtMobileNum.TabIndex = 6;
            // 
            // labelModifiedDate
            // 
            this.labelModifiedDate.AutoSize = true;
            this.labelModifiedDate.Location = new System.Drawing.Point(536, 33);
            this.labelModifiedDate.Name = "labelModifiedDate";
            this.labelModifiedDate.Size = new System.Drawing.Size(53, 13);
            this.labelModifiedDate.TabIndex = 4;
            this.labelModifiedDate.Text = "Ngày sửa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hợp đồng tham gia";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(536, 7);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // labelTaxCode
            // 
            this.labelTaxCode.AutoSize = true;
            this.labelTaxCode.Location = new System.Drawing.Point(308, 33);
            this.labelTaxCode.Name = "labelTaxCode";
            this.labelTaxCode.Size = new System.Drawing.Size(60, 13);
            this.labelTaxCode.TabIndex = 4;
            this.labelTaxCode.Text = "Mã số thuế";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(592, 82);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(126, 21);
            this.txtPhoneNum.TabIndex = 5;
            // 
            // labelShopKeeper
            // 
            this.labelShopKeeper.AutoSize = true;
            this.labelShopKeeper.Location = new System.Drawing.Point(295, 7);
            this.labelShopKeeper.Name = "labelShopKeeper";
            this.labelShopKeeper.Size = new System.Drawing.Size(75, 13);
            this.labelShopKeeper.TabIndex = 4;
            this.labelShopKeeper.Text = "Người đại diện";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(374, 108);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "KV / Miền";
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
            // ucDataButtonAgency
            // 
            this.ucDataButtonAgency.AddNewVisible = true;
            this.ucDataButtonAgency.CancelVisible = true;
            this.ucDataButtonAgency.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonAgency.DeleteVisible = true;
            this.ucDataButtonAgency.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonAgency.EditVisible = true;
            this.ucDataButtonAgency.ExcelVisible = true;
            this.ucDataButtonAgency.IsContitnue = true;
            this.ucDataButtonAgency.LanguageVisible = false;
            this.ucDataButtonAgency.Location = new System.Drawing.Point(0, 478);
            this.ucDataButtonAgency.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonAgency.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonAgency.MultiLanguageVisible = false;
            this.ucDataButtonAgency.Name = "ucDataButtonAgency";
            this.ucDataButtonAgency.PrintVisible = false;
            this.ucDataButtonAgency.ReportVisible = false;
            this.ucDataButtonAgency.SaveVisible = true;
            this.ucDataButtonAgency.Size = new System.Drawing.Size(1078, 34);
            this.ucDataButtonAgency.TabIndex = 0;
            this.ucDataButtonAgency.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_InsertHandler);
            this.ucDataButtonAgency.ExcelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_ExcelHandler);
            this.ucDataButtonAgency.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_EditHandler);
            this.ucDataButtonAgency.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_SaveHandler);
            this.ucDataButtonAgency.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_DeleteHandler);
            this.ucDataButtonAgency.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_CancelHandler);
            this.ucDataButtonAgency.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_CloseHandler);
            // 
            // frmDacAgency
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1078, 512);
            this.Controls.Add(this.groupBoxStore);
            this.Controls.Add(this.ucDataButtonAgency);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDacAgency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục Khách hàng";
            this.Load += new System.EventHandler(this.frmDacAgency_Load);
            this.groupBoxStore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAgency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAgency)).EndInit();
            this.panelSearchAgency.ResumeLayout(false);
            this.panelAgency.ResumeLayout(false);
            this.panelAgency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueProvince.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewProvince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueRegion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewAgency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonAgency;
        private System.Windows.Forms.GroupBox groupBoxStore;
        private System.Windows.Forms.Panel panelAgency;
        private System.Windows.Forms.TextBox txtAgencyCode;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label labelPhoneNum;
        private System.Windows.Forms.TextBox txtAgencyName;
        private System.Windows.Forms.Label labelMobileNum;
        private System.Windows.Forms.TextBox txtOwnerName;
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
        private DevExpress.XtraGrid.GridControl gcAgency;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAgency;
        private DevExpress.XtraEditors.GridLookUpEdit lueRegion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditViewAgency;
        private System.Windows.Forms.TextBox txtJoinContact;
        private System.Windows.Forms.TextBox txtTaxCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTaxCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProvinceCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRegion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnJoinContact;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTaxCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPhoneNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDependCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifiedUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActive;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRegionCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRegionName;
        private DevExpress.XtraEditors.GridLookUpEdit lueProvince;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditViewProvince;
        private DevExpress.XtraGrid.Columns.GridColumn gridLookUpColumnProvinceCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridLookUpColumnProvinceName;
        private System.Windows.Forms.Label labelModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMobileNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmail;
        private System.Windows.Forms.Button btnImport;
        private DevExpress.XtraEditors.GridLookUpEdit lueAgency;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblModifiedDate;
        private System.Windows.Forms.Label lblCreatedDate;
    }
}