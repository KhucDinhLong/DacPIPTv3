namespace PIPT.Agency
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
            this.buttonResetPassword = new System.Windows.Forms.Button();
            this.chkLstGroup = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtLockedReason = new System.Windows.Forms.TextBox();
            this.chkLocked = new System.Windows.Forms.CheckBox();
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
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.LoginID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeadlineOfUsing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LockedUser = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ucDataButtonUser = new PIPT.Agency.ucDataButton();
            this.grpUserInfo.SuspendLayout();
            this.groupBoxUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.SuspendLayout();
            // 
            // grpUserInfo
            // 
            this.grpUserInfo.Controls.Add(this.buttonResetPassword);
            this.grpUserInfo.Controls.Add(this.chkLstGroup);
            this.grpUserInfo.Controls.Add(this.label1);
            this.grpUserInfo.Controls.Add(this.dtpEndDate);
            this.grpUserInfo.Controls.Add(this.txtLockedReason);
            this.grpUserInfo.Controls.Add(this.chkLocked);
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
            this.grpUserInfo.Size = new System.Drawing.Size(697, 197);
            this.grpUserInfo.TabIndex = 1;
            this.grpUserInfo.TabStop = false;
            this.grpUserInfo.Text = "Thông tin tài khoản người dùng";
            // 
            // buttonResetPassword
            // 
            this.buttonResetPassword.Image = global::PIPT.Agency.Properties.Resources.submit1616;
            this.buttonResetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonResetPassword.Location = new System.Drawing.Point(598, 45);
            this.buttonResetPassword.Name = "buttonResetPassword";
            this.buttonResetPassword.Size = new System.Drawing.Size(75, 23);
            this.buttonResetPassword.TabIndex = 11;
            this.buttonResetPassword.Text = "Reset";
            this.buttonResetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonResetPassword.UseVisualStyleBackColor = true;
            this.buttonResetPassword.Click += new System.EventHandler(this.buttonResetPassword_Click);
            // 
            // chkLstGroup
            // 
            this.chkLstGroup.CheckOnClick = true;
            this.chkLstGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstGroup.FormattingEnabled = true;
            this.chkLstGroup.Location = new System.Drawing.Point(140, 133);
            this.chkLstGroup.MultiColumn = true;
            this.chkLstGroup.Name = "chkLstGroup";
            this.chkLstGroup.Size = new System.Drawing.Size(533, 55);
            this.chkLstGroup.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 133);
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
            this.dtpEndDate.Location = new System.Drawing.Point(306, 105);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(118, 21);
            this.dtpEndDate.TabIndex = 6;
            // 
            // txtLockedReason
            // 
            this.txtLockedReason.Location = new System.Drawing.Point(438, 74);
            this.txtLockedReason.Multiline = true;
            this.txtLockedReason.Name = "txtLockedReason";
            this.txtLockedReason.Size = new System.Drawing.Size(235, 53);
            this.txtLockedReason.TabIndex = 5;
            // 
            // chkLocked
            // 
            this.chkLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLocked.Location = new System.Drawing.Point(22, 105);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(131, 20);
            this.chkLocked.TabIndex = 4;
            this.chkLocked.Text = "Khóa người dùng";
            this.chkLocked.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLocked.UseVisualStyleBackColor = true;
            this.chkLocked.CheckedChanged += new System.EventHandler(this.chkLocked_CheckedChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 77);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(157, 21);
            this.txtEmail.TabIndex = 3;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(140, 49);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(157, 21);
            this.txtEmployeeName.TabIndex = 2;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(438, 46);
            this.txtConfirmPassword.MaxLength = 50;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(157, 21);
            this.txtConfirmPassword.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(438, 18);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(157, 21);
            this.txtPassword.TabIndex = 1;
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
            this.lblEndDate.Location = new System.Drawing.Point(176, 105);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(122, 20);
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
            this.groupBoxUserList.Controls.Add(this.dataGridViewUser);
            this.groupBoxUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUserList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxUserList.Location = new System.Drawing.Point(0, 197);
            this.groupBoxUserList.Name = "groupBoxUserList";
            this.groupBoxUserList.Size = new System.Drawing.Size(697, 266);
            this.groupBoxUserList.TabIndex = 2;
            this.groupBoxUserList.TabStop = false;
            this.groupBoxUserList.Text = "Danh sách tài khoản";
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AllowUserToAddRows = false;
            this.dataGridViewUser.AllowUserToDeleteRows = false;
            this.dataGridViewUser.AllowUserToResizeRows = false;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginID,
            this.FullName,
            this.Email,
            this.DeadlineOfUsing,
            this.LockedUser});
            this.dataGridViewUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUser.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUser.Size = new System.Drawing.Size(691, 246);
            this.dataGridViewUser.TabIndex = 0;
            this.dataGridViewUser.SelectionChanged += new System.EventHandler(this.dataGridViewUser_SelectionChanged);
            // 
            // LoginID
            // 
            this.LoginID.DataPropertyName = "LoginID";
            this.LoginID.HeaderText = "Tài khoản";
            this.LoginID.Name = "LoginID";
            this.LoginID.ReadOnly = true;
            this.LoginID.Width = 120;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Tên nhân viên";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 150;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 150;
            // 
            // DeadlineOfUsing
            // 
            this.DeadlineOfUsing.DataPropertyName = "DeadlineOfUsing";
            this.DeadlineOfUsing.HeaderText = "Hạn sử dụng";
            this.DeadlineOfUsing.Name = "DeadlineOfUsing";
            this.DeadlineOfUsing.ReadOnly = true;
            this.DeadlineOfUsing.Width = 140;
            // 
            // LockedUser
            // 
            this.LockedUser.DataPropertyName = "LockedUser";
            this.LockedUser.HeaderText = "Khóa";
            this.LockedUser.Name = "LockedUser";
            this.LockedUser.ReadOnly = true;
            this.LockedUser.Width = 60;
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
            this.ucDataButtonUser.Location = new System.Drawing.Point(0, 463);
            this.ucDataButtonUser.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonUser.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonUser.MultiLanguageVisible = false;
            this.ucDataButtonUser.Name = "ucDataButtonUser";
            this.ucDataButtonUser.PrintVisible = false;
            this.ucDataButtonUser.ReportVisible = false;
            this.ucDataButtonUser.SaveVisible = true;
            this.ucDataButtonUser.Size = new System.Drawing.Size(697, 34);
            this.ucDataButtonUser.TabIndex = 0;
            this.ucDataButtonUser.InsertHandler += new ucDataButton.DataHandler(this.ucDataButtonUser_InsertHander);
            this.ucDataButtonUser.EditHandler += new ucDataButton.DataHandler(this.ucDataButtonUser_EditHandler);
            this.ucDataButtonUser.SaveHandler += new ucDataButton.DataHandler(this.ucDataButtonUser_SaveHandler);
            this.ucDataButtonUser.DeleteHandler += new ucDataButton.DataHandler(this.ucDataButtonUser_DeleteHandler);
            this.ucDataButtonUser.CancelHandler += new ucDataButton.DataHandler(this.ucDataButtonUser_CancelHandler);
            this.ucDataButtonUser.CloseHandler += new ucDataButton.DataHandler(this.ucDataButtonUser_CloseHandler);
            // 
            // frmUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(697, 497);
            this.Controls.Add(this.groupBoxUserList);
            this.Controls.Add(this.grpUserInfo);
            this.Controls.Add(this.ucDataButtonUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài khoản người dùng";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.Shown += new System.EventHandler(this.frmUser_Shown);
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
            this.groupBoxUserList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonUser;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.CheckedListBox chkLstGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtLockedReason;
        private System.Windows.Forms.CheckBox chkLocked;
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
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeadlineOfUsing;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LockedUser;
        private System.Windows.Forms.Button buttonResetPassword;
    }
}