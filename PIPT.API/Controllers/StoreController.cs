using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using DAC.Core;
using System.Data;

namespace PIPT.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/store")]
    public class StoreController : ApiController
    {
        DacDistributeToStoreCS distributeToStoreCS = new DacDistributeToStoreCS();
        DacDistributeToStoreDetailsCS distributeToStoreDetailsCS = new DacDistributeToStoreDetailsCS();
        DacStoreCS StoreCS = new DacStoreCS();
        #region Distribute to Store
        [HttpPost]
        [AllowAnonymous]
        [Route("distributeToStore")]
        // Chấp nhận URL dạng api/store/distributeToStore/objData
        public IHttpActionResult CreateDistributeToStore(JObject objData)
        {
            List<DacDistributeToStoreDetails> distributeDetails = new List<DacDistributeToStoreDetails>();
            dynamic jsonData = objData;
            JObject dacDistributeToStoreJson = jsonData.DacDistributeToStore;
            JArray dacDistributeDetailsJson = jsonData.StoreDetailsCollection;

            var DacDistributeToStore = dacDistributeToStoreJson.ToObject<DacDistributeToStore>();
            if (distributeToStoreCS.Insert(DacDistributeToStore))
            {
                foreach (var detail in dacDistributeDetailsJson)
                {
                    DacDistributeToStoreDetails _DacDistributeDetails = detail.ToObject<DacDistributeToStoreDetails>();
                    _DacDistributeDetails.DistributorID = DacDistributeToStore.ID;
                    distributeDetails.Add(_DacDistributeDetails);
                }
                DataTable dataTable = CommonCore.GetDataTable(distributeDetails, typeof(DacDistributeToStoreDetails));
                dataTable.TableName = "DacDistributeToStoreDetails"; // Ten bang trong CSDL
                // Khai bao mang cac cot trong bang du lieu can mapping
                string[] sColumnName = new string[] { "DistributorID", "DacCode", "ProductCode" };
                CommonCore.PerformBulkCopy(dataTable, sColumnName);
            }
            return Ok();
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("distributeToStore")]
        // Chấp nhận URL dạng api/store/distributeToStore/ID (ID int)
        public IHttpActionResult UpdateDistributeToStore(JObject objData)
        {
            dynamic jsonData = objData;
            var DistributeToStore = jsonData.ToObject<DacDistributeToStore>();
            DacDistributeToStoreCS DistributeToStoreCS = new DacDistributeToStoreCS();
            if (DistributeToStoreCS.Update(DistributeToStore))
                return Ok();
            return NotFound();
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("distributeToStore")]
        // Chấp nhận URL dạng api/store/distributeToStore?ID=_ID
        public IHttpActionResult DeleteDistributeToStore(string ID)
        {
            DacDistributeToStoreCS DistributeToStoreCS = new DacDistributeToStoreCS();
            if (DistributeToStoreCS.Delete(ID))
                return Ok();
            return NotFound();
        }
        #endregion
        #region Create | Delete DistributeToStoreDetails
        [HttpPost]
        [AllowAnonymous]
        // Chấp nhận URL dạng api/store/storeDetails/objData
        [Route("storeDetails")]
        public IHttpActionResult CreateStoreDetails(JObject objData)
        {
            dynamic jsonData = objData;
            JArray storeDetailsJson = jsonData.StoreDetailsCollection;
            DacDistributeToStoreDetailsCollection StoreDetailsCollection = new DacDistributeToStoreDetailsCollection();
            foreach(var storeDetails in storeDetailsJson)
            {
                StoreDetailsCollection.Add(storeDetails.ToObject<DacDistributeToStoreDetails>());
            }
            DataTable dataTable = CommonCore.GetDataTable(StoreDetailsCollection, typeof(DacDistributeToStoreDetails));
            dataTable.TableName = "DacDistributeToStoreDetails"; // Ten bang trong CSDL
            // Khai bao mang cac cot trong bang du lieu can mapping
            string[] sColumnName = new string[] { "DistributorID", "DacCode", "ProductCode" };
            try
            {
                CommonCore.PerformBulkCopy(dataTable, sColumnName);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("storeDetails")]
        // Chấp nhận URL dạng api/store/storeDetails?DistID=_DistID&DacCode=_DacCode
        public IHttpActionResult DeleteStoreDetails(string DistID, string DacCode)
        {
            DacDistributeToStoreDetailsCS StoreDetailsCS = new DacDistributeToStoreDetailsCS();
            if (StoreDetailsCS.Delete(DistID, DacCode))
                return Ok();
            return NotFound();
        }
        [HttpDelete]
        [AllowAnonymous]
        [Route("storeDetails")]
        // Chấp nhận URL dạng api/store/storeDetails?DacCode=_DacCode
        public IHttpActionResult DeleteStoreDetails(string DacCode)
        {
            DacDistributeToStoreDetailsCS StoreDetailsCS = new DacDistributeToStoreDetailsCS();
            if (StoreDetailsCS.Delete(DacCode))
                return Ok();
            return NotFound();
        }
        #endregion
        #region Stores
        [AllowAnonymous]
        // Chấp nhận URL dạng api/store?AgencyCode=AgencyCode
        public DacStoreCollection Get(string AgencyCode)
        {
            return StoreCS.GetListStore(AgencyCode);
        }

        [AllowAnonymous]
        // Chấp nhận URL dạng api/store?ID=ID&AgencyCode=AgencyCode
        public DacStoreCollection Get(int ID, string AgencyCode)
        {
            return StoreCS.GetListStore(ID, AgencyCode);
        }

        [HttpPost]
        [AllowAnonymous]
        // Chấp nhận URL dạng api/store/objData
        public IHttpActionResult CreateStore(JObject objData)
        {
            dynamic jsonData = objData;
            var DacStore = jsonData.ToObject<DacStore>();
            DacStoreCS StoreCS = new DacStoreCS();
            if (StoreCS.Insert(DacStore))
                return Ok();
            return NotFound();
        }

        [HttpPut]
        [AllowAnonymous]
        // Chấp nhận URL dạng api/store/ID (ID int)
        public IHttpActionResult UpdateStore(JObject objData)
        {
            dynamic jsonData = objData;
            var DacStore = jsonData.ToObject<DacStore>();
            DacStoreCS StoreCS = new DacStoreCS();
            if (StoreCS.Update(DacStore))
                return Ok();
            return NotFound();
        }

        [HttpDelete]
        [AllowAnonymous]
        // Chấp nhận URL dạng api/store/DeleteStore?Code=_Code&AgencyCode=_AgencyCode
        public IHttpActionResult DeleteStore(string Code, string AgencyCode)
        {
            //dynamic jsonData = objData;
            //DacStore dacStore = jsonData.ToObject<DacStore>();
            DacStoreCS StoreCS = new DacStoreCS();
            if (StoreCS.Delete(Code, AgencyCode))
                return Ok();
            return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("storeCollection")]
        // Chấp nhận URL dạng api/store/storeCollection/objData
        public IHttpActionResult CreateStores(JObject objData)
        {
            dynamic jsonData = objData;
            JArray storesJson = jsonData.DacStoreCollection;
            DacStoreCollection stores = new DacStoreCollection();
            foreach(var store in storesJson)
            {
                stores.Add(store.ToObject<DacStore>());
            }
            DataTable dataTable = CommonCore.GetDataTable(stores, typeof(DacStore));
            dataTable.TableName = "DacStore";
            // Khai bao mang cac cot trong bang du lieu can mapping
            string[] sColumnName = new string[] { "ID", "Code", "Name", "Address", "ShopKeeper", "PhoneNum", "MobileNum", "Email", "AgencyCode", "ProvinceCode", "Description", "CreatedDate", "Active" };
            try
            {
                CommonCore.PerformBulkCopy(dataTable, sColumnName);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
        #endregion
    }
}
