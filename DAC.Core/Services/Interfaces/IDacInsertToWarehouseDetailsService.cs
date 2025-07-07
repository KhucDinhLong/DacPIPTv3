using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacInsertToWarehouseDetailsService
    {
        BaseViewModel<DacInsertToWarehouseDetails> GetByDacCode(string DacCode);
        BaseViewModel<bool> AddRange(List<DacInsertToWarehouseDetails> LstDetail);
        BaseViewModel<bool> DeleteByDacCode(List<string> LstDacCode);
        BaseViewModel<bool> DeleteByDacCode(string DacCode);
    }
}
