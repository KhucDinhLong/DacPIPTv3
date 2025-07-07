using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Components;
using PIPTWeb.Shared;
using PIPTWeb.Shared.Models;
using PIPTWeb.Shared.ViewModels;
using Radzen;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.Customer
{
    public partial class CustomersPage
    {
        [Inject] public ICustomersService customersService { get; set; }
        [Inject] public NotificationService notification { get; set; }

        private Customers _Customer = new Customers();
        private bool IsDeleteDialogOpen = false;
        private PIPTModal piptModal { get; set; }
        private PaginatedInputModel pagination { get; set; } = new PaginatedInputModel();

        private List<Customers> LstCustomers;

        public int totalPages { get; set; }
        private int actualPage = 1;
        private string CustomerCode = string.Empty;
        private string CustomerName = string.Empty;

        protected async override Task OnInitializedAsync()
        {
            pagination.PageNumber = 1;
            pagination.PageSize = 50;
            LstCustomers = await customersService.GetPagingCustomers(pagination);
            totalPages = customersService.totalPages;
            ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Tải dữ liệu khách hàng", Detail = "Thành công!" });
            StateHasChanged();
        }

        private async Task OpenDialog(Customers customer)
        {
            _Customer = customer;
            await piptModal.Open();
        }

        private async Task OpenDeleteDialog(Customers Customer)
        {
            _Customer = Customer;
            IsDeleteDialogOpen = true;
            await piptModal.Open();
        }

        private async Task OnSubmitCallBack()
        {
            IsDeleteDialogOpen = false;
            await piptModal.Close();
            LstCustomers = await customersService.GetPagingCustomers(pagination);
            totalPages = customersService.totalPages;
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
            LstCustomers = await customersService.GetPagingCustomers(pagination);
            totalPages = customersService.totalPages;
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
            LstCustomers = await customersService.GetPagingCustomers(pagination);
            totalPages = customersService.totalPages;
        }
        void CancelDialog()
        {
            IsDeleteDialogOpen = false;
        }
    }
}
