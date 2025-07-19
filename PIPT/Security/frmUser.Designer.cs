namespace PIPT
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.grpUserInfo = new System.Windows.Forms.GroupBox();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.lueAgency = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditViewAgencyCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColAgencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAgencyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.chkLstGroup = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtLockedReason = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblLockedReason = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.groupBoxUserList = new System.Windows.Forms.GroupBox();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeadlineOfUsing = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkLockedUser = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colLockedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLockedReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucDataButtonUser = new PIPT.ucDataButton();
            this.grpUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewAgencyCode)).BeginInit();
            this.groupBoxUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLockedUser)).BeginInit();
            this.SuspendLayout();
            // 
            // grpUserInfo
            // 
            this.grpUserInfo.Controls.Add(this.chkLocked);
            this.grpUserInfo.Controls.Add(this.lueAgency);
            this.grpUserInfo.Controls.Add(this.label4);
            this.grpUserInfo.Controls.Add(this.btnResetPassword);
            this.grpUserInfo.Controls.Add(this.chkLstGroup);
            this.grpUserInfo.Controls.Add(this.label1);
            this.grpUserInfo.Controls.Add(this.dtpEndDate);
            this.grpUserInfo.Controls.Add(this.txtLockedReason);
            this.grpUserInfo.Controls.Add(this.txtEmail);
            this.grpUserInfo.Controls.Add(this.txtEmployeeName);
            this.grpUserInfo.Controls.Add(this.txtConfirmPassword);
            this.grpUserInfo.Controls.Add(this.txtPassword);
            this.grpUserInfo.Controls.Add(this.txtUserName);
            this.grpUserInfo.Controls.Add(this.lblEndDate);
            this.grpUserInfo.Controls.Add(this.lblLockedReason);
            this.grpUserInfo.Controls.Add(this.lblEmail);
            this.grpUserInfo.Controls.Add(this.label2);
            this.grpUserInfo.Controls.Add(this.lblEmployeeID);
            this.grpUserInfo.Controls.Add(this.lblPassword);
            this.grpUserInfo.Controls.Add(this.lblUserName);
            this.grpUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpUserInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUserInfo.Location = new System.Drawing.Point(0, 0);
            this.grpUserInfo.Name = "grpUserInfo";
            this.grpUserInfo.Size = new System.Drawing.Size(697, 221);
            this.grpUserInfo.TabIndex = 1;
            this.grpUserInfo.TabStop = false;
            this.grpUserInfo.Text = "Thông tin tài khoản người dùng";
            // 
            // chkLocked
            // 
            this.chkLocked.AutoSize = true;
            this.chkLocked.Location = new System.Drawing.Point(140, 130);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(50, 17);
            this.chkLocked.TabIndex = 4;
            this.chkLocked.Text = "Khóa";
            this.chkLocked.UseVisualStyleBackColor = true;
            this.chkLocked.CheckedChanged += new System.EventHandler(this.chkLocked_CheckedChanged_1);
            // 
            // lueAgency
            // 
            this.lueAgency.EditValue = "";
            this.lueAgency.Location = new System.Drawing.Point(140, 104);
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
            this.lueAgency.TabIndex = 3;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Đại lý";
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Image = global::PIPT.Properties.Resources.submit1616;
            this.btnResetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetPassword.Location = new System.Drawing.Point(598, 45);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(75, 23);
            this.btnResetPassword.TabIndex = 10;
            this.btnResetPassword.Text = "Reset";
            this.btnResetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.buttonResetPassword_Click);
            // 
            // chkLstGroup
            // 
            this.chkLstGroup.CheckOnClick = true;
            this.chkLstGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstGroup.FormattingEnabled = true;
            this.chkLstGroup.Location = new System.Drawing.Point(140, 157);
            this.chkLstGroup.MultiColumn = true;
            this.chkLstGroup.Name = "chkLstGroup";
            this.chkLstGroup.Size = new System.Drawing.Size(533, 55);
            this.chkLstGroup.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nhóm người dùng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(438, 125);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(118, 21);
            this.dtpEndDate.TabIndex = 9;
            // 
            // txtLockedReason
            // 
            this.txtLockedReason.Location = new System.Drawing.Point(438, 74);
            this.txtLockedReason.Multiline = true;
            this.txtLockedReason.Name = "txtLockedReason";
            this.txtLockedReason.Size = new System.Drawing.Size(235, 46);
            this.txtLockedReason.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 77);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(157, 21);
            this.txtEmail.TabIndex = 2;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(140, 49);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(157, 21);
            this.txtEmployeeName.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(438, 46);
            this.txtConfirmPassword.MaxLength = 50;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(157, 21);
            this.txtConfirmPassword.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(438, 18);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(157, 21);
            this.txtPassword.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(140, 20);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(157, 21);
            this.txtUserName.TabIndex = 0;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(350, 125);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(82, 20);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "Hạn sử dụng";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLockedReason
            // 
            this.lblLockedReason.Location = new System.Drawing.Point(321, 74);
            this.lblLockedReason.Name = "lblLockedReason";
            this.lblLockedReason.Size = new System.Drawing.Size(112, 20);
            this.lblLockedReason.TabIndex = 7;
            this.lblLockedReason.Text = "Lý do khóa";
            this.lblLockedReason.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(22, 77);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(112, 20);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Địa chỉ email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(303, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập lại mật khẩu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Location = new System.Drawing.Point(22, 49);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(112, 16);
            this.lblEmployeeID.TabIndex = 2;
            this.lblEmployeeID.Text = "Tên nhân viên";
            this.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(306, 20);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(126, 19);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Mật khẩu";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(19, 20);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(112, 20);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Tài khoản";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxUserList
            // 
            this.groupBoxUserList.Controls.Add(this.gcUser);
            this.groupBoxUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUserList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxUserList.Location = new System.Drawing.Point(0, 221);
            this.groupBoxUserList.Name = "groupBoxUserList";
            this.groupBoxUserList.Size = new System.Drawing.Size(697, 284);
            this.groupBoxUserList.TabIndex = 2;
            this.groupBoxUserList.TabStop = false;
            this.groupBoxUserList.Text = "Danh sách tài khoản";
            // 
            // gcUser
            // 
            this.gcUser.Location = new System.Drawing.Point(13, 21);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.Name = "gcUser";
            this.gcUser.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkLockedUser});
            this.gcUser.Size = new System.Drawing.Size(672, 257);
            this.gcUser.TabIndex = 11;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserName,
            this.colFullName,
            this.colCustomerCode,
            this.colDeadlineOfUsing,
            this.colLock,
            this.colLockedDate,
            this.colLockedReason});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsView.ShowAutoFilterRow = true;
            this.gvUser.OptionsView.ShowDetailButtons = false;
            this.gvUser.OptionsView.ShowGroupPanel = false;
            this.gvUser.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvUser_FocusedRowChanged);
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Tài khoản";
            this.colUserName.FieldName = "LoginID";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "Họ tên";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 1;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Caption = "Mã khách hàng";
            this.colCustomerCode.FieldName = "CustomerCode";
            this.colCustomerCode.Name = "colCustomerCode";
            this.colCustomerCode.Visible = true;
            this.colCustomerCode.VisibleIndex = 2;
            // 
            // colDeadlineOfUsing
            // 
            this.colDeadlineOfUsing.Caption = "Hạn sử dụng";
            this.colDeadlineOfUsing.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDeadlineOfUsing.FieldName = "DeadlineOfUsing";
            this.colDeadlineOfUsing.Name = "colDeadlineOfUsing";
            this.colDeadlineOfUsing.Visible = true;
            this.colDeadlineOfUsing.VisibleIndex = 3;
            // 
            // colLock
            // 
            this.colLock.Caption = "Khóa";
            this.colLock.ColumnEdit = this.chkLockedUser;
            this.colLock.FieldName = "LockedUser";
            this.colLock.Name = "colLock";
            this.colLock.Visible = true;
            this.colLock.VisibleIndex = 4;
            // 
            // chkLockedUser
            // 
            this.chkLockedUser.AutoHeight = false;
            this.chkLockedUser.Name = "chkLockedUser";
            this.chkLockedUser.ReadOnly = true;
            // 
            // colLockedDate
            // 
            this.colLockedDate.Caption = "Ngày khóa";
            this.colLockedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colLockedDate.FieldName = "LockedDate";
            this.colLockedDate.Name = "colLockedDate";
            this.colLockedDate.Visible = true;
            this.colLockedDate.VisibleIndex = 5;
            // 
            // colLockedReason
            // 
            this.colLockedReason.Caption = "Lý do khóa";
            this.colLockedReason.FieldName = "LockedReason";
            this.colLockedReason.Name = "colLockedReason";
            this.colLockedReason.Visible = true;
            this.colLockedReason.VisibleIndex = 6;
            // 
            // ucDataButtonUser
            // 
            this.ucDataButtonUser.AddNewVisible = true;
            this.ucDataButtonUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucDataButtonUser.CancelVisible = true;
            this.ucDataButtonUser.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonUser.DeleteVisible = true;
            this.ucDataButtonUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonUser.EditVisible = true;
            this.ucDataButtonUser.ExcelVisible = false;
            this.ucDataButtonUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDataButtonUser.IsContitnue = true;
            this.ucDataButtonUser.LanguageVisible = true;
            this.ucDataButtonUser.Location = new System.Drawing.Point(0, 505);
            this.ucDataButtonUser.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonUser.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonUser.MultiLanguageVisible = false;
            this.ucDataButtonUser.Name = "ucDataButtonUser";
            this.ucDataButtonUser.PrintVisible = false;
            this.ucDataButtonUser.ReportVisible = false;
            this.ucDataButtonUser.SaveVisible = true;
            this.ucDataButtonUser.Size = new System.Drawing.Size(697, 34);
            this.ucDataButtonUser.TabIndex = 12;
            this.ucDataButtonUser.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonUser_InsertHander);
            this.ucDataButtonUser.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonUser_EditHandler);
            this.ucDataButtonUser.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonUser_SaveHandler);
            this.ucDataButtonUser.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonUser_DeleteHandler);
            this.ucDataButtonUser.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonUser_CancelHandler);
            this.ucDataButtonUser.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonUser_CloseHandler);
            // 
            // frmUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(697, 539);
            this.Controls.Add(this.groupBoxUserList);
            this.Controls.Add(this.grpUserInfo);
            this.Controls.Add(this.ucDataButtonUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài khoản người dùng";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewAgencyCode)).EndInit();
            this.groupBoxUserList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLockedUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonUser;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtLockedReason;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblLockedReason;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox groupBoxUserList;
        private System.Windows.Forms.Button btnResetPassword;
        private DevExpress.XtraEditors.GridLookUpEdit lueAgency;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditViewAgencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAgencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAgencyName;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDeadlineOfUsing;
        private DevExpress.XtraGrid.Columns.GridColumn colLock;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkLockedUser;
        private DevExpress.XtraGrid.Columns.GridColumn colLockedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLockedReason;
        private System.Windows.Forms.CheckedListBox chkLstGroup;
        private System.Windows.Forms.CheckBox chkLocked;
    }
}