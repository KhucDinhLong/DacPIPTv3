using DAC.DAL;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAC.Core
{
    public class DacProductUnitCS
    {
        public List<DacProductUnit> GetListProductUnit()
        {
            List<DacProductUnit> dacProductUnitCollection = new List<DacProductUnit>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@FactoryCode", string.Empty);
            SqlDataReader reader = dacDb.ExecuteReader("spDacProductUnit_SelectAll");

            while (reader.Read())
            {
                DacProductUnit dacProductUnit = new DacProductUnit();

                dacProductUnit.Id = (int)reader["Id"];
                dacProductUnit.Name = reader["Name"].ToString();
                dacProductUnit.Remark = reader["Remark"].ToString();

                dacProductUnitCollection.Add(dacProductUnit);
            }

            //Call Close when reading done.
            reader.Close();

            return dacProductUnitCollection;
        }
        public List<DacProductUnit> GetListProductUnit(int Id)
        {
            List<DacProductUnit> dacProductUnitCollection = new List<DacProductUnit>();
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@Id", Id);
            SqlDataReader reader = dacDb.ExecuteReader("spDacProductUnit_SelectById");

            while (reader.Read())
            {
                DacProductUnit dacProductUnit = new DacProductUnit();
                dacProductUnit.Id = (int)reader["Id"];
                dacProductUnit.Name = reader["Name"].ToString();
                dacProductUnit.Remark = reader["Remark"].ToString();

                dacProductUnitCollection.Add(dacProductUnit);
            }

            //Call Close when reading done.
            reader.Close();

            return dacProductUnitCollection;
        }
    }
}
