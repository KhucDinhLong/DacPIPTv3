using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PIPTWeb.Client.Utils;
using PIPTWeb.Shared;
using PIPTWeb.Shared.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Services
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;

        private AuthenticationState anonymous;
        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrWhiteSpace(token))
                return anonymous;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            List<Claim> Claims = new List<Claim>();
            Claims.AddRange(JwtParser.ParseClaimsFromJwt(token));
            // thêm claims của user để xác nhận quyền
            var localClaims = await localStorage.GetItemAsync<string>("authClaims");
            localClaims = PIPTWebMethods.DecryptString(localClaims);
            List<AuthClaims> authClaims = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuthClaims>>(localClaims);
            
            if (authClaims != null)
            {
                foreach (var claim in authClaims)
                {
                    Claims.Add(new Claim(claim.Type, claim.Value));
                }
            }
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(Claims, "jwtAuthType")));
        }
        public async void NotifyUserAuthentication(string jwtToken)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            List<Claim> Claims = new List<Claim>();
            Claims.AddRange(JwtParser.ParseClaimsFromJwt(jwtToken));
            // thêm claims của user để xác nhận quyền
            var localClaims = await localStorage.GetItemAsync<string>("authClaims");
            localClaims = PIPTWebMethods.DecryptString(localClaims);
            List<AuthClaims> authClaims = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuthClaims>>(localClaims);

            if (authClaims != null)
            {
                foreach (var claim in authClaims)
                {
                    Claims.Add(new Claim(claim.Type, claim.Value));
                }
            }

            var authUser = new ClaimsPrincipal(new ClaimsIdentity(Claims, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authUser));
            NotifyAuthenticationStateChanged(authState);
        }
        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
