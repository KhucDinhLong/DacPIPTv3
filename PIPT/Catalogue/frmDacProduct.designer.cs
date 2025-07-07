namespace PIPT
{
    partial class frmDacProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacProduct));
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.gcProduct = new DevExpress.XtraGrid.GridControl();
            this.gvProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRegisterNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnManufacture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGeneralFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifiedUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelProduct = new System.Windows.Forms.Panel();
            this.lblModifiedDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lueProductCategory = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditViewCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCagegoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookUpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookUpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLargeGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.rtxtRemark = new System.Windows.Forms.RichTextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtGeneralFormat = new System.Windows.Forms.TextBox();
            this.txtManufacture = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtRegisterNumber = new System.Windows.Forms.TextBox();
            this.labelModifiedDate = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelRegisterNumber = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelGeneralFormat = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.ucDataButtonProduct = new PIPT.ucDataButton();
            this.groupBoxProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduct)).BeginInit();
            this.panelProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Controls.Add(this.gcProduct);
            this.groupBoxProduct.Controls.Add(this.panelProduct);
            this.groupBoxProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProduct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProduct.Location = new System.Drawing.Point(0, 0);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Size = new System.Drawing.Size(934, 426);
            this.groupBoxProduct.TabIndex = 1;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "Thông tin sản phẩm";
            // 
            // gcProduct
            // 
            this.gcProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcProduct.Location = new System.Drawing.Point(3, 148);
            this.gcProduct.MainView = this.gvProduct;
            this.gcProduct.Name = "gcProduct";
            this.gcProduct.Size = new System.Drawing.Size(928, 275);
            this.gcProduct.TabIndex = 10;
            this.gcProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProduct});
            // 
            // gvProduct
            // 
            this.gvProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnCode,
            this.gridColumnName,
            this.gridColumnCategoryId,
            this.gridColumnRegisterNumber,
            this.gridColumnManufacture,
            this.gridColumnGeneralFormat,
            this.gridColumnRemark,
            this.gridColumnCreatedUser,
            this.gridColumnCreatedDate,
            this.gridColumnModifiedUser,
            this.gridColumnModifiedDate,
            this.gridColumnActive});
            this.gvProduct.GridControl = this.gcProduct;
            this.gvProduct.Name = "gvProduct";
            this.gvProduct.OptionsView.ShowAutoFilterRow = true;
            this.gvProduct.OptionsView.ShowDetailButtons = false;
            this.gvProduct.OptionsView.ShowGroupPanel = false;
            this.gvProduct.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvProduct_FocusedRowChanged);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "Mã SP";
            this.gridColumnCode.CustomizationCaption = "Mã sản phẩm";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 0;
            this.gridColumnCode.Width = 58;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Tên SP";
            this.gridColumnName.CustomizationCaption = "Tên sản phẩm";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            this.gridColumnName.Width = 108;
            // 
            // gridColumnCategoryId
            // 
            this.gridColumnCategoryId.Caption = "Loại SP";
            this.gridColumnCategoryId.CustomizationCaption = "Loại sản phẩm";
            this.gridColumnCategoryId.FieldName = "ProductCategoryId";
            this.gridColumnCategoryId.Name = "gridColumnCategoryId";
            this.gridColumnCategoryId.Visible = true;
            this.gridColumnCategoryId.VisibleIndex = 2;
            this.gridColumnCategoryId.Width = 56;
            // 
            // gridColumnRegisterNumber
            // 
            this.gridColumnRegisterNumber.Caption = "Số đăng ký";
            this.gridColumnRegisterNumber.CustomizationCaption = "Register Number";
            this.gridColumnRegisterNumber.FieldName = "RegisterNumber";
            this.gridColumnRegisterNumber.Name = "gridColumnRegisterNumber";
            this.gridColumnRegisterNumber.Visible = true;
            this.gridColumnRegisterNumber.VisibleIndex = 3;
            this.gridColumnRegisterNumber.Width = 73;
            // 
            // gridColumnManufacture
            // 
            this.gridColumnManufacture.Caption = "Nhà sản xuất";
            this.gridColumnManufacture.CustomizationCaption = "Manufacture";
            this.gridColumnManufacture.FieldName = "Manufacture";
            this.gridColumnManufacture.Name = "gridColumnManufacture";
            this.gridColumnManufacture.Visible = true;
            this.gridColumnManufacture.VisibleIndex = 4;
            this.gridColumnManufacture.Width = 73;
            // 
            // gridColumnGeneralFormat
            // 
            this.gridColumnGeneralFormat.Caption = "Quy cách";
            this.gridColumnGeneralFormat.CustomizationCaption = "General Format";
            this.gridColumnGeneralFormat.FieldName = "GeneralFormat";
            this.gridColumnGeneralFormat.Name = "gridColumnGeneralFormat";
            this.gridColumnGeneralFormat.Visible = true;
            this.gridColumnGeneralFormat.VisibleIndex = 5;
            this.gridColumnGeneralFormat.Width = 73;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "Ghi chú";
            this.gridColumnRemark.CustomizationCaption = "Remark";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 6;
            this.gridColumnRemark.Width = 73;
            // 
            // gridColumnCreatedUser
            // 
            this.gridColumnCreatedUser.Caption = "Người tạo";
            this.gridColumnCreatedUser.CustomizationCaption = "Created User";
            this.gridColumnCreatedUser.FieldName = "CreatedUser";
            this.gridColumnCreatedUser.Name = "gridColumnCreatedUser";
            this.gridColumnCreatedUser.Visible = true;
            this.gridColumnCreatedUser.VisibleIndex = 7;
            this.gridColumnCreatedUser.Width = 73;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Ngày tạo";
            this.gridColumnCreatedDate.CustomizationCaption = "CreatedDate";
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 8;
            this.gridColumnCreatedDate.Width = 102;
            // 
            // gridColumnModifiedUser
            // 
            this.gridColumnModifiedUser.Caption = "Người sửa";
            this.gridColumnModifiedUser.CustomizationCaption = "Modified User";
            this.gridColumnModifiedUser.FieldName = "ModifiedUser";
            this.gridColumnModifiedUser.Name = "gridColumnModifiedUser";
            this.gridColumnModifiedUser.Visible = true;
            this.gridColumnModifiedUser.VisibleIndex = 9;
            this.gridColumnModifiedUser.Width = 69;
            // 
            // gridColumnModifiedDate
            // 
            this.gridColumnModifiedDate.Caption = "Ngày sửa";
            this.gridColumnModifiedDate.CustomizationCaption = "Modified Date";
            this.gridColumnModifiedDate.FieldName = "ModifiedDate";
            this.gridColumnModifiedDate.Name = "gridColumnModifiedDate";
            this.gridColumnModifiedDate.Visible = true;
            this.gridColumnModifiedDate.VisibleIndex = 10;
            this.gridColumnModifiedDate.Width = 99;
            // 
            // gridColumnActive
            // 
            this.gridColumnActive.Caption = "Active";
            this.gridColumnActive.FieldName = "Active";
            this.gridColumnActive.Name = "gridColumnActive";
            this.gridColumnActive.Visible = true;
            this.gridColumnActive.VisibleIndex = 11;
            this.gridColumnActive.Width = 53;
            // 
            // panelProduct
            // 
            this.panelProduct.Controls.Add(this.lblModifiedDate);
            this.panelProduct.Controls.Add(this.lblCreatedDate);
            this.panelProduct.Controls.Add(this.lueProductCategory);
            this.panelProduct.Controls.Add(this.txtProductCode);
            this.panelProduct.Controls.Add(this.rtxtRemark);
            this.panelProduct.Controls.Add(this.chkActive);
            this.panelProduct.Controls.Add(this.txtGeneralFormat);
            this.panelProduct.Controls.Add(this.txtManufacture);
            this.panelProduct.Controls.Add(this.txtProductName);
            this.panelProduct.Controls.Add(this.txtRegisterNumber);
            this.panelProduct.Controls.Add(this.labelModifiedDate);
            this.panelProduct.Controls.Add(this.labelDescription);
            this.panelProduct.Controls.Add(this.labelCreatedDate);
            this.panelProduct.Controls.Add(this.labelRegisterNumber);
            this.panelProduct.Controls.Add(this.labelName);
            this.panelProduct.Controls.Add(this.labelCategory);
            this.panelProduct.Controls.Add(this.labelGeneralFormat);
            this.panelProduct.Controls.Add(this.labelCode);
            this.panelProduct.Controls.Add(this.labelSize);
            this.panelProduct.Location = new System.Drawing.Point(73, 22);
            this.panelProduct.Name = "panelProduct";
            this.panelProduct.Size = new System.Drawing.Size(795, 120);
            this.panelProduct.TabIndex = 9;
            // 
            // lblModifiedDate
            // 
            this.lblModifiedDate.AutoSize = true;
            this.lblModifiedDate.Location = new System.Drawing.Point(550, 37);
            this.lblModifiedDate.Name = "lblModifiedDate";
            this.lblModifiedDate.Size = new System.Drawing.Size(0, 13);
            this.lblModifiedDate.TabIndex = 11;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(550, 10);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(0, 13);
            this.lblCreatedDate.TabIndex = 10;
            // 
            // lueProductCategory
            // 
            this.lueProductCategory.Location = new System.Drawing.Point(71, 62);
            this.lueProductCategory.Name = "lueProductCategory";
            this.lueProductCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueProductCategory.Properties.DisplayMember = "Name";
            this.lueProductCategory.Properties.ImmediatePopup = true;
            this.lueProductCategory.Properties.NullText = "";
            this.lueProductCategory.Properties.PopupView = this.gridLookUpEditViewCategory;
            this.lueProductCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueProductCategory.Properties.ValueMember = "Id";
            this.lueProductCategory.Size = new System.Drawing.Size(184, 20);
            this.lueProductCategory.TabIndex = 9;
            // 
            // gridLookUpEditViewCategory
            // 
            this.gridLookUpEditViewCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCagegoryID,
            this.gridColumnLookUpCode,
            this.gridColumnLookUpName,
            this.gridColumnLargeGroupCode});
            this.gridLookUpEditViewCategory.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditViewCategory.Name = "gridLookUpEditViewCategory";
            this.gridLookUpEditViewCategory.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditViewCategory.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditViewCategory.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnCagegoryID
            // 
            this.gridColumnCagegoryID.Caption = "ID";
            this.gridColumnCagegoryID.FieldName = "ID";
            this.gridColumnCagegoryID.Name = "gridColumnCagegoryID";
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
            // gridColumnLargeGroupCode
            // 
            this.gridColumnLargeGroupCode.Caption = "Mã nhóm lớn";
            this.gridColumnLargeGroupCode.FieldName = "LargeGroupCode";
            this.gridColumnLargeGroupCode.Name = "gridColumnLargeGroupCode";
            this.gridColumnLargeGroupCode.Visible = true;
            this.gridColumnLargeGroupCode.VisibleIndex = 2;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(71, 7);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(100, 21);
            this.txtProductCode.TabIndex = 0;
            // 
            // rtxtRemark
            // 
            this.rtxtRemark.Location = new System.Drawing.Point(550, 61);
            this.rtxtRemark.Name = "rtxtRemark";
            this.rtxtRemark.Size = new System.Drawing.Size(230, 46);
            this.rtxtRemark.TabIndex = 7;
            this.rtxtRemark.Text = "";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(683, 6);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(97, 17);
            this.chkActive.TabIndex = 8;
            this.chkActive.Text = "Còn hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtGeneralFormat
            // 
            this.txtGeneralFormat.Location = new System.Drawing.Point(351, 61);
            this.txtGeneralFormat.Name = "txtGeneralFormat";
            this.txtGeneralFormat.Size = new System.Drawing.Size(100, 21);
            this.txtGeneralFormat.TabIndex = 3;
            // 
            // txtManufacture
            // 
            this.txtManufacture.Location = new System.Drawing.Point(351, 34);
            this.txtManufacture.Name = "txtManufacture";
            this.txtManufacture.Size = new System.Drawing.Size(100, 21);
            this.txtManufacture.TabIndex = 3;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(71, 34);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(184, 21);
            this.txtProductName.TabIndex = 1;
            // 
            // txtRegisterNumber
            // 
            this.txtRegisterNumber.Location = new System.Drawing.Point(351, 7);
            this.txtRegisterNumber.Name = "txtRegisterNumber";
            this.txtRegisterNumber.Size = new System.Drawing.Size(100, 21);
            this.txtRegisterNumber.TabIndex = 2;
            // 
            // labelModifiedDate
            // 
            this.labelModifiedDate.AutoSize = true;
            this.labelModifiedDate.Location = new System.Drawing.Point(491, 37);
            this.labelModifiedDate.Name = "labelModifiedDate";
            this.labelModifiedDate.Size = new System.Drawing.Size(53, 13);
            this.labelModifiedDate.TabIndex = 4;
            this.labelModifiedDate.Text = "Ngày sửa";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(502, 61);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ghi chú";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(493, 10);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // labelRegisterNumber
            // 
            this.labelRegisterNumber.AutoSize = true;
            this.labelRegisterNumber.Location = new System.Drawing.Point(285, 10);
            this.labelRegisterNumber.Name = "labelRegisterNumber";
            this.labelRegisterNumber.Size = new System.Drawing.Size(60, 13);
            this.labelRegisterNumber.TabIndex = 4;
            this.labelRegisterNumber.Text = "Số đăng ký";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(25, 37);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(40, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Tên SP";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(24, 64);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(41, 13);
            this.labelCategory.TabIndex = 4;
            this.labelCategory.Text = "Loại SP";
            // 
            // labelGeneralFormat
            // 
            this.labelGeneralFormat.AutoSize = true;
            this.labelGeneralFormat.Location = new System.Drawing.Point(293, 64);
            this.labelGeneralFormat.Name = "labelGeneralFormat";
            this.labelGeneralFormat.Size = new System.Drawing.Size(52, 13);
            this.labelGeneralFormat.TabIndex = 4;
            this.labelGeneralFormat.Text = "Quy cách";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(29, 10);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(36, 13);
            this.labelCode.TabIndex = 4;
            this.labelCode.Text = "Mã SP";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(274, 37);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(71, 13);
            this.labelSize.TabIndex = 4;
            this.labelSize.Text = "Nhà sản xuất";
            // 
            // ucDataButtonProduct
            // 
            this.ucDataButtonProduct.AddNewVisible = true;
            this.ucDataButtonProduct.CancelVisible = true;
            this.ucDataButtonProduct.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonProduct.DeleteVisible = true;
            this.ucDataButtonProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonProduct.EditVisible = true;
            this.ucDataButtonProduct.ExcelVisible = false;
            this.ucDataButtonProduct.IsContitnue = true;
            this.ucDataButtonProduct.LanguageVisible = false;
            this.ucDataButtonProduct.Location = new System.Drawing.Point(0, 426);
            this.ucDataButtonProduct.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonProduct.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonProduct.MultiLanguageVisible = false;
            this.ucDataButtonProduct.Name = "ucDataButtonProduct";
            this.ucDataButtonProduct.PrintVisible = false;
            this.ucDataButtonProduct.ReportVisible = false;
            this.ucDataButtonProduct.SaveVisible = true;
            this.ucDataButtonProduct.Size = new System.Drawing.Size(934, 34);
            this.ucDataButtonProduct.TabIndex = 0;
            this.ucDataButtonProduct.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_InsertHandler);
            this.ucDataButtonProduct.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_EditHandler);
            this.ucDataButtonProduct.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_SaveHandler);
            this.ucDataButtonProduct.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_DeleteHandler);
            this.ucDataButtonProduct.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_CancelHandler);
            this.ucDataButtonProduct.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_CloseHandler);
            // 
            // frmDacProduct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(934, 460);
            this.Controls.Add(this.groupBoxProduct);
            this.Controls.Add(this.ucDataButtonProduct);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDacProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục sản phẩm";
            this.Load += new System.EventHandler(this.frmDacProduct_Load);
            this.groupBoxProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProduct)).EndInit();
            this.panelProduct.ResumeLayout(false);
            this.panelProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueProductCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonProduct;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private System.Windows.Forms.Panel panelProduct;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.RichTextBox rtxtRemark;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtManufacture;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtRegisterNumber;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.Label labelRegisterNumber;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelCategory;
        private DevExpress.XtraGrid.GridControl gcProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProduct;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRegisterNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnManufacture;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGeneralFormat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifiedUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActive;
        private DevExpress.XtraEditors.GridLookUpEdit lueProductCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditViewCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookUpCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookUpName;
        private System.Windows.Forms.TextBox txtGeneralFormat;
        private System.Windows.Forms.Label labelModifiedDate;
        private System.Windows.Forms.Label labelGeneralFormat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCagegoryID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLargeGroupCode;
        private System.Windows.Forms.Label lblModifiedDate;
        private System.Windows.Forms.Label lblCreatedDate;
    }
}