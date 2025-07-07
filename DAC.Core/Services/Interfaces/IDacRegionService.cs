using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacRegionService
    {
        BaseViewModel<List<DacRegion>> GetAll();
        BaseViewModel<DacRegion> GetById(int id);
        BaseViewModel<DacRegion> Create(DacRegion newRegion);
        BaseViewModel<DacRegion> Edit(DacRegion region);
        BaseViewModel<bool> Delete(int id);
    }
}
