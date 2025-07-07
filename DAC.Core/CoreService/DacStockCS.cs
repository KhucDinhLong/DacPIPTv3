using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacStockCS
    {
        /// <summary>
        /// Nhan danh sach cac chuyen muc
        /// </summary>
        /// <param name="sStoredProcedureName">Ten StoredProcedure tuong ung</param>
        /// <returns></returns>
        public List<DacStock> GetListStock(string Code, string Name, string Email, string Mobi, string LoginID)
        {
            List<DacStock> dacStockCollection = new List<DacStock>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@Code", Code);
            dacDb.AddParameter("@Name", Name);
            dacDb.AddParameter("@Email", Email);
            dacDb.AddParameter("@Mobi", Mobi);
            dacDb.AddParameter("@LoginID", LoginID);
            SqlDataReader reader = dacDb.ExecuteReader("DacStock_Select");

            while (reader.Read())
            {
                DacStock stock = new DacStock();

                stock.Id = (int)reader["Id"];
                stock.Code = reader["Code"].ToString();
                stock.Name = reader["Name"].ToString();
                stock.Contact = reader["Contact"].ToString();
                stock.Address = reader["Address"].ToString();
                stock.Email = reader["Email"].ToString();
                stock.Telephone = reader["Telephone"].ToString();
                stock.Fax = reader["Fax"].ToString();
                stock.Mobi = reader["Mobi"].ToString();
                stock.Manager = reader["Manager"].ToString(); 
                stock.Description = reader["Description"].ToString();
                stock.Active = (bool)reader["Active"];

                dacStockCollection.Add(stock);
            }

            //Call Close when reading done.
            reader.Close();

            return dacStockCollection;
        }

        /// <summary>
        /// Luu dinh nghia cac loai kho
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Insert(DacStock stock)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@Code", stock.Code);
                dacDb.AddParameter("@Name", stock.Name);
                dacDb.AddParameter("@Contact", stock.Contact);
                dacDb.AddParameter("@Address", stock.Address);
                dacDb.AddParameter("@Email", stock.Email);
                dacDb.AddParameter("@Telephone", stock.Telephone);
                dacDb.AddParameter("@Fax", stock.Fax);
                dacDb.AddParameter("@Mobi", stock.Mobi);
                dacDb.AddParameter("@Manager", stock.Manager);
                dacDb.AddParameter("@Description", stock.Description);
                dacDb.AddParameter("@Active", stock.Active);

                dacDb.ExecuteNonQuery("DacStock_Insert");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Sua dinh nghia cac loai danh muc
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool Update(DacStock stock)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", stock.Id);
                dacDb.AddParameter("@Code", stock.Code);
                dacDb.AddParameter("@Name", stock.Name);
                dacDb.AddParameter("@Contact", stock.Contact);
                dacDb.AddParameter("@Address", stock.Address);
                dacDb.AddParameter("@Email", stock.Email);
                dacDb.AddParameter("@Telephone", stock.Telephone);
                dacDb.AddParameter("@Fax", stock.Fax);
                dacDb.AddParameter("@Mobi", stock.Mobi);
                dacDb.AddParameter("@Manager", stock.Manager);
                dacDb.AddParameter("@Description", stock.Description);
                dacDb.AddParameter("@Active", stock.Active);

                dacDb.ExecuteNonQuery("DacStock_Update");
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

                dacDb.ExecuteNonQuery("DacStock_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DacStock> GetAllActiveStock()
        {
            List<DacStock> dacStockCollection = new List<DacStock>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            SqlDataReader reader = dacDb.ExecuteReader("DacStock_Select_All_Active");

            while (reader.Read())
            {
                DacStock stock = new DacStock();

                stock.Id = (int)reader["Id"];
                stock.Code = reader["Code"].ToString();
                stock.Name = reader["Name"].ToString();
                stock.Contact = reader["Contact"].ToString();
                stock.Address = reader["Address"].ToString();
                stock.Email = reader["Email"].ToString();
                stock.Telephone = reader["Telephone"].ToString();
                stock.Fax = reader["Fax"].ToString();
                stock.Mobi = reader["Mobi"].ToString();
                stock.Manager = reader["Manager"].ToString();
                stock.Description = reader["Description"].ToString();
                stock.Active = (bool)reader["Active"];

                dacStockCollection.Add(stock);
            }

            //Call Close when reading done.
            reader.Close();

            return dacStockCollection;
        }

        public string GetNameByCode(string Code)
        {
            string result = string.Empty;
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@Code", Code);
            SqlDataReader reader = dacDb.ExecuteReader("DacStock_Get_Name_By_Code");
            if (reader.Read())
            {
                result = reader["Name"].ToString();
                reader.Close();
            }
            return result;
        }
    }
}