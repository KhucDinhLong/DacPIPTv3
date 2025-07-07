using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacDistributeToFactoryDetailsCS
    {
        //spDacDistributeToFactoryDetails_SelectByFactoryId (DistributorID)
        public List<DacDistributeToFactoryDetails> GetDistributeDetails(int iDistributorID)
        {
            List<DacDistributeToFactoryDetails> dacDistributeDetailsCollection = new List<DacDistributeToFactoryDetails>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@DistributorID", iDistributorID);
            SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToFactoryDetails_SelectByFactoryId");
            while (reader.Read())
            {
                DacDistributeToFactoryDetails dacDistributeDetails = new DacDistributeToFactoryDetails();

                dacDistributeDetails.ID = (long)reader["ID"];
                dacDistributeDetails.DistributorID = (int)reader["DistributorID"];
                dacDistributeDetails.DacCode = reader["DacCode"].ToString();
                dacDistributeDetails.ProductCode = reader["ProductCode"].ToString();

                dacDistributeDetailsCollection.Add(dacDistributeDetails);
            }

            // Call Close when reading done
            reader.Close();

            return dacDistributeDetailsCollection;
        }
        //spDacDistributeToFactoryDetails_SelectByDacCode (DacCode)
        public List<DacDistributeToFactoryDetails> GetDistributeDetails(string sDacCode)
        {
            List<DacDistributeToFactoryDetails> dacDistributeDetailsCollection = new List<DacDistributeToFactoryDetails>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@DacCode", sDacCode);
            SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToFactoryDetails_SelectByDacCode");
            while (reader.Read())
            {
                DacDistributeToFactoryDetails dacDistributeDetails = new DacDistributeToFactoryDetails();

                dacDistributeDetails.ID = (long)reader["ID"];
                dacDistributeDetails.DistributorID = (int)reader["DistributorID"];
                dacDistributeDetails.DacCode = reader["DacCode"].ToString();
                dacDistributeDetails.ProductCode = reader["ProductCode"].ToString();

                dacDistributeDetailsCollection.Add(dacDistributeDetails);
            }

            // Call Close when reading done
            reader.Close();

            return dacDistributeDetailsCollection;
        }
        //public DataTable DacDistributeToFactoryTotal(string DacCode, string QRCode, DateTime FrDate, DateTime ToDate,
        //                    string TenKH, string TenSP, string SoDT)
        //{
        //    DataTable dataTable = new DataTable();
        //    DacDbAccess dacDb = new DacDbAccess();
        //    try
        //    {
        //        dacDb.CreateNewSqlCommand();
        //        // Add parameters
        //        dacDb.AddParameter("@DacCode", DacCode);
        //        dacDb.AddParameter("@QRCode", QRCode);
        //        dacDb.AddParameter("@FrDate", FrDate);
        //        dacDb.AddParameter("@ToDate", ToDate);
        //        dacDb.AddParameter("@TenKH", TenKH);
        //        dacDb.AddParameter("@TenSP", TenSP);
        //        dacDb.AddParameter("@SoDT", SoDT);

        //        dataTable = dacDb.ExecuteDataTable("spDacDistributeToFactory_Total");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dataTable;
        //}
        //spDacDistributeToFactoryDetails_Insert (DistributorID, DacCode)
        public bool Insert(DacDistributeToFactoryDetails distributeDetails)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DistributorID", distributeDetails.DistributorID);
                dacDb.AddParameter("@DacCode", distributeDetails.DacCode);
                dacDb.AddParameter("@ProductCode", distributeDetails.ProductCode);

                dacDb.ExecuteNonQuery("spDacDistributeToFactoryDetails_Insert");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //spDacDistributeToAgencyDetails_Delete (ID)
        public bool Delete(long iID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", iID);

                dacDb.ExecuteNonQuery("spDacDistributeToFactoryDetails_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //spDacDistributeToAgencyDetails_DeleteByDacCode (DacCode)
        public bool Delete(string sDacCode)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DacCode", sDacCode);

                dacDb.ExecuteNonQuery("spDacDistributeToFactoryDetails_DeleteByDacCode");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
