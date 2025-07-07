using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface ISecGroupUserService
    {
        BaseViewModel<List<SecGroupUser>> GetAll();
        BaseViewModel<List<SecGroupUser>> GetByLoginID(string loginID);
        BaseViewModel<bool> Add(SecGroupUser entity);
        BaseViewModel<bool> Delete(SecGroupUser entity);
    }
}
