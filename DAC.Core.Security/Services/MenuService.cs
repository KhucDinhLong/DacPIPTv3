using System;
using System.Collections.Generic;
using DAC.DAL;
using System.Data.SqlClient;

namespace DAC.Core.Security
{
    public class MenuService
    {
        #region Write Data

        /// <summary>
        /// Update Menu in DB
        /// </summary>
        /// <param name="lstAddedMenu">List of menus need to be updated</param>
        public bool UpdateMenu(List<Menu> lstMenu)
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.BeginTransaction();
            try
            {
                Menu objMenu;

                for (int i = 0; i < lstMenu.Count; i++)
                {
                    objMenu = GetMenuByID(lstMenu[i].MenuID, dacDb);

                    if (objMenu != null)
                    {
                        objMenu.MenuFiliationID = lstMenu[i].MenuFiliationID;
                        objMenu.MenuValue = lstMenu[i].MenuValue;
                        objMenu.FormName = lstMenu[i].FormName;

                        UpdateMenu(objMenu, dacDb);
                    }
                    else
                        InsertMenu(lstMenu[i], dacDb);
                }

                dacDb.CommitTransaction();
                return true;
            }
            catch
            {
                dacDb.RollbackTransaction();
                return false;
            }
        }

        /// <summary>
        /// Get menu for updating
        /// </summary>
        /// <param name="objMenuID">Menu ID</param>
        /// <returns></returns>
        public Menu GetMenuByID(string sMenuID, DacDbAccess db)
        {
            Menu objMenu = null;
            db.CreateNewSqlCommand();
            db.AddParameter("@MenuID", sMenuID);
            SqlDataReader reader = db.ExecuteReaderWithOpenningConnection("spSecMenu_SelectByMenuID");

            if (reader.Read())
            {
                objMenu = new Menu();

                objMenu.MenuID = sMenuID;
                objMenu.MenuValue = reader["MenuValue"].ToString();
                objMenu.MenuPosition = Convert.ToInt32(reader["MenuPosition"]);
                objMenu.MenuFiliationID = reader["MenuFiliationID"].ToString();
                objMenu.FormName = reader["FormName"].ToString();
            }

            //Call Close when reading done.
            reader.Close();

            return objMenu;
        }

        /// <summary>
        /// InsertMenu
        /// </summary>
        /// <param name="objMenu"></param>
        private void InsertMenu(Menu objMenu, DacDbAccess db)
        {
            try
            {
                db.CreateNewSqlCommand();

                db.AddParameter("@MenuID", objMenu.MenuID);
                db.AddParameter("@MenuPosition", objMenu.MenuPosition);
                db.AddParameter("@MenuValue", objMenu.MenuValue);
                db.AddParameter("@MenuFiliationID", objMenu.MenuFiliationID);
                db.AddParameter("@FormName", objMenu.FormName);

                db.ExecuteNonQueryWithTransaction("spSecMenu_Insert");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// UpdateMenu
        /// </summary>
        /// <param name="objMenu"></param>
        private void UpdateMenu(Menu objMenu, DacDbAccess db)
        {
            try
            {
                db.CreateNewSqlCommand();

                db.AddParameter("@MenuID", objMenu.MenuID);
                db.AddParameter("@MenuValue", objMenu.MenuValue);
                db.AddParameter("@MenuFiliationID", objMenu.MenuFiliationID);
                db.AddParameter("@FormName", objMenu.FormName);

                db.ExecuteNonQueryWithTransaction("spSecMenu_Update");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        /// <summary>
        /// Get Menu Collection By LanguageID
        /// </summary>       
        /// <returns></returns>
        public MenuCollection GetMenuCollection()
        {
            MenuCollection menuCollection = new MenuCollection();

            DacDbAccess db = new DacDbAccess();
            db.CreateNewSqlCommand();
            SqlDataReader reader = db.ExecuteReader("spSecMenu_SelectAll");

            while (reader.Read())
            {
                Menu objMenu = new Menu();

                objMenu.MenuID = reader["MenuID"].ToString();
                objMenu.MenuPosition = Convert.ToInt32(reader["MenuPosition"]);
                objMenu.MenuValue = reader["MenuValue"].ToString();
                objMenu.MenuFiliationID = reader["MenuFiliationID"].ToString();
                objMenu.FormName = reader["FormName"].ToString();

                menuCollection.Add(objMenu);
            }

            //Call Close when reading done.
            reader.Close();

            return menuCollection;
        }
    }
}
