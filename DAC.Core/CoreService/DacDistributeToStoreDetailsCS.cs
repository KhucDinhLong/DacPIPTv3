using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacDistributeToStoreDetailsCS
    { 
        //spDacDistributeToStoreDetails_SelectByID (DistributorID)
        public DacExportDetail2 GetDistributeDetails(long lID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@ID", lID);
            SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToStoreDetails_SelectByID");
            DacExportDetail2 dacDistributeDetails = new DacExportDetail2();
            if (reader.Read())
            {
                dacDistributeDetails.Id = (long)reader["Id"];
                dacDistributeDetails.ExportId = (int) reader["DistributeToStoreId"];
                dacDistributeDetails.DacCode = reader["DacCode"].ToString();
                dacDistributeDetails.ProductCode = reader["ProductCode"].ToString();
            }

            // Call Close when reading done
            reader.Close();

            return dacDistributeDetails;
        }
        //spDacDistributeToStoreDetails_SelectByStoreId (DistributorID)
        public List<DacExportDetail2> GetDistributeDetails(int DistributeToStoreId)
        {
            List<DacExportDetail2> dacDistributeDetailsCollection = new List<DacExportDetail2>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@DistributeToStoreId", DistributeToStoreId);
            SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToStoreDetails_SelectByStoreId");
            while (reader.Read())
            {
                DacExportDetail2 dacDistributeDetails = new DacExportDetail2();

                dacDistributeDetails.Id = (long)reader["Id"];
                dacDistributeDetails.ExportId = (int) reader["DistributeToStoreId"];
                dacDistributeDetails.DacCode = reader["DacCode"].ToString();
                dacDistributeDetails.ProductCode = reader["ProductCode"].ToString();

                dacDistributeDetailsCollection.Add(dacDistributeDetails);
            }

            // Call Close when reading done
            reader.Close();

            return dacDistributeDetailsCollection;
        }
        //spDacDistributeToStoreDetails_SelectByDacCode (DacCode)
        public List<DacExportDetail2> GetDistributeDetailsByDacCode(string sDacCode)
        {
            List<DacExportDetail2> dacDistributeDetailsCollection = new List<DacExportDetail2>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@DacCode", sDacCode);
            SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToStoreDetails_SelectByDacCode");
            while (reader.Read())
            {
                DacExportDetail2 dacDistributeDetails = new DacExportDetail2();

                dacDistributeDetails.Id = (long)reader["Id"];
                dacDistributeDetails.ExportId = (int) reader["DistributeToStoreId"];
                dacDistributeDetails.DacCode = reader["DacCode"].ToString();
                dacDistributeDetails.ProductCode = reader["ProductCode"].ToString();

                dacDistributeDetailsCollection.Add(dacDistributeDetails);
            }

            // Call Close when reading done
            reader.Close();

            return dacDistributeDetailsCollection;
        }
        //spDacDistributeToStoreDetails_Insert (DistributorID, DacCode)
        public bool Insert(DacExportDetail2 distributeDetails)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DistributeToStoreId", distributeDetails.ExportId);
                dacDb.AddParameter("@DacCode", distributeDetails.DacCode); 
                dacDb.AddParameter("@ProductCode", distributeDetails.ProductCode);

                dacDb.ExecuteNonQuery("spDacDistributeToStoreDetails_Insert");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //spDacDistributeToStoreDetails_Delete (ID)
        public bool Delete(long iID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", iID);

                dacDb.ExecuteNonQuery("spDacDistributeToStoreDetails_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //spDacDistributeToStoreDetails_DeleteByDacCode (DacCode)
        public bool Delete(string sDacCode)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DacCode", sDacCode);

                dacDb.ExecuteNonQuery("spDacDistributeToStoreDetails_DeleteByDacCode");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //spDacDistributeToStoreDetails_DeleteByDisIDCode (DistributorID, DacCode)
        public bool Delete(string sDistributorID, string sDacCode)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DistributorID", sDistributorID);
                dacDb.AddParameter("@DacCode", sDacCode);

                dacDb.ExecuteNonQuery("spDacDistributeToStoreDetails_DeleteByDisIDCode");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
