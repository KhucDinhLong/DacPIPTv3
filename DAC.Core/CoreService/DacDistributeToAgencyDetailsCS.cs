using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacDistributeToAgencyDetailsCS
    {
        //spDacDistributeToAgencyDetails_SelectByAgencyId (DistributorID)
        public List<DacDistributeToAgencyDetails> GetDistributeDetails(int iDistributorID)
        {
            List<DacDistributeToAgencyDetails> dacDistributeDetailsCollection = new List<DacDistributeToAgencyDetails>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@DistributorID", iDistributorID);
            SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToAgencyDetails_SelectByAgencyId");
            while (reader.Read())
            {
                DacDistributeToAgencyDetails dacDistributeDetails = new DacDistributeToAgencyDetails();

                dacDistributeDetails.Id = (long)reader["ID"];
                dacDistributeDetails.DistributeToAgencyId = (int)reader["DistributeToAgencyId"];
                dacDistributeDetails.DacCode = reader["DacCode"].ToString();
                dacDistributeDetails.ProductCode = reader["ProductCode"].ToString();

                dacDistributeDetailsCollection.Add(dacDistributeDetails);
            }

            // Call Close when reading done
            reader.Close();

            return dacDistributeDetailsCollection;
        }
        //spDacDistributeToAgencyDetails_SelectByDacCode (DacCode)
        public List<DacDistributeToAgencyDetails> GetDistributeDetails(string sDacCode)
        {
            List<DacDistributeToAgencyDetails> dacDistributeDetailsCollection = new List<DacDistributeToAgencyDetails>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@DacCode", sDacCode);
            SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToAgencyDetails_SelectByDacCode");
            while (reader.Read())
            {
                DacDistributeToAgencyDetails dacDistributeDetails = new DacDistributeToAgencyDetails();

                dacDistributeDetails.Id = (long)reader["ID"];
                dacDistributeDetails.DistributeToAgencyId = (int)reader["DistributeToAgencyId"];
                dacDistributeDetails.DacCode = reader["DacCode"].ToString();
                dacDistributeDetails.ProductCode = reader["ProductCode"].ToString();

                dacDistributeDetailsCollection.Add(dacDistributeDetails);
            }

            // Call Close when reading done
            reader.Close();

            return dacDistributeDetailsCollection;
        }
        public DataTable DacDistributeToAgencyTotal(string DacCode, string QRCode, DateTime FrDate, DateTime ToDate,
                            string TenKH, string TenSP, string SoDT, string LoginID)
        {
            DataTable dataTable = new DataTable();
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DacCode", DacCode);
                dacDb.AddParameter("@QRCode", QRCode);
                dacDb.AddParameter("@FrDate", FrDate);
                dacDb.AddParameter("@ToDate", ToDate);
                dacDb.AddParameter("@TenKH", TenKH);
                dacDb.AddParameter("@TenSP", TenSP);
                dacDb.AddParameter("@SoDT", SoDT);
                dacDb.AddParameter("@LoginID", LoginID);

                dataTable = dacDb.ExecuteDataTable("spDacDistributeToAgency_Total");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }
        public DataTable DacDistributeToAgencyCusSMS(string DacCode, string QRCode, DateTime FrDate, DateTime ToDate,
                            string TenKH, string TenSP, string SoDT)
        {
            DataTable dataTable = new DataTable();
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DacCode", DacCode);
                dacDb.AddParameter("@QRCode", QRCode);
                dacDb.AddParameter("@FrDate", FrDate);
                dacDb.AddParameter("@ToDate", ToDate);
                dacDb.AddParameter("@TenKH", TenKH);
                dacDb.AddParameter("@TenSP", TenSP);
                dacDb.AddParameter("@SoDT", SoDT);

                dataTable = dacDb.ExecuteDataTable("spDacDistributeToAgency_CusSMS");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }
        //spDacDistributeToAgencyDetails_Insert (DistributorID, DacCode)
        public bool Insert(DacDistributeToAgencyDetails distributeDetails)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DistributorID", distributeDetails.DistributeToAgencyId);
                dacDb.AddParameter("@DacCode", distributeDetails.DacCode);
                dacDb.AddParameter("@ProductCode", distributeDetails.ProductCode);

                dacDb.ExecuteNonQuery("spDacDistributeToAgencyDetails_Insert");
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

                dacDb.ExecuteNonQuery("spDacDistributeToAgencyDetails_Delete");
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

                dacDb.ExecuteNonQuery("spDacDistributeToAgencyDetails_DeleteByDacCode");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
