using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.ProvincePage
{
    public partial class ProvinceEdit
    {
        [Inject] IProvincesService provinceService { get; set; }

        [Parameter] public Province province { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task HandleValidSubmit()
        {
            await provinceService.UpdateProvince(province);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
