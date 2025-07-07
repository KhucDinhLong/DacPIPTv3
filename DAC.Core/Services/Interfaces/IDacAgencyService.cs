using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacAgencyService
    {
        BaseViewModel<List<DacAgencyVM>> GetAll();
        BaseViewModel<DacAgency> GetById(int id);
        BaseViewModel<DacAgency> GetByCode(string code);
        BaseViewModel<DacAgency> Create(DacAgency newAgency);
        BaseViewModel<DacAgency> Edit(DacAgency agency);
        BaseViewModel<bool> Delete(int id);
        BaseViewModel<bool> HasUsed(string code);
        BaseViewModel<int> ImportFromExcel(string filePath, string UserName);
    }
}
