using DAC.Core;
using DAC.DAL;
using System;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmConfig : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmConfig _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmConfig Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmConfig();
            }
            return _instance;
        }

        public static frmConfig Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmConfig Instance(Form parent, bool isActivate)
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
        public frmConfig()
        {
            InitializeComponent();
        }

        private void buttonExportUpdate_Click(object sender, System.EventArgs e)
        {
            try
            {
                SecConfig secConfig = CommonBO.GetSecConfig(CheckInWarehouse.Name);
                secConfig.Value = CheckInWarehouse.Checked ? "true" : "false";
                secConfig.Pattern = string.Empty;
                SecConfigCS.UpdateSecConfig(secConfig);

                secConfig = CommonBO.GetSecConfig(AutoIncreaseWarehouse.Name);
                secConfig.Value = AutoIncreaseWarehouse.Checked ? "true" : "false";
                secConfig.Pattern = textBoxAutoIncreaseWarehouse.Text;
                SecConfigCS.UpdateSecConfig(secConfig);

                secConfig = CommonBO.GetSecConfig(AutoIncreaseOrder.Name);
                secConfig.Value = AutoIncreaseOrder.Checked ? "true" : "false";
                secConfig.Pattern = textBoxAutoIncreaseOrder.Text;
                SecConfigCS.UpdateSecConfig(secConfig); 
                
                secConfig = CommonBO.GetSecConfig(AutoIncreaseOrderStore.Name);
                secConfig.Value = AutoIncreaseOrderStore.Checked ? "true" : "false";
                secConfig.Pattern = textBoxAutoIncreaseOrderStore.Text;
                SecConfigCS.UpdateSecConfig(secConfig);

                secConfig = CommonBO.GetSecConfig(AutoIncreasePackage.Name);
                secConfig.Value = AutoIncreasePackage.Checked ? "true" : "false";
                secConfig.Pattern = textBoxAutoIncreasePackage.Text;
                SecConfigCS.UpdateSecConfig(secConfig);

                secConfig = CommonBO.GetSecConfig(AutoIncreaseContainer.Name);
                secConfig.Value = AutoIncreaseContainer.Checked ? "true" : "false";
                secConfig.Pattern = textBoxAutoIncreaseContainer.Text;
                SecConfigCS.UpdateSecConfig(secConfig);

                secConfig = CommonBO.GetSecConfig("DateStartGettingData");
                secConfig.Value = dateTimePickerStartDate.Value.ToString("yyyy-MM-dd");
                secConfig.Pattern = string.Empty;
                SecConfigCS.UpdateSecConfig(secConfig);

                secConfig = CommonBO.GetSecConfig(AutoIncreaseFactory.Name);
                secConfig.Value = AutoIncreaseFactory.Checked ? "true" : "false";
                secConfig.Pattern = textBoxAutoIncreaseFactory.Text;
                SecConfigCS.UpdateSecConfig(secConfig);

                secConfig = CommonBO.GetSecConfig(SeriLength.Name);
                secConfig.Value = textBoxSeriLength.Text.Length.ToString();
                secConfig.Pattern = textBoxSeriLength.Text;
                SecConfigCS.UpdateSecConfig(secConfig);

                CommonBO.RefreshSecConfigs();
                DialogResult dialogResult = MessageBox.Show("Bạn đã cập nhật cấu hình thành công!", "PIPT - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch {
                MessageBox.Show("Cập nhật cấu hình bị lỗi!", "PIPT - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmConfig_Load(object sender, System.EventArgs e)
        {
            CheckInWarehouse.Checked = Convert.ToBoolean(CommonBO.GetSecConfig(CheckInWarehouse.Name).Value);

            AutoIncreaseWarehouse.Checked = Convert.ToBoolean(CommonBO.GetSecConfig(AutoIncreaseWarehouse.Name).Value);
            textBoxAutoIncreaseWarehouse.Text = CommonBO.GetSecConfig(AutoIncreaseWarehouse.Name).Pattern;

            AutoIncreaseOrder.Checked = Convert.ToBoolean(CommonBO.GetSecConfig(AutoIncreaseOrder.Name).Value);
            textBoxAutoIncreaseOrder.Text = CommonBO.GetSecConfig(AutoIncreaseOrder.Name).Pattern;

            AutoIncreaseOrderStore.Checked = Convert.ToBoolean(CommonBO.GetSecConfig(AutoIncreaseOrderStore.Name).Value);
            textBoxAutoIncreaseOrderStore.Text = CommonBO.GetSecConfig(AutoIncreaseOrderStore.Name).Pattern;

            AutoIncreasePackage.Checked = Convert.ToBoolean(CommonBO.GetSecConfig(AutoIncreasePackage.Name).Value);
            textBoxAutoIncreasePackage.Text = CommonBO.GetSecConfig(AutoIncreasePackage.Name).Pattern;

            AutoIncreaseContainer.Checked = Convert.ToBoolean(CommonBO.GetSecConfig(AutoIncreaseContainer.Name).Value);
            textBoxAutoIncreaseContainer.Text = CommonBO.GetSecConfig(AutoIncreaseContainer.Name).Pattern;

            dateTimePickerStartDate.Value = DateTime.Parse(CommonBO.GetSecConfig("DateStartGettingData").Value);

            AutoIncreaseFactory.Checked = Convert.ToBoolean(CommonBO.GetSecConfig(AutoIncreaseFactory.Name).Value);
            textBoxAutoIncreaseFactory.Text = CommonBO.GetSecConfig(AutoIncreaseFactory.Name).Pattern;

            SeriLength.Checked = Convert.ToBoolean(CommonBO.GetSecConfig(SeriLength.Name).Value.Length);
            SeriLength.Text = $"Chiều dài seri nhập vào ({CommonBO.GetSecConfig(SeriLength.Name).Pattern.Length} ký tự)";
            textBoxSeriLength.Text = CommonBO.GetSecConfig(SeriLength.Name).Pattern;
        }
    }
}
