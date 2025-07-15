using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacDistributeToAgencyCS
    {
        public List<DacExport> GetListDistributeToAgency(DateTime FrDate, DateTime ToDate, string AgencyCode, string ProductCode, string LoginID)
        {
            List<DacExport> dacDistributeToAgencyCollection = new List<DacExport>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FrDate", FrDate);
            dacDb.AddParameter("@ToDate", ToDate);
            dacDb.AddParameter("@AgencyCode", AgencyCode);
            dacDb.AddParameter("@ProductCode", ProductCode);
            dacDb.AddParameter("@LoginID", LoginID);

            SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToAgency_Select");
            while (reader.Read())
            {
                DacExport dacDistributeToAgency = new DacExport();

                dacDistributeToAgency.Id = (int)reader["ID"];
                dacDistributeToAgency.OrderNumber = reader["OrderNumber"].ToString();
                dacDistributeToAgency.CreatedDate = (DateTime)reader["CreatedDate"];
                dacDistributeToAgency.CustomerCode = reader["AgencyCode"].ToString();
                dacDistributeToAgency.Quantity = (double)reader["Quantity"];
                dacDistributeToAgency.Description = reader["Description"].ToString();
                dacDistributeToAgency.Active = (bool)reader["Active"];

                dacDistributeToAgencyCollection.Add(dacDistributeToAgency);
            }

            // Call Close when reading done
            reader.Close();

            return dacDistributeToAgencyCollection;
        }
        public static string GetMaxOrderNumber()
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@Year", DateTime.Now.Year);
            int sMaxOrderNumber = Convert.ToInt32(dacDb.ExecuteScalar("spGetMaxOrderNumberAgency"));
            sMaxOrderNumber += 1;
            return String.Format("{0:00000}", sMaxOrderNumber);
        }
        public bool Insert(DacExport distributeToAgency, ref int iNewID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@OrderNumber", distributeToAgency.OrderNumber);
                dacDb.AddParameter("@CreatedDate", distributeToAgency.CreatedDate);
                dacDb.AddParameter("@AgencyCode", distributeToAgency.CustomerCode);
                dacDb.AddParameter("@Quantity", distributeToAgency.Quantity);
                dacDb.AddParameter("@Description", distributeToAgency.Description);
                dacDb.AddParameter("@Active", distributeToAgency.Active);
                dacDb.AddParameter("@NewID", SqlDbType.Int);
                if (dacDb.ExecuteNonQuery("spDacDistributeToAgency_Insert") > 0)
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
        public bool Update(DacExport distributeToAgency)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", distributeToAgency.Id);
                dacDb.AddParameter("@OrderNumber", distributeToAgency.OrderNumber);
                dacDb.AddParameter("@CreatedDate", distributeToAgency.CreatedDate);
                dacDb.AddParameter("@AgencyCode", distributeToAgency.CustomerCode);
                dacDb.AddParameter("@Quantity", distributeToAgency.Quantity);
                dacDb.AddParameter("@Description", distributeToAgency.Description);
                dacDb.AddParameter("@Active", distributeToAgency.Active);

                dacDb.ExecuteNonQuery("spDacDistributeToAgency_Update");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //spDacDistributeToAgency_UpdateQuantity
        public bool Update(int iID, double dQuantity)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", iID);
                dacDb.AddParameter("@Quantity", dQuantity);

                dacDb.ExecuteNonQuery("spDacDistributeToAgency_UpdateQuantity");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //spDacDistributeToAgency_UpdateActive
        public bool Update(int iID, bool bActive)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                dacDb.CreateNewSQL();
                // Add parameters
                dacDb.AddParameter("@ID", iID);
                dacDb.AddParameter("@Active", bActive);

                dacDb.ExecuteNonQuery("UPDATE dbo.DacDistributeToAgency SET Active = @Active WHERE ID = @ID");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int iID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", iID);

                dacDb.ExecuteNonQuery("spDacDistributeToAgency_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
