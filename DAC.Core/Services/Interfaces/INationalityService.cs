using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface INationalityService
    {
        BaseViewModel<List<Nationality>> GetAll();
        BaseViewModel<Nationality> GetById(int id);
        BaseViewModel<Nationality> Create(Nationality nationality);
        BaseViewModel<Nationality> Edit(Nationality nationality);
        BaseViewModel<bool> Delete(int id);
    }
}
