using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.DacAgencyPage
{
    public partial class DacAgenciesDelete
    {
        [Inject] IDacAgencyService agencyService { get; set; }

        [Parameter] public DacAgency agency { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task DeleteAsync()
        {
            int AgencyId = agency.ID;
            await agencyService.DeleteAgency(AgencyId);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
