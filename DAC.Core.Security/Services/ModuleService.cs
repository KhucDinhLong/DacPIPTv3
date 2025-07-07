using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC.DAL;

namespace DAC.Core.Security
{
    public class ModuleService 
    {
        /// <summary>
        /// Insert or Update
        /// </summary>
        /// <param name="moduleID"></param>
        public void InsertOrUpdate(Module objModule, DacDbAccess dacDbAccess)
        {
            try
            {
                Module objNewModule = GetModuleByModuleID(dacDbAccess, objModule.ModuleID);

                if (objNewModule != null)
                    Update(objModule, dacDbAccess);
                else
                    Insert(objModule, dacDbAccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="objModule"></param>
        public void Insert(Module objModule, DacDbAccess dacDbAccess)
        {
            try
            {
                dacDbAccess.CreateNewSqlCommand();

                dacDbAccess.AddParameter("@ModuleID", objModule.ModuleID);
                dacDbAccess.AddParameter("@ModuleName", objModule.ModuleName);
                dacDbAccess.AddParameter("@Note", objModule.Note);

                dacDbAccess.ExecuteNonQueryWithTransaction("spSecModule_Insert");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="objModule"></param>       
        public void Update(Module objModule, DacDbAccess dacDbAccess)
        {
            try
            {
                dacDbAccess.CreateNewSqlCommand();

                dacDbAccess.AddParameter("@ModuleID", objModule.ModuleID);
                dacDbAccess.AddParameter("@ModuleName", objModule.ModuleName);
                dacDbAccess.AddParameter("@Note", objModule.Note);

                dacDbAccess.ExecuteNonQueryWithTransaction("spSecModule_Update");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Module by ModuleID
        /// </summary>
        /// <param name="nModuleID"></param>
        /// <returns></returns>
        public Module GetModuleByModuleID(int nModuleID)
        {
            Module objModule = null;

            DacDbAccess dacDbAccess = new DacDbAccess();
            dacDbAccess.CreateNewSqlCommand();
            dacDbAccess.AddParameter("@ModuleID", nModuleID);
            System.Data.SqlClient.SqlDataReader reader = dacDbAccess.ExecuteReader("spSecModule_SelectByModuleID");

            if (reader.Read())
            {
                objModule = new Module();
                objModule.ModuleID = nModuleID;
                objModule.ModuleName = reader["ModuleName"].ToString();
                objModule.Note = reader["Note"].ToString();
            }

            //Call Close when reading done.
            reader.Close();

            return objModule;
        }

        /// <summary>
        /// GetModuleByModuleID
        /// </summary>
        /// <param name="nModuleID"></param>
        /// <returns></returns>
        public Module GetModuleByModuleID(DacDbAccess dacDbAccess, int nModuleID)
        {
            Module objModule = null;

            dacDbAccess.CreateNewSqlCommand();
            dacDbAccess.AddParameter("@ModuleID", nModuleID);
            System.Data.SqlClient.SqlDataReader reader = dacDbAccess.ExecuteReaderWithOpenningConnection("spSecModule_SelectByModuleID");

            if (reader.Read())
            {
                objModule = new Module();

                objModule.ModuleID = nModuleID;
                objModule.ModuleName = reader["ModuleName"].ToString();
                objModule.Note = reader["Note"].ToString();
            }

            //Call Close when reading done.
            reader.Close();

            return objModule;
        }

        /// <summary>
        /// Get All Modules
        /// </summary>
        /// <returns></returns>
        public ModuleCollection GetAllModules()
        {
            ModuleCollection moduleCollection = new ModuleCollection();

            DacDbAccess dacDbAccess = new DacDbAccess();
            dacDbAccess.CreateNewSqlCommand();
            System.Data.SqlClient.SqlDataReader reader = dacDbAccess.ExecuteReader("g");

            while (reader.Read())
            {
                Module objModule = new Module();

                objModule.ModuleID = Convert.ToInt32(reader["ModuleID"]);
                objModule.ModuleName = reader["ModuleName"].ToString();
                objModule.Note = reader["Note"].ToString();

                moduleCollection.Add(objModule);
            }

            //Call Close when reading done.
            reader.Close();

            return moduleCollection;
        }
    }
}
