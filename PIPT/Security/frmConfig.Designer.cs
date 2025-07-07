namespace PIPT
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckInWarehouse = new System.Windows.Forms.CheckBox();
            this.buttonExportUpdate = new System.Windows.Forms.Button();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.AutoIncreaseOrder = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxAutoIncreaseContainer = new System.Windows.Forms.TextBox();
            this.textBoxAutoIncreasePackage = new System.Windows.Forms.TextBox();
            this.AutoIncreasePackage = new System.Windows.Forms.CheckBox();
            this.AutoIncreaseContainer = new System.Windows.Forms.CheckBox();
            this.textBoxAutoIncreaseWarehouse = new System.Windows.Forms.TextBox();
            this.AutoIncreaseWarehouse = new System.Windows.Forms.CheckBox();
            this.textBoxAutoIncreaseFactory = new System.Windows.Forms.TextBox();
            this.textBoxAutoIncreaseOrderStore = new System.Windows.Forms.TextBox();
            this.textBoxAutoIncreaseOrder = new System.Windows.Forms.TextBox();
            this.AutoIncreaseFactory = new System.Windows.Forms.CheckBox();
            this.AutoIncreaseOrderStore = new System.Windows.Forms.CheckBox();
            this.textBoxSeriLength = new System.Windows.Forms.TextBox();
            this.SeriLength = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckInWarehouse);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thiết lập xuất hàng";
            // 
            // CheckInWarehouse
            // 
            this.CheckInWarehouse.AutoSize = true;
            this.CheckInWarehouse.Checked = true;
            this.CheckInWarehouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckInWarehouse.Location = new System.Drawing.Point(6, 20);
            this.CheckInWarehouse.Name = "CheckInWarehouse";
            this.CheckInWarehouse.Size = new System.Drawing.Size(170, 19);
            this.CheckInWarehouse.TabIndex = 0;
            this.CheckInWarehouse.Text = "Kiểm tra QRCode đã nhập";
            this.CheckInWarehouse.UseVisualStyleBackColor = true;
            // 
            // buttonExportUpdate
            // 
            this.buttonExportUpdate.Location = new System.Drawing.Point(282, 309);
            this.buttonExportUpdate.Name = "buttonExportUpdate";
            this.buttonExportUpdate.Size = new System.Drawing.Size(75, 34);
            this.buttonExportUpdate.TabIndex = 1;
            this.buttonExportUpdate.Text = "Cập nhật";
            this.buttonExportUpdate.UseVisualStyleBackColor = true;
            this.buttonExportUpdate.Click += new System.EventHandler(this.buttonExportUpdate_Click);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(160, 314);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(88, 21);
            this.dateTimePickerStartDate.TabIndex = 1;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(17, 317);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(137, 15);
            this.labelStartDate.TabIndex = 2;
            this.labelStartDate.Text = "Ngày bắt đầu lấy dữ liệu";
            // 
            // AutoIncreaseOrder
            // 
            this.AutoIncreaseOrder.AutoSize = true;
            this.AutoIncreaseOrder.Checked = true;
            this.AutoIncreaseOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoIncreaseOrder.Location = new System.Drawing.Point(5, 45);
            this.AutoIncreaseOrder.Name = "AutoIncreaseOrder";
            this.AutoIncreaseOrder.Size = new System.Drawing.Size(170, 19);
            this.AutoIncreaseOrder.TabIndex = 0;
            this.AutoIncreaseOrder.Text = "Tự động tăng lệnh xuất ĐL";
            this.AutoIncreaseOrder.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSeriLength);
            this.groupBox2.Controls.Add(this.SeriLength);
            this.groupBox2.Controls.Add(this.textBoxAutoIncreaseContainer);
            this.groupBox2.Controls.Add(this.textBoxAutoIncreasePackage);
            this.groupBox2.Controls.Add(this.AutoIncreasePackage);
            this.groupBox2.Controls.Add(this.AutoIncreaseContainer);
            this.groupBox2.Controls.Add(this.textBoxAutoIncreaseWarehouse);
            this.groupBox2.Controls.Add(this.AutoIncreaseWarehouse);
            this.groupBox2.Controls.Add(this.textBoxAutoIncreaseFactory);
            this.groupBox2.Controls.Add(this.textBoxAutoIncreaseOrderStore);
            this.groupBox2.Controls.Add(this.textBoxAutoIncreaseOrder);
            this.groupBox2.Controls.Add(this.AutoIncreaseFactory);
            this.groupBox2.Controls.Add(this.AutoIncreaseOrder);
            this.groupBox2.Controls.Add(this.AutoIncreaseOrderStore);
            this.groupBox2.Location = new System.Drawing.Point(14, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 237);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thiết lập các mã lệnh";
            // 
            // textBoxAutoIncreaseContainer
            // 
            this.textBoxAutoIncreaseContainer.Location = new System.Drawing.Point(220, 134);
            this.textBoxAutoIncreaseContainer.Name = "textBoxAutoIncreaseContainer";
            this.textBoxAutoIncreaseContainer.Size = new System.Drawing.Size(123, 21);
            this.textBoxAutoIncreaseContainer.TabIndex = 8;
            this.textBoxAutoIncreaseContainer.Text = "CON000000000";
            // 
            // textBoxAutoIncreasePackage
            // 
            this.textBoxAutoIncreasePackage.Location = new System.Drawing.Point(220, 109);
            this.textBoxAutoIncreasePackage.Name = "textBoxAutoIncreasePackage";
            this.textBoxAutoIncreasePackage.Size = new System.Drawing.Size(123, 21);
            this.textBoxAutoIncreasePackage.TabIndex = 7;
            this.textBoxAutoIncreasePackage.Text = "PKG-00000-000";
            // 
            // AutoIncreasePackage
            // 
            this.AutoIncreasePackage.AutoSize = true;
            this.AutoIncreasePackage.Checked = true;
            this.AutoIncreasePackage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoIncreasePackage.Location = new System.Drawing.Point(5, 111);
            this.AutoIncreasePackage.Name = "AutoIncreasePackage";
            this.AutoIncreasePackage.Size = new System.Drawing.Size(153, 19);
            this.AutoIncreasePackage.TabIndex = 5;
            this.AutoIncreasePackage.Text = "Tự động tăng mã thùng";
            this.AutoIncreasePackage.UseVisualStyleBackColor = true;
            // 
            // AutoIncreaseContainer
            // 
            this.AutoIncreaseContainer.AutoSize = true;
            this.AutoIncreaseContainer.Checked = true;
            this.AutoIncreaseContainer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoIncreaseContainer.Location = new System.Drawing.Point(4, 136);
            this.AutoIncreaseContainer.Name = "AutoIncreaseContainer";
            this.AutoIncreaseContainer.Size = new System.Drawing.Size(145, 19);
            this.AutoIncreaseContainer.TabIndex = 6;
            this.AutoIncreaseContainer.Text = "Tự động tăng mã kiện";
            this.AutoIncreaseContainer.UseVisualStyleBackColor = true;
            // 
            // textBoxAutoIncreaseWarehouse
            // 
            this.textBoxAutoIncreaseWarehouse.Location = new System.Drawing.Point(220, 18);
            this.textBoxAutoIncreaseWarehouse.Name = "textBoxAutoIncreaseWarehouse";
            this.textBoxAutoIncreaseWarehouse.Size = new System.Drawing.Size(123, 21);
            this.textBoxAutoIncreaseWarehouse.TabIndex = 4;
            this.textBoxAutoIncreaseWarehouse.Text = "00000";
            // 
            // AutoIncreaseWarehouse
            // 
            this.AutoIncreaseWarehouse.AutoSize = true;
            this.AutoIncreaseWarehouse.Checked = true;
            this.AutoIncreaseWarehouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoIncreaseWarehouse.Location = new System.Drawing.Point(5, 20);
            this.AutoIncreaseWarehouse.Name = "AutoIncreaseWarehouse";
            this.AutoIncreaseWarehouse.Size = new System.Drawing.Size(156, 19);
            this.AutoIncreaseWarehouse.TabIndex = 3;
            this.AutoIncreaseWarehouse.Text = "Tự động tăng lệnh nhập";
            this.AutoIncreaseWarehouse.UseVisualStyleBackColor = true;
            // 
            // textBoxAutoIncreaseFactory
            // 
            this.textBoxAutoIncreaseFactory.Location = new System.Drawing.Point(220, 161);
            this.textBoxAutoIncreaseFactory.Name = "textBoxAutoIncreaseFactory";
            this.textBoxAutoIncreaseFactory.Size = new System.Drawing.Size(123, 21);
            this.textBoxAutoIncreaseFactory.TabIndex = 2;
            this.textBoxAutoIncreaseFactory.Text = "00000";
            // 
            // textBoxAutoIncreaseOrderStore
            // 
            this.textBoxAutoIncreaseOrderStore.Location = new System.Drawing.Point(220, 68);
            this.textBoxAutoIncreaseOrderStore.Name = "textBoxAutoIncreaseOrderStore";
            this.textBoxAutoIncreaseOrderStore.Size = new System.Drawing.Size(123, 21);
            this.textBoxAutoIncreaseOrderStore.TabIndex = 2;
            this.textBoxAutoIncreaseOrderStore.Text = "00000";
            // 
            // textBoxAutoIncreaseOrder
            // 
            this.textBoxAutoIncreaseOrder.Location = new System.Drawing.Point(220, 43);
            this.textBoxAutoIncreaseOrder.Name = "textBoxAutoIncreaseOrder";
            this.textBoxAutoIncreaseOrder.Size = new System.Drawing.Size(123, 21);
            this.textBoxAutoIncreaseOrder.TabIndex = 1;
            this.textBoxAutoIncreaseOrder.Text = "00000";
            // 
            // AutoIncreaseFactory
            // 
            this.AutoIncreaseFactory.AutoSize = true;
            this.AutoIncreaseFactory.Checked = true;
            this.AutoIncreaseFactory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoIncreaseFactory.Location = new System.Drawing.Point(4, 163);
            this.AutoIncreaseFactory.Name = "AutoIncreaseFactory";
            this.AutoIncreaseFactory.Size = new System.Drawing.Size(201, 19);
            this.AutoIncreaseFactory.TabIndex = 0;
            this.AutoIncreaseFactory.Text = "Tự động tăng lệnh xuất nhà máy";
            this.AutoIncreaseFactory.UseVisualStyleBackColor = true;
            // 
            // AutoIncreaseOrderStore
            // 
            this.AutoIncreaseOrderStore.AutoSize = true;
            this.AutoIncreaseOrderStore.Checked = true;
            this.AutoIncreaseOrderStore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoIncreaseOrderStore.Location = new System.Drawing.Point(4, 70);
            this.AutoIncreaseOrderStore.Name = "AutoIncreaseOrderStore";
            this.AutoIncreaseOrderStore.Size = new System.Drawing.Size(171, 19);
            this.AutoIncreaseOrderStore.TabIndex = 0;
            this.AutoIncreaseOrderStore.Text = "Tự động tăng lệnh xuất CH";
            this.AutoIncreaseOrderStore.UseVisualStyleBackColor = true;
            // 
            // textBoxSeriLength
            // 
            this.textBoxSeriLength.Location = new System.Drawing.Point(220, 210);
            this.textBoxSeriLength.Name = "textBoxSeriLength";
            this.textBoxSeriLength.Size = new System.Drawing.Size(123, 21);
            this.textBoxSeriLength.TabIndex = 10;
            this.textBoxSeriLength.Text = "0000000000";
            // 
            // SeriLength
            // 
            this.SeriLength.AutoSize = true;
            this.SeriLength.Checked = true;
            this.SeriLength.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SeriLength.Location = new System.Drawing.Point(4, 212);
            this.SeriLength.Name = "SeriLength";
            this.SeriLength.Size = new System.Drawing.Size(154, 19);
            this.SeriLength.TabIndex = 9;
            this.SeriLength.Text = "Chiều dài seri nhập vào";
            this.SeriLength.UseVisualStyleBackColor = true;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 351);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonExportUpdate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình hệ thống";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CheckInWarehouse;
        private System.Windows.Forms.Button buttonExportUpdate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.CheckBox AutoIncreaseOrder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox AutoIncreaseOrderStore;
        private System.Windows.Forms.TextBox textBoxAutoIncreaseOrder;
        private System.Windows.Forms.TextBox textBoxAutoIncreaseContainer;
        private System.Windows.Forms.TextBox textBoxAutoIncreasePackage;
        private System.Windows.Forms.CheckBox AutoIncreasePackage;
        private System.Windows.Forms.CheckBox AutoIncreaseContainer;
        private System.Windows.Forms.TextBox textBoxAutoIncreaseWarehouse;
        private System.Windows.Forms.CheckBox AutoIncreaseWarehouse;
        private System.Windows.Forms.TextBox textBoxAutoIncreaseOrderStore;
        private System.Windows.Forms.TextBox textBoxAutoIncreaseFactory;
        private System.Windows.Forms.CheckBox AutoIncreaseFactory;
        private System.Windows.Forms.TextBox textBoxSeriLength;
        private System.Windows.Forms.CheckBox SeriLength;
    }
}