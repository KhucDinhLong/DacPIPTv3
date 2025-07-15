using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacCustomerService : IRestoreDataService
    {
        BaseViewModel<List<DacCustomerVM>> GetAll();
        BaseViewModel<DacCustomer> GetById(int id);
        BaseViewModel<DacCustomer> GetByCode(string code);
        BaseViewModel<DacCustomer> Create(DacCustomer newAgency);
        BaseViewModel<DacCustomer> Edit(DacCustomer agency);
        BaseViewModel<bool> Delete(int id);
        BaseViewModel<bool> HasUsed(string code);
        BaseViewModel<int> ImportFromExcel(string filePath, string UserName);
    }
}
