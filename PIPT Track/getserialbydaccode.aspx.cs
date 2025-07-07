using System;
using System.Configuration;
using PIPT.Track.dacws;

namespace PIPT.Track
{
    public partial class getserialbydaccode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                thongBaoLabel.Visible = false;
            }
        }

        protected void btnGetSerial_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (dacCode.Text.Trim().Length == 0)
                {
                    thongBaoLabel.Visible = true;
                    thongBaoLabel.Text = @"<div class='alert alert-danger fade in'>
                      <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                      <strong>Không có dữ liệu!</strong> Bạn vui lòng nhập mã trước khi truy vấn.
                      </div>";
                    return;
                }
                DacResultInfo dacResultInfo = new DacResultInfo();
                WSACShowResult aCShowResult = new WSACShowResult();
                aCShowResult.AuthHeaderValue = new AuthHeader();
                aCShowResult.AuthHeaderValue.UserName = ConfigurationManager.AppSettings["Username"];
                aCShowResult.AuthHeaderValue.Password = ConfigurationManager.AppSettings["Password"];
                dacResultInfo = aCShowResult.GetSerialByDacCode(dacCode.Text.Trim().ToUpper());
                if(dacResultInfo.SeriesNo != 0)
                {
                    serialLabel.Text = "<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>"
                                         + String.Format("{0:0000000000}", dacResultInfo.SeriesNo) + "</strong></div>";
                }
                else
                {
                    serialLabel.Text = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>"
                                         + "Không có kết quả!</strong> Không tìm thấy số serial nào cho mã này, Bạn hãy kiểm tra lại mã an ninh</div>";
                }
                thongBaoLabel.Visible = false;
            }
            else
            {
                thongBaoLabel.Visible = true;
                thongBaoLabel.Text = @"<div class='alert alert-danger fade in'>
                  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                  <strong>Chưa đăng nhập!</strong> Bạn vui lòng đăng nhập trước khi truy vấn.
                  </div>";
            }
        }
    }
}