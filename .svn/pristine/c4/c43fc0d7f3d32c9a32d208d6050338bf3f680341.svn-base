using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PIPT
{
    public class ApiHelper
    {
        public HttpClient client = new HttpClient();
        public ApiHelper()
        {
            string sUri = "http://dacapi.temchonggia.com.vn/";
            // Link cho day serial bao hanh dien tu Fujiaire VN
            //string sUri = "http://quantri.fujiairemalaysia.com.vn/";
            // Test local Fujiaire VN
            //string sUri = "http://localhost:2910/";

            client.BaseAddress = new Uri(sUri);
            client.DefaultRequestHeaders.Accept.Clear();
            var username = "dacaudit";
            var password = "dacaudit";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region Product ApiController
        public async Task<Boolean> AddCustomerProductSeriAsync(DAC.Core.Models.CustomerProductSeriModel customerProductSeriModel)
        {
            // Chuyển đối tượng thành Json
            var productSeri = JsonConvert.SerializeObject(customerProductSeriModel);
            // Định dạng nội dung Json String
            var content = new StringContent(productSeri, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("api/productapi/productseri", content);
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Boolean> AddAgencyProductSeriAsync(DAC.Core.Models.CustomerProductSeriModel customerProductSeriModel)
        {
            // Chuyển đối tượng thành Json
            var productSeri = JsonConvert.SerializeObject(customerProductSeriModel);
            // Định dạng nội dung Json String
            var content = new StringContent(productSeri, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("api/productapi/agencyProductSeri", content);
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        #endregion
    }
}
