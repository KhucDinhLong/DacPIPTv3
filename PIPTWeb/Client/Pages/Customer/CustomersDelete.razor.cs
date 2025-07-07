using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.Customer
{
    public partial class CustomersDelete
    {
        [Inject] ICustomersService customerService { get; set; }

        [Parameter] public Customers customer { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task DeleteAsync()
        {
            int CustomerId = customer.Id;
            await customerService.DeleteCustomer(CustomerId);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
