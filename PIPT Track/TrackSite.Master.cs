using DAC.Core;
using DAC.Core.Security;
using System;

namespace PIPT.Track
{
    public partial class TrackSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["username"] == null)
                {
                    username.Visible = true;
                    password.Visible = true;
                    btnLogin.Text = "Đăng nhập";
                }
                else
                {
                    username.Visible = false;
                    password.Visible = false;
                    btnLogin.Text = "Đăng xuất";
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Khoi tao chuoi ket noi co so du lieu
            DAC.DAL.GetDacDbConnection.ConnectionString = (System.Configuration.ConfigurationManager.ConnectionStrings["DacDBConn"].ConnectionString);
            if (btnLogin.Text == "Đăng nhập")
            {
                CheckUserData();
                string sMessage = string.Empty;
                UserBS userBS = new UserBS();
                UserStatus status = UserStatus.NotExists;
                User objUser = userBS.CheckUser(username.Text.Trim(), CommonCore.EncryptString(password.Text.Trim(), CommonCore.PASS_PHRASE), ref status);

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
                        break;
                }
                if (status == UserStatus.OK)
                {
                    username.Visible = false;
                    password.Visible = false;
                    Session["username"] = CommonBS.CurrentUser.LoginID;
                    btnLogin.Text = "Đăng xuất";
                }
                else
                {
                    WebMessageBox.Show(sMessage);
                }
            }
            else
            {
                Session["username"] = null;
                username.Visible = true;
                password.Visible = true;
                btnLogin.Text = "Đăng nhập";
            }
        }

        protected void CheckUserData()
        {
            if(username.Text.Trim().Length == 0)
            {
                WebMessageBox.Show("Bạn chưa nhập tài khoản!");
                username.Focus();
                return;
            }
            if (password.Text.Trim().Length == 0)
            {
                WebMessageBox.Show("Bạn chưa nhập mật khẩu!");
                password.Focus();
                return;
            }
        }
    }
}