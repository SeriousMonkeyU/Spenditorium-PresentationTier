using BlazorWasm.Auth;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client_Tier1;
using Microsoft.AspNetCore.Components.Authorization;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new System.Net.Http.HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY5ODgzQDMyMzAyZTMzMmUzMGpWTC9EWEpDZGVMVHlvNGVZYjM1Y3pMT0hhYk10V2VnK2xiZU1rdXZGSmc9");
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();