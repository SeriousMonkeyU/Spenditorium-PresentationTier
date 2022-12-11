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
    public ClientHttpClient(System.Net.Http.HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public override string ToString()
    {
        return _httpClient.ToString();
    }
}