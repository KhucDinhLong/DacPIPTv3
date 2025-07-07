using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDistrictService
    {
        BaseViewModel<List<District>> GetAll();
        BaseViewModel<District> GetById(int id);
        BaseViewModel<District> Create(District district);
        BaseViewModel<District> Edit(District district);
        BaseViewModel<bool> Delete(int id);
    }
}
