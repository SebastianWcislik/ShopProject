using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopProjectAPP;
using ShopProjectAPP.Helpers;
using ShopProjectAPP.ViewModel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7044/") });
builder.Services.AddScoped<ProductViewModel>();

url = builder.Configuration.GetValue<string>("HttpAddress");

await builder.Build().RunAsync();

public partial class Program
{
    public static string url { get; set; }
}