using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Core.Security
{
    public class MenuGroupBS
    {
        /// <summary>
        /// Update menu-group in DB
        /// </summary>
        /// <param name="lstAddedMenuGroup">List of Added Menu-Group</param>
        /// <param name="lstDeletedMenuGroup">List of Deleted Menu-Group</param>
        /// <returns></returns>
        public bool UpdateMenuGroup(DacDbAccess dacDb, List<MenuGroup> lstAddedMenuGroup, List<MenuGroup> lstDeletedMenuGroup)
        {
            try
            {

                //1. Add new menu 
                for (int i = 0; i < lstAddedMenuGroup.Count; i++)
                {
                    dacDb.CreateNewSqlCommand();
                    dacDb.AddParameter("@GroupID", lstAddedMenuGroup[i].GroupID);
                    dacDb.AddParameter("@MenuID", lstAddedMenuGroup[i].MenuID);

                    dacDb.ExecuteNonQuery("spSecMenuGroup_Insert");
                }

                //2. Delete menu
                for (int i = 0; i < lstDeletedMenuGroup.Count; i++)
                {
                    dacDb.CreateNewSqlCommand();
                    dacDb.AddParameter("@GroupID", lstDeletedMenuGroup[i].GroupID);
                    dacDb.AddParameter("@MenuID", lstDeletedMenuGroup[i].MenuID);

                    dacDb.ExecuteNonQuery("spSecMenuGroup_Delete");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Get Menu Group Collection
        /// </summary>
        /// <returns></returns>
        public MenuGroupCollection GetMenuGroupCollection()
        {
            MenuGroupCollection menuGroupCollection = new MenuGroupCollection();

            DacDbAccess db = new DacDbAccess();
            db.CreateNewSqlCommand();
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("spSecMenuGroup_SelectAll");
            while (reader.Read())
            {
                MenuGroup objMenuGroup = new MenuGroup();

                objMenuGroup.GroupID = (Guid)reader["GroupID"];
                objMenuGroup.MenuID = reader["MenuID"].ToString();

                menuGroupCollection.Add(objMenuGroup);
            }

            //Call Close when reading done.
            reader.Close();

            return menuGroupCollection;
        }

        /// <summary>
        /// Get Menu Group Collection
        /// </summary>
        /// <returns></returns>
        public MenuGroupCollection GetMenuGroupCollectionByGroupID(List<Guid> lstGroupID)
        {
            MenuGroupCollection allMenuGroupCollection = GetMenuGroupCollection();
            MenuGroupCollection menuGroupCollection = new MenuGroupCollection();

            for (int i = 0; i < lstGroupID.Count; i++)
            {
                foreach (MenuGroup objMenuGroup in allMenuGroupCollection)
                {
                    if (objMenuGroup.GroupID == lstGroupID[i])
                        menuGroupCollection.Add(objMenuGroup);
                }
            }

            return menuGroupCollection;
        }
    }
}
