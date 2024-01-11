using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using ShopProjectAPP;
using ShopProjectAPP.ViewModel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<GameViewModel>();
builder.Services.AddScoped<NavMenuViewModel>();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredModal();

url = builder.Configuration.GetValue<string>("HttpAddress");
userUrl = builder.Configuration.GetValue<string>("userUrl");
userActionUrl = builder.Configuration.GetValue<string>("userActionUrl");
gamesUrl = builder.Configuration.GetValue<string>("gamesUrl");
orderUrl = builder.Configuration.GetValue<string>("orderUrl");
orderActionsUrl = builder.Configuration.GetValue<string>("orderActionsUrl");

await builder.Build().RunAsync();

public partial class Program
{
    public static string url { get; set; }
    public static string userUrl { get; set; }
    public static string userActionUrl {  get; set; }
    public static string gamesUrl { get; set; }
    public static string orderUrl { get; set; }
    public static string orderActionsUrl {  get; set; }
}