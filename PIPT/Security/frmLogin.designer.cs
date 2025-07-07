namespace PIPT
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOption = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.loginGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginGroupBox
            // 
            this.loginGroupBox.Controls.Add(this.pictureBox1);
            this.loginGroupBox.Controls.Add(this.chkRemember);
            this.loginGroupBox.Controls.Add(this.txtPassword);
            this.loginGroupBox.Controls.Add(this.txtUserName);
            this.loginGroupBox.Controls.Add(this.passwordLabel);
            this.loginGroupBox.Controls.Add(this.userNameLabel);
            this.loginGroupBox.Controls.Add(this.btnExit);
            this.loginGroupBox.Controls.Add(this.btnOption);
            this.loginGroupBox.Controls.Add(this.btnLogin);
            this.loginGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginGroupBox.Location = new System.Drawing.Point(0, 0);
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.Size = new System.Drawing.Size(374, 166);
            this.loginGroupBox.TabIndex = 0;
            this.loginGroupBox.TabStop = false;
            this.loginGroupBox.Text = "Thông tin đăng nhập";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PIPT.Properties.Resources.users;
            this.pictureBox1.Location = new System.Drawing.Point(25, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Enabled = false;
            this.chkRemember.Location = new System.Drawing.Point(189, 87);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(171, 20);
            this.chkRemember.TabIndex = 2;
            this.chkRemember.Text = "Nhớ thông tin đăng nhập";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(189, 55);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(168, 23);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(189, 23);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(168, 23);
            this.txtUserName.TabIndex = 0;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(113, 61);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(65, 16);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Mật khẩu:";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(113, 29);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(71, 16);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "Tài khoản:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(285, 115);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 34);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // btnOption
            // 
            this.btnOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOption.Location = new System.Drawing.Point(12, 115);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(72, 34);
            this.btnOption.TabIndex = 5;
            this.btnOption.Text = "Tùy chọn";
            this.btnOption.UseVisualStyleBackColor = true;
            this.btnOption.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(189, 115);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(91, 34);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 166);
            this.Controls.Add(this.loginGroupBox);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.loginGroupBox.ResumeLayout(false);
            this.loginGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}