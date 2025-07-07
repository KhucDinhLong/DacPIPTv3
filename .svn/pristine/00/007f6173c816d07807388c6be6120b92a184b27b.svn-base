using DAC.Core;
using DAC.DAL;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PIPT.Agency
{
    public partial class frmDacLogNotUpload : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacLogNotUpload _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacLogNotUpload Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacLogNotUpload();
            }
            return _instance;
        }

        public static frmDacLogNotUpload Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacLogNotUpload Instance(Form parent, bool isActivate)
        {
            _instance = Instance(parent);
            if (isActivate)
            {
                _instance.WindowState = FormWindowState.Normal;
                _instance.Show();
                _instance.Activate();
            }
            return _instance;
        }
        #endregion
        #region Variables
        DacDbAccess dacDb = new DacDbAccess();
        DacLogNotUpload LogNotUpload = new DacLogNotUpload();
        DacLogNotUploadCollection LogNotUploadCollection = new DacLogNotUploadCollection();
        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
        BindingList<DacLogNotUpload> bdlDacLogNotUpload;
        Common common = new Common();
        private bool bIsDataBinding;
        #endregion
        #region Form's Events
        public frmDacLogNotUpload()
        {
            InitializeComponent();
        }

        private void frmDacLogNotUpload_Load(object sender, EventArgs e)
        {
            this.InitData();
        }
        #endregion
        #region Functions on Form
        private void InitData()
        {
            // Get data from database
            LogNotUploadCollection = LogNotUploadCS.GetListDacLogNotUpload(string.Empty, string.Empty);
            // Get BindingList DataSource
            AddObjectIntoBindingList(LogNotUploadCollection);
        }
        private void AddObjectIntoBindingList(DacLogNotUploadCollection LogNotUploadCollection)
        {
            bdlDacLogNotUpload = new BindingList<DacLogNotUpload>();
            foreach (DacLogNotUpload LogNotUpload in LogNotUploadCollection)
            {
                bdlDacLogNotUpload.Add(LogNotUpload);
            }
            SetDataSource();
        }
        private void SetDataSource()
        {
            CommonCore.ClearDataBinding(panelLogNotUpload);
            // Binding data to Controls
            bIsDataBinding = true;
            textBoxCode.DataBindings.Add("Text", bdlDacLogNotUpload, "IDNotUpload");
            textBoxTableName.DataBindings.Add("Text", bdlDacLogNotUpload, "InTable");
            textBoxAction.DataBindings.Add("Text", bdlDacLogNotUpload, "Action");
            richTextBoxContent.DataBindings.Add("Text", bdlDacLogNotUpload, "Content");
            textBoxRemark.DataBindings.Add("Text", bdlDacLogNotUpload, "Remark");
            textBoxStatus.DataBindings.Add("Text", bdlDacLogNotUpload, "Status");
            dateTimePickerDateSend.DataBindings.Clear();
            dateTimePickerDateSend.DataBindings.Add("Value", bdlDacLogNotUpload, "DateSend");
            dateTimePickerLastDateSend.DataBindings.Clear();
            dateTimePickerLastDateSend.DataBindings.Add("Value", bdlDacLogNotUpload, "LastDateSend");

            dataGridViewLogNotUpload.DataSource = bdlDacLogNotUpload;
            bIsDataBinding = false;
            EnableControls(bIsDataBinding);
        }
        private void EnableControls(bool bIsEnabled)
        {
            foreach (Control ctrl in panelLogNotUpload.Controls)
            {
                ctrl.Enabled = bIsEnabled;
            }
        }
        
        #endregion
        #region Button's Events
        private void dataGridViewLogNotUpload_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if(e.ColumnIndex == dataGridViewLogNotUpload.Columns["ButtonColumnUpload"].Index)
            {
                // Tai len du lieu theo mang mo ta
                DacLogNotUpload LogNotUpload = (DacLogNotUpload)dataGridViewLogNotUpload.Rows[e.RowIndex].DataBoundItem;
                switch(LogNotUpload.InTable)
                {
                    case "DacDistributeToStore":
                        common.SendDataStoreToServer(LogNotUpload);
                        //MessageBox.Show("Kiểm tra thử: DacDistributeToStore");
                        break;
                    case "DacDistributeToStoreDetails":
                        common.SendDataStoreDetailsToServer(LogNotUpload);
                        //MessageBox.Show("Kiểm tra thử: DacDistributeToStoreDetails");
                        break;
                }
                System.Threading.Thread.Sleep(2000);
                this.InitData();
            }
        }
        #endregion
    }
}
