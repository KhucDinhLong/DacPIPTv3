using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Services
{
    public interface IRoleService
    {
        IEnumerable<SecRoles> LstRole { get; set; }
        SecRoles role { get; set; }
        int totalPages { get; set; }
        event Action OnChange;
        Task LoadRoles(PaginatedInputModel pagination);
        Task<SecRoles> CreateRole(SecRoles request);
        Task<SecRoles> GetRoleById(string id);
        Task<int> DeleteRoleById(string id);
        Task<SecRoles> EditRoleById(string id, SecRoles request);
        Task GetAllRoles();
    }
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;
        public RoleService(HttpClient httpClient) => _httpClient = httpClient;
        public IEnumerable<SecRoles> LstRole { get; set; } = new List<SecRoles>();
        public SecRoles role { get; set; } = new SecRoles();
        public int totalPages { get; set; } = 1;

        public event Action OnChange;

        public async Task<SecRoles> CreateRole(SecRoles request)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/v1/Role/Create", request);
            return await result.Content.ReadFromJsonAsync<SecRoles>();
        }

        public async Task<int> DeleteRoleById(string id)
        {
            var result = await _httpClient.PostAsync($"api/v1/Role/Delete/{id}", null);
            var content = result.Content.ReadAsStringAsync();
            return Convert.ToInt16(content.Result);
        }

        public async Task<SecRoles> EditRoleById(string id, SecRoles request)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/v1/Role/Edit/{id}", request);
            return await result.Content.ReadFromJsonAsync<SecRoles>();
        }

        public async Task GetAllRoles()
        {
            var response = await _httpClient.GetAsync($"api/v1/Role");
            LstRole = await response.Content.ReadFromJsonAsync<List<SecRoles>>();
            OnChange.Invoke();
        }

        public async Task<SecRoles> GetRoleById(string id)
        {
            role = await _httpClient.GetFromJsonAsync<SecRoles>($"api/v1/Role/{id}");
            return role;
        }

        public async Task LoadRoles(PaginatedInputModel pagination)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync($"api/v1/Role", pagination);
            if (httpResponse.IsSuccessStatusCode)
            {
                var resultApiModel = await httpResponse.Content.ReadFromJsonAsync<ResultApiModel<SecRoles>>();
                LstRole = resultApiModel.Data;
                if (resultApiModel.Pagination != null)
                {
                    totalPages = resultApiModel.Pagination.PagesQuantity;
                }
                else
                {
                    totalPages = 1;
                }
            }
            OnChange.Invoke();
        }
    }
}
