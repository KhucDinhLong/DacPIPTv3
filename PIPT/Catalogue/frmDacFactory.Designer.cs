namespace PIPT
{
    partial class frmDacFactory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDacFactory));
            this.groupBoxStore = new System.Windows.Forms.GroupBox();
            this.gridControlFactory = new DevExpress.XtraGrid.GridControl();
            this.gridViewFactory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMobileNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifiedUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelSearchAgency = new System.Windows.Forms.Panel();
            this.buttonPaste = new System.Windows.Forms.Button();
            this.panelAgency = new System.Windows.Forms.Panel();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.dateTimePickerModifiedDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelMobileNum = new System.Windows.Forms.Label();
            this.textBoxOwnerName = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxMobileNum = new System.Windows.Forms.TextBox();
            this.labelModifiedDate = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelShopKeeper = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ucDataButtonAgency = new PIPT.ucDataButton();
            this.groupBoxStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFactory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFactory)).BeginInit();
            this.panelSearchAgency.SuspendLayout();
            this.panelAgency.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxStore
            // 
            this.groupBoxStore.Controls.Add(this.gridControlFactory);
            this.groupBoxStore.Controls.Add(this.panelSearchAgency);
            this.groupBoxStore.Controls.Add(this.panelAgency);
            this.groupBoxStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStore.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStore.Name = "groupBoxStore";
            this.groupBoxStore.Size = new System.Drawing.Size(1078, 478);
            this.groupBoxStore.TabIndex = 1;
            this.groupBoxStore.TabStop = false;
            this.groupBoxStore.Text = "Thông tin xưởng sản xuất";
            // 
            // gridControlFactory
            // 
            this.gridControlFactory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlFactory.Location = new System.Drawing.Point(0, 110);
            this.gridControlFactory.MainView = this.gridViewFactory;
            this.gridControlFactory.Name = "gridControlFactory";
            this.gridControlFactory.Size = new System.Drawing.Size(1072, 362);
            this.gridControlFactory.TabIndex = 11;
            this.gridControlFactory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFactory});
            // 
            // gridViewFactory
            // 
            this.gridViewFactory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnCode,
            this.gridColumnName,
            this.gridColumnAddress,
            this.gridColumnOwnerName,
            this.gridColumnMobileNum,
            this.gridColumnEmail,
            this.gridColumnCreatedUser,
            this.gridColumnCreatedDate,
            this.gridColumnModifiedDate,
            this.gridColumnModifiedUser,
            this.gridColumnDescription,
            this.gridColumnActive});
            this.gridViewFactory.GridControl = this.gridControlFactory;
            this.gridViewFactory.Name = "gridViewFactory";
            this.gridViewFactory.OptionsView.ShowAutoFilterRow = true;
            this.gridViewFactory.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            this.gridColumnID.Width = 42;
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "Mã KH";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 1;
            this.gridColumnCode.Width = 69;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Tên KH";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 2;
            this.gridColumnName.Width = 131;
            // 
            // gridColumnAddress
            // 
            this.gridColumnAddress.Caption = "Địa chỉ";
            this.gridColumnAddress.FieldName = "Address";
            this.gridColumnAddress.Name = "gridColumnAddress";
            this.gridColumnAddress.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnAddress.Visible = true;
            this.gridColumnAddress.VisibleIndex = 3;
            this.gridColumnAddress.Width = 156;
            // 
            // gridColumnOwnerName
            // 
            this.gridColumnOwnerName.Caption = "Người đại diện";
            this.gridColumnOwnerName.FieldName = "OwnerName";
            this.gridColumnOwnerName.Name = "gridColumnOwnerName";
            this.gridColumnOwnerName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumnOwnerName.Visible = true;
            this.gridColumnOwnerName.VisibleIndex = 4;
            this.gridColumnOwnerName.Width = 78;
            // 
            // gridColumnMobileNum
            // 
            this.gridColumnMobileNum.Caption = "Di động";
            this.gridColumnMobileNum.FieldName = "MobileNum";
            this.gridColumnMobileNum.Name = "gridColumnMobileNum";
            this.gridColumnMobileNum.Visible = true;
            this.gridColumnMobileNum.VisibleIndex = 5;
            this.gridColumnMobileNum.Width = 67;
            // 
            // gridColumnEmail
            // 
            this.gridColumnEmail.Caption = "Email";
            this.gridColumnEmail.FieldName = "Email";
            this.gridColumnEmail.Name = "gridColumnEmail";
            this.gridColumnEmail.Visible = true;
            this.gridColumnEmail.VisibleIndex = 6;
            this.gridColumnEmail.Width = 90;
            // 
            // gridColumnCreatedUser
            // 
            this.gridColumnCreatedUser.Caption = "Người tạo";
            this.gridColumnCreatedUser.FieldName = "CreatedUser";
            this.gridColumnCreatedUser.Name = "gridColumnCreatedUser";
            this.gridColumnCreatedUser.Visible = true;
            this.gridColumnCreatedUser.VisibleIndex = 7;
            this.gridColumnCreatedUser.Width = 65;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Ngày tạo";
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 8;
            this.gridColumnCreatedDate.Width = 62;
            // 
            // gridColumnModifiedDate
            // 
            this.gridColumnModifiedDate.Caption = "Ngày sửa";
            this.gridColumnModifiedDate.FieldName = "ModifiedDate";
            this.gridColumnModifiedDate.Name = "gridColumnModifiedDate";
            this.gridColumnModifiedDate.Visible = true;
            this.gridColumnModifiedDate.VisibleIndex = 10;
            this.gridColumnModifiedDate.Width = 67;
            // 
            // gridColumnModifiedUser
            // 
            this.gridColumnModifiedUser.Caption = "Người sửa";
            this.gridColumnModifiedUser.FieldName = "ModifiedUser";
            this.gridColumnModifiedUser.Name = "gridColumnModifiedUser";
            this.gridColumnModifiedUser.Visible = true;
            this.gridColumnModifiedUser.VisibleIndex = 9;
            this.gridColumnModifiedUser.Width = 65;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Ghi chú";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 11;
            this.gridColumnDescription.Width = 122;
            // 
            // gridColumnActive
            // 
            this.gridColumnActive.Caption = "Active";
            this.gridColumnActive.FieldName = "Active";
            this.gridColumnActive.Name = "gridColumnActive";
            this.gridColumnActive.Visible = true;
            this.gridColumnActive.VisibleIndex = 12;
            this.gridColumnActive.Width = 40;
            // 
            // panelSearchAgency
            // 
            this.panelSearchAgency.Controls.Add(this.buttonPaste);
            this.panelSearchAgency.Location = new System.Drawing.Point(851, 71);
            this.panelSearchAgency.Name = "panelSearchAgency";
            this.panelSearchAgency.Size = new System.Drawing.Size(146, 33);
            this.panelSearchAgency.TabIndex = 10;
            // 
            // buttonPaste
            // 
            this.buttonPaste.Image = global::PIPT.Properties.Resources.Excel;
            this.buttonPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPaste.Location = new System.Drawing.Point(36, 5);
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(71, 24);
            this.buttonPaste.TabIndex = 3;
            this.buttonPaste.Text = "Paste";
            this.buttonPaste.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPaste.UseVisualStyleBackColor = true;
            this.buttonPaste.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // panelAgency
            // 
            this.panelAgency.Controls.Add(this.textBoxCode);
            this.panelAgency.Controls.Add(this.richTextBoxDescription);
            this.panelAgency.Controls.Add(this.dateTimePickerModifiedDate);
            this.panelAgency.Controls.Add(this.dateTimePickerCreatedDate);
            this.panelAgency.Controls.Add(this.checkBoxActive);
            this.panelAgency.Controls.Add(this.labelEmail);
            this.panelAgency.Controls.Add(this.textBoxAddress);
            this.panelAgency.Controls.Add(this.textBoxName);
            this.panelAgency.Controls.Add(this.labelMobileNum);
            this.panelAgency.Controls.Add(this.textBoxOwnerName);
            this.panelAgency.Controls.Add(this.labelDescription);
            this.panelAgency.Controls.Add(this.textBoxMobileNum);
            this.panelAgency.Controls.Add(this.labelModifiedDate);
            this.panelAgency.Controls.Add(this.labelCreatedDate);
            this.panelAgency.Controls.Add(this.labelShopKeeper);
            this.panelAgency.Controls.Add(this.textBoxEmail);
            this.panelAgency.Controls.Add(this.labelName);
            this.panelAgency.Controls.Add(this.labelCode);
            this.panelAgency.Controls.Add(this.label3);
            this.panelAgency.Location = new System.Drawing.Point(3, 20);
            this.panelAgency.Name = "panelAgency";
            this.panelAgency.Size = new System.Drawing.Size(842, 84);
            this.panelAgency.TabIndex = 9;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(75, 4);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(100, 21);
            this.textBoxCode.TabIndex = 0;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(592, 55);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(240, 22);
            this.richTextBoxDescription.TabIndex = 9;
            this.richTextBoxDescription.Text = "";
            // 
            // dateTimePickerModifiedDate
            // 
            this.dateTimePickerModifiedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerModifiedDate.Location = new System.Drawing.Point(592, 28);
            this.dateTimePickerModifiedDate.Name = "dateTimePickerModifiedDate";
            this.dateTimePickerModifiedDate.Size = new System.Drawing.Size(98, 21);
            this.dateTimePickerModifiedDate.TabIndex = 8;
            // 
            // dateTimePickerCreatedDate
            // 
            this.dateTimePickerCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCreatedDate.Location = new System.Drawing.Point(592, 4);
            this.dateTimePickerCreatedDate.Name = "dateTimePickerCreatedDate";
            this.dateTimePickerCreatedDate.Size = new System.Drawing.Size(98, 21);
            this.dateTimePickerCreatedDate.TabIndex = 8;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Location = new System.Drawing.Point(725, 6);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(97, 17);
            this.checkBoxActive.TabIndex = 10;
            this.checkBoxActive.Text = "Còn hoạt động";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(334, 33);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "E-mail";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(75, 56);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(195, 21);
            this.textBoxAddress.TabIndex = 2;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(75, 30);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(195, 21);
            this.textBoxName.TabIndex = 1;
            // 
            // labelMobileNum
            // 
            this.labelMobileNum.AutoSize = true;
            this.labelMobileNum.Location = new System.Drawing.Point(325, 58);
            this.labelMobileNum.Name = "labelMobileNum";
            this.labelMobileNum.Size = new System.Drawing.Size(43, 13);
            this.labelMobileNum.TabIndex = 4;
            this.labelMobileNum.Text = "Di động";
            // 
            // textBoxOwnerName
            // 
            this.textBoxOwnerName.Location = new System.Drawing.Point(374, 4);
            this.textBoxOwnerName.Name = "textBoxOwnerName";
            this.textBoxOwnerName.Size = new System.Drawing.Size(126, 21);
            this.textBoxOwnerName.TabIndex = 4;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(544, 58);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(42, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Ghi chú";
            // 
            // textBoxMobileNum
            // 
            this.textBoxMobileNum.Location = new System.Drawing.Point(374, 55);
            this.textBoxMobileNum.Name = "textBoxMobileNum";
            this.textBoxMobileNum.Size = new System.Drawing.Size(126, 21);
            this.textBoxMobileNum.TabIndex = 6;
            // 
            // labelModifiedDate
            // 
            this.labelModifiedDate.AutoSize = true;
            this.labelModifiedDate.Location = new System.Drawing.Point(536, 31);
            this.labelModifiedDate.Name = "labelModifiedDate";
            this.labelModifiedDate.Size = new System.Drawing.Size(53, 13);
            this.labelModifiedDate.TabIndex = 4;
            this.labelModifiedDate.Text = "Ngày sửa";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(536, 7);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(51, 13);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Ngày tạo";
            // 
            // labelShopKeeper
            // 
            this.labelShopKeeper.AutoSize = true;
            this.labelShopKeeper.Location = new System.Drawing.Point(295, 7);
            this.labelShopKeeper.Name = "labelShopKeeper";
            this.labelShopKeeper.Size = new System.Drawing.Size(75, 13);
            this.labelShopKeeper.TabIndex = 4;
            this.labelShopKeeper.Text = "Người đại diện";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(374, 30);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(126, 21);
            this.textBoxEmail.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(10, 34);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(59, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Tên xưởng";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(32, 7);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(37, 13);
            this.labelCode.TabIndex = 4;
            this.labelCode.Text = "Mã KH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa chỉ";
            // 
            // ucDataButtonAgency
            // 
            this.ucDataButtonAgency.AddNewVisible = true;
            this.ucDataButtonAgency.CancelVisible = true;
            this.ucDataButtonAgency.DataMode = DAC.Core.Security.DataState.View;
            this.ucDataButtonAgency.DeleteVisible = true;
            this.ucDataButtonAgency.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButtonAgency.EditVisible = true;
            this.ucDataButtonAgency.ExcelVisible = true;
            this.ucDataButtonAgency.IsContitnue = true;
            this.ucDataButtonAgency.LanguageVisible = false;
            this.ucDataButtonAgency.Location = new System.Drawing.Point(0, 478);
            this.ucDataButtonAgency.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButtonAgency.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButtonAgency.MultiLanguageVisible = false;
            this.ucDataButtonAgency.Name = "ucDataButtonAgency";
            this.ucDataButtonAgency.PrintVisible = false;
            this.ucDataButtonAgency.ReportVisible = false;
            this.ucDataButtonAgency.SaveVisible = true;
            this.ucDataButtonAgency.Size = new System.Drawing.Size(1078, 34);
            this.ucDataButtonAgency.TabIndex = 0;
            this.ucDataButtonAgency.InsertHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_InsertHandler);
            this.ucDataButtonAgency.ExcelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_ExcelHandler);
            this.ucDataButtonAgency.EditHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_EditHandler);
            this.ucDataButtonAgency.SaveHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_SaveHandler);
            this.ucDataButtonAgency.DeleteHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_DeleteHandler);
            this.ucDataButtonAgency.CancelHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_CancelHandler);
            this.ucDataButtonAgency.CloseHandler += new PIPT.ucDataButton.DataHandler(this.ucDataButtonAgency_CloseHandler);
            // 
            // frmDacFactory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1078, 512);
            this.Controls.Add(this.groupBoxStore);
            this.Controls.Add(this.ucDataButtonAgency);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDacFactory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục Xưởng sản xuất";
            this.Load += new System.EventHandler(this.frmDacFactory_Load);
            this.groupBoxStore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFactory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFactory)).EndInit();
            this.panelSearchAgency.ResumeLayout(false);
            this.panelAgency.ResumeLayout(false);
            this.panelAgency.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDataButton ucDataButtonAgency;
        private System.Windows.Forms.GroupBox groupBoxStore;
        private System.Windows.Forms.Panel panelAgency;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreatedDate;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelMobileNum;
        private System.Windows.Forms.TextBox textBoxOwnerName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxMobileNum;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.Label labelShopKeeper;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelSearchAgency;
        private System.Windows.Forms.Button buttonPaste;
        private DevExpress.XtraGrid.GridControl gridControlFactory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFactory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifiedUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActive;
        private System.Windows.Forms.DateTimePicker dateTimePickerModifiedDate;
        private System.Windows.Forms.Label labelModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMobileNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmail;
    }
}