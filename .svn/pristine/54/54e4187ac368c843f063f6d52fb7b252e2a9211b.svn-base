using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared;
using PIPTWeb.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Components
{
    public partial class RequiredPassword
    {
        public LoginRequest login { get; set; }
        [Parameter] public string link { get; set; }
        [Parameter] public EventCallback OnValidSubmitCallBack { get; set; }
        [Parameter] public EventCallback OnCloseCallBack { get; set; }
        [Inject] private NavigationManager navigation { get; set; }
        [Inject] private IAuthenticationService authentication { get; set; }
        [Inject] private ILocalStorageService localStorage { get; set; }

        public bool showAuthError { get; set; }
        public string Error { get; set; }

        protected override async Task OnInitializedAsync()
        {
            login = new LoginRequest();
            login.UserName = await localStorage.GetItemAsync<string>("UserName");
        }
        private async Task OnvalidSubmit()
        {
            showAuthError = false;
            var result = await authentication.IsValidUser(login);
            if (!result)
            {
                Error = "Mật khẩu không đúng, xin kiểm tra lại!";
                showAuthError = true;
            }
            else
            {
                await localStorage.SetItemAsync("ConfirmPassword", true);
                navigation.NavigateTo(link);
                await OnValidSubmitCallBack.InvokeAsync();
            }
        }

        private async Task OnClose()
        {
            await OnCloseCallBack.InvokeAsync();
        }
    }
}
