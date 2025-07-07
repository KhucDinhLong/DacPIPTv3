using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAC.Core
{
    public class DacPackageDetailsCS
    {
        //spDacPackageDetails_SelectByPackageId (PackageID)
        public List<DacPackageDetails> GetPackageDetails(int iPackageID)
        {
            List<DacPackageDetails> dacPackageDetailsCollection = new List<DacPackageDetails>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@PackageId", iPackageID);
            SqlDataReader reader = dacDb.ExecuteReader("spDacPackageDetails_SelectByPackageId");
            while (reader.Read())
            {
                DacPackageDetails dacPackageDetails = new DacPackageDetails();

                dacPackageDetails.Id = (int)reader["Id"];
                dacPackageDetails.PackageId = (int)reader["PackageId"];
                dacPackageDetails.DacCode = reader["DacCode"].ToString();

                dacPackageDetailsCollection.Add(dacPackageDetails);
            }

            // Call Close when reading done
            reader.Close();

            return dacPackageDetailsCollection;
        }

        //spDacPackageDetails_SelectByDacCode (DacCode)
        public List<DacPackageDetails> GetPackageDetails(string sDacCode)
        {
            List<DacPackageDetails> dacPackageDetailsCollection = new List<DacPackageDetails>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@DacCode", sDacCode);
            SqlDataReader reader = dacDb.ExecuteReader("spDacPackageDetails_SelectByDacCode");
            while (reader.Read())
            {
                DacPackageDetails dacPackageDetails = new DacPackageDetails();

                dacPackageDetails.Id = (int)reader["Id"];
                dacPackageDetails.PackageId = (int)reader["PackageId"];
                dacPackageDetails.DacCode = reader["DacCode"].ToString();

                dacPackageDetailsCollection.Add(dacPackageDetails);
            }

            // Call Close when reading done
            reader.Close();

            return dacPackageDetailsCollection;
        }

        //spDacPackageDetails_SelectByPackageCode (PackageCode)
        //spDacPackageDetails_SelectByContainerCode (ContainerCode)
        public List<DacPackageDetails> GetPackageDetails(string sDacCode, string PackageType)
        {
            List<DacPackageDetails> dacPackageDetailsCollection = new List<DacPackageDetails>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            string package = CommonBO.GetSecConfig("AutoIncreasePackage").Pattern;
            StringBuilder PackageKeyword = new StringBuilder();
            foreach (char item in package.ToCharArray())
            {
                if (char.IsLetter(item))
                    PackageKeyword.Append(item);
            }
            string container = CommonBO.GetSecConfig("AutoIncreaseContainer").Pattern;
            StringBuilder ContainerKeyword = new StringBuilder();
            foreach (char item in container.ToCharArray())
            {
                if (char.IsLetter(item))
                    ContainerKeyword.Append(item);
            }
            SqlDataReader reader = null;
            if (PackageType == PackageKeyword.ToString())
            {
                dacDb.AddParameter("@PackageCode", sDacCode);

                reader = dacDb.ExecuteReader("spDacPackageDetails_SelectByPackageCode");
                while (reader.Read())
                {
                    DacPackageDetails dacPackageDetails = new DacPackageDetails();

                    dacPackageDetails.Id = (int)reader["Id"];
                    dacPackageDetails.PackageId = (int)reader["PackageId"];
                    dacPackageDetails.DacCode = reader["DacCode"].ToString();

                    dacPackageDetailsCollection.Add(dacPackageDetails);
                }
                // Call Close when reading done
                reader.Close();
            }
            if (PackageType == ContainerKeyword.ToString())
            {
                dacDb.AddParameter("@ContainerCode", sDacCode);
                reader = dacDb.ExecuteReader("spDacPackageDetails_SelectByContainerCode");
                while (reader.Read())
                {
                    DacPackageDetails dacPackageDetails = new DacPackageDetails();

                    dacPackageDetails.Id = (int)reader["Id"];
                    dacPackageDetails.PackageId = (int)reader["PackageId"];
                    dacPackageDetails.DacCode = reader["DacCode"].ToString();

                    dacPackageDetailsCollection.Add(dacPackageDetails);
                }
                // Call Close when reading done
                reader.Close();
            }
            //switch (PackageType)
            //{
            //    case "PKG":
            //        dacDb.AddParameter("@PackageCode", sDacCode);
            //        SqlDataReader reader 
            //            = dacDb.ExecuteReader("spDacPackageDetails_SelectByPackageCode");
            //        while (reader.Read())
            //        {
            //            DacPackageDetails dacPackageDetails = new DacPackageDetails();

            //            dacPackageDetails.ID = (int)reader["ID"];
            //            dacPackageDetails.PackageId = (int)reader["PackageId"];
            //            dacPackageDetails.DacCode = reader["DacCode"].ToString();
            //            dacPackageDetails.ProductCode = reader["ProductCode"].ToString();

            //            dacPackageDetailsCollection.Add(dacPackageDetails);
            //        }
            //        // Call Close when reading done
            //        reader.Close();
            //        break;
            //    case "CON":
            //        dacDb.AddParameter("@ContainerCode", sDacCode);
            //        reader = dacDb.ExecuteReader("spDacPackageDetails_SelectByContainerCode");
            //        while (reader.Read())
            //        {
            //            DacPackageDetails dacPackageDetails = new DacPackageDetails();

            //            dacPackageDetails.ID = (int)reader["ID"];
            //            dacPackageDetails.PackageId = (int)reader["PackageId"];
            //            dacPackageDetails.DacCode = reader["DacCode"].ToString();
            //            dacPackageDetails.ProductCode = reader["ProductCode"].ToString();

            //            dacPackageDetailsCollection.Add(dacPackageDetails);
            //        }
            //        // Call Close when reading done
            //        reader.Close();
            //        break;
            //}

            return dacPackageDetailsCollection;
        }

        //spDacPackageDetails_Insert (PackageId, DacCode)
        public bool Insert(DacPackageDetails packageDetails)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@PackageId", packageDetails.PackageId);
                dacDb.AddParameter("@DacCode", packageDetails.DacCode);

                dacDb.ExecuteNonQuery("spDacPackageDetails_Insert");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //spDacPackageDetails_Delete (ID)
        public bool Delete(long iID)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@ID", iID);

                dacDb.ExecuteNonQuery("spDacPackageDetails_Delete");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //spDacPackageDetails_DeleteByDacCode (DacCode)
        public bool Delete(string sDacCode)
        {
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@DacCode", sDacCode);

                dacDb.ExecuteNonQuery("spDacPackageDetails_DeleteByDacCode");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
