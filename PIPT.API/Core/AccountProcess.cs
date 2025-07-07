using DAC.Core.Security;
using DAC.Core;

namespace PIPT.API.Core
{
    public class AccountProcess
    {
        public AccountProcess()
        {
            //DAC.DAL.GetDacDbConnection.ConnectionString = (System.Configuration.ConfigurationManager.ConnectionStrings["DacDBConn"].ConnectionString);
        }
        public bool Login(string userName, string password)
        {
            UserBS userBS = new UserBS();
            if (userBS.CheckUser(userName, CommonCore.EncryptString(password, CommonCore.PASS_PHRASE)))
                return true;
            return false;
        }
    }
}