using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacInsertToWarehouseService
    {
        BaseViewModel<List<DacInsertToWarehouseVM>> GetAll();
        BaseViewModel<DacInsertToWarehouseVM> GetDetail(int Id);
        BaseViewModel<DacInsertToWarehouseVM> Create(DacInsertToWarehouseVM importInfoVM);
        BaseViewModel<DacInsertToWarehouseVM> Edit(DacInsertToWarehouseVM importInfoVM);
        BaseViewModel<bool> Delete(int importInfoId);
        BaseViewModel<string> GetMaxInsertNumber(string DisplayFormat);
        BaseViewModel<bool> InvalidProductCode(DacInsertToWarehouseVM importInfoVM);
        BaseViewModel<DacInsertToWarehouse> GetByCode(string InsertNumber);
        BaseViewModel<string> GenerateNewCode();
    }
}
