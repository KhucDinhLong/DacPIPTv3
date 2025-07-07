using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DAC.DAL;

namespace DAC.Core.Security
{
    public class SecurityManagerService
    {
        private static AuthorizationBS authorizationBS;
        private static bool _isDebugMode = false;

        public static bool IsDebugMode
        {
            get { return _isDebugMode; }
            set { _isDebugMode = value; }
        }

        private static System.Collections.Specialized.StringCollection AssembliesToVerify
        {
            get
            {
                System.Collections.Hashtable hash = (System.Collections.Hashtable)System.Configuration.ConfigurationManager.GetSection("security");
                System.Collections.Specialized.StringCollection mCol = new System.Collections.Specialized.StringCollection();
                foreach (string key in hash.Keys)
                    if (bool.Parse(hash[key].ToString()))
                        mCol.Add(key);
                return mCol;
            }
        }

        /// <summary>
        /// Check All Assemblies
        /// </summary>
        /// <returns></returns>
        public static bool CheckAllAssemblies()
        {
            DacDbAccess dacDbaccess = new DacDbAccess();
            dacDbaccess.BeginTransaction();
            try
            {
                authorizationBS = new AuthorizationBS();
                foreach (string sAss in AssembliesToVerify)
                {
                    System.Reflection.Assembly ass = System.Reflection.Assembly.Load(sAss);
                    CheckAssemblyAuthorization(ass, dacDbaccess);
                }
                dacDbaccess.CommitTransaction();
                return true;
            }
            catch
            {
                dacDbaccess.RollbackTransaction();
                return false;
            }
        }

        /// <summary>
        /// Check All Assemblies
        /// </summary>
        /// <param name="moduleCollection"></param>
        /// <returns></returns>
        public static bool CheckAllAssemblies(ModuleCollection moduleCollection)
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.BeginTransaction();
            try
            {
                // 1. Update Modules
                ModuleBS moduleBS = new ModuleBS();
                foreach (Module objModule in moduleCollection)
                {
                    moduleBS.InsertOrUpdate(objModule, dacDb);
                }

                // 2. Update Authorization
                authorizationBS = new AuthorizationBS();
                foreach (string sAss in AssembliesToVerify)
                {
                    System.Reflection.Assembly ass = System.Reflection.Assembly.Load(sAss);
                    CheckAssemblyAuthorization(ass, dacDb);
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
        /// Check Assembly Authorization
        /// </summary>
        /// <param name="ass"></param>
        /// <param name="dacDb"></param>
        private static void CheckAssemblyAuthorization(System.Reflection.Assembly ass, DacDbAccess dacDb)
        {
            foreach (Type type in ass.GetTypes())
            {
                CheckAuthorizations(type, dacDb);
            }
        }

        /// <summary>
        /// Check Authorizations
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dacDbaccess"></param>
        private static void CheckAuthorizations(Type type, DacDbAccess dacDb)
        {
            if((type.GetCustomAttributes(typeof(AuthorizationAttribute), true).Length == 0)) return;
            foreach(System.Reflection.MemberInfo memInfo in type.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                object[] objBrowse = memInfo.GetCustomAttributes(typeof(MethodBrowsableAttribute), true);
                if (objBrowse.Length > 0 && !((MethodBrowsableAttribute)objBrowse[0]).Browsable)
                    continue;

                object[] objMethods = memInfo.GetCustomAttributes(typeof(MethodBrowsableAttribute), true);
                if(objMethods.Length > 0)
                {
                    MethodDescriptionAttribute descriptionAttribute = (MethodDescriptionAttribute)objMethods[0];

                    Authorization objAuthorization = authorizationBS.GetAuthorization(memInfo, descriptionAttribute);

                    try
                    {
                        authorizationBS.AddOrUpdate(objAuthorization, dacDb);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public static bool IsAuthorized(System.Reflection.MethodBase methodBase)
        {
            if (CommonBS.IsAdminUser)
                return true;
            else
            {
                AuthorizationBS authorizationBS = new AuthorizationBS();

                //GroupAuthorizationCollection groupAuthorizationCollection = new GroupAuthorizationBS().GetGroupAuthorizationCollectionByUserID(CommonBS.CurrentUser.UserName.ToLower());
                foreach (GroupAuthorization objGroupAuthorization in GroupAuthorizationBS.AuthorizationCollectionOfCurrentUser)/*groupAuthorizationCollection)*/
                {
                    if (objGroupAuthorization.Authorization.MethodFullName == authorizationBS.GetMethodFullName(methodBase))
                        return true;
                }

                return false;
            }
        }
    }
}
