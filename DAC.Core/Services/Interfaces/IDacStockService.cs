using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacStockService
    {
        BaseViewModel<List<DacStock>> GetAll();
        BaseViewModel<DacStock> GetById(int id);
        BaseViewModel<DacStock> Create(DacStock stock);
        BaseViewModel<DacStock> Edit(DacStock stock);
        BaseViewModel<bool> Delete(int id);
        BaseViewModel<bool> HasUsed(string code);
        BaseViewModel<DacStock> GetByCode(string StockCode);
        BaseViewModel<int> ImportFromExcel(string filePath, string UserName);
    }
}
