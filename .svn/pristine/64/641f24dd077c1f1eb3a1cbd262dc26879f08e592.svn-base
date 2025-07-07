using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;

namespace PIPTWeb.Client.Pages.Menu
{
    public partial class MenuDelete
    {
        [Inject] IMenuService menuService { get; set; }

        [Parameter] public PIPTWeb.Shared.Models.SysMenu Menu { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task DeleteAsync()
        {
            int MenuId = Menu.ID;
            await menuService.DeleteMenuById(MenuId);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
