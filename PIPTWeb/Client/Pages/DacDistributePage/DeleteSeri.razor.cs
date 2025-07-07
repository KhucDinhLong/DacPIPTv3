using Microsoft.AspNetCore.Components;
using PIPTWeb.Client.Services;
using PIPTWeb.Shared.Models;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.DacDistributePage
{
    public partial class DeleteSeri
    {
        [Inject] IDacDistributeService distributeService { get; set; }
        [Inject] private NotificationService notification { get; set; }
        [Parameter] public List<DacDistributeToAgencyDetails> LstDeleteSeri { get; set; }
        [Parameter] public EventCallback OnvalidSubmit { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }
        public async Task DeleteAsync()
        {
            string result = await distributeService.DeleteSeri(LstDeleteSeri);
            if (result == "204")
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Xóa dữ liệu", Detail = "Thành công!" });
            }
            else
            {
                ShowNotification(new Radzen.NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Xóa dữ liệu", Detail = "Thất bại!" });
            }
            await OnvalidSubmit.InvokeAsync();
        }

        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
        void ShowNotification(Radzen.NotificationMessage message)
        {
            notification.Notify(message);
        }
    }
}
