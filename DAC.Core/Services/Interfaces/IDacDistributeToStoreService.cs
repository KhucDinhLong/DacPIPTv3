using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacDistributeToStoreService
    {
        BaseViewModel<List<DacDistributeToStoreVM>> GetAll();
        BaseViewModel<DacDistributeToStoreVM> GetDetail(int Id);
        BaseViewModel<DacDistributeToStoreVM> Create(DacDistributeToStoreVM exportInfoVM);
        BaseViewModel<DacDistributeToStoreVM> Edit(DacDistributeToStoreVM exportInfoVM);
        BaseViewModel<bool> Delete(int exportInfoId);
        BaseViewModel<string> GenerateNewCode();
        BaseViewModel<bool> InvalidProductCode(string DacCode, string ProductCode);
        BaseViewModel<DacDistributeToStore> GetByCode(string OrderNumber);
    }
}
