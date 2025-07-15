using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacExportService : IRestoreDataService
    {
        BaseViewModel<List<DacExportVM>> GetAll();
        BaseViewModel<DacExportVM> GetDetail(int Id);
        BaseViewModel<DacExportVM> Create(DacExportVM exportInfoVM);
        BaseViewModel<DacExportVM> Edit(DacExportVM exportInfoVM);
        BaseViewModel<bool> Delete(int exportInfoId);
        BaseViewModel<string> GenerateNewCode();
        BaseViewModel<bool> InvalidProductCode(string DacCode, string ProductCode);
        BaseViewModel<DacExport> GetByCode(string OrderNumber);
    }
}
