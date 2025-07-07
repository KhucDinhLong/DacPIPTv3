namespace PIPT.Agency
{
    partial class frmDacCatalogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacCatalogue));
            this.groupBoxStore = new System.Windows.Forms.GroupBox();
            this.buttonGetCatalogue = new System.Windows.Forms.Button();
            this.panelStore = new System.Windows.Forms.Panel();
            this.dateTimePickerModifiedDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.labelModifiedDate = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.txtLargeCode = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.dataGridViewCatalogue = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLargeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucDataButtonStore = new PIPT.Agency.ucDataButton();
            this.groupBoxStore.SuspendLayout();
            this.panelStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalogue)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxStore
            // 
            this.groupBoxStore.Controls.Add(this.buttonGetCatalogue);
            this.groupBoxStore.Controls.Add(this.panelStore);
            this.groupBoxStore.Controls.Add(this.dataGridViewCatalogue);
            this.groupBoxStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStore.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStore.Name = "groupBoxStore";
            this.groupBoxStore.Size = new System.Drawing.Size(504, 396);
            this.groupBoxStore.TabIndex = 1;
            this.groupBoxStore.TabStop = false;
            this.groupBoxStore.Text = "Thông tin";
            // 
            // buttonGetCatalogue
            // 
            this.buttonGetCatalogue.Image = global::PIPT.Agency.Properties.Resources.download;
            this.buttonGetCatalogue.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonGetCatalogue.Location = new System.Drawing.Point(431, 69);
            this.buttonGetCatalogue.Name = "buttonGetCatalogue";
            this.buttonGetCatalogue.Size = new System.Drawing.Size(70, 69);
            this.buttonGetCatalogue.TabIndex = 18;
            this.buttonGetCatalogue.Text = "Nhận thông tin";
            this.buttonGetCatalogue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonGetCatalogue.UseVisualStyleBackColor = true;
            this.buttonGetCatalogue.Click += new System.EventHandler(this.buttonGetCatalogue_Click);
            // 
            // panelStore
            // 
            this.panelStore.Controls.Add(this.dateTimePickerModifiedDate);
            this.panelStore.Controls.Add(this.dateTimePickerCreatedDate);
            this.panelStore.Controls.Add(this.labelModifiedDate);
            this.panelStore.Controls.Add(this.labelCreatedDate);
            this.panelStore.Controls.Add(this.txtLargeCode);
            this.panelStore.Controls.Add(this.txtRemark);
            this.panelStore.Controls.Add(this.textBoxCode);
            this.panelStore.Controls.Add(this.label2);
            this.panelStore.Controls.Add(this.textBoxName);
            this.panelStore.Controls.Add(this.label1);
            this.panelStore.Controls.Add(this.labelName);
            this.panelStore.Controls.Add(this.labelCode);
            this.panelStore.Location = new System.Drawing.Point(3, 20);
            this.panelStore.Name = "panelStore";
            this.panelStore.Size = new System.Drawing.Size(422, 118);
            this.panelStore.TabIndex = 9;
            // 
            // dateTimePickerModifiedDate
            // 
            this.dateTimePickerModifiedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerModifiedDate.Location = new System.Drawing.Point(320, 32);
            this.dateTimePickerModifiedDate.Name = "dateTimePickerModifiedDate";
            this.dateTimePickerModifiedDate.Size = new System.Drawing.Size(97, 21);
            this.dateTimePickerModifiedDate.TabIndex = 15;
            // 
            // dateTimePickerCreatedDate
            // 
            this.dateTimePickerCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCreatedDate.Location = new System.Drawing.Point(320, 5);
            this.dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            this.dateTimePickerCreatedDate.Size = new System.Drawing.Size(97, 21);
            this.dateTimePickerCreatedDate.TabIndex = 16;
            // 
            // labelModifiedDate
            // 
            this.labelModifiedDate.AutoSize = true;
            this.labelModifiedDate.Location = new System.Drawing.Point(261, 38);
            this.labelModifiedDate.Name = "labelModifiedDate";
            this.labelModifiedDate.Size = new System.Drawing.Size(53, 13);
            this.labelModifiedDate.TabIndex = 13;
            this.labelModifiedDate.Text = "Ngày sửa";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(263, 11);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 14;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // txtLargeCode
            // 
            this.txtLargeCode.Location = new System.Drawing.Point(81, 58);
            this.txtLargeCode.Name = "txtLargeCode";
            this.txtLargeCode.Size = new System.Drawing.Size(100, 21);
            this.txtLargeCode.TabIndex = 0;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(55, 85);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(195, 21);
            this.txtRemark.TabIndex = 1;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(55, 4);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(100, 21);
            this.textBoxCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ghi chú";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(55, 31);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(195, 21);
            this.textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã nhóm lớn";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(24, 34);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(25, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Tên";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(28, 7);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(21, 13);
            this.labelCode.TabIndex = 4;
            this.labelCode.Text = "Mã";
            // 
            // dataGridViewCatalogue
            // 
            this.dataGridViewCatalogue.AllowUserToAddRows = false;
            this.dataGridViewCatalogue.AllowUserToDeleteRows = false;
            this.dataGridViewCatalogue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCatalogue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ColumnCode,
            this.ColumnName,
            this.ColumnLargeCode,
            this.ColumnRemark,
            this.CreatedUser,
            this.ModifiedDate,
            this.CreatedDate,
            this.ModifiedUser});
            this.dataGridViewCatalogue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewCatalogue.Location = new System.Drawing.Point(3, 144);
            this.dataGridViewCatalogue.Name = "dataGridViewCatalogue";
            this.dataGridViewCatalogue.RowHeadersVisible = false;
            this.dataGridViewCatalogue.Size = new System.Drawing.Size(498, 249);
            this.dataGridViewCatalogue.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ColumnCode
            // 
            this.ColumnCode.DataPropertyName = "Code";
            this.ColumnCode.HeaderText = "Mã";
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.ReadOnly = true;
            this.ColumnCode.Width = 60;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "Name";
            this.ColumnName.HeaderText = "Tên";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 120;
            // 
            // ColumnLargeCode
            // 
            this.ColumnLargeCode.DataPropertyName = "LargeGroupCode";
            this.ColumnLargeCode.HeaderText = "LargeCode";
            this.ColumnLargeCode.Name = "ColumnLargeCode";
            this.ColumnLargeCode.Width = 80;
            // 
            // ColumnRemark
            // 
            this.ColumnRemark.DataPropertyName = "Remark";
            this.ColumnRemark.HeaderText = "Remark";
            this.ColumnRemark.Name = "ColumnRemark";
            // 
            // CreatedUser
            // 
            this.CreatedUser.DataPropertyName = "CreatedUser";
            this.CreatedUser.HeaderText = "Người tạo";
            this.CreatedUser.Name = "CreatedUser";
            // 
            // ModifiedDate
            // 
            this.ModifiedDate.DataPropertyName = "ModifiedDate";
            this.ModifiedDate.HeaderText = "Ngày sửa";
            this.ModifiedDate.Name = "ModifiedDate";
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "Ngày tạo";
            this.CreatedDate.Name = "CreatedDate";
            // 
            // ModifiedUser
            // 
            this.ModifiedUser.DataPropertyName = "ModifiedUser";
            this.ModifiedUser.HeaderText = "Người sửa";
            this.ModifiedUser.Name = "ModifiedUser";
            // 
            // ucDataButtonStore
            // 
            this.ucDataButtonStore.AddNewVisible = true;
            this.ucDataButtonStore.CancelVisible = true;
            this.ucDataButtonStore.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonStore.DeleteVisible = true;
            this.ucDataButtonStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonStore.EditVisible = true;
            this.ucDataButtonStore.ExcelVisible = false;
            this.ucDataButtonStore.IsContitnue = true;
            this.ucDataButtonStore.LanguageVisible = false;
            this.ucDataButtonStore.Location = new System.Drawing.Point(0, 396);
            this.ucDataButtonStore.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonStore.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonStore.MultiLanguageVisible = false;
            this.ucDataButtonStore.Name = "ucDataButtonStore";
            this.ucDataButtonStore.PrintVisible = false;
            this.ucDataButtonStore.ReportVisible = false;
            this.ucDataButtonStore.SaveVisible = true;
            this.ucDataButtonStore.Size = new System.Drawing.Size(504, 34);
            this.ucDataButtonStore.TabIndex = 0;
            this.ucDataButtonStore.InsertHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonStore_InsertHandler);
            this.ucDataButtonStore.EditHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonStore_EditHandler);
            this.ucDataButtonStore.SaveHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonStore_SaveHandler);
            this.ucDataButtonStore.DeleteHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonStore_DeleteHandler);
            this.ucDataButtonStore.CancelHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonStore_CancelHandler);
            this.ucDataButtonStore.CloseHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonStore_CloseHandler);
            // 
            // frmDacCatalogue
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(504, 430);
            this.Controls.Add(this.groupBoxStore);
            this.Controls.Add(this.ucDataButtonStore);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDacCatalogue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục nhóm SP";
            this.Load += new System.EventHandler(this.frmDacAgency_Load);
            this.groupBoxStore.ResumeLayout(false);
            this.panelStore.ResumeLayout(false);
            this.panelStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalogue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonStore;
        private System.Windows.Forms.GroupBox groupBoxStore;
        private System.Windows.Forms.DataGridView dataGridViewCatalogue;
        private System.Windows.Forms.Panel panelStore;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.TextBox txtLargeCode;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerModifiedDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreatedDate;
        private System.Windows.Forms.Label labelModifiedDate;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLargeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedUser;
        private System.Windows.Forms.Button buttonGetCatalogue;
    }
}