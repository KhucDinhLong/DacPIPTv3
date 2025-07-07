using PIPTWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Services
{
    public interface ISecConfigService
    {
        Task<List<SecConfig>> GetConfigByCustomerIdAsync(int CustomerId);
        List<SecConfig> GetConfigByCustomerId(int CustomerId);
    }
    public class SecConfigService : ISecConfigService
    {
        private readonly HttpClient _httpClient;
        public SecConfigService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<SecConfig> GetConfigByCustomerId(int CustomerId)
        {
            var response = _httpClient.GetFromJsonAsync<List<SecConfig>>($"api/v1/SecConfig/GetByCustomerId/?CustomerId={CustomerId}");
            return response.Result;
        }

        public async Task<List<SecConfig>> GetConfigByCustomerIdAsync(int CustomerId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<SecConfig>>($"api/v1/SecConfig/GetByCustomerId/?CustomerId={CustomerId}");
            return response;
        }
    }
}
