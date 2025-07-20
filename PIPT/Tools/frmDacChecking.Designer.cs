namespace PIPT
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
            this.labelAgency = new System.Windows.Forms.Label();
            this.txtDacCode = new System.Windows.Forms.TextBox();
            this.labelChecking = new System.Windows.Forms.Label();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.grExport = new System.Windows.Forms.GroupBox();
            this.txtExportDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.labelAgencyName = new System.Windows.Forms.Label();
            this.grProduct = new System.Windows.Forms.GroupBox();
            this.txtProductManufacture = new System.Windows.Forms.TextBox();
            this.labelManufacture = new System.Windows.Forms.Label();
            this.txtProductGeneralFormat = new System.Windows.Forms.TextBox();
            this.txtProductRegisterNumber = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.labelGeneralFormat = new System.Windows.Forms.Label();
            this.labelRegisterNumber = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.txtProductCategory = new System.Windows.Forms.TextBox();
            this.labelProductCategory = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.labelProductCode = new System.Windows.Forms.Label();
            this.grPackage = new System.Windows.Forms.GroupBox();
            this.txtPackageProductName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPackageProductCode = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPersonPackage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPackageCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPackageCreateDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grExport1 = new System.Windows.Forms.GroupBox();
            this.txtExportDate1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrderNumber1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustomerName1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grExport2 = new System.Windows.Forms.GroupBox();
            this.txtExportDate2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOrderNumber2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCustomerName2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.grExport3 = new System.Windows.Forms.GroupBox();
            this.txtExportDate3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOrderNumber3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCustomerName3 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panelChecking = new System.Windows.Forms.Panel();
            this.grExport.SuspendLayout();
            this.grProduct.SuspendLayout();
            this.grPackage.SuspendLayout();
            this.grExport1.SuspendLayout();
            this.grExport2.SuspendLayout();
            this.grExport3.SuspendLayout();
            this.panelChecking.SuspendLayout();
            this.SuspendLayout();
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
            // txtDacCode
            // 
            this.txtDacCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDacCode.Location = new System.Drawing.Point(179, 10);
            this.txtDacCode.Name = "txtDacCode";
            this.txtDacCode.Size = new System.Drawing.Size(234, 21);
            this.txtDacCode.TabIndex = 0;
            this.txtDacCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDacCode_KeyPress);
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
            // btnGetInfo
            // 
            this.btnGetInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetInfo.Image = global::PIPT.Properties.Resources.submit1616;
            this.btnGetInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetInfo.Location = new System.Drawing.Point(418, 9);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(80, 24);
            this.btnGetInfo.TabIndex = 1;
            this.btnGetInfo.Text = "Kiểm tra";
            this.btnGetInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.buttonChecking_Click);
            // 
            // grExport
            // 
            this.grExport.Controls.Add(this.txtExportDate);
            this.grExport.Controls.Add(this.label4);
            this.grExport.Controls.Add(this.txtOrderNumber);
            this.grExport.Controls.Add(this.label1);
            this.grExport.Controls.Add(this.txtCustomerName);
            this.grExport.Controls.Add(this.labelAgencyName);
            this.grExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grExport.Location = new System.Drawing.Point(3, 37);
            this.grExport.Name = "grExport";
            this.grExport.Size = new System.Drawing.Size(277, 109);
            this.grExport.TabIndex = 3;
            this.grExport.TabStop = false;
            this.grExport.Text = "Đơn hàng";
            this.grExport.Visible = false;
            // 
            // txtExportDate
            // 
            this.txtExportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExportDate.Location = new System.Drawing.Point(95, 76);
            this.txtExportDate.Name = "txtExportDate";
            this.txtExportDate.Size = new System.Drawing.Size(174, 21);
            this.txtExportDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày xuất:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNumber.Location = new System.Drawing.Point(95, 22);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(174, 21);
            this.txtOrderNumber.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã đơn hàng:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(95, 49);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(174, 21);
            this.txtCustomerName.TabIndex = 3;
            // 
            // labelAgencyName
            // 
            this.labelAgencyName.AutoSize = true;
            this.labelAgencyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgencyName.Location = new System.Drawing.Point(13, 50);
            this.labelAgencyName.Name = "labelAgencyName";
            this.labelAgencyName.Size = new System.Drawing.Size(76, 15);
            this.labelAgencyName.TabIndex = 1;
            this.labelAgencyName.Text = "Khách hàng:";
            // 
            // grProduct
            // 
            this.grProduct.Controls.Add(this.txtProductManufacture);
            this.grProduct.Controls.Add(this.labelManufacture);
            this.grProduct.Controls.Add(this.txtProductGeneralFormat);
            this.grProduct.Controls.Add(this.txtProductRegisterNumber);
            this.grProduct.Controls.Add(this.txtProductName);
            this.grProduct.Controls.Add(this.labelGeneralFormat);
            this.grProduct.Controls.Add(this.labelRegisterNumber);
            this.grProduct.Controls.Add(this.labelProductName);
            this.grProduct.Controls.Add(this.txtProductCategory);
            this.grProduct.Controls.Add(this.labelProductCategory);
            this.grProduct.Controls.Add(this.txtProductCode);
            this.grProduct.Controls.Add(this.labelProductCode);
            this.grProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grProduct.Location = new System.Drawing.Point(286, 37);
            this.grProduct.Name = "grProduct";
            this.grProduct.Size = new System.Drawing.Size(267, 186);
            this.grProduct.TabIndex = 4;
            this.grProduct.TabStop = false;
            this.grProduct.Text = "Sản phẩm";
            this.grProduct.Visible = false;
            // 
            // txtProductManufacture
            // 
            this.txtProductManufacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductManufacture.Location = new System.Drawing.Point(90, 128);
            this.txtProductManufacture.Name = "txtProductManufacture";
            this.txtProductManufacture.Size = new System.Drawing.Size(171, 21);
            this.txtProductManufacture.TabIndex = 18;
            // 
            // labelManufacture
            // 
            this.labelManufacture.AutoSize = true;
            this.labelManufacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManufacture.Location = new System.Drawing.Point(32, 131);
            this.labelManufacture.Name = "labelManufacture";
            this.labelManufacture.Size = new System.Drawing.Size(52, 15);
            this.labelManufacture.TabIndex = 16;
            this.labelManufacture.Text = "Nhà SX:";
            // 
            // txtProductGeneralFormat
            // 
            this.txtProductGeneralFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductGeneralFormat.Location = new System.Drawing.Point(90, 155);
            this.txtProductGeneralFormat.Name = "txtProductGeneralFormat";
            this.txtProductGeneralFormat.Size = new System.Drawing.Size(171, 21);
            this.txtProductGeneralFormat.TabIndex = 19;
            // 
            // txtProductRegisterNumber
            // 
            this.txtProductRegisterNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductRegisterNumber.Location = new System.Drawing.Point(90, 101);
            this.txtProductRegisterNumber.Name = "txtProductRegisterNumber";
            this.txtProductRegisterNumber.Size = new System.Drawing.Size(171, 21);
            this.txtProductRegisterNumber.TabIndex = 17;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(90, 47);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(171, 21);
            this.txtProductName.TabIndex = 15;
            // 
            // labelGeneralFormat
            // 
            this.labelGeneralFormat.AutoSize = true;
            this.labelGeneralFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGeneralFormat.Location = new System.Drawing.Point(24, 158);
            this.labelGeneralFormat.Name = "labelGeneralFormat";
            this.labelGeneralFormat.Size = new System.Drawing.Size(60, 15);
            this.labelGeneralFormat.TabIndex = 8;
            this.labelGeneralFormat.Text = "Quy cách:";
            // 
            // labelRegisterNumber
            // 
            this.labelRegisterNumber.AutoSize = true;
            this.labelRegisterNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegisterNumber.Location = new System.Drawing.Point(14, 104);
            this.labelRegisterNumber.Name = "labelRegisterNumber";
            this.labelRegisterNumber.Size = new System.Drawing.Size(70, 15);
            this.labelRegisterNumber.TabIndex = 8;
            this.labelRegisterNumber.Text = "Số đăng ký:";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductName.Location = new System.Drawing.Point(17, 50);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(67, 15);
            this.labelProductName.TabIndex = 8;
            this.labelProductName.Text = "Sản phẩm:";
            // 
            // txtProductCategory
            // 
            this.txtProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCategory.Location = new System.Drawing.Point(90, 74);
            this.txtProductCategory.Name = "txtProductCategory";
            this.txtProductCategory.Size = new System.Drawing.Size(171, 21);
            this.txtProductCategory.TabIndex = 16;
            // 
            // labelProductCategory
            // 
            this.labelProductCategory.AutoSize = true;
            this.labelProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductCategory.Location = new System.Drawing.Point(50, 77);
            this.labelProductCategory.Name = "labelProductCategory";
            this.labelProductCategory.Size = new System.Drawing.Size(34, 15);
            this.labelProductCategory.TabIndex = 1;
            this.labelProductCategory.Text = "Loại:";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(90, 20);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(171, 21);
            this.txtProductCode.TabIndex = 14;
            // 
            // labelProductCode
            // 
            this.labelProductCode.AutoSize = true;
            this.labelProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductCode.Location = new System.Drawing.Point(56, 23);
            this.labelProductCode.Name = "labelProductCode";
            this.labelProductCode.Size = new System.Drawing.Size(28, 15);
            this.labelProductCode.TabIndex = 1;
            this.labelProductCode.Text = "Mã:";
            // 
            // grPackage
            // 
            this.grPackage.Controls.Add(this.txtPackageProductName);
            this.grPackage.Controls.Add(this.label18);
            this.grPackage.Controls.Add(this.txtPackageProductCode);
            this.grPackage.Controls.Add(this.label17);
            this.grPackage.Controls.Add(this.txtPersonPackage);
            this.grPackage.Controls.Add(this.label9);
            this.grPackage.Controls.Add(this.txtBatch);
            this.grPackage.Controls.Add(this.label7);
            this.grPackage.Controls.Add(this.txtQuantity);
            this.grPackage.Controls.Add(this.label6);
            this.grPackage.Controls.Add(this.txtPackageCode);
            this.grPackage.Controls.Add(this.label3);
            this.grPackage.Controls.Add(this.txtPackageCreateDate);
            this.grPackage.Controls.Add(this.label2);
            this.grPackage.Location = new System.Drawing.Point(286, 231);
            this.grPackage.Name = "grPackage";
            this.grPackage.Size = new System.Drawing.Size(267, 260);
            this.grPackage.TabIndex = 17;
            this.grPackage.TabStop = false;
            this.grPackage.Text = "Thông tin đóng gói";
            this.grPackage.Visible = false;
            // 
            // txtPackageProductName
            // 
            this.txtPackageProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageProductName.Location = new System.Drawing.Point(90, 100);
            this.txtPackageProductName.Name = "txtPackageProductName";
            this.txtPackageProductName.Size = new System.Drawing.Size(171, 21);
            this.txtPackageProductName.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(17, 103);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 15);
            this.label18.TabIndex = 38;
            this.label18.Text = "Sản phẩm:";
            // 
            // txtPackageProductCode
            // 
            this.txtPackageProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageProductCode.Location = new System.Drawing.Point(90, 73);
            this.txtPackageProductCode.Name = "txtPackageProductCode";
            this.txtPackageProductCode.Size = new System.Drawing.Size(171, 21);
            this.txtPackageProductCode.TabIndex = 22;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(37, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 15);
            this.label17.TabIndex = 36;
            this.label17.Text = "Mã SP:";
            // 
            // txtPersonPackage
            // 
            this.txtPersonPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonPackage.Location = new System.Drawing.Point(90, 181);
            this.txtPersonPackage.Name = "txtPersonPackage";
            this.txtPersonPackage.Size = new System.Drawing.Size(171, 21);
            this.txtPersonPackage.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "Người đóng:";
            // 
            // txtBatch
            // 
            this.txtBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatch.Location = new System.Drawing.Point(90, 154);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(171, 21);
            this.txtBatch.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(46, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "Số lô:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(90, 127);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(171, 21);
            this.txtQuantity.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "Số lượng:";
            // 
            // txtPackageCode
            // 
            this.txtPackageCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageCode.Location = new System.Drawing.Point(90, 46);
            this.txtPackageCode.Name = "txtPackageCode";
            this.txtPackageCode.Size = new System.Drawing.Size(171, 21);
            this.txtPackageCode.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Mã thùng:";
            // 
            // txtPackageCreateDate
            // 
            this.txtPackageCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageCreateDate.Location = new System.Drawing.Point(90, 19);
            this.txtPackageCreateDate.Name = "txtPackageCreateDate";
            this.txtPackageCreateDate.Size = new System.Drawing.Size(171, 21);
            this.txtPackageCreateDate.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ngày tạo:";
            // 
            // grExport1
            // 
            this.grExport1.Controls.Add(this.txtExportDate1);
            this.grExport1.Controls.Add(this.label5);
            this.grExport1.Controls.Add(this.txtOrderNumber1);
            this.grExport1.Controls.Add(this.label8);
            this.grExport1.Controls.Add(this.txtCustomerName1);
            this.grExport1.Controls.Add(this.label10);
            this.grExport1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grExport1.Location = new System.Drawing.Point(3, 152);
            this.grExport1.Name = "grExport1";
            this.grExport1.Size = new System.Drawing.Size(277, 109);
            this.grExport1.TabIndex = 6;
            this.grExport1.TabStop = false;
            this.grExport1.Text = "Đơn hàng";
            this.grExport1.Visible = false;
            // 
            // txtExportDate1
            // 
            this.txtExportDate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExportDate1.Location = new System.Drawing.Point(95, 76);
            this.txtExportDate1.Name = "txtExportDate1";
            this.txtExportDate1.Size = new System.Drawing.Size(174, 21);
            this.txtExportDate1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày xuất:";
            // 
            // txtOrderNumber1
            // 
            this.txtOrderNumber1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNumber1.Location = new System.Drawing.Point(95, 22);
            this.txtOrderNumber1.Name = "txtOrderNumber1";
            this.txtOrderNumber1.Size = new System.Drawing.Size(174, 21);
            this.txtOrderNumber1.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Mã đơn hàng:";
            // 
            // txtCustomerName1
            // 
            this.txtCustomerName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName1.Location = new System.Drawing.Point(95, 49);
            this.txtCustomerName1.Name = "txtCustomerName1";
            this.txtCustomerName1.Size = new System.Drawing.Size(174, 21);
            this.txtCustomerName1.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Khách hàng:";
            // 
            // grExport2
            // 
            this.grExport2.Controls.Add(this.txtExportDate2);
            this.grExport2.Controls.Add(this.label11);
            this.grExport2.Controls.Add(this.txtOrderNumber2);
            this.grExport2.Controls.Add(this.label12);
            this.grExport2.Controls.Add(this.txtCustomerName2);
            this.grExport2.Controls.Add(this.label13);
            this.grExport2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grExport2.Location = new System.Drawing.Point(3, 267);
            this.grExport2.Name = "grExport2";
            this.grExport2.Size = new System.Drawing.Size(277, 109);
            this.grExport2.TabIndex = 6;
            this.grExport2.TabStop = false;
            this.grExport2.Text = "Đơn hàng";
            this.grExport2.Visible = false;
            // 
            // txtExportDate2
            // 
            this.txtExportDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExportDate2.Location = new System.Drawing.Point(95, 76);
            this.txtExportDate2.Name = "txtExportDate2";
            this.txtExportDate2.Size = new System.Drawing.Size(174, 21);
            this.txtExportDate2.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(25, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "Ngày xuất:";
            // 
            // txtOrderNumber2
            // 
            this.txtOrderNumber2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNumber2.Location = new System.Drawing.Point(95, 22);
            this.txtOrderNumber2.Name = "txtOrderNumber2";
            this.txtOrderNumber2.Size = new System.Drawing.Size(174, 21);
            this.txtOrderNumber2.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Mã đơn hàng:";
            // 
            // txtCustomerName2
            // 
            this.txtCustomerName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName2.Location = new System.Drawing.Point(95, 49);
            this.txtCustomerName2.Name = "txtCustomerName2";
            this.txtCustomerName2.Size = new System.Drawing.Size(174, 21);
            this.txtCustomerName2.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 15);
            this.label13.TabIndex = 1;
            this.label13.Text = "Khách hàng:";
            // 
            // grExport3
            // 
            this.grExport3.Controls.Add(this.txtExportDate3);
            this.grExport3.Controls.Add(this.label14);
            this.grExport3.Controls.Add(this.txtOrderNumber3);
            this.grExport3.Controls.Add(this.label15);
            this.grExport3.Controls.Add(this.txtCustomerName3);
            this.grExport3.Controls.Add(this.label16);
            this.grExport3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grExport3.Location = new System.Drawing.Point(3, 382);
            this.grExport3.Name = "grExport3";
            this.grExport3.Size = new System.Drawing.Size(277, 109);
            this.grExport3.TabIndex = 18;
            this.grExport3.TabStop = false;
            this.grExport3.Text = "Đơn hàng";
            this.grExport3.Visible = false;
            // 
            // txtExportDate3
            // 
            this.txtExportDate3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExportDate3.Location = new System.Drawing.Point(95, 76);
            this.txtExportDate3.Name = "txtExportDate3";
            this.txtExportDate3.Size = new System.Drawing.Size(174, 21);
            this.txtExportDate3.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(25, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "Ngày xuất:";
            // 
            // txtOrderNumber3
            // 
            this.txtOrderNumber3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNumber3.Location = new System.Drawing.Point(95, 22);
            this.txtOrderNumber3.Name = "txtOrderNumber3";
            this.txtOrderNumber3.Size = new System.Drawing.Size(174, 21);
            this.txtOrderNumber3.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 15);
            this.label15.TabIndex = 1;
            this.label15.Text = "Mã đơn hàng:";
            // 
            // txtCustomerName3
            // 
            this.txtCustomerName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName3.Location = new System.Drawing.Point(95, 49);
            this.txtCustomerName3.Name = "txtCustomerName3";
            this.txtCustomerName3.Size = new System.Drawing.Size(174, 21);
            this.txtCustomerName3.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 15);
            this.label16.TabIndex = 1;
            this.label16.Text = "Khách hàng:";
            // 
            // panelChecking
            // 
            this.panelChecking.Controls.Add(this.grExport3);
            this.panelChecking.Controls.Add(this.grExport2);
            this.panelChecking.Controls.Add(this.grExport1);
            this.panelChecking.Controls.Add(this.grPackage);
            this.panelChecking.Controls.Add(this.grProduct);
            this.panelChecking.Controls.Add(this.grExport);
            this.panelChecking.Controls.Add(this.btnGetInfo);
            this.panelChecking.Controls.Add(this.labelChecking);
            this.panelChecking.Controls.Add(this.txtDacCode);
            this.panelChecking.Location = new System.Drawing.Point(12, 12);
            this.panelChecking.Name = "panelChecking";
            this.panelChecking.Size = new System.Drawing.Size(558, 498);
            this.panelChecking.TabIndex = 1;
            // 
            // frmDacChecking
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(582, 516);
            this.Controls.Add(this.panelChecking);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDacChecking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm tra xuất xứ tại cửa hàng";
            this.grExport.ResumeLayout(false);
            this.grExport.PerformLayout();
            this.grProduct.ResumeLayout(false);
            this.grProduct.PerformLayout();
            this.grPackage.ResumeLayout(false);
            this.grPackage.PerformLayout();
            this.grExport1.ResumeLayout(false);
            this.grExport1.PerformLayout();
            this.grExport2.ResumeLayout(false);
            this.grExport2.PerformLayout();
            this.grExport3.ResumeLayout(false);
            this.grExport3.PerformLayout();
            this.panelChecking.ResumeLayout(false);
            this.panelChecking.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelAgency;
        public System.Windows.Forms.TextBox txtDacCode;
        private System.Windows.Forms.Label labelChecking;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.GroupBox grExport;
        private System.Windows.Forms.TextBox txtExportDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label labelAgencyName;
        private System.Windows.Forms.GroupBox grProduct;
        private System.Windows.Forms.TextBox txtProductManufacture;
        private System.Windows.Forms.Label labelManufacture;
        private System.Windows.Forms.TextBox txtProductGeneralFormat;
        private System.Windows.Forms.TextBox txtProductRegisterNumber;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label labelGeneralFormat;
        private System.Windows.Forms.Label labelRegisterNumber;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.TextBox txtProductCategory;
        private System.Windows.Forms.Label labelProductCategory;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label labelProductCode;
        private System.Windows.Forms.GroupBox grPackage;
        private System.Windows.Forms.TextBox txtPersonPackage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPackageCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPackageCreateDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grExport1;
        private System.Windows.Forms.TextBox txtExportDate1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrderNumber1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCustomerName1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grExport2;
        private System.Windows.Forms.TextBox txtExportDate2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOrderNumber2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCustomerName2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grExport3;
        private System.Windows.Forms.TextBox txtExportDate3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtOrderNumber3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCustomerName3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panelChecking;
        private System.Windows.Forms.TextBox txtPackageProductName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPackageProductCode;
        private System.Windows.Forms.Label label17;
    }
}