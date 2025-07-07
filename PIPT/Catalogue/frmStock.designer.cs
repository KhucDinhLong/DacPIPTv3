namespace PIPT
{
    partial class frmStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStock));
            this.groupBoxStock = new System.Windows.Forms.GroupBox();
            this.gcStock = new DevExpress.XtraGrid.GridControl();
            this.gvStock = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMobi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnManager = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelStock = new System.Windows.Forms.Panel();
            this.lueAgency = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditViewCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnLookUpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookUpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.labelManager = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelMobi = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelFax = new System.Windows.Forms.Label();
            this.labelTelephone = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelBranchID = new System.Windows.Forms.Label();
            this.labelContact = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.ucDataButtonStock = new PIPT.ucDataButton();
            this.groupBoxStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStock)).BeginInit();
            this.panelStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxStock
            // 
            this.groupBoxStock.Controls.Add(this.gcStock);
            this.groupBoxStock.Controls.Add(this.panelStock);
            this.groupBoxStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStock.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStock.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStock.Name = "groupBoxStock";
            this.groupBoxStock.Size = new System.Drawing.Size(857, 426);
            this.groupBoxStock.TabIndex = 1;
            this.groupBoxStock.TabStop = false;
            this.groupBoxStock.Text = "Thông tin kho";
            // 
            // gcStock
            // 
            this.gcStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcStock.Location = new System.Drawing.Point(3, 166);
            this.gcStock.MainView = this.gvStock;
            this.gcStock.Name = "gcStock";
            this.gcStock.Size = new System.Drawing.Size(851, 257);
            this.gcStock.TabIndex = 12;
            this.gcStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStock});
            // 
            // gvStock
            // 
            this.gvStock.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnCode,
            this.gridColumnName,
            this.gridColumnContact,
            this.gridColumnAddress,
            this.gridColumnEmail,
            this.gridColumnTelephone,
            this.gridColumnFax,
            this.gridColumnMobi,
            this.gridColumnManager,
            this.gridColumnDescription,
            this.gridColumnActive});
            this.gvStock.GridControl = this.gcStock;
            this.gvStock.Name = "gvStock";
            this.gvStock.OptionsView.ShowAutoFilterRow = true;
            this.gvStock.OptionsView.ShowGroupPanel = false;
            this.gvStock.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvStock_FocusedRowChanged);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "Mã";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 0;
            this.gridColumnCode.Width = 60;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Tên";
            this.gridColumnName.CustomizationCaption = "Tên của danh mục";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            this.gridColumnName.Width = 145;
            // 
            // gridColumnContact
            // 
            this.gridColumnContact.Caption = "Người liên hệ";
            this.gridColumnContact.FieldName = "Contact";
            this.gridColumnContact.Name = "gridColumnContact";
            this.gridColumnContact.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnContact.Visible = true;
            this.gridColumnContact.VisibleIndex = 2;
            this.gridColumnContact.Width = 54;
            // 
            // gridColumnAddress
            // 
            this.gridColumnAddress.Caption = "Địa chỉ";
            this.gridColumnAddress.FieldName = "Address";
            this.gridColumnAddress.Name = "gridColumnAddress";
            this.gridColumnAddress.Visible = true;
            this.gridColumnAddress.VisibleIndex = 3;
            this.gridColumnAddress.Width = 63;
            // 
            // gridColumnEmail
            // 
            this.gridColumnEmail.Caption = "Email";
            this.gridColumnEmail.FieldName = "Email";
            this.gridColumnEmail.Name = "gridColumnEmail";
            this.gridColumnEmail.Visible = true;
            this.gridColumnEmail.VisibleIndex = 4;
            this.gridColumnEmail.Width = 41;
            // 
            // gridColumnTelephone
            // 
            this.gridColumnTelephone.Caption = "Điện thoại";
            this.gridColumnTelephone.FieldName = "Telephone";
            this.gridColumnTelephone.Name = "gridColumnTelephone";
            this.gridColumnTelephone.Visible = true;
            this.gridColumnTelephone.VisibleIndex = 5;
            this.gridColumnTelephone.Width = 63;
            // 
            // gridColumnFax
            // 
            this.gridColumnFax.Caption = "Fax";
            this.gridColumnFax.FieldName = "Fax";
            this.gridColumnFax.Name = "gridColumnFax";
            this.gridColumnFax.Visible = true;
            this.gridColumnFax.VisibleIndex = 6;
            this.gridColumnFax.Width = 59;
            // 
            // gridColumnMobi
            // 
            this.gridColumnMobi.Caption = "Di động";
            this.gridColumnMobi.FieldName = "Mobi";
            this.gridColumnMobi.Name = "gridColumnMobi";
            this.gridColumnMobi.Visible = true;
            this.gridColumnMobi.VisibleIndex = 7;
            this.gridColumnMobi.Width = 59;
            // 
            // gridColumnManager
            // 
            this.gridColumnManager.Caption = "Thủ kho";
            this.gridColumnManager.FieldName = "Manager";
            this.gridColumnManager.Name = "gridColumnManager";
            this.gridColumnManager.Visible = true;
            this.gridColumnManager.VisibleIndex = 8;
            this.gridColumnManager.Width = 74;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Miêu tả";
            this.gridColumnDescription.CustomizationCaption = "Description";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 9;
            this.gridColumnDescription.Width = 117;
            // 
            // gridColumnActive
            // 
            this.gridColumnActive.Caption = "Active";
            this.gridColumnActive.FieldName = "Active";
            this.gridColumnActive.Name = "gridColumnActive";
            this.gridColumnActive.Visible = true;
            this.gridColumnActive.VisibleIndex = 10;
            this.gridColumnActive.Width = 48;
            // 
            // panelStock
            // 
            this.panelStock.Controls.Add(this.lueAgency);
            this.panelStock.Controls.Add(this.txtDescription);
            this.panelStock.Controls.Add(this.txtContact);
            this.panelStock.Controls.Add(this.txtMobile);
            this.panelStock.Controls.Add(this.txtFax);
            this.panelStock.Controls.Add(this.txtManager);
            this.panelStock.Controls.Add(this.txtEmail);
            this.panelStock.Controls.Add(this.txtPhone);
            this.panelStock.Controls.Add(this.txtAddress);
            this.panelStock.Controls.Add(this.txtCode);
            this.panelStock.Controls.Add(this.labelManager);
            this.panelStock.Controls.Add(this.chkActive);
            this.panelStock.Controls.Add(this.labelEmail);
            this.panelStock.Controls.Add(this.txtName);
            this.panelStock.Controls.Add(this.labelMobi);
            this.panelStock.Controls.Add(this.labelAddress);
            this.panelStock.Controls.Add(this.labelFax);
            this.panelStock.Controls.Add(this.labelTelephone);
            this.panelStock.Controls.Add(this.labelName);
            this.panelStock.Controls.Add(this.labelBranchID);
            this.panelStock.Controls.Add(this.labelContact);
            this.panelStock.Controls.Add(this.labelDescription);
            this.panelStock.Controls.Add(this.labelCode);
            this.panelStock.Location = new System.Drawing.Point(41, 20);
            this.panelStock.Name = "panelStock";
            this.panelStock.Size = new System.Drawing.Size(774, 140);
            this.panelStock.TabIndex = 9;
            // 
            // lueAgency
            // 
            this.lueAgency.Location = new System.Drawing.Point(90, 7);
            this.lueAgency.Name = "lueAgency";
            this.lueAgency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAgency.Properties.DisplayMember = "Name";
            this.lueAgency.Properties.ImmediatePopup = true;
            this.lueAgency.Properties.NullText = "";
            this.lueAgency.Properties.PopupView = this.gridLookUpEditViewCategory;
            this.lueAgency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueAgency.Properties.ValueMember = "Code";
            this.lueAgency.Size = new System.Drawing.Size(195, 20);
            this.lueAgency.TabIndex = 0;
            // 
            // gridLookUpEditViewCategory
            // 
            this.gridLookUpEditViewCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnLookUpCode,
            this.gridColumnLookUpName});
            this.gridLookUpEditViewCategory.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditViewCategory.Name = "gridLookUpEditViewCategory";
            this.gridLookUpEditViewCategory.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditViewCategory.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditViewCategory.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnLookUpCode
            // 
            this.gridColumnLookUpCode.Caption = "Mã";
            this.gridColumnLookUpCode.FieldName = "Code";
            this.gridColumnLookUpCode.Name = "gridColumnLookUpCode";
            this.gridColumnLookUpCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnLookUpCode.Visible = true;
            this.gridColumnLookUpCode.VisibleIndex = 0;
            this.gridColumnLookUpCode.Width = 100;
            // 
            // gridColumnLookUpName
            // 
            this.gridColumnLookUpName.Caption = "Tên";
            this.gridColumnLookUpName.FieldName = "Name";
            this.gridColumnLookUpName.Name = "gridColumnLookUpName";
            this.gridColumnLookUpName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnLookUpName.Visible = true;
            this.gridColumnLookUpName.VisibleIndex = 1;
            this.gridColumnLookUpName.Width = 284;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(372, 87);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(345, 42);
            this.txtDescription.TabIndex = 8;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(90, 87);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(195, 21);
            this.txtContact.TabIndex = 3;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(90, 114);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(100, 21);
            this.txtMobile.TabIndex = 4;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(617, 33);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(100, 21);
            this.txtFax.TabIndex = 10;
            // 
            // txtManager
            // 
            this.txtManager.Location = new System.Drawing.Point(372, 60);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(177, 21);
            this.txtManager.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(372, 33);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(177, 21);
            this.txtEmail.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(617, 7);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 21);
            this.txtPhone.TabIndex = 9;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(372, 7);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(177, 21);
            this.txtAddress.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(90, 33);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 21);
            this.txtCode.TabIndex = 1;
            // 
            // labelManager
            // 
            this.labelManager.AutoSize = true;
            this.labelManager.Location = new System.Drawing.Point(302, 63);
            this.labelManager.Name = "labelManager";
            this.labelManager.Size = new System.Drawing.Size(64, 13);
            this.labelManager.TabIndex = 4;
            this.labelManager.Text = "Quản lý kho";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(617, 62);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(97, 17);
            this.chkActive.TabIndex = 11;
            this.chkActive.Text = "Còn hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(335, 36);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(31, 13);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(195, 21);
            this.txtName.TabIndex = 2;
            // 
            // labelMobi
            // 
            this.labelMobi.AutoSize = true;
            this.labelMobi.Location = new System.Drawing.Point(41, 117);
            this.labelMobi.Name = "labelMobi";
            this.labelMobi.Size = new System.Drawing.Size(43, 13);
            this.labelMobi.TabIndex = 4;
            this.labelMobi.Text = "Di động";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(327, 10);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(39, 13);
            this.labelAddress.TabIndex = 4;
            this.labelAddress.Text = "Địa chỉ";
            // 
            // labelFax
            // 
            this.labelFax.AutoSize = true;
            this.labelFax.Location = new System.Drawing.Point(586, 37);
            this.labelFax.Name = "labelFax";
            this.labelFax.Size = new System.Drawing.Size(25, 13);
            this.labelFax.TabIndex = 4;
            this.labelFax.Text = "Fax";
            // 
            // labelTelephone
            // 
            this.labelTelephone.AutoSize = true;
            this.labelTelephone.Location = new System.Drawing.Point(555, 10);
            this.labelTelephone.Name = "labelTelephone";
            this.labelTelephone.Size = new System.Drawing.Size(56, 13);
            this.labelTelephone.TabIndex = 4;
            this.labelTelephone.Text = "Điện thoại";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(59, 63);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(25, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Tên";
            // 
            // labelBranchID
            // 
            this.labelBranchID.AutoSize = true;
            this.labelBranchID.Location = new System.Drawing.Point(20, 10);
            this.labelBranchID.Name = "labelBranchID";
            this.labelBranchID.Size = new System.Drawing.Size(64, 13);
            this.labelBranchID.TabIndex = 4;
            this.labelBranchID.Text = "Thuộc đại lý";
            // 
            // labelContact
            // 
            this.labelContact.AutoSize = true;
            this.labelContact.Location = new System.Drawing.Point(15, 90);
            this.labelContact.Name = "labelContact";
            this.labelContact.Size = new System.Drawing.Size(69, 13);
            this.labelContact.TabIndex = 4;
            this.labelContact.Text = "Người liên hệ";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(324, 90);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Miêu tả";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(63, 36);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(21, 13);
            this.labelCode.TabIndex = 4;
            this.labelCode.Text = "Mã";
            // 
            // ucDataButtonStock
            // 
            this.ucDataButtonStock.AddNewVisible = true;
            this.ucDataButtonStock.CancelVisible = true;
            this.ucDataButtonStock.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonStock.DeleteVisible = true;
            this.ucDataButtonStock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonStock.EditVisible = true;
            this.ucDataButtonStock.ExcelVisible = false;
            this.ucDataButtonStock.IsContitnue = true;
            this.ucDataButtonStock.LanguageVisible = false;
            this.ucDataButtonStock.Location = new System.Drawing.Point(0, 426);
            this.ucDataButtonStock.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonStock.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonStock.MultiLanguageVisible = false;
            this.ucDataButtonStock.Name = "ucDataButtonStock";
            this.ucDataButtonStock.PrintVisible = false;
            this.ucDataButtonStock.ReportVisible = false;
            this.ucDataButtonStock.SaveVisible = true;
            this.ucDataButtonStock.Size = new System.Drawing.Size(857, 34);
            this.ucDataButtonStock.TabIndex = 13;
            this.ucDataButtonStock.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStock_InsertHandler);
            this.ucDataButtonStock.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStock_EditHandler);
            this.ucDataButtonStock.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonlStock_SaveHandler);
            this.ucDataButtonStock.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStock_DeleteHandler);
            this.ucDataButtonStock.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStock_CancelHandler);
            this.ucDataButtonStock.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonStock_CloseHandler);
            // 
            // frmStock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(857, 460);
            this.Controls.Add(this.groupBoxStock);
            this.Controls.Add(this.ucDataButtonStock);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Định nghĩa các loại kho";
            this.Load += new System.EventHandler(this.frmStock_Load);
            this.groupBoxStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStock)).EndInit();
            this.panelStock.ResumeLayout(false);
            this.panelStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonStock;
        private System.Windows.Forms.GroupBox groupBoxStock;
        private System.Windows.Forms.Panel panelStock;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labelTelephone;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label labelBranchID;
        private DevExpress.XtraGrid.GridControl gcStock;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStock;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnContact;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActive;
        private DevExpress.XtraEditors.GridLookUpEdit lueAgency;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditViewCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookUpCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookUpName;
        private System.Windows.Forms.Label labelFax;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox txtDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTelephone;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label labelManager;
        private System.Windows.Forms.Label labelMobi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFax;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMobi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnManager;
    }
}