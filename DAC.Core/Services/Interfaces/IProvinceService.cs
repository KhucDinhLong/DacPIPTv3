using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IProvinceService
    {
        BaseViewModel<List<Province>> GetAll();
        BaseViewModel<Province> GetById(int id);
        BaseViewModel<Province> Create(Province province);
        BaseViewModel<Province> Edit(Province province);
        BaseViewModel<bool> Delete(int id);
    }
}
