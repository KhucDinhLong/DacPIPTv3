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
    public interface IDacProductService
    {
        int totalPages { get; set; }
        Task<List<DacProduct>> GetProducts();
        Task<List<DacProduct>> GetPagingProducts(PaginatedInputModel pagination);
        Task<List<DacProduct>> GetProductByUserName(string UserName);
        Task<DacProduct> GetProductById(int ProductId);
        Task<DacProduct> GetProductByCode(string ProductCode);
        Task<List<DacProduct>> GetProductByName(string ProductName);
        Task<string> CreateProduct(DacProduct product);
        Task<string> UpdateProduct(DacProduct product);
        Task<string> DeleteProduct(int ProductId);
    }
    public class DacProductService : IDacProductService
    {
        private readonly HttpClient _httpClient;
        public DacProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public int totalPages { get; set; } = 1;

        public async Task<string> CreateProduct(DacProduct product)
        {
            product.Active = true;
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacProduct/Create", product);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacProduct>>();
            return ResponseContent.Message;
        }

        public async Task<string> DeleteProduct(int ProductId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/DacProduct/{ProductId}");
            var ResponseCode = await response.Content.ReadAsStringAsync();
            if (ResponseCode == "500")
                return "Sản phẩm đã được xuất đi, không thể xóa!";
            else if (ResponseCode == "204")
                return "Xóa sản phẩm thành công!";
            else if (ResponseCode == "200")
                return "Sản phẩm không tồn tại!";
            else
                return "Có lỗi xảy ra trong quá trình xóa dữ liệu!";
        }

        public async Task<List<DacProduct>> GetPagingProducts(PaginatedInputModel pagination)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacProduct", pagination);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacProduct>>();
            if (ResponseContent.Code == "200" && ResponseContent.Data != null)
            {
                totalPages = ResponseContent.Pagination.PagesQuantity;
                return ResponseContent.Data.ToList();
            }
            else
            {
                totalPages = 1;
                return new List<DacProduct>();
            }
        }

        public async Task<DacProduct> GetProductByCode(string ProductCode)
        {
            var response = await _httpClient.GetFromJsonAsync<DacProduct>($"api/v1/DacProduct/GetProductByCode/?ProductCode={ProductCode}");
            return response;
        }

        public async Task<DacProduct> GetProductById(int ProductId)
        {
            var response = await _httpClient.GetFromJsonAsync<DacProduct>($"api/v1/DacProduct/GetProductById/?ProductId={ProductId}");
            return response;
        }

        public async Task<List<DacProduct>> GetProductByName(string ProductName)
        {
            var response = await _httpClient.GetFromJsonAsync<ResultApiModel<DacProduct>>($"api/v1/DacProduct/GetProductByName/?ProductName={ProductName}");
            if (response.Data != null)
                return response.Data.ToList();
            else
                return new List<DacProduct>();
        }

        public async Task<List<DacProduct>> GetProductByUserName(string UserName)
        {
            var response = await _httpClient.GetFromJsonAsync<ResultApiModel<DacProduct>>($"api/v1/DacProduct/GetProductByUserName/?UserName={UserName}");
            if (response.Data != null)
                return response.Data.ToList();
            else
                return new List<DacProduct>();
        }

        public async Task<List<DacProduct>> GetProducts()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DacProduct>>($"api/v1/DacProduct");
            return response;
        }

        public async Task<string> UpdateProduct(DacProduct product)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/DacProduct", product);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacProduct>>();
            return ResponseContent.Message;
        }
    }
}
