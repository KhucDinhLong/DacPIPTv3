using DAC.DAL;
using DAC.DAL.ViewModels;
using System;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface ISecGroupsService
    {
        BaseViewModel<List<SecGroups>> GetAll();
        BaseViewModel<SecGroups> GetById(Guid groupId);
        BaseViewModel<bool> Add(SecGroups entity);
        BaseViewModel<bool> Update(SecGroups entity);
        BaseViewModel<bool> Delete(SecGroups entity);
    }
}
