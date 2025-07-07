using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAC.DAL;
using DAC.Core.Security;
using DAC.Core;

namespace PIPT.Agency
{
    public partial class frmLogin : Form
    {
        #region Variables
        private UserBS userBS = new UserBS();
        #endregion
        public frmLogin()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == false)
                return;
            string sMessage = String.Empty;
            UserStatus status = UserStatus.NotExists;
            User objUser = userBS.CheckUser(usernameTextBox.Text.Trim(), CommonCore.EncryptString(passwordTextBox.Text.Trim(), CommonCore.PASS_PHRASE), ref status);
            switch (status)
            {
                case UserStatus.NotExists:
                    sMessage = "Người dùng hoặc mật khẩu không đúng";
                    break;
                case UserStatus.Locked:
                    sMessage = "Người dùng này đã bị khóa";
                    break;
                case UserStatus.ExpiredDate:
                    sMessage = "Người dùng này đã hết hạn sử dụng";
                    break;
                case UserStatus.OK:
                    CommonBS.CurrentUser = objUser;
                    this.DialogResult = DialogResult.OK;
                    return;
            }
            MessageBox.Show(sMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            usernameTextBox.Focus();
        }
        /// <summary>
        /// Check data which user inputs OK or NOT
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            if(usernameTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(passwordTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}
