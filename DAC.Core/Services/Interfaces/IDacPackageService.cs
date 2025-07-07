using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacPackageService
    {
        BaseViewModel<List<DacPackageVM>> GetAll();
        BaseViewModel<DacPackageVM> GetDetail(int PackageId);
        BaseViewModel<DacPackageVM> Create(DacPackageVM packageVM);
        BaseViewModel<DacPackageVM> Edit(DacPackageVM packageVM);
        BaseViewModel<bool> Delete(int packageId);
        BaseViewModel<bool> Exist(string PackageCode);
        BaseViewModel<string> GetMaxPackage(string pattern, string Size);
        BaseViewModel<bool> InvalidProductCode(DacPackageVM packageVM);
        BaseViewModel<DacPackageVM> GetInfo(string DacCode);
    }
}
