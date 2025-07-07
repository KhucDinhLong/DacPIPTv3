using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using PIPTWeb.Client.Services;
using Blazored.LocalStorage;

namespace PIPTWeb.Client.Pages.Account
{
    public partial class Logout
    {
        [Inject]
        public IAuthenticationService authenticationService { get; set; }
        [Inject]
        public NavigationManager navigation { get; set; }
        [Inject]
        public ILocalStorageService localStorage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await authenticationService.Logout();
            dataStorage.lstMenus = null;
            await localStorage.RemoveItemAsync("UserName");
            await localStorage.RemoveItemAsync("lstMenu");
            await localStorage.RemoveItemAsync("FullName");
            await localStorage.RemoveItemAsync("Avatar");
            await localStorage.RemoveItemAsync("ConfirmPassword");
            navigation.NavigateTo("/login");
        }
    }
}
