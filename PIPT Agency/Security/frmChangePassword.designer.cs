namespace PIPT.Agency
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.userNameLabel = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.oldPasswordLabel = new System.Windows.Forms.Label();
            this.textBoxOldPassword = new System.Windows.Forms.TextBox();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.confirmNewPasswordLabel = new System.Windows.Forms.Label();
            this.textBoxConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.groupBoxPassword = new System.Windows.Forms.GroupBox();
            this.ucDataButtonChangePassword = new PIPT.Agency.ucDataButton();
            this.groupBoxPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(78, 25);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(64, 16);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "Tài khoản";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Enabled = false;
            this.textBoxUserName.Location = new System.Drawing.Point(156, 22);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(222, 23);
            this.textBoxUserName.TabIndex = 0;
            // 
            // oldPasswordLabel
            // 
            this.oldPasswordLabel.AutoSize = true;
            this.oldPasswordLabel.Location = new System.Drawing.Point(65, 54);
            this.oldPasswordLabel.Name = "oldPasswordLabel";
            this.oldPasswordLabel.Size = new System.Drawing.Size(77, 16);
            this.oldPasswordLabel.TabIndex = 0;
            this.oldPasswordLabel.Text = "Mật khẩu cũ";
            this.oldPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.Location = new System.Drawing.Point(156, 51);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.Size = new System.Drawing.Size(222, 23);
            this.textBoxOldPassword.TabIndex = 1;
            this.textBoxOldPassword.UseSystemPasswordChar = true;
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(57, 86);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(85, 16);
            this.newPasswordLabel.TabIndex = 0;
            this.newPasswordLabel.Text = "Mật khẩu mới";
            this.newPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(156, 79);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(222, 23);
            this.textBoxNewPassword.TabIndex = 2;
            this.textBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // confirmNewPasswordLabel
            // 
            this.confirmNewPasswordLabel.AutoSize = true;
            this.confirmNewPasswordLabel.Location = new System.Drawing.Point(6, 111);
            this.confirmNewPasswordLabel.Name = "confirmNewPasswordLabel";
            this.confirmNewPasswordLabel.Size = new System.Drawing.Size(136, 16);
            this.confirmNewPasswordLabel.TabIndex = 0;
            this.confirmNewPasswordLabel.Text = "Nhập lại mật khẩu mới";
            this.confirmNewPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxConfirmNewPassword
            // 
            this.textBoxConfirmNewPassword.Location = new System.Drawing.Point(156, 108);
            this.textBoxConfirmNewPassword.Name = "textBoxConfirmNewPassword";
            this.textBoxConfirmNewPassword.Size = new System.Drawing.Size(222, 23);
            this.textBoxConfirmNewPassword.TabIndex = 3;
            this.textBoxConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // groupBoxPassword
            // 
            this.groupBoxPassword.Controls.Add(this.ucDataButtonChangePassword);
            this.groupBoxPassword.Controls.Add(this.textBoxUserName);
            this.groupBoxPassword.Controls.Add(this.textBoxConfirmNewPassword);
            this.groupBoxPassword.Controls.Add(this.userNameLabel);
            this.groupBoxPassword.Controls.Add(this.confirmNewPasswordLabel);
            this.groupBoxPassword.Controls.Add(this.oldPasswordLabel);
            this.groupBoxPassword.Controls.Add(this.textBoxNewPassword);
            this.groupBoxPassword.Controls.Add(this.textBoxOldPassword);
            this.groupBoxPassword.Controls.Add(this.newPasswordLabel);
            this.groupBoxPassword.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPassword.Name = "groupBoxPassword";
            this.groupBoxPassword.Size = new System.Drawing.Size(384, 182);
            this.groupBoxPassword.TabIndex = 2;
            this.groupBoxPassword.TabStop = false;
            this.groupBoxPassword.Text = "Thông tin thay đổi mật khẩu";
            // 
            // ucDataButtonChangePassword
            // 
            this.ucDataButtonChangePassword.AddNewVisible = false;
            this.ucDataButtonChangePassword.CancelVisible = false;
            this.ucDataButtonChangePassword.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonChangePassword.DeleteVisible = false;
            this.ucDataButtonChangePassword.EditVisible = false;
            this.ucDataButtonChangePassword.ExcelVisible = false;
            this.ucDataButtonChangePassword.IsContitnue = true;
            this.ucDataButtonChangePassword.LanguageVisible = false;
            this.ucDataButtonChangePassword.Location = new System.Drawing.Point(78, 137);
            this.ucDataButtonChangePassword.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonChangePassword.MinimumSize = new System.Drawing.Size(300, 34);
            this.ucDataButtonChangePassword.MultiLanguageVisible = true;
            this.ucDataButtonChangePassword.Name = "ucDataButtonChangePassword";
            this.ucDataButtonChangePassword.PrintVisible = false;
            this.ucDataButtonChangePassword.ReportVisible = false;
            this.ucDataButtonChangePassword.SaveVisible = true;
            this.ucDataButtonChangePassword.Size = new System.Drawing.Size(300, 34);
            this.ucDataButtonChangePassword.TabIndex = 3;
            this.ucDataButtonChangePassword.SaveHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonChangePassword_SaveHandler);
            this.ucDataButtonChangePassword.CloseHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonChangePassword_CloseHandler);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 202);
            this.Controls.Add(this.groupBoxPassword);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.groupBoxPassword.ResumeLayout(false);
            this.groupBoxPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label oldPasswordLabel;
        private System.Windows.Forms.TextBox textBoxOldPassword;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label confirmNewPasswordLabel;
        private System.Windows.Forms.TextBox textBoxConfirmNewPassword;
        private System.Windows.Forms.GroupBox groupBoxPassword;
        private ucDataButton ucDataButtonChangePassword;
    }
}