using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacProductService
    {
        BaseViewModel<List<DacProductVM>> GetAll();
        BaseViewModel<DacProduct> GetById(int Id);
        BaseViewModel<DacProduct> GetByCode(string ProductCode);
        BaseViewModel<DacProduct> Create(DacProduct NewProduct);
        BaseViewModel<DacProduct> Edit(DacProduct Product);
        BaseViewModel<bool> Delete(int Id);
        BaseViewModel<bool> HasUsed(string ProductCode);
    }
}
