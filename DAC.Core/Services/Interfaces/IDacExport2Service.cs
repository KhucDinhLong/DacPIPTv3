using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacExport2Service
    {
        BaseViewModel<List<DacExport2VM>> GetAll();
        BaseViewModel<DacExport2VM> GetDetail(int Id);
        BaseViewModel<DacExport2VM> Create(DacExport2VM exportInfoVM);
        BaseViewModel<DacExport2VM> Edit(DacExport2VM exportInfoVM);
        BaseViewModel<bool> Delete(int exportInfoId);
        BaseViewModel<string> GenerateNewCode();
        BaseViewModel<bool> InvalidProductCode(string DacCode, string ProductCode);
        BaseViewModel<DacExport2> GetByCode(string OrderNumber);
    }
}
