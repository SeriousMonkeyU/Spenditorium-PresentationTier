using BlazorWasm.Auth;
using BlazorWasm.Services;
using BlazorWasm.Services.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client_Tier1;
using Client_Tier1.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new System.Net.Http.HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<IClientService, ClientService>();


AuthorizationPolicies.AddPolicies(builder.Services);
builder.Services.AddScoped(sp => new System.Net.Http.HttpClient());
builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();