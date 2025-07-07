using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DAC.DAL;

namespace PIPT.Agency
{
    public partial class frmDacBackupRestore : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacBackupRestore _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacBackupRestore Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacBackupRestore();
            }
            return _instance;
        }

        public static frmDacBackupRestore Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacBackupRestore Instance(Form parent, bool isActivate)
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
        string DatabaseName = string.Empty;
        DacDbAccess dacDb = new DacDbAccess();
        #endregion
        #region Form's Events
        public frmDacBackupRestore()
        {
            InitializeComponent();
            // Selected Database
            DatabaseName = DacDbConnection.SqlConnection.Database;
        }
        private void frmDacBackupRestore_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> databases = dacDb.GetDatabases();
                comboBoxDatabase.Items.Clear();
                if (databases.Count > 0)
                {
                    foreach(string database in databases)
                    {
                        comboBoxDatabase.Items.Add(database);
                    }                    
                    comboBoxDatabase.Text = DatabaseName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
        #endregion
        #region Button's Event
        private void buttonLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxLocation.Text = dlg.SelectedPath;
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            if(textBoxLocation.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn đường dẫn lưu file", "Thông báo");
                return;
            }
            if(comboBoxDatabase.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn Cơ sở dữ liệu", "Thông báo");
                return;
            }
            try
            {
                dacDb.BackupDatabase(comboBoxDatabase.Text, textBoxLocation.Text);
                MessageBox.Show("Sao lưu dữ liệu thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        private void buttonBackupPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup Files(*.bak)|*.bak|All Files(*.*)|*.*";
            dlg.FilterIndex = 0;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxBackupPath.Text = dlg.FileName;
            }
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            if (textBoxBackupPath.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn file backup", "Thông báo");
                return;
            }
            if (comboBoxDatabase.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn Cơ sở dữ liệu", "Thông báo");
                return;
            }
            try
            {
                dacDb.RestoreDatabase(comboBoxDatabase.Text, textBoxBackupPath.Text);
                MessageBox.Show("Phục hồi dữ liệu thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        #endregion

    }
}
