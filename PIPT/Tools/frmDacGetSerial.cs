using DAC.Core;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace PIPT
{
    public partial class frmDacGetSerial : Form
    {
        public frmDacGetSerial()
        {
            InitializeComponent();
        }

        private void buttonGetSerial_Click(object sender, EventArgs e)
        {
            if (txtDacCode.Text.Trim().Length != 0)
            {
                PIPT.Track.dacws.DacResultInfo dacResultInfo = new PIPT.Track.dacws.DacResultInfo();
                PIPT.Track.dacws.WSACShowResult acResult = new PIPT.Track.dacws.WSACShowResult();
                acResult.AuthHeaderValue = new PIPT.Track.dacws.AuthHeader();
                acResult.AuthHeaderValue.UserName = ConfigurationManager.AppSettings["Username"].ToString();
                acResult.AuthHeaderValue.Password = ConfigurationManager.AppSettings["Password"].ToString();

                dacResultInfo = acResult.GetSerialByDacCode(txtDacCode.Text.Trim());
                if (dacResultInfo.SeriesNo != 0)
                {
                    txtSerial.Text = string.Format("{0:0000000000}", dacResultInfo.SeriesNo);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy số serial nào cho mã này, Bạn hãy kiểm tra lại mã an ninh", "Thong bao");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã an ninh!", "Thong bao");
            }
        }

        private void textBoxSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string serial = txtSerial.Text.Trim();
                if (serial.Length >= 10)
                {
                    serial = CommonCore.GetSerialFromScanner(serial);
                    txtSerial.Text = serial;
                    string DacCode = CommonCore.GetDacCodeFromScanner(serial);
                    txtDacCode.Text = DacCode;
                }
            }
        }
    }
}
