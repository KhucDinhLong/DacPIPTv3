namespace PIPT
{
    partial class frmDacDeleteCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacDeleteCode));
            this.groupBoxDeleteCode = new System.Windows.Forms.GroupBox();
            this.gcDacCode = new DevExpress.XtraGrid.GridControl();
            this.gvDacCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDacCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelAddDacCode = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtDacCode = new System.Windows.Forms.TextBox();
            this.labelSearchCode = new System.Windows.Forms.Label();
            this.panelPackage = new System.Windows.Forms.Panel();
            this.btnDetailDelete = new System.Windows.Forms.Button();
            this.chkDeleteProductFromAgency = new DevExpress.XtraEditors.CheckEdit();
            this.chkDeleteProductFromWarehouse = new DevExpress.XtraEditors.CheckEdit();
            this.chkDeleteProductFromPackage = new DevExpress.XtraEditors.CheckEdit();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.groupBoxDeleteCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDacCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDacCode)).BeginInit();
            this.panelAddDacCode.SuspendLayout();
            this.panelPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteProductFromAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteProductFromWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteProductFromPackage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxDeleteCode
            // 
            this.groupBoxDeleteCode.Controls.Add(this.gcDacCode);
            this.groupBoxDeleteCode.Controls.Add(this.panelAddDacCode);
            this.groupBoxDeleteCode.Controls.Add(this.panelPackage);
            this.groupBoxDeleteCode.Controls.Add(this.lblProductCount);
            this.groupBoxDeleteCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDeleteCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDeleteCode.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDeleteCode.Name = "groupBoxDeleteCode";
            this.groupBoxDeleteCode.Size = new System.Drawing.Size(502, 580);
            this.groupBoxDeleteCode.TabIndex = 1;
            this.groupBoxDeleteCode.TabStop = false;
            this.groupBoxDeleteCode.Text = "Lựa chọn thông tin xóa sản phẩm";
            // 
            // gcDacCode
            // 
            this.gcDacCode.Location = new System.Drawing.Point(283, 18);
            this.gcDacCode.MainView = this.gvDacCode;
            this.gcDacCode.Name = "gcDacCode";
            this.gcDacCode.Size = new System.Drawing.Size(213, 550);
            this.gcDacCode.TabIndex = 11;
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
            this.colDacCode.Caption = "DacCode";
            this.colDacCode.FieldName = "DacCode";
            this.colDacCode.Name = "colDacCode";
            this.colDacCode.Visible = true;
            this.colDacCode.VisibleIndex = 0;
            // 
            // panelAddDacCode
            // 
            this.panelAddDacCode.Controls.Add(this.btnEnter);
            this.panelAddDacCode.Controls.Add(this.txtDacCode);
            this.panelAddDacCode.Controls.Add(this.labelSearchCode);
            this.panelAddDacCode.Location = new System.Drawing.Point(6, 18);
            this.panelAddDacCode.Name = "panelAddDacCode";
            this.panelAddDacCode.Size = new System.Drawing.Size(270, 70);
            this.panelAddDacCode.TabIndex = 10;
            // 
            // btnEnter
            // 
            this.btnEnter.Image = global::PIPT.Properties.Resources.submit1616;
            this.btnEnter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnter.Location = new System.Drawing.Point(109, 34);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(62, 28);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "Nhận";
            this.btnEnter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // txtDacCode
            // 
            this.txtDacCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDacCode.Location = new System.Drawing.Point(110, 5);
            this.txtDacCode.Name = "txtDacCode";
            this.txtDacCode.Size = new System.Drawing.Size(154, 23);
            this.txtDacCode.TabIndex = 0;
            this.txtDacCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDacCode_KeyPress);
            // 
            // labelSearchCode
            // 
            this.labelSearchCode.AutoSize = true;
            this.labelSearchCode.Location = new System.Drawing.Point(3, 9);
            this.labelSearchCode.Name = "labelSearchCode";
            this.labelSearchCode.Size = new System.Drawing.Size(101, 13);
            this.labelSearchCode.TabIndex = 4;
            this.labelSearchCode.Text = "Quét mã hoặc nhập";
            // 
            // panelPackage
            // 
            this.panelPackage.Controls.Add(this.btnDetailDelete);
            this.panelPackage.Controls.Add(this.chkDeleteProductFromAgency);
            this.panelPackage.Controls.Add(this.chkDeleteProductFromWarehouse);
            this.panelPackage.Controls.Add(this.chkDeleteProductFromPackage);
            this.panelPackage.Location = new System.Drawing.Point(6, 91);
            this.panelPackage.Name = "panelPackage";
            this.panelPackage.Size = new System.Drawing.Size(270, 111);
            this.panelPackage.TabIndex = 9;
            // 
            // btnDetailDelete
            // 
            this.btnDetailDelete.Image = global::PIPT.Properties.Resources.Delete1616;
            this.btnDetailDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailDelete.Location = new System.Drawing.Point(6, 78);
            this.btnDetailDelete.Name = "btnDetailDelete";
            this.btnDetailDelete.Size = new System.Drawing.Size(105, 24);
            this.btnDetailDelete.TabIndex = 7;
            this.btnDetailDelete.Text = "Xóa QRCode";
            this.btnDetailDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetailDelete.UseVisualStyleBackColor = true;
            this.btnDetailDelete.Click += new System.EventHandler(this.buttonDetailDelete_Click);
            // 
            // chkDeleteProductFromAgency
            // 
            this.chkDeleteProductFromAgency.Location = new System.Drawing.Point(6, 53);
            this.chkDeleteProductFromAgency.Name = "chkDeleteProductFromAgency";
            this.chkDeleteProductFromAgency.Properties.Caption = "Xóa sản phẩm khỏi đơn hàng";
            this.chkDeleteProductFromAgency.Size = new System.Drawing.Size(243, 19);
            this.chkDeleteProductFromAgency.TabIndex = 5;
            // 
            // chkDeleteProductFromWarehouse
            // 
            this.chkDeleteProductFromWarehouse.Location = new System.Drawing.Point(6, 28);
            this.chkDeleteProductFromWarehouse.Name = "chkDeleteProductFromWarehouse";
            this.chkDeleteProductFromWarehouse.Properties.Caption = "Xóa sản phẩm khỏi nhập kho";
            this.chkDeleteProductFromWarehouse.Size = new System.Drawing.Size(156, 19);
            this.chkDeleteProductFromWarehouse.TabIndex = 4;
            // 
            // chkDeleteProductFromPackage
            // 
            this.chkDeleteProductFromPackage.Location = new System.Drawing.Point(6, 3);
            this.chkDeleteProductFromPackage.Name = "chkDeleteProductFromPackage";
            this.chkDeleteProductFromPackage.Properties.Caption = "Xóa sản phẩm khỏi thùng";
            this.chkDeleteProductFromPackage.Size = new System.Drawing.Size(156, 19);
            this.chkDeleteProductFromPackage.TabIndex = 3;
            // 
            // lblProductCount
            // 
            this.lblProductCount.AutoSize = true;
            this.lblProductCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCount.Location = new System.Drawing.Point(6, 205);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(100, 13);
            this.lblProductCount.TabIndex = 0;
            this.lblProductCount.Text = "Số tem đã thêm:";
            // 
            // frmDacDeleteCode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(502, 580);
            this.Controls.Add(this.groupBoxDeleteCode);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDacDeleteCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xóa các mã sản phẩm";
            this.groupBoxDeleteCode.ResumeLayout(false);
            this.groupBoxDeleteCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDacCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDacCode)).EndInit();
            this.panelAddDacCode.ResumeLayout(false);
            this.panelAddDacCode.PerformLayout();
            this.panelPackage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteProductFromAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteProductFromWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteProductFromPackage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxDeleteCode;
        private System.Windows.Forms.Panel panelPackage;
        private System.Windows.Forms.Panel panelAddDacCode;
        private System.Windows.Forms.TextBox txtDacCode;
        private System.Windows.Forms.Label labelSearchCode;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblProductCount;
        private System.Windows.Forms.Button btnDetailDelete;
        private DevExpress.XtraEditors.CheckEdit chkDeleteProductFromAgency;
        private DevExpress.XtraEditors.CheckEdit chkDeleteProductFromPackage;
        private DevExpress.XtraEditors.CheckEdit chkDeleteProductFromWarehouse;
        private DevExpress.XtraGrid.GridControl gcDacCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDacCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDacCode;
    }
}