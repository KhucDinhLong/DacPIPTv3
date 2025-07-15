using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacExportDetailService
    {
        BaseViewModel<DacExportDetail> GetByDacCode(string DacCode);
        BaseViewModel<bool> AddRange(List<DacExportDetail> LstDetail);
        BaseViewModel<bool> DeleteByDacCode(List<string> LstDacCode);
        BaseViewModel<DacExportVM> GetExportInfo(string DacCode);
        BaseViewModel<bool> DeleteByDacCode(string DacCode);
    }
}
