using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacDistributeToAgencyDetailsService
    {
        BaseViewModel<DacDistributeToAgencyDetails> GetByDacCode(string DacCode);
        BaseViewModel<bool> AddRange(List<DacDistributeToAgencyDetails> LstDetail);
        BaseViewModel<bool> DeleteByDacCode(List<string> LstDacCode);
        BaseViewModel<DacDistributeToAgencyVM> GetExportInfo(string DacCode);
        BaseViewModel<bool> DeleteByDacCode(string DacCode);
    }
}
