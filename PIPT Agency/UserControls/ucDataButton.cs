﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using DAC.Core.Security;

namespace PIPT.Agency
{
    public partial class ucDataButton : UserControl
    {
        #region Declare variables
        // public enum DataState { Insert, Edit, View };
        private DataState dataState = DataState.View;
        private bool bIsContinue = true;

        // declare delegates
        public delegate void DataHandler();

        // declare events
        /// <summary>
        /// Select procedure for inserting data
        /// </summary>
        public event DataHandler InsertHandler;

        /// <summary>
        /// Select procedule Print data.
        /// </summary>
        public event DataHandler PrintHandler;

        /// <summary>
        /// select procedule Report data
        /// </summary>
        public event DataHandler ReportHandler;

        /// <summary>
        /// Select procedule Multi language
        /// </summary>
        public event DataHandler MultiLanguageHandler;

        /// <summary>
        /// Select procedure for export data to excel
        /// </summary>
        public event DataHandler ExcelHandler;

        /// <summary>
        /// Select procedure for editing data
        /// </summary>
        public event DataHandler EditHandler;

        /// <summary>
        /// Select procedure for saving data
        /// </summary>
        public event DataHandler SaveHandler;

        /// <summary>
        /// Select procedure for deletingdata
        /// </summary>
        public event DataHandler DeleteHandler;

        /// <summary>
        /// Select procedure for canceling data
        /// </summary>
        public event DataHandler CancelHandler;

        /// <summary>
        /// Select procedure for closing data
        /// </summary>
        public event DataHandler CloseHandler;
        #endregion

        public ucDataButton()
        {
            InitializeComponent();
        }

        #region Properties
        public DataState DataMode
        {
            get { return dataState; }
            set { dataState = value; }
        }
        public bool IsContitnue
        {
            get { return bIsContinue; }
            set { bIsContinue = value; }
        }
        #endregion

        #region Set focus buttons
        public void SetInsertFocus()
        {
            cmdAdd.Enabled = true;
            cmdAdd.Focus();
        }

        public void SetSaveFocus()
        {
            cmdSave.Focus();
        }

        public void SetCancelFocus()
        {
            cmdCancel.Focus();
        }

        public void SetEditFocus()
        {
            cmdEdit.Focus();
        }

        public void SetDeleteFocus()
        {
            cmdDelete.Focus();
        }
        #endregion

        #region Attribute Button
        //const string strDescription = "abc";

        private bool excelVisible = true;
        [Category("ButtonVisible")]
        [Browsable(true)]
        public bool ExcelVisible
        {
            set
            {
                excelVisible = value;
                cmdExcel.Visible = excelVisible;
            }
            get
            {
                return excelVisible; 
            }
        }

        private bool addNewVisible = true;
        [Category("ButtonVisible")]
        [Browsable(true)]
        public bool AddNewVisible
        {
            set
            {
                addNewVisible = value;
                cmdAdd.Visible = addNewVisible;
            }
            get
            {
                return addNewVisible; 
            }
        }

        private bool editVisible = true;
        [Category("ButtonVisible")]
        [Browsable(true)]
        public bool EditVisible
        {
            set
            {
                editVisible = value;
                cmdEdit.Visible = editVisible;
            }
            get
            {
                return editVisible; 
            }
        }

        private bool deleteVisible = true;
        [Category("ButtonVisible")]
        [Browsable(true)]
        public bool DeleteVisible
        {
            set
            {
                deleteVisible = value;
                cmdDelete.Visible = deleteVisible;
            }
            get 
            {
                return deleteVisible; 
            }
        }

        private bool saveVisible = true;
        [Category("ButtonVisible")]
        [Browsable(true)]
        public bool SaveVisible
        {
            set
            {
                saveVisible = value;
                cmdSave.Visible = saveVisible;
            }
            get
            { 
                return saveVisible; 
            }
        }

        private bool cancelVisible = true;
        [Category("ButtonVisible")]
        [Browsable(true)]
        public bool CancelVisible
        {
            set
            {
                cancelVisible = value;
                cmdCancel.Visible = cancelVisible;
            }
            get
            {
                return cancelVisible; 
            }
        }

        private bool languageVisible = true;
        [Category("ButtonVisible")]
        [Browsable(true)]
        public bool LanguageVisible
        {
            set
            {
                languageVisible = value;
                cmdLanguage.Visible = languageVisible;
            }
            get
            {
                return languageVisible; 
            }
        }

        private bool printVisible = true;
        [Category("ButtonVisible")]
        [Browsable(true)]
        public bool PrintVisible
        {
            set
            {
                printVisible = value;
                cmdPrint.Visible = printVisible;
            }
            get
            {
                return printVisible;
            }
        }

        private bool reportVisible = true;
        [Category("ButtonVisible")]
        [Browsable(true)]
        public bool ReportVisible
        {
            set
            {
                reportVisible = value;
                cmdReport.Visible = reportVisible;
            }
            get
            {
                return reportVisible;
            }
        }

        private bool multiLanguage = true;
        [Category("ButtonVisible")]
        [Browsable(true)]
        public bool MultiLanguageVisible
        {
            set
            {
                multiLanguage = value;
                cmdLanguage.Visible = multiLanguage;
            }
            get
            { 
                return multiLanguage;
            }
        }

        #endregion

        #region Update State Buttons
        private void acInsert_Update(object sender, EventArgs e)
        {
            (sender as CDiese.Actions.Action).Enabled = (dataState != DataState.Insert);
        }

        private void acEdit_Update(object sender, EventArgs e)
        {
            (sender as CDiese.Actions.Action).Enabled = (dataState == DataState.View);
        }

        private void acDelete_Update(object sender, EventArgs e)
        {
            (sender as CDiese.Actions.Action).Enabled = (dataState != DataState.Insert);
        }

        private void acSave_Update(object sender, EventArgs e)
        {
            (sender as CDiese.Actions.Action).Enabled = (dataState != DataState.View);
        }

        private void acCancel_Update(object sender, EventArgs e)
        {
            (sender as CDiese.Actions.Action).Enabled = (dataState != DataState.View);
        }
        #endregion

        #region Implements Buttons
        private void acClose_Execute(object sender, EventArgs e)
        {
            if (CloseHandler != null)
                CloseHandler();
            else
            {
                this.ParentForm.Close();
            }
        }

        private void acCancel_Execute(object sender, EventArgs e)
        {
            if (CancelHandler != null)
                CancelHandler();

            dataState = DataState.View;
        }

        private void acDelete_Execute(object sender, EventArgs e)
        {
            if (DeleteHandler != null)
                DeleteHandler();
        }

        private void acEdit_Execute(object sender, EventArgs e)
        {
            dataState = DataState.Edit;

            if (EditHandler != null)
                EditHandler();
        }

        private void acInsert_Execute(object sender, EventArgs e)
        {
            dataState = DataState.Insert;
            if (InsertHandler != null)
                InsertHandler();
        }

        private void acSave_Execute(object sender, EventArgs e)
        {
            if (SaveHandler != null)
                SaveHandler();
        }

        private void cmdExcel_Click(object sender, EventArgs e)
        {
            if (ExcelHandler != null)
                ExcelHandler();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (PrintHandler != null)
                PrintHandler();
        }

        private void cmdReport_Click(object sender, EventArgs e)
        {
            if (ReportHandler != null)
                ReportHandler();
        }

        private void cmdLanguage_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }

}
