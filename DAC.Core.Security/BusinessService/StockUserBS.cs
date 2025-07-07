using DAC.Core;
using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAC.Core.Security
{
    [Authorization]
    public class StockUserBS
    {
        public enum GroupAction { Insert, Update, Delete, MultilangUI, MultilangData }
        public bool IsAuthorized(GroupAction action)
        {
            string sMethodName = string.Empty;
            switch (action)
            {
                case GroupAction.Insert:
                    sMethodName = "Insert";
                    break;
                case GroupAction.Update:
                    sMethodName = "Update";
                    break;
                case GroupAction.Delete:
                    sMethodName = "Delete";
                    break;
                //case GroupAction.MultilangUI:
                //    sMethodName = "MultilangUI";
                //    break;
                //case GroupAction.MultilangData:
                //    sMethodName = "MultilangData";
                //    break;
            }

            return SecurityManager.IsAuthorized(typeof(StockUserBS).GetMethod(sMethodName));
        }

        [MethodDescription(ModuleType.Administration, FormName.GROUP, FunctionName.SC_AddGroup)]
        public bool Insert(StockUser objStockUser)
        {
            try
            {
                DacDbAccess dacDb = new DacDbAccess();
                dacDb.CreateNewSqlCommand();

                dacDb.AddParameter("@StockID", objStockUser.StockID);
                dacDb.AddParameter("@LoginID", objStockUser.LoginID);

                dacDb.ExecuteNonQuery("spSecStockUser_Insert");
                return true;
            }
            catch
            {
                return false;
            }
        }

        [MethodDescription(ModuleType.Administration, FormName.GROUP, FunctionName.SC_DeleteGroup)]
        public bool Delete(StockUser objStockUser)
        {
            try
            {
                DacDbAccess dacDb = new DacDbAccess();
                dacDb.CreateNewSqlCommand();

                dacDb.AddParameter("@StockID", objStockUser.StockID);
                dacDb.AddParameter("@LoginID", objStockUser.LoginID);

                dacDb.ExecuteNonQuery("spSecStockUser_Delete");
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get Stock User Collection By User ID
        /// </summary>
        /// <param name="sUserName">User Name</param>
        /// <returns>Group Collection</returns>
        public StockUserCollection GetStockUserCollectionByLoginID(string sLoginID)
        {
            StockUserCollection stockUserCollection = new StockUserCollection();
            sLoginID = sLoginID.ToLower();

            DacDbAccess db = new DacDbAccess();
            db.CreateNewSqlCommand();

            db.AddParameter("@LoginID", sLoginID);
            SqlDataReader reader = db.ExecuteReader("spSecStockUser_SelectByLoginID");

            while (reader.Read())
            {
                StockUser objStockUser = new StockUser();

                objStockUser.LoginID = reader["LoginID"].ToString();
                objStockUser.StockID = reader["StockID"].ToString();

                stockUserCollection.Add(objStockUser);
            }

            //Call Close when done reading.
            reader.Close();

            return stockUserCollection;
        }

        /// <summary>
        /// Update Stock-User in DB
        /// </summary>
        /// <param name="lstAddedStockUser">List of Added Stock-User</param>
        /// <param name="lstDeletedStockUser">List of Deleted Stock-User</param>
        /// <returns></returns>
        public bool UpdateStockUser(DacDbAccess dacDb, List<StockUser> lstAddedStockUser, List<StockUser> lstDeletedStockUser)
        {
            try
            {
                //1. Add new menu 
                for (int i = 0; i < lstAddedStockUser.Count; i++)
                {
                    dacDb.CreateNewSqlCommand();
                    dacDb.AddParameter("@LoginID", lstAddedStockUser[i].LoginID);
                    dacDb.AddParameter("@StockID", lstAddedStockUser[i].StockID);

                    dacDb.ExecuteNonQuery("spSecStockUser_Insert");
                }

                //2. Delete menu
                for (int i = 0; i < lstDeletedStockUser.Count; i++)
                {
                    dacDb.CreateNewSqlCommand();
                    dacDb.AddParameter("@LoginID", lstDeletedStockUser[i].LoginID);
                    dacDb.AddParameter("@StockID", lstDeletedStockUser[i].StockID);

                    dacDb.ExecuteNonQuery("spSecStockUser_Delete");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
