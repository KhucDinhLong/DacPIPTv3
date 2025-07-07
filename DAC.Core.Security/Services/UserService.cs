using System;
using System.Collections.Generic;
using DAC.DAL;
using System.Data.SqlClient;
using System.Linq;

namespace DAC.Core.Security
{
    [Authorization]
    public class UserService
    {
        private readonly PIPTDbContext _dbContext;
        public UserService()
        {
            _dbContext = new PIPTDbContext();
        }
        public enum UserAction { Insert, Update, Delete, MultilangUI }
        public bool IsAuthorized(UserAction action)
        {
            string sMethodName = String.Empty;
            switch (action)
            {
                case UserAction.Insert:
                    sMethodName = "Insert";
                    break;
                case UserAction.Update:
                    sMethodName = "Update";
                    break;
                case UserAction.Delete:
                    sMethodName = "Delete";
                    break;
                    //case UserAction.MultilangUI:
                    //    sMethodName = "MultilangUI";
                    //    break;
            }
            return SecurityManagerService.IsAuthorized(typeof(UserBS).GetMethod(sMethodName));
        }

        public UserCollection GetListUser()
        {
            var LstUser = _dbContext.SecUsers.ToList();
            if (LstUser != null && LstUser.Any())
            {

            }
            UserCollection userCollection = new UserCollection();

            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            SqlDataReader reader = dacDb.ExecuteReader("spSecUser_SelectAll");

            while (reader.Read())
            {
                User objUser = new User();

                objUser.LoginID = reader["LoginID"].ToString();
                objUser.FullName = reader["FullName"].ToString();
                objUser.Password = reader["Password"].ToString();
                objUser.Email = reader["Email"].ToString();
                objUser.CreatedDate = (DateTime)reader["CreatedDate"];
                objUser.LockedUser = (bool)reader["LockedUser"];
                objUser.LockedDate = (DateTime)reader["LockedDate"];
                objUser.LockedReason = reader["LockedReason"].ToString();
                objUser.LastLogIn = (DateTime)reader["LastLogIn"];
                objUser.LastChangedPassword = (DateTime)reader["LastChangedPassword"];
                objUser.DeadlineOfUsing = (DateTime)reader["DeadlineOfUsing"];

                userCollection.Add(objUser);
            }

            //Call Close when reading done.
            reader.Close();

            return userCollection;
        }

        /// <summary>
        /// Get User by ID
        /// </summary>
        /// <param name="sLoginID"></param>
        /// <returns></returns>
        public User GetUserByID(string sLoginID)
        {
            User objUser = new User();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@LoginID", sLoginID);
            SqlDataReader reader = dacDb.ExecuteReader("spSecUser_SelectByLoginID");
            if (reader.Read())
            {
                objUser.LoginID = reader["LoginID"].ToString();
                objUser.FullName = reader["FullName"].ToString();
                objUser.Password = reader["Password"].ToString();
                objUser.Email = reader["Email"].ToString();
                objUser.CreatedDate = (DateTime)reader["CreatedDate"];
                objUser.LockedUser = (bool)reader["LockedUser"];
                objUser.LockedDate = (DateTime)reader["LockedDate"];
                objUser.LockedReason = reader["LockedReason"].ToString();
                objUser.LastLogIn = (DateTime)reader["LastLogIn"];
                objUser.LastChangedPassword = (DateTime)reader["LastChangedPassword"];
                objUser.DeadlineOfUsing = (DateTime)reader["DeadlineOfUsing"];
            }

            //Call Close when reading done.
            reader.Close();

            return objUser;
        }

        [MethodDescription(ModuleType.Administration, FormName.USER, FunctionName.SC_AddUser)]
        public bool Insert(User objUser, List<GroupUser> lstGroupUser)
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.BeginTransaction();

