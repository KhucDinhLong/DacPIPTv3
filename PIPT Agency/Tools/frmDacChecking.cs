using DAC.Core;
using DAC.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace PIPT.Agency
{
    public partial class frmDacChecking : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacChecking _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacChecking Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacChecking();
            }
            return _instance;
        }

        public static frmDacChecking Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacChecking Instance(Form parent, bool isActivate)
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
        #endregion
        #region Form's Events
        public frmDacChecking()
        {
            InitializeComponent();
        }
        private void frmDacChecking_Load(object sender, EventArgs e)
        {
        }
        #endregion

        private void textBoxDacCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                string serial = CommonCore.GetSerialFromScanner(textBoxDacCode.Text);
                textBoxDacCode.Text = serial;
                DacChecking(serial);
            }
        }

        private void buttonChecking_Click(object sender, EventArgs e)
        {
            DacChecking(textBoxDacCode.Text);
        }

        public void DacChecking(string sDacCode)
        {
            string sProductCode = string.Empty;
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@DacCode", sDacCode);
            DataTable dataTableAgency = dacDb.ExecuteDataTable("dbo.spDacDistributeToAgency_SelectDacCode");
            DataTable dataTableStore = dacDb.ExecuteDataTable("dbo.spDacDistributeToStore_SelectDacCode");
            if (dataTableAgency.Rows.Count > 0)
            {
                DataRow dataRow = dataTableAgency.Rows[0];
                textBoxAgencyExportedDate.Text = dataRow["CreatedDate"].ToString();
                textBoxAgencyCode.Text = dataRow["AgencyCode"].ToString();
                textBoxAgencyName.Text = dataRow["Name"].ToString();
                textBoxAgencyAddress.Text = dataRow["Address"].ToString();
                textBoxAgencyOwner.Text = dataRow["OwnerName"].ToString();
                textBoxDescription.Text = dataRow["Description"].ToString();
                textBoxAgencyMobile.Text = dataRow["MobileNum"].ToString();
                textBoxAgencyEmail.Text = dataRow["Email"].ToString();
                textBoxAgencyProvince.Text = dataRow["ProvinceName"].ToString();
                textBoxAgencyPCode.Text = dataRow["ProductCode"].ToString();
                textBoxAgencyDependCode.Text = dataRow["DependCode"].ToString();
                textBoxAgencyJoinContact.Text = dataRow["JoinContact"].ToString();
                textBoxAgencyPhoneNum.Text = dataRow["PhoneNum"].ToString();
                textBoxAgencyRegion.Text = dataRow["Region"].ToString();
                sProductCode = dataRow["ProductCode"].ToString();
                groupBoxAgency.Visible = true;
            }
            else
            {
                groupBoxAgency.Visible = false;
            }
            if (dataTableStore.Rows.Count > 0)
            {
                DataRow dataRow = dataTableStore.Rows[0];
                textBoxStoreExportedDate.Text = dataRow["CreatedDate"].ToString();
                textBoxStoreCode.Text = dataRow["StoreCode"].ToString();
                textBoxStoreName.Text = dataRow["Name"].ToString();
                textBoxStoreAddress.Text = dataRow["Address"].ToString();
                textBoxStoreOwner.Text = dataRow["OwnerName"].ToString();
                textBoxStoreMobile.Text = dataRow["MobileNum"].ToString();
                textBoxStoreEmail.Text = dataRow["Email"].ToString();
                textBoxStorePCode.Text = dataRow["ProductCode"].ToString();
                sProductCode = dataRow["ProductCode"].ToString();
                groupBoxStore.Visible = true;
            }
            else
            {
                groupBoxStore.Visible = false;
            }
            if (sProductCode.Length != 0)
            {
                dacDb.CreateNewSqlCommand();
                dacDb.AddParameter("@Code", sProductCode);
                dacDb.AddParameter("@Name", string.Empty);
                DataTable dataTableProduct = dacDb.ExecuteDataTable("spDacProduct_SelectByCode");
                if (dataTableProduct.Rows.Count > 0)
                {
                    DataRow dataRow = dataTableProduct.Rows[0];
                    textBoxProductCode.Text = dataRow["Code"].ToString();
                    textBoxProductName.Text = dataRow["Name"].ToString();
                    textBoxProductCategory.Text = dataRow["ProductCategoryName"].ToString();
                    textBoxProductRegisterNumber.Text = dataRow["RegisterNumber"].ToString();
                    textBoxProductManufacture.Text = dataRow["Manufacture"].ToString();
                    textBoxProductGeneralFormat.Text = dataRow["GeneralFormat"].ToString();
                    groupBoxProduct.Visible = true;
                }
                else
                {
                    groupBoxProduct.Visible = false;
                }
            }
            else
            {
                groupBoxProduct.Visible = false;
            }
        }
    }
}
