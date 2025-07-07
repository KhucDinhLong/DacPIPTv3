using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using System;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.DacAgencyPage
{
    public partial class DacAgenciesCreate
    {
        [Inject] IDacAgencyService agencyService { get; set; }
        [Parameter] public DacAgency agency { get; set; }
        [Parameter] public string UserName { get; set; }
        [Parameter] public bool IsAdmin { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task HandleValidSubmit()
        {
            agency.CreatedUser = UserName;
            agency.CreatedDate = DateTime.Now;
            await agencyService.CreateAgency(agency);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
