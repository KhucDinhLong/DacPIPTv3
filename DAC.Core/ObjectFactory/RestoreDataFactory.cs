using DAC.Core.Services.Implements;
using DAC.Core.Services.Interfaces;
using System;

namespace DAC.Core.ObjectFactory
{
    public class RestoreDataFactory
    {
        public static IRestoreDataService GetService(string DataTableName)
        {
            switch (DataTableName)
            {
                case "DacAgency":
                    return new DacCustomerService();
                case "DacDistributeToAgency":
                    return new DacExportProcessService();
                default:
                    throw new ArgumentException("Unknown table");
            }
        }
    }
}
