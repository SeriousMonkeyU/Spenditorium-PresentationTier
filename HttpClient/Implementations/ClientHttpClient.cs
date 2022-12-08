using HttpClient.IClientService;
using Shared.DTO;
using System.Net.Http;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Shared.Models;

namespace HttpClient.Implementations;

public class ClientHttpClient : IClientHttpServices
{

    private System.Net.Http.HttpClient _httpClient;
    public static string? Jwt { get; private set; } = "";
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;

    public ClientHttpClient(System.Net.Http.HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Client> Create(ClientCreation dto)
    {
        string uri = "https://localhost:8090/client/register";
        string clientSerialized = JsonSerializer.Serialize(dto);
        StringContent content = new StringContent(
            clientSerialized,
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage response = await _httpClient.PostAsync(uri, content);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ToString());
        }
        
        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
        Client client = JsonSerializer.Deserialize<Client>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return client;
    }

    public async Task Login(UserLoginDto ULD)
    {
        UserLoginDto userLoginDto = ULD;
        
        string uri = "http://localhost:8090/client/login";
        string answerSerialized = JsonSerializer.Serialize(userLoginDto);
        StringContent content = new StringContent(
            answerSerialized,
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage response = await _httpClient.PostAsync(uri, content);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.ToString());
        }
        string token = await response.Content.ReadAsStringAsync();
        
        Jwt = token;

        ClaimsPrincipal principal = CreateClaimsPrincipal();

        OnAuthStateChanged.Invoke(principal);
    }
    
    public Task LogoutAsync()
    {
        Jwt = null;
        ClaimsPrincipal principal = new();
        OnAuthStateChanged.Invoke(principal);
        return Task.CompletedTask;
    }

    private static ClaimsPrincipal CreateClaimsPrincipal()
    {
        if (string.IsNullOrEmpty(Jwt))
        {
            return new ClaimsPrincipal();
        }

        IEnumerable<Claim> claims = ParseClaimsFromJwt(Jwt);
        
        ClaimsIdentity identity = new(claims, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }
    
    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }
    
    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }
    
    public Task Logout()
    {
        Jwt = null;
        ClaimsPrincipal principal = new();
        OnAuthStateChanged.Invoke(principal);
        return Task.CompletedTask;
    }
    
    public override string ToString()
    {
        return _httpClient.ToString();
    }
}