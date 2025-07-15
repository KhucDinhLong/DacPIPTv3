using DAC.Core.Services.Interfaces;
using DAC.DAL.OldVersion;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Services.Implements
{
    public class PIPTOldVersionMetaDataService : IPIPTOldVersionMetaDataService
    {
        public List<string> GetTableName()
        {
            try
            {
                using (var oldVersionDbContext = new PIPTOldVerDbContext())
                {
                    return oldVersionDbContext.Database.SqlQuery<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'").ToList();
                }
            }
            catch 
            {

                return null;
            }
        }
    }
}
