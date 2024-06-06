using Blazored.LocalStorage;
using Blazored.Toast;
using ECommerceApp;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register ApiAuthenticationStateProvider
builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiUrl"]) });
builder.Services.AddScoped<IProductApi, ProductApi>();
builder.Services.AddScoped<IAuthApi, AuthApi>();
builder.Services.AddScoped<ICartApi, CartApi>();
builder.Services.AddBlazoredToast();


await builder.Build().RunAsync();
