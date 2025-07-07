using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacInsertToWarehouseDetailsCS
    {
        public List<DacInsertToWarehouseDetails> GetInsertDetails(int iInsertID, string sDistributorStoredProduceName)
        {
            List<DacInsertToWarehouseDetails> InsertToWarehouseDetailsCollection = new List<DacInsertToWarehouseDetails>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@InsertID", iInsertID);
            SqlDataReader reader = dacDb.ExecuteReader(sDistributorStoredProduceName);
            while (reader.Read())
            {
                DacInsertToWarehouseDetails InsertToWarehouseDetails = new DacInsertToWarehouseDetails();

                InsertToWarehouseDetails.Id = (long)reader["Id"];
                InsertToWarehouseDetails.InsertID = (int)reader["InsertID"];
                InsertToWarehouseDetails.DacCode = reader["DacCode"].ToString();
                InsertToWarehouseDetails.Status = Convert.ToByte(reader["Status"]);

                InsertToWarehouseDetailsCollection.Add(InsertToWarehouseDetails);
            }

            // Call Close when reading done
            reader.Close();

            return InsertToWarehouseDetailsCollection;
        }
        public bool Insert(DacInsertToWarehouseDetails InsertToWarehouseDetails, string sDistributorStoredProduceName)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@InsertID", InsertToWarehouseDetails.InsertID);
                dacDb.AddParameter("@DacCode", InsertToWarehouseDetails.DacCode);
                dacDb.AddParameter("@Status", InsertToWarehouseDetails.Status);

                dacDb.ExecuteNonQuery(sDistributorStoredProduceName);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(long iID, string sDistributorStoredProduceName)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", iID);

                dacDb.ExecuteNonQuery(sDistributorStoredProduceName);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //spDacInsertToWarehouseDetails_DeleteByDacCode
        public bool Delete(string sDacCode)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DacCode", sDacCode);

                dacDb.ExecuteNonQuery("spDacInsertToWarehouseDetails_DeleteByDacCode");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DacInsertToWarehouseDetails> GetInsertDetails(string sDacCode, string sDistributorStoredProduceName)
        {
            List<DacInsertToWarehouseDetails> InsertToWarehouseDetailsCollection = new List<DacInsertToWarehouseDetails>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@DacCode", sDacCode);
            SqlDataReader reader = dacDb.ExecuteReader(sDistributorStoredProduceName);
            while (reader.Read())
            {
                DacInsertToWarehouseDetails InsertToWarehouseDetails = new DacInsertToWarehouseDetails();

                InsertToWarehouseDetails.Id = (long)reader["Id"];
                InsertToWarehouseDetails.InsertID = (int)reader["InsertID"];
                InsertToWarehouseDetails.DacCode = reader["DacCode"].ToString();
                InsertToWarehouseDetails.Status = Convert.ToByte(reader["Status"]);

                InsertToWarehouseDetailsCollection.Add(InsertToWarehouseDetails);
            }

            // Call Close when reading done
            reader.Close();

            return InsertToWarehouseDetailsCollection;
        }

        public DataTable DacWarehouseTotal(string DacCode, string QRCode, DateTime FrDate, DateTime ToDate, 
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
                //dacDb.AddParameter("@LoginID", LoginID);

                 dataTable = dacDb.ExecuteDataTable("spDacWarehouse_Total");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        //spDacInsertToWarehouse_SelectByDacCode
        public DataTable DacWarehouseByDacCode(string DacCode)
        {
            DataTable dataTable = new DataTable();
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DacCode", DacCode);

                dataTable = dacDb.ExecuteDataTable("spDacInsertToWarehouse_SelectByDacCode");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public void PerformBulkCopy(DataTable dataTable, string[] sColumnName)
        {
            if (dataTable.Rows.Count > 0)
            {
                DacDbAccess dacDb = new DacDbAccess();
                try
                {
                    dacDb.PerformBulkCopy(dataTable, sColumnName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
