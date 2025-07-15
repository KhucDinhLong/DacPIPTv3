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
            this.tsmiGrantStock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDatabaseBackupRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.frmDacLogBook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCatalogue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacAgency = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacStore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacProductGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacSellCount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacFactory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPacking = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacPackageGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacLockPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacProductWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacDistributeToAgency = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacDistributeToStore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacChecking = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacGetSerial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacGetData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacInsertSerial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacDeleteCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacDistributeToFactory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDacLockDistributor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportExportInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportExportInfoToStore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCompareImportExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportImExStock = new System.Windows.Forms.ToolStripMenuItem();
            this.theoSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportByStock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportByStamp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWarehouseTatal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportFactory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportActivateAddingPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.miRefactor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSystem,
            this.tsmiCatalogue,
            this.tsmiPacking,
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
            this.tsmiGrantStock,
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
            // tsmiGrantStock
            // 
            this.tsmiGrantStock.Name = "tsmiGrantStock";
            this.tsmiGrantStock.Size = new System.Drawing.Size(270, 22);
            this.tsmiGrantStock.Tag = "frmGrantStock";
            this.tsmiGrantStock.Text = "Phân quyền cho người dùng kho";
            this.tsmiGrantStock.Click += new System.EventHandler(this.MenuItems_Click);
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
            // tsmiPacking
            // 
            this.tsmiPacking.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDacPackageGroup,
            this.tsmiDacPackage,
            this.tsmiDacContainer,
            this.tsmiDacLockPackage});
            this.tsmiPacking.Name = "tsmiPacking";
            this.tsmiPacking.Size = new System.Drawing.Size(131, 20);
            this.tsmiPacking.Text = "Đóng gói sản phẩm";
            // 
            // tsmiDacPackageGroup
            // 
            this.tsmiDacPackageGroup.Name = "tsmiDacPackageGroup";
            this.tsmiDacPackageGroup.Size = new System.Drawing.Size(189, 22);
            this.tsmiDacPackageGroup.Tag = "frmDacPackageGroup";
            this.tsmiDacPackageGroup.Text = "Đóng thùng theo bó";
            this.tsmiDacPackageGroup.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacPackage
            // 
            this.tsmiDacPackage.Name = "tsmiDacPackage";
            this.tsmiDacPackage.Size = new System.Drawing.Size(189, 22);
            this.tsmiDacPackage.Tag = "frmDacPackage";
            this.tsmiDacPackage.Text = "Đóng thùng";
            this.tsmiDacPackage.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacContainer
            // 
            this.tsmiDacContainer.Name = "tsmiDacContainer";
            this.tsmiDacContainer.Size = new System.Drawing.Size(189, 22);
            this.tsmiDacContainer.Tag = "frmDacContainer";
            this.tsmiDacContainer.Text = "Đóng kiện";
            this.tsmiDacContainer.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacLockPackage
            // 
            this.tsmiDacLockPackage.Name = "tsmiDacLockPackage";
            this.tsmiDacLockPackage.Size = new System.Drawing.Size(189, 22);
            this.tsmiDacLockPackage.Tag = "frmDacLockPackage";
            this.tsmiDacLockPackage.Text = "Khóa đóng thùng";
            this.tsmiDacLockPackage.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiTools
            // 
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDacProductWarehouse,
            this.tsmiDacDistributeToAgency,
            this.tsmiDacDistributeToStore,
            this.tsmiDacChecking,
            this.tsmiDacGetSerial,
            this.tsmiDacGetData,
            this.tsmiDacInsertSerial,
            this.tsmiDacDeleteCode,
            this.tsmiDacDistributeToFactory,
            this.tsmiDacLockDistributor,
            this.tsmiInventory});
            this.tsmiTools.Name = "tsmiTools";
            this.tsmiTools.Size = new System.Drawing.Size(123, 20);
            this.tsmiTools.Text = "Quản lý sản phẩm";
            // 
            // tsmiDacProductWarehouse
            // 
            this.tsmiDacProductWarehouse.Name = "tsmiDacProductWarehouse";
            this.tsmiDacProductWarehouse.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacProductWarehouse.Tag = "frmDacProductWarehouse";
            this.tsmiDacProductWarehouse.Text = "Nhập kho";
            this.tsmiDacProductWarehouse.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacDistributeToAgency
            // 
            this.tsmiDacDistributeToAgency.Name = "tsmiDacDistributeToAgency";
            this.tsmiDacDistributeToAgency.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacDistributeToAgency.Tag = "frmDacDistributeToAgency";
            this.tsmiDacDistributeToAgency.Text = "Xuất hàng cho ĐL";
            this.tsmiDacDistributeToAgency.Click += new System.EventHandler(this.MenuItems_Click);
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
            // tsmiDacGetData
            // 
            this.tsmiDacGetData.Name = "tsmiDacGetData";
            this.tsmiDacGetData.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacGetData.Tag = "frmDacGetData";
            this.tsmiDacGetData.Text = "Nhận dữ liệu";
            this.tsmiDacGetData.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacInsertSerial
            // 
            this.tsmiDacInsertSerial.Name = "tsmiDacInsertSerial";
            this.tsmiDacInsertSerial.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacInsertSerial.Tag = "frmDacInsertSerial";
            this.tsmiDacInsertSerial.Text = "Nhập số Serial";
            this.tsmiDacInsertSerial.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacDeleteCode
            // 
            this.tsmiDacDeleteCode.Name = "tsmiDacDeleteCode";
            this.tsmiDacDeleteCode.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacDeleteCode.Tag = "frmDacDeleteCode";
            this.tsmiDacDeleteCode.Text = "Xóa mã QRCode";
            this.tsmiDacDeleteCode.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacDistributeToFactory
            // 
            this.tsmiDacDistributeToFactory.Name = "tsmiDacDistributeToFactory";
            this.tsmiDacDistributeToFactory.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacDistributeToFactory.Tag = "frmDacDistributeToFactory";
            this.tsmiDacDistributeToFactory.Text = "Xuất cho xưởng";
            this.tsmiDacDistributeToFactory.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiDacLockDistributor
            // 
            this.tsmiDacLockDistributor.Name = "tsmiDacLockDistributor";
            this.tsmiDacLockDistributor.Size = new System.Drawing.Size(183, 22);
            this.tsmiDacLockDistributor.Tag = "frmDacLockDistributor";
            this.tsmiDacLockDistributor.Text = "Khóa lệnh";
            this.tsmiDacLockDistributor.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiInventory
            // 
            this.tsmiInventory.Name = "tsmiInventory";
            this.tsmiInventory.Size = new System.Drawing.Size(183, 22);
            this.tsmiInventory.Tag = "frmDacInventory";
            this.tsmiInventory.Text = "Tồn kho theo năm";
            this.tsmiInventory.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReport
            // 
            this.tsmiReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReportWarehouse,
            this.tsmiReportExportInfo,
            this.tsmiReportExportInfoToStore,
            this.tsmiCompareImportExport,
            this.tsmiReportImExStock,
            this.tsmiWarehouseTatal,
            this.tsmiReportPackage,
            this.tsmiReportContainer,
            this.tsmiReportFactory,
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
            // tsmiReportExportInfoToStore
            // 
            this.tsmiReportExportInfoToStore.Name = "tsmiReportExportInfoToStore";
            this.tsmiReportExportInfoToStore.Size = new System.Drawing.Size(189, 22);
            this.tsmiReportExportInfoToStore.Tag = "frmReportExportInfoToStore";
            this.tsmiReportExportInfoToStore.Text = "SP đã xuất cho CH";
            this.tsmiReportExportInfoToStore.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiCompareImportExport
            // 
            this.tsmiCompareImportExport.Name = "tsmiCompareImportExport";
            this.tsmiCompareImportExport.Size = new System.Drawing.Size(189, 22);
            this.tsmiCompareImportExport.Tag = "frmCompareImportExport";
            this.tsmiCompareImportExport.Text = "Đối chiếu nhập xuất";
            this.tsmiCompareImportExport.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReportImExStock
            // 
            this.tsmiReportImExStock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theoSảnPhẩmToolStripMenuItem,
            this.tsmiReportByStock,
            this.tsmiReportByStamp});
            this.tsmiReportImExStock.Name = "tsmiReportImExStock";
            this.tsmiReportImExStock.Size = new System.Drawing.Size(189, 22);
            this.tsmiReportImExStock.Tag = "";
            this.tsmiReportImExStock.Text = "Nhập xuất tồn";
            this.tsmiReportImExStock.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // theoSảnPhẩmToolStripMenuItem
            // 
            this.theoSảnPhẩmToolStripMenuItem.Name = "theoSảnPhẩmToolStripMenuItem";
            this.theoSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.theoSảnPhẩmToolStripMenuItem.Tag = "frmReportImExStock";
            this.theoSảnPhẩmToolStripMenuItem.Text = "Theo sản phẩm";
            this.theoSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReportByStock
            // 
            this.tsmiReportByStock.Name = "tsmiReportByStock";
            this.tsmiReportByStock.Size = new System.Drawing.Size(165, 22);
            this.tsmiReportByStock.Tag = "frmReportImExStockBaseStock";
            this.tsmiReportByStock.Text = "Theo kho";
            this.tsmiReportByStock.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReportByStamp
            // 
            this.tsmiReportByStamp.Name = "tsmiReportByStamp";
            this.tsmiReportByStamp.Size = new System.Drawing.Size(165, 22);
            this.tsmiReportByStamp.Tag = "frmReportImExStockInThisYear";
            this.tsmiReportByStamp.Text = "Theo tem";
            this.tsmiReportByStamp.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiWarehouseTatal
            // 
            this.tsmiWarehouseTatal.Name = "tsmiWarehouseTatal";
            this.tsmiWarehouseTatal.Size = new System.Drawing.Size(189, 22);
            this.tsmiWarehouseTatal.Tag = "frmWarehouseTatal";
            this.tsmiWarehouseTatal.Text = "Báo cáo tổng hợp";
            this.tsmiWarehouseTatal.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReportPackage
            // 
            this.tsmiReportPackage.Name = "tsmiReportPackage";
            this.tsmiReportPackage.Size = new System.Drawing.Size(189, 22);
            this.tsmiReportPackage.Tag = "frmReportPackage";
            this.tsmiReportPackage.Text = "Báo cáo đóng thùng";
            this.tsmiReportPackage.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReportContainer
            // 
            this.tsmiReportContainer.Name = "tsmiReportContainer";
            this.tsmiReportContainer.Size = new System.Drawing.Size(189, 22);
            this.tsmiReportContainer.Tag = "frmReportContainer";
            this.tsmiReportContainer.Text = "Báo cáo đóng kiện";
            this.tsmiReportContainer.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReportFactory
            // 
            this.tsmiReportFactory.Name = "tsmiReportFactory";
            this.tsmiReportFactory.Size = new System.Drawing.Size(189, 22);
            this.tsmiReportFactory.Tag = "frmReportFactory";
            this.tsmiReportFactory.Text = "Xuất cho XSX";
            this.tsmiReportFactory.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // tsmiReportActivateAddingPoint
            // 
            this.tsmiReportActivateAddingPoint.Name = "tsmiReportActivateAddingPoint";
            this.tsmiReportActivateAddingPoint.Size = new System.Drawing.Size(189, 22);
            this.tsmiReportActivateAddingPoint.Tag = "frmReportActivateAddingPoint";
            this.tsmiReportActivateAddingPoint.Text = "Kích hoạt tích điểm";
            this.tsmiReportActivateAddingPoint.Click += new System.EventHandler(this.MenuItems_Click);
            // 
            // miRefactor
            // 
            this.miRefactor.Name = "miRefactor";
            this.miRefactor.Size = new System.Drawing.Size(187, 22);
            this.miRefactor.Tag = "frmRefactor";
            this.miRefactor.Text = "Tái cấu trúc dữ liệu";
            this.miRefactor.Click += new System.EventHandler(this.MenuItems_Click);
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
        private System.Windows.Forms.ToolStripMenuItem tsmiDacDistributeToStore;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacChecking;
        private System.Windows.Forms.ToolStripMenuItem tsmiReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportExportInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiWarehouseTatal;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacGetSerial;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacRegion;
        private System.Windows.Forms.ToolStripMenuItem tsmiDatabaseBackupRestore;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacInsertSerial;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacGetData;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacProductWarehouse;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportWarehouse;
        private System.Windows.Forms.ToolStripMenuItem frmDacLogBook;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportExportInfoToStore;
        private System.Windows.Forms.ToolStripMenuItem tsmiPacking;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacPackage;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacContainer;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacDeleteCode;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportPackage;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportContainer;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacFactory;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacDistributeToFactory;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportFactory;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportImExStock;
        private System.Windows.Forms.ToolStripMenuItem tsmiCompareImportExport;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacLockDistributor;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportActivateAddingPoint;
        private System.Windows.Forms.ToolStripMenuItem tsmiStock;
        private System.Windows.Forms.ToolStripMenuItem tsmiGrantStock;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacPackageGroup;
        private System.Windows.Forms.ToolStripMenuItem theoSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportByStock;
        private System.Windows.Forms.ToolStripMenuItem tsmiInventory;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportByStamp;
        private System.Windows.Forms.ToolStripMenuItem tsmiDacLockPackage;
        private System.Windows.Forms.ToolStripMenuItem miRefactor;
    }
}

