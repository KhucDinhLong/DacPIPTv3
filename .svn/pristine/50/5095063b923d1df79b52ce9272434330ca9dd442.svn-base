using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Services
{
    public interface IDacRegionsService
    {
        int totalPages { get; set; }
        Task<List<DacRegion>> GetRegions(bool? Active);
        Task<List<DacRegion>> GetPagingRegions(PaginatedInputModel pagination);
        Task<DacRegion> GetRegionById(int RegionId);
        Task<DacRegion> GetRegionByCode(string RegionCode);
        Task<string> CreateRegion(DacRegion region);
        Task<string> UpdateRegion(DacRegion region);
        Task<string> DeleteRegion(int RegionId);
    }
    public class DacRegionsService : IDacRegionsService
    {
        private readonly HttpClient _httpClient;
        public DacRegionsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public int totalPages { get; set; }

        public async Task<string> CreateRegion(DacRegion region)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacRegions/Create", region);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacRegion>>();
            return ResponseContent.Message;
        }

        public async Task<string> DeleteRegion(int RegionId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/DacRegions/{RegionId}");
            var ResponseCode = await response.Content.ReadAsStringAsync();
            if (ResponseCode == "500")
                return "Mã vùng miền này hiện đang có đại lý sử dụng, không thể xóa!";
            else if (ResponseCode == "204")
                return "Xóa vùng miền thành công!";
            else if (ResponseCode == "200")
                return "Vùng miền không tồn tại!";
            else
                return "Có lỗi xảy ra trong quá trình xóa dữ liệu!";
        }

        public async Task<List<DacRegion>> GetPagingRegions(PaginatedInputModel pagination)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacRegions", pagination);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacRegion>>();
            if (ResponseContent.Code == "200" && ResponseContent.Data != null)
            {
                totalPages = ResponseContent.Pagination.PagesQuantity;
                return ResponseContent.Data.ToList();
            }
            else
            {
                totalPages = 1;
                return new List<DacRegion>();
            }
        }

        public async Task<DacRegion> GetRegionByCode(string RegionCode)
        {
            var response = await _httpClient.GetFromJsonAsync<DacRegion>($"api/v1/DacRegions/GetRegionByCode/?RegionCode={RegionCode}");
            return response;
        }

        public async Task<DacRegion> GetRegionById(int RegionId)
        {
            var response = await _httpClient.GetFromJsonAsync<DacRegion>($"api/v1/DacRegions/GetRegionById/?RegionId={RegionId}");
            return response;
        }

        public async Task<List<DacRegion>> GetRegions(bool? Active)
        {
            var response = await _httpClient.GetFromJsonAsync<List<DacRegion>>($"api/v1/DacRegions/?Active={Active}");
            return response;
        }

        public async Task<string> UpdateRegion(DacRegion region)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/DacRegions", region);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacRegion>>();
            return ResponseContent.Message;
        }
    }
}
