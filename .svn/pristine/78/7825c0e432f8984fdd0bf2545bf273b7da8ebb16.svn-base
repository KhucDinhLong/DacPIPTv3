using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using System;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.DacRegionPage
{
    public partial class DacRegionCreate
    {
        [Inject] IDacRegionsService regionService { get; set; }
        [Parameter] public DacRegion region { get; set; }
        [Parameter] public string UserName { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task HandleValidSubmit()
        {
            region.CreatedUser = UserName;
            region.CreatedDate = DateTime.Now;
            await regionService.CreateRegion(region);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
