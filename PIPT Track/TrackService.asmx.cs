using System.Data;
using System.Web.Services;
using DAC.DAL;

namespace PIPT.Track
{
    /// <summary>
    /// Summary description for TrackService
    /// </summary>
    [WebService(Namespace = "http://temchonggia.com.vn/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TrackService : System.Web.Services.WebService
    {
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Xml)]
        public string TrackAgency(string DacCode)
        {
            string ProductCode = "";
            DAC.DAL.GetDacDbConnection.ConnectionString = (System.Configuration.ConfigurationManager.ConnectionStrings["DacDBConn"].ConnectionString);
            DacDbAccess dacDb = new DacDbAccess();
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            dacDb.CreateNewSqlCommand();
            dacDb.AddParameter("@DacCode", DacCode);
            dataTable = dacDb.ExecuteDataTable("dbo.spDacDistributeToAgency_SelectDacCode");
            if (dataTable.Rows.Count > 0)
            {
                DataRow dataRow = dataTable.Rows[0];
                ProductCode = dataRow["ProductCode"].ToString();
                dataTable.TableName = "Agency";
                this.AddValueInDataRow(dataTable);
                ds.Tables.Add(dataTable);
            }
            dataTable = dacDb.ExecuteDataTable("dbo.spDacDistributeToStore_SelectDacCode");
            if (dataTable.Rows.Count > 0)
            {
                DataRow dataRow = dataTable.Rows[0];
                ProductCode = dataRow["ProductCode"].ToString();
                dataTable.TableName = "Store";
                this.AddValueInDataRow(dataTable);
                ds.Tables.Add(dataTable);
            }
            if (ProductCode.Length != 0)
            {
                dacDb.CreateNewSqlCommand();
                dacDb.AddParameter("@Code", ProductCode);
                dacDb.AddParameter("@Name", string.Empty);
                dataTable = dacDb.ExecuteDataTable("spDacProduct_SelectByCode");
                dataTable.TableName = "Product";
                this.AddValueInDataRow(dataTable);
                ds.Tables.Add(dataTable);
            }
            if (ds.Tables.Count == 0)
                return "noResult";
            return ds.GetXml();
        }
        /// <summary>
        /// Tim cell co gia tri null hoac rong de sua lai.
        /// </summary>
        /// <param name="dataTable"></param>
        private void AddValueInDataRow(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                if (dataTable.Rows[0][i] == null)
                {
                    dataTable.Rows[0][i] = "...";
                }
                else
                {
                    if (dataTable.Rows[0][i].ToString() == string.Empty)
                    {
                        dataTable.Rows[0][i] = "...";
                    }
                }
            }
        }
    }
}
