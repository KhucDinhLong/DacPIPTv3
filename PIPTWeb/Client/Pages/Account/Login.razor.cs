using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web;

namespace PIPTWeb.Client.Pages.Account
{
    public partial class Login
    {
        private LoginModel loginModel = new LoginModel();
        [Inject] public IAuthenticationService authenticationService { get; set; }
        [Inject] public NavigationManager navigation { get; set; }
        [Inject] public ILocalStorageService localStorage { get; set; }


        public bool showAuthError { get; set; }
        public string Error { get; set; }
        public async Task ExecuteLogin()
        {
            showAuthError = false;
            var result = await authenticationService.Login(loginModel);
            if (!result.Success)
            {
                Error = result.Message;
                showAuthError = true;
            }
            else
            {
                await localStorage.SetItemAsync("UserName", result.UserName);
                await localStorage.SetItemAsync("lstMenu", result.Menus);
                await localStorage.SetItemAsync("FullName", result.FullName);
                await localStorage.SetItemAsync("Avatar", result.Avatar);
                var QueryString = HttpUtility.ParseQueryString(new Uri(navigation.Uri).Query);
                if (QueryString.Count > 0)
                {
                    navigation.NavigateTo(QueryString["returnUrl"].ToString());
                }
                else
                {
                    navigation.NavigateTo("/");
                }
            }
        }
    }
}
