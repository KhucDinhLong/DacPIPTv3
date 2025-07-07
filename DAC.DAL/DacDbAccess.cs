using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAC.DAL
{
    public class DacDbAccess
    {
        public SqlCommand sqlCommand;
        SqlTransaction sqlTransaction;
        SqlBulkCopy sqlBulkCopy;

        #region Open-Close Connection
        /// <summary>
        /// Open Connection
        /// </summary>
        private void Open()
        {
            DacDbConnection.Open();
        }
        /// <summary>
        /// Close Connection
        /// </summary>
        private void Close()
        {
            DacDbConnection.Close();
        }
        #endregion

        #region Transaction
        /// <summary>
        /// Begin Transaction
        /// </summary>
        public void BeginTransaction()
        {
            DacDbConnection.Open();
            sqlTransaction = DacDbConnection.SqlConnection.BeginTransaction();
        }
        /// <summary>
        /// Commit Transaction
        /// </summary>
        public void CommitTransaction()
        {
            sqlTransaction.Commit();
            DacDbConnection.Close();
        }
        /// <summary>
        /// Rollback Transaction
        /// </summary>
        public void RollbackTransaction()
        {
            sqlTransaction.Rollback();
            DacDbConnection.Close();
        }
        #endregion

        #region Create and Add parameter for SqlCommand
        /// <summary>
        /// Create New SqlCommand
        /// </summary>
        public void CreateNewSqlCommand()
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = DacDbConnection.SqlConnection;
        }
        /// <summary>
        /// Create New SqlCommand
        /// </summary>
        public void CreateNewSQL()
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = DacDbConnection.SqlConnection;
        }
        /// <summary>
        /// Add Parameters for calling stored procedures
        /// </summary>
        /// <param name="parameterName">Name of Parameter</param>
        /// <param name="value">Value of Parameter</param>
        public void AddParameter(string parameterName, object value)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = parameterName;
            sqlParameter.Value = value;
            sqlCommand.Parameters.Add(sqlParameter);
        }
        /// <summary>
        /// Add Parameters for calling stored procedures
        /// </summary>
        /// <param name="parameterName">Name of Parameter</param>
        /// <param name="value">Value of Parameter</param>
        public void RemoveParameter(string parameterName)
        {
            int paramIndex = sqlCommand.Parameters.IndexOf(parameterName);
            sqlCommand.Parameters.RemoveAt(paramIndex);
        }
        /// <summary>
        /// Add Parameters for calling stored procedures with Output parameter
        /// </summary>
        /// <param name="parameterName">Name of Parameter</param>
        /// <param name="value">Value of Parameter</param>
        /// <param name="sqlDbType">Type of Parameter</param>
        public void AddParameter(string parameterName, SqlDbType sqlDbType)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = parameterName;
            sqlParameter.SqlDbType = sqlDbType;
            sqlParameter.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter);
        }
        #endregion

        #region Execute SqlCommand
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="sProcedureName">Name of Stored Procedure</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sProcedureName)
        {
            try
            {
                sqlCommand.CommandText = sProcedureName;
                this.Open();
                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// Execute Non Query With Transaction
        /// </summary>
        /// <param name="sProcedureName">Name of Stored Procedure</param>
        /// <returns></returns>
        public bool ExecuteNonQueryWithTransaction(string sProcedureName)
        {
            try
            {
                sqlCommand.CommandText = sProcedureName;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Execute Scalar
        /// </summary>
        /// <param name="sProcedureName">Name of Stored Procedure</param>
        /// <returns></returns>
        public object ExecuteScalar(string sProcedureName)
        {
            try
            {
                sqlCommand.CommandText = sProcedureName;
                this.Open();
                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// Execute Reader
        /// </summary>
        /// <param name="sProcedureName">Name of Stored Procedure</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sProcedureName)
        {
            try
            {
                sqlCommand.CommandText = sProcedureName;
                this.Open();
                return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Execute Reader With Openning Connecting - Not close connection after reading
        /// </summary>
        /// <param name="sProcedureName">Name of Stored Procedure</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReaderWithOpenningConnection(string sProcedureName)
        {
            try
            {
                sqlCommand.CommandText = sProcedureName;
                sqlCommand.Transaction = sqlTransaction;
                return sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Execute Datatable
        /// </summary>
        /// <param name="sProcedureName">Name of Stored Procedure</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sProcedureName)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlCommand.CommandText = sProcedureName;
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }
        /// <summary>
        /// Thuc hien Insert ca bang du lieu vao database (Phai khai bao ten bang truoc)
        /// </summary>
        /// <param name="dataTable">Bang chua du lieu can luu</param>
        /// <param name="arrColumnName">Mang cac ten cot cua bang</param>
        public void PerformBulkCopy(DataTable dataTable, string[] arrColumnName)
        {
            // Open Connection
            this.Open();
            sqlBulkCopy = new SqlBulkCopy(GetDacDbConnection.ConnectionString, SqlBulkCopyOptions.FireTriggers);
            sqlBulkCopy.BulkCopyTimeout = 120;
            // Mapping Column in Table with datasource
            for(int i = 0; i < arrColumnName.Length; i++)
            {
                sqlBulkCopy.ColumnMappings.Add(arrColumnName[i], arrColumnName[i]);
            }
            sqlBulkCopy.DestinationTableName = dataTable.TableName;
            sqlBulkCopy.WriteToServer(dataTable);
            // Close Connection
            this.Close();
        }
        #endregion

        #region Backup And Restore
        public List<string> GetDatabases()
        {
            List<string> databases = new List<string>();
            this.Open();
            //sqlCommand = new SqlCommand("SELECT * FROM sys.databases d WHERE d.database_id > 4", DacDbConnection.SqlConnection);
            sqlCommand = new SqlCommand("EXEC sp_databases", DacDbConnection.SqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                databases.Add(reader[0].ToString());
            }
            this.Close();
            return databases;
        }
        public void BackupDatabase(string databaseName, string path)
        {
            this.Open();
            string sql = "BACKUP DATABASE " + databaseName + " TO DISK = '" + path + "\\" + DateTime.Now.Date.ToString("yyyyMMdd") + "_" + databaseName + ".bak'";
            sqlCommand = new SqlCommand(sql, DacDbConnection.SqlConnection);
            sqlCommand.ExecuteNonQuery();
            this.Close();
        }
        public void RestoreDatabase(string databaseName, string fileName)
        {
            this.Open();
            string sql = "ALTER DATABASE " + databaseName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            sql += "USE MASTER RESTORE DATABASE " + databaseName + " FROM DISK = '" + fileName + "' WITH REPLACE;";
            sql += "ALTER DATABASE " + databaseName + " SET MULTI_USER;";
            sqlCommand = new SqlCommand(sql, DacDbConnection.SqlConnection);
            sqlCommand.ExecuteNonQuery();
            this.Close();
        }
        #endregion
    }
}
