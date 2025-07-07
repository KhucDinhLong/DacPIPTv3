using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Services
{
    public class OneAppHubService
    {
        public static HubConnection GetConnectionHub(string token, NavigationManager navigationManager)
        {
            HubConnection hubConnection = null;
            if (!string.IsNullOrWhiteSpace(token))
            {
                hubConnection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/oneapphubs"), option => { option.AccessTokenProvider = async () => await Task.FromResult(token); })
                .Build();
            }
            return hubConnection;
        }
        public static async Task TryStartHubConnection(HubConnection hubConnection, NavigationManager navigationManager)
        {
            if (hubConnection != null)
            {
                try
                {
                    await hubConnection.StartAsync();
                }
                catch(Exception ex)
                {
                    if (ex.Message.Contains("401"))
                    {
                        navigationManager.NavigateTo("/login");
                    }
                }
            }
        }
    }
}
