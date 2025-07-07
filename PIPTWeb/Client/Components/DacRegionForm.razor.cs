using Microsoft.AspNetCore.Components;
using PIPTWeb.Shared.Models;

namespace PIPTWeb.Client.Components
{
    public partial class DacRegionForm
    {
        [Parameter] public DacRegion region { get; set; }
        [Parameter] public string HeaderText { get; set; }
        [Parameter] public string ButtonText { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }
    }
}
