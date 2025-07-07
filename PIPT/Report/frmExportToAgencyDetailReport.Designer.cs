
namespace PIPT.Report
{
    partial class frmExportToAgencyDetailReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gcDacCode = new DevExpress.XtraGrid.GridControl();
            this.gvDacCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblAgencyName = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblStockName = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.colDacCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcDacCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDacCode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lệnh:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Khách hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sản phẩm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kho:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày xuất:";
            // 
            // gcDacCode
            // 
            this.gcDacCode.Location = new System.Drawing.Point(13, 175);
            this.gcDacCode.MainView = this.gvDacCode;
            this.gcDacCode.Name = "gcDacCode";
            this.gcDacCode.Size = new System.Drawing.Size(429, 466);
            this.gcDacCode.TabIndex = 6;
            this.gcDacCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDacCode});
            // 
            // gvDacCode
            // 
            this.gvDacCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDacCode,
            this.colProductName});
            this.gvDacCode.GridControl = this.gcDacCode;
            this.gvDacCode.Name = "gvDacCode";
            this.gvDacCode.OptionsView.ShowGroupPanel = false;
            // 
            // lblAgencyName
            // 
            this.lblAgencyName.AutoSize = true;
            this.lblAgencyName.Location = new System.Drawing.Point(87, 40);
            this.lblAgencyName.Name = "lblAgencyName";
            this.lblAgencyName.Size = new System.Drawing.Size(0, 13);
            this.lblAgencyName.TabIndex = 7;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(87, 13);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(0, 13);
            this.lblOrderNumber.TabIndex = 8;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(87, 67);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(0, 13);
            this.lblProductName.TabIndex = 9;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(87, 94);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(0, 13);
            this.lblQuantity.TabIndex = 10;
            // 
            // lblStockName
            // 
            this.lblStockName.AutoSize = true;
            this.lblStockName.Location = new System.Drawing.Point(87, 121);
            this.lblStockName.Name = "lblStockName";
            this.lblStockName.Size = new System.Drawing.Size(0, 13);
            this.lblStockName.TabIndex = 11;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(87, 148);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(0, 13);
            this.lblCreatedDate.TabIndex = 12;
            // 
            // colDacCode
            // 
            this.colDacCode.Caption = "QR code";
            this.colDacCode.FieldName = "DacCode";
            this.colDacCode.Name = "colDacCode";
            this.colDacCode.Visible = true;
            this.colDacCode.VisibleIndex = 0;
            this.colDacCode.Width = 99;
            // 
            // colProductName
            // 
            this.colProductName.Caption = "Sản phẩm";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 1;
            this.colProductName.Width = 312;
            // 
            // frmExportToAgencyDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 653);
            this.Controls.Add(this.lblCreatedDate);
            this.Controls.Add(this.lblStockName);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.lblAgencyName);
            this.Controls.Add(this.gcDacCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmExportToAgencyDetailReport";
            this.Text = "frmExportToAgencyDetailReport";
            this.Load += new System.EventHandler(this.frmExportToAgencyDetailReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDacCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDacCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.GridControl gcDacCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDacCode;
        private System.Windows.Forms.Label lblAgencyName;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblStockName;
        private System.Windows.Forms.Label lblCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDacCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
    }
}