using System;
using System.Configuration;
using System.Windows.Forms;

namespace PIPT.Agency
{
    public partial class frmDacGetSerial : Form
    {
        #region Instance of the form
        /// <summary>
        /// Instance to store instance of this form
        /// </summary>
        private static frmDacGetSerial _instance = null;

        /// <summary>
        /// Instance form.
        /// </summary>
        /// <returns>Instance of this Form</returns>
        public static frmDacGetSerial Instance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmDacGetSerial();
            }
            return _instance;
        }

        public static frmDacGetSerial Instance(Form parent)
        {
            _instance = Instance();
            _instance.MdiParent = parent;
            return _instance;
        }

        public static frmDacGetSerial Instance(Form parent, bool isActivate)
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
        public frmDacGetSerial()
        {
            InitializeComponent();
        }

        private void buttonGetSerial_Click(object sender, EventArgs e)
        {
            if (textBoxDacCode.Text.Trim().Length != 0)
            {
                PIPT.Track.dacws.DacResultInfo dacResultInfo = new PIPT.Track.dacws.DacResultInfo();
                PIPT.Track.dacws.WSACShowResult acResult = new PIPT.Track.dacws.WSACShowResult();
                acResult.AuthHeaderValue = new PIPT.Track.dacws.AuthHeader();
                acResult.AuthHeaderValue.UserName = ConfigurationManager.AppSettings["Username"].ToString();
                acResult.AuthHeaderValue.Password = ConfigurationManager.AppSettings["Password"].ToString();

                dacResultInfo = acResult.GetSerialByDacCode(textBoxDacCode.Text.Trim());
                if (dacResultInfo.SeriesNo != 0)
                {
                    textBoxSerial.Text = string.Format("{0:0000000000}", dacResultInfo.SeriesNo);
                    buttonChecking.Visible = true;
                }
                else
                {
                    buttonChecking.Visible = false;
                    MessageBox.Show("Không tìm thấy số serial nào cho mã này, Bạn hãy kiểm tra lại mã an ninh", "Thong bao");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã an ninh!", "Thong bao");
            }
        }

        private void buttonChecking_Click(object sender, EventArgs e)
        {
            frmDacChecking frm = frmDacChecking.Instance(this.MdiParent, true);
            frm.DacChecking(textBoxSerial.Text.Trim());
            frm.textBoxDacCode.Text = textBoxSerial.Text.Trim();
        }
    }
}
