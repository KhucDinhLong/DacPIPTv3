namespace PIPT.Agency
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
            this.rememberCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.optionButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginGroupBox
            // 
            this.loginGroupBox.Controls.Add(this.pictureBox1);
            this.loginGroupBox.Controls.Add(this.rememberCheckBox);
            this.loginGroupBox.Controls.Add(this.passwordTextBox);
            this.loginGroupBox.Controls.Add(this.usernameTextBox);
            this.loginGroupBox.Controls.Add(this.passwordLabel);
            this.loginGroupBox.Controls.Add(this.userNameLabel);
            this.loginGroupBox.Controls.Add(this.exitButton);
            this.loginGroupBox.Controls.Add(this.optionButton);
            this.loginGroupBox.Controls.Add(this.loginButton);
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
            this.pictureBox1.Image = global::PIPT.Agency.Properties.Resources.users;
            this.pictureBox1.Location = new System.Drawing.Point(25, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // rememberCheckBox
            // 
            this.rememberCheckBox.AutoSize = true;
            this.rememberCheckBox.Enabled = false;
            this.rememberCheckBox.Location = new System.Drawing.Point(189, 87);
            this.rememberCheckBox.Name = "rememberCheckBox";
            this.rememberCheckBox.Size = new System.Drawing.Size(171, 20);
            this.rememberCheckBox.TabIndex = 2;
            this.rememberCheckBox.Text = "Nhớ thông tin đăng nhập";
            this.rememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(189, 55);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '•';
            this.passwordTextBox.Size = new System.Drawing.Size(168, 23);
            this.passwordTextBox.TabIndex = 1;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(189, 23);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(168, 23);
            this.usernameTextBox.TabIndex = 0;
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
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(285, 115);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(72, 34);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Thoát";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // optionButton
            // 
            this.optionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.optionButton.Location = new System.Drawing.Point(12, 115);
            this.optionButton.Name = "optionButton";
            this.optionButton.Size = new System.Drawing.Size(72, 34);
            this.optionButton.TabIndex = 5;
            this.optionButton.Text = "Tùy chọn";
            this.optionButton.UseVisualStyleBackColor = true;
            this.optionButton.Visible = false;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(189, 115);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(91, 34);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Đăng nhập";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.loginButton;
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
        private System.Windows.Forms.CheckBox rememberCheckBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button optionButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}