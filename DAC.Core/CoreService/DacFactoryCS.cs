using System;
using DAC.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace DAC.Core
{
    public class DacFactoryCS
    {
        public List<DacFactory> GetListFactory()
        {
            List<DacFactory> dacFactoryCollection = new List<DacFactory>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            SqlDataReader reader = dacDb.ExecuteReader("spDacFactory_SelectAll");
            while (reader.Read())
            {
                DacFactory dacFactory = new DacFactory();

                dacFactory.ID = (int)reader["ID"];
                dacFactory.Code = reader["Code"].ToString();
                dacFactory.Name = reader["Name"].ToString();
                dacFactory.Address = reader["Address"].ToString();
                dacFactory.OwnerName = reader["OwnerName"].ToString();
                dacFactory.MobileNum = reader["MobileNum"].ToString();
                dacFactory.Email = reader["Email"].ToString();
                dacFactory.Description = reader["Description"].ToString();
                dacFactory.CreatedDate = (DateTime)reader["CreatedDate"];
                dacFactory.CreatedUser = reader["CreatedUser"].ToString();
                dacFactory.ModifiedUser = reader["ModifiedUser"].ToString();
                dacFactory.ModifiedDate = (DateTime)reader["ModifiedDate"];
                dacFactory.Active = (bool)reader["Active"];

                dacFactoryCollection.Add(dacFactory);
            }

            // Call Close when reading done
            reader.Close();

            return dacFactoryCollection;
        }
        public List<DacFactory> GetListFactory(string sCode, string sName, string sMobileNum)
        {
            List<DacFactory> dacFactoryCollection = new List<DacFactory>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@Code", sCode.ToUpper());
            dacDb.AddParameter("@Name", sName);
            dacDb.AddParameter("@MobileNum", sMobileNum);
            SqlDataReader reader = dacDb.ExecuteReader("spDacFactory_SelectByCode");
            while (reader.Read())
            {
                DacFactory dacFactory = new DacFactory();
                dacFactory.ID = (int)reader["ID"];
                dacFactory.Code = reader["Code"].ToString();
                dacFactory.Name = reader["Name"].ToString();
                dacFactory.Address = reader["Address"].ToString();
                dacFactory.OwnerName = reader["OwnerName"].ToString();
                dacFactory.MobileNum = reader["MobileNum"].ToString();
                dacFactory.Email = reader["Email"].ToString();
                dacFactory.Description = reader["Description"].ToString();
                dacFactory.CreatedDate = (DateTime)reader["CreatedDate"];
                dacFactory.CreatedUser = reader["CreatedUser"].ToString();
                dacFactory.ModifiedUser = reader["ModifiedUser"].ToString();
                dacFactory.ModifiedDate = (DateTime)reader["ModifiedDate"];
                dacFactory.Active = (bool)reader["Active"];

                dacFactoryCollection.Add(dacFactory);
            }

            // Call Close when reading done
            reader.Close();

            return dacFactoryCollection;
        }
        public bool Insert(DacFactory dacFactory)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@Code", dacFactory.Code);
                dacDb.AddParameter("@Name", dacFactory.Name);
                dacDb.AddParameter("@Address", dacFactory.Address);
                dacDb.AddParameter("@OwnerName", dacFactory.OwnerName);
                dacDb.AddParameter("@MobileNum", dacFactory.MobileNum);
                dacDb.AddParameter("@Email", dacFactory.Email);
                dacDb.AddParameter("@Description", dacFactory.Description);
                dacDb.AddParameter("@CreatedDate", dacFactory.CreatedDate);
                dacDb.AddParameter("@CreatedUser", dacFactory.CreatedUser);
                dacDb.AddParameter("@ModifiedUser", dacFactory.ModifiedUser);
                dacDb.AddParameter("@ModifiedDate", dacFactory.ModifiedDate);
                dacDb.AddParameter("@Active", dacFactory.Active);

                dacDb.ExecuteNonQuery("spDacFactory_Insert");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(DacFactory dacFactory)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", dacFactory.ID);
                dacDb.AddParameter("@Code", dacFactory.Code);
                dacDb.AddParameter("@Name", dacFactory.Name);
                dacDb.AddParameter("@Address", dacFactory.Address);
                dacDb.AddParameter("@OwnerName", dacFactory.OwnerName);
                dacDb.AddParameter("@MobileNum", dacFactory.MobileNum);
                dacDb.AddParameter("@Email", dacFactory.Email);
                dacDb.AddParameter("@Description", dacFactory.Description);
                dacDb.AddParameter("@ModifiedDate", dacFactory.ModifiedDate);
                dacDb.AddParameter("@ModifiedUser", dacFactory.ModifiedUser);
                dacDb.AddParameter("@Active", dacFactory.Active);

                dacDb.ExecuteNonQuery("spDacFactory_Update");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(string sCode)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@Code", sCode);

                dacDb.ExecuteNonQuery("spDacFactory_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
