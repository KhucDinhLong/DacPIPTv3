using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.User
{
    public partial class UserResetPwd
    {
        [Inject] ISecUsersService userService { get; set; }

        [Parameter] public PIPTWeb.Shared.Models.SecUsers User { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task ResetPwd()
        {
            string UserName = User.UserName;
            await userService.SetPassword(UserName);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
