using HttpClient.IClientService;
using Shared.DTO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Shared.Models;

namespace HttpClient.Implementations;

public class ClientHttpClient : IClientHttpServices
{

    private System.Net.Http.HttpClient _httpClient;

    public ClientHttpClient(System.Net.Http.HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }
    
    public async Task<Client> Create(ClientCreation dto)
    {
        string uri = "http://localhost:8090/addNewClient";
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
        Client client = JsonSerializer.Deserialize<Client>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return client;
    }

    public async Task<bool> Login(string username, string password)
    {
        string uri = "http://localhost:8090/login";
        string answerSerialized = JsonSerializer.Serialize(username + password);
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
        string result = await response.Content.ReadAsStringAsync();
        bool temp = JsonSerializer.Deserialize<bool>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return temp;
    }
}