using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Core.Security
{
    [Authorization]
    public class AuthorizationBS
    {
        public enum Action { Update, MultilangUI, MultilangData }
        public bool IsAuthorized(Action action)
        {
            string sMethodName = string.Empty;
            switch (action)
            {
                case Action.Update:
                    sMethodName = "AddOrUpdate";
                    break;
                //case Action.MultilangUI:
                //    sMethodName = "MultilangUI";
                //    break;
                //case Action.MultilangData:
                //    sMethodName = "MultilangData";
                //    break;
            }

            return SecurityManager.IsAuthorized(typeof(AuthorizationBS).GetMethod(sMethodName));
        }

        private static AuthorizationCollection m_AuthCollection = null;


        [MethodDescription(ModuleType.Administration, FormName.AUTHORIZATION, FunctionName.SC_AddOrEditAuthorization)]
        public void AddOrUpdate(Authorization authorization, DacDbAccess dacDb)
        {
            Authorization existingAuth = FetchByMethodFullNameWithOpenningConnection(authorization.MethodFullName, dacDb);
            if (existingAuth == null)
            {
                authorization.AuthorizationID = Guid.NewGuid();

                Insert(authorization, dacDb);
            }
            else
            {
                authorization.AuthorizationID = existingAuth.AuthorizationID;

                Update(authorization, dacDb);
            }
        }

        /// <summary>
        /// FetchByMethodFullName
        /// </summary>
        /// <param name="sMethodFullName"></param>
        /// <returns></returns>
        public Authorization FetchByMethodFullName(string sMethodFullName)
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@MethodFullName", sMethodFullName);

            SqlDataReader reader = dacDb.ExecuteReader("spSecAuthorization_FetchByMethodFullName");

            Authorization objAuthorization = null;
            if (reader.Read())
            {
                objAuthorization = new Authorization();

                objAuthorization.AuthorizationID = (Guid)reader["AuthorizationID"];
                objAuthorization.Title = reader["Title"].ToString();
                objAuthorization.Description = reader["Description"].ToString();
                objAuthorization.MethodFullName = reader["MethodFullName"].ToString();
                objAuthorization.ModuleID = (int)reader["ModuleID"];
            }

            // Call Close when reading done.
            reader.Close();

            return objAuthorization;
        }

        /// <summary>
        /// FetchByMethodFullNameWithOpenningConnection
        /// </summary>
        /// <param name="sMethodFullName"></param>
        /// <returns></returns>
        public Authorization FetchByMethodFullNameWithOpenningConnection(string sMethodFullName, DacDbAccess dacDb)
        {
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@MethodFullName", sMethodFullName);

            SqlDataReader reader = dacDb.ExecuteReaderWithOpenningConnection("spSecAuthorization_FetchByMethodFullName");

            Authorization objAuthorization = null;
            if (reader.Read())
            {
                objAuthorization = new Authorization();

                objAuthorization.AuthorizationID = (Guid)reader["AuthorizationID"];
                objAuthorization.Title = reader["Title"].ToString();
                objAuthorization.Description = reader["Description"].ToString();
                objAuthorization.MethodFullName = reader["MethodFullName"].ToString();
                objAuthorization.ModuleID = (int)reader["ModuleID"];
            }

            // Call Close when reading done.
            reader.Close();

            return objAuthorization;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="objAuthorization"></param>
        public void Insert(Authorization objAuthorization, DacDbAccess dacDb)
        {
            try
            {
                dacDb.CreateNewSqlCommand();

                dacDb.AddParameter("@AuthorizationID", objAuthorization.AuthorizationID);
                dacDb.AddParameter("@Title", objAuthorization.Title);
                dacDb.AddParameter("@Description", objAuthorization.Description);
                dacDb.AddParameter("@MethodFullName", objAuthorization.MethodFullName);
                dacDb.AddParameter("@ModuleID", objAuthorization.ModuleID);

                dacDb.ExecuteNonQueryWithTransaction("spSecAuthorization_Insert");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="objAuthorization"></param>
        public void Update(Authorization objAuthorization, DacDbAccess dacDb)
        {
            try
            {
                dacDb.CreateNewSqlCommand();

                dacDb.AddParameter("@AuthorizationID", objAuthorization.AuthorizationID);
                dacDb.AddParameter("@Title", objAuthorization.Title);
                dacDb.AddParameter("@Description", objAuthorization.Description);
                dacDb.AddParameter("@MethodFullName", objAuthorization.MethodFullName);
                dacDb.AddParameter("@ModuleID", objAuthorization.ModuleID);

                dacDb.ExecuteNonQueryWithTransaction("spSecAuthorization_Update");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AuthorizationCollection AuthorizationCollection
        {
            get
            {
                if (m_AuthCollection == null)
                {
                    m_AuthCollection = new AuthorizationCollection();
                    try
                    {
                        DacDbAccess dacDb = new DacDbAccess();
                        dacDb.CreateNewSqlCommand();
                        SqlDataReader reader = dacDb.ExecuteReader("spSecAuthorization_SelectAll");

                        while (reader.Read())
                        {
                            Authorization authorization = new Authorization();

                            authorization.AuthorizationID = (Guid)reader["AuthorizationID"];
                            authorization.Title = reader["Title"].ToString();
                            authorization.Description = reader["Description"].ToString();
                            authorization.MethodFullName = reader["MethodFullName"].ToString();
                            authorization.ModuleID = (int)reader["ModuleID"];

                            m_AuthCollection.Add(authorization);
                        }

                        //Call Close when reading done.
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return m_AuthCollection;
            }
            set
            {
                m_AuthCollection = value;
            }
        }

        /// <summary>
        /// GetAuthorizationByID
        /// </summary>
        /// <param name="authorizationID"></param>
        /// <returns></returns>
        public Authorization GetAuthorizationByID(Guid authorizationID)
        {
            foreach (Authorization obj in AuthorizationCollection)
            {
                if (obj.AuthorizationID == authorizationID)
                    return obj;
            }

            return null;
        }


        public static AuthorizationCollection GetAuthorizationCollectionByModuleType(ModuleType moduleType)
        {
            AuthorizationCollection authorizationCollection = new AuthorizationCollection();
            foreach (Authorization objAuthorization in AuthorizationCollection)
            {
                if (objAuthorization.ModuleID == (int)moduleType)
                    authorizationCollection.Add(objAuthorization);
            }

            return authorizationCollection;
        }

        public static AuthorizationCollection GetAuthorizationCollectionByTitle(ModuleType moduleType, string sTitle)
        {
            AuthorizationCollection authorizationCollection = new AuthorizationCollection();
            foreach (Authorization objAuthorization in AuthorizationCollection)
            {
                if (objAuthorization.ModuleID == (int)moduleType && objAuthorization.Title == sTitle)
                    authorizationCollection.Add(objAuthorization);
            }

            return authorizationCollection;
        }

        /// <summary>
        /// GetAuthorizationCollectionByTitle 
        /// </summary>
        /// <param name="sTitle"></param>
        /// <returns></returns>
        public static AuthorizationCollection GetAuthorizationCollectionByTitle(string sTitle)
        {
            AuthorizationCollection authorizationCollection = new AuthorizationCollection();
            foreach (Authorization objAuthorization in AuthorizationCollection)
            {
                if (objAuthorization.Title == sTitle)
                    authorizationCollection.Add(objAuthorization);
            }

            return authorizationCollection;
        }

        /// <summary>
        /// GetAuthorization 
        /// </summary>
        /// <param name="memInfo"></param>
        /// <param name="attrib"></param>
        /// <returns></returns>
        public Authorization GetAuthorization(System.Reflection.MemberInfo memInfo, MethodDescriptionAttribute attrib)
        {
            Authorization objAuthorization = new Authorization();

            objAuthorization.Title = attrib.Title;
            objAuthorization.Description = attrib.Description;
            objAuthorization.MethodFullName = GetMethodFullName(memInfo);
            objAuthorization.ModuleID = (int)attrib.ModuleType;

            return objAuthorization;
        }

        /// <summary>
        /// GetMethodFullName
        /// </summary>
        /// <param name="memInfo"></param>
        /// <returns></returns>
        public string GetMethodFullName(System.Reflection.MemberInfo memInfo)
        {
            return string.Format("{0}[{1}]", memInfo.DeclaringType, memInfo);
        }

        /// <summary>
        /// GetAuthorizationCollectionByGroupID
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        public static AuthorizationCollection GetAuthorizationCollectionByGroupID(ModuleType moduleType)
        {
            AuthorizationCollection authorizationCollection = new AuthorizationCollection();
            foreach (Authorization authorization in AuthorizationCollection)
            {
                if (authorization.ModuleID == (int)moduleType)
                    authorizationCollection.Add(authorization);
            }

            return authorizationCollection;
        }
    }
}
