using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacDistributeToStoreCS
    {
        public List<DacDistributeToStore> GetListDistributeToStore(DateTime FrDate, DateTime ToDate, string StoreCode, string ProductCode, string LoginID, string AgencyCode)
        {
            List<DacDistributeToStore> dacDistributeToStoreCollection = new List<DacDistributeToStore>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FrDate", FrDate);
            dacDb.AddParameter("@ToDate", ToDate);
            dacDb.AddParameter("@StoreCode", StoreCode);
            dacDb.AddParameter("@ProductCode", ProductCode);
            dacDb.AddParameter("@LoginID", LoginID);
            dacDb.AddParameter("@AgencyCode", AgencyCode);

            SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToStore_Select");
            while (reader.Read())
            {
                DacDistributeToStore dacDistributeToStore = new DacDistributeToStore();

                dacDistributeToStore.Id = int.Parse(reader["Id"].ToString());
                dacDistributeToStore.OrderNumber = reader["OrderNumber"].ToString();
                dacDistributeToStore.CreatedDate = (DateTime)reader["CreatedDate"];
                dacDistributeToStore.StoreCode = reader["StoreCode"].ToString();
                dacDistributeToStore.Quantity = (double)reader["Quantity"];
                dacDistributeToStore.Description = reader["Description"].ToString();
                dacDistributeToStore.Active = (bool)reader["Active"];

                dacDistributeToStoreCollection.Add(dacDistributeToStore);
            }

            // Call Close when reading done
            reader.Close();

            return dacDistributeToStoreCollection;
        }

        public DacDistributeToStore GetDistributeToStore(string sID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            DacDistributeToStore dacDistributeToStore = new DacDistributeToStore();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", sID);

                SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToStore_SelectID");
                if (reader.Read())
                {
                    dacDistributeToStore.Id = int.Parse(reader["Id"].ToString());
                    dacDistributeToStore.OrderNumber = reader["OrderNumber"].ToString();
                    dacDistributeToStore.CreatedDate = (DateTime)reader["CreatedDate"];
                    dacDistributeToStore.StoreCode = reader["StoreCode"].ToString();
                    dacDistributeToStore.Quantity = (double)reader["Quantity"];
                    dacDistributeToStore.Description = reader["Description"].ToString();
                    dacDistributeToStore.Active = (bool)reader["Active"];
                }

                // Call Close when reading done
                reader.Close();

                return dacDistributeToStore;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetMaxOrderNumber()
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@Year", DateTime.Now.Year);
            int sMaxOrderNumber = Convert.ToInt32(dacDb.ExecuteScalar("spGetMaxOrderNumberStore"));
            sMaxOrderNumber += 1;
            return String.Format("{0:00000}", sMaxOrderNumber);
        }

        public string GetAgencyCodeByStoreCode(string StoreCode)
        {
            string AgencyCode = string.Empty;
            DacStoreCS StoreCS = new DacStoreCS();
            List<DacStore> StoreCollection = StoreCS.GetListStore(StoreCode, string.Empty, string.Empty);
            if(StoreCollection.Count > 0)
            {
                AgencyCode = StoreCollection[0].AgencyCode;
            }
            return AgencyCode;
        }

        /// <summary>
        /// Get ID Max from PIPT Agency
        /// </summary>
        /// <returns></returns>
        public static string GetMaxID(string AgencyCode)
        {
            if(AgencyCode.Length > 10)
            {
                AgencyCode = AgencyCode.Substring(0, 10);
            }
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@AgencyCode", AgencyCode);
            var MaxID = dacDb.ExecuteScalar("spGetMaxDistributeToStoreID");
            // Dinh dang ID nhu sau AgencyCode-0000000001
            if (MaxID != null)
            {
                string[] sNumberSplit = MaxID.ToString().Split('-');
                int iID = Convert.ToInt32(sNumberSplit[1]) + 1;
                return String.Format("{0}-{1:0000000000}", AgencyCode, iID);
            }
            else
                return String.Format("{0}-0000000001", AgencyCode);
        }

        public bool Insert(DacDistributeToStore distributeToStore, ref int iNewID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@OrderNumber", distributeToStore.OrderNumber);
                dacDb.AddParameter("@CreatedDate", distributeToStore.CreatedDate);
                dacDb.AddParameter("@StoreCode", distributeToStore.StoreCode);
                dacDb.AddParameter("@Quantity", distributeToStore.Quantity);
                dacDb.AddParameter("@Description", distributeToStore.Description);
                dacDb.AddParameter("@Active", distributeToStore.Active);
                dacDb.AddParameter("@NewID", SqlDbType.Int);

                if (dacDb.ExecuteNonQuery("spDacDistributeToStore_Insert") > 0)
                {
                    iNewID = Convert.ToInt32(dacDb.sqlCommand.Parameters["@NewID"].Value);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(DacDistributeToStore distributeToStore)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@Id", distributeToStore.Id);
                dacDb.AddParameter("@OrderNumber", distributeToStore.OrderNumber);
                dacDb.AddParameter("@CreatedDate", distributeToStore.CreatedDate);
                dacDb.AddParameter("@StoreCode", distributeToStore.StoreCode);
                dacDb.AddParameter("@Quantity", distributeToStore.Quantity);
                dacDb.AddParameter("@Description", distributeToStore.Description);
                dacDb.AddParameter("@Active", distributeToStore.Active);

                dacDb.ExecuteNonQuery("spDacDistributeToStore_Update");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //spDacDistributeToAgency_UpdateQuantity
        public bool Update(int? iID, double dQuantity)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@Id", iID);
                dacDb.AddParameter("@Quantity", dQuantity);

                dacDb.ExecuteNonQuery("spDacDistributeToStore_UpdateQuantity");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int sID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@Id", sID);

                dacDb.ExecuteNonQuery("spDacDistributeToStore_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
