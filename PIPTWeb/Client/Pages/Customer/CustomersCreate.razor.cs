using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.Customer
{
    public partial class CustomersCreate
    {
        [Inject] ICustomersService customerService { get; set; }
        [Parameter] public Customers customer { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task HandleValidSubmit()
        {
            await customerService.CreateCustomer(customer);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
