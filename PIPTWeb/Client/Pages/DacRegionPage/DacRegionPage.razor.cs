using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Components;
using PIPTWeb.Shared;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using Radzen;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace PIPTWeb.Client.Pages.DacRegionPage
{
    public partial class DacRegionPage
    {
        [Inject] public IDacRegionsService regionService { get; set; }
        [Inject] public NotificationService notification { get; set; }
        [Inject] private ILocalStorageService localStorage { get; set; }

        private DacRegion _Region = new DacRegion();
        private bool IsDeleteDialogOpen = false;
        private PIPTModal piptModal { get; set; }
        private PaginatedInputModel pagination { get; set; } = new PaginatedInputModel();

        private List<DacRegion> LstRegions;

        public int totalPages { get; set; }
        private int actualPage = 1;
        private string RegionCode = string.Empty;
        private string RegionName = string.Empty;
        private string UserName;

        protected async override Task OnInitializedAsync()
        {
            pagination.PageNumber = 1;
            pagination.PageSize = 50;
            UserName = await localStorage.GetItemAsync<string>("UserName");
            LstRegions = await regionService.GetPagingRegions(pagination);
            totalPages = regionService.totalPages;
            ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Tải dữ liệu vùng miền", Detail = "Thành công!" });
            StateHasChanged();
        }

        private async Task OpenDialog(DacRegion region)
        {
            _Region = region;
            await piptModal.Open();
        }

        private async Task OpenDeleteDialog(DacRegion region)
        {
            _Region = region;
            IsDeleteDialogOpen = true;
            await piptModal.Open();
        }

        private async Task OnSubmitCallBack()
        {
            IsDeleteDialogOpen = false;
            await piptModal.Close();
            LstRegions = await regionService.GetPagingRegions(pagination);
            totalPages = regionService.totalPages;
            ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Cập nhật dữ liệu vùng miền", Detail = "Thành công!" });
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
            LstRegions = await regionService.GetPagingRegions(pagination);
            totalPages = regionService.totalPages;
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
            LstRegions = await regionService.GetPagingRegions(pagination);
            totalPages = regionService.totalPages;
        }
        void CancelDialog()
        {
            IsDeleteDialogOpen = false;
        }
    }
}
