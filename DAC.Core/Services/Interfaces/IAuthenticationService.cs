using DAC.DAL;
using DAC.DAL.ViewModels;

namespace DAC.Core.Services.Interfaces
{
    public interface IAuthenticationService
    {
        BaseViewModel<SecUsersVM> Login(string loginId, string Password);
    }
}
