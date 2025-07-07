namespace PIPT
{
    partial class frmDacGetData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacGetData));
            this.groupBoxDacQueryCode = new System.Windows.Forms.GroupBox();
            this.txtUnitCode = new System.Windows.Forms.TextBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFrDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewLoadDacQueryCode = new System.Windows.Forms.DataGridView();
            this.ColQueryRecID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoadQueryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoadPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoadUnitCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoadDacCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoadStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelUnitCodeSample = new System.Windows.Forms.Label();
            this.labelUnitCode = new System.Windows.Forms.Label();
            this.labelToDate = new System.Windows.Forms.Label();
            this.labelFrDate = new System.Windows.Forms.Label();
            this.btnQueryData = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewDacQueryCode = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQRID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQueryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDacCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelSearchPhone = new System.Windows.Forms.Label();
            this.txtSearchPhone = new System.Windows.Forms.TextBox();
            this.labelSearchDacCode = new System.Windows.Forms.Label();
            this.txtSearchDacCode = new System.Windows.Forms.TextBox();
            this.groupBoxDacQueryCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoadDacQueryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDacQueryCode)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxDacQueryCode
            // 
            this.groupBoxDacQueryCode.Controls.Add(this.txtUnitCode);
            this.groupBoxDacQueryCode.Controls.Add(this.dtpToDate);
            this.groupBoxDacQueryCode.Controls.Add(this.dtpFrDate);
            this.groupBoxDacQueryCode.Controls.Add(this.dataGridViewLoadDacQueryCode);
            this.groupBoxDacQueryCode.Controls.Add(this.labelUnitCodeSample);
            this.groupBoxDacQueryCode.Controls.Add(this.labelUnitCode);
            this.groupBoxDacQueryCode.Controls.Add(this.labelToDate);
            this.groupBoxDacQueryCode.Controls.Add(this.labelFrDate);
            this.groupBoxDacQueryCode.Controls.Add(this.btnQueryData);
            this.groupBoxDacQueryCode.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDacQueryCode.Name = "groupBoxDacQueryCode";
            this.groupBoxDacQueryCode.Size = new System.Drawing.Size(629, 191);
            this.groupBoxDacQueryCode.TabIndex = 1;
            this.groupBoxDacQueryCode.TabStop = false;
            this.groupBoxDacQueryCode.Text = "Truy vấn dữ liệu";
            // 
            // txtUnitCode
            // 
            this.txtUnitCode.Location = new System.Drawing.Point(371, 19);
            this.txtUnitCode.Name = "txtUnitCode";
            this.txtUnitCode.Size = new System.Drawing.Size(100, 20);
            this.txtUnitCode.TabIndex = 2;
            this.txtUnitCode.Text = "\'9988\'";
            this.txtUnitCode.Visible = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(224, 19);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(90, 21);
            this.dtpToDate.TabIndex = 1;
            // 
            // dtpFrDate
            // 
            this.dtpFrDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrDate.Location = new System.Drawing.Point(62, 19);
            this.dtpFrDate.Name = "dtpFrDate";
            this.dtpFrDate.Size = new System.Drawing.Size(90, 21);
            this.dtpFrDate.TabIndex = 0;
            // 
            // dataGridViewLoadDacQueryCode
            // 
            this.dataGridViewLoadDacQueryCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoadDacQueryCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColQueryRecID,
            this.ColLoadQueryDate,
            this.ColLoadPhoneNumber,
            this.ColLoadUnitCode,
            this.ColLoadDacCode,
            this.ColLoadStatus});
            this.dataGridViewLoadDacQueryCode.Location = new System.Drawing.Point(6, 48);
            this.dataGridViewLoadDacQueryCode.Name = "dataGridViewLoadDacQueryCode";
            this.dataGridViewLoadDacQueryCode.RowHeadersVisible = false;
            this.dataGridViewLoadDacQueryCode.Size = new System.Drawing.Size(614, 136);
            this.dataGridViewLoadDacQueryCode.TabIndex = 2;
            // 
            // ColQueryRecID
            // 
            this.ColQueryRecID.DataPropertyName = "QueryRecID";
            this.ColQueryRecID.HeaderText = "QRID";
            this.ColQueryRecID.Name = "ColQueryRecID";
            this.ColQueryRecID.Width = 70;
            // 
            // ColLoadQueryDate
            // 
            this.ColLoadQueryDate.DataPropertyName = "QueryDate";
            this.ColLoadQueryDate.HeaderText = "QueryDate";
            this.ColLoadQueryDate.Name = "ColLoadQueryDate";
            this.ColLoadQueryDate.Width = 150;
            // 
            // ColLoadPhoneNumber
            // 
            this.ColLoadPhoneNumber.DataPropertyName = "PhoneNumber";
            this.ColLoadPhoneNumber.HeaderText = "Phone";
            this.ColLoadPhoneNumber.Name = "ColLoadPhoneNumber";
            this.ColLoadPhoneNumber.Width = 110;
            // 
            // ColLoadUnitCode
            // 
            this.ColLoadUnitCode.DataPropertyName = "UnitCode";
            this.ColLoadUnitCode.HeaderText = "Code";
            this.ColLoadUnitCode.Name = "ColLoadUnitCode";
            this.ColLoadUnitCode.Width = 50;
            // 
            // ColLoadDacCode
            // 
            this.ColLoadDacCode.DataPropertyName = "DacCode";
            this.ColLoadDacCode.HeaderText = "DacCode";
            this.ColLoadDacCode.Name = "ColLoadDacCode";
            this.ColLoadDacCode.Width = 150;
            // 
            // ColLoadStatus
            // 
            this.ColLoadStatus.DataPropertyName = "QueryStatus";
            this.ColLoadStatus.HeaderText = "Status";
            this.ColLoadStatus.Name = "ColLoadStatus";
            this.ColLoadStatus.Width = 55;
            // 
            // labelUnitCodeSample
            // 
            this.labelUnitCodeSample.AutoSize = true;
            this.labelUnitCodeSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnitCodeSample.Location = new System.Drawing.Point(477, 23);
            this.labelUnitCodeSample.Name = "labelUnitCodeSample";
            this.labelUnitCodeSample.Size = new System.Drawing.Size(78, 15);
            this.labelUnitCodeSample.TabIndex = 1;
            this.labelUnitCodeSample.Text = "\'2318\',\'2319\'";
            this.labelUnitCodeSample.Visible = false;
            // 
            // labelUnitCode
            // 
            this.labelUnitCode.AutoSize = true;
            this.labelUnitCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnitCode.Location = new System.Drawing.Point(320, 20);
            this.labelUnitCode.Name = "labelUnitCode";
            this.labelUnitCode.Size = new System.Drawing.Size(45, 15);
            this.labelUnitCode.TabIndex = 1;
            this.labelUnitCode.Text = "Mã KH";
            this.labelUnitCode.Visible = false;
            // 
            // labelToDate
            // 
            this.labelToDate.AutoSize = true;
            this.labelToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToDate.Location = new System.Drawing.Point(159, 20);
            this.labelToDate.Name = "labelToDate";
            this.labelToDate.Size = new System.Drawing.Size(59, 15);
            this.labelToDate.TabIndex = 1;
            this.labelToDate.Text = "Đến ngày";
            // 
            // labelFrDate
            // 
            this.labelFrDate.AutoSize = true;
            this.labelFrDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrDate.Location = new System.Drawing.Point(6, 20);
            this.labelFrDate.Name = "labelFrDate";
            this.labelFrDate.Size = new System.Drawing.Size(50, 15);
            this.labelFrDate.TabIndex = 1;
            this.labelFrDate.Text = "Từ ngày";
            // 
            // btnQueryData
            // 
            this.btnQueryData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueryData.Location = new System.Drawing.Point(558, 18);
            this.btnQueryData.Name = "btnQueryData";
            this.btnQueryData.Size = new System.Drawing.Size(62, 24);
            this.btnQueryData.TabIndex = 3;
            this.btnQueryData.Text = "Truy vấn";
            this.btnQueryData.UseVisualStyleBackColor = true;
            this.btnQueryData.Click += new System.EventHandler(this.buttonQueryData_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(651, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 24);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dataGridViewDacQueryCode
            // 
            this.dataGridViewDacQueryCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDacQueryCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnQRID,
            this.ColumnQueryDate,
            this.ColumnPhone,
            this.ColumnUnitCode,
            this.ColumnDacCode,
            this.ColumnSeries,
            this.ColumnStatus});
            this.dataGridViewDacQueryCode.Location = new System.Drawing.Point(12, 209);
            this.dataGridViewDacQueryCode.Name = "dataGridViewDacQueryCode";
            this.dataGridViewDacQueryCode.RowHeadersVisible = false;
            this.dataGridViewDacQueryCode.Size = new System.Drawing.Size(816, 370);
            this.dataGridViewDacQueryCode.TabIndex = 3;
            // 
            // ColumnID
            // 
            this.ColumnID.DataPropertyName = "ID";
            this.ColumnID.HeaderText = "STT";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.Width = 70;
            // 
            // ColumnQRID
            // 
            this.ColumnQRID.DataPropertyName = "QueryRecID";
            this.ColumnQRID.HeaderText = "QRID";
            this.ColumnQRID.Name = "ColumnQRID";
            this.ColumnQRID.Width = 70;
            // 
            // ColumnQueryDate
            // 
            this.ColumnQueryDate.DataPropertyName = "QueryDate";
            this.ColumnQueryDate.HeaderText = "QueryDate";
            this.ColumnQueryDate.Name = "ColumnQueryDate";
            this.ColumnQueryDate.Width = 160;
            // 
            // ColumnPhone
            // 
            this.ColumnPhone.DataPropertyName = "PhoneNumber";
            this.ColumnPhone.HeaderText = "Phone";
            this.ColumnPhone.Name = "ColumnPhone";
            this.ColumnPhone.Width = 120;
            // 
            // ColumnUnitCode
            // 
            this.ColumnUnitCode.DataPropertyName = "UnitCode";
            this.ColumnUnitCode.HeaderText = "UnitCode";
            this.ColumnUnitCode.Name = "ColumnUnitCode";
            this.ColumnUnitCode.Width = 70;
            // 
            // ColumnDacCode
            // 
            this.ColumnDacCode.DataPropertyName = "DacCode";
            this.ColumnDacCode.HeaderText = "DacCode";
            this.ColumnDacCode.Name = "ColumnDacCode";
            this.ColumnDacCode.Width = 160;
            // 
            // ColumnSeries
            // 
            this.ColumnSeries.DataPropertyName = "Series";
            this.ColumnSeries.HeaderText = "Series";
            this.ColumnSeries.Name = "ColumnSeries";
            this.ColumnSeries.Width = 70;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "QueryStatus";
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.Width = 70;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(651, 147);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(764, 147);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(64, 23);
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Text = "Xuất";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmount.Location = new System.Drawing.Point(647, 177);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(40, 15);
            this.labelAmount.TabIndex = 1;
            this.labelAmount.Text = "SL: 0";
            // 
            // labelSearchPhone
            // 
            this.labelSearchPhone.AutoSize = true;
            this.labelSearchPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchPhone.Location = new System.Drawing.Point(648, 60);
            this.labelSearchPhone.Name = "labelSearchPhone";
            this.labelSearchPhone.Size = new System.Drawing.Size(35, 15);
            this.labelSearchPhone.TabIndex = 1;
            this.labelSearchPhone.Text = "Số đt";
            // 
            // txtSearchPhone
            // 
            this.txtSearchPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchPhone.Location = new System.Drawing.Point(650, 78);
            this.txtSearchPhone.Name = "txtSearchPhone";
            this.txtSearchPhone.Size = new System.Drawing.Size(129, 21);
            this.txtSearchPhone.TabIndex = 5;
            // 
            // labelSearchDacCode
            // 
            this.labelSearchDacCode.AutoSize = true;
            this.labelSearchDacCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchDacCode.Location = new System.Drawing.Point(648, 102);
            this.labelSearchDacCode.Name = "labelSearchDacCode";
            this.labelSearchDacCode.Size = new System.Drawing.Size(52, 15);
            this.labelSearchDacCode.TabIndex = 1;
            this.labelSearchDacCode.Text = "Mã DAC";
            // 
            // txtSearchDacCode
            // 
            this.txtSearchDacCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchDacCode.Location = new System.Drawing.Point(651, 120);
            this.txtSearchDacCode.Name = "txtSearchDacCode";
            this.txtSearchDacCode.Size = new System.Drawing.Size(177, 21);
            this.txtSearchDacCode.TabIndex = 6;
            // 
            // frmDacGetData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(840, 591);
            this.Controls.Add(this.txtSearchDacCode);
            this.Controls.Add(this.txtSearchPhone);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridViewDacQueryCode);
            this.Controls.Add(this.groupBoxDacQueryCode);
            this.Controls.Add(this.labelSearchDacCode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelSearchPhone);
            this.Controls.Add(this.labelAmount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDacGetData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lấy dữ liệu khách hàng đã truy vấn từ DAC";
            this.groupBoxDacQueryCode.ResumeLayout(false);
            this.groupBoxDacQueryCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoadDacQueryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDacQueryCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDacQueryCode;
        private System.Windows.Forms.DataGridView dataGridViewLoadDacQueryCode;
        private System.Windows.Forms.Label labelFrDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnQueryData;
        private System.Windows.Forms.DataGridView dataGridViewDacQueryCode;
        private System.Windows.Forms.TextBox txtUnitCode;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFrDate;
        private System.Windows.Forms.Label labelUnitCode;
        private System.Windows.Forms.Label labelToDate;
        private System.Windows.Forms.Label labelUnitCodeSample;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQRID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQueryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDacCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSeries;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQueryRecID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoadQueryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoadPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoadUnitCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoadDacCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoadStatus;
        private System.Windows.Forms.Label labelSearchPhone;
        private System.Windows.Forms.TextBox txtSearchPhone;
        private System.Windows.Forms.Label labelSearchDacCode;
        private System.Windows.Forms.TextBox txtSearchDacCode;
    }
}