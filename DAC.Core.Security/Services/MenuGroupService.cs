using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAC.Core.Security
{
    public class MenuGroupService
    {
        private readonly PIPTDbContext _dbContext;
        public MenuGroupService()
        {
            _dbContext = new PIPTDbContext();
        }
        /// <summary>
        /// Update menu-group in DB
        /// </summary>
        /// <param name="lstAddedMenuGroup">List of Added Menu-Group</param>
        /// <param name="lstDeletedMenuGroup">List of Deleted Menu-Group</param>
        /// <returns></returns>
        public bool UpdateMenuGroup(List<MenuGroup> lstAddedMenuGroup, List<MenuGroup> lstDeletedMenuGroup)
        {
            try
            {
                //1. Delete menu
                for (int i = 0; i < lstDeletedMenuGroup.Count; i++)
                {
                    var DeleteGroup = _dbContext.SecMenuGroup.FirstOrDefault(x => x.GroupId == lstDeletedMenuGroup[i].GroupID 
                                            && x.MenuId == lstDeletedMenuGroup[i].MenuID);
                    if (DeleteGroup != null)
                    {
                        _dbContext.SecMenuGroup.Remove(DeleteGroup);
                    }
                }
                //2. Add new menu 
                for (int i = 0; i < lstAddedMenuGroup.Count; i++)
                {
                    SecMenuGroup newData = new SecMenuGroup();
                    newData.GroupId = lstAddedMenuGroup[i].GroupID;
                    newData.MenuId = lstAddedMenuGroup[i].MenuID;
                    _dbContext.SecMenuGroup.Add(newData);
                    //dacDb.CreateNewSqlCommand();
                    //dacDb.AddParameter("@GroupID", lstAddedMenuGroup[i].GroupID);
                    //dacDb.AddParameter("@MenuID", lstAddedMenuGroup[i].MenuID);

                    //dacDb.ExecuteNonQuery("spSecMenuGroup_Insert");
                }
                _dbContext.SaveChanges();
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
