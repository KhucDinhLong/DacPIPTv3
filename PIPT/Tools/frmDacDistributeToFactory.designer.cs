namespace PIPT
{
    partial class frmDacDistributeToFactory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacDistributeToFactory));
            this.groupBoxFactory = new System.Windows.Forms.GroupBox();
            this.gridControlDistributor = new DevExpress.XtraGrid.GridControl();
            this.gridViewDistributor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFactoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProvinceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelAddDacCode = new System.Windows.Forms.Panel();
            this.gridLookUpEditProductChoose = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.addSerialCodeButton = new System.Windows.Forms.Button();
            this.ToSeriTextBox = new System.Windows.Forms.TextBox();
            this.FrSeriTextBox = new System.Windows.Forms.TextBox();
            this.buttonDetailDelete = new System.Windows.Forms.Button();
            this.buttonUpdateDetail = new System.Windows.Forms.Button();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.textBoxDacCode = new System.Windows.Forms.TextBox();
            this.ToSeriLabel = new System.Windows.Forms.Label();
            this.FrSeriLabel = new System.Windows.Forms.Label();
            this.labelSearchCode = new System.Windows.Forms.Label();
            this.panelDistributeToFactory = new System.Windows.Forms.Panel();
            this.buttonRefreshAgency = new System.Windows.Forms.Button();
            this.checkEditKeepOrder = new DevExpress.XtraEditors.CheckEdit();
            this.gridLookUpEditProduct = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditProductView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLookUpEditFactory = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditAgencyView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxOrderNumber = new System.Windows.Forms.TextBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.comboBoxProvince = new System.Windows.Forms.ComboBox();
            this.dateTimePickerCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelProvince = new System.Windows.Forms.Label();
            this.labelOrderNumber = new System.Windows.Forms.Label();
            this.labelFactory = new System.Windows.Forms.Label();
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnDistributorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDacCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColumProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelProductCount = new System.Windows.Forms.Label();
            this.ucDataButtonAgency = new PIPT.ucDataButton();
            this.groupBoxFactory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDistributor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDistributor)).BeginInit();
            this.panelAddDacCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProductChoose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panelDistributeToFactory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditKeepOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProductView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditFactory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditAgencyView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFactory
            // 
            this.groupBoxFactory.Controls.Add(this.gridControlDistributor);
            this.groupBoxFactory.Controls.Add(this.panelAddDacCode);
            this.groupBoxFactory.Controls.Add(this.panelDistributeToFactory);
            this.groupBoxFactory.Controls.Add(this.dataGridViewDetails);
            this.groupBoxFactory.Controls.Add(this.labelProductCount);
            this.groupBoxFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFactory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFactory.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFactory.Name = "groupBoxFactory";
            this.groupBoxFactory.Size = new System.Drawing.Size(730, 546);
            this.groupBoxFactory.TabIndex = 1;
            this.groupBoxFactory.TabStop = false;
            this.groupBoxFactory.Text = "Thông tin xưởng sản xuất";
            // 
            // gridControlDistributor
            // 
            this.gridControlDistributor.EmbeddedNavigator.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gridControlDistributor.Location = new System.Drawing.Point(3, 184);
            this.gridControlDistributor.MainView = this.gridViewDistributor;
            this.gridControlDistributor.Name = "gridControlDistributor";
            this.gridControlDistributor.Size = new System.Drawing.Size(410, 356);
            this.gridControlDistributor.TabIndex = 12;
            this.gridControlDistributor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDistributor});
            // 
            // gridViewDistributor
            // 
            this.gridViewDistributor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnOrder,
            this.gridColumnFactoryCode,
            this.gridColumnQuantity,
            this.gridColumnCreatedDate,
            this.gridColumActive,
            this.gridColumnProvinceCode,
            this.gridColumnDescription});
            this.gridViewDistributor.GridControl = this.gridControlDistributor;
            this.gridViewDistributor.Name = "gridViewDistributor";
            this.gridViewDistributor.OptionsBehavior.Editable = false;
            this.gridViewDistributor.OptionsView.ShowAutoFilterRow = true;
            this.gridViewDistributor.OptionsView.ShowGroupPanel = false;
            this.gridViewDistributor.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDistributor_FocusedRowChanged);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            this.gridColumnID.Width = 46;
            // 
            // gridColumnOrder
            // 
            this.gridColumnOrder.Caption = "Lệnh";
            this.gridColumnOrder.FieldName = "OrderNumber";
            this.gridColumnOrder.Name = "gridColumnOrder";
            this.gridColumnOrder.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnOrder.Visible = true;
            this.gridColumnOrder.VisibleIndex = 1;
            this.gridColumnOrder.Width = 61;
            // 
            // gridColumnFactoryCode
            // 
            this.gridColumnFactoryCode.Caption = "Mã XSX";
            this.gridColumnFactoryCode.FieldName = "FactoryCode";
            this.gridColumnFactoryCode.Name = "gridColumnFactoryCode";
            this.gridColumnFactoryCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnFactoryCode.Visible = true;
            this.gridColumnFactoryCode.VisibleIndex = 2;
            this.gridColumnFactoryCode.Width = 67;
            // 
            // gridColumnQuantity
            // 
            this.gridColumnQuantity.Caption = "Số lượng";
            this.gridColumnQuantity.FieldName = "Quantity";
            this.gridColumnQuantity.Name = "gridColumnQuantity";
            this.gridColumnQuantity.Visible = true;
            this.gridColumnQuantity.VisibleIndex = 3;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Ngày tạo";
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 4;
            this.gridColumnCreatedDate.Width = 90;
            // 
            // gridColumActive
            // 
            this.gridColumActive.Caption = "Active";
            this.gridColumActive.FieldName = "Active";
            this.gridColumActive.Name = "gridColumActive";
            this.gridColumActive.Visible = true;
            this.gridColumActive.VisibleIndex = 5;
            this.gridColumActive.Width = 53;
            // 
            // gridColumnProvinceCode
            // 
            this.gridColumnProvinceCode.Caption = "Province Code";
            this.gridColumnProvinceCode.FieldName = "ProvinceCode";
            this.gridColumnProvinceCode.Name = "gridColumnProvinceCode";
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Description";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            // 
            // panelAddDacCode
            // 
            this.panelAddDacCode.Controls.Add(this.gridLookUpEditProductChoose);
            this.panelAddDacCode.Controls.Add(this.addSerialCodeButton);
            this.panelAddDacCode.Controls.Add(this.ToSeriTextBox);
            this.panelAddDacCode.Controls.Add(this.FrSeriTextBox);
            this.panelAddDacCode.Controls.Add(this.buttonDetailDelete);
            this.panelAddDacCode.Controls.Add(this.buttonUpdateDetail);
            this.panelAddDacCode.Controls.Add(this.buttonEnter);
            this.panelAddDacCode.Controls.Add(this.textBoxDacCode);
            this.panelAddDacCode.Controls.Add(this.ToSeriLabel);
            this.panelAddDacCode.Controls.Add(this.FrSeriLabel);
            this.panelAddDacCode.Controls.Add(this.labelSearchCode);
            this.panelAddDacCode.Location = new System.Drawing.Point(419, 14);
            this.panelAddDacCode.Name = "panelAddDacCode";
            this.panelAddDacCode.Size = new System.Drawing.Size(308, 115);
            this.panelAddDacCode.TabIndex = 10;
            // 
            // gridLookUpEditProductChoose
            // 
            this.gridLookUpEditProductChoose.EditValue = "";
            this.gridLookUpEditProductChoose.Location = new System.Drawing.Point(6, 65);
            this.gridLookUpEditProductChoose.Name = "gridLookUpEditProductChoose";
            this.gridLookUpEditProductChoose.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditProductChoose.Properties.DisplayMember = "Name";
            this.gridLookUpEditProductChoose.Properties.ImmediatePopup = true;
            this.gridLookUpEditProductChoose.Properties.NullText = "";
            this.gridLookUpEditProductChoose.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.gridLookUpEditProductChoose.Properties.ValueMember = "Code";
            this.gridLookUpEditProductChoose.Properties.View = this.gridView1;
            this.gridLookUpEditProductChoose.Size = new System.Drawing.Size(299, 20);
            this.gridLookUpEditProductChoose.TabIndex = 11;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Product Code";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 35;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Product Name";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // addSerialCodeButton
            // 
            this.addSerialCodeButton.Location = new System.Drawing.Point(270, 38);
            this.addSerialCodeButton.Name = "addSerialCodeButton";
            this.addSerialCodeButton.Size = new System.Drawing.Size(35, 23);
            this.addSerialCodeButton.TabIndex = 4;
            this.addSerialCodeButton.Text = "+";
            this.addSerialCodeButton.UseVisualStyleBackColor = true;
            // 
            // ToSeriTextBox
            // 
            this.ToSeriTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToSeriTextBox.Location = new System.Drawing.Point(172, 38);
            this.ToSeriTextBox.Name = "ToSeriTextBox";
            this.ToSeriTextBox.Size = new System.Drawing.Size(85, 23);
            this.ToSeriTextBox.TabIndex = 3;
            this.ToSeriTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ToSeriTextBox_KeyPress);
            // 
            // FrSeriTextBox
            // 
            this.FrSeriTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrSeriTextBox.Location = new System.Drawing.Point(50, 38);
            this.FrSeriTextBox.Name = "FrSeriTextBox";
            this.FrSeriTextBox.Size = new System.Drawing.Size(85, 23);
            this.FrSeriTextBox.TabIndex = 2;
            this.FrSeriTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrSeriTextBox_KeyPress);
            // 
            // buttonDetailDelete
            // 
            this.buttonDetailDelete.Image = global::PIPT.Properties.Resources.Delete1616;
            this.buttonDetailDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDetailDelete.Location = new System.Drawing.Point(200, 88);
            this.buttonDetailDelete.Name = "buttonDetailDelete";
            this.buttonDetailDelete.Size = new System.Drawing.Size(105, 24);
            this.buttonDetailDelete.TabIndex = 6;
            this.buttonDetailDelete.Text = "Xóa QRCode";
            this.buttonDetailDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDetailDelete.UseVisualStyleBackColor = true;
            this.buttonDetailDelete.Click += new System.EventHandler(this.buttonDetailDelete_Click);
            // 
            // buttonUpdateDetail
            // 
            this.buttonUpdateDetail.Image = global::PIPT.Properties.Resources.update1616;
            this.buttonUpdateDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdateDetail.Location = new System.Drawing.Point(6, 88);
            this.buttonUpdateDetail.Name = "buttonUpdateDetail";
            this.buttonUpdateDetail.Size = new System.Drawing.Size(84, 24);
            this.buttonUpdateDetail.TabIndex = 5;
            this.buttonUpdateDetail.Text = "Cập nhật";
            this.buttonUpdateDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUpdateDetail.UseVisualStyleBackColor = true;
            this.buttonUpdateDetail.Click += new System.EventHandler(this.buttonUpdateDetail_Click);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Image = global::PIPT.Properties.Resources.submit1616;
            this.buttonEnter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEnter.Location = new System.Drawing.Point(243, 7);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(62, 28);
            this.buttonEnter.TabIndex = 1;
            this.buttonEnter.Text = "Nhận";
            this.buttonEnter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // textBoxDacCode
            // 
            this.textBoxDacCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDacCode.Location = new System.Drawing.Point(110, 10);
            this.textBoxDacCode.Name = "textBoxDacCode";
            this.textBoxDacCode.Size = new System.Drawing.Size(127, 23);
            this.textBoxDacCode.TabIndex = 0;
            this.textBoxDacCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDacCode_KeyPress);
            // 
            // ToSeriLabel
            // 
            this.ToSeriLabel.AutoSize = true;
            this.ToSeriLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToSeriLabel.Location = new System.Drawing.Point(141, 43);
            this.ToSeriLabel.Name = "ToSeriLabel";
            this.ToSeriLabel.Size = new System.Drawing.Size(25, 13);
            this.ToSeriLabel.TabIndex = 4;
            this.ToSeriLabel.Text = "=>";
            // 
            // FrSeriLabel
            // 
            this.FrSeriLabel.AutoSize = true;
            this.FrSeriLabel.Location = new System.Drawing.Point(3, 43);
            this.FrSeriLabel.Name = "FrSeriLabel";
            this.FrSeriLabel.Size = new System.Drawing.Size(41, 13);
            this.FrSeriLabel.TabIndex = 4;
            this.FrSeriLabel.Text = "Từ Seri";
            // 
            // labelSearchCode
            // 
            this.labelSearchCode.AutoSize = true;
            this.labelSearchCode.Location = new System.Drawing.Point(3, 15);
            this.labelSearchCode.Name = "labelSearchCode";
            this.labelSearchCode.Size = new System.Drawing.Size(101, 13);
            this.labelSearchCode.TabIndex = 4;
            this.labelSearchCode.Text = "Quét mã hoặc nhập";
            // 
            // panelDistributeToFactory
            // 
            this.panelDistributeToFactory.Controls.Add(this.buttonRefreshAgency);
            this.panelDistributeToFactory.Controls.Add(this.checkEditKeepOrder);
            this.panelDistributeToFactory.Controls.Add(this.gridLookUpEditProduct);
            this.panelDistributeToFactory.Controls.Add(this.gridLookUpEditFactory);
            this.panelDistributeToFactory.Controls.Add(this.textBoxQuantity);
            this.panelDistributeToFactory.Controls.Add(this.textBoxOrderNumber);
            this.panelDistributeToFactory.Controls.Add(this.richTextBoxDescription);
            this.panelDistributeToFactory.Controls.Add(this.comboBoxProvince);
            this.panelDistributeToFactory.Controls.Add(this.dateTimePickerCreatedDate);
            this.panelDistributeToFactory.Controls.Add(this.checkBoxActive);
            this.panelDistributeToFactory.Controls.Add(this.labelDescription);
            this.panelDistributeToFactory.Controls.Add(this.labelProduct);
            this.panelDistributeToFactory.Controls.Add(this.labelCreatedDate);
            this.panelDistributeToFactory.Controls.Add(this.labelQuantity);
            this.panelDistributeToFactory.Controls.Add(this.labelProvince);
            this.panelDistributeToFactory.Controls.Add(this.labelOrderNumber);
            this.panelDistributeToFactory.Controls.Add(this.labelFactory);
            this.panelDistributeToFactory.Location = new System.Drawing.Point(3, 14);
            this.panelDistributeToFactory.Name = "panelDistributeToFactory";
            this.panelDistributeToFactory.Size = new System.Drawing.Size(410, 164);
            this.panelDistributeToFactory.TabIndex = 9;
            // 
            // buttonRefreshAgency
            // 
            this.buttonRefreshAgency.Image = global::PIPT.Properties.Resources.refresh16x16;
            this.buttonRefreshAgency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRefreshAgency.Location = new System.Drawing.Point(325, 9);
            this.buttonRefreshAgency.Name = "buttonRefreshAgency";
            this.buttonRefreshAgency.Size = new System.Drawing.Size(82, 23);
            this.buttonRefreshAgency.TabIndex = 12;
            this.buttonRefreshAgency.Text = "Tải lại XSX";
            this.buttonRefreshAgency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRefreshAgency.UseVisualStyleBackColor = true;
            this.buttonRefreshAgency.Click += new System.EventHandler(this.buttonRefreshAgency_Click);
            // 
            // checkEditKeepOrder
            // 
            this.checkEditKeepOrder.Location = new System.Drawing.Point(158, 11);
            this.checkEditKeepOrder.Name = "checkEditKeepOrder";
            this.checkEditKeepOrder.Properties.Caption = "Giữ lệnh";
            this.checkEditKeepOrder.Size = new System.Drawing.Size(63, 19);
            this.checkEditKeepOrder.TabIndex = 11;
            // 
            // gridLookUpEditProduct
            // 
            this.gridLookUpEditProduct.EditValue = "";
            this.gridLookUpEditProduct.Location = new System.Drawing.Point(72, 65);
            this.gridLookUpEditProduct.Name = "gridLookUpEditProduct";
            this.gridLookUpEditProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditProduct.Properties.DisplayMember = "Name";
            this.gridLookUpEditProduct.Properties.ImmediatePopup = true;
            this.gridLookUpEditProduct.Properties.NullText = "";
            this.gridLookUpEditProduct.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.gridLookUpEditProduct.Properties.ValueMember = "Code";
            this.gridLookUpEditProduct.Properties.View = this.gridLookUpEditProductView;
            this.gridLookUpEditProduct.Size = new System.Drawing.Size(335, 20);
            this.gridLookUpEditProduct.TabIndex = 10;
            // 
            // gridLookUpEditProductView
            // 
            this.gridLookUpEditProductView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColCode,
            this.gridColName});
            this.gridLookUpEditProductView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditProductView.Name = "gridLookUpEditProductView";
            this.gridLookUpEditProductView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditProductView.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditProductView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColCode
            // 
            this.gridColCode.Caption = "Product Code";
            this.gridColCode.FieldName = "Code";
            this.gridColCode.Name = "gridColCode";
            this.gridColCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColCode.Visible = true;
            this.gridColCode.VisibleIndex = 0;
            this.gridColCode.Width = 35;
            // 
            // gridColName
            // 
            this.gridColName.Caption = "Product Name";
            this.gridColName.FieldName = "Name";
            this.gridColName.Name = "gridColName";
            this.gridColName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColName.Visible = true;
            this.gridColName.VisibleIndex = 1;
            // 
            // gridLookUpEditFactory
            // 
            this.gridLookUpEditFactory.EditValue = "";
            this.gridLookUpEditFactory.Location = new System.Drawing.Point(72, 39);
            this.gridLookUpEditFactory.Name = "gridLookUpEditFactory";
            this.gridLookUpEditFactory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditFactory.Properties.DisplayMember = "Name";
            this.gridLookUpEditFactory.Properties.ImmediatePopup = true;
            this.gridLookUpEditFactory.Properties.NullText = "";
            this.gridLookUpEditFactory.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.gridLookUpEditFactory.Properties.ValueMember = "Code";
            this.gridLookUpEditFactory.Properties.View = this.gridLookUpEditAgencyView;
            this.gridLookUpEditFactory.Size = new System.Drawing.Size(335, 20);
            this.gridLookUpEditFactory.TabIndex = 10;
            // 
            // gridLookUpEditAgencyView
            // 
            this.gridLookUpEditAgencyView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.gridColumnAddress});
            this.gridLookUpEditAgencyView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditAgencyView.Name = "gridLookUpEditAgencyView";
            this.gridLookUpEditAgencyView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditAgencyView.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditAgencyView.OptionsView.ShowGroupPanel = false;
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 80;
            // 
            // colName
            // 
            this.colName.Caption = "Tên xưởng";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 150;
            // 
            // gridColumnAddress
            // 
            this.gridColumnAddress.Caption = "Address";
            this.gridColumnAddress.FieldName = "Address";
            this.gridColumnAddress.Name = "gridColumnAddress";
            this.gridColumnAddress.Visible = true;
            this.gridColumnAddress.VisibleIndex = 2;
            this.gridColumnAddress.Width = 154;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(72, 91);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(80, 21);
            this.textBoxQuantity.TabIndex = 9;
            // 
            // textBoxOrderNumber
            // 
            this.textBoxOrderNumber.Location = new System.Drawing.Point(72, 11);
            this.textBoxOrderNumber.Name = "textBoxOrderNumber";
            this.textBoxOrderNumber.Size = new System.Drawing.Size(80, 21);
            this.textBoxOrderNumber.TabIndex = 9;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(240, 91);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(167, 42);
            this.richTextBoxDescription.TabIndex = 7;
            this.richTextBoxDescription.Text = "";
            // 
            // comboBoxProvince
            // 
            this.comboBoxProvince.FormattingEnabled = true;
            this.comboBoxProvince.Location = new System.Drawing.Point(302, 139);
            this.comboBoxProvince.Name = "comboBoxProvince";
            this.comboBoxProvince.Size = new System.Drawing.Size(104, 21);
            this.comboBoxProvince.TabIndex = 5;
            this.comboBoxProvince.Visible = false;
            // 
            // dateTimePickerCreatedDate
            // 
            this.dateTimePickerCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCreatedDate.Location = new System.Drawing.Point(72, 118);
            this.dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            this.dateTimePickerCreatedDate.Size = new System.Drawing.Size(100, 21);
            this.dateTimePickerCreatedDate.TabIndex = 6;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Location = new System.Drawing.Point(72, 143);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(97, 17);
            this.checkBoxActive.TabIndex = 8;
            this.checkBoxActive.Text = "Còn hoạt động";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(192, 91);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ghi chú";
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(12, 71);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(54, 13);
            this.labelProduct.TabIndex = 4;
            this.labelProduct.Text = "Sản phẩm";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(15, 121);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(17, 94);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(49, 13);
            this.labelQuantity.TabIndex = 4;
            this.labelQuantity.Text = "Số lượng";
            // 
            // labelProvince
            // 
            this.labelProvince.AutoSize = true;
            this.labelProvince.Location = new System.Drawing.Point(269, 142);
            this.labelProvince.Name = "labelProvince";
            this.labelProvince.Size = new System.Drawing.Size(27, 13);
            this.labelProvince.TabIndex = 4;
            this.labelProvince.Text = "Tỉnh";
            this.labelProvince.Visible = false;
            // 
            // labelOrderNumber
            // 
            this.labelOrderNumber.AutoSize = true;
            this.labelOrderNumber.Location = new System.Drawing.Point(11, 15);
            this.labelOrderNumber.Name = "labelOrderNumber";
            this.labelOrderNumber.Size = new System.Drawing.Size(55, 13);
            this.labelOrderNumber.TabIndex = 4;
            this.labelOrderNumber.Text = "Lệnh xuất";
            // 
            // labelFactory
            // 
            this.labelFactory.AutoSize = true;
            this.labelFactory.Location = new System.Drawing.Point(13, 42);
            this.labelFactory.Name = "labelFactory";
            this.labelFactory.Size = new System.Drawing.Size(53, 13);
            this.labelFactory.TabIndex = 4;
            this.labelFactory.Text = "Xưởng SX";
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToAddRows = false;
            this.dataGridViewDetails.AllowUserToDeleteRows = false;
            this.dataGridViewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.IsSelected,
            this.ColumnDistributorID,
            this.ColumnDacCode,
            this.gridColumProductCode});
            this.dataGridViewDetails.Location = new System.Drawing.Point(419, 135);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.RowHeadersVisible = false;
            this.dataGridViewDetails.Size = new System.Drawing.Size(305, 389);
            this.dataGridViewDetails.TabIndex = 0;
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "ID";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            this.ColumnId.Width = 70;
            // 
            // IsSelected
            // 
            this.IsSelected.HeaderText = "";
            this.IsSelected.Name = "IsSelected";
            this.IsSelected.Width = 30;
            // 
            // ColumnDistributorID
            // 
            this.ColumnDistributorID.DataPropertyName = "DistributorID";
            this.ColumnDistributorID.HeaderText = "ID XSX";
            this.ColumnDistributorID.Name = "ColumnDistributorID";
            this.ColumnDistributorID.Width = 70;
            // 
            // ColumnDacCode
            // 
            this.ColumnDacCode.DataPropertyName = "DacCode";
            this.ColumnDacCode.HeaderText = "Mã QRCode";
            this.ColumnDacCode.Name = "ColumnDacCode";
            this.ColumnDacCode.Width = 110;
            // 
            // gridColumProductCode
            // 
            this.gridColumProductCode.DataPropertyName = "ProductCode";
            this.gridColumProductCode.HeaderText = "Mã SP";
            this.gridColumProductCode.Name = "gridColumProductCode";
            this.gridColumProductCode.Width = 80;
            // 
            // labelProductCount
            // 
            this.labelProductCount.AutoSize = true;
            this.labelProductCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductCount.Location = new System.Drawing.Point(422, 527);
            this.labelProductCount.Name = "labelProductCount";
            this.labelProductCount.Size = new System.Drawing.Size(132, 13);
            this.labelProductCount.TabIndex = 4;
            this.labelProductCount.Text = "Số sản phẩm đã thêm:";
            // 
            // ucDataButtonAgency
            // 
            this.ucDataButtonAgency.AddNewVisible = true;
            this.ucDataButtonAgency.CancelVisible = true;
            this.ucDataButtonAgency.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonAgency.DeleteVisible = true;
            this.ucDataButtonAgency.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonAgency.EditVisible = true;
            this.ucDataButtonAgency.ExcelVisible = false;
            this.ucDataButtonAgency.IsContitnue = true;
            this.ucDataButtonAgency.LanguageVisible = false;
            this.ucDataButtonAgency.Location = new System.Drawing.Point(0, 546);
            this.ucDataButtonAgency.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonAgency.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonAgency.MultiLanguageVisible = false;
            this.ucDataButtonAgency.Name = "ucDataButtonAgency";
            this.ucDataButtonAgency.PrintVisible = false;
            this.ucDataButtonAgency.ReportVisible = false;
            this.ucDataButtonAgency.SaveVisible = true;
            this.ucDataButtonAgency.Size = new System.Drawing.Size(730, 34);
            this.ucDataButtonAgency.TabIndex = 0;
            this.ucDataButtonAgency.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_InsertHandler);
            this.ucDataButtonAgency.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_EditHandler);
            this.ucDataButtonAgency.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_SaveHandler);
            this.ucDataButtonAgency.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_DeleteHandler);
            this.ucDataButtonAgency.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_CancelHandler);
            this.ucDataButtonAgency.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonProduct_CloseHandler);
            // 
            // frmDacDistributeToFactory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(730, 580);
            this.Controls.Add(this.groupBoxFactory);
            this.Controls.Add(this.ucDataButtonAgency);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDacDistributeToFactory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân phối mã qrcode cho xưởng sản xuất";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDacDistributeToFactory_FormClosing);
            this.Load += new System.EventHandler(this.frmDacDistributeToFactory_Load);
            this.groupBoxFactory.ResumeLayout(false);
            this.groupBoxFactory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDistributor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDistributor)).EndInit();
            this.panelAddDacCode.ResumeLayout(false);
            this.panelAddDacCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProductChoose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panelDistributeToFactory.ResumeLayout(false);
            this.panelDistributeToFactory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditKeepOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProductView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditFactory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditAgencyView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonAgency;
        private System.Windows.Forms.GroupBox groupBoxFactory;
        private System.Windows.Forms.Panel panelDistributeToFactory;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreatedDate;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.Label labelFactory;
        private System.Windows.Forms.Panel panelAddDacCode;
        private System.Windows.Forms.TextBox textBoxDacCode;
        private System.Windows.Forms.Label labelSearchCode;
        private System.Windows.Forms.ComboBox comboBoxProvince;
        private System.Windows.Forms.Label labelProvince;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.TextBox textBoxOrderNumber;
        private System.Windows.Forms.Label labelOrderNumber;
        private System.Windows.Forms.Label labelProductCount;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEditFactory;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEditProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditProductView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditAgencyView;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColName;
        private DevExpress.XtraGrid.GridControl gridControlDistributor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDistributor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFactoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumActive;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProvinceCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantity;
        private DevExpress.XtraEditors.CheckEdit checkEditKeepOrder;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.Button buttonDetailDelete;
        private System.Windows.Forms.Button buttonUpdateDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAddress;
        private System.Windows.Forms.Button buttonRefreshAgency;
        private System.Windows.Forms.Button addSerialCodeButton;
        private System.Windows.Forms.TextBox ToSeriTextBox;
        private System.Windows.Forms.TextBox FrSeriTextBox;
        private System.Windows.Forms.Label ToSeriLabel;
        private System.Windows.Forms.Label FrSeriLabel;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEditProductChoose;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDistributorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDacCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumProductCode;
    }
}