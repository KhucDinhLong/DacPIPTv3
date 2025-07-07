using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PIPTWeb.Client.Services;
using PIPTWeb.Components;
using PIPTWeb.Select2;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.DacDistributePage
{
    public partial class DacDistributePage
    {
        [Inject] private IDacDistributeService distributeService { get; set; }
        [Inject] private IAuthenticationService authService { get; set; }
        [Inject] private ISecUsersService userService { get; set; }
        [Inject] private IDacAgencyService agencyService { get; set; }
        [Inject] private ISecConfigService configService { get; set; }
        [Inject] private IDacProductService productService { get; set; }
        [Inject] private IJSRuntime jsRuntime { get; set; }
        [Inject] private ILocalStorageService localStorage { get; set; }
        [Inject] private NotificationService notification { get; set; }
        private string UserName;
        private List<DacDistributeModel> LstDistributeModel = new List<DacDistributeModel>();
        private DacDistributeModel currentDistribute = new DacDistributeModel { dacDistributeToAgency = new DacDistributeToAgencyModel(), LstDistributeDetail = new List<DacDistributeToAgencyDetails>() };
        private string _Seri = string.Empty;
        public string Seri
        {
            get
            {
                return _Seri;
            }
            set
            {
                _Seri = value;
                EnterSeri();
            }
        }
        private string DacCode = string.Empty;
        private string _FromSeri = string.Empty;
        public string FromSeri
        {
            get
            {
                return _FromSeri;
            }
            set
            {
                _FromSeri = value;
                EnterFromSeri();
            }
        }
        private string FromDacCode;
        private string _ToSeri = string.Empty;
        public string ToSeri
        {
            get
            {
                return _ToSeri;
            }
            set
            {
                _ToSeri = value;
                EnterToSeri();
            }
        }
        private string ToDacCode;
        private PaginatedInputModel pagination = new PaginatedInputModel();
        private List<DacAgency> LstSrcAgency = new List<DacAgency>();
        private List<DacAgency> LstSelectedSrcAgency = new List<DacAgency>();
        private InputSelect2Options select2Option = new InputSelect2Options();
        private int _selectedAgency;
        public int SelectedAgency
        {
            get
            {
                return _selectedAgency;
            }
            set
            {
                _selectedAgency = value;
                ChangeAgency(_selectedAgency).GetAwaiter();
            }
        }
        private List<DacAgency> LstDesAgency = new List<DacAgency>();
        private List<DacAgency> LstSelectedDesAgency = new List<DacAgency>();
        private List<DacProduct> LstProduct = new List<DacProduct>();
        private List<DacProduct> LstSelectedProduct = new List<DacProduct>();
        public int totalPages { get; set; }
        private int actualPage = 1;
        private bool? IsAdmin;
        private bool disableControl = true;
        private bool isUpdate = false;
        private List<SecConfig> LstConfig;
        private Customers customer;
        private bool DisableAdd;
        private bool DisableUpdate;
        private bool DisableDelete;
        private bool DisableSave;
        private bool DisableCancel;
        private PIPTModal piptModal { get; set; }
        private bool IsDeleteDialogOpen;
        private List<string> LstInvalidSeri = new List<string>();
        private List<DacDistributeToAgencyDetails> LstDeleteSeri = new List<DacDistributeToAgencyDetails>();
        private bool isDeleteSeri;
        protected override async Task OnInitializedAsync()
        {
            await LoadData();
            LoadStatusControl();
            StateHasChanged();
        }
        private async Task SubmitData()
        {

        }
        private async Task<List<DacAgency>> filterAgencyFunction(List<DacAgency> allAgency, string filter, CancellationToken token)
        {
            return await Task.FromResult(allAgency.Where(i => i.Name.ToLower().Contains(filter.ToLower())).ToList());
        }
        private async Task<DacAgency> getAgencyByIdAsync(List<DacAgency> allItems, string id, CancellationToken token)
        {
            return await Task.FromResult(allItems.SingleOrDefault(x => x.ID.ToString() == id));
        }
        private void OnSrcAgencyChange()
        {
            if (currentDistribute != null && currentDistribute.dacDistributeToAgency != null && LstSelectedSrcAgency.Count > 0)
            {
                currentDistribute.dacDistributeToAgency.SrcAgencyId = LstSelectedSrcAgency[0].ID;
                SelectedAgency = LstSelectedSrcAgency[0].ID;
            }
        }
        private void OnDesAgencyChange()
        {
            if (currentDistribute != null && currentDistribute.dacDistributeToAgency != null && LstSelectedDesAgency.Count > 0)
                currentDistribute.dacDistributeToAgency.DesAgencyId = LstSelectedDesAgency[0].ID;
        }
        private async Task<List<DacProduct>> filterProductFunction(List<DacProduct> allProduct, string filter, CancellationToken token)
        {
            return await Task.FromResult(allProduct.Where(i => i.Name.ToLower().Contains(filter.ToLower())).ToList());
        }
        private async Task<DacProduct> getProductByIdAsync(List<DacProduct> allItems, string id, CancellationToken token)
        {
            return await Task.FromResult(allItems.SingleOrDefault(x => x.Id.ToString() == id));
        }
        private void OnProductChange()
        {
            if (currentDistribute != null && currentDistribute.dacDistributeToAgency != null && LstSelectedProduct.Count > 0)
                currentDistribute.dacDistributeToAgency.ProductCode = LstSelectedProduct[0].Code;
        }
        private async Task ChangeAgency(int SelectedAgencyId)
        {
            if (IsAdmin.HasValue && IsAdmin.Value)
            {
                LstConfig = await GetConfig();
            }
            LstDesAgency = await agencyService.GetChildrenByAgencyId(SelectedAgencyId);
            LstSelectedDesAgency.Clear();
            try
            {
                var selectedDesAgency = await agencyService.GetAgencyById(currentDistribute.dacDistributeToAgency.DesAgencyId.Value);
                if (selectedDesAgency != null)
                    LstSelectedDesAgency.Add(selectedDesAgency);
            }
            catch (Exception)
            {
            }
            StateHasChanged();
        }
        private async Task SelectedPage(int page)
        {
            actualPage = page;
            pagination.PageNumber = actualPage;
            LstDistributeModel = await distributeService.GetPagingDistribute(pagination);
            StateHasChanged();
        }
        private void EnterSeri()
        {
            DacCode = GetDacCodeFromScanner(Seri);
            if (!string.IsNullOrWhiteSpace(DacCode))
            {
                var distribute = currentDistribute.LstDistributeDetail.Where(x => x.DacCode == Seri);
                if (distribute == null || distribute.Count() <= 0)
                {
                    DacDistributeToAgencyDetails DistributeDetail = new DacDistributeToAgencyDetails();
                    DistributeDetail.DistributorID = currentDistribute.dacDistributeToAgency.ID;
                    DistributeDetail.DacCode = DacCode;
                    DistributeDetail.ProductCode = currentDistribute.dacDistributeToAgency.ProductCode;
                    DistributeDetail.Quantity = 1;
                    currentDistribute.LstDistributeDetail.Add(DistributeDetail);
                    Seri = string.Empty;
                    StateHasChanged();
                }
            }
        }
        private void EnterFromSeri()
        {
            if (!string.IsNullOrWhiteSpace(FromSeri))
            {
                FromDacCode = GetDacCodeFromScanner(FromSeri);
                FromSeri = string.Empty;
                StateHasChanged();
                jsRuntime.InvokeVoidAsync("FocusControl", "txtToSeri").GetAwaiter();
            }
        }
        private void EnterToSeri()
        {
            ToDacCode = GetDacCodeFromScanner(ToSeri);
            if (!string.IsNullOrWhiteSpace(ToDacCode))
            {
                try
                {
                    long FromSeriValue = long.Parse(FromDacCode);
                    long ToSeriValue = long.Parse(ToDacCode);
                    if (FromSeriValue > ToSeriValue)
                        return;
                    string SeriLength = string.Empty;
                    if (LstConfig != null && LstConfig.Count > 0)
                    {
                        var config = LstConfig.FirstOrDefault(x => x.Code == "SeriLength");
                        if (config != null)
                        {
                            for (long i = FromSeriValue; i <= ToSeriValue; i++)
                            {
                                var curentDacCode = string.Format("{0:" + config.Pattern + "}", i);
                                var distribute = currentDistribute.LstDistributeDetail.Where(x => x.DacCode == curentDacCode);
                                if (distribute == null || distribute.Count() <= 0)
                                {
                                    DacDistributeToAgencyDetails DistributeDetail = new DacDistributeToAgencyDetails();
                                    DistributeDetail.DistributorID = currentDistribute.dacDistributeToAgency.ID;
                                    DistributeDetail.DacCode = curentDacCode;
                                    DistributeDetail.ProductCode = currentDistribute.dacDistributeToAgency.ProductCode;
                                    DistributeDetail.Quantity = 1;
                                    currentDistribute.LstDistributeDetail.Add(DistributeDetail);
                                }
                            }
                            StateHasChanged();
                        }
                    }
                    ToSeri = string.Empty;
                    StateHasChanged();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
        private string GetDacCodeFromScanner(string Scanner)
        {

            string Serial = Scanner;
            if (IsNumber(Serial))
            {
                return Serial;
            }
            else
            {
                if (LstConfig != null && LstConfig.Count > 0)
                {
                    var LstPattern = LstConfig.Where(x => x.Code == "SeriPattern");
                    if (LstPattern != null && LstPattern.Count() > 0)
                    {
                        foreach (var item in LstPattern)
                        {
                            Regex regex = new Regex(@"^" + item.Value + "$");
                            if (regex.IsMatch(Scanner))
                            {
                                string[] splits = Scanner.Split('=');
                                Serial = splits[1].Trim();
                                if (Serial.Contains("&"))
                                {
                                    splits = Serial.Split('&');
                                    Serial = splits[0].Trim();
                                }
                                return Serial;
                            }
                        }
                    }
                }
                return Serial;
            }
        }
        private bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        private async Task<List<SecConfig>> GetConfig()
        {
            int? CustomerId;
            try
            {
                if (IsAdmin.HasValue && IsAdmin.Value)
                {
                    CustomerId = currentDistribute?.dacDistributeToAgency?.SrcAgencyId;
                }
                else
                {
                    customer = await userService.GetCustomerByUserNameAsync(UserName);
                    CustomerId = customer?.Id;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            if (CustomerId.HasValue)
            {
                return await configService.GetConfigByCustomerIdAsync(CustomerId.Value);
            }
            else
            {
                return null;
            }
        }
        private async Task Add()
        {
            currentDistribute = new DacDistributeModel { dacDistributeToAgency = new DacDistributeToAgencyModel(), LstDistributeDetail = new List<DacDistributeToAgencyDetails>() };
            currentDistribute.dacDistributeToAgency.OrderNumber = await distributeService.GetMaxOrder();
            LstSelectedSrcAgency.Clear();
            LstSelectedDesAgency.Clear();
            LstSelectedProduct.Clear();
            if (IsAdmin.HasValue && IsAdmin.Value)
                LstDesAgency.Clear();
            isUpdate = false;
            disableControl = false;
            DisableCancel = false;
            DisableSave = false;
            DisableAdd = true;
            DisableDelete = true;
            DisableUpdate = true;
            LoadStatusControl();
            await jsRuntime.InvokeVoidAsync("EnableControl");
            await jsRuntime.InvokeVoidAsync("UnSelectedDistribute");
            StateHasChanged();
        }
        private async Task Update()
        {
            isUpdate = true;
            disableControl = false;
            DisableCancel = false;
            DisableSave = false;
            DisableAdd = true;
            DisableDelete = true;
            DisableUpdate = true;
            LoadStatusControl();
            await jsRuntime.InvokeVoidAsync("EnableControl");
            StateHasChanged();
        }
        private async Task Cancel()
        {
            await LoadData();
            LoadStatusControl();
            StateHasChanged();
        }
        private async Task Delete()
        {
            if (currentDistribute.dacDistributeToAgency.ID > 0)
            {
                IsDeleteDialogOpen = true;
                await piptModal.Open();
            }
            else
            {
                IsDeleteDialogOpen = false;
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Xóa dữ liệu", Detail = "Thất bại! Không có dữ liệu để xóa!" });
            }
        }
        private async Task Save()
        {
            if (!ValidateData())
                return;
            LstInvalidSeri = await distributeService.CheckValidDistribute(UserName, currentDistribute, isUpdate);
            if (LstInvalidSeri.Count > 0)
            {
                if (LstInvalidSeri.Count == 1 && LstInvalidSeri[0] == "401")
                {
                    ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lưu dữ liệu", Detail = "Thất bại! Tài khoản không hợp lệ!" });
                    return;
                }
                if (LstInvalidSeri.Count == 1 && LstInvalidSeri[0] == "404")
                {
                    ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lưu dữ liệu", Detail = "Thất bại! Không tìm thấy đại lý xuất hàng!" });
                    return;
                }
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lưu dữ liệu", Detail = "Thất bại! Danh sách hàng xuất không hợp lệ!" });
                IsDeleteDialogOpen = false;
                isDeleteSeri = false;
                await piptModal.Open();
                return;
            }
            string result = await distributeService.Save(currentDistribute, isUpdate);
            if (result == "200")
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Lưu dữ liệu", Detail = "Thành công!" });
            }
            else
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lưu dữ liệu", Detail = "Thất bại!" });
            }
            select2Option.Disabled = true;
            await LoadData();
            LoadStatusControl();
            StateHasChanged();
        }
        private void LoadStatusControl()
        {
            Seri = string.Empty;
            FromSeri = string.Empty;
            ToSeri = string.Empty;
            DacCode = string.Empty;
            FromDacCode = string.Empty;
            ToDacCode = string.Empty;
            select2Option = new InputSelect2Options();
            select2Option.Disabled = disableControl;
            if (!currentDistribute.dacDistributeToAgency.CreatedDate.HasValue)
                currentDistribute.dacDistributeToAgency.CreatedDate = DateTime.Now;
        }
        private async Task LoadData()
        {
            DisableAdd = false;
            DisableUpdate = false;
            DisableDelete = false;
            DisableSave = true;
            DisableCancel = true;
            isUpdate = false;
            disableControl = true;
            select2Option.Disabled = disableControl;
            IsDeleteDialogOpen = false;
            isDeleteSeri = false;
            LstDeleteSeri = new List<DacDistributeToAgencyDetails>();
            UserName = await localStorage.GetItemAsync<string>("UserName");
            var user = await userService.GetUserByUserName(UserName);
            if (user != null && user.IsAdmin.HasValue && user.IsAdmin.Value)
                IsAdmin = true;
            else
                IsAdmin = false;
            pagination.PageNumber = 1;
            pagination.PageSize = 50;
            LstConfig = await GetConfig();
            if (IsAdmin.HasValue && IsAdmin.Value)
            {
                LstDistributeModel = await distributeService.GetPagingDistribute(pagination);
                totalPages = distributeService.totalpage;
                LstSrcAgency = await agencyService.GetAgencies(null);
                LstProduct = await productService.GetProducts();
            }
            else
            {
                LstDistributeModel = await distributeService.GetPagingDistributeByUserName(pagination, UserName);
                totalPages = distributeService.totalpage;
                LstDesAgency = await agencyService.GetChildrenAgenciesByUserName(UserName);
                LstProduct = await productService.GetProductByUserName(UserName);
            }
            if (LstDistributeModel != null && LstDistributeModel.Count > 0)
            {
                currentDistribute = LstDistributeModel[0];
                currentDistribute.LstDistributeDetail = await distributeService.GetDetailByDistributeId(currentDistribute.dacDistributeToAgency.ID);
            }
            else
            {
                currentDistribute = new DacDistributeModel();
                currentDistribute.dacDistributeToAgency = new DacDistributeToAgencyModel();
                currentDistribute.LstDistributeDetail = new List<DacDistributeToAgencyDetails>();
            }
            try
            {
                LstSelectedSrcAgency.Clear();
                LstSelectedDesAgency.Clear();
                LstSelectedProduct.Clear();
                var selectedSrcAgency = await agencyService.GetAgencyById(currentDistribute.dacDistributeToAgency.SrcAgencyId.Value);
                if (selectedSrcAgency != null)
                    LstSelectedSrcAgency.Add(selectedSrcAgency);
                var selectedProduct = await productService.GetProductByCode(currentDistribute.dacDistributeToAgency.ProductCode);
                if (selectedProduct != null)
                    LstSelectedProduct.Add(selectedProduct);
            }
            catch (Exception)
            {
            }
            await jsRuntime.InvokeVoidAsync("UnSelectedDistribute");
            await jsRuntime.InvokeVoidAsync("SelectedDistribute", currentDistribute.dacDistributeToAgency.ID);
        }
        private bool ValidateData()
        {
            if (currentDistribute.dacDistributeToAgency == null)
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lỗi", Detail = "Có lỗi xảy ra, bạn không thể thực hiện thao tác này!" });
                return false;
            }
            if (isUpdate && string.IsNullOrWhiteSpace(currentDistribute.dacDistributeToAgency.OrderNumber))
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lỗi", Detail = "Lệnh xuất không đúng!" });
                return false;
            }
            if (!currentDistribute.dacDistributeToAgency.SrcAgencyId.HasValue || currentDistribute.dacDistributeToAgency.SrcAgencyId.Value <= 0)
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lỗi", Detail = "Nguồn xuất không đúng!" });
                return false;
            }
            if (!currentDistribute.dacDistributeToAgency.DesAgencyId.HasValue || currentDistribute.dacDistributeToAgency.DesAgencyId.Value <= 0)
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lỗi", Detail = "Đích xuất không đúng!" });
                return false;
            }
            if (string.IsNullOrWhiteSpace(currentDistribute.dacDistributeToAgency.ProductCode))
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lỗi", Detail = "Sản phẩm không đúng!" });
                return false;
            }
            if (!currentDistribute.dacDistributeToAgency.Quantity.HasValue || currentDistribute.dacDistributeToAgency.Quantity.Value <= 0)
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lỗi", Detail = "Số lượng không đúng!" });
                return false;
            }
            if (!currentDistribute.dacDistributeToAgency.CreatedDate.HasValue)
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Lỗi", Detail = "Ngày xuất không đúng!" });
                return false;
            }
            return true;
        }
        void ShowNotification(Radzen.NotificationMessage message)
        {
            notification.Notify(message);
        }
        private async Task ChangeModel(DacDistributeModel item)
        {
            currentDistribute = item;
            currentDistribute.LstDistributeDetail = await distributeService.GetDetailByDistributeId(currentDistribute.dacDistributeToAgency.ID);
            LstDeleteSeri = new List<DacDistributeToAgencyDetails>();
            await jsRuntime.InvokeVoidAsync("UnCheckOnDetail");
            await jsRuntime.InvokeVoidAsync("UnSelectedDistribute");
            await jsRuntime.InvokeVoidAsync("SelectedDistribute", item.dacDistributeToAgency.ID);
            StateHasChanged();
        }
        void CancelDialog()
        {
            IsDeleteDialogOpen = false;
            isDeleteSeri = false;
        }
        private async Task OnSubmitCallBack()
        {
            await piptModal.Close();
            select2Option.Disabled = true;
            await LoadData();
            LoadStatusControl();
            StateHasChanged();
        }

        private async Task CloseDialog()
        {
            IsDeleteDialogOpen = false;
            isDeleteSeri = false;
            await piptModal.Close();
            StateHasChanged();
        }
        void CheckboxClicked(DacDistributeToAgencyDetails DistributeDetail, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!LstDeleteSeri.Contains(DistributeDetail))
                {
                    LstDeleteSeri.Add(DistributeDetail);
                }
            }
            else
            {
                if (LstDeleteSeri.Contains(DistributeDetail))
                {
                    LstDeleteSeri.Remove(DistributeDetail);
                }
            }
        }
        private async Task DeleteSeri()
        {
            if (LstDeleteSeri != null && LstDeleteSeri.Count > 0)
            {
                isDeleteSeri = true;
                await piptModal.Open();
            }
            else
            {
                isDeleteSeri = false;
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Xóa dữ liệu", Detail = "Thất bại! Không có dữ liệu để xóa!" });
            }
        }
    }
}
