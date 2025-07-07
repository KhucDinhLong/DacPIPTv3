using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIPTWeb.Client.Pages.DacDistributePage
{
    public partial class InvalidSeri
    {
        [Parameter] public List<string> LstInvalidSeri { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }
        public async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
