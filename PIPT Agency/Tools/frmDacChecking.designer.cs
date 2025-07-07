namespace PIPT.Agency
{
    partial class frmDacChecking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacChecking));
            this.textBoxDacCode = new System.Windows.Forms.TextBox();
            this.panelChecking = new System.Windows.Forms.Panel();
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.textBoxProductManufacture = new System.Windows.Forms.TextBox();
            this.labelManufacture = new System.Windows.Forms.Label();
            this.textBoxProductGeneralFormat = new System.Windows.Forms.TextBox();
            this.textBoxProductRegisterNumber = new System.Windows.Forms.TextBox();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.labelGeneralFormat = new System.Windows.Forms.Label();
            this.labelRegisterNumber = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.textBoxProductCategory = new System.Windows.Forms.TextBox();
            this.labelProductCategory = new System.Windows.Forms.Label();
            this.textBoxProductCode = new System.Windows.Forms.TextBox();
            this.labelProductCode = new System.Windows.Forms.Label();
            this.groupBoxStore = new System.Windows.Forms.GroupBox();
            this.textBoxStoreExportedDate = new System.Windows.Forms.TextBox();
            this.labelStoreExportedDate = new System.Windows.Forms.Label();
            this.textBoxStorePCode = new System.Windows.Forms.TextBox();
            this.labelStorePCode = new System.Windows.Forms.Label();
            this.textBoxStoreEmail = new System.Windows.Forms.TextBox();
            this.labelStoreEmail = new System.Windows.Forms.Label();
            this.textBoxStoreMobile = new System.Windows.Forms.TextBox();
            this.labelStoreMobile = new System.Windows.Forms.Label();
            this.textBoxStoreOwner = new System.Windows.Forms.TextBox();
            this.labelStoreOwner = new System.Windows.Forms.Label();
            this.textBoxStoreAddress = new System.Windows.Forms.TextBox();
            this.labelStoreAddress = new System.Windows.Forms.Label();
            this.textBoxStoreName = new System.Windows.Forms.TextBox();
            this.labelStoreName = new System.Windows.Forms.Label();
            this.textBoxStoreCode = new System.Windows.Forms.TextBox();
            this.labelStoreCode = new System.Windows.Forms.Label();
            this.groupBoxAgency = new System.Windows.Forms.GroupBox();
            this.textBoxAgencyPCode = new System.Windows.Forms.TextBox();
            this.labelAgencyPCode = new System.Windows.Forms.Label();
            this.textBoxAgencyDependCode = new System.Windows.Forms.TextBox();
            this.labelDependCode = new System.Windows.Forms.Label();
            this.textBoxAgencyRegion = new System.Windows.Forms.TextBox();
            this.labelRegion = new System.Windows.Forms.Label();
            this.textBoxAgencyProvince = new System.Windows.Forms.TextBox();
            this.labelAgencyProvince = new System.Windows.Forms.Label();
            this.textBoxAgencyEmail = new System.Windows.Forms.TextBox();
            this.labelAgencyEmail = new System.Windows.Forms.Label();
            this.textBoxAgencyExportedDate = new System.Windows.Forms.TextBox();
            this.labelAgencyExportedDate = new System.Windows.Forms.Label();
            this.textBoxAgencyTaxCode = new System.Windows.Forms.TextBox();
            this.labelTaxCode = new System.Windows.Forms.Label();
            this.textBoxAgencyPhoneNum = new System.Windows.Forms.TextBox();
            this.labelPhoneNum = new System.Windows.Forms.Label();
            this.textBoxAgencyMobile = new System.Windows.Forms.TextBox();
            this.labelAgencyMobile = new System.Windows.Forms.Label();
            this.textBoxAgencyJoinContact = new System.Windows.Forms.TextBox();
            this.labelJoinContact = new System.Windows.Forms.Label();
            this.textBoxAgencyOwner = new System.Windows.Forms.TextBox();
            this.labelAgencyOwner = new System.Windows.Forms.Label();
            this.textBoxAgencyAddress = new System.Windows.Forms.TextBox();
            this.labelAgencyAddress = new System.Windows.Forms.Label();
            this.textBoxAgencyName = new System.Windows.Forms.TextBox();
            this.labelAgencyName = new System.Windows.Forms.Label();
            this.textBoxAgencyCode = new System.Windows.Forms.TextBox();
            this.labelAgencyCode = new System.Windows.Forms.Label();
            this.labelChecking = new System.Windows.Forms.Label();
            this.labelAgency = new System.Windows.Forms.Label();
            this.buttonChecking = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.panelChecking.SuspendLayout();
            this.groupBoxProduct.SuspendLayout();
            this.groupBoxStore.SuspendLayout();
            this.groupBoxAgency.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDacCode
            // 
            this.textBoxDacCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDacCode.Location = new System.Drawing.Point(178, 10);
            this.textBoxDacCode.Name = "textBoxDacCode";
            this.textBoxDacCode.Size = new System.Drawing.Size(234, 21);
            this.textBoxDacCode.TabIndex = 0;
            this.textBoxDacCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDacCode_KeyPress);
            // 
            // panelChecking
            // 
            this.panelChecking.Controls.Add(this.groupBoxProduct);
            this.panelChecking.Controls.Add(this.groupBoxStore);
            this.panelChecking.Controls.Add(this.groupBoxAgency);
            this.panelChecking.Controls.Add(this.buttonChecking);
            this.panelChecking.Controls.Add(this.labelChecking);
            this.panelChecking.Controls.Add(this.textBoxDacCode);
            this.panelChecking.Location = new System.Drawing.Point(12, 12);
            this.panelChecking.Name = "panelChecking";
            this.panelChecking.Size = new System.Drawing.Size(541, 465);
            this.panelChecking.TabIndex = 1;
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Controls.Add(this.textBoxProductManufacture);
            this.groupBoxProduct.Controls.Add(this.labelManufacture);
            this.groupBoxProduct.Controls.Add(this.textBoxProductGeneralFormat);
            this.groupBoxProduct.Controls.Add(this.textBoxProductRegisterNumber);
            this.groupBoxProduct.Controls.Add(this.textBoxProductName);
            this.groupBoxProduct.Controls.Add(this.labelGeneralFormat);
            this.groupBoxProduct.Controls.Add(this.labelRegisterNumber);
            this.groupBoxProduct.Controls.Add(this.labelProductName);
            this.groupBoxProduct.Controls.Add(this.textBoxProductCategory);
            this.groupBoxProduct.Controls.Add(this.labelProductCategory);
            this.groupBoxProduct.Controls.Add(this.textBoxProductCode);
            this.groupBoxProduct.Controls.Add(this.labelProductCode);
            this.groupBoxProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProduct.Location = new System.Drawing.Point(271, 37);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Size = new System.Drawing.Size(267, 186);
            this.groupBoxProduct.TabIndex = 4;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "Sản phẩm";
            // 
            // textBoxProductManufacture
            // 
            this.textBoxProductManufacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductManufacture.Location = new System.Drawing.Point(80, 128);
            this.textBoxProductManufacture.Name = "textBoxProductManufacture";
            this.textBoxProductManufacture.Size = new System.Drawing.Size(181, 21);
            this.textBoxProductManufacture.TabIndex = 19;
            // 
            // labelManufacture
            // 
            this.labelManufacture.AutoSize = true;
            this.labelManufacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManufacture.Location = new System.Drawing.Point(22, 130);
            this.labelManufacture.Name = "labelManufacture";
            this.labelManufacture.Size = new System.Drawing.Size(52, 15);
            this.labelManufacture.TabIndex = 16;
            this.labelManufacture.Text = "Nhà SX:";
            // 
            // textBoxProductGeneralFormat
            // 
            this.textBoxProductGeneralFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductGeneralFormat.Location = new System.Drawing.Point(80, 155);
            this.textBoxProductGeneralFormat.Name = "textBoxProductGeneralFormat";
            this.textBoxProductGeneralFormat.Size = new System.Drawing.Size(181, 21);
            this.textBoxProductGeneralFormat.TabIndex = 14;
            // 
            // textBoxProductRegisterNumber
            // 
            this.textBoxProductRegisterNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductRegisterNumber.Location = new System.Drawing.Point(80, 101);
            this.textBoxProductRegisterNumber.Name = "textBoxProductRegisterNumber";
            this.textBoxProductRegisterNumber.Size = new System.Drawing.Size(181, 21);
            this.textBoxProductRegisterNumber.TabIndex = 14;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductName.Location = new System.Drawing.Point(80, 47);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(181, 21);
            this.textBoxProductName.TabIndex = 14;
            // 
            // labelGeneralFormat
            // 
            this.labelGeneralFormat.AutoSize = true;
            this.labelGeneralFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGeneralFormat.Location = new System.Drawing.Point(14, 158);
            this.labelGeneralFormat.Name = "labelGeneralFormat";
            this.labelGeneralFormat.Size = new System.Drawing.Size(60, 15);
            this.labelGeneralFormat.TabIndex = 8;
            this.labelGeneralFormat.Text = "Quy cách:";
            // 
            // labelRegisterNumber
            // 
            this.labelRegisterNumber.AutoSize = true;
            this.labelRegisterNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegisterNumber.Location = new System.Drawing.Point(7, 104);
            this.labelRegisterNumber.Name = "labelRegisterNumber";
            this.labelRegisterNumber.Size = new System.Drawing.Size(70, 15);
            this.labelRegisterNumber.TabIndex = 8;
            this.labelRegisterNumber.Text = "Số đăng ký:";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductName.Location = new System.Drawing.Point(24, 50);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(50, 15);
            this.labelProductName.TabIndex = 8;
            this.labelProductName.Text = "Tên SP:";
            // 
            // textBoxProductCategory
            // 
            this.textBoxProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductCategory.Location = new System.Drawing.Point(80, 74);
            this.textBoxProductCategory.Name = "textBoxProductCategory";
            this.textBoxProductCategory.Size = new System.Drawing.Size(181, 21);
            this.textBoxProductCategory.TabIndex = 15;
            // 
            // labelProductCategory
            // 
            this.labelProductCategory.AutoSize = true;
            this.labelProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductCategory.Location = new System.Drawing.Point(21, 77);
            this.labelProductCategory.Name = "labelProductCategory";
            this.labelProductCategory.Size = new System.Drawing.Size(53, 15);
            this.labelProductCategory.TabIndex = 1;
            this.labelProductCategory.Text = "Loại SP:";
            // 
            // textBoxProductCode
            // 
            this.textBoxProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductCode.Location = new System.Drawing.Point(80, 20);
            this.textBoxProductCode.Name = "textBoxProductCode";
            this.textBoxProductCode.Size = new System.Drawing.Size(181, 21);
            this.textBoxProductCode.TabIndex = 15;
            // 
            // labelProductCode
            // 
            this.labelProductCode.AutoSize = true;
            this.labelProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductCode.Location = new System.Drawing.Point(27, 25);
            this.labelProductCode.Name = "labelProductCode";
            this.labelProductCode.Size = new System.Drawing.Size(47, 15);
            this.labelProductCode.TabIndex = 1;
            this.labelProductCode.Text = "Mã SP:";
            // 
            // groupBoxStore
            // 
            this.groupBoxStore.Controls.Add(this.textBoxStoreExportedDate);
            this.groupBoxStore.Controls.Add(this.labelStoreExportedDate);
            this.groupBoxStore.Controls.Add(this.textBoxStorePCode);
            this.groupBoxStore.Controls.Add(this.labelStorePCode);
            this.groupBoxStore.Controls.Add(this.textBoxStoreEmail);
            this.groupBoxStore.Controls.Add(this.labelStoreEmail);
            this.groupBoxStore.Controls.Add(this.textBoxStoreMobile);
            this.groupBoxStore.Controls.Add(this.labelStoreMobile);
            this.groupBoxStore.Controls.Add(this.textBoxStoreOwner);
            this.groupBoxStore.Controls.Add(this.labelStoreOwner);
            this.groupBoxStore.Controls.Add(this.textBoxStoreAddress);
            this.groupBoxStore.Controls.Add(this.labelStoreAddress);
            this.groupBoxStore.Controls.Add(this.textBoxStoreName);
            this.groupBoxStore.Controls.Add(this.labelStoreName);
            this.groupBoxStore.Controls.Add(this.textBoxStoreCode);
            this.groupBoxStore.Controls.Add(this.labelStoreCode);
            this.groupBoxStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStore.Location = new System.Drawing.Point(271, 229);
            this.groupBoxStore.Name = "groupBoxStore";
            this.groupBoxStore.Size = new System.Drawing.Size(267, 233);
            this.groupBoxStore.TabIndex = 3;
            this.groupBoxStore.TabStop = false;
            this.groupBoxStore.Text = "Cửa hàng";
            // 
            // textBoxStoreExportedDate
            // 
            this.textBoxStoreExportedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStoreExportedDate.Location = new System.Drawing.Point(80, 17);
            this.textBoxStoreExportedDate.Name = "textBoxStoreExportedDate";
            this.textBoxStoreExportedDate.Size = new System.Drawing.Size(181, 21);
            this.textBoxStoreExportedDate.TabIndex = 17;
            // 
            // labelStoreExportedDate
            // 
            this.labelStoreExportedDate.AutoSize = true;
            this.labelStoreExportedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoreExportedDate.Location = new System.Drawing.Point(11, 20);
            this.labelStoreExportedDate.Name = "labelStoreExportedDate";
            this.labelStoreExportedDate.Size = new System.Drawing.Size(64, 15);
            this.labelStoreExportedDate.TabIndex = 16;
            this.labelStoreExportedDate.Text = "Ngày xuất:";
            // 
            // textBoxStorePCode
            // 
            this.textBoxStorePCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStorePCode.Location = new System.Drawing.Point(80, 206);
            this.textBoxStorePCode.Name = "textBoxStorePCode";
            this.textBoxStorePCode.Size = new System.Drawing.Size(181, 21);
            this.textBoxStorePCode.TabIndex = 9;
            // 
            // labelStorePCode
            // 
            this.labelStorePCode.AutoSize = true;
            this.labelStorePCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStorePCode.Location = new System.Drawing.Point(27, 209);
            this.labelStorePCode.Name = "labelStorePCode";
            this.labelStorePCode.Size = new System.Drawing.Size(47, 15);
            this.labelStorePCode.TabIndex = 3;
            this.labelStorePCode.Text = "Mã SP:";
            // 
            // textBoxStoreEmail
            // 
            this.textBoxStoreEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStoreEmail.Location = new System.Drawing.Point(80, 179);
            this.textBoxStoreEmail.Name = "textBoxStoreEmail";
            this.textBoxStoreEmail.Size = new System.Drawing.Size(181, 21);
            this.textBoxStoreEmail.TabIndex = 10;
            // 
            // labelStoreEmail
            // 
            this.labelStoreEmail.AutoSize = true;
            this.labelStoreEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoreEmail.Location = new System.Drawing.Point(32, 182);
            this.labelStoreEmail.Name = "labelStoreEmail";
            this.labelStoreEmail.Size = new System.Drawing.Size(42, 15);
            this.labelStoreEmail.TabIndex = 4;
            this.labelStoreEmail.Text = "Email:";
            // 
            // textBoxStoreMobile
            // 
            this.textBoxStoreMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStoreMobile.Location = new System.Drawing.Point(80, 152);
            this.textBoxStoreMobile.Name = "textBoxStoreMobile";
            this.textBoxStoreMobile.Size = new System.Drawing.Size(181, 21);
            this.textBoxStoreMobile.TabIndex = 11;
            // 
            // labelStoreMobile
            // 
            this.labelStoreMobile.AutoSize = true;
            this.labelStoreMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoreMobile.Location = new System.Drawing.Point(24, 155);
            this.labelStoreMobile.Name = "labelStoreMobile";
            this.labelStoreMobile.Size = new System.Drawing.Size(48, 15);
            this.labelStoreMobile.TabIndex = 5;
            this.labelStoreMobile.Text = "Mobile:";
            // 
            // textBoxStoreOwner
            // 
            this.textBoxStoreOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStoreOwner.Location = new System.Drawing.Point(80, 125);
            this.textBoxStoreOwner.Name = "textBoxStoreOwner";
            this.textBoxStoreOwner.Size = new System.Drawing.Size(181, 21);
            this.textBoxStoreOwner.TabIndex = 12;
            // 
            // labelStoreOwner
            // 
            this.labelStoreOwner.AutoSize = true;
            this.labelStoreOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoreOwner.Location = new System.Drawing.Point(22, 128);
            this.labelStoreOwner.Name = "labelStoreOwner";
            this.labelStoreOwner.Size = new System.Drawing.Size(52, 15);
            this.labelStoreOwner.TabIndex = 6;
            this.labelStoreOwner.Text = "Chủ CH:";
            // 
            // textBoxStoreAddress
            // 
            this.textBoxStoreAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStoreAddress.Location = new System.Drawing.Point(80, 98);
            this.textBoxStoreAddress.Name = "textBoxStoreAddress";
            this.textBoxStoreAddress.Size = new System.Drawing.Size(181, 21);
            this.textBoxStoreAddress.TabIndex = 13;
            // 
            // labelStoreAddress
            // 
            this.labelStoreAddress.AutoSize = true;
            this.labelStoreAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoreAddress.Location = new System.Drawing.Point(26, 101);
            this.labelStoreAddress.Name = "labelStoreAddress";
            this.labelStoreAddress.Size = new System.Drawing.Size(48, 15);
            this.labelStoreAddress.TabIndex = 7;
            this.labelStoreAddress.Text = "Địa chỉ:";
            // 
            // textBoxStoreName
            // 
            this.textBoxStoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStoreName.Location = new System.Drawing.Point(80, 71);
            this.textBoxStoreName.Name = "textBoxStoreName";
            this.textBoxStoreName.Size = new System.Drawing.Size(181, 21);
            this.textBoxStoreName.TabIndex = 14;
            // 
            // labelStoreName
            // 
            this.labelStoreName.AutoSize = true;
            this.labelStoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoreName.Location = new System.Drawing.Point(12, 74);
            this.labelStoreName.Name = "labelStoreName";
            this.labelStoreName.Size = new System.Drawing.Size(62, 15);
            this.labelStoreName.TabIndex = 8;
            this.labelStoreName.Text = "Tên đại lý:";
            // 
            // textBoxStoreCode
            // 
            this.textBoxStoreCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStoreCode.Location = new System.Drawing.Point(80, 44);
            this.textBoxStoreCode.Name = "textBoxStoreCode";
            this.textBoxStoreCode.Size = new System.Drawing.Size(181, 21);
            this.textBoxStoreCode.TabIndex = 15;
            // 
            // labelStoreCode
            // 
            this.labelStoreCode.AutoSize = true;
            this.labelStoreCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoreCode.Location = new System.Drawing.Point(26, 47);
            this.labelStoreCode.Name = "labelStoreCode";
            this.labelStoreCode.Size = new System.Drawing.Size(48, 15);
            this.labelStoreCode.TabIndex = 1;
            this.labelStoreCode.Text = "Mã CH:";
            // 
            // groupBoxAgency
            // 
            this.groupBoxAgency.Controls.Add(this.textBoxDescription);
            this.groupBoxAgency.Controls.Add(this.labelDescription);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyPCode);
            this.groupBoxAgency.Controls.Add(this.labelAgencyPCode);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyDependCode);
            this.groupBoxAgency.Controls.Add(this.labelDependCode);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyRegion);
            this.groupBoxAgency.Controls.Add(this.labelRegion);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyProvince);
            this.groupBoxAgency.Controls.Add(this.labelAgencyProvince);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyEmail);
            this.groupBoxAgency.Controls.Add(this.labelAgencyEmail);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyExportedDate);
            this.groupBoxAgency.Controls.Add(this.labelAgencyExportedDate);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyTaxCode);
            this.groupBoxAgency.Controls.Add(this.labelTaxCode);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyPhoneNum);
            this.groupBoxAgency.Controls.Add(this.labelPhoneNum);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyMobile);
            this.groupBoxAgency.Controls.Add(this.labelAgencyMobile);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyJoinContact);
            this.groupBoxAgency.Controls.Add(this.labelJoinContact);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyOwner);
            this.groupBoxAgency.Controls.Add(this.labelAgencyOwner);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyAddress);
            this.groupBoxAgency.Controls.Add(this.labelAgencyAddress);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyName);
            this.groupBoxAgency.Controls.Add(this.labelAgencyName);
            this.groupBoxAgency.Controls.Add(this.textBoxAgencyCode);
            this.groupBoxAgency.Controls.Add(this.labelAgencyCode);
            this.groupBoxAgency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAgency.Location = new System.Drawing.Point(3, 37);
            this.groupBoxAgency.Name = "groupBoxAgency";
            this.groupBoxAgency.Size = new System.Drawing.Size(262, 425);
            this.groupBoxAgency.TabIndex = 3;
            this.groupBoxAgency.TabStop = false;
            this.groupBoxAgency.Text = "Khách hàng";
            // 
            // textBoxAgencyPCode
            // 
            this.textBoxAgencyPCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyPCode.Location = new System.Drawing.Point(75, 398);
            this.textBoxAgencyPCode.Name = "textBoxAgencyPCode";
            this.textBoxAgencyPCode.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyPCode.TabIndex = 2;
            // 
            // labelAgencyPCode
            // 
            this.labelAgencyPCode.AutoSize = true;
            this.labelAgencyPCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgencyPCode.Location = new System.Drawing.Point(22, 401);
            this.labelAgencyPCode.Name = "labelAgencyPCode";
            this.labelAgencyPCode.Size = new System.Drawing.Size(47, 15);
            this.labelAgencyPCode.TabIndex = 1;
            this.labelAgencyPCode.Text = "Mã SP:";
            // 
            // textBoxAgencyDependCode
            // 
            this.textBoxAgencyDependCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyDependCode.Location = new System.Drawing.Point(75, 317);
            this.textBoxAgencyDependCode.Name = "textBoxAgencyDependCode";
            this.textBoxAgencyDependCode.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyDependCode.TabIndex = 2;
            // 
            // labelDependCode
            // 
            this.labelDependCode.AutoSize = true;
            this.labelDependCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDependCode.Location = new System.Drawing.Point(13, 320);
            this.labelDependCode.Name = "labelDependCode";
            this.labelDependCode.Size = new System.Drawing.Size(52, 15);
            this.labelDependCode.TabIndex = 1;
            this.labelDependCode.Text = "Mã ĐLý:";
            // 
            // textBoxAgencyRegion
            // 
            this.textBoxAgencyRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyRegion.Location = new System.Drawing.Point(75, 344);
            this.textBoxAgencyRegion.Name = "textBoxAgencyRegion";
            this.textBoxAgencyRegion.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyRegion.TabIndex = 2;
            // 
            // labelRegion
            // 
            this.labelRegion.AutoSize = true;
            this.labelRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegion.Location = new System.Drawing.Point(13, 347);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(56, 15);
            this.labelRegion.TabIndex = 1;
            this.labelRegion.Text = "KV/Miền:";
            // 
            // textBoxAgencyProvince
            // 
            this.textBoxAgencyProvince.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyProvince.Location = new System.Drawing.Point(75, 371);
            this.textBoxAgencyProvince.Name = "textBoxAgencyProvince";
            this.textBoxAgencyProvince.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyProvince.TabIndex = 2;
            // 
            // labelAgencyProvince
            // 
            this.labelAgencyProvince.AutoSize = true;
            this.labelAgencyProvince.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgencyProvince.Location = new System.Drawing.Point(35, 374);
            this.labelAgencyProvince.Name = "labelAgencyProvince";
            this.labelAgencyProvince.Size = new System.Drawing.Size(34, 15);
            this.labelAgencyProvince.TabIndex = 1;
            this.labelAgencyProvince.Text = "Tỉnh:";
            // 
            // textBoxAgencyEmail
            // 
            this.textBoxAgencyEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyEmail.Location = new System.Drawing.Point(75, 290);
            this.textBoxAgencyEmail.Name = "textBoxAgencyEmail";
            this.textBoxAgencyEmail.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyEmail.TabIndex = 2;
            // 
            // labelAgencyEmail
            // 
            this.labelAgencyEmail.AutoSize = true;
            this.labelAgencyEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgencyEmail.Location = new System.Drawing.Point(27, 293);
            this.labelAgencyEmail.Name = "labelAgencyEmail";
            this.labelAgencyEmail.Size = new System.Drawing.Size(42, 15);
            this.labelAgencyEmail.TabIndex = 1;
            this.labelAgencyEmail.Text = "Email:";
            // 
            // textBoxAgencyExportedDate
            // 
            this.textBoxAgencyExportedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyExportedDate.Location = new System.Drawing.Point(75, 20);
            this.textBoxAgencyExportedDate.Name = "textBoxAgencyExportedDate";
            this.textBoxAgencyExportedDate.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyExportedDate.TabIndex = 15;
            // 
            // labelAgencyExportedDate
            // 
            this.labelAgencyExportedDate.AutoSize = true;
            this.labelAgencyExportedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgencyExportedDate.Location = new System.Drawing.Point(6, 23);
            this.labelAgencyExportedDate.Name = "labelAgencyExportedDate";
            this.labelAgencyExportedDate.Size = new System.Drawing.Size(64, 15);
            this.labelAgencyExportedDate.TabIndex = 1;
            this.labelAgencyExportedDate.Text = "Ngày xuất:";
            // 
            // textBoxAgencyTaxCode
            // 
            this.textBoxAgencyTaxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyTaxCode.Location = new System.Drawing.Point(75, 209);
            this.textBoxAgencyTaxCode.Name = "textBoxAgencyTaxCode";
            this.textBoxAgencyTaxCode.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyTaxCode.TabIndex = 2;
            // 
            // labelTaxCode
            // 
            this.labelTaxCode.AutoSize = true;
            this.labelTaxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaxCode.Location = new System.Drawing.Point(10, 212);
            this.labelTaxCode.Name = "labelTaxCode";
            this.labelTaxCode.Size = new System.Drawing.Size(60, 15);
            this.labelTaxCode.TabIndex = 1;
            this.labelTaxCode.Text = "MS Thuế:";
            // 
            // textBoxAgencyPhoneNum
            // 
            this.textBoxAgencyPhoneNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyPhoneNum.Location = new System.Drawing.Point(75, 236);
            this.textBoxAgencyPhoneNum.Name = "textBoxAgencyPhoneNum";
            this.textBoxAgencyPhoneNum.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyPhoneNum.TabIndex = 2;
            // 
            // labelPhoneNum
            // 
            this.labelPhoneNum.AutoSize = true;
            this.labelPhoneNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhoneNum.Location = new System.Drawing.Point(23, 239);
            this.labelPhoneNum.Name = "labelPhoneNum";
            this.labelPhoneNum.Size = new System.Drawing.Size(46, 15);
            this.labelPhoneNum.TabIndex = 1;
            this.labelPhoneNum.Text = "Phone:";
            // 
            // textBoxAgencyMobile
            // 
            this.textBoxAgencyMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyMobile.Location = new System.Drawing.Point(75, 263);
            this.textBoxAgencyMobile.Name = "textBoxAgencyMobile";
            this.textBoxAgencyMobile.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyMobile.TabIndex = 2;
            // 
            // labelAgencyMobile
            // 
            this.labelAgencyMobile.AutoSize = true;
            this.labelAgencyMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgencyMobile.Location = new System.Drawing.Point(21, 266);
            this.labelAgencyMobile.Name = "labelAgencyMobile";
            this.labelAgencyMobile.Size = new System.Drawing.Size(48, 15);
            this.labelAgencyMobile.TabIndex = 1;
            this.labelAgencyMobile.Text = "Mobile:";
            // 
            // textBoxAgencyJoinContact
            // 
            this.textBoxAgencyJoinContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyJoinContact.Location = new System.Drawing.Point(75, 128);
            this.textBoxAgencyJoinContact.Name = "textBoxAgencyJoinContact";
            this.textBoxAgencyJoinContact.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyJoinContact.TabIndex = 2;
            // 
            // labelJoinContact
            // 
            this.labelJoinContact.AutoSize = true;
            this.labelJoinContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJoinContact.Location = new System.Drawing.Point(10, 131);
            this.labelJoinContact.Name = "labelJoinContact";
            this.labelJoinContact.Size = new System.Drawing.Size(64, 15);
            this.labelJoinContact.TabIndex = 1;
            this.labelJoinContact.Text = "Hợp đồng:";
            // 
            // textBoxAgencyOwner
            // 
            this.textBoxAgencyOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyOwner.Location = new System.Drawing.Point(75, 155);
            this.textBoxAgencyOwner.Name = "textBoxAgencyOwner";
            this.textBoxAgencyOwner.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyOwner.TabIndex = 2;
            // 
            // labelAgencyOwner
            // 
            this.labelAgencyOwner.AutoSize = true;
            this.labelAgencyOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgencyOwner.Location = new System.Drawing.Point(10, 158);
            this.labelAgencyOwner.Name = "labelAgencyOwner";
            this.labelAgencyOwner.Size = new System.Drawing.Size(63, 15);
            this.labelAgencyOwner.TabIndex = 1;
            this.labelAgencyOwner.Text = "Chủ đại lý:";
            // 
            // textBoxAgencyAddress
            // 
            this.textBoxAgencyAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyAddress.Location = new System.Drawing.Point(75, 101);
            this.textBoxAgencyAddress.Name = "textBoxAgencyAddress";
            this.textBoxAgencyAddress.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyAddress.TabIndex = 2;
            // 
            // labelAgencyAddress
            // 
            this.labelAgencyAddress.AutoSize = true;
            this.labelAgencyAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgencyAddress.Location = new System.Drawing.Point(21, 104);
            this.labelAgencyAddress.Name = "labelAgencyAddress";
            this.labelAgencyAddress.Size = new System.Drawing.Size(48, 15);
            this.labelAgencyAddress.TabIndex = 1;
            this.labelAgencyAddress.Text = "Địa chỉ:";
            // 
            // textBoxAgencyName
            // 
            this.textBoxAgencyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyName.Location = new System.Drawing.Point(75, 74);
            this.textBoxAgencyName.Name = "textBoxAgencyName";
            this.textBoxAgencyName.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyName.TabIndex = 2;
            // 
            // labelAgencyName
            // 
            this.labelAgencyName.AutoSize = true;
            this.labelAgencyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgencyName.Location = new System.Drawing.Point(18, 77);
            this.labelAgencyName.Name = "labelAgencyName";
            this.labelAgencyName.Size = new System.Drawing.Size(51, 15);
            this.labelAgencyName.TabIndex = 1;
            this.labelAgencyName.Text = "Tên KH:";
            // 
            // textBoxAgencyCode
            // 
            this.textBoxAgencyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAgencyCode.Location = new System.Drawing.Point(75, 47);
            this.textBoxAgencyCode.Name = "textBoxAgencyCode";
            this.textBoxAgencyCode.Size = new System.Drawing.Size(181, 21);
            this.textBoxAgencyCode.TabIndex = 2;
            // 
            // labelAgencyCode
            // 
            this.labelAgencyCode.AutoSize = true;
            this.labelAgencyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgencyCode.Location = new System.Drawing.Point(22, 50);
            this.labelAgencyCode.Name = "labelAgencyCode";
            this.labelAgencyCode.Size = new System.Drawing.Size(48, 15);
            this.labelAgencyCode.TabIndex = 1;
            this.labelAgencyCode.Text = "Mã KH:";
            // 
            // labelChecking
            // 
            this.labelChecking.AutoSize = true;
            this.labelChecking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChecking.Location = new System.Drawing.Point(67, 13);
            this.labelChecking.Name = "labelChecking";
            this.labelChecking.Size = new System.Drawing.Size(105, 15);
            this.labelChecking.TabIndex = 1;
            this.labelChecking.Text = "Nhập mã kiểm tra";
            // 
            // labelAgency
            // 
            this.labelAgency.AutoSize = true;
            this.labelAgency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgency.Location = new System.Drawing.Point(6, 16);
            this.labelAgency.Name = "labelAgency";
            this.labelAgency.Size = new System.Drawing.Size(40, 15);
            this.labelAgency.TabIndex = 1;
            this.labelAgency.Text = "Đại lý:";
            // 
            // buttonChecking
            // 
            this.buttonChecking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChecking.Image = global::PIPT.Agency.Properties.Resources.submit1616;
            this.buttonChecking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChecking.Location = new System.Drawing.Point(418, 9);
            this.buttonChecking.Name = "buttonChecking";
            this.buttonChecking.Size = new System.Drawing.Size(80, 24);
            this.buttonChecking.TabIndex = 2;
            this.buttonChecking.Text = "Kiểm tra";
            this.buttonChecking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonChecking.UseVisualStyleBackColor = true;
            this.buttonChecking.Click += new System.EventHandler(this.buttonChecking_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescription.Location = new System.Drawing.Point(75, 182);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(181, 21);
            this.textBoxDescription.TabIndex = 17;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(18, 185);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(52, 15);
            this.labelDescription.TabIndex = 16;
            this.labelDescription.Text = "Ghi chú:";
            // 
            // frmDacChecking
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(565, 489);
            this.Controls.Add(this.panelChecking);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDacChecking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm tra xuất xứ tại cửa hàng";
            this.Load += new System.EventHandler(this.frmDacChecking_Load);
            this.panelChecking.ResumeLayout(false);
            this.panelChecking.PerformLayout();
            this.groupBoxProduct.ResumeLayout(false);
            this.groupBoxProduct.PerformLayout();
            this.groupBoxStore.ResumeLayout(false);
            this.groupBoxStore.PerformLayout();
            this.groupBoxAgency.ResumeLayout(false);
            this.groupBoxAgency.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxDacCode;
        private System.Windows.Forms.Panel panelChecking;
        private System.Windows.Forms.Button buttonChecking;
        private System.Windows.Forms.Label labelChecking;
        private System.Windows.Forms.Label labelStoreCode;
        private System.Windows.Forms.Label labelAgencyCode;
        private System.Windows.Forms.GroupBox groupBoxStore;
        private System.Windows.Forms.GroupBox groupBoxAgency;
        private System.Windows.Forms.Label labelAgency;
        private System.Windows.Forms.TextBox textBoxStorePCode;
        private System.Windows.Forms.Label labelStorePCode;
        private System.Windows.Forms.TextBox textBoxStoreEmail;
        private System.Windows.Forms.Label labelStoreEmail;
        private System.Windows.Forms.TextBox textBoxStoreMobile;
        private System.Windows.Forms.Label labelStoreMobile;
        private System.Windows.Forms.TextBox textBoxStoreOwner;
        private System.Windows.Forms.Label labelStoreOwner;
        private System.Windows.Forms.TextBox textBoxStoreAddress;
        private System.Windows.Forms.Label labelStoreAddress;
        private System.Windows.Forms.TextBox textBoxStoreName;
        private System.Windows.Forms.Label labelStoreName;
        private System.Windows.Forms.TextBox textBoxStoreCode;
        private System.Windows.Forms.TextBox textBoxAgencyPCode;
        private System.Windows.Forms.Label labelAgencyPCode;
        private System.Windows.Forms.TextBox textBoxAgencyProvince;
        private System.Windows.Forms.Label labelAgencyProvince;
        private System.Windows.Forms.TextBox textBoxAgencyEmail;
        private System.Windows.Forms.Label labelAgencyEmail;
        private System.Windows.Forms.TextBox textBoxAgencyMobile;
        private System.Windows.Forms.Label labelAgencyMobile;
        private System.Windows.Forms.TextBox textBoxAgencyOwner;
        private System.Windows.Forms.Label labelAgencyOwner;
        private System.Windows.Forms.TextBox textBoxAgencyAddress;
        private System.Windows.Forms.Label labelAgencyAddress;
        private System.Windows.Forms.TextBox textBoxAgencyName;
        private System.Windows.Forms.Label labelAgencyName;
        private System.Windows.Forms.TextBox textBoxAgencyCode;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.TextBox textBoxProductCode;
        private System.Windows.Forms.Label labelProductCode;
        private System.Windows.Forms.TextBox textBoxProductManufacture;
        private System.Windows.Forms.Label labelManufacture;
        private System.Windows.Forms.TextBox textBoxProductGeneralFormat;
        private System.Windows.Forms.TextBox textBoxProductRegisterNumber;
        private System.Windows.Forms.Label labelGeneralFormat;
        private System.Windows.Forms.Label labelRegisterNumber;
        private System.Windows.Forms.TextBox textBoxProductCategory;
        private System.Windows.Forms.Label labelProductCategory;
        private System.Windows.Forms.TextBox textBoxAgencyDependCode;
        private System.Windows.Forms.Label labelDependCode;
        private System.Windows.Forms.TextBox textBoxAgencyRegion;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.TextBox textBoxAgencyTaxCode;
        private System.Windows.Forms.Label labelTaxCode;
        private System.Windows.Forms.TextBox textBoxAgencyPhoneNum;
        private System.Windows.Forms.Label labelPhoneNum;
        private System.Windows.Forms.TextBox textBoxAgencyJoinContact;
        private System.Windows.Forms.Label labelJoinContact;
        private System.Windows.Forms.TextBox textBoxAgencyExportedDate;
        private System.Windows.Forms.Label labelAgencyExportedDate;
        private System.Windows.Forms.TextBox textBoxStoreExportedDate;
        private System.Windows.Forms.Label labelStoreExportedDate;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
    }
}