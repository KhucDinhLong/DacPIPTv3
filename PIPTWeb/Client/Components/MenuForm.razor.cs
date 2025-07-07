using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Components
{
    public partial class MenuForm
    {
        [Parameter] public SysMenu Menu { get; set; }
        [Parameter] public string HeaderText { get; set; }
        [Parameter] public string ButtonText { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }
        [Inject] IMenuService menuService { get; set; }
        private List<SysMenu> LstMenu { get; set; } = new List<SysMenu>();
        protected override async Task OnInitializedAsync()
        {
            await menuService.GetMenus();
            LstMenu = menuService.LstMenu.ToList();
            StateHasChanged();
        }
    }
}
