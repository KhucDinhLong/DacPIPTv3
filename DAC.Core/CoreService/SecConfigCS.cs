using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAC.Core
{
    public class SecConfigCS
    {
        public static List<SecConfig> GetSecConfigs()
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSQL();
                // Add parameters
                DataTable dataTable = dacDb.ExecuteDataTable("SELECT * FROM [dbo].[SecConfig] WHERE [Active] = 1");
                if (dataTable.Rows.Count > 0)
                {
                    List<SecConfig> secConfigs = new List<SecConfig>();
                    foreach(DataRow dataRow in dataTable.Rows)
                    {
                        SecConfig secConfig = new SecConfig();
                        secConfig.Id = (int)dataRow["Id"];
                        secConfig.Code = dataRow["Code"].ToString();
                        secConfig.Name = dataRow["Name"].ToString();
                        secConfig.Value = dataRow["Value"].ToString();
                        secConfig.Pattern = dataRow["Pattern"].ToString();
                        secConfig.Description = dataRow["Description"].ToString();
                        secConfig.Active = (bool)dataRow["Active"];

                        secConfigs.Add(secConfig);
                    }
                    return secConfigs;
                }
                else
                {
                    return new List<SecConfig>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DacDbConnection.Close();
            }
        }

        public static bool UpdateSecConfig(SecConfig secConfig)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSQL();
                // Add parameters
                dacDb.AddParameter("@ID", secConfig.Id);
                dacDb.AddParameter("@Value", secConfig.Value);
                dacDb.AddParameter("@Pattern", secConfig.Pattern);

                dacDb.ExecuteNonQuery("UPDATE dbo.SecConfig SET Value = @Value, Pattern = @Pattern WHERE ID = @ID");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DacDbConnection.Close();
            }
        }
    }
}
