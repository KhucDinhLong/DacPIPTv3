using DAC.Core;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PIPT.Agency
{
    public class ApiHelper
    {
        public HttpClient client = new HttpClient();
        public ApiHelper()
        {
            string sUri = System.Configuration.ConfigurationManager.AppSettings["BaseAddress"].ToString();
            client.BaseAddress = new Uri(sUri);
            client.DefaultRequestHeaders.Accept.Clear();
            var username = "apiadmin";
            var password = "85lYL1VtAjUhUv24faWHvA==";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #region Get Catalogue ApiController
        public async Task<DacProductCatalogueCollection> GetCatalogueAsync()
        {
            DacProductCatalogueCollection CatalogueCollection = new DacProductCatalogueCollection();
            using (HttpResponseMessage response = await client.GetAsync("api/catalogue"))
            {
                response.EnsureSuccessStatusCode();
                DacProductCatalogue[] Catalogues = await response.Content.ReadAsAsync<DacProductCatalogue[]>();
                CatalogueCollection.AddRange(Catalogues);
            }
            return CatalogueCollection;
        }
        public async Task<DacProductCatalogueCollection> GetCatalogueAsync(int Id)
        {
            DacProductCatalogueCollection CatalogueCollection = new DacProductCatalogueCollection();
            using (HttpResponseMessage response = await client.GetAsync("api/catalogue/" + Id))
            {
                response.EnsureSuccessStatusCode();
                DacProductCatalogue[] Catalogues = await response.Content.ReadAsAsync<DacProductCatalogue[]>();
                CatalogueCollection.AddRange(Catalogues);
            }
            return CatalogueCollection;
        }
        #endregion

        #region Get Product ApiController
        public async Task<DacProductCollection> GetProductAsync()
        {
            DacProductCollection ProductCollection = new DacProductCollection();
            using (HttpResponseMessage response = await client.GetAsync("api/product"))
            {
                response.EnsureSuccessStatusCode();
                DacProduct[] Products = await response.Content.ReadAsAsync<DacProduct[]>();
                //foreach(DacProduct Product in Products)
                //{
                //    ProductCollection.Add(Product);
                //}
                ProductCollection.AddRange(Products);
            }
            return ProductCollection;
        }

        public async Task<DacProductCollection> GetProductAsync(int Id)
        {
            DacProductCollection ProductCollection = new DacProductCollection();
            using (HttpResponseMessage response = await client.GetAsync("api/product/" + Id))
            {
                response.EnsureSuccessStatusCode();
                DacProduct[] Products = await response.Content.ReadAsAsync<DacProduct[]>();
                ProductCollection.AddRange(Products);
            }
            return ProductCollection;
        }

        public async Task<DacProductCollection> GetProductAsync(string Code)
        {
            DacProductCollection ProductCollection = new DacProductCollection();
            using (HttpResponseMessage response = await client.GetAsync("api/product?Code=" + Code))
            {
                response.EnsureSuccessStatusCode();
                DacProduct[] Products = await response.Content.ReadAsAsync<DacProduct[]>();
                ProductCollection.AddRange(Products);
            }
            return ProductCollection;
        }
        #endregion

        #region Get Agency ApiController
        public async Task<DacAgencyCollection> GetAgencyAsync(string Code)
        {
            DacAgencyCollection AgencyCollection = new DacAgencyCollection();
            using (HttpResponseMessage response = await client.GetAsync("api/agency?Code=" + Code))
            {
                response.EnsureSuccessStatusCode();
                DacAgency[] Catalogues = await response.Content.ReadAsAsync<DacAgency[]>();
                AgencyCollection.AddRange(Catalogues);
            }
            return AgencyCollection;
        }
        #endregion

        #region Store ApiController
        public async Task<Boolean> AddDistributeToStoreAsync(DAC.Core.Models.DacDistributeToStoreViewModel dacDistributeToStoreViewModel)
        {
            // Chuyển đối tượng thành Json
            var serializedStore = JsonConvert.SerializeObject(dacDistributeToStoreViewModel);
            // Định dạng nội dung Json String
            var content = new StringContent(serializedStore, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("api/store/distributeToStore", content);
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Boolean> UpdateDistributeToStoreAsync(DacDistributeToStore DistributeToStore)
        {
            // Chuyển đối tượng thành Json
            var serializedStore = JsonConvert.SerializeObject(DistributeToStore);
            // Định dạng nội dung Json String
            var content = new StringContent(serializedStore, Encoding.UTF8, "application/json");
            //string[] splits = DistributeToStore.ID.Split('-');
            //int iID = 5;
            //if(splits.Length > 1)
            //{
            //    iID = Convert.ToInt32(splits[1]);
            //}
            var result = await client.PutAsync($"api/store/distributeToStore", content);
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Boolean> DeleteDistributeToStoreAsync(string ID)
        {
            // Khi goi phuong thuc Delete, thi phai goi dung ten ham va tham so truyen vao URL
            var result = await client.DeleteAsync($"api/store/distributeToStore?ID={ID}");
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Boolean> AddDistributeToStoreDetailsAsync(DAC.Core.Models.DacStoreDetailsViewModel dacStoreDetailsViewModel)
        {
            // Chuyển đối tượng thành Json
            var serializedStoreDetails = JsonConvert.SerializeObject(dacStoreDetailsViewModel);
            // Định dạng nội dung Json String
            var content = new StringContent(serializedStoreDetails, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("api/store/storeDetails", content);
            if(result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Boolean> DeleteDistributeToStoreDetailsAsync(string DacCode)
        {
            var result = await client.DeleteAsync($"api/store/storeDetails?DacCode={DacCode}");
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Boolean> DeleteDistributeToStoreDetailsAsync(string DistID, string DacCode)
        {
            var result = await client.DeleteAsync($"api/store/storeDetails?DistID={DistID}&DacCode={DacCode}");
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<DacStoreCollection> GetStoreAsync(string AgencyCode)
        {
            DacStoreCollection StoreCollection = new DacStoreCollection();
            using (HttpResponseMessage response = await client.GetAsync($"api/store?AgencyCode={AgencyCode}"))
            {
                response.EnsureSuccessStatusCode();
                DacStore[] Stores = await response.Content.ReadAsAsync<DacStore[]>();
                StoreCollection.AddRange(Stores);
            }
            return StoreCollection;
        }
        public async Task<DacStoreCollection> GetStoreAsync(int ID, string AgencyCode)
        {
            DacStoreCollection StoreCollection = new DacStoreCollection();
            using (HttpResponseMessage response = await client.GetAsync($"api/store?ID={ID}&AgencyCode={AgencyCode}"))
            {
                response.EnsureSuccessStatusCode();
                DacStore[] Stores = await response.Content.ReadAsAsync<DacStore[]>();
                StoreCollection.AddRange(Stores);
            }
            return StoreCollection;
        }
        public async Task<Boolean> AddStoreAsync(DacStore store)
        {
            // Chuyển đối tượng thành Json
            var serializedStore = JsonConvert.SerializeObject(store);
            // Định dạng nội dung Json String
            var content = new StringContent(serializedStore, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("api/store", content);
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Boolean> UpdateStoreAsync(DacStore store)
        {
            // Chuyển đối tượng thành Json
            var serializedStore = JsonConvert.SerializeObject(store);
            // Định dạng nội dung Json String
            var content = new StringContent(serializedStore, Encoding.UTF8, "application/json");
            var result = await client.PutAsync($"api/store/{store.ID}", content);
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Boolean> DeleteStoreAsync(string Code, string AgencyCode)
        {
            // Khi goi phuong thuc Delete, thi phai goi dung ten ham va tham so truyen vao URL
            var result = await client.DeleteAsync($"api/store?Code={Code}&AgencyCode={AgencyCode}");
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Boolean> AddStoreAsync(DAC.Core.Models.DacStoreViewModel dacStoreViewModel)
        {
            // Chuyển đối tượng thành Json
            var serializedStore = JsonConvert.SerializeObject(dacStoreViewModel);
            // Định dạng nội dung Json String
            var content = new StringContent(serializedStore, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("api/store/storeCollection", content);
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
        #endregion
    }
}
