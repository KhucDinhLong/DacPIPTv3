using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PIPTWeb.Server.Hubs
{
    [Authorize]
    public class PIPTWebHubs : Hub
    {
        public async Task UploadInfo()
        {
            await Clients.All.SendAsync("InfoHasChange");
        }
		
        public async Task ChangeInfoCTCD()
        {
            await Clients.All.SendAsync("InfoCTCDHasChange");
        }

        //public async Task SendMessageAsync(ChatMessage message, string userName)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", message, userName);
        //}
        
        public async Task ChatNotificationAsync(string message, string receiverUserId, string senderUserId)
        {
            await Clients.All.SendAsync("ReceiveChatNotification", message, receiverUserId, senderUserId);
        }

        public async Task ChangeOrderCTCD()
        {
            await Clients.All.SendAsync("OrderCTCDHasChange");
        }

        public async Task CreateNewRequest(List<string> LstUserName)
        {
            if (LstUserName != null && LstUserName.Count > 0)
            {
                foreach (var UserName in LstUserName)
                {
                    await Clients.Group(UserName).SendAsync("NewRequestCreated");
                }
            }
        }
		
        public override Task OnConnectedAsync()
        {
            var name = Context.User.Identity.Name;
            Groups.AddToGroupAsync(Context.ConnectionId, name);
            return base.OnConnectedAsync();
        }

    }
}