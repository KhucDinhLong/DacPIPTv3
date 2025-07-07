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
    public interface IDacDistributeService
    {
        int totalpage { get; set; }
        Task<List<DacDistributeModel>> GetPagingDistribute(PaginatedInputModel pagination);
        Task<List<DacDistributeModel>> GetPagingDistributeByUserName(PaginatedInputModel pagination, string UserName);
        Task<string> Create(DacDistributeModel distributeModel);
        Task<string> Update(DacDistributeModel distributeModel);
        Task<string> Delete(int DistributeId);
        Task<string> Save(DacDistributeModel distributeModel, bool IsUpdate);
        Task<string> GetMaxOrder();
        Task<List<string>> CheckValidDistribute(string UserName, DacDistributeModel currentDistribute, bool isUpdate);
        Task<string> DeleteSeri(List<DacDistributeToAgencyDetails> LstDeleteSeri);
        Task<List<DacDistributeToAgencyDetails>> GetDetailByDistributeId(int DistributeId);
    }
    public class DacDistributeService : IDacDistributeService
    {
        private readonly HttpClient _httpClient;
        public DacDistributeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public int totalpage { get; set; } = 1;

        public async Task<List<string>> CheckValidDistribute(string UserName, DacDistributeModel currentDistribute, bool isUpdate)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacDistribute/Valid/?UserName={UserName}&isUpdate={isUpdate}", currentDistribute);
            var responseContent = await response.Content.ReadFromJsonAsync<List<string>>();
            return responseContent;
        }

        public async Task<string> Create(DacDistributeModel distributeModel)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacDistribute/Create", distributeModel);
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacDistributeModel>>();
            return responseContent.Message;
        }

        public async Task<string> Delete(int DistributeId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/DacDistribute/{DistributeId}");
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }

        public async Task<string> DeleteSeri(List<DacDistributeToAgencyDetails> LstDeleteSeri)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacDistribute/DeleteSeri/", LstDeleteSeri);
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }

        public async Task<List<DacDistributeToAgencyDetails>> GetDetailByDistributeId(int DistributeId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<DacDistributeToAgencyDetails>>($"api/v1/DacDistribute/GetDetailByDistributeId/?DistributeId={DistributeId}");
            return response;
        }

        public async Task<string> GetMaxOrder()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/v1/DacDistribute/MaxOrder");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<DacDistributeModel>> GetPagingDistribute(PaginatedInputModel pagination)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacDistribute", pagination);
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacDistributeModel>>();
            if (responseContent.Code == "200" && responseContent.Data != null)
            {
                totalpage = responseContent.Pagination.PagesQuantity;
                return responseContent.Data.ToList();
            }
            else
            {
                totalpage = 1;
                return new List<DacDistributeModel>();
            }   
        }

        public async Task<List<DacDistributeModel>> GetPagingDistributeByUserName(PaginatedInputModel pagination, string UserName)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacDistribute/GetPagingDistributeByUserName/?UserName={UserName}", pagination);
            var responseContent = await response.Content.ReadFromJsonAsync<ResultApiModel<DacDistributeModel>>();
            if (responseContent.Code == "200" && responseContent.Data != null)
            {
                totalpage = responseContent.Pagination.PagesQuantity;
                return responseContent.Data.ToList();
            }
            else
            {
                totalpage = 1;
                return new List<DacDistributeModel>();
            }
        }

        public async Task<string> Save(DacDistributeModel distributeModel, bool IsUpdate)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/DacDistribute/Save/?IsUpdate={IsUpdate}", distributeModel);
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }

        public async Task<string> Update(DacDistributeModel distributeModel)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/DacDistribute", distributeModel);
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}
