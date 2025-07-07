using DAC.DAL;
using DAC.DAL.ViewModels;
using System.Collections.Generic;

namespace DAC.Core.Services.Interfaces
{
    public interface IDacProductUnitService
    {
        BaseViewModel<List<DacProductUnit>> GetAll();
    }
}
