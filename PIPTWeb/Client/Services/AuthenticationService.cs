using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PIPTWeb.Shared.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Services
{
    public interface IAuthenticationService
    {
        public Task<RegisterResponse> Register(RegisterRequest model);
        public Task<LoginResult> Login(LoginModel model);
        public Task Logout();
        public Task<bool> ChangePassword(ChangePwdModel changePwdModel);
        public Task<string> UploadAvatar(UploadFileModel avatar);
        public Task<bool> IsValidUser(LoginRequest login);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authStateProvider;
        private readonly ILocalStorageService localStorage;
        public AuthenticationService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.authStateProvider = authStateProvider;
            this.localStorage = localStorage;
        }

        public async Task<bool> ChangePassword(ChangePwdModel changePwdModel)
        {
            var result = false;
            var response = await httpClient.PostAsJsonAsync("api/v1/Authentication/changepassword", changePwdModel);
            result = await response.Content.ReadFromJsonAsync<bool>();
            return result;
        }

        public async Task<bool> IsValidUser(LoginRequest login)
        {
            var response = await httpClient.PostAsJsonAsync("api/v1/Authentication/IsValidUser", login);
            var responseContent = await response.Content.ReadFromJsonAsync<bool>();
            return responseContent;
        }

        public async Task<LoginResult> Login(LoginModel model)
        {
            var authResult = await httpClient.PostAsJsonAsync("api/v1/Authentication/login", model);
            var authContent = await authResult.Content.ReadFromJsonAsync<LoginResult>();
            if (!authContent.Success)
            {
                return authContent;
            }
            await localStorage.SetItemAsync("authToken", authContent.Token);
            await localStorage.SetItemAsync("authClaims", authContent.RoleClaims);
            ((AuthStateProvider)authStateProvider).NotifyUserAuthentication(authContent.Token);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authContent.Token);

            return authContent;
        }

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("authToken");
            await localStorage.RemoveItemAsync("authClaims");
            ((AuthStateProvider)authStateProvider).NotifyUserLogout();
            httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegisterResponse> Register(RegisterRequest model)
        {
            var result = await httpClient.PostAsJsonAsync("api/v1/Authentication/register", model);
            if (!result.IsSuccessStatusCode)
                return new RegisterResponse
                {
                    IsSuccessfulRegistration = false
                };
            return new RegisterResponse
            {
                IsSuccessfulRegistration = true
            };
        }

        public async Task<string> UploadAvatar(UploadFileModel avatar)
        {
            var response = await httpClient.PostAsJsonAsync("api/v1/Authentication/uploadavatar", avatar);
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<UploadFileModel>>();
            if (responseContent.Code == "200")
                return responseContent.Message;
            else
                return "Tải file thất bại";
        }
    }
}
