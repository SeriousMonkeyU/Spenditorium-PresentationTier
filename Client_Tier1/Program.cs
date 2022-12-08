using BlazorWasm.Auth;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client_Tier1;
using HttpClient.IClientService;
using HttpClient.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new System.Net.Http.HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<IClientHttpServices, ClientHttpClient>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

AuthorizationPolicies.AddPolicies(builder.Services);

await builder.Build().RunAsync();