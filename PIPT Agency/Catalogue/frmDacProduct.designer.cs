namespace PIPT.Agency
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
            this.buttonGetAllProduct = new System.Windows.Forms.Button();
            this.gridControlProduct = new DevExpress.XtraGrid.GridControl();
            this.gridViewProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.gridLookUpEditCategory = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditViewCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCagegoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookUpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookUpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLargeGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.richTextBoxRemark = new System.Windows.Forms.RichTextBox();
            this.dateTimePickerModifiedDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.textBoxGeneralFormat = new System.Windows.Forms.TextBox();
            this.textBoxManufacture = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxRegisterNumber = new System.Windows.Forms.TextBox();
            this.labelModifiedDate = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelRegisterNumber = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelGeneralFormat = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.ucDataButtonProduct = new PIPT.Agency.ucDataButton();
            this.groupBoxProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProduct)).BeginInit();
            this.panelProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Controls.Add(this.buttonGetAllProduct);
            this.groupBoxProduct.Controls.Add(this.gridControlProduct);
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
            // buttonGetAllProduct
            // 
            this.buttonGetAllProduct.Image = global::PIPT.Agency.Properties.Resources.download;
            this.buttonGetAllProduct.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonGetAllProduct.Location = new System.Drawing.Point(841, 74);
            this.buttonGetAllProduct.Name = "buttonGetAllProduct";
            this.buttonGetAllProduct.Size = new System.Drawing.Size(90, 68);
            this.buttonGetAllProduct.TabIndex = 14;
            this.buttonGetAllProduct.Text = "Nhận sản phẩm từ Server";
            this.buttonGetAllProduct.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonGetAllProduct.UseVisualStyleBackColor = true;
            this.buttonGetAllProduct.Click += new System.EventHandler(this.buttonGetAllProduct_Click);
            // 
            // gridControlProduct
            // 
            this.gridControlProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlProduct.Location = new System.Drawing.Point(3, 148);
            this.gridControlProduct.MainView = this.gridViewProduct;
            this.gridControlProduct.Name = "gridControlProduct";
            this.gridControlProduct.Size = new System.Drawing.Size(928, 275);
            this.gridControlProduct.TabIndex = 10;
            this.gridControlProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProduct});
            // 
            // gridViewProduct
            // 
            this.gridViewProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridViewProduct.GridControl = this.gridControlProduct;
            this.gridViewProduct.Name = "gridViewProduct";
            this.gridViewProduct.OptionsView.ShowAutoFilterRow = true;
            this.gridViewProduct.OptionsView.ShowGroupPanel = false;
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
            this.gridColumnCode.Width = 50;
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
            this.gridColumnName.Width = 93;
            // 
            // gridColumnCategoryId
            // 
            this.gridColumnCategoryId.Caption = "Loại SP";
            this.gridColumnCategoryId.CustomizationCaption = "Loại sản phẩm";
            this.gridColumnCategoryId.FieldName = "ProductCategoryId";
            this.gridColumnCategoryId.Name = "gridColumnCategoryId";
            this.gridColumnCategoryId.Visible = true;
            this.gridColumnCategoryId.VisibleIndex = 2;
            this.gridColumnCategoryId.Width = 48;
            // 
            // gridColumnRegisterNumber
            // 
            this.gridColumnRegisterNumber.Caption = "Số đăng ký";
            this.gridColumnRegisterNumber.CustomizationCaption = "Register Number";
            this.gridColumnRegisterNumber.FieldName = "RegisterNumber";
            this.gridColumnRegisterNumber.Name = "gridColumnRegisterNumber";
            this.gridColumnRegisterNumber.Visible = true;
            this.gridColumnRegisterNumber.VisibleIndex = 3;
            this.gridColumnRegisterNumber.Width = 63;
            // 
            // gridColumnManufacture
            // 
            this.gridColumnManufacture.Caption = "Nhà sản xuất";
            this.gridColumnManufacture.CustomizationCaption = "Manufacture";
            this.gridColumnManufacture.FieldName = "Manufacture";
            this.gridColumnManufacture.Name = "gridColumnManufacture";
            this.gridColumnManufacture.Visible = true;
            this.gridColumnManufacture.VisibleIndex = 4;
            this.gridColumnManufacture.Width = 63;
            // 
            // gridColumnGeneralFormat
            // 
            this.gridColumnGeneralFormat.Caption = "Quy cách";
            this.gridColumnGeneralFormat.CustomizationCaption = "General Format";
            this.gridColumnGeneralFormat.FieldName = "GeneralFormat";
            this.gridColumnGeneralFormat.Name = "gridColumnGeneralFormat";
            this.gridColumnGeneralFormat.Visible = true;
            this.gridColumnGeneralFormat.VisibleIndex = 5;
            this.gridColumnGeneralFormat.Width = 63;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "Ghi chú";
            this.gridColumnRemark.CustomizationCaption = "Remark";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 6;
            this.gridColumnRemark.Width = 63;
            // 
            // gridColumnCreatedUser
            // 
            this.gridColumnCreatedUser.Caption = "Người tạo";
            this.gridColumnCreatedUser.CustomizationCaption = "Created User";
            this.gridColumnCreatedUser.FieldName = "CreatedUser";
            this.gridColumnCreatedUser.Name = "gridColumnCreatedUser";
            this.gridColumnCreatedUser.Visible = true;
            this.gridColumnCreatedUser.VisibleIndex = 7;
            this.gridColumnCreatedUser.Width = 63;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Ngày tạo";
            this.gridColumnCreatedDate.CustomizationCaption = "CreatedDate";
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 8;
            this.gridColumnCreatedDate.Width = 63;
            // 
            // gridColumnModifiedUser
            // 
            this.gridColumnModifiedUser.Caption = "Người sửa";
            this.gridColumnModifiedUser.CustomizationCaption = "Modified User";
            this.gridColumnModifiedUser.FieldName = "ModifiedUser";
            this.gridColumnModifiedUser.Name = "gridColumnModifiedUser";
            this.gridColumnModifiedUser.Visible = true;
            this.gridColumnModifiedUser.VisibleIndex = 9;
            // 
            // gridColumnModifiedDate
            // 
            this.gridColumnModifiedDate.Caption = "Ngày sửa";
            this.gridColumnModifiedDate.CustomizationCaption = "Modified Date";
            this.gridColumnModifiedDate.FieldName = "ModifiedDate";
            this.gridColumnModifiedDate.Name = "gridColumnModifiedDate";
            this.gridColumnModifiedDate.Visible = true;
            this.gridColumnModifiedDate.VisibleIndex = 10;
            this.gridColumnModifiedDate.Width = 84;
            // 
            // gridColumnActive
            // 
            this.gridColumnActive.Caption = "Active";
            this.gridColumnActive.FieldName = "Active";
            this.gridColumnActive.Name = "gridColumnActive";
            this.gridColumnActive.Visible = true;
            this.gridColumnActive.VisibleIndex = 11;
            this.gridColumnActive.Width = 51;
            // 
            // panelProduct
            // 
            this.panelProduct.Controls.Add(this.gridLookUpEditCategory);
            this.panelProduct.Controls.Add(this.textBoxCode);
            this.panelProduct.Controls.Add(this.richTextBoxRemark);
            this.panelProduct.Controls.Add(this.dateTimePickerModifiedDate);
            this.panelProduct.Controls.Add(this.dateTimePickerCreatedDate);
            this.panelProduct.Controls.Add(this.checkBoxActive);
            this.panelProduct.Controls.Add(this.textBoxGeneralFormat);
            this.panelProduct.Controls.Add(this.textBoxManufacture);
            this.panelProduct.Controls.Add(this.textBoxName);
            this.panelProduct.Controls.Add(this.textBoxRegisterNumber);
            this.panelProduct.Controls.Add(this.labelModifiedDate);
            this.panelProduct.Controls.Add(this.labelDescription);
            this.panelProduct.Controls.Add(this.labelCreatedDate);
            this.panelProduct.Controls.Add(this.labelRegisterNumber);
            this.panelProduct.Controls.Add(this.labelName);
            this.panelProduct.Controls.Add(this.labelCategory);
            this.panelProduct.Controls.Add(this.labelGeneralFormat);
            this.panelProduct.Controls.Add(this.labelCode);
            this.panelProduct.Controls.Add(this.labelSize);
            this.panelProduct.Location = new System.Drawing.Point(12, 22);
            this.panelProduct.Name = "panelProduct";
            this.panelProduct.Size = new System.Drawing.Size(778, 120);
            this.panelProduct.TabIndex = 9;
            // 
            // gridLookUpEditCategory
            // 
            this.gridLookUpEditCategory.Location = new System.Drawing.Point(56, 62);
            this.gridLookUpEditCategory.Name = "gridLookUpEditCategory";
            this.gridLookUpEditCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditCategory.Properties.DisplayMember = "Name";
            this.gridLookUpEditCategory.Properties.ImmediatePopup = true;
            this.gridLookUpEditCategory.Properties.NullText = "";
            this.gridLookUpEditCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEditCategory.Properties.ValueMember = "Id";
            this.gridLookUpEditCategory.Properties.View = this.gridLookUpEditViewCategory;
            this.gridLookUpEditCategory.Size = new System.Drawing.Size(184, 20);
            this.gridLookUpEditCategory.TabIndex = 9;
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
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(56, 7);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(100, 21);
            this.textBoxCode.TabIndex = 0;
            // 
            // richTextBoxRemark
            // 
            this.richTextBoxRemark.Location = new System.Drawing.Point(535, 61);
            this.richTextBoxRemark.Name = "richTextBoxRemark";
            this.richTextBoxRemark.Size = new System.Drawing.Size(230, 46);
            this.richTextBoxRemark.TabIndex = 7;
            this.richTextBoxRemark.Text = "";
            // 
            // dateTimePickerModifiedDate
            // 
            this.dateTimePickerModifiedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerModifiedDate.Location = new System.Drawing.Point(535, 31);
            this.dateTimePickerModifiedDate.Name = "dateTimePickerModifiedDate";
            this.dateTimePickerModifiedDate.Size = new System.Drawing.Size(98, 21);
            this.dateTimePickerModifiedDate.TabIndex = 6;
            // 
            // dateTimePickerCreatedDate
            // 
            this.dateTimePickerCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCreatedDate.Location = new System.Drawing.Point(535, 4);
            this.dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            this.dateTimePickerCreatedDate.Size = new System.Drawing.Size(98, 21);
            this.dateTimePickerCreatedDate.TabIndex = 6;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Location = new System.Drawing.Point(668, 6);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(97, 17);
            this.checkBoxActive.TabIndex = 8;
            this.checkBoxActive.Text = "Còn hoạt động";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // textBoxGeneralFormat
            // 
            this.textBoxGeneralFormat.Location = new System.Drawing.Point(336, 61);
            this.textBoxGeneralFormat.Name = "textBoxGeneralFormat";
            this.textBoxGeneralFormat.Size = new System.Drawing.Size(100, 21);
            this.textBoxGeneralFormat.TabIndex = 3;
            // 
            // textBoxManufacture
            // 
            this.textBoxManufacture.Location = new System.Drawing.Point(336, 34);
            this.textBoxManufacture.Name = "textBoxManufacture";
            this.textBoxManufacture.Size = new System.Drawing.Size(100, 21);
            this.textBoxManufacture.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(56, 34);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(184, 21);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxRegisterNumber
            // 
            this.textBoxRegisterNumber.Location = new System.Drawing.Point(336, 7);
            this.textBoxRegisterNumber.Name = "textBoxRegisterNumber";
            this.textBoxRegisterNumber.Size = new System.Drawing.Size(100, 21);
            this.textBoxRegisterNumber.TabIndex = 2;
            // 
            // labelModifiedDate
            // 
            this.labelModifiedDate.AutoSize = true;
            this.labelModifiedDate.Location = new System.Drawing.Point(476, 37);
            this.labelModifiedDate.Name = "labelModifiedDate";
            this.labelModifiedDate.Size = new System.Drawing.Size(53, 13);
            this.labelModifiedDate.TabIndex = 4;
            this.labelModifiedDate.Text = "Ngày sửa";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(487, 61);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ghi chú";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(478, 10);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // labelRegisterNumber
            // 
            this.labelRegisterNumber.AutoSize = true;
            this.labelRegisterNumber.Location = new System.Drawing.Point(270, 10);
            this.labelRegisterNumber.Name = "labelRegisterNumber";
            this.labelRegisterNumber.Size = new System.Drawing.Size(60, 13);
            this.labelRegisterNumber.TabIndex = 4;
            this.labelRegisterNumber.Text = "Số đăng ký";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(10, 37);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(40, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Tên SP";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(9, 64);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(41, 13);
            this.labelCategory.TabIndex = 4;
            this.labelCategory.Text = "Loại SP";
            // 
            // labelGeneralFormat
            // 
            this.labelGeneralFormat.AutoSize = true;
            this.labelGeneralFormat.Location = new System.Drawing.Point(278, 64);
            this.labelGeneralFormat.Name = "labelGeneralFormat";
            this.labelGeneralFormat.Size = new System.Drawing.Size(52, 13);
            this.labelGeneralFormat.TabIndex = 4;
            this.labelGeneralFormat.Text = "Quy cách";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(14, 10);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(36, 13);
            this.labelCode.TabIndex = 4;
            this.labelCode.Text = "Mã SP";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(259, 37);
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
            this.ucDataButtonProduct.InsertHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonProduct_InsertHandler);
            this.ucDataButtonProduct.EditHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonProduct_EditHandler);
            this.ucDataButtonProduct.SaveHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonProduct_SaveHandler);
            this.ucDataButtonProduct.DeleteHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonProduct_DeleteHandler);
            this.ucDataButtonProduct.CancelHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonProduct_CancelHandler);
            this.ucDataButtonProduct.CloseHandler += new PIPT.Agency.ucDataButton.DataHandler(this.ucDataButtonProduct_CloseHandler);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProduct)).EndInit();
            this.panelProduct.ResumeLayout(false);
            this.panelProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViewCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonProduct;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private System.Windows.Forms.Panel panelProduct;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.RichTextBox richTextBoxRemark;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreatedDate;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.TextBox textBoxManufacture;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxRegisterNumber;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.Label labelRegisterNumber;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelCategory;
        private DevExpress.XtraGrid.GridControl gridControlProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProduct;
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
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEditCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditViewCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookUpCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookUpName;
        private System.Windows.Forms.DateTimePicker dateTimePickerModifiedDate;
        private System.Windows.Forms.TextBox textBoxGeneralFormat;
        private System.Windows.Forms.Label labelModifiedDate;
        private System.Windows.Forms.Label labelGeneralFormat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCagegoryID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLargeGroupCode;
        private System.Windows.Forms.Button buttonGetAllProduct;
    }
}