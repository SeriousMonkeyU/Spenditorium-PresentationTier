using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client_Tier1;
using Client_Tier1.Service;
using Shared.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new System.Net.Http.HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new System.Net.Http.HttpClient());
builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();