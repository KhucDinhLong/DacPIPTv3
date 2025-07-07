using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PIPT
{
    public class ExcelDataTransformService
    {
        #region Private members
        
		private string _fileName;
		private string _provider = "Provider=Microsoft.Jet.OLEDB.4.0;";
		private string _dataSourceString = "Data Source=";
		private string _dataSourceType = ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1;ReadOnly:=false;UpdateLinks:=0\"";
        //"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + oFileDialog.FileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1;ReadOnly:=false;UpdateLinks:=0\""
        //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + oFileDialog.FileName + ";Extended Properties=Excel 12.0;"
		#endregion

        public ExcelDataTransformService()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public string FileName
		{
			get{ return _fileName; }
			set{ _fileName = value; }
		}

		public string ConnectionString
		{
			get
			{
				if(FileName == "") throw new NoNullAllowedException("Bạn phải nhập tên file!");
                if (FileName.Contains("xlsx"))
                {
                    _provider = "Provider=Microsoft.ACE.OLEDB.16.0;";
                    _dataSourceType = ";Extended Properties=\"Excel 16.0;\"";
                }
				return _provider + _dataSourceString + FileName + _dataSourceType; 
			}
		}

        /// <summary>
		/// Trả về các bảng(table)/sheet trong file DataSource
		/// </summary>
		/// <returns></returns>
		public DataTable GetSheetNames()
		{
			DataTable dtSheets = null;

			using (OleDbConnection oledbConn = new OleDbConnection(ConnectionString))
			{
				try
				{
					oledbConn.Open();

					//Trả về các sheet có trong file excel
					dtSheets = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[]{null, null, null, "TABLE"});
				}
				catch(Exception exc)
				{
					throw new Exception(exc.Message);
				}
				finally
				{
					if(oledbConn != null)
						oledbConn.Close();
				}
			}
			return dtSheets;
		}

        public DataSet GetDataImport(string sheetName)
		{
            DataSet dtDataImport = new DataSet();
			bool isValid = false;

			foreach(DataRow r in GetSheetNames().Rows)
			{
				if(r[2].ToString() == sheetName)
				{
					isValid = true;
					break;
				}
			}

			if(!isValid)
			{
				throw new Exception("Tên Sheet không tồn tại trong file.");
			}

			string selectCommand = "SELECT * FROM [" + sheetName + "]";
			using (OleDbConnection oledbConn = new OleDbConnection(ConnectionString))
			{
				try
				{
					oledbConn.Open();

					//Mở dữ liệu trong sheet được chọn và đổ vào DataTable
					OleDbDataAdapter oleDataAdapter = new OleDbDataAdapter(selectCommand, oledbConn);
					oleDataAdapter.Fill(dtDataImport, sheetName);
					oleDataAdapter.Dispose();
				}
				catch(Exception exc)
				{
					throw new Exception(exc.Message);
				}
				finally
				{
					if(oledbConn != null)
					oledbConn.Close();
				}
			}			
			return dtDataImport;
		}

        /// <summary>
        /// Xuat du lieu tu Grid ra File csv
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="fileName"></param>
        /// <param name="convertTexts"></param>
        public void ExportToCsv(DataGridView dataGridView, string fileName, int[] convertTexts)
        {
            string stOutput = String.Empty;
            // Export titles:
            string sHeaders = String.Empty;

            for (int j = 0; j < dataGridView.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dataGridView.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dataGridView.Rows[i].Cells.Count; j++)
                {
                    string sValue = Convert.ToString(dataGridView.Rows[i].Cells[j].Value);
                    if (this.BeInArray(convertTexts, j))
                    {
                        sValue = "'" + sValue;
                    }
                    stLine = stLine.ToString() + sValue + "\t";
                }
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// Kiem tra mot so nguyen iCheck co nam trong mang hay khong
        /// </summary>
        /// <param name="convertTexts"></param>
        /// <param name="iCheck"></param>
        /// <returns></returns>
        private bool BeInArray(int[] convertTexts, int iCheck)
        {
            bool bResult = false;
            if (convertTexts.Length > 0)
            {
                for (int i = 0; i < convertTexts.Length; i++)
                {
                    if (iCheck == convertTexts[i])
                    {
                        bResult = true;
                        break;
                    }
                }
            }
            else
            {
                bResult = false;
            }
            return bResult;
        }

        /* Ham xuat ra file excel dung Microsoft.Office.Interop.Excel COM
        public static void ExportToExcel(DataGridView dgView)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            try
            {
                // instantiating the excel application class
                object misValue = System.Reflection.Missing.Value;
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook currentWorkbook = excelApp.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet currentWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)currentWorkbook.ActiveSheet;
                currentWorksheet.Columns.ColumnWidth = 18;
                if (dgView.Rows.Count > 0)
                {
                    currentWorksheet.Cells[1, 1] = DateTime.Now.ToString("s");
                    int i = 1;
                    foreach (DataGridViewColumn dgviewColumn in dgView.Columns)
                    {
                        // Excel work sheet indexing starts with 1
                        currentWorksheet.Cells[2, i] = dgviewColumn.Name;
                        ++i;
                    }
                    Microsoft.Office.Interop.Excel.Range headerColumnRange = currentWorksheet.get_Range("A2", "G2");
                    headerColumnRange.Font.Bold = true;
                    headerColumnRange.Font.Color = 0xFF0000;
                    //headerColumnRange.EntireColumn.AutoFit();
                    int rowIndex = 0;
                    for (rowIndex = 0; rowIndex < dgView.Rows.Count; rowIndex++)
                    {
                        DataGridViewRow dgRow = dgView.Rows[rowIndex];
                        for (int cellIndex = 0; cellIndex < dgRow.Cells.Count; cellIndex++)
                        {
                            currentWorksheet.Cells[rowIndex + 3, cellIndex + 1] = dgRow.Cells[cellIndex].Value;
                        }
                    }
                    Microsoft.Office.Interop.Excel.Range fullTextRange = currentWorksheet.get_Range("A1", "G" + (rowIndex + 1).ToString());
                    fullTextRange.WrapText = true;
                    fullTextRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
                else
                {
                    string timeStamp = DateTime.Now.ToString("s");
                    timeStamp = timeStamp.Replace(':', '-');
                    timeStamp = timeStamp.Replace("T", "__");
                    currentWorksheet.Cells[1, 1] = timeStamp;
                    currentWorksheet.Cells[1, 2] = "No error occured";
                }
                using (SaveFileDialog exportSaveFileDialog = new SaveFileDialog())
                {
                    exportSaveFileDialog.Title = "Select Excel File";
                    exportSaveFileDialog.Filter = "Microsoft Office Excel Workbook(*.xlsx)|*.xlsx";

                    if (DialogResult.OK == exportSaveFileDialog.ShowDialog())
                    {
                        string fullFileName = exportSaveFileDialog.FileName;
                        // currentWorkbook.SaveCopyAs(fullFileName);
                        // indicating that we already saved the workbook, otherwise call to Quit() will pop up
                        // the save file dialogue box

                        currentWorkbook.SaveAs(fullFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, misValue, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, misValue, misValue, misValue);
                        currentWorkbook.Saved = true;
                        MessageBox.Show("Exported successfully", "Exported to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (excelApp != null)
                {
                    excelApp.Quit();
                }
            }
        } */
    }
}
