using Microsoft.AspNetCore.Identity;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System.Threading.Tasks;

namespace PIPTWeb.Shared
{
    public interface IUserManagementService
    {
        Task<SecUsers> IsValidUsers(string username, string password);
        Task<SecUsers> Register(RegisterRequest registerRequest);
    }

    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<SecUsers> _userManager;

        public UserManagementService(UserManager<SecUsers> userManager)
        {
            _userManager = userManager;
        }

        public async Task<SecUsers> IsValidUsers(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user != null)
            {
                var singInResult = await _userManager.CheckPasswordAsync(user, password);
                if (singInResult)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            return user;
        }

        public async Task<SecUsers> Register(RegisterRequest registerModel)
        {
            var user = new SecUsers();
            user.UserName = registerModel.UserName;
            user.Email = registerModel.Email;
            user.FirstName = registerModel.FirstName;
            user.LastName = registerModel.LastName;
            user.IsAdmin = false;
            var registerResult = await _userManager.CreateAsync(user, registerModel.Password);
            if(registerResult.Succeeded)
            {
                return user;
            }
            return null;
        }
    }
}
