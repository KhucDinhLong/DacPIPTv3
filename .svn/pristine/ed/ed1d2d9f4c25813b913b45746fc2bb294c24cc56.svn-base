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
    public interface IMenuService
    {
        IEnumerable<SysMenu> LstMenu { get; set; }
        SysMenu Menu { get; set; }
        int totalPages { get; set; }
        event Action OnChange;
        Task LoadMenus(PaginatedInputModel pagination);
        Task<bool> CreateMenu(SysMenu request);
        Task<SysMenu> GetMenuById(int id);
        Task<bool> DeleteMenuById(int id);
        Task<bool> EditMenuById(int id, SysMenu request);
        Task GetMenus();
    }
    public class MenuService : IMenuService
    {
        private readonly HttpClient _httpClient;
        public MenuService(HttpClient httpClient) => _httpClient = httpClient;
        public IEnumerable<SysMenu> LstMenu { get; set; }
        public SysMenu Menu { get; set; } = new SysMenu();
        public int totalPages { get; set; } = 1;

        public event Action OnChange;

        public async Task<bool> CreateMenu(SysMenu request)
        {
            request.Active = true;
            var response = await _httpClient.PostAsJsonAsync($"api/v1/Menu/Create", request);
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<SysMenu>>();
            if (responseContent.Code == "201")
                return true;
            return false;
        }

        public async Task<bool> DeleteMenuById(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/Menu/{id}");
            var code = await response.Content.ReadAsStringAsync();
            if (code == "204")
                return true;
            return false;
        }

        public async Task<bool> EditMenuById(int id, SysMenu request)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/Menu/{id}", request);
            ResultApiModel<SysMenu> responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<SysMenu>>();
            if (responseContent.Code == "200")
                return true;
            return false;
        }

        public async Task GetMenus()
        {
            LstMenu = await _httpClient.GetFromJsonAsync<List<SysMenu>>($"api/v1/Menu");
            OnChange.Invoke();
        }

        public async Task<SysMenu> GetMenuById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ResultApiModel<SysMenu>>($"api/v1/Menu/{id}");
            if (response.Code == "200")
            {
                IEnumerable<SysMenu> data = response.Data;
                if (data != null && data.Count() > 0)
                {
                    Menu = data.ElementAt(0);
                }
            }
            return Menu;
        }

        public async Task LoadMenus(PaginatedInputModel pagination)
        {
            //var response = await _httpClient.GetFromJsonAsync<ResultApiModel<PositionModel>>($"api/Position/?page={page}&limit={limit}");
            var httpResponse = await _httpClient.PostAsJsonAsync($"api/v1/Menu", pagination);
            if (httpResponse.IsSuccessStatusCode)
            {
                var resultApiModel = await httpResponse.Content.ReadFromJsonAsync<ResultApiModel<SysMenu>>();
                LstMenu = resultApiModel.Data;
                totalPages = resultApiModel.Pagination.PagesQuantity;
            }
            OnChange.Invoke();
        }

    }
}

