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
    public interface ICustomersService
    {
        int totalPages { get; set; }
        Task<List<Customers>> GetCustomers(bool? Active);
        Task<List<Customers>> GetPagingCustomers(PaginatedInputModel pagination);
        Task<Customers> GetCustomerByUserName(string UserName);
        Task<Customers> GetCustomerById(int CustomerId);
        Task<Customers> GetCustomerByCode(string CustomerCode);
        Task<string> CreateCustomer(Customers customer);
        Task<string> UpdateCustomer(Customers customer);
        Task<string> DeleteCustomer(int CustomerId);
    }
    public class CustomersService : ICustomersService
    {
        private readonly HttpClient _httpClient;
        public CustomersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public int totalPages { get; set; } = 1;

        public async Task<string> CreateCustomer(Customers customer)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/Customers/Create", customer);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<Customers>>();
            return ResponseContent.Message;
        }

        public async Task<string> DeleteCustomer(int CustomerId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/Customers/{CustomerId}");
            var ResponseCode = await response.Content.ReadAsStringAsync();
            if (ResponseCode == "500")
                return "Khách hàng này hiện đang có đại lý được quản lý, không thể xóa!";
            else if (ResponseCode == "204")
                return "Xóa khách hàng thành công!";
            else if (ResponseCode == "200")
                return "Khách hàng không tồn tại!";
            else
                return "Có lỗi xảy ra trong quá trình xóa dữ liệu!";
        }

        public async Task<Customers> GetCustomerByCode(string CustomerCode)
        {
            var response = await _httpClient.GetFromJsonAsync<Customers>($"api/v1/Customers/GetCustomerByCode/?CustomerCode={CustomerCode}");
            return response;
        }

        public async Task<Customers> GetCustomerById(int CustomerId)
        {
            var response = await _httpClient.GetFromJsonAsync<Customers>($"api/v1/Customers/GetCustomerById/?CustomerId={CustomerId}");
            return response;
        }

        public async Task<Customers> GetCustomerByUserName(string UserName)
        {
            var response = await _httpClient.GetFromJsonAsync<Customers>($"api/v1/Customers/GetCustomerByUserName/?UserName={UserName}");
            return response;
        }

        public async Task<List<Customers>> GetCustomers(bool? Active)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Customers>>($"api/v1/Customers/?Active={Active}");
            return response;
        }

        public async Task<List<Customers>> GetPagingCustomers(PaginatedInputModel pagination)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/Customers", pagination);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<Customers>>();
            if (ResponseContent.Code == "200" && ResponseContent.Data != null)
            {
                totalPages = ResponseContent.Pagination.PagesQuantity;
                return ResponseContent.Data.ToList();
            }
            else
            {
                totalPages = 1;
                return new List<Customers>();
            }
        }

        public async Task<string> UpdateCustomer(Customers customer)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/Customers", customer);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<Customers>>();
            return ResponseContent.Message;
        }
    }
}
