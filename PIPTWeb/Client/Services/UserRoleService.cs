using Microsoft.AspNetCore.Identity;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Services
{
    interface IUserRoleService 
    {
        public SecUsers user { get; set; }
        public IdentityRole role { get; set; }
        public List<SecUsers> LstUser { get; set; }
        public List<IdentityRole> LstRole { get; set; }
        public IdentityUserRole<string> userRole { get; set; }
        event Action OnChange;
        Task GetUserByRole(string roleId);
        Task<IEnumerable<string>> GetRoleByUser(string userId);
        Task<IdentityUserRole<string>> AddUserRole(IdentityUserRole<string> userRole);
        Task DeleteUserRole(string userId);
    }

    public class UserRoleService : IUserRoleService
    {
        private readonly HttpClient _httpClient;

        public SecUsers user { get; set; } = new SecUsers();
        public IdentityRole role { get; set; } = new IdentityRole();
        public List<SecUsers> LstUser { get; set; } = new List<SecUsers>();
        public List<IdentityRole> LstRole { get; set; } = new List<IdentityRole>();
        public IdentityUserRole<string> userRole { get; set; } = new IdentityUserRole<string>();

        public UserRoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public event Action OnChange;

        public async Task<IdentityUserRole<string>> AddUserRole(IdentityUserRole<string> userRole)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/v1/UserRole/Create", userRole);
            OnChange.Invoke();
            return await result.Content.ReadFromJsonAsync<IdentityUserRole<string>>();
        }

        public async Task DeleteUserRole(string userId)
        {
            await _httpClient.DeleteAsync($"api/v1/UserRole/?userId={userId}");
            OnChange.Invoke();
        }

        public async Task<IEnumerable<string>> GetRoleByUser(string userId)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/UserRole/getrole", userId);
            try
            {
                var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<string>>();
                if (responseContent.Code == "200")
                {
                    //OnChange.Invoke();
                    return responseContent.Data;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            //OnChange.Invoke();
            return null;
        }

        public async Task GetUserByRole(string roleId)
        {
            LstUser = await _httpClient.GetFromJsonAsync<List<SecUsers>>($"api/v1/UserRole/GetUserByRole/{roleId}");
        }

        public async Task<List<Claim>> GetUserRoleClaims(string userId)
        {
            var claims = await _httpClient.GetFromJsonAsync<ResultApiModel<RoleClaimsViewModel>>($"api/v1/userrole/getroleclaims/?userId={userId}");
            var permissions = new List<Claim>();
            foreach(var claim in claims.Data)
            {
                permissions.Add(new Claim(claim.Type, claim.Value));
            }
            return permissions;
        }
    }
}
