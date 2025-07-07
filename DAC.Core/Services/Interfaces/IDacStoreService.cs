using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacStoreService
    {
        BaseViewModel<List<DacStoreVM>> GetAll();
        BaseViewModel<DacStore> GetById(int id);
        BaseViewModel<DacStore> Create(DacStore store);
        BaseViewModel<DacStore> Edit(DacStore store);
        BaseViewModel<bool> Delete(int id);
        BaseViewModel<bool> HasUsed(string code);
        BaseViewModel<DacStore> GetByCode(string StoreCode);
        BaseViewModel<int> ImportFromExcel(string filePath, string UserName);
    }
}
