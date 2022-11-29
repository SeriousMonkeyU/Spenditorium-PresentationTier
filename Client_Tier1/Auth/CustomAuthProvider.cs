using System.Security.Claims;
using HttpClient.IClientService;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWasm.Auth;

public class CustomAuthProvider : AuthenticationStateProvider
{
    private readonly IClientHttpServices authService;

    public CustomAuthProvider(IClientHttpServices authService)
    {
        this.authService = authService;
        authService.OnAuthStateChanged += AuthStateChanged;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await authService.GetAuthAsync();

        return new AuthenticationState(principal);
    }

    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}