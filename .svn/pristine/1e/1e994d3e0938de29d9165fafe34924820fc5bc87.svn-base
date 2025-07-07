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
    public interface IDacAgencyService
    {
        int totalPages { get; set; }
        Task<List<DacAgency>> GetAgencies(bool? Active);
        Task<List<DacAgency>> GetPagingAgencies(PaginatedInputModel pagination);
        Task<DacAgency> GetAgencyByUserName(string UserName);
        Task<List<DacAgency>> GetChildrenAgenciesByUserName(string UserName);
        Task<DacAgency> GetParentAgencyByUserName(string UserName);
        Task<DacAgency> GetAgencyById(int AgencyId);
        Task<DacAgency> GetAgencyByCode(string AgencyCode);
        Task<List<DacAgency>> GetAgencyByName(string AgencyName);
        Task<string> CreateAgency(DacAgency agency);
        Task<List<DacAgency>> GetChildrenByAgencyId(int AgencyId);
        Task<string> UpdateAgency(DacAgency agency);
        Task<string> DeleteAgency(int AgencyId);
        Task<List<DacAgency>> GetPagingAgenciesByUserName(PaginatedInputModel pagination, string UserName);
    }
    public class DacAgencyService : IDacAgencyService
    {
        private readonly HttpClient _httpClient;
        public DacAgencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public int totalPages { get; set; } = 1;

        public async Task<string> CreateAgency(DacAgency agency)
        {
            agency.Active = true;
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacAgency/Create", agency);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacAgency>>();
            return ResponseContent.Message;
        }

        public async Task<string> DeleteAgency(int AgencyId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/DacAgency/{AgencyId}");
            var ResponseCode = await response.Content.ReadAsStringAsync();
            if (ResponseCode == "500")
                return "Đại lý hiện đang có đại lý cấp dưới, không thể xóa!";
            else if (ResponseCode == "204")
                return "Xóa đại lý thành công!";
            else if (ResponseCode == "200")
                return "Đại lý không tồn tại!";
            else
                return "Có lỗi xảy ra trong quá trình xóa dữ liệu!";
        }

        public async Task<List<DacAgency>> GetAgencies(bool? Active)
        {
            var response = await _httpClient.GetFromJsonAsync<List<DacAgency>>($"api/v1/DacAgency/?Active={Active}");
            return response;
        }

        public async Task<DacAgency> GetAgencyByCode(string AgencyCode)
        {
            var response = await _httpClient.GetFromJsonAsync<DacAgency>($"api/v1/DacAgency/GetAgencyByCode/?AgencyCode={AgencyCode}");
            return response;
        }

        public async Task<DacAgency> GetAgencyById(int AgencyId)
        {
            var response = await _httpClient.GetFromJsonAsync<DacAgency>($"api/v1/DacAgency/GetAgencyById/?AgencyId={AgencyId}");
            return response;
        }

        public async Task<List<DacAgency>> GetAgencyByName(string AgencyName)
        {
            var response = await _httpClient.GetFromJsonAsync<ResultApiModel<DacAgency>>($"api/v1/DacAgency/GetAgencyByName/?AgencyName={AgencyName}");
            if (response.Data != null)
                return response.Data.ToList();
            else
                return new List<DacAgency>();
        }

        public async Task<DacAgency> GetAgencyByUserName(string UserName)
        {
            var response = await _httpClient.GetFromJsonAsync<DacAgency>($"api/v1/DacAgency/GetAgencyByUserName/?UserName={UserName}");
            return response;
        }

        public async Task<List<DacAgency>> GetChildrenAgenciesByUserName(string UserName)
        {
            var response = await _httpClient.GetFromJsonAsync<ResultApiModel<DacAgency>>($"api/v1/DacAgency/GetChildrenAgenciesByUserName/?UserName={UserName}");
            if (response.Data != null)
                return response.Data.ToList();
            else
                return new List<DacAgency>();
        }

        public async Task<List<DacAgency>> GetChildrenByAgencyId(int AgencyId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<DacAgency>>($"api/v1/DacAgency/GetChildrenByAgencyId/?AgencyId={AgencyId}");
                return response;
            }
            catch(Exception ex)
            {
                return new List<DacAgency>();
            } 
            
        }

        public async Task<List<DacAgency>> GetPagingAgencies(PaginatedInputModel pagination)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacAgency", pagination);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacAgency>>();
            if (ResponseContent.Code == "200" && ResponseContent.Data != null)
            {
                totalPages = ResponseContent.Pagination.PagesQuantity;
                return ResponseContent.Data.ToList();
            }
            else
            {
                totalPages = 1;
                return new List<DacAgency>();
            }
        }

        public async Task<List<DacAgency>> GetPagingAgenciesByUserName(PaginatedInputModel pagination, string UserName)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacAgency/GetPagingAgenciesByUserName/?UserName={UserName}", pagination);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacAgency>>();
            if (ResponseContent.Code == "200" && ResponseContent.Data != null)
            {
                totalPages = ResponseContent.Pagination.PagesQuantity;
                return ResponseContent.Data.ToList();
            }
            else
            {
                totalPages = 1;
                return new List<DacAgency>();
            }
        }

        public async Task<DacAgency> GetParentAgencyByUserName(string UserName)
        {
            var response = await _httpClient.GetFromJsonAsync<DacAgency>($"api/v1/DacAgency/GetParentAgencyByUserName/?UserName={UserName}");
            return response;
        }

        public async Task<string> UpdateAgency(DacAgency agency)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/DacAgency", agency);
            var ResponseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacAgency>>();
            return ResponseContent.Message;
        }
    }
}
