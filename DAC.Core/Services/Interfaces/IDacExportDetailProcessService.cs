using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacExportDetailProcessService
    {
        BaseViewModel<DacExportDetailVM> GetByDacCode(string DacCode, int CustomerLevel);
        BaseViewModel<bool> AddRange(List<DacExportDetailVM> LstDetail, int CustomerLevel);
        BaseViewModel<bool> DeleteByDacCode(List<string> LstDacCode, int CustomerLevel);
        BaseViewModel<DacExportVM> GetExportInfo(string DacCode, int CustomerLevel);
        BaseViewModel<bool> DeleteByDacCode(string DacCode, int CustomerLevel);
        BaseViewModel<bool> Exportable(string DacCode, string CustomerCode, int CustomerLevel);
    }
}
