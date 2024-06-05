using ECommerceApp;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiUrl"]) });

builder.Services.AddTransient<IProductApi, ProductApi>();
builder.Services.AddTransient<IAuthApi, AuthApi>();


await builder.Build().RunAsync();
