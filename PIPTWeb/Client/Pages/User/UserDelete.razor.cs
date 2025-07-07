using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;

namespace PIPTWeb.Client.Pages.User
{
    public partial class UserDelete
    {
        [Inject] ISecUsersService userService { get; set; }

        [Parameter] public PIPTWeb.Shared.Models.SecUsers User { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        public async Task DeleteAsync()
        {
            string userId = User.Id;
            await userService.DeleteUserById(userId);
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
