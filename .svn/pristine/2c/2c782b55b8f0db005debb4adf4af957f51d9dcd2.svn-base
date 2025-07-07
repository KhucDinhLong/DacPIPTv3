using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Components;
using PIPTWeb.Shared;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using Radzen;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.DacAgencyPage
{
    public partial class DacAgenciesPage
    {
        [Inject] public IDacAgencyService agencyService { get; set; }
        [Inject] public NotificationService notification { get; set; }
        [Inject] ILocalStorageService localStorage { get; set; }
        [Inject] public ISecUsersService userService { get; set; }

        private DacAgency _Agency = new DacAgency();
        private bool IsDeleteDialogOpen = false;
        private PIPTModal piptModal { get; set; }
        private PaginatedInputModel pagination { get; set; } = new PaginatedInputModel();

        private List<DacAgency> LstAgencies;

        public int totalPages { get; set; }
        private int actualPage = 1;
        private string AgencyCode = string.Empty;
        private string AgencyName = string.Empty;
        private string UserName;
        private bool IsAdmin;

        protected async override Task OnInitializedAsync()
        {
            pagination.PageNumber = 1;
            pagination.PageSize = 50;
            UserName = await localStorage.GetItemAsync<string>("UserName");
            var user = await userService.GetUserByUserName(UserName);
            if (user != null && user.IsAdmin.HasValue)
            {
                IsAdmin = user.IsAdmin.Value;
            }
            else
            {
                IsAdmin = false;
            }
            if (IsAdmin)
            {
                LstAgencies = await agencyService.GetPagingAgencies(pagination);
            }
            else
            {
                LstAgencies = await agencyService.GetPagingAgenciesByUserName(pagination, UserName);
            }
            totalPages = agencyService.totalPages;
            ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Tải dữ liệu khách hàng", Detail = "Thành công!" });
            StateHasChanged();
        }

        private async Task OpenDialog(DacAgency agency)
        {
            _Agency = agency;
            await piptModal.Open();
        }

        private async Task OpenDeleteDialog(DacAgency agency)
        {
            _Agency = agency;
            IsDeleteDialogOpen = true;
            await piptModal.Open();
        }

        private async Task OnSubmitCallBack()
        {
            IsDeleteDialogOpen = false;
            await piptModal.Close();
            LstAgencies = await agencyService.GetPagingAgencies(pagination);
            totalPages = agencyService.totalPages;
            ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Cập nhật dữ liệu khách hàng", Detail = "Thành công!" });
            StateHasChanged();
        }

        private async Task CloseDialog()
        {
            IsDeleteDialogOpen = false;
            await piptModal.Close();
            StateHasChanged();
        }

        private async Task SelectedPage(int page)
        {
            actualPage = page;
            pagination.PageNumber = actualPage;
            LstAgencies = await agencyService.GetPagingAgencies(pagination);
            totalPages = agencyService.totalPages;
            StateHasChanged();
        }

        void ShowNotification(Radzen.NotificationMessage message)
        {
            notification.Notify(message);
        }

        private async Task Search(string Code, string Name)
        {
            actualPage = 1;
            pagination.PageNumber = actualPage;
            // Thêm bộ lọc tìm kiếm
            pagination.FilterParams = new List<FilterUtility.FilterParams> {
            new FilterUtility.FilterParams { ColumnName = "Code", FilterValue = Code, FilterOption = FilterUtility.FilterOptions.Contains },
            new FilterUtility.FilterParams { ColumnName = "Name", FilterValue = Name, FilterOption = FilterUtility.FilterOptions.Contains }
            };
            LstAgencies = await agencyService.GetPagingAgencies(pagination);
            totalPages = agencyService.totalPages;
        }
        void CancelDialog()
        {
            IsDeleteDialogOpen = false;
        }
    }
}
