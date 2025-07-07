namespace PIPT.Agency
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.tsmiSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogOff = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDatabaseBackupRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCatalogue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacStore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacCatalogue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacProductUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacDistributeToStore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacChecking = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacGetSerial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacLogNotUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportExportInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWarehouseTatal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSecurity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAuthorization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacDeleteCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSystem,
            this.tsmiCatalogue,
            this.tsmiTools,
            this.tsmiReport});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuMain.Size = new System.Drawing.Size(767, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "Main Menu";
            // 
            // tsmiSystem
            // 
            this.tsmiSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLogOff,
            this.tsmiChangePassword,
            this.tsmiConfig,
            this.tsmiSecurity,
            this.tsmiDatabaseBackupRestore,
            this.tsmiClose});
            this.tsmiSystem.Name = "tsmiSystem";
            this.tsmiSystem.Size = new System.Drawing.Size(71, 20);
            this.tsmiSystem.Text = "Hệ thống";
            // 
            // tsmiLogOff
            // 
            this.tsmiLogOff.Name = "tsmiLogOff";
            this.tsmiLogOff.Size = new System.Drawing.Size(152, 22);
            this.tsmiLogOff.Tag = "tsmiLogOff";
            this.tsmiLogOff.Text = "Đăng xuất";
            this.tsmiLogOff.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiChangePassword
            // 
            this.tsmiChangePassword.Name = "tsmiChangePassword";
            this.tsmiChangePassword.Size = new System.Drawing.Size(152, 22);
            this.tsmiChangePassword.Tag = "frmChangePassword";
            this.tsmiChangePassword.Text = "Đổi mật khẩu";
            this.tsmiChangePassword.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiConfig
            // 
            this.tsmiConfig.Name = "tsmiConfig";
            this.tsmiConfig.Size = new System.Drawing.Size(152, 22);
            this.tsmiConfig.Tag = "frmConfig";
            this.tsmiConfig.Text = "Cấu hình";
            this.tsmiConfig.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDatabaseBackupRestore
            // 
            this.tsmiDatabaseBackupRestore.Name = "tsmiDatabaseBackupRestore";
            this.tsmiDatabaseBackupRestore.Size = new System.Drawing.Size(152, 22);
            this.tsmiDatabaseBackupRestore.Tag = "frmDacBackupRestore";
            this.tsmiDatabaseBackupRestore.Text = "Cơ sở dữ liệu";
            this.tsmiDatabaseBackupRestore.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(152, 22);
            this.tsmiClose.Tag = "tsmiClose";
            this.tsmiClose.Text = "Thoát";
            this.tsmiClose.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiCatalogue
            // 
            this.tsmiCatalogue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDacStore,
            this.tsmiDacCatalogue,
            this.tsmiDacProduct,
            this.tsmiDacProductUnit});
            this.tsmiCatalogue.Name = "tsmiCatalogue";
            this.tsmiCatalogue.Size = new System.Drawing.Size(77, 20);
            this.tsmiCatalogue.Text = "Danh mục";
            // 
            // tsmiDacStore
            // 
            this.tsmiDacStore.Name = "tsmiDacStore";
            this.tsmiDacStore.Size = new System.Drawing.Size(169, 22);
            this.tsmiDacStore.Tag = "frmDacStore";
            this.tsmiDacStore.Text = "Cửa hàng";
            this.tsmiDacStore.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacCatalogue
            // 
            this.tsmiDacCatalogue.Name = "tsmiDacCatalogue";
            this.tsmiDacCatalogue.Size = new System.Drawing.Size(169, 22);
            this.tsmiDacCatalogue.Tag = "frmDacCatalogue";
            this.tsmiDacCatalogue.Text = "Nhóm sản phẩm";
            this.tsmiDacCatalogue.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacProduct
            // 
            this.tsmiDacProduct.Name = "tsmiDacProduct";
            this.tsmiDacProduct.Size = new System.Drawing.Size(169, 22);
            this.tsmiDacProduct.Tag = "frmDacProduct";
            this.tsmiDacProduct.Text = "Sản phẩm";
            this.tsmiDacProduct.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacProductUnit
            // 
            this.tsmiDacProductUnit.Name = "tsmiDacProductUnit";
            this.tsmiDacProductUnit.Size = new System.Drawing.Size(169, 22);
            this.tsmiDacProductUnit.Tag = "frmDacProductUnit";
            this.tsmiDacProductUnit.Text = "Đơn vị";
            this.tsmiDacProductUnit.Visible = false;
            this.tsmiDacProductUnit.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiTools
            // 
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDacDistributeToStore,
            this.tsmiDacChecking,
            this.tsmiDacGetSerial,
            this.tsmiDacLogNotUpload,
            this.tsmiDacDeleteCode});
            this.tsmiTools.Name = "tsmiTools";
            this.tsmiTools.Size = new System.Drawing.Size(123, 20);
            this.tsmiTools.Text = "Quản lý sản phẩm";
            // 
            // tsmiDacDistributeToStore
            // 
            this.tsmiDacDistributeToStore.Name = "tsmiDacDistributeToStore";
            this.tsmiDacDistributeToStore.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacDistributeToStore.Tag = "frmDacDistributeToStore";
            this.tsmiDacDistributeToStore.Text = "Xuất cho cửa hàng";
            this.tsmiDacDistributeToStore.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacChecking
            // 
            this.tsmiDacChecking.Name = "tsmiDacChecking";
            this.tsmiDacChecking.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacChecking.Tag = "frmDacChecking";
            this.tsmiDacChecking.Text = "Kiểm tra";
            this.tsmiDacChecking.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacGetSerial
            // 
            this.tsmiDacGetSerial.Name = "tsmiDacGetSerial";
            this.tsmiDacGetSerial.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacGetSerial.Tag = "frmDacGetSerial";
            this.tsmiDacGetSerial.Text = "Lấy số Serial";
            this.tsmiDacGetSerial.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacLogNotUpload
            // 
            this.tsmiDacLogNotUpload.Name = "tsmiDacLogNotUpload";
            this.tsmiDacLogNotUpload.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacLogNotUpload.Tag = "frmDacLogNotUpload";
            this.tsmiDacLogNotUpload.Text = "Lịch sử Upload";
            this.tsmiDacLogNotUpload.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReport
            // 
            this.tsmiReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReportExportInfo,
            this.tsmiWarehouseTatal});
            this.tsmiReport.Name = "tsmiReport";
            this.tsmiReport.Size = new System.Drawing.Size(65, 20);
            this.tsmiReport.Text = "Báo cáo";
            // 
            // tsmiReportExportInfo
            // 
            this.tsmiReportExportInfo.Name = "tsmiReportExportInfo";
            this.tsmiReportExportInfo.Size = new System.Drawing.Size(180, 22);
            this.tsmiReportExportInfo.Tag = "frmReportExportInfo";
            this.tsmiReportExportInfo.Text = "Sản phẩm đã xuất";
            this.tsmiReportExportInfo.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiWarehouseTatal
            // 
            this.tsmiWarehouseTatal.Name = "tsmiWarehouseTatal";
            this.tsmiWarehouseTatal.Size = new System.Drawing.Size(180, 22);
            this.tsmiWarehouseTatal.Tag = "frmWarehouseTatal";
            this.tsmiWarehouseTatal.Text = "Báo cáo tổng hợp";
            this.tsmiWarehouseTatal.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiSecurity
            // 
            this.tsmiSecurity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUser,
            this.tsmiAuthorization,
            this.tsmiUpdateMenu});
            this.tsmiSecurity.Name = "tsmiSecurity";
            this.tsmiSecurity.Size = new System.Drawing.Size(152, 22);
            this.tsmiSecurity.Text = "Quản lý";
            // 
            // tsmiUser
            // 
            this.tsmiUser.Name = "tsmiUser";
            this.tsmiUser.Size = new System.Drawing.Size(270, 22);
            this.tsmiUser.Tag = "frmUser";
            this.tsmiUser.Text = "Người dùng";
            this.tsmiUser.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiAuthorization
            // 
            this.tsmiAuthorization.Name = "tsmiAuthorization";
            this.tsmiAuthorization.Size = new System.Drawing.Size(270, 22);
            this.tsmiAuthorization.Tag = "frmAuthorization";
            this.tsmiAuthorization.Text = "Phân quyền cho nhóm người dùng";
            this.tsmiAuthorization.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiUpdateMenu
            // 
            this.tsmiUpdateMenu.Name = "tsmiUpdateMenu";
            this.tsmiUpdateMenu.Size = new System.Drawing.Size(270, 22);
            this.tsmiUpdateMenu.Tag = "frmUpdateMenu";
            this.tsmiUpdateMenu.Text = "Cập nhật menu";
            this.tsmiUpdateMenu.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacDeleteCode
            // 
            this.tsmiDacDeleteCode.Name = "tsmiDacDeleteCode";
            this.tsmiDacDeleteCode.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacDeleteCode.Tag = "frmDacDeleteCode";
            this.tsmiDacDeleteCode.Text = "Xóa mã QRCode";
            this.tsmiDacDeleteCode.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 361);
            this.Controls.Add(this.menuMain);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dac PIPT Agency";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSystem;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogOff;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePassword;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripMenuItem tsmiCatalogue;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacStore;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacCatalogue;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacProductUnit;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacDistributeToStore;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacChecking;
        private System.Windows.Forms.ToolStripMenuItem tsmiReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportExportInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiWarehouseTatal;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacGetSerial;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmiDatabaseBackupRestore;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacLogNotUpload;
        private System.Windows.Forms.ToolStripMenuItem tsmiSecurity;
        private System.Windows.Forms.ToolStripMenuItem tsmiUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiAuthorization;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacDeleteCode;
    }
}

