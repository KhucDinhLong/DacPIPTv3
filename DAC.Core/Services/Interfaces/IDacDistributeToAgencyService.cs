using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacDistributeToAgencyService
    {
        BaseViewModel<List<DacDistributeToAgencyVM>> GetAll();
        BaseViewModel<DacDistributeToAgencyVM> GetDetail(int Id);
        BaseViewModel<DacDistributeToAgencyVM> Create(DacDistributeToAgencyVM exportInfoVM);
        BaseViewModel<DacDistributeToAgencyVM> Edit(DacDistributeToAgencyVM exportInfoVM);
        BaseViewModel<bool> Delete(int exportInfoId);
        BaseViewModel<string> GenerateNewCode();
        BaseViewModel<bool> InvalidProductCode(string DacCode, string ProductCode);
        BaseViewModel<DacDistributeToAgency> GetByCode(string OrderNumber);
    }
}
