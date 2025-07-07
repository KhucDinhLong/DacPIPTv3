using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface ISecUsersService
    {
        BaseViewModel<List<SecUsersVM>> GetAll();
        BaseViewModel<SecUsers> GetByLoginID(string loginID);
        BaseViewModel<bool> Exists(string loginID);
        BaseViewModel<SecUsersVM> Create(SecUsersVM entity);
        BaseViewModel<SecUsersVM> Edit(SecUsersVM entity);
        BaseViewModel<bool> Delete(string LoginId);
        BaseViewModel<bool> ResetPassword(string loginID, string password);
    }
}
