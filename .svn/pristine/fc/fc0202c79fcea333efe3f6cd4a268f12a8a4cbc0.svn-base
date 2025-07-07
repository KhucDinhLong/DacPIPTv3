using DAC.Core;
using DAC.Core.Security;
using System;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmChangePassword : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmChangePassword _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmChangePassword Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmChangePassword();
            }
            return _instance;
        }

        public static frmChangePassword Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmChangePassword Instance(Form parent, bool isActivate)
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
        UserBS userBS = new UserBS();
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            textBoxUserName.Text = CommonBS.CurrentUser.LoginID;
            ucDataButtonChangePassword.DataMode = DataState.Insert;
        }
        private bool IsDataOK()
        {
            if (textBoxOldPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu cũ.", "Thông báo" + Common.formSoftName);
                textBoxOldPassword.Focus();
                return false;
            }
            if (CommonBS.CurrentUser.Password != CommonCore.EncryptString(textBoxOldPassword.Text.Trim(), CommonCore.PASS_PHRASE))
            {
                MessageBox.Show("Mật khẩu cũ không đúng.", "Thông báo" + Common.formSoftName);
                textBoxOldPassword.Focus();
                return false;
            }
            if (textBoxNewPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới.", "Thông báo" + Common.formSoftName);
                textBoxNewPassword.Focus();
                return false;
            }
            if (textBoxNewPassword.Text.Trim() != textBoxConfirmNewPassword.Text.Trim())
            {
                MessageBox.Show("Mật khẩu bạn nhập không trùng nhau.", "Thông báo" + Common.formSoftName);
                textBoxConfirmNewPassword.Focus();
                return false;
            }
            return true;
        }

        private void ucDataButtonChangePassword_SaveHandler()
        {
            if(IsDataOK())
            {
                CommonBS.CurrentUser.Password = CommonCore.EncryptString(textBoxNewPassword.Text.Trim(), CommonCore.PASS_PHRASE);
                CommonBS.CurrentUser.LastChangedPassword = DateTime.Now;
                if(userBS.UpdatePassword(CommonBS.CurrentUser))
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công.", "Thông báo" + Common.formSoftName);
                }
                else
                {
                    MessageBox.Show("Thay đổi mật khẩu không thành công.", "Thông báo" + Common.formSoftName);
                }
            }
        }

        private void ucDataButtonChangePassword_CloseHandler()
        {
            this.Close();
        }

    }
}
