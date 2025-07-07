
namespace PIPT.Report
{
    partial class frmImportDetailReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStockName = new System.Windows.Forms.Label();
            this.lblStockCode = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblInsertNumber = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gcDacCode = new DevExpress.XtraGrid.GridControl();
            this.gvDacCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDacCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDacCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDacCode)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStockName);
            this.panel1.Controls.Add(this.lblStockCode);
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.lblInsertNumber);
            this.panel1.Controls.Add(this.lblCreatedDate);
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 163);
            this.panel1.TabIndex = 0;
            // 
            // lblStockName
            // 
            this.lblStockName.AutoSize = true;
            this.lblStockName.Location = new System.Drawing.Point(98, 139);
            this.lblStockName.Name = "lblStockName";
            this.lblStockName.Size = new System.Drawing.Size(0, 13);
            this.lblStockName.TabIndex = 11;
            // 
            // lblStockCode
            // 
            this.lblStockCode.AutoSize = true;
            this.lblStockCode.Location = new System.Drawing.Point(98, 114);
            this.lblStockCode.Name = "lblStockCode";
            this.lblStockCode.Size = new System.Drawing.Size(0, 13);
            this.lblStockCode.TabIndex = 10;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(98, 89);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(0, 13);
            this.lblQuantity.TabIndex = 9;
            // 
            // lblInsertNumber
            // 
            this.lblInsertNumber.AutoSize = true;
            this.lblInsertNumber.Location = new System.Drawing.Point(98, 14);
            this.lblInsertNumber.Name = "lblInsertNumber";
            this.lblInsertNumber.Size = new System.Drawing.Size(0, 13);
            this.lblInsertNumber.TabIndex = 8;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(98, 39);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(0, 13);
            this.lblCreatedDate.TabIndex = 7;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(98, 64);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(0, 13);
            this.lblProductName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tên sản phẩm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên kho:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã kho:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lệnh:";
            // 
            // gcDacCode
            // 
            this.gcDacCode.Location = new System.Drawing.Point(12, 182);
            this.gcDacCode.MainView = this.gvDacCode;
            this.gcDacCode.Name = "gcDacCode";
            this.gcDacCode.Size = new System.Drawing.Size(302, 459);
            this.gcDacCode.TabIndex = 1;
            this.gcDacCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDacCode});
            // 
            // gvDacCode
            // 
            this.gvDacCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDacCode});
            this.gvDacCode.GridControl = this.gcDacCode;
            this.gvDacCode.Name = "gvDacCode";
            this.gvDacCode.OptionsView.ShowGroupPanel = false;
            // 
            // colDacCode
            // 
            this.colDacCode.Caption = "QR code";
            this.colDacCode.FieldName = "DacCode";
            this.colDacCode.Name = "colDacCode";
            this.colDacCode.Visible = true;
            this.colDacCode.VisibleIndex = 0;
            // 
            // frmImportDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 653);
            this.Controls.Add(this.gcDacCode);
            this.Controls.Add(this.panel1);
            this.Name = "frmImportDetailReport";
            this.Text = "Danh sách chi tiết";
            this.Load += new System.EventHandler(this.ImportDetailReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDacCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDacCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gcDacCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDacCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDacCode;
        private System.Windows.Forms.Label lblStockName;
        private System.Windows.Forms.Label lblStockCode;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblInsertNumber;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblProductName;
    }
}