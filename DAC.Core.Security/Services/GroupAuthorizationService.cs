using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAC.Core.Security
{
    [Authorization]
    public class GroupAuthorizationService
    {
        private readonly PIPTDbContext _dbContext;
        public GroupAuthorizationService()
        {
            _dbContext = new PIPTDbContext();
        }
        public bool IsAuthorized()
        {
            return SecurityManager.IsAuthorized(typeof(GroupAuthorizationBS).GetMethod("UpdateData"));
        }

        /// <summary>
        /// Get Group Authorization By ID
        /// </summary>
        /// <param name="objGroupAuthorizationID">ID of Group Authorization</param>
        /// <returns></returns>
        public GroupAuthorization GetGroupAuthorizationByID(Guid groupID, Guid authorizationID)
        {
            var grAuth = _dbContext.SecGroupAuthorization.FirstOrDefault(x => x.GroupId == groupID && x.AuthorizationId == authorizationID);
            GroupAuthorization objGroupAuthorization = new GroupAuthorization();
            if (grAuth != null)
            {
                objGroupAuthorization.GroupID = grAuth.GroupId;
                objGroupAuthorization.AuthorizationID = grAuth.AuthorizationId;
            }
            return objGroupAuthorization;
        }

        [MethodDescription(ModuleType.Administration, FormName.AUTHORIZATION, FunctionName.SC_AddOrDeleteGroupAuthorization)]
        public bool UpdateData(List<GroupAuthorization> lstAddedGroupAuthorization, List<GroupAuthorization> lstDeletedGroupAuthorization,
                                List<MenuGroup> lstAddedMenuGroup, List<MenuGroup> lstDeletedMenuGroup)
        {
            try
            {
                UpdateGroupAuthorization(lstAddedGroupAuthorization, lstDeletedGroupAuthorization);
                new MenuGroupService().UpdateMenuGroup(lstAddedMenuGroup, lstDeletedMenuGroup);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update Group Authorization
        /// </summary>
        /// <param name="lstAddedGroupAuthorization"></param>
        /// <param name="lstDeletedGroupAuthorization"></param>
        private void UpdateGroupAuthorization(List<GroupAuthorization> lstAddedGroupAuthorization, List<GroupAuthorization> lstDeletedGroupAuthorization)
        {
            try
            {
                //1. Delete lstDeletedGroupAuthorization
                for (int i = 0; i < lstDeletedGroupAuthorization.Count; i++)
                {
                    var DeleteAuth = _dbContext.SecGroupAuthorization.FirstOrDefault(x => x.GroupId == lstDeletedGroupAuthorization[i].GroupID 
                                            && x.AuthorizationId == lstDeletedGroupAuthorization[i].AuthorizationID);
                    if (DeleteAuth != null)
                    {
                        _dbContext.SecGroupAuthorization.Remove(DeleteAuth);
                    }
                }
                //2. Insert lstAddedGroupAuthorization
                for (int i = 0; i < lstAddedGroupAuthorization.Count; i++)
                {
                    SecGroupAuthorization newAuth = new SecGroupAuthorization();
                    newAuth.GroupId = lstAddedGroupAuthorization[i].GroupID;
                    newAuth.AuthorizationId = lstAddedGroupAuthorization[i].AuthorizationID;
                    _dbContext.SecGroupAuthorization.Add(newAuth);
                }
            }
            catch 
            {
            }
        }

        /// <summary>
        /// Get Authorization
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Authorization GetAuthorization(SqlDataReader reader)
        {
            Authorization objAuthorization = new Authorization();

            objAuthorization.AuthorizationID = (Guid)reader["AuthorizationID"];
            objAuthorization.Title = reader["Title"].ToString();
            objAuthorization.Description = reader["Description"].ToString();
            objAuthorization.MethodFullName = reader["MethodFullName"].ToString();
            objAuthorization.ModuleID = (int)reader["ModuleID"];

            return objAuthorization;
        }

        /// <summary>
        /// Get Group
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Group GetGroup(SqlDataReader reader)
        {
            Group objGroup = new Group();

            objGroup.GroupID = (Guid)reader["GroupID"];
            objGroup.GroupName = reader["GroupName"].ToString();
            objGroup.Note = reader["Note"].ToString();
            objGroup.IsAdmin = (bool)reader["IsAdmin"];

            return objGroup;
        }

        private static GroupAuthorizationCollection _authorizationCollection = null;
        public static GroupAuthorizationCollection GroupAuthorizationCollection
        {
            get
            {
                if (_authorizationCollection == null)
                {
                    _authorizationCollection = new GroupAuthorizationCollection();
                    GroupAuthorizationCollection groupAuthorizationCollection = new GroupAuthorizationCollection();

                    DacDbAccess dacDb = new DacDbAccess();
                    dacDb.CreateNewSqlCommand();
                    SqlDataReader reader = dacDb.ExecuteReader("spSecGroupAuthorization_SelectAll");

                    while (reader.Read())
                    {
                        GroupAuthorization objGroupAuthorization = new GroupAuthorization();

                        objGroupAuthorization.AuthorizationID = (Guid)reader["AuthorizationID"];
                        objGroupAuthorization.GroupID = (Guid)reader["GroupID"];
                        objGroupAuthorization.Authorization = GetAuthorization(reader);
                        objGroupAuthorization.Group = GetGroup(reader);

                        _authorizationCollection.Add(objGroupAuthorization);
                    }

                    // Call Close when reading done.
                    reader.Close();
                }

                return _authorizationCollection;
            }
            set
            {
                _authorizationCollection = value;
            }
        }


        private static GroupAuthorizationCollection _authorizationCollectionOfCurrentUser = null;
        public static GroupAuthorizationCollection AuthorizationCollectionOfCurrentUser
        {
            get
            {
                if (_authorizationCollectionOfCurrentUser == null)
                {
                    //Get Groups which this user belongs to
                    List<Guid> lstGroups = new List<Guid>();
                    GroupUserBS groupUserBS = new GroupUserBS();

                    lstGroups = groupUserBS.GetListGroupIdByUserID(CommonBS.CurrentUser.LoginID.ToLower());
                    //End            

                    _authorizationCollectionOfCurrentUser = new GroupAuthorizationCollection();
                    for (int i = 0; i < lstGroups.Count; i++)
                    {
                        foreach (GroupAuthorization objGroupAuthorization in GroupAuthorizationCollection)
                        {
                            if (objGroupAuthorization.GroupID == lstGroups[i])
                                _authorizationCollectionOfCurrentUser.Add(objGroupAuthorization);
                        }
                    }
                }

                return _authorizationCollectionOfCurrentUser;
            }
            set
            {
                _authorizationCollectionOfCurrentUser = value;
            }
        }

        /// <summary>
        /// GetAuthorizationRoleCollectionByRoleID
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public GroupAuthorizationCollection GetGroupAuthorizationCollectionByGroupID(Guid groupID)
        {
            GroupAuthorizationCollection groupAuthorizationCollection = new GroupAuthorizationCollection();
            foreach (GroupAuthorization objGroupAuthorization in GroupAuthorizationCollection)
            {
                if (objGroupAuthorization.GroupID == groupID)
                    groupAuthorizationCollection.Add(objGroupAuthorization);
            }

            return groupAuthorizationCollection;
        }

        /// <summary>
        /// CountAuthorizationCollectionByGroupID
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public int CountAuthorizationCollectionByGroupID(Guid groupID)
        {
            int count = 0;
            foreach (GroupAuthorization objGroupAuthorization in GroupAuthorizationCollection)
            {
                if (objGroupAuthorization.GroupID == groupID)
                    count++;
            }

            return count;
        }
    }
}
