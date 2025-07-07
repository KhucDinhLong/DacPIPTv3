using System.Collections.Generic;

namespace DAC.Core.Security
{
    public class StockUser
    {
        public StockUser() { }
        public StockUser(string stockID, string loginID)
        {
            StockID = stockID;
            LoginID = loginID;
        }

        public virtual string StockID
        {
            get;
            set;
        }

        public virtual string LoginID
        {
            get;
            set;
        }
    }

    public class StockUserCollection : List<StockUser>
    {
    }
}