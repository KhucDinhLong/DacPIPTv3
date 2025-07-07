using DAC.DAL;
using System;
using System.Data.SqlClient;

namespace DAC.Core.Security
{
    [Authorization]
    public class GroupService
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

            return SecurityManager.IsAuthorized(typeof(GroupBS).GetMethod(sMethodName));
        }

        [MethodDescription(ModuleType.Administration, FormName.GROUP, FunctionName.SC_AddGroup)]
        public bool Insert(Group objGroup)
        {
            try
            {
                DacDbAccess dacDb = new DacDbAccess();
                dacDb.CreateNewSqlCommand();

                dacDb.AddParameter("@GroupID", objGroup.GroupID);
                dacDb.AddParameter("@GroupName", objGroup.GroupName);
                dacDb.AddParameter("@Note", objGroup.Note);
                dacDb.AddParameter("@IsAdmin", objGroup.IsAdmin);

                dacDb.ExecuteNonQuery("spSecGroup_Insert");
                return true;
            }
            catch
            {
                return false;
            }
        }

        [MethodDescription(ModuleType.Administration, FormName.GROUP, FunctionName.SC_EditGroup)]
        public bool Update(Group objGroup)
        {
            try
            {
                DacDbAccess dacDb = new DacDbAccess();
                dacDb.CreateNewSqlCommand();

                dacDb.AddParameter("@GroupID", objGroup.GroupID);
                dacDb.AddParameter("@GroupName", objGroup.GroupName);
                dacDb.AddParameter("@Note", objGroup.Note);
                dacDb.AddParameter("@IsAdmin", objGroup.IsAdmin);

                dacDb.ExecuteNonQuery("spSecGroup_Update");
                return true;
            }
            catch
            {
                return false;
            }
        }

        [MethodDescription(ModuleType.Administration, FormName.GROUP, FunctionName.SC_DeleteGroup)]
        public bool Delete(Guid groupID)
        {
            try
            {
                DacDbAccess dacDb = new DacDbAccess();
                dacDb.CreateNewSqlCommand();

                dacDb.AddParameter("@GroupID", groupID);

                dacDb.ExecuteNonQuery("spSecGroup_Delete");
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// RoleCollection
        /// </summary>
        public GroupCollection GetListOfGroup()
        {
            GroupCollection groupCollection = new GroupCollection();

            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();

            SqlDataReader reader = dacDb.ExecuteReader("spSecGroup_SelectAll");
            while (reader.Read())
            {
                Group objGroup = new Group();

                objGroup.GroupID = (Guid)reader["GroupID"];
                objGroup.GroupName = reader["GroupName"].ToString();
                objGroup.Note = reader["Note"].ToString();
                objGroup.IsAdmin = (bool)reader["IsAdmin"];

                groupCollection.Add(objGroup);
            }

            //Call Close when done reading.
            reader.Close();

            return groupCollection;
        }

        /// <summary>
        /// GetGroupByID
        /// </summary>
        /// <param name="objGroupID"></param>
        /// <returns></returns>
        public Group GetGroupByID(string groupID)
        {
            Group objGroup = new Group();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();

            dacDb.AddParameter("@GroupID", groupID);
            SqlDataReader reader = dacDb.ExecuteReader("spSecGroup_SelectByGroupID");

            if (reader.Read())
            {
                objGroup.GroupID = Guid.Parse(groupID);
                objGroup.GroupName = reader["GroupName"].ToString();
                objGroup.Note = reader["Note"].ToString();
                objGroup.IsAdmin = (bool)reader["IsAdmin"];
            }

            //Call Close when done reading.
            reader.Close();

            return objGroup;
        }
    }
}
