using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Services
{
    public interface IProvincesService
    {
        int totalPages { get; set; }
        Task<List<Province>> GetProvinces(bool? Active);
        Task<List<Province>> GetPagingProvinces(PaginatedInputModel pagination);
        Task<Province> GetProvinceById(int ProvinceId);
        Task<Province> GetProvinceByCode(string ProvinceCode);
        Task<string> CreateProvince(Province province);
        Task<string> UpdateProvince(Province province);
        Task<string> DeleteProvince(int ProvinceId);
    }
    public class ProvincesService : IProvincesService
    {
        private readonly HttpClient _httpClient;
        public ProvincesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public int totalPages { get; set; }

        public async Task<string> CreateProvince(Province province)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/Provinces/Create", province);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<Province>>();
            return ResponseContent.Message;
        }

        public async Task<string> DeleteProvince(int ProvinceId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/Provinces/{ProvinceId}");
            var ResponseCode = await response.Content.ReadAsStringAsync();
            if (ResponseCode == "500")
                return "Mã tỉnh thành này hiện đang có đại lý sử dụng, không thể xóa!";
            else if (ResponseCode == "204")
                return "Xóa tỉnh thành thành công!";
            else if (ResponseCode == "200")
                return "Tỉnh thành không tồn tại!";
            else
                return "Có lỗi xảy ra trong quá trình xóa dữ liệu!";
        }

        public async Task<List<Province>> GetPagingProvinces(PaginatedInputModel pagination)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/Provinces", pagination);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<Province>>();
            if (ResponseContent.Code == "200" && ResponseContent.Data != null)
            {
                totalPages = ResponseContent.Pagination.PagesQuantity;
                return ResponseContent.Data.ToList();
            }
            else
            {
                totalPages = 1;
                return new List<Province>();
            }
        }

        public async Task<Province> GetProvinceByCode(string ProvinceCode)
        {
            var response = await _httpClient.GetFromJsonAsync<Province>($"api/v1/Provinces/GetProvinceByCode/?ProvinceCode={ProvinceCode}");
            return response;
        }

        public async Task<Province> GetProvinceById(int ProvinceId)
        {
            var response = await _httpClient.GetFromJsonAsync<Province>($"api/v1/Provinces/GetProvinceById/?ProvinceId={ProvinceId}");
            return response;
        }

        public async Task<List<Province>> GetProvinces(bool? Active)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Province>>($"api/v1/Provinces/?Active={Active}");
            return response;
        }

        public async Task<string> UpdateProvince(Province province)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/Provinces", province);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<Province>>();
            return ResponseContent.Message;
        }
    }
}
