using DAC.Core;
using DAC.Core.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Net.Http;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace PIPT.Agency
{
    public class Common
    {
        // Ten phan mem chung cho toan bo chuong trinh
        public static string formSoftName = " - DAC PIPT " + DateTime.Now.Year;
        public static string SoftName = "DAC PIPT 2015 - " + DateTime.Now.Year;
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

        #region Get Data From Server
        public void GetUpdateDataFromServer()
        {
            // Kiem tra neu co ket noi internet thi thuc hien cap nhat
            if(InternetConnection.IsInternetConnected())
            {
                // Cap nhat danh muc moi
                this.GetUpdateCatalogue();
                Thread.Sleep(1000);
                // Cap nhat danh muc san pham moi
                this.GetUpdateProduct();
                Thread.Sleep(1000);
                // Cap nhat danh muc cua hang / nha thuoc moi
                this.GetUpdateStore();
            }
            else
            {
                MessageBox.Show("Không có kết nối internet! \r\n Bạn tắt đi và mở lại chương trình để thực hiện cập dữ liệu", Common.SoftName);
            }
        }
        private async void GetUpdateCatalogue()
        {
            DacProductCategoryCS CategoryCS = new DacProductCategoryCS();
            DacProductCatalogueCollection dacCatalogueCollection = CategoryCS.GetListCategory();
            if (dacCatalogueCollection.Count > 0)
            {
                // Get ID max
                int IdMax = 0;
                foreach (DacProductCatalogue Catalogue in dacCatalogueCollection)
                {
                    if (Catalogue.Id > IdMax)
                    {
                        IdMax = Catalogue.Id;
                    }
                }
                // Get Product from ID and save
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    dacCatalogueCollection = await apiHelper.GetCatalogueAsync(IdMax);
                    foreach (DacProductCatalogue Catalogue in dacCatalogueCollection)
                    {
                        CategoryCS.Insert(Catalogue, Catalogue.Id);
                    }
                }
                catch
                {
                    return;
                }
            }
        }
        private async void GetUpdateProduct()
        {
            DacProductCS ProductCS = new DacProductCS();
            DacProductCollection dacProductCollection = ProductCS.GetListProduct();
            if (dacProductCollection.Count > 0)
            {
                // Get ID max
                int IdMax = 0;
                foreach (DacProduct Product in dacProductCollection)
                {
                    if (Product.Id > IdMax)
                    {
                        IdMax = Product.Id;
                    }
                }
                // Get Product from ID and save
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    dacProductCollection = await apiHelper.GetProductAsync(IdMax);
                    foreach (DacProduct Product in dacProductCollection)
                    {
                        ProductCS.Insert(Product, Product.Id);
                    }
                }
                catch
                {
                    return;
                }
            }
        }
        private async void GetUpdateStore()
        {
            DacStoreCS dacStoreCS = new DacStoreCS();
            DacStoreCollection dacStoreCollection = dacStoreCS.GetListStore();
            if (dacStoreCollection.Count > 0)
            {
                string AgencyCode = string.Empty;
                DacAgencyCS dacAgencyCS = new DacAgencyCS();
                DacAgencyCollection dacAgencyCollection = dacAgencyCS.GetListAgency();
                if(dacAgencyCollection.Count > 0)
                {
                    AgencyCode = dacAgencyCollection[0].Code;
                }
                if(AgencyCode == string.Empty)
                {
                    return;
                }
                // Get ID max
                int IdMax = 0;
                foreach (DacStore store in dacStoreCollection)
                {
                    if (store.ID > IdMax)
                    {
                        IdMax = store.ID;
                    }
                }
                // Get Store from ID and save
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    dacStoreCollection = await apiHelper.GetStoreAsync(IdMax, AgencyCode);
                    foreach (DacStore store in dacStoreCollection)
                    {
                        dacStoreCS.Insert(store, store.ID);
                    }
                }
                catch (HttpRequestException rex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: \r\n" + rex.Message, SoftName);
                }
            }
        }
        #endregion
        #region Update Data To Server When Error Network Occurred
        public async void AddDistributeToStoreOnServer(DAC.Core.Models.DacDistributeToStoreViewModel DistributeToStoreViewModel, DacLogNotUpload LogNotUpload)
        {
            if (InternetConnection.IsInternetConnected())
            {
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    bool IsSuccess = await apiHelper.AddDistributeToStoreAsync(DistributeToStoreViewModel);
                    if (!IsSuccess)
                    {
                        // Lưu thông tin xuất hàng chưa được upload
                        // để gửi lại sau.
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStoreViewModel.DacDistributeToStore.ID, "DacDistributeToStore",
                            "Create", "Chưa tải dữ liệu lên được do không gọi được API", DacLogNotUploadCS.Status);
                    }
                    else // Upload du lieu len thanh cong
                    {
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStoreViewModel.DacDistributeToStore.ID, "DacDistributeToStore",
                            "Create", "Dữ liệu đã được tải lên máy chủ thành công!", "Uploaded");
                    }
                }
                catch (HttpRequestException rex)
                {
                    DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                    LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStoreViewModel.DacDistributeToStore.ID, "DacDistributeToStore",
                        "Create", rex.Message, DacLogNotUploadCS.Status);
                }
            }
            else
            {
                DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStoreViewModel.DacDistributeToStore.ID, "DacDistributeToStore",
                    "Create", "Chưa tải dữ liệu lên được do không có Internet", DacLogNotUploadCS.Status);
            }
        }
        public async void UpdateDistributeToStoreOnServer(DacDistributeToStore DistributeToStore, DacLogNotUpload LogNotUpload)
        {
            if (InternetConnection.IsInternetConnected())
            {
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    bool IsSuccess = await apiHelper.UpdateDistributeToStoreAsync(DistributeToStore);
                    if (!IsSuccess)
                    {
                        // Lưu thông tin xuất hàng chưa được upload
                        // để gửi lại sau.
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStore.ID, "DacDistributeToStore",
                            "Update", "Chưa cập nhật được dữ liệu do không gọi được API", DacLogNotUploadCS.Status);
                    }
                    else // Upload du lieu len thanh cong
                    {
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStore.ID, "DacDistributeToStore",
                            "Update", "Dữ liệu đã được tải lên máy chủ thành công!", "Uploaded");
                    }
                }
                catch (HttpRequestException rex)
                {
                    DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                    LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStore.ID, "DacDistributeToStore",
                        "Update", rex.Message, DacLogNotUploadCS.Status);
                }
            }
            else
            {
                DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStore.ID, "DacDistributeToStore",
                    "Update", "Chưa cập nhật được dữ liệu do không có Internet", DacLogNotUploadCS.Status);
            }
        }
        public async void DeleteDistributeToStoreOnServer(string ID, DacLogNotUpload LogNotUpload)
        {
            if (InternetConnection.IsInternetConnected())
            {
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    bool IsSuccess = await apiHelper.DeleteDistributeToStoreAsync(ID);
                    if (!IsSuccess)
                    {
                        // Lưu thông tin xuất hàng chưa được upload
                        // để gửi lại sau.
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, ID, "DacDistributeToStore",
                            "Delete", "Chưa xóa được dữ liệu do không gọi được API", DacLogNotUploadCS.Status);
                    }
                    else // Upload du lieu len thanh cong
                    {
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, ID, "DacDistributeToStore",
                            "Delete", "Dữ liệu đã được tải lên máy chủ thành công!", "Uploaded");
                    }
                }
                catch (HttpRequestException rex)
                {
                    DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                    LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, ID, "DacDistributeToStore",
                        "Delete", rex.Message, DacLogNotUploadCS.Status);
                }
            }
            else
            {
                DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, ID, "DacDistributeToStore",
                    "Delete", "Chưa xóa được dữ liệu do không có Internet", DacLogNotUploadCS.Status);
            }
        }
        public async void AddDistributeToStoreDetailsOnServer(DAC.Core.Models.DacStoreDetailsViewModel StoreDetailsViewModel, DacLogNotUpload LogNotUpload)
        {
            if (InternetConnection.IsInternetConnected())
            {
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    bool IsSuccess = await apiHelper.AddDistributeToStoreDetailsAsync(StoreDetailsViewModel);
                    if (!IsSuccess)
                    {
                        // Lưu thông tin xuất hàng chưa được upload
                        // để gửi lại sau.
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, "StoreDetailsViewModel", "DacDistributeToStoreDetails",
                            "Create", "Chưa tải dữ liệu lên được do không gọi được API", DacLogNotUploadCS.Status);
                    }
                    else // Upload du lieu len thanh cong
                    {
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, "StoreDetailsViewModel", "DacDistributeToStoreDetails",
                            "Create", "Dữ liệu đã được tải lên máy chủ thành công!", "Uploaded");
                    }
                }
                catch (HttpRequestException rex)
                {
                    DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                    LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, "StoreDetailsViewModel", "DacDistributeToStoreDetails",
                        "Create", rex.Message, DacLogNotUploadCS.Status);
                }
            }
            else
            {
                DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, "StoreDetailsViewModel", "DacDistributeToStoreDetails",
                    "Create", "Chưa tải dữ liệu lên được do không có Internet", DacLogNotUploadCS.Status);
            }
        }
        public async void DeleteDistributeToStoreDetailsOnServer(DacDistributeToStoreDetails DistributeToStoreDetails, DacLogNotUpload LogNotUpload)
        {
            if (InternetConnection.IsInternetConnected())
            {
                ApiHelper apiHelper = new ApiHelper();
                try
                {
                    bool IsSuccess = await apiHelper.DeleteDistributeToStoreDetailsAsync(DistributeToStoreDetails.DistributorID, DistributeToStoreDetails.DacCode);
                    if (!IsSuccess)
                    {
                        // Lưu thông tin xuất hàng chưa được upload
                        // để gửi lại sau.
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStoreDetails.ID.ToString(), "DacDistributeToStoreDetails",
                            "Delete", "Chưa xóa được dữ liệu do không gọi được API", DacLogNotUploadCS.Status);
                    }
                    else // Upload du lieu len thanh cong
                    {
                        DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                        LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStoreDetails.ID.ToString(), "DacDistributeToStoreDetails",
                            "Delete", "Dữ liệu đã được tải lên máy chủ thành công!", "Uploaded");
                    }
                }
                catch (HttpRequestException rex)
                {
                    DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                    LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStoreDetails.ID.ToString(), "DacDistributeToStoreDetails",
                        "Delete", rex.Message, DacLogNotUploadCS.Status);
                }
            }
            else
            {
                DacLogNotUploadCS LogNotUploadCS = new DacLogNotUploadCS();
                LogNotUploadCS.UpdateLogNotUpload(LogNotUpload.ID, DistributeToStoreDetails.ID.ToString(), "DacDistributeToStoreDetails",
                    "Delete", "Chưa xóa được dữ liệu do không có Internet", DacLogNotUploadCS.Status);
            }
        }

        public void SendDataStoreToServer(DacLogNotUpload LogNotUpload)
        {
            if(LogNotUpload != null)
            {
                DacDistributeToStore DistributeToStore = new DacDistributeToStore();
                DacDistributeToStoreCS DistributeToStoreCS = new DacDistributeToStoreCS();
                DacDistributeToStoreDetailsCS DistributeToStoreDetailsCS = new DacDistributeToStoreDetailsCS();
                DistributeToStore = DistributeToStoreCS.GetDistributeToStore(LogNotUpload.IDNotUpload);
                if(DistributeToStore == null)
                { return; }
                switch (LogNotUpload.Action)
                {
                    case "Create":
                        DAC.Core.Models.DacDistributeToStoreViewModel DistributeToStoreViewModel
                            = new DAC.Core.Models.DacDistributeToStoreViewModel();
                        DistributeToStoreViewModel.DacDistributeToStore = DistributeToStore;
                        DistributeToStoreViewModel.StoreDetailsCollection = DistributeToStoreDetailsCS.GetDistributeDetails(DistributeToStore.ID);
                        this.AddDistributeToStoreOnServer(DistributeToStoreViewModel, LogNotUpload);
                        break;
                    case "Update":
                        this.UpdateDistributeToStoreOnServer(DistributeToStore, LogNotUpload);
                        break;
                    case "Delete":
                        this.DeleteDistributeToStoreOnServer(LogNotUpload.IDNotUpload, LogNotUpload); // Or LogNotUpload.Content
                        break;
                }
            }
        }
        public void SendDataStoreDetailsToServer(DacLogNotUpload LogNotUpload)
        {
            if (LogNotUpload != null)
            {
                DacDistributeToStoreDetails DistributeToStoreDetails = new DacDistributeToStoreDetails();
                switch (LogNotUpload.Action)
                {
                    case "Create":
                        JObject objData = JObject.Parse(LogNotUpload.Content);
                        dynamic jsonData = objData;
                        JArray storeDetailsJson = jsonData.StoreDetailsCollection;
                        DacDistributeToStoreDetailsCollection StoreDetailsCollection = new DacDistributeToStoreDetailsCollection();
                        foreach (var storeDetails in storeDetailsJson)
                        {
                            StoreDetailsCollection.Add(storeDetails.ToObject<DacDistributeToStoreDetails>());
                        }
                        //List<DacDistributeToStoreDetails> listStoreDetails = 
                        //JsonConvert.DeserializeObject<List<DacDistributeToStoreDetails>>(LogNotUpload.Content);
                        DAC.Core.Models.DacStoreDetailsViewModel StoreDetailsViewModel =
                            new DAC.Core.Models.DacStoreDetailsViewModel();
                        StoreDetailsViewModel.StoreDetailsCollection = StoreDetailsCollection;
                        this.AddDistributeToStoreDetailsOnServer(StoreDetailsViewModel, LogNotUpload);
                        break;
                    case "Delete":
                        var json_serializer = new JavaScriptSerializer();
                        DistributeToStoreDetails = 
                            json_serializer.Deserialize<DacDistributeToStoreDetails>(LogNotUpload.Content);
                        this.DeleteDistributeToStoreDetailsOnServer(DistributeToStoreDetails, LogNotUpload);
                        break;
                }
            }
        }
        #endregion
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
