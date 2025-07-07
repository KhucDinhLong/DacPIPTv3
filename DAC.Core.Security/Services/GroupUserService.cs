using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Core.Security
{
    public class GroupUserService
    {
        /// <summary>
        /// GetGroupUserByID
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="sUserName"></param>
        /// <returns></returns>
        public GroupUser GetGroupUserByID(Guid groupID, string sLoginID)
        {
            sLoginID = sLoginID.ToLower();
            GroupUser objGroupUser = null;

            DacDbAccess db = new DacDbAccess();
            db.CreateNewSqlCommand();

            db.AddParameter("@GroupID", groupID);
            db.AddParameter("@LoginID", sLoginID);

            SqlDataReader reader = db.ExecuteReader("spSecGroupUser_SelectByID");

            if (reader.Read())
            {
                objGroupUser = new GroupUser();

                objGroupUser.GroupID = (Guid)reader["GroupID"];
                objGroupUser.LoginID = reader["LoginID"].ToString();
            }

            //Call Close when done reading.
            reader.Close();

            return objGroupUser;
        }

        /// <summary>
        /// GetListGroupIdByUserAndLanguageID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Guid> GetListGroupIdByUserID(string sLoginID)
        {
            sLoginID = sLoginID.ToLower();
            List<Guid> lstGroupID = new List<Guid>();

            DacDbAccess db = new DacDbAccess();
            db.CreateNewSqlCommand();

            db.AddParameter("@LoginID", sLoginID);

            SqlDataReader reader = db.ExecuteReader("spSecGroupUser_SelectByLoginID");
            while (reader.Read())
            {
                lstGroupID.Add((Guid)reader["GroupID"]);
            }

            //Call Close when done reading.
            reader.Close();

            return lstGroupID;
        }

        /// <summary>
        /// GetListGroupIdByUserAndLanguageID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<GroupUser> GetListOfGroupUserByUserID(string sLoginID)
        {
            sLoginID = sLoginID.ToLower();
            List<GroupUser> lstGroupUser = new List<GroupUser>();

            DacDbAccess db = new DacDbAccess();
            db.CreateNewSqlCommand();

            db.AddParameter("@LoginID", sLoginID);

            SqlDataReader reader = db.ExecuteReader("spSecGroupUser_SelectByLoginID");
            while (reader.Read())
            {
                lstGroupUser.Add(new GroupUser((Guid)reader["GroupID"], reader["LoginID"].ToString()));
            }

            //Call Close when done reading.
            reader.Close();

            return lstGroupUser;
        }


        /// <summary>
        /// Get Group CollecGroupCollectiontion By User ID
        /// </summary>
        /// <param name="sUserName">User Name</param>
        /// <returns>Group Collection</returns>
        public GroupCollection GetGroupCollectionByUserID(string sLoginID)
        {
            GroupCollection groupCollection = new GroupCollection();
            sLoginID = sLoginID.ToLower();

            DacDbAccess db = new DacDbAccess();
            db.CreateNewSqlCommand();

            db.AddParameter("@LoginID", sLoginID);
            SqlDataReader reader = db.ExecuteReader("spSecGroup_SelectByLoginID");

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
    }
}
