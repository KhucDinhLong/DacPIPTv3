using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace PIPTWeb.Client
{
    public static class JSRuntimeExtensions
    {
        public static ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message)
        {
            return jsRuntime.InvokeAsync<bool>("confirm", message);
        }

        public static ValueTask NavChildIdent(this IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeVoidAsync("navChildIdent");
        }
        public static ValueTask NavCompact(this IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeVoidAsync("navCompact");
        }
    }
}
