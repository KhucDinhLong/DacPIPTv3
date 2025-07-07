using DAC.Core.Security;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Windows.Forms;

namespace PIPT
{
    public class Common
    {
        // Ten phan mem chung cho toan bo chuong trinh
        public static string formSoftName = " - DAC PIPT 2015 " + DateTime.Now.Year;
        public static string SoftNane = "DAC PIPT 2015 - " + DateTime.Now.Year;
        public static string sExitProgram = "Bạn có muốn thoát khỏi chương trình DAC PIPT?";
        public static string sLoadingData = "Đang tải ...";
        public static string sSavingData = "Đang lưu ...";
        public static string sDeletingData = "Đang xóa ...";
        public static string sUpdatingData = "Đang update ...";
        public static string sProcessingData = "Đang xử lý ...";
        public static string ClipBoardData
        {
            get
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData == null) return string.Empty;

                if (iData.GetDataPresent(DataFormats.UnicodeText))
                    return (string)iData.GetData(DataFormats.UnicodeText);
               return string.Empty;
            }
            set { Clipboard.SetDataObject(value); }
        }
        #region Please form when invoke a method
        private WaitForm waitForm;
        public Form CurrentForm;
        public MethodInvoker CurrentFormMethodInvoker;

        public void App_ShowWaitForm(DataState dataState)
        {
            BackgroundWorker GroundWorker = new BackgroundWorker();
            GroundWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            GroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

            //you can use progresschange in order change waiting message while background working
            try
            {
                waitForm = new WaitForm();
                string sActionName = Common.sProcessingData;
                switch(dataState)
                {
                    case DataState.Insert:
                        sActionName = Common.sSavingData;
                        break;
                    case DataState.Edit:
                        sActionName = Common.sUpdatingData;
                        break;
                    case DataState.Delete:
                        sActionName = Common.sDeletingData;
                        break;
                    case DataState.Load:
                        sActionName = Common.sLoadingData;
                        break;
                    case DataState.Process:
                        sActionName = Common.sProcessingData;
                        break;
                }
                waitForm.loadingLabel.Text = sActionName;
                waitForm.Show();//use controlable form instead of poor MessageBox
                Application.DoEvents();
                GroundWorker.RunWorkerAsync();//this will run all Transmitting protocol coding at background thread

                //MessageBox.Show("Please wait. Uploading logo.", "Status");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            MethodInvoke(CurrentForm, CurrentFormMethodInvoker);
            //Thread.Sleep(500);
        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //all background work has complete and we are going to close the waiting message
            waitForm.Close();
        }
        private void MethodInvoke(Form form, MethodInvoker methodInvoker)
        {
            form.Invoke(methodInvoker);
        }
        #endregion
        #region Common function
        public static bool CheckExistCode(string Code, DevExpress.XtraGrid.Views.Grid.GridView gridView, DevExpress.XtraGrid.Columns.GridColumn gridColumn)
        {
            bool bResult = false;
            int gridViewAgencyRowCount = gridView.RowCount;
            for (int i = 0; i < gridViewAgencyRowCount; i++)
            {
                object valueCell = gridView.GetRowCellValue(i, gridColumn);
                if (valueCell.ToString() == Code)
                {
                    bResult = true;
                    break;
                }
            }
            return bResult;
        }
        private DataTable loadExcel()
        {
            string dir = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DataTable dt = new DataTable();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "xlsx";
            openFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            // browseFile.Filter = "Link Files (*.lnk)|*.lnk";

            openFileDialog1.Title = "Browse Excel file";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dir = openFileDialog1.FileName;
                string con =
              @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dir + ";" +
              @"Extended Properties='Excel 12.0;HDR=Yes;'";
                string sql = "SELECT * from [Sheet$]";
                using (OleDbConnection connection = new OleDbConnection(con))
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                    {
                        using (OleDbDataReader rdr = cmd.ExecuteReader())
                        {
                            dt.Load(rdr);
                        }
                    }
                }
            }
            return dt;
        }
        #endregion
        public sealed class RemoteHost
        {
            public static string HostName { get; set; }
            public static string HostIPAddress { get; set; }
            public static string WindowsUser { get; set; }
        }
    }
}
