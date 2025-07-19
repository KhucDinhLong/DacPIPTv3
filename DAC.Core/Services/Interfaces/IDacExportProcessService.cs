using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacExportProcessService : IRestoreDataService
    {
        int UserLevel { get; set; }
        BaseViewModel<List<DacExportVM>> GetAll();
        BaseViewModel<DacExportVM> GetDetail(int Id, int CustomerLevel);
        BaseViewModel<DacExportVM> Create(DacExportVM exportInfoVM);
        BaseViewModel<DacExportVM> Edit(DacExportVM exportInfoVM);
        BaseViewModel<bool> Delete(int exportInfoId, int CustomerLevel);
        BaseViewModel<string> GenerateNewCode(int CustomerLevel);
        BaseViewModel<bool> InvalidProductCode(string DacCode, string ProductCode, int CustomerLevel);
        BaseViewModel<DacExportVM> GetByCode(string OrderNumber, int CustomerLevel);
    }
}
