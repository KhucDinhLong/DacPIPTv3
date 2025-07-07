using Blazor.AdminLte;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PIPTWeb.Client.Logging;
using PIPTWeb.Client.PolicyProvider;
using PIPTWeb.Client.Services;
using PIPTWeb.Client.Utils;
using Radzen;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace PIPTWeb.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddFileReaderService(options => {
                options.UseWasmSharedBuffer = true;
            });
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddApiAuthorization()
                .AddAccountClaimsPrincipalFactory<RolesClaimsPrincipalFactory>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            //builder.Services.AddSingleton<IHttpContextAccessor>();

            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<ISecUsersService, SecUsersService>();
            builder.Services.AddScoped<IUserRoleService, UserRoleService>();
            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<IRoleMenuService, RoleMenuService>();
            builder.Services.AddScoped<IDacAgencyService, DacAgencyService>();
            builder.Services.AddScoped<IDacDistributeService, DacDistributeService>();
            builder.Services.AddScoped<IDacProductService, DacProductService>();
            builder.Services.AddScoped<ISecConfigService, SecConfigService>();
            builder.Services.AddScoped<ICustomersService, CustomersService>();
            builder.Services.AddSingleton<DataStorageService>();
            builder.Services.AddAdminLte();

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            builder.Services.AddLogging(logging => {
                var httpClient = builder.Services.BuildServiceProvider().GetRequiredService<HttpClient>();
                logging.SetMinimumLevel(LogLevel.Error);
                logging.AddProvider(new OneAppLoggerProvider(httpClient));
            });

            await builder.Build().RunAsync();
        }
    }
}
