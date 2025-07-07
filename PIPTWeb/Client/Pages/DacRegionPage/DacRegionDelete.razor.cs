using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.DacRegionPage
{
    public partial class DacRegionDelete
    {
        [Inject] IDacRegionsService regionService { get; set; }

        [Parameter] public DacRegion region { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task DeleteAsync()
        {
            int RegionId = region.ID;
            await regionService.DeleteRegion(RegionId);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
