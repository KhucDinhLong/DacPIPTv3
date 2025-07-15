using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacDistributeToStoreDetailsService
    {
        BaseViewModel<DacDistributeToStoreDetails> GetByDacCode(string DacCode);
        BaseViewModel<bool> AddRange(List<DacDistributeToStoreDetails> LstDetail);
        BaseViewModel<bool> DeleteByDacCode(List<string> LstDacCode);
        BaseViewModel<DacExport2VM> GetExportInfo(string DacCode);
        BaseViewModel<bool> DeleteByDacCode(string DacCode);
    }
}
