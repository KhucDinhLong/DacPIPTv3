using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacDistributeToFactoryCS
    {
        public List<DacExport1> GetListDistributeToFactory(DateTime FrDate, DateTime ToDate, string FactoryCode, string ProductCode)
        {
            List<DacExport1> dacDistributeToFactoryCollection = new List<DacExport1>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FrDate", FrDate);
            dacDb.AddParameter("@ToDate", ToDate);
            dacDb.AddParameter("@FactoryCode", FactoryCode);
            dacDb.AddParameter("@ProductCode", ProductCode);
            SqlDataReader reader = dacDb.ExecuteReader("spDacDistributeToFactory_Select");
            while (reader.Read())
            {
                DacExport1 dacDistributeToFactory = new DacExport1();

                dacDistributeToFactory.Id = (int)reader["ID"];
                dacDistributeToFactory.OrderNumber = reader["OrderNumber"].ToString();
                dacDistributeToFactory.CreatedDate = (DateTime)reader["CreatedDate"];
                dacDistributeToFactory.CustomerCode = reader["CustomerCode"].ToString();
                dacDistributeToFactory.Quantity = (double)reader["Quantity"];
                dacDistributeToFactory.Description = reader["Description"].ToString();
                dacDistributeToFactory.Active = (bool)reader["Active"];

                dacDistributeToFactoryCollection.Add(dacDistributeToFactory);
            }

            // Call Close when reading done
            reader.Close();

            return dacDistributeToFactoryCollection;
        }
        public static string GetMaxOrderNumber()
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@Year", DateTime.Now.Year);
            int sMaxOrderNumber = Convert.ToInt32(dacDb.ExecuteScalar("spGetMaxOrderNumberFactory"));
            sMaxOrderNumber += 1;
            return String.Format("{0:00000}", sMaxOrderNumber);
        }
        public bool Insert(DacExport1 distributeToFactory, ref int iNewID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@OrderNumber", distributeToFactory.OrderNumber);
                dacDb.AddParameter("@CreatedDate", distributeToFactory.CreatedDate);
                dacDb.AddParameter("@ProvinceCode", distributeToFactory.CustomerCode);
                dacDb.AddParameter("@Quantity", distributeToFactory.Quantity);
                dacDb.AddParameter("@Description", distributeToFactory.Description);
                dacDb.AddParameter("@Active", distributeToFactory.Active);
                dacDb.AddParameter("@NewID", SqlDbType.Int);
                if (dacDb.ExecuteNonQuery("spDacDistributeToFactory_Insert") > 0)
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
        public bool Update(DacExport1 distributeToFactory)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", distributeToFactory.Id);
                dacDb.AddParameter("@OrderNumber", distributeToFactory.OrderNumber);
                dacDb.AddParameter("@CreatedDate", distributeToFactory.CreatedDate);
                dacDb.AddParameter("@ProvinceCode", distributeToFactory.CustomerCode);
                dacDb.AddParameter("@Quantity", distributeToFactory.Quantity);
                dacDb.AddParameter("@Description", distributeToFactory.Description);
                dacDb.AddParameter("@Active", distributeToFactory.Active);

                dacDb.ExecuteNonQuery("spDacDistributeToFactory_Update");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //spDacDistributeToFactory_UpdateQuantity
        public bool Update(int iID, double dQuantity)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", iID);
                dacDb.AddParameter("@Quantity", dQuantity);

                dacDb.ExecuteNonQuery("spDacDistributeToFactory_UpdateQuantity");
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

                dacDb.ExecuteNonQuery("spDacDistributeToFactory_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
