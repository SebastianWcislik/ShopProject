using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopProjectAPP;
using ShopProjectAPP.ViewModel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<GameViewModel>();

url = builder.Configuration.GetValue<string>("HttpAddress");

await builder.Build().RunAsync();

public partial class Program
{
    public static string url { get; set; }
}