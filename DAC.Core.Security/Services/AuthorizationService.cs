using DAC.DAL;
using System;
using System.Linq;

namespace DAC.Core.Security
{
    [Authorization]
    public class AuthorizationService
    {
        private readonly PIPTDbContext _dbContext;
        public AuthorizationService()
        {
            _dbContext = new PIPTDbContext();
            GetAuthorizationCollection();
        }
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

        //private static AuthorizationCollection m_AuthCollection = null;

        public AuthorizationCollection LstAuthorization { get; set; }


        //[MethodDescription(ModuleType.Administration, FormName.AUTHORIZATION, FunctionName.SC_AddOrEditAuthorization)]
        //public void AddOrUpdate(Authorization authorization, DacDbAccess dacDb)
        //{
        //    Authorization existingAuth = FetchByMethodFullNameWithOpenningConnection(authorization.MethodFullName, dacDb);
        //    if (existingAuth == null)
        //    {
        //        authorization.AuthorizationID = Guid.NewGuid();

        //        Insert(authorization, dacDb);
        //    }
        //    else
        //    {
        //        authorization.AuthorizationID = existingAuth.AuthorizationID;

        //        Update(authorization, dacDb);
        //    }
        //}

        /// <summary>
        /// FetchByMethodFullName
        /// </summary>
        /// <param name="sMethodFullName"></param>
        /// <returns></returns>
        public Authorization FetchByMethodFullName(string sMethodFullName)
        {
            var author = _dbContext.SecAuthorizations.FirstOrDefault(x => x.MethodFullName == sMethodFullName);
            Authorization objAuthorization = new Authorization();
            objAuthorization.AuthorizationID = author != null ? author.AuthorizationId : new Guid();
            objAuthorization.Title = author?.Title;
            objAuthorization.Description = author?.Description;
            objAuthorization.MethodFullName = author?.MethodFullName;
            objAuthorization.ModuleID = author != null && author.ModuleID.HasValue ? author.ModuleID.Value : 0;

            return objAuthorization;
        }

        /// <summary>
        /// FetchByMethodFullNameWithOpenningConnection
        /// </summary>
        /// <param name="sMethodFullName"></param>
        /// <returns></returns>
        //public Authorization FetchByMethodFullNameWithOpenningConnection(string sMethodFullName, DacDbAccess dacDb)
        //{
        //    dacDb.CreateNewSqlCommand();
        //    dacDb.AddParameter("@MethodFullName", sMethodFullName);

        //    SqlDataReader reader = dacDb.ExecuteReaderWithOpenningConnection("spSecAuthorization_FetchByMethodFullName");

        //    Authorization objAuthorization = null;
        //    if (reader.Read())
        //    {
        //        objAuthorization = new Authorization();

        //        objAuthorization.AuthorizationID = (Guid)reader["AuthorizationID"];
        //        objAuthorization.Title = reader["Title"].ToString();
        //        objAuthorization.Description = reader["Description"].ToString();
        //        objAuthorization.MethodFullName = reader["MethodFullName"].ToString();
        //        objAuthorization.ModuleID = (int)reader["ModuleID"];
        //    }

        //    // Call Close when reading done.
        //    reader.Close();

        //    return objAuthorization;
        //}

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="objAuthorization"></param>
        public void Insert(Authorization objAuthorization, DacDbAccess dacDb)
        {
            if (objAuthorization != null)
            {
                try
                {

                    var NewAuth = new SecAuthorizations();
                    NewAuth.AuthorizationId = objAuthorization.AuthorizationID;
                    NewAuth.Title = objAuthorization.Title;
                    NewAuth.Description = objAuthorization.Description;
                    NewAuth.MethodFullName = objAuthorization.MethodFullName;
                    NewAuth.ModuleID = objAuthorization.ModuleID;
                    _dbContext.SecAuthorizations.Add(NewAuth);
                    _dbContext.SaveChanges();
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="objAuthorization"></param>
        public void Update(Authorization objAuthorization, DacDbAccess dacDb)
        {
            if (objAuthorization != null)
            {
                try
                {
                    var objAuth = _dbContext.SecAuthorizations.FirstOrDefault(x => x.AuthorizationId == objAuthorization.AuthorizationID);
                    if (objAuth != null)
                    {
                        objAuth.Title = objAuthorization.Title;
                        objAuth.Description = objAuthorization.Description;
                        objAuth.MethodFullName = objAuthorization.MethodFullName;
                        objAuth.ModuleID = objAuthorization.ModuleID;
                        _dbContext.Entry(objAuth).State = System.Data.Entity.EntityState.Modified;
                        _dbContext.SaveChanges();
                    }
                }
                catch
                {
                }
            }
        }

        public void GetAuthorizationCollection()
        {
            try
            {
                var LstAuth = _dbContext.SecAuthorizations.ToList()?.OrderBy(x => x.Title)?.ThenBy(x => x.Description);
                if (LstAuth != null && LstAuth.Any())
                {
                    foreach (var item in LstAuth)
                    {
                        Authorization authorization = new Authorization();
                        authorization.AuthorizationID = item.AuthorizationId;
                        authorization.Title = item.Title;
                        authorization.Description = item.Description;
                        authorization.MethodFullName = item.MethodFullName;
                        authorization.ModuleID = item.ModuleID.HasValue ? item.ModuleID.Value : 0;
                        LstAuthorization.Add(authorization);
                    }
                }
            }
            catch 
            {
            }
        }

        /// <summary>
        /// GetAuthorizationByID
        /// </summary>
        /// <param name="authorizationID"></param>
        /// <returns></returns>
        public Authorization GetAuthorizationByID(Guid authorizationID)
        {
            try
            {
                return LstAuthorization?.FirstOrDefault(x => x.AuthorizationID == authorizationID);
            }
            catch 
            {
                return null;
            }
        }


        public AuthorizationCollection GetAuthorizationCollectionByModuleType(ModuleType moduleType)
        {
            try
            {
                var LstAuth = LstAuthorization.Where(x => x.ModuleID == int.Parse(moduleType.ToString()))?.ToList();
                return LstAuth as AuthorizationCollection;
            }
            catch 
            {
                return null;
            }
        }

        public AuthorizationCollection GetAuthorizationCollectionByTitle(ModuleType moduleType, string sTitle)
        {
            try
            {
                var LstAuth = LstAuthorization.Where(x => x.ModuleID == int.Parse(moduleType.ToString()) && x.Title == sTitle)?.ToList();
                return LstAuth as AuthorizationCollection;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// GetAuthorizationCollectionByTitle 
        /// </summary>
        /// <param name="sTitle"></param>
        /// <returns></returns>
        public AuthorizationCollection GetAuthorizationCollectionByTitle(string sTitle)
        {
            try
            {
                var LstAuth = LstAuthorization.Where(x => x.Title == sTitle)?.ToList();
                return LstAuth as AuthorizationCollection;
            }
            catch
            {
                return null;
            }
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
        //public static AuthorizationCollection GetAuthorizationCollectionByGroupID(ModuleType moduleType)
        //{
        //    AuthorizationCollection authorizationCollection = new AuthorizationCollection();
        //    foreach (Authorization authorization in AuthorizationCollection)
        //    {
        //        if (authorization.ModuleID == (int)moduleType)
        //            authorizationCollection.Add(authorization);
        //    }

        //    return authorizationCollection;
        //}
    }
}
