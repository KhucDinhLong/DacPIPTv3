namespace PIPT
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
            this.tsmiSecurity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAuthorization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDatabaseBackupRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.frmDacLogBook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.miRefactor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCatalogue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacAgency = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacStore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacProductGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacSellCount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacFactory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacProductWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacDistributeToAgency = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacChecking = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacGetSerial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacDeleteCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportExportInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportActivateAddingPoint = new System.Windows.Forms.ToolStripMenuItem();
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
            this.frmDacLogBook,
            this.tsmiClose,
            this.miRefactor});
            this.tsmiSystem.Name = "tsmiSystem";
            this.tsmiSystem.Size = new System.Drawing.Size(71, 20);
            this.tsmiSystem.Text = "Hệ thống";
            // 
            // tsmiLogOff
            // 
            this.tsmiLogOff.Name = "tsmiLogOff";
            this.tsmiLogOff.Size = new System.Drawing.Size(187, 22);
            this.tsmiLogOff.Tag = "tsmiLogOff";
            this.tsmiLogOff.Text = "Đăng xuất";
            this.tsmiLogOff.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiChangePassword
            // 
            this.tsmiChangePassword.Name = "tsmiChangePassword";
            this.tsmiChangePassword.Size = new System.Drawing.Size(187, 22);
            this.tsmiChangePassword.Tag = "frmChangePassword";
            this.tsmiChangePassword.Text = "Đổi mật khẩu";
            this.tsmiChangePassword.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiConfig
            // 
            this.tsmiConfig.Name = "tsmiConfig";
            this.tsmiConfig.Size = new System.Drawing.Size(187, 22);
            this.tsmiConfig.Tag = "frmConfig";
            this.tsmiConfig.Text = "Cấu hình";
            this.tsmiConfig.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiSecurity
            // 
            this.tsmiSecurity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUser,
            this.tsmiGroup,
            this.tsmiAuthorization,
            this.tsmiUpdateMenu});
            this.tsmiSecurity.Name = "tsmiSecurity";
            this.tsmiSecurity.Size = new System.Drawing.Size(187, 22);
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
            // tsmiGroup
            // 
            this.tsmiGroup.Name = "tsmiGroup";
            this.tsmiGroup.Size = new System.Drawing.Size(270, 22);
            this.tsmiGroup.Tag = "frmGroup";
            this.tsmiGroup.Text = "Nhóm người dùng";
            this.tsmiGroup.Click += new System.EventHandler(this.MenuItems_Click);
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
            // tsmiDatabaseBackupRestore
            // 
            this.tsmiDatabaseBackupRestore.Name = "tsmiDatabaseBackupRestore";
            this.tsmiDatabaseBackupRestore.Size = new System.Drawing.Size(187, 22);
            this.tsmiDatabaseBackupRestore.Tag = "frmDacBackupRestore";
            this.tsmiDatabaseBackupRestore.Text = "Cơ sở dữ liệu";
            this.tsmiDatabaseBackupRestore.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // frmDacLogBook
            // 
            this.frmDacLogBook.Name = "frmDacLogBook";
            this.frmDacLogBook.Size = new System.Drawing.Size(187, 22);
            this.frmDacLogBook.Tag = "frmDacLogBook";
            this.frmDacLogBook.Text = "Lịch sử SD PM";
            this.frmDacLogBook.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(187, 22);
            this.tsmiClose.Tag = "tsmiClose";
            this.tsmiClose.Text = "Thoát";
            this.tsmiClose.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // miRefactor
            // 
            this.miRefactor.Name = "miRefactor";
            this.miRefactor.Size = new System.Drawing.Size(187, 22);
            this.miRefactor.Tag = "frmRefactor";
            this.miRefactor.Text = "Tái cấu trúc dữ liệu";
            this.miRefactor.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiCatalogue
            // 
            this.tsmiCatalogue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDacAgency,
            this.tsmiDacStore,
            this.tsmiDacProduct,
            this.tsmiDacRegion,
            this.tsmiDacProductGroup,
            this.tsmiDacSellCount,
            this.tsmiDacFactory,
            this.tsmiStock});
            this.tsmiCatalogue.Name = "tsmiCatalogue";
            this.tsmiCatalogue.Size = new System.Drawing.Size(77, 20);
            this.tsmiCatalogue.Text = "Danh mục";
            // 
            // tsmiDacAgency
            // 
            this.tsmiDacAgency.Name = "tsmiDacAgency";
            this.tsmiDacAgency.Size = new System.Drawing.Size(190, 22);
            this.tsmiDacAgency.Tag = "frmDacAgency";
            this.tsmiDacAgency.Text = "Đại lý";
            this.tsmiDacAgency.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacStore
            // 
            this.tsmiDacStore.Name = "tsmiDacStore";
            this.tsmiDacStore.Size = new System.Drawing.Size(190, 22);
            this.tsmiDacStore.Tag = "frmDacStore";
            this.tsmiDacStore.Text = "Cửa hàng";
            this.tsmiDacStore.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacProduct
            // 
            this.tsmiDacProduct.Name = "tsmiDacProduct";
            this.tsmiDacProduct.Size = new System.Drawing.Size(190, 22);
            this.tsmiDacProduct.Tag = "frmDacProduct";
            this.tsmiDacProduct.Text = "Sản phẩm";
            this.tsmiDacProduct.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacRegion
            // 
            this.tsmiDacRegion.Name = "tsmiDacRegion";
            this.tsmiDacRegion.Size = new System.Drawing.Size(190, 22);
            this.tsmiDacRegion.Tag = "frmDacRegion";
            this.tsmiDacRegion.Text = "Khu vực - Miền";
            this.tsmiDacRegion.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacProductGroup
            // 
            this.tsmiDacProductGroup.Name = "tsmiDacProductGroup";
            this.tsmiDacProductGroup.Size = new System.Drawing.Size(190, 22);
            this.tsmiDacProductGroup.Tag = "frmDacProductCategory";
            this.tsmiDacProductGroup.Text = "Nhóm sản phẩm";
            this.tsmiDacProductGroup.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacSellCount
            // 
            this.tsmiDacSellCount.Name = "tsmiDacSellCount";
            this.tsmiDacSellCount.Size = new System.Drawing.Size(190, 22);
            this.tsmiDacSellCount.Tag = "frmDacSellCount";
            this.tsmiDacSellCount.Text = "Sản phẩm tích điểm";
            this.tsmiDacSellCount.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacFactory
            // 
            this.tsmiDacFactory.Name = "tsmiDacFactory";
            this.tsmiDacFactory.Size = new System.Drawing.Size(190, 22);
            this.tsmiDacFactory.Tag = "frmDacFactory";
            this.tsmiDacFactory.Text = "Xưởng sản xuất";
            this.tsmiDacFactory.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiStock
            // 
            this.tsmiStock.Name = "tsmiStock";
            this.tsmiStock.Size = new System.Drawing.Size(190, 22);
            this.tsmiStock.Tag = "frmStock";
            this.tsmiStock.Text = "Kho hàng";
            this.tsmiStock.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiTools
            // 
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDacProductWarehouse,
            this.tsmiDacDistributeToAgency,
            this.tsmiDacChecking,
            this.tsmiDacGetSerial,
            this.tsmiDacDeleteCode,
            this.tsmiDacPackage});
            this.tsmiTools.Name = "tsmiTools";
            this.tsmiTools.Size = new System.Drawing.Size(123, 20);
            this.tsmiTools.Text = "Quản lý sản phẩm";
            // 
            // tsmiDacProductWarehouse
            // 
            this.tsmiDacProductWarehouse.Name = "tsmiDacProductWarehouse";
            this.tsmiDacProductWarehouse.Size = new System.Drawing.Size(170, 22);
            this.tsmiDacProductWarehouse.Tag = "frmDacProductWarehouse";
            this.tsmiDacProductWarehouse.Text = "Nhập kho";
            this.tsmiDacProductWarehouse.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacDistributeToAgency
            // 
            this.tsmiDacDistributeToAgency.Name = "tsmiDacDistributeToAgency";
            this.tsmiDacDistributeToAgency.Size = new System.Drawing.Size(170, 22);
            this.tsmiDacDistributeToAgency.Tag = "frmDacDistributeToAgency";
            this.tsmiDacDistributeToAgency.Text = "Xuất hàng";
            this.tsmiDacDistributeToAgency.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacChecking
            // 
            this.tsmiDacChecking.Name = "tsmiDacChecking";
            this.tsmiDacChecking.Size = new System.Drawing.Size(170, 22);
            this.tsmiDacChecking.Tag = "frmDacChecking";
            this.tsmiDacChecking.Text = "Kiểm tra";
            this.tsmiDacChecking.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacGetSerial
            // 
            this.tsmiDacGetSerial.Name = "tsmiDacGetSerial";
            this.tsmiDacGetSerial.Size = new System.Drawing.Size(170, 22);
            this.tsmiDacGetSerial.Tag = "frmDacGetSerial";
            this.tsmiDacGetSerial.Text = "Lấy số Serial";
            this.tsmiDacGetSerial.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacDeleteCode
            // 
            this.tsmiDacDeleteCode.Name = "tsmiDacDeleteCode";
            this.tsmiDacDeleteCode.Size = new System.Drawing.Size(170, 22);
            this.tsmiDacDeleteCode.Tag = "frmDacDeleteCode";
            this.tsmiDacDeleteCode.Text = "Xóa mã QRCode";
            this.tsmiDacDeleteCode.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacPackage
            // 
            this.tsmiDacPackage.Name = "tsmiDacPackage";
            this.tsmiDacPackage.Size = new System.Drawing.Size(170, 22);
            this.tsmiDacPackage.Tag = "frmDacPackage";
            this.tsmiDacPackage.Text = "Đóng thùng";
            // 
            // tsmiReport
            // 
            this.tsmiReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReportWarehouse,
            this.tsmiReportExportInfo,
            this.tsmiReportPackage,
            this.tsmiReportActivateAddingPoint});
            this.tsmiReport.Name = "tsmiReport";
            this.tsmiReport.Size = new System.Drawing.Size(65, 20);
            this.tsmiReport.Text = "Báo cáo";
            // 
            // tsmiReportWarehouse
            // 
            this.tsmiReportWarehouse.Name = "tsmiReportWarehouse";
            this.tsmiReportWarehouse.Size = new System.Drawing.Size(189, 22);
            this.tsmiReportWarehouse.Tag = "frmReportWarehouse";
            this.tsmiReportWarehouse.Text = "Sản phẩm đã nhập";
            this.tsmiReportWarehouse.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReportExportInfo
            // 
            this.tsmiReportExportInfo.Name = "tsmiReportExportInfo";
            this.tsmiReportExportInfo.Size = new System.Drawing.Size(189, 22);
            this.tsmiReportExportInfo.Tag = "frmReportExportInfo";
            this.tsmiReportExportInfo.Text = "Sản phẩm đã xuất";
            this.tsmiReportExportInfo.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReportPackage
            // 
            this.tsmiReportPackage.Name = "tsmiReportPackage";
            this.tsmiReportPackage.Size = new System.Drawing.Size(189, 22);
            this.tsmiReportPackage.Tag = "frmReportPackage";
            this.tsmiReportPackage.Text = "Báo cáo đóng thùng";
            this.tsmiReportPackage.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReportActivateAddingPoint
            // 
            this.tsmiReportActivateAddingPoint.Name = "tsmiReportActivateAddingPoint";
            this.tsmiReportActivateAddingPoint.Size = new System.Drawing.Size(189, 22);
            this.tsmiReportActivateAddingPoint.Tag = "frmReportActivateAddingPoint";
            this.tsmiReportActivateAddingPoint.Text = "Kích hoạt tích điểm";
            this.tsmiReportActivateAddingPoint.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 456);
            this.Controls.Add(this.menuMain);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dac PIPT - Kích hoạt tích điểm";
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
        private System.Windows.Forms.ToolStripMenuItem tsmiSecurity;
        private System.Windows.Forms.ToolStripMenuItem tsmiUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiAuthorization;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripMenuItem tsmiCatalogue;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacAgency;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacStore;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacProductGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacSellCount;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacDistributeToAgency;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacChecking;
        private System.Windows.Forms.ToolStripMenuItem tsmiReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportExportInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacGetSerial;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacRegion;
        private System.Windows.Forms.ToolStripMenuItem tsmiDatabaseBackupRestore;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacProductWarehouse;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportWarehouse;
        private System.Windows.Forms.ToolStripMenuItem frmDacLogBook;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacDeleteCode;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportPackage;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacFactory;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportActivateAddingPoint;
        private System.Windows.Forms.ToolStripMenuItem tsmiStock;
        private System.Windows.Forms.ToolStripMenuItem miRefactor;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacPackage;
    }
}

