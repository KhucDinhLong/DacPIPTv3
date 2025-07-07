using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.DAL.Services
{
    public class SecUsersService
    {
        public List<SecUsers> GetListUser()
        {
            PIPTDbContext dbContext = new PIPTDbContext();

            return dbContext.SecUsers.ToList();
        }
        public SecUsers GetUserByID(string sLoginID)
        {
            PIPTDbContext dbContext = new PIPTDbContext();

            return dbContext.SecUsers.FirstOrDefault(x => x.LoginId == sLoginID);
        }
    }
}