            try
            {
                //1. Insert a record into Users table
                dacDb.CreateNewSqlCommand();
                dacDb.AddParameter("@LoginID", objUser.LoginID);
                dacDb.AddParameter("@Password", objUser.Password);
                dacDb.AddParameter("@FullName", objUser.FullName);
                dacDb.AddParameter("@Email", objUser.Email);
                dacDb.AddParameter("@CreatedDate", objUser.CreatedDate);
                dacDb.AddParameter("@LockedUser", objUser.LockedUser);
                dacDb.AddParameter("@LockedDate", objUser.LockedDate);
                dacDb.AddParameter("@LockedReason", objUser.LockedReason);
                dacDb.AddParameter("@LastLogIn", objUser.LastLogIn);
                dacDb.AddParameter("@LastChangedPassword", objUser.LastChangedPassword);
                dacDb.AddParameter("@DeadlineOfUsing", objUser.DeadlineOfUsing);

                dacDb.ExecuteNonQueryWithTransaction("spSecUser_Insert");

                //2. Insert records into GroupUser table
                for (int i = 0; i < lstGroupUser.Count; i++)
                {
                    dacDb.CreateNewSqlCommand();
                    dacDb.AddParameter("@GroupID", lstGroupUser[i].GroupID);
                    dacDb.AddParameter("@LoginID", lstGroupUser[i].LoginID);
                    dacDb.ExecuteNonQueryWithTransaction("spSecGroupUser_Insert");
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

        [MethodDescription(ModuleType.Administration, FormName.USER, FunctionName.SC_EditUser)]
        public bool Update(User objUser, List<GroupUser> lstAddedGroupUser, List<GroupUser> lstDeletedGroupUser)
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.BeginTransaction();

            try
            {
                //1. Update a record in Users table
                dacDb.CreateNewSqlCommand();
                dacDb.AddParameter("@LoginID", objUser.LoginID);
                dacDb.AddParameter("@FullName", objUser.FullName);
                dacDb.AddParameter("@Email", objUser.Email);
                dacDb.AddParameter("@CreatedDate", objUser.CreatedDate);
                dacDb.AddParameter("@LockedUser", objUser.LockedUser);
                dacDb.AddParameter("@LockedDate", objUser.LockedDate);
                dacDb.AddParameter("@LockedReason", objUser.LockedReason);
                dacDb.AddParameter("@LastLogIn", objUser.LastLogIn);
                dacDb.AddParameter("@LastChangedPassword", objUser.LastChangedPassword);
                dacDb.AddParameter("@DeadlineOfUsing", objUser.DeadlineOfUsing);

                dacDb.ExecuteNonQueryWithTransaction("spSecUser_Update");

                //2. Delete records in GroupUser table
                for (int i = 0; i < lstDeletedGroupUser.Count; i++)
                {
                    dacDb.CreateNewSqlCommand();
                    dacDb.AddParameter("@GroupID", lstDeletedGroupUser[i].GroupID);
                    dacDb.AddParameter("@LoginID", lstDeletedGroupUser[i].LoginID);
                    dacDb.ExecuteNonQueryWithTransaction("spSecGroupUser_Delete");
                }

                //3. Insert records into GroupUser tablemin
                for (int i = 0; i < lstAddedGroupUser.Count; i++)
                {
                    dacDb.CreateNewSqlCommand();
                    dacDb.AddParameter("@GroupID", lstAddedGroupUser[i].GroupID);
                    dacDb.AddParameter("@LoginID", lstAddedGroupUser[i].LoginID);
                    dacDb.ExecuteNonQueryWithTransaction("spSecGroupUser_Insert");
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

        [MethodDescription(ModuleType.Administration, FormName.USER, FunctionName.SC_DeleteUser)]
        public bool Delete(List<string> lstUserID, List<GroupUser> lstDeletedGroupUser)
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.BeginTransaction();

            try
            {
                //1. Delete records in GroupUser table
                for (int i = 0; i < lstDeletedGroupUser.Count; i++)
                {
                    dacDb.CreateNewSqlCommand();
                    dacDb.AddParameter("@GroupID", lstDeletedGroupUser[i].GroupID);
                    dacDb.AddParameter("@LoginID", lstDeletedGroupUser[i].LoginID);

                    dacDb.ExecuteNonQueryWithTransaction("spSecGroupUser_Delete");
                }

                //2. Delete records in Users table
                for (int i = 0; i < lstUserID.Count; i++)
                {
                    dacDb.CreateNewSqlCommand();
                    dacDb.AddParameter("@LoginID", lstUserID[i]);

                    dacDb.ExecuteNonQueryWithTransaction("spSecUser_Delete");
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
        /// Update Password
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public bool UpdatePassword(User objUser)
        {
            try
            {
                DacDbAccess dacDb = new DacDbAccess();
                dacDb.CreateNewSqlCommand();

                dacDb.AddParameter("@LoginID", objUser.LoginID);
                dacDb.AddParameter("@Password", objUser.Password);
                dacDb.AddParameter("@LastChangedPassword", objUser.LastChangedPassword);

                dacDb.ExecuteNonQuery("spSecUser_UpdatePassword");

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check login user belongs to Admin Group ?
        /// </summary>
        /// <param name="sUserName">User Name</param>
        /// <returns>Admin Group or not</returns>
        public bool IsAdminUser(string sLoginID)
        {
            GroupCollection groupCollection = new GroupUserBS().GetGroupCollectionByUserID(sLoginID);
            foreach (Group objGroup in groupCollection)
            {
                if (objGroup.IsAdmin)
                {
                    CommonBS.IsAdminUser = true;
                    return true;
                }
            }

            CommonBS.IsAdminUser = false;
            return false;
        }

        /// <summary>
        /// Check Login user
        /// </summary>
        /// <param name="sUserName">User Name</param>
        /// <param name="sPassword">Password</param>
        /// <param name="status">Status of this User</param>
        /// <returns></returns>
        public User CheckUser(string sLoginID, string sPassword, ref UserStatus status)
        {
            DateTime dtmNow = CommonBS.GetServerTime();
            User objUser = GetUserByID(sLoginID);
            if (objUser != null)
            {
                if (objUser.Password == sPassword)
                {
                    //Check this user belongs to Admin Group ?
                    if (IsAdminUser(sLoginID))
                        status = UserStatus.OK;
                    else
                    {
                        if (!objUser.LockedUser)
                        {
                            if (objUser.DeadlineOfUsing.Date >= dtmNow.Date)
                                status = UserStatus.OK;
                            else
                                status = UserStatus.ExpiredDate;
                        }
                        else
                            status = UserStatus.Locked;
                    }
                }
                else
                    status = UserStatus.NotExists;
            }
            else
                status = UserStatus.NotExists;

            return objUser;
        }
        public bool CheckUser(string Username, string Password)
        {
            bool bCheck = false;
            User objUser = GetUserByID(Username);
            if (objUser != null)
            {
                if (objUser.Password == Password)
                {
                    bCheck = true;
                }
                else
                {
                    bCheck = false;
                }
            }
            return bCheck;
        }
    }
}
