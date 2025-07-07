using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacContainerCS
    {
        public List<DacContainer> GetListContainer(DateTime FrDate, DateTime ToDate, string ContainerCode, string ProductCode)
        {
            List<DacContainer> dacContainerCollection = new List<DacContainer>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FrDate", FrDate);
            dacDb.AddParameter("@ToDate", ToDate);
            dacDb.AddParameter("@ContainerCode", ContainerCode);
            dacDb.AddParameter("@ProductCode", ProductCode);
            SqlDataReader reader = dacDb.ExecuteReader("spDacContainer_Select");
            while (reader.Read())
            {
                DacContainer dacContainer = new DacContainer();

                dacContainer.ID = (int)reader["ID"];
                dacContainer.CreatedDate = (DateTime)reader["CreatedDate"];
                dacContainer.ContainerCode = reader["ContainerCode"].ToString();
                dacContainer.ProductCode = reader["ProductCode"].ToString();
                dacContainer.Quantity = (int)reader["Quantity"];
                dacContainer.Description = reader["Description"].ToString();
                dacContainer.Active = (bool)reader["Active"];

                dacContainerCollection.Add(dacContainer);
            }

            // Call Close when reading done
            reader.Close();

            return dacContainerCollection;
        }

        public static string GetMaxContainer()
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@Year", DateTime.Now.Year);
            int sMaxContainerCode = Convert.ToInt32(dacDb.ExecuteScalar("spGetMaxContainer"));
            if (sMaxContainerCode == 0)
            {
                return String.Format("CON{0}{1:00000}", DateTime.Now.Year.ToString().Substring(2, 2), 1);
            }
            else
            {
                sMaxContainerCode += 1;
                return String.Format("CON{0:0000000}", sMaxContainerCode);
            }
        }

        public bool Insert(DacContainer Container, ref int iNewID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@CreatedDate", Container.CreatedDate);
                dacDb.AddParameter("@ContainerCode", Container.ContainerCode);
                dacDb.AddParameter("@ProductCode", Container.ProductCode);
                dacDb.AddParameter("@Quantity", Container.Quantity);
                dacDb.AddParameter("@Description", Container.Description);
                dacDb.AddParameter("@Active", Container.Active);
                dacDb.AddParameter("@NewID", SqlDbType.Int);
                if (dacDb.ExecuteNonQuery("spDacContainer_Insert") > 0)
                {
                    iNewID = Convert.ToInt32(dacDb.sqlCommand.Parameters["@NewID"].Value);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(DacContainer Container)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", Container.ID);
                dacDb.AddParameter("@CreatedDate", Container.CreatedDate);
                dacDb.AddParameter("@ContainerCode", Container.ContainerCode);
                dacDb.AddParameter("@ProductCode", Container.ProductCode);
                dacDb.AddParameter("@Quantity", Container.Quantity);
                dacDb.AddParameter("@Description", Container.Description);
                dacDb.AddParameter("@Active", Container.Active);

                dacDb.ExecuteNonQuery("spDacContainer_Update");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(int iID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", iID);

                dacDb.ExecuteNonQuery("spDacContainer_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

