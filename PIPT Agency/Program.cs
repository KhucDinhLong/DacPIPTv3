using DAC.DAL;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIPT.Agency
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GetDacDbConnection.ConnectionString = (System.Configuration.ConfigurationManager.ConnectionStrings["DacDBConn"].ConnectionString);
            frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMain());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
