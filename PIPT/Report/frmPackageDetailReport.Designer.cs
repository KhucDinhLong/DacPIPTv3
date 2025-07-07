
namespace PIPT.Report
{
    partial class frmPackageDetailReport
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
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblPackageCode = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblBatch = new System.Windows.Forms.Label();
            this.gcDacCode = new DevExpress.XtraGrid.GridControl();
            this.gvDacCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcDacCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDacCode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã thùng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày tạo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sản phẩm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số lô:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(77, 61);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(0, 13);
            this.lblProductName.TabIndex = 5;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(77, 37);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(0, 13);
            this.lblCreatedDate.TabIndex = 6;
            // 
            // lblPackageCode
            // 
            this.lblPackageCode.AutoSize = true;
            this.lblPackageCode.Location = new System.Drawing.Point(77, 13);
            this.lblPackageCode.Name = "lblPackageCode";
            this.lblPackageCode.Size = new System.Drawing.Size(0, 13);
            this.lblPackageCode.TabIndex = 7;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(77, 85);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(0, 13);
            this.lblQuantity.TabIndex = 8;
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(77, 109);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(0, 13);
            this.lblBatch.TabIndex = 9;
            // 
            // gcDacCode
            // 
            this.gcDacCode.Location = new System.Drawing.Point(13, 139);
            this.gcDacCode.MainView = this.gvDacCode;
            this.gcDacCode.Name = "gcDacCode";
            this.gcDacCode.Size = new System.Drawing.Size(299, 512);
            this.gcDacCode.TabIndex = 10;
            this.gcDacCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDacCode});
            // 
            // gvDacCode
            // 
            this.gvDacCode.GridControl = this.gcDacCode;
            this.gvDacCode.Name = "gvDacCode";
            this.gvDacCode.OptionsView.ShowGroupPanel = false;
            // 
            // frmPackageDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 663);
            this.Controls.Add(this.gcDacCode);
            this.Controls.Add(this.lblBatch);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPackageCode);
            this.Controls.Add(this.lblCreatedDate);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPackageDetailReport";
            this.Text = "frmPackageDetailReport";
            this.Load += new System.EventHandler(this.frmPackageDetailReport_Load);
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
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblPackageCode;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblBatch;
        private DevExpress.XtraGrid.GridControl gcDacCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDacCode;
    }
}