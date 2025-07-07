using System.Data;
using System.Linq;

namespace DAC.Core
{
    public static class DataTableHelper
    {
        public enum JoinType
        {
            /// <summary>
            /// Tuong tu nhu join co ban. Thu tuc join chi so khop trong ca hai bang Table A va Table B.
            /// </summary>
            Inner = 0,
            /// <summary>
            /// Tuong tu nhu join ngoai. Thu thu join ngoai thiet lap tat ca cac ban ghi tu Table A, voi cac ban ghi co trong bang Table B. Neu khong khop, phia ben phai se la null.
            /// </summary>
            Left = 1
        }

        public static DataTable JoinTwoDataTablesOnOneColumn(DataTable dataTableLeft, DataTable dataTableRight, string colToJoinOn, JoinType joinType)
        {
            //Change column name to a temp name so the LINQ for getting row data will work properly.
            string strTempColName = colToJoinOn + "_2";
            if (dataTableRight.Columns.Contains(colToJoinOn))
                dataTableRight.Columns[colToJoinOn].ColumnName = strTempColName;

            //Get columns from dtblLeft
            DataTable dtblResult = dataTableLeft.Clone();

            //Get columns from dtblRight
            var dt2Columns = dataTableRight.Columns.OfType<DataColumn>().Select(dc => new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping));

            //Get columns from dtblRight that are not in dtblLeft
            var dt2FinalColumns = from dc in dt2Columns.AsEnumerable()
                                  where !dtblResult.Columns.Contains(dc.ColumnName)
                                  select dc;

            //Add the rest of the columns to dtblResult
            dtblResult.Columns.AddRange(dt2FinalColumns.ToArray());

            //No reason to continue if the colToJoinOn does not exist in both DataTables.
            if (!dataTableLeft.Columns.Contains(colToJoinOn) || (!dataTableRight.Columns.Contains(colToJoinOn) && !dataTableRight.Columns.Contains(strTempColName)))
            {
                if (!dtblResult.Columns.Contains(colToJoinOn))
                    dtblResult.Columns.Add(colToJoinOn);
                return dtblResult;
            }

            switch (joinType)
            {
                default:
                case JoinType.Inner:
                    #region Inner
                    //get row data
                    //To use the DataTable.AsEnumerable() extension method you need to add a reference to the System.Data.DataSetExtension assembly in your project. 
                    var rowDataLeftInner = from rowLeft in dataTableLeft.AsEnumerable()
                                           join rowRight in dataTableRight.AsEnumerable() on rowLeft[colToJoinOn] equals rowRight[strTempColName]
                                           select rowLeft.ItemArray.Concat(rowRight.ItemArray).ToArray();

                    //Add row data to dtblResult
                    foreach (object[] values in rowDataLeftInner)
                        dtblResult.Rows.Add(values);
                    #endregion
                    break;
                case JoinType.Left:
                    #region Left
                    var rowDataLeftOuter = from rowLeft in dataTableLeft.AsEnumerable()
                                           join rowRight in dataTableRight.AsEnumerable() on rowLeft[colToJoinOn] equals rowRight[strTempColName] into gj
                                           from subRight in gj.DefaultIfEmpty()
                                           select rowLeft.ItemArray.Concat((subRight == null) ? (dataTableRight.NewRow().ItemArray) : subRight.ItemArray).ToArray();

                    //Add row data to dtblResult
                    foreach (object[] values in rowDataLeftOuter)
                        dtblResult.Rows.Add(values);
                    #endregion
                    break;
            }

            //Change column name back to original
            dataTableRight.Columns[strTempColName].ColumnName = colToJoinOn;

            //Remove extra column from result
            dtblResult.Columns.Remove(strTempColName);

            return dtblResult;
        }
        public static DataTable JoinTwoDataTablesOnMultiColumn(DataTable dataTableLeft, DataTable dataTableRight, string[] colToJoinOn, JoinType joinType)
        {
            //Create columns for result table
            DataTable dtblResult = new DataTable();
            foreach (DataColumn col in dataTableLeft.Columns)
            {
                if (!dtblResult.Columns.Contains(col.ColumnName))
                {
                    DataColumn newCol = new DataColumn();
                    newCol.ColumnName = col.ColumnName;
                    newCol.DataType = col.DataType;
                    newCol.Expression = col.Expression;
                    dtblResult.Columns.Add(newCol);
                }
            }

            foreach (DataColumn col in dataTableRight.Columns)
            {
                if (!dtblResult.Columns.Contains(col.ColumnName))
                {
                    DataColumn newCol = new DataColumn();
                    newCol.ColumnName = col.ColumnName;
                    newCol.DataType = col.DataType;
                    newCol.Expression = col.Expression;
                    dtblResult.Columns.Add(newCol);
                }
            }

            //No reason to continue if the colToJoinOn does not exist in both DataTables.
            foreach (string item in colToJoinOn)
            {
                if (!dataTableLeft.Columns.Contains(item) || !dataTableRight.Columns.Contains(item))
                {
                    return dtblResult;
                }
            }

            switch (joinType)
            {
                default:
                case JoinType.Inner:
                    #region Inner
                    //get row data
                    //To use the DataTable.AsEnumerable() extension method you need to add a reference to the System.Data.DataSetExtension assembly in your project. 
                    var rowDataLeftInner = from rowLeft in dataTableLeft.AsEnumerable()
                                           join rowRight in dataTableRight.AsEnumerable() on
                                           new { rowLeftCon = rowLeft[colToJoinOn[0]], rowLeftCon2 = rowLeft[colToJoinOn[1]] } equals
                                           new { rowLeftCon = rowRight[colToJoinOn[0]], rowLeftCon2 = rowRight[colToJoinOn[1]] }
                                           select rowLeft.ItemArray.Concat(rowRight.ItemArray).ToArray();
                    //Add row data to dtblResult
                    foreach (object[] values in rowDataLeftInner)
                        dtblResult.Rows.Add(values);

                    #endregion
                    break;
                case JoinType.Left:
                    #region Left
                    var rowDataLeftOuter = from rowLeft in dataTableLeft.AsEnumerable()
                                           join rowRight in dataTableRight.AsEnumerable() on
                                           new { rowLeftCon = rowLeft[colToJoinOn[0]], rowLeftCon2 = rowLeft[colToJoinOn[1]] } equals
                                           new { rowLeftCon = rowRight[colToJoinOn[0]], rowLeftCon2 = rowRight[colToJoinOn[1]] } into gj
                                           from subRight in gj.DefaultIfEmpty()
                                           select rowLeft.ItemArray.Concat((subRight == null) ? (dataTableRight.NewRow().ItemArray) : subRight.ItemArray).ToArray();

                    //Add row data to dtblResult
                    foreach (object[] values in rowDataLeftOuter)
                        dtblResult.Rows.Add(values);
                    #endregion
                    break;
            }

            return dtblResult;
        }
    }
}
