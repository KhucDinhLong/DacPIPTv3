using System;
using System.Windows.Forms;
using Unity;

namespace PIPT
{
    static class Program
    {
        public static IUnityContainer Container { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DAC.DAL.GetDacDbConnection.ConnectionString = (System.Configuration.ConfigurationManager.ConnectionStrings["DacDBConn"].ConnectionString);
            Container = DependencyInjectionConfig.RegisterDependencies();
            var frmlogin = (dynamic)Container.Resolve(typeof(frmLogin));
            if (frmlogin.ShowDialog() == DialogResult.OK)
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
