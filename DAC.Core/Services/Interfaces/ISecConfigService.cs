using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface ISecConfigService
    {
        BaseViewModel<List<SecConfig>> GetAll();
        BaseViewModel<SecConfig> GetByCode(string ConfigCode);
        BaseViewModel<SecConfig> Create(SecConfig NewConfig);
        BaseViewModel<SecConfig> Edit(SecConfig secConfig);
        BaseViewModel<bool> Delete(int Id);
    }
}
