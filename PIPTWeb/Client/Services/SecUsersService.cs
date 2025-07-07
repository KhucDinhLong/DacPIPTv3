using Blazored.LocalStorage;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Services
{
    public interface ISecUsersService
    {
        IEnumerable<SecUsers> LstUser { get; set; }
        SecUsers user { get; set; }
        int totalPages { get; set; }
        event Action OnChange;
        Task LoadUsers(PaginatedInputModel pagination);
        Task<SecUsers> CreateUser(SecUsers request);
        Task<SecUsers> GetUserById(string id);
        Task<bool> DeleteUserById(string id);
        Task<SecUsers> EditUserById(string id, SecUsers request);
        Task<SecUsers> GetUserByUserName(string UserName);
        Task<bool> SetPassword(string UserName);
        Task<Customers> GetCustomerByUserNameAsync(string UserName);
        Customers GetCustomerByUserName(string UserName);
    }
    public class SecUsersService : ISecUsersService
    {
        private readonly ILocalStorageService _localStorage;

        private readonly HttpClient _httpClient;
        public SecUsersService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }
        public IEnumerable<SecUsers> LstUser { get; set; } = new List<SecUsers>();
        public SecUsers user { get; set; } = new SecUsers();
        public int totalPages { get; set; } = 1;

        public event Action OnChange;

        public async Task<SecUsers> CreateUser(SecUsers request)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/v1/SecUsers/Create", request);
            return await result.Content.ReadFromJsonAsync<SecUsers>();
        }

        public async Task<bool> DeleteUserById(string id)
        {
            var result = await _httpClient.PostAsync($"api/v1/SecUsers/Delete/{id}", null);
            var content = result.Content.ReadAsStringAsync();
            return Convert.ToBoolean(content.Result);
        }

        public async Task<SecUsers> EditUserById(string id, SecUsers request)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/v1/SecUsers/Edit/{id}", request);
            return await result.Content.ReadFromJsonAsync<SecUsers>();
        }

        public async Task<SecUsers> GetUserById(string id)
        {
            user = await _httpClient.GetFromJsonAsync<SecUsers>($"api/v1/SecUsers/{id}");
            return user;
        }

        public async Task<SecUsers> GetUserByUserName(string UserName)
        {
            user = await _httpClient.GetFromJsonAsync<SecUsers>($"api/v1/SecUsers/GetByUserName/?UserName={UserName}");
            return user;
        }

        public async Task LoadUsers(PaginatedInputModel pagination)
        {
            //var token = await _localStorage.GetItemAsync<string>("authToken");
            //_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var httpResponse = await _httpClient.PostAsJsonAsync($"api/v1/SecUsers", pagination);
            if (httpResponse.IsSuccessStatusCode)
            {
                var resultApiModel = await httpResponse.Content.ReadFromJsonAsync<ResultApiModel<SecUsers>>();
                LstUser = resultApiModel.Data;
                totalPages = resultApiModel.Pagination.PagesQuantity;
            }
            OnChange.Invoke();
        }

        public async Task<bool> SetPassword(string UserName)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<string>($"api/v1/SecUsers/setpassword/?UserName={UserName}", UserName);
                var responseContent = await response.Content.ReadFromJsonAsync<bool>();
                return responseContent;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<Customers> GetCustomerByUserNameAsync(string UserName)
        {
            var response = await _httpClient.GetFromJsonAsync<Customers>($"api/v1/SecUsers/GetCustomerByUserName/?UserName={UserName}");
            return response;
        }

        public Customers GetCustomerByUserName(string UserName)
        {
            var response = _httpClient.GetFromJsonAsync<Customers>($"api/v1/SecUsers/GetCustomerByUserName/?UserName={UserName}");
            return response.Result;
        }
    }
}
