using DAC.Core;
using DAC.Core.Common;
using DAC.Core.Security;
using DAC.Core.Services.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmLogin : Form
    {
        #region Variables
        private UserBS userBS = new UserBS();
        private IAuthenticationService _authenticationService;
        #endregion
        public frmLogin(IAuthenticationService authenticationService)
        {
            InitializeComponent();
            _authenticationService = authenticationService;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == false)
                return;
            var user = _authenticationService.Login(txtUserName.Text, CommonUtils.EncryptString(txtPassword.Text)).ResponseData;
            if (user != null)
            {
                if ((user.LstGroup != null && user.LstGroup.FirstOrDefault(x => x.IsAdmin.HasValue && x.IsAdmin.Value) != null) 
                    || ((!user.LockedUser.HasValue || !user.LockedUser.Value) && user.DeadlineOfUsing >= DateTime.Now && user.Level.HasValue && user.Level > 0))
                {
                    Session.CurrentUser = user;
                    CommonBS.CurrentUser = new User();
                    CommonBS.CurrentUser.LastChangedPassword = user.LastChangedPassword.HasValue ? user.LastChangedPassword.Value : DateTime.Now;
                    CommonBS.CurrentUser.CreatedDate = user.CreatedDate.HasValue ? user.CreatedDate.Value : DateTime.Now;
                    CommonBS.CurrentUser.DeadlineOfUsing = user.DeadlineOfUsing.HasValue ? user.DeadlineOfUsing.Value : DateTime.Now;
                    CommonBS.CurrentUser.Email = user.Email;
                    CommonBS.CurrentUser.FullName = user.FullName;
                    CommonBS.CurrentUser.LastLogIn = user.LastLogin.HasValue ? user.LastLogin.Value : DateTime.Now;
                    CommonBS.CurrentUser.LockedDate = user.LockedDate.HasValue ? user.LockedDate.Value : DateTime.Now;
                    CommonBS.CurrentUser.LockedReason = user.LockedReason;
                    CommonBS.CurrentUser.LockedUser = user.LockedUser.HasValue ? user.LockedUser.Value : false;
                    CommonBS.CurrentUser.LoginID = user.LoginID;
                    CommonBO.SecConfigs = SecConfigCS.GetSecConfigs();
                    CommonBS.IsAdminUser = user.isAdmin.HasValue ? user.isAdmin.Value : false;
                    this.DialogResult = DialogResult.OK;
                }
                else if (!user.Level.HasValue || user.Level.Value < 0)
                {
                    MessageBox.Show("Không lấy được thông tin khách hàng sử dụng tài khoản này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();
                }
                else
                {
                    if (user.LockedUser.HasValue && user.LockedUser.Value)
                    {
                        MessageBox.Show("Người dùng này đã bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Người dùng này đã hết hạn sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserName.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Người dùng hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
            }
            
        }
        /// <summary>
        /// Check data which user inputs OK or NOT
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}
