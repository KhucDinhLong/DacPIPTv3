namespace PIPT
{
    partial class frmDacSellCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacSellCount));
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.gridControlSellCount = new DevExpress.XtraGrid.GridControl();
            this.gridViewSellCount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUnitCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPromotionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTxtType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSellDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelSellCount = new System.Windows.Forms.Panel();
            this.gridLookUpEditProduct = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditViewCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnLookUpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookUpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textBoxUnitCode = new System.Windows.Forms.TextBox();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSellDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.textBoxPromotionCode = new System.Windows.Forms.TextBox();
            this.labelModifiedDate = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelGeneralFormat = new System.Windows.Forms.Label();
            this.labelUnitCode = new System.Windows.Forms.Label();
            this.ucDataButtonSellCount = new PIPT.ucDataButton();
            this.checkBoxTxtType = new System.Windows.Forms.CheckBox();
            this.comboBoxEditMemo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBoxProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSellCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSellCount)).BeginInit();
            this.panelSellCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMemo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Controls.Add(this.gridControlSellCount);
            this.groupBoxProduct.Controls.Add(this.panelSellCount);
            this.groupBoxProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProduct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProduct.Location = new System.Drawing.Point(0, 0);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Size = new System.Drawing.Size(934, 426);
            this.groupBoxProduct.TabIndex = 1;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "Thông tin sản phẩm";
            // 
            // gridControlProduct
            // 
            this.gridControlSellCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlSellCount.Location = new System.Drawing.Point(3, 148);
            this.gridControlSellCount.MainView = this.gridViewSellCount;
            this.gridControlSellCount.Name = "gridControlProduct";
            this.gridControlSellCount.Size = new System.Drawing.Size(928, 275);
            this.gridControlSellCount.TabIndex = 10;
            this.gridControlSellCount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSellCount});
            // 
            // gridViewProduct
            // 
            this.gridViewSellCount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnUnitCode,
            this.gridColumnProductCode,
            this.gridColumnPromotionCode,
            this.gridColumnTxtType,
            this.gridColumnSellDate,
            this.gridColumnMemo,
            this.gridColumnActive});
            this.gridViewSellCount.GridControl = this.gridControlSellCount;
            this.gridViewSellCount.Name = "gridViewProduct";
            this.gridViewSellCount.OptionsView.ShowAutoFilterRow = true;
            this.gridViewSellCount.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // gridColumnUnitCode
            // 
            this.gridColumnUnitCode.Caption = "Đầu mã";
            this.gridColumnUnitCode.CustomizationCaption = "4 số đầu mã an ninh";
            this.gridColumnUnitCode.FieldName = "UnitCode";
            this.gridColumnUnitCode.Name = "gridColumnUnitCode";
            this.gridColumnUnitCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnUnitCode.Visible = true;
            this.gridColumnUnitCode.VisibleIndex = 0;
            this.gridColumnUnitCode.Width = 58;
            // 
            // gridColumnProductCode
            // 
            this.gridColumnProductCode.Caption = "Mã SP";
            this.gridColumnProductCode.CustomizationCaption = "Mã sản phẩm";
            this.gridColumnProductCode.FieldName = "ProductCode";
            this.gridColumnProductCode.Name = "gridColumnProductCode";
            this.gridColumnProductCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnProductCode.Visible = true;
            this.gridColumnProductCode.VisibleIndex = 1;
            this.gridColumnProductCode.Width = 108;
            // 
            // gridColumnPromotionCode
            // 
            this.gridColumnPromotionCode.Caption = "Mã chương trình";
            this.gridColumnPromotionCode.CustomizationCaption = "Mã chương trình tích điểm";
            this.gridColumnPromotionCode.FieldName = "PromotionCode";
            this.gridColumnPromotionCode.Name = "gridColumnPromotionCode";
            this.gridColumnPromotionCode.Visible = true;
            this.gridColumnPromotionCode.VisibleIndex = 2;
            this.gridColumnPromotionCode.Width = 73;
            // 
            // gridColumnTxtType
            // 
            this.gridColumnTxtType.Caption = "Có tích điểm";
            this.gridColumnTxtType.CustomizationCaption = "Có tích điểm hay không";
            this.gridColumnTxtType.FieldName = "TxtType";
            this.gridColumnTxtType.Name = "gridColumnTxtType";
            this.gridColumnTxtType.Visible = true;
            this.gridColumnTxtType.VisibleIndex = 3;
            this.gridColumnTxtType.Width = 73;
            // 
            // gridColumnSellDate
            // 
            this.gridColumnSellDate.Caption = "Ngày tạo";
            this.gridColumnSellDate.CustomizationCaption = "Sell Date";
            this.gridColumnSellDate.FieldName = "SellDate";
            this.gridColumnSellDate.Name = "gridColumnSellDate";
            this.gridColumnSellDate.Visible = true;
            this.gridColumnSellDate.VisibleIndex = 4;
            this.gridColumnSellDate.Width = 102;
            // 
            // gridColumnMemo
            // 
            this.gridColumnMemo.Caption = "Kiểu tích điểm";
            this.gridColumnMemo.CustomizationCaption = "Memo";
            this.gridColumnMemo.FieldName = "Memo";
            this.gridColumnMemo.Name = "gridColumnMemo";
            this.gridColumnMemo.Visible = true;
            this.gridColumnMemo.VisibleIndex = 5;
            this.gridColumnMemo.Width = 99;
            // 
            // gridColumnActive
            // 
            this.gridColumnActive.Caption = "Active";
            this.gridColumnActive.FieldName = "Active";
            this.gridColumnActive.Name = "gridColumnActive";
            this.gridColumnActive.Visible = true;
            this.gridColumnActive.VisibleIndex = 6;
            this.gridColumnActive.Width = 53;
            // 
            // panelProduct
            // 
            this.panelSellCount.Controls.Add(this.comboBoxEditMemo);
            this.panelSellCount.Controls.Add(this.gridLookUpEditProduct);
            this.panelSellCount.Controls.Add(this.textBoxUnitCode);
            this.panelSellCount.Controls.Add(this.dateTimePickerEndDate);
            this.panelSellCount.Controls.Add(this.dateTimePickerSellDate);
            this.panelSellCount.Controls.Add(this.checkBoxTxtType);
            this.panelSellCount.Controls.Add(this.checkBoxActive);
            this.panelSellCount.Controls.Add(this.textBoxPromotionCode);
            this.panelSellCount.Controls.Add(this.labelModifiedDate);
            this.panelSellCount.Controls.Add(this.labelCreatedDate);
            this.panelSellCount.Controls.Add(this.labelName);
            this.panelSellCount.Controls.Add(this.labelCategory);
            this.panelSellCount.Controls.Add(this.labelGeneralFormat);
            this.panelSellCount.Controls.Add(this.labelUnitCode);
            this.panelSellCount.Location = new System.Drawing.Point(102, 22);
            this.panelSellCount.Name = "panelProduct";
            this.panelSellCount.Size = new System.Drawing.Size(755, 120);
            this.panelSellCount.TabIndex = 9;
            // 
            // gridLookUpEditProduct
            // 
            this.gridLookUpEditProduct.Location = new System.Drawing.Point(99, 62);
            this.gridLookUpEditProduct.Name = "gridLookUpEditProduct";
            this.gridLookUpEditProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditProduct.Properties.DisplayMember = "Name";
            this.gridLookUpEditProduct.Properties.ImmediatePopup = true;
            this.gridLookUpEditProduct.Properties.NullText = "";
            this.gridLookUpEditProduct.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEditProduct.Properties.ValueMember = "Code";
            this.gridLookUpEditProduct.Properties.View = this.gridLookUpEditViewCategory;
            this.gridLookUpEditProduct.Size = new System.Drawing.Size(184, 20);
            this.gridLookUpEditProduct.TabIndex = 9;
            // 
            // gridLookUpEditViewCategory
            // 
            this.gridLookUpEditViewCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnLookUpCode,
            this.gridColumnLookUpName});
            this.gridLookUpEditViewCategory.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditViewCategory.Name = "gridLookUpEditViewCategory";
            this.gridLookUpEditViewCategory.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditViewCategory.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditViewCategory.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnLookUpCode
            // 
            this.gridColumnLookUpCode.Caption = "Mã";
            this.gridColumnLookUpCode.FieldName = "Code";
            this.gridColumnLookUpCode.Name = "gridColumnLookUpCode";
            this.gridColumnLookUpCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnLookUpCode.Visible = true;
            this.gridColumnLookUpCode.VisibleIndex = 0;
            // 
            // gridColumnLookUpName
            // 
            this.gridColumnLookUpName.Caption = "Tên SP";
            this.gridColumnLookUpName.FieldName = "Name";
            this.gridColumnLookUpName.Name = "gridColumnLookUpName";
            this.gridColumnLookUpName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnLookUpName.Visible = true;
            this.gridColumnLookUpName.VisibleIndex = 1;
            // 
            // textBoxUnitCode
            // 
            this.textBoxUnitCode.Location = new System.Drawing.Point(99, 7);
            this.textBoxUnitCode.Name = "textBoxUnitCode";
            this.textBoxUnitCode.Size = new System.Drawing.Size(100, 21);
            this.textBoxUnitCode.TabIndex = 0;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(588, 59);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(98, 21);
            this.dateTimePickerEndDate.TabIndex = 6;
            this.dateTimePickerEndDate.Visible = false;
            // 
            // dateTimePickerSellDate
            // 
            this.dateTimePickerSellDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSellDate.Location = new System.Drawing.Point(588, 4);
            this.dateTimePickerSellDate.Name = "dateTimePickerSellDate";
            this.dateTimePickerSellDate.Size = new System.Drawing.Size(98, 21);
            this.dateTimePickerSellDate.TabIndex = 6;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Location = new System.Drawing.Point(588, 33);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(97, 17);
            this.checkBoxActive.TabIndex = 8;
            this.checkBoxActive.Text = "Còn hoạt động";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // textBoxPromotionCode
            // 
            this.textBoxPromotionCode.Location = new System.Drawing.Point(99, 34);
            this.textBoxPromotionCode.Name = "textBoxPromotionCode";
            this.textBoxPromotionCode.Size = new System.Drawing.Size(184, 21);
            this.textBoxPromotionCode.TabIndex = 1;
            // 
            // labelModifiedDate
            // 
            this.labelModifiedDate.AutoSize = true;
            this.labelModifiedDate.Location = new System.Drawing.Point(529, 65);
            this.labelModifiedDate.Name = "labelModifiedDate";
            this.labelModifiedDate.Size = new System.Drawing.Size(53, 13);
            this.labelModifiedDate.TabIndex = 4;
            this.labelModifiedDate.Text = "Ngày sửa";
            this.labelModifiedDate.Visible = false;
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(531, 10);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 37);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(85, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Mã chương trình";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(8, 65);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(54, 13);
            this.labelCategory.TabIndex = 4;
            this.labelCategory.Text = "Sản phẩm";
            // 
            // labelGeneralFormat
            // 
            this.labelGeneralFormat.AutoSize = true;
            this.labelGeneralFormat.Location = new System.Drawing.Point(311, 10);
            this.labelGeneralFormat.Name = "labelGeneralFormat";
            this.labelGeneralFormat.Size = new System.Drawing.Size(72, 13);
            this.labelGeneralFormat.TabIndex = 4;
            this.labelGeneralFormat.Text = "Kiểu tích điểm";
            // 
            // labelUnitCode
            // 
            this.labelUnitCode.AutoSize = true;
            this.labelUnitCode.Location = new System.Drawing.Point(8, 10);
            this.labelUnitCode.Name = "labelUnitCode";
            this.labelUnitCode.Size = new System.Drawing.Size(54, 13);
            this.labelUnitCode.TabIndex = 4;
            this.labelUnitCode.Text = "Unit Code";
            // 
            // ucDataButtonProduct
            // 
            this.ucDataButtonSellCount.AddNewVisible = true;
            this.ucDataButtonSellCount.CancelVisible = true;
            this.ucDataButtonSellCount.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonSellCount.DeleteVisible = true;
            this.ucDataButtonSellCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonSellCount.EditVisible = true;
            this.ucDataButtonSellCount.ExcelVisible = false;
            this.ucDataButtonSellCount.IsContitnue = true;
            this.ucDataButtonSellCount.LanguageVisible = false;
            this.ucDataButtonSellCount.Location = new System.Drawing.Point(0, 426);
            this.ucDataButtonSellCount.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonSellCount.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonSellCount.MultiLanguageVisible = false;
            this.ucDataButtonSellCount.Name = "ucDataButtonProduct";
            this.ucDataButtonSellCount.PrintVisible = false;
            this.ucDataButtonSellCount.ReportVisible = false;
            this.ucDataButtonSellCount.SaveVisible = true;
            this.ucDataButtonSellCount.Size = new System.Drawing.Size(934, 34);
            this.ucDataButtonSellCount.TabIndex = 0;
            this.ucDataButtonSellCount.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonSellCount_InsertHandler);
            this.ucDataButtonSellCount.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonSellCount_EditHandler);
            this.ucDataButtonSellCount.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonSellCount_SaveHandler);
            this.ucDataButtonSellCount.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonSellCount_DeleteHandler);
            this.ucDataButtonSellCount.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonSellCount_CancelHandler);
            this.ucDataButtonSellCount.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonSellCount_CloseHandler);
            // 
            // checkBoxTxtType
            // 
            this.checkBoxTxtType.AutoSize = true;
            this.checkBoxTxtType.Checked = true;
            this.checkBoxTxtType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTxtType.Location = new System.Drawing.Point(389, 33);
            this.checkBoxTxtType.Name = "checkBoxTxtType";
            this.checkBoxTxtType.Size = new System.Drawing.Size(84, 17);
            this.checkBoxTxtType.TabIndex = 8;
            this.checkBoxTxtType.Text = "Có tích điểm";
            this.checkBoxTxtType.UseVisualStyleBackColor = true;
            // 
            // comboBoxEditMemo
            // 
            this.comboBoxEditMemo.EditValue = "PersonalTime";
            this.comboBoxEditMemo.Location = new System.Drawing.Point(389, 7);
            this.comboBoxEditMemo.Name = "comboBoxEditMemo";
            this.comboBoxEditMemo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditMemo.Properties.Items.AddRange(new object[] {
            "PersonalTime",
            "PeriodicTime"});
            this.comboBoxEditMemo.Size = new System.Drawing.Size(121, 20);
            this.comboBoxEditMemo.TabIndex = 10;
            // 
            // frmDacSellCount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(934, 460);
            this.Controls.Add(this.groupBoxProduct);
            this.Controls.Add(this.ucDataButtonSellCount);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDacSellCount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm sản phẩm tích điểm";
            this.Load += new System.EventHandler(this.frmDacProduct_Load);
            this.groupBoxProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSellCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSellCount)).EndInit();
            this.panelSellCount.ResumeLayout(false);
            this.panelSellCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMemo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonSellCount;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private System.Windows.Forms.Panel panelSellCount;
        private System.Windows.Forms.TextBox textBoxUnitCode;
        private System.Windows.Forms.DateTimePicker dateTimePickerSellDate;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.TextBox textBoxPromotionCode;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelUnitCode;
        private System.Windows.Forms.Label labelCategory;
        private DevExpress.XtraGrid.GridControl gridControlSellCount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSellCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUnitCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPromotionCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTxtType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSellDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMemo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActive;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEditProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditViewCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookUpCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookUpName;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelModifiedDate;
        private System.Windows.Forms.Label labelGeneralFormat;
        private System.Windows.Forms.CheckBox checkBoxTxtType;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditMemo;
    }
}