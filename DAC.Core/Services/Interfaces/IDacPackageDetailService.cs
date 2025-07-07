using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacPackageDetailService
    {
        BaseViewModel<DacPackageDetails> GetByDacCode(string DacCode);
        BaseViewModel<bool> AddRange(List<DacPackageDetails> LstDetail);
        BaseViewModel<bool> DeleteByDacCode(List<string> LstDacCode);
        BaseViewModel<bool> DeleteByDacCode(string DacCode);
    }
}