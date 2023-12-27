using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopProjectAPP;
using ShopProjectAPP.Helpers;
using ShopProjectAPP.Services;
using ShopProjectAPP.Services.Interfaces;
using ShopProjectAPP.ViewModel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7044/") });
builder.Services.AddScoped<ProductViewModel>();
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();