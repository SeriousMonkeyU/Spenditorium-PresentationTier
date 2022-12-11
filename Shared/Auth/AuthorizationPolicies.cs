using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Auth;

public class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MustBeSubToElectricity", a =>
                a.RequireAuthenticatedUser().RequireClaim("email", "email@gmail.com"));
        });
    }
}