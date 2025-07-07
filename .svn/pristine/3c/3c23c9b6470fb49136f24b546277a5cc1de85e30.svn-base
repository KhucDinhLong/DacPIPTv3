using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.ProvincePage
{
    public partial class ProvinceDelete
    {
        [Inject] IProvincesService provinceService { get; set; }

        [Parameter] public Province province { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task DeleteAsync()
        {
            int ProvinceId = province.ID;
            await provinceService.DeleteProvince(ProvinceId);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
