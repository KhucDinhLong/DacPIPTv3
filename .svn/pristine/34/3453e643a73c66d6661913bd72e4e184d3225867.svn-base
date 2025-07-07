using DAC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAC.Core
{
    public static class Inventory
    {
        public static DataTable GetInventory(string _frDate, string _toDate, string _ProductCode)
        {
            TimeSpan timeSpan;
            DateTime frDate = DateTime.Parse(_frDate);
            DateTime toDate = DateTime.Parse(_toDate);
            int iYear = frDate.Date.Year;
            string ProductCode = _ProductCode;
            DataTable dataTableInventoryStartYear = new DataTable();
            DataTable dataTableImExStock = new DataTable();
            DacDbAccess dacDb = new DacDbAccess();
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@Year", iYear);
                dacDb.AddParameter("@ProductCode", ProductCode);

                dataTableInventoryStartYear = dacDb.ExecuteDataTable("spDacInventoryStartYear");
                dataTableInventoryStartYear.TableName = "InventoryStartYear";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            DateTime TheFirstDay = DateTime.Parse(iYear + "-01-01");
            timeSpan = frDate.Date - TheFirstDay.Date;
            if (timeSpan.Days > 0)
            {
                try
                {
                    DataTable dataTable = new DataTable("ImportStockBefore");
                    dacDb.CreateNewSqlCommand();
                    // Add parameters
                    dacDb.AddParameter("@FrDate", TheFirstDay.Date.ToString("yyyy-MM-dd"));
                    dacDb.AddParameter("@ToDate", frDate.Date.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.000");
                    dacDb.AddParameter("@ProductCode", ProductCode);

                    DataTable dataTableImport = dacDb.ExecuteDataTable("spDacImportStock");
                    DataTable dataTableExport = dacDb.ExecuteDataTable("spDacExportStock");

                    dataTable = DataTableHelper.JoinTwoDataTablesOnOneColumn(dataTableImport, dataTableExport, "ProductCode", DataTableHelper.JoinType.Left);
                    // Tinh ton kho truoc ky
                    DataTable dataTableOpeningStock = DataTableHelper.JoinTwoDataTablesOnOneColumn(dataTableInventoryStartYear, dataTable, "ProductCode", DataTableHelper.JoinType.Left);
                    dataTableOpeningStock.Columns.Add(new DataColumn { ColumnName = "TonDau", DataType = typeof(double) });

                    foreach (DataRow dr in dataTableOpeningStock.Rows)
                    {
                        if (dr["Quantity"] == DBNull.Value)
                        {
                            dr["Quantity"] = 0;
                        }
                        if (dr["SL_Nhap"] == DBNull.Value)
                        {
                            dr["SL_Nhap"] = 0;
                        }
                        if (dr["SL_Xuat"] == DBNull.Value)
                        {
                            dr["SL_Xuat"] = 0;
                        }
                        dr["TonDau"] = Convert.ToDouble(dr["Quantity"]) + Convert.ToDouble(dr["SL_Nhap"]) - Convert.ToDouble(dr["SL_Xuat"]);
                    }
                    dataTableOpeningStock.Columns.Remove("Quantity");
                    dataTableOpeningStock.Columns.Remove("SL_Nhap");
                    dataTableOpeningStock.Columns.Remove("SL_Xuat");
                    // Tinh ton kho trong ky
                    dacDb.CreateNewSqlCommand();
                    // Add parameters
                    dacDb.AddParameter("@FrDate", frDate.Date.ToString("yyyy-MM-dd"));
                    dacDb.AddParameter("@ToDate", toDate.Date.ToString("yyyy-MM-dd") + " 23:59:59.000");
                    dacDb.AddParameter("@ProductCode", ProductCode);
                    dataTableImport = new DataTable();
                    dataTableExport = new DataTable();
                    dataTableImport = dacDb.ExecuteDataTable("spDacImportStock");
                    dataTableExport = dacDb.ExecuteDataTable("spDacExportStock");
                    DataTable dataTableClosingStock = DataTableHelper.JoinTwoDataTablesOnOneColumn(dataTableImport, dataTableExport, "ProductCode", DataTableHelper.JoinType.Left);

                    foreach (DataRow dr in dataTableClosingStock.Rows)
                    {
                        if (dr["SL_Nhap"] == DBNull.Value)
                        {
                            dr["SL_Nhap"] = 0;
                        }
                        if (dr["SL_Xuat"] == DBNull.Value)
                        {
                            dr["SL_Xuat"] = 0;
                        }
                    }
                    // Bang nhap xuat ton
                    dataTableImExStock = DataTableHelper.JoinTwoDataTablesOnOneColumn(dataTableClosingStock, dataTableOpeningStock, "ProductCode", DataTableHelper.JoinType.Left);

                    foreach (DataRow dr in dataTableImExStock.Rows)
                    {
                        if (dr["SL_Nhap"] == DBNull.Value)
                        {
                            dr["SL_Nhap"] = 0;
                        }
                        if (dr["SL_Xuat"] == DBNull.Value)
                        {
                            dr["SL_Xuat"] = 0;
                        }
                    }
                    dataTableImExStock.Columns.Add(new DataColumn { ColumnName = "TonCuoi", DataType = typeof(double) });
                    foreach (DataRow dr in dataTableImExStock.Rows)
                    {
                        dr["TonCuoi"] = Convert.ToDouble(dr["TonDau"]) + Convert.ToDouble(dr["SL_Nhap"]) - Convert.ToDouble(dr["SL_Xuat"]);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    // Tinh ton kho trong ky
                    dacDb.CreateNewSqlCommand();
                    // Add parameters
                    dacDb.AddParameter("@FrDate", frDate.Date.ToString("yyyy-MM-dd"));
                    dacDb.AddParameter("@ToDate", toDate.Date.ToString("yyyy-MM-dd") + " 23:59:59.000");
                    dacDb.AddParameter("@ProductCode", ProductCode);
                    DataTable dataTableImport = new DataTable();
                    DataTable dataTableExport = new DataTable();
                    dataTableImport = dacDb.ExecuteDataTable("spDacImportStock");
                    dataTableExport = dacDb.ExecuteDataTable("spDacExportStock");
                    DataTable dataTableClosingStock = DataTableHelper.JoinTwoDataTablesOnOneColumn(dataTableImport, dataTableExport, "ProductCode", DataTableHelper.JoinType.Left);

                    foreach (DataRow dr in dataTableClosingStock.Rows)
                    {
                        if (dr["SL_Xuat"] == DBNull.Value)
                        {
                            dr["SL_Xuat"] = 0;
                        }
                    }
                    // Bang nhap xuat ton
                    dataTableImExStock = DataTableHelper.JoinTwoDataTablesOnOneColumn(dataTableClosingStock, dataTableInventoryStartYear, "ProductCode", DataTableHelper.JoinType.Left);
                    dataTableImExStock.Columns.Add(new DataColumn { ColumnName = "TonCuoi", DataType = typeof(double) });
                    foreach (DataRow dr in dataTableImExStock.Rows)
                    {
                        dr["TonCuoi"] = Convert.ToDouble(dr["Quantity"]) + Convert.ToDouble(dr["SL_Nhap"]) - Convert.ToDouble(dr["SL_Xuat"]);
                    }
                    dataTableImExStock.Columns["Quantity"].ColumnName = "TonDau";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dataTableImExStock;
        }

        public static DataTable GetProduct()
        {
            DacDbAccess dacDb = new DacDbAccess();
            dacDb.CreateNewSqlCommand();
            // Add parameters
            dacDb.AddParameter("@FactoryCode", string.Empty);
            DataTable dataTable = new DataTable();
            dataTable = dacDb.ExecuteDataTable("spDacProduct_SelectAll");
            dataTable.Columns["Code"].ColumnName = "ProductCode";
            return dataTable;
        }

        public static DataTable GetInventoryByStock(string _frDate, string _toDate, string _StockID)
        {
            DateTime frDate = DateTime.Parse(_frDate);
            DateTime toDate = DateTime.Parse(_toDate);
            int thisYear = toDate.Year;
            DataTable dataTableImExStock = new DataTable();
            DataColumn colProductCode = new DataColumn("ProductCode", typeof(string));
            dataTableImExStock.Columns.Add(colProductCode);
            DataColumn colStockID = new DataColumn("StockID", typeof(string));
            dataTableImExStock.Columns.Add(colStockID);
            DataColumn colStockName = new DataColumn("StockName", typeof(string));
            dataTableImExStock.Columns.Add(colStockName);
            DataColumn colTonDau = new DataColumn("TonDau", typeof(int));
            dataTableImExStock.Columns.Add(colTonDau);
            DataColumn colSL_Nhap = new DataColumn("SL_Nhap", typeof(int));
            dataTableImExStock.Columns.Add(colSL_Nhap);
            DataColumn colSL_Xuat = new DataColumn("SL_Xuat", typeof(int));
            dataTableImExStock.Columns.Add(colSL_Xuat);
            DataColumn colTonCuoi = new DataColumn("TonCuoi", typeof(int));
            dataTableImExStock.Columns.Add(colTonCuoi);
            DacDbAccess dacDb = new DacDbAccess();
            try
            {

                Dictionary<string, int> LstInventory = new Dictionary<string, int>();

                // Lay ra ton kho cua nam nay
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@Year", thisYear);
                dacDb.AddParameter("@StockID", _StockID);
                DataTable tblInventory = dacDb.ExecuteDataTable("spDacInventoryStartYearWithStock");
                // Tinh SL ton kho tu ngay dau nam nay cho den ngay bat dau
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@FrDate", new DateTime(thisYear, 1, 1));
                dacDb.AddParameter("@ToDate", frDate.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.000");
                dacDb.AddParameter("@StockID", _StockID);
                DataTable dataTableImport = dacDb.ExecuteDataTable("spDacImportStock_Report");
                DataTable dataTableExport = dacDb.ExecuteDataTable("spDacExportStock_Report");
                // Tinh tong ton kho cho den ngay bat dau
                for (int i = 0; i < tblInventory.Rows.Count; i++)
                {
                    bool hasExists = false;
                    for (int j = 0; j < dataTableImport.Rows.Count; j++)
                    {
                        if (dataTableImport.Rows[j]["ProductCode"].ToString() == tblInventory.Rows[i]["ProductCode"].ToString()
                            && dataTableImport.Rows[j]["StockID"].ToString() == tblInventory.Rows[i]["StockID"].ToString())
                        {
                            dataTableImport.Rows[j]["SL_Nhap"] = int.Parse(dataTableImport.Rows[i]["SL_Nhap"].ToString())
                                + int.Parse(tblInventory.Rows[i]["Quantity"].ToString());
                            hasExists = true;
                        }
                    }
                    if (!hasExists)
                    {
                        DataRow newRow = dataTableImport.NewRow();
                        newRow["ProductCode"] = tblInventory.Rows[i]["ProductCode"];
                        newRow["StockID"] = tblInventory.Rows[i]["StockID"];
                        newRow["SL_Nhap"] = tblInventory.Rows[i]["Quantity"];
                        dataTableImport.Rows.Add(newRow);
                    }
                }
                // Add vao list ton dau theo dang <ProductCode-StockID, TonDau>
                string DataKey;
                for (int i = 0; i < dataTableImport.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTableExport.Rows.Count; j++)
                    {
                        if (dataTableImport.Rows[i]["ProductCode"].ToString() == dataTableExport.Rows[j]["ProductCode"].ToString()
                            && dataTableImport.Rows[i]["StockID"].ToString() == dataTableExport.Rows[j]["StockID"].ToString())
                        {
                            DataKey = dataTableImport.Rows[i]["ProductCode"].ToString() + "-" + dataTableImport.Rows[i]["StockID"].ToString();
                            int IventoryQuantity = int.Parse(dataTableImport.Rows[i]["SL_Nhap"].ToString())
                                - int.Parse(dataTableExport.Rows[j]["SL_Xuat"].ToString());
                            LstInventory.Add(DataKey, IventoryQuantity);
                        }
                    }
                    DataKey = dataTableImport.Rows[i]["ProductCode"].ToString() + "-" + dataTableImport.Rows[i]["StockID"].ToString();
                    if (!LstInventory.ContainsKey(DataKey))
                        LstInventory.Add(DataKey, int.Parse(dataTableImport.Rows[i]["SL_Nhap"].ToString()));
                }
                //Lay ra SL nhap xuat trong khoang thoi gian
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@FrDate", frDate);
                dacDb.AddParameter("@ToDate", toDate);
                dacDb.AddParameter("@StockID", _StockID);
                dataTableImport = new DataTable();
                dataTableExport = new DataTable();
                dataTableImport = dacDb.ExecuteDataTable("spDacImportStock_Report");
                dataTableExport = dacDb.ExecuteDataTable("spDacExportStock_Report");
                // Them du lieu nhap kho
                foreach (var item in dataTableImport.AsEnumerable())
                {
                    DataRow row = dataTableImExStock.NewRow();
                    row["ProductCode"] = item["ProductCode"];
                    row["StockID"] = item["StockID"];
                    row["StockName"] = item["Name"];
                    row["SL_Nhap"] = item["SL_Nhap"];
                    row["SL_Xuat"] = 0;
                    dataTableImExStock.Rows.Add(row);
                }
                // Them du lieu xuat kho
                List<string> LstDataFinish = new List<string>();
                for (int i = 0; i < dataTableImExStock.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTableExport.Rows.Count; j++)
                    {
                        if (dataTableImExStock.Rows[i]["ProductCode"].ToString() == dataTableExport.Rows[j]["ProductCode"].ToString()
                            && dataTableImExStock.Rows[i]["StockID"].ToString() == dataTableExport.Rows[j]["StockID"].ToString())
                        {
                            dataTableImExStock.Rows[i]["SL_Xuat"] = dataTableExport.Rows[j]["SL_Xuat"];
                            LstDataFinish.Add(dataTableExport.Rows[j]["ProductCode"] + "-" + dataTableExport.Rows[j]["StockID"]);
                        }
                    }
                }
                foreach (var item in dataTableExport.AsEnumerable())
                {
                    string dataKey = item["ProductCode"] + "-" + item["StockID"];
                    if (!LstDataFinish.Contains(dataKey))
                    {
                        DataRow row = dataTableImExStock.NewRow();
                        row["ProductCode"] = item["ProductCode"];
                        row["StockID"] = item["StockID"];
                        row["StockName"] = item["Name"];
                        row["SL_Nhap"] = 0;
                        row["SL_Xuat"] = item["SL_Xuat"];
                        dataTableImExStock.Rows.Add(row);
                    }
                }
                // Them du lieu ton kho
                foreach (string key in LstInventory.Keys)
                {
                    bool hasExists = false;
                    for (int i = 0; i < dataTableImExStock.Rows.Count; i++)
                    {
                        DataKey = dataTableImExStock.Rows[i]["ProductCode"] + "-" + dataTableImExStock.Rows[i]["StockID"];
                        if (key == DataKey)
                            hasExists = true;
                    }
                    if (!hasExists && LstInventory[key] != 0)
                    {
                        DataRow row = dataTableImExStock.NewRow();
                        string[] arr = key.Split('-');
                        row["ProductCode"] = arr[0];
                        row["StockID"] = arr[1];
                        DacStockCS stockCS = new DacStockCS();
                        row["StockName"] = stockCS.GetNameByCode(arr[1]);
                        row["SL_Nhap"] = 0;
                        row["SL_Xuat"] = 0;
                        row["TonDau"] = LstInventory[key];
                        row["TonCuoi"] = LstInventory[key];
                        dataTableImExStock.Rows.Add(row);
                    }
                }
                foreach (DataRow row in dataTableImExStock.Rows)
                {
                    string dataKey = row["ProductCode"] + "-" + row["StockID"];
                    row["TonDau"] = LstInventory.Keys.Contains(dataKey) ? LstInventory[dataKey] : 0;
                    row["TonCuoi"] = int.Parse(row["TonDau"].ToString())
                        + int.Parse(row["SL_Nhap"].ToString()) - int.Parse(row["SL_Xuat"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataTableImExStock;
        }

        public static DataTable GetInventoryInThisYear(string _frDate, string _StockID)
        {
            DateTime frDate = DateTime.Parse(_frDate);
            int iYear = frDate.Date.Year;
            string ProductCode = _StockID;
            DataTable dataTableInventoryInThisYear = new DataTable();
            DataTable dataTableExportStockInThisYear = new DataTable();
            DacDbAccess dacDb = new DacDbAccess();
            DataTable dataTableOpeningStock = new DataTable("InventoryStock");
            try
            {
                dacDb.CreateNewSqlCommand();
                // Add parameters
                dacDb.AddParameter("@Year", iYear);
                dacDb.AddParameter("@StockID", ProductCode);

                dataTableInventoryInThisYear = dacDb.ExecuteDataTable("spDacInventoryInThisYear");
                dataTableExportStockInThisYear = dacDb.ExecuteDataTable("spDacExportStockInThisYear");

                dataTableOpeningStock = GetDataInventory(dataTableInventoryInThisYear, dataTableExportStockInThisYear, "KeyId");
                // Tinh ton kho truoc ky
                dataTableOpeningStock.Columns.Add(new DataColumn { ColumnName = "TonCuoi", DataType = typeof(double) });

                foreach (DataRow dr in dataTableOpeningStock.Rows)
                {
                    if (dr["SL_Nhap"] == DBNull.Value)
                    {
                        dr["SL_Nhap"] = 0;
                    }
                    if (dr["SL_Xuat"] == DBNull.Value)
                    {
                        dr["SL_Xuat"] = 0;
                    }
                    dr["TonCuoi"] = Convert.ToDouble(dr["SL_Nhap"]) - Convert.ToDouble(dr["SL_Xuat"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTableOpeningStock;
        }

        private static DataTable GetDataInventory(DataTable dataTableInventoryInThisYear, DataTable dataTableExportStockInThisYear, string Key)
        {
            //Change column name to a temp name so the LINQ for getting row data will work properly.
            string strTempColName = Key + "_2";
            if (dataTableExportStockInThisYear.Columns.Contains(Key))
                dataTableExportStockInThisYear.Columns[Key].ColumnName = strTempColName;

            //Get columns from dtblLeft
            DataTable dtblResult = dataTableInventoryInThisYear.Clone();

            //Get columns from dtblRight
            var dt2Columns = dataTableExportStockInThisYear.Columns.OfType<DataColumn>().Select(dc => new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping));

            //Get columns from dtblRight that are not in dtblLeft
            var dt2FinalColumns = from dc in dt2Columns.AsEnumerable()
                                  where !dtblResult.Columns.Contains(dc.ColumnName)
                                  select dc;

            //Add the rest of the columns to dtblResult
            dtblResult.Columns.AddRange(dt2FinalColumns.ToArray());

            //No reason to continue if the colToJoinOn does not exist in both DataTables.
            if (!dataTableInventoryInThisYear.Columns.Contains(Key) 
                || (!dataTableExportStockInThisYear.Columns.Contains(Key) 
                && !dataTableExportStockInThisYear.Columns.Contains(strTempColName)))
            {
                if (!dtblResult.Columns.Contains(Key))
                    dtblResult.Columns.Add(Key);
                return dtblResult;
            }
            var leftJoin = from rowLeft in dataTableInventoryInThisYear.AsEnumerable()
                           join rowRight in dataTableExportStockInThisYear.AsEnumerable() on rowLeft[Key] equals rowRight[strTempColName] into gj
                           from subRight in gj.DefaultIfEmpty()
                           select rowLeft.ItemArray.Concat((subRight == null) ? (dataTableExportStockInThisYear.NewRow().ItemArray) : subRight.ItemArray).ToArray();
            var tmpLeft = from left in leftJoin
                          select new
                          {
                              KeyId = left.GetValue(0),
                              InvenProductCode = left.GetValue(1),
                              SL_Nhap = left.GetValue(2),
                              InvenStockID = left.GetValue(3),
                              Name = left.GetValue(4),
                              KeyId_2 = left.GetValue(5),
                              ProductCode = left.GetValue(6),
                              SL_Xuat = left.GetValue(7),
                              StockID = left.GetValue(8)
                          };
            var rightJoin = from rowRight in dataTableExportStockInThisYear.AsEnumerable()
                            join rowLeft in dataTableInventoryInThisYear.AsEnumerable() on rowRight[strTempColName] equals rowLeft[Key] into gj
                            from subLeft in gj.DefaultIfEmpty()
                            select rowRight.ItemArray.Concat((subLeft == null) ? (dataTableInventoryInThisYear.NewRow().ItemArray) : subLeft.ItemArray).ToArray();
            var tmpRight = from right in rightJoin
                           select new
                           {
                               KeyId = right.GetValue(4),
                               InvenProductCode = right.GetValue(5),
                               SL_Nhap = right.GetValue(6),
                               InvenStockID = right.GetValue(7),
                               Name = right.GetValue(8),
                               KeyId_2 = right.GetValue(0),
                               ProductCode = right.GetValue(1),
                               SL_Xuat = right.GetValue(2),
                               StockID = right.GetValue(3)
                           };
            var rowDataOuter = tmpLeft.Union(tmpRight);
            foreach (var values in rowDataOuter)
            {
                DataRow row = dtblResult.NewRow();
                row["KeyId"] = values.KeyId;
                row["InvenProductCode"] = values.InvenProductCode;
                row["SL_Nhap"] = values.SL_Nhap;
                row["InvenStockID"] = values.InvenStockID;
                row["Name"] = values.Name;
                row["KeyId_2"] = values.KeyId_2;
                row["ProductCode"] = values.ProductCode;
                row["SL_Xuat"] = values.SL_Xuat;
                row["StockID"] = values.StockID;
                dtblResult.Rows.Add(row);
            }
            return dtblResult;
        }
    }
}
