using DAC.Core.CoreLogic;
using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Core.CoreService
{
    public class DacInventoryCS
    {
        public List<DacInventory> ListAllInventory()
        {
            List<DacInventory> dacInventoryCollection = new List<DacInventory>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            SqlDataReader reader = dacDb.ExecuteReader("spDacInventory_SelectAll");

            while (reader.Read())
            {
                DacInventory dacInventory = new DacInventory();
                dacInventory.Id = (int)reader["Id"];
                dacInventory.ProductCode = reader["ProductCode"].ToString();
                dacInventory.Quantity = reader["Quantity"] != null ? int.Parse(reader["Quantity"].ToString()) : 0;
                dacInventory.Year = reader["Year"] != null ? int.Parse(reader["Year"].ToString()) : 0;
                dacInventory.StockId = reader["StockID"].ToString();
                dacInventory.ProductName = reader["ProductName"].ToString();
                dacInventory.StockName = reader["StockName"].ToString();
                dacInventoryCollection.Add(dacInventory);
            }

            //Call Close when reading done.
            reader.Close();

            return dacInventoryCollection;
        }

        public List<DacInventory> ListAllInventoryHasStock()
        {
            List<DacInventory> dacInventoryCollection = new List<DacInventory>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            SqlDataReader reader = dacDb.ExecuteReader("spDacInventory_SelectAll_Has_Stock");

            while (reader.Read())
            {
                DacInventory dacInventory = new DacInventory();
                dacInventory.Id = (int)reader["Id"];
                dacInventory.ProductCode = reader["ProductCode"].ToString();
                dacInventory.Quantity = reader["Quantity"] != null ? int.Parse(reader["Quantity"].ToString()) : 0;
                dacInventory.Year = reader["Year"] != null ? int.Parse(reader["Year"].ToString()) : 0;
                dacInventory.StockId = reader["StockID"].ToString();
                dacInventory.ProductName = reader["ProductName"].ToString();
                dacInventory.StockName = reader["StockName"].ToString();
                dacInventoryCollection.Add(dacInventory);
            }

            //Call Close when reading done.
            reader.Close();

            return dacInventoryCollection;
        }

        public DacInventory GetInventoryByID(int ID)
        {
            DacInventory dacInventory = new DacInventory();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            SqlDataReader reader = dacDb.ExecuteReader("spDacInventory_Select_By_ID");

            while (reader.Read())
            {
                dacInventory.Id = (int)reader["Id"];
                dacInventory.ProductCode = reader["ProductCode"].ToString();
                dacInventory.Quantity = reader["Quantity"] != null ? int.Parse(reader["Quantity"].ToString()) : 0;
                dacInventory.Year = reader["Year"] != null ? int.Parse(reader["Year"].ToString()) : 0;
                dacInventory.StockId = reader["StockID"].ToString();
                dacInventory.ProductName = reader["ProductName"].ToString();
                dacInventory.StockName = reader["StockName"].ToString();
            }

            //Call Close when reading done.
            reader.Close();

            return dacInventory;
        }

        public List<DacInventory> Find(string ProductCode, int Year)
        {
            List<DacInventory> dacInventoryCollection = new List<DacInventory>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@ProductCode", ProductCode);
            dacDb.AddParameter("@Year", Year);
            SqlDataReader reader = dacDb.ExecuteReader("spDacInventory_Select_By_ProductCode_And_Year");

            while (reader.Read())
            {
                DacInventory dacInventory = new DacInventory();
                dacInventory.Id = (int)reader["Id"];
                dacInventory.ProductCode = reader["ProductCode"].ToString();
                dacInventory.Quantity = reader["Quantity"] != null ? int.Parse(reader["Quantity"].ToString()) : 0;
                dacInventory.Year = reader["Year"] != null ? int.Parse(reader["Year"].ToString()) : 0;
                dacInventory.StockId = reader["StockID"].ToString();
                dacInventoryCollection.Add(dacInventory);
            }

            //Call Close when reading done.
            reader.Close();

            return dacInventoryCollection;
        }

        public List<DacInventory> Find(string ProductCode)
        {
            List<DacInventory> dacInventoryCollection = new List<DacInventory>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@ProductCode", ProductCode);
            SqlDataReader reader = dacDb.ExecuteReader("spDacInventory_Select_By_ProductCode");

            while (reader.Read())
            {
                DacInventory dacInventory = new DacInventory();
                dacInventory.Id = (int)reader["Id"];
                dacInventory.ProductCode = reader["ProductCode"].ToString();
                dacInventory.Quantity = reader["Quantity"] != null ? int.Parse(reader["Quantity"].ToString()) : 0;
                dacInventory.Year = reader["Year"] != null ? int.Parse(reader["Year"].ToString()) : 0;
                dacInventory.StockId = reader["StockID"].ToString();
                dacInventoryCollection.Add(dacInventory);
            }

            //Call Close when reading done.
            reader.Close();

            return dacInventoryCollection;
        }

        public bool Insert(DacInventory dacInventory)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ProductCode", dacInventory.ProductCode);
                dacDb.AddParameter("@Quantity", dacInventory.Quantity);
                dacDb.AddParameter("@Year", dacInventory.Year);
                dacDb.AddParameter("@StockID", dacInventory.StockId);

                dacDb.ExecuteNonQuery("spDacInventory_Insert");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(DacInventory dacInventory)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@Id", dacInventory.Id);
                dacDb.AddParameter("@Quantity", dacInventory.Quantity);
                dacDb.AddParameter("@ProductCode", dacInventory.ProductCode);
                dacDb.AddParameter("@StockID", dacInventory.StockId);
                dacDb.AddParameter("@Year", dacInventory.Year);

                dacDb.ExecuteNonQuery("spDacInventory_Update");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(DacInventory dacInventory)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", dacInventory.Id);

                dacDb.ExecuteNonQuery("spDacInventory_Delete_By_ID");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
