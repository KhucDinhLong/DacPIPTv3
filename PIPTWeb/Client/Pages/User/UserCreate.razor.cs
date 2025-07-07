using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;

namespace PIPTWeb.Client.Pages.User
{
    public partial class UserCreate
    {
        [Inject] ISecUsersService userService { get; set; }

        [Parameter] public PIPTWeb.Shared.Models.SecUsers User { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task HandleValidSubmit()
        {
            await userService.CreateUser(User);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
