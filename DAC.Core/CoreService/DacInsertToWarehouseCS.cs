using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacInsertToWarehouseCS
    {
        public List<DacInsertToWarehouse> GetListInsertToWarehouse(DateTime FrDate, DateTime ToDate,  string ProductCode, string LoginID)
        {
            List<DacInsertToWarehouse> dacInsertToWarehouseCollection = new List<DacInsertToWarehouse>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FrDate", FrDate);
            dacDb.AddParameter("@ToDate", ToDate);
            dacDb.AddParameter("@ProductCode", ProductCode);
            dacDb.AddParameter("@LoginID", LoginID);

            SqlDataReader reader = dacDb.ExecuteReader("spDacInsertToWarehouse_Select");
            while (reader.Read())
            {
                DacInsertToWarehouse InsertToWarehouse = new DacInsertToWarehouse();

                InsertToWarehouse.Id = (int)reader["Id"];
                InsertToWarehouse.InsertNumber = reader["InsertNumber"].ToString();
                InsertToWarehouse.CreatedDate = (DateTime)reader["CreatedDate"];
                InsertToWarehouse.ProductCode = reader["ProductCode"].ToString();
                InsertToWarehouse.Quantity = (Int32)reader["Quantity"];
                InsertToWarehouse.Description = reader["Description"].ToString();
                InsertToWarehouse.StockCode = reader["StockID"].ToString();
                InsertToWarehouse.Active = (bool)reader["Active"];

                dacInsertToWarehouseCollection.Add(InsertToWarehouse);
            }

            // Call Close when reading done
            reader.Close();

            return dacInsertToWarehouseCollection;
        }
        public static string GetMaxInsertNumber()
        {
            string sInsertNumber = string.Empty;
            SecConfig secConfig = CommonBO.GetSecConfig("AutoIncreaseWarehouse");
            if (secConfig.Value == "true")
            {
                DacDbAccess dacDb = new DacDbAccess();
                dacDb.CreateNewSqlCommand();
                dacDb.AddParameter("@Year", DateTime.Now.Year);
                int sMaxOrderNumber = Convert.ToInt32(dacDb.ExecuteScalar("spGetMaxInsertNumberWarehouse"));
                sMaxOrderNumber += 1;
                sInsertNumber = String.Format("{0:00000}", sMaxOrderNumber);
            }
            return sInsertNumber;
        }

        public bool Update(DacInsertToWarehouse InsertToWarehouse)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", InsertToWarehouse.Id);
                dacDb.AddParameter("@InsertNumber", InsertToWarehouse.InsertNumber);
                dacDb.AddParameter("@CreatedDate", InsertToWarehouse.CreatedDate);
                dacDb.AddParameter("@ProductCode", InsertToWarehouse.ProductCode);
                dacDb.AddParameter("@Quantity", InsertToWarehouse.Quantity);
                dacDb.AddParameter("@Description", InsertToWarehouse.Description);
                dacDb.AddParameter("@StockID", InsertToWarehouse.StockCode);
                dacDb.AddParameter("@Active", InsertToWarehouse.Active);

                dacDb.ExecuteNonQuery("spDacInsertToWarehouse_Update");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(int ID, bool IsActive)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", ID);
                dacDb.AddParameter("@IsActive", IsActive);

                dacDb.ExecuteNonQuery("spDacInsertToWarehouse_UpdateStatus");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert(DacInsertToWarehouse InsertToWarehouse, ref int iNewID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@InsertNumber", InsertToWarehouse.InsertNumber);
                dacDb.AddParameter("@CreatedDate", InsertToWarehouse.CreatedDate);
                dacDb.AddParameter("@ProductCode", InsertToWarehouse.ProductCode);
                dacDb.AddParameter("@Quantity", InsertToWarehouse.Quantity);
                dacDb.AddParameter("@Description", InsertToWarehouse.Description);
                dacDb.AddParameter("@StockID", InsertToWarehouse.StockCode);
                dacDb.AddParameter("@Active", InsertToWarehouse.Active);
                dacDb.AddParameter("@NewID", SqlDbType.Int);
                if (dacDb.ExecuteNonQuery("spDacInsertToWarehouse_Insert") > 0)
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

        public bool CheckPackage(string sPackageCode)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSQL();
                // Add parameters
                dacDb.AddParameter("@PackageCode", sPackageCode);
                SqlDataReader reader = dacDb.ExecuteReader("SELECT * FROM [dbo].[DacInsertToWarehouse] WHERE [Description] like N'%' + @PackageCode + '%'");
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DacDbConnection.Close();
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

                dacDb.ExecuteNonQuery("spDacInsertToWarehouse_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime GetCreateDate(string DacCode)
        {
            DateTime CreateDate = new DateTime();
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSQL();
                // Add parameters
                dacDb.AddParameter("@DacCode", DacCode);
                SqlDataReader reader = dacDb.ExecuteReader("SELECT a.CreatedDate FROM [dbo].[DacInsertToWarehouse] a " +
                    "INNER JOIN [dbo].[DacInsertToWarehouseDetails] b ON a.ID = b.InsertID " +
                    "WHERE b.[DacCode] = @DacCode");
                if (reader.Read())
                {
                    CreateDate = DateTime.Parse(reader["CreatedDate"].ToString());
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DacDbConnection.Close();
            }
            return CreateDate;
        }
    }
}
