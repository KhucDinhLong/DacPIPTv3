using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Components;
using PIPTWeb.Shared;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.ProvincePage
{
    public partial class ProvincesPage
    {
        [Inject] public IProvincesService provinceService { get; set; }
        [Inject] public NotificationService notification { get; set; }

        private Province _Province = new Province();
        private bool IsDeleteDialogOpen = false;
        private PIPTModal piptModal { get; set; }
        private PaginatedInputModel pagination { get; set; } = new PaginatedInputModel();

        private List<Province> LstProvinces;

        public int totalPages { get; set; }
        private int actualPage = 1;
        private string ProvinceCode = string.Empty;
        private string ProvinceName = string.Empty;

        protected async override Task OnInitializedAsync()
        {
            pagination.PageNumber = 1;
            pagination.PageSize = 50;
            LstProvinces = await provinceService.GetPagingProvinces(pagination);
            totalPages = provinceService.totalPages;
            ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Tải dữ liệu tỉnh thành", Detail = "Thành công!" });
            StateHasChanged();
        }

        private async Task OpenDialog(Province province)
        {
            _Province = province;
            await piptModal.Open();
        }

        private async Task OpenDeleteDialog(Province province)
        {
            _Province = province;
            IsDeleteDialogOpen = true;
            await piptModal.Open();
        }

        private async Task OnSubmitCallBack()
        {
            IsDeleteDialogOpen = false;
            await piptModal.Close();
            LstProvinces = await provinceService.GetPagingProvinces(pagination);
            totalPages = provinceService.totalPages;
            ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Cập nhật dữ liệu tỉnh thành", Detail = "Thành công!" });
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
            LstProvinces = await provinceService.GetPagingProvinces(pagination);
            totalPages = provinceService.totalPages;
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
            LstProvinces = await provinceService.GetPagingProvinces(pagination);
            totalPages = provinceService.totalPages;
        }
        void CancelDialog()
        {
            IsDeleteDialogOpen = false;
        }
    }
}
