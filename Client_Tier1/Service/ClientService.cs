using System.Text;
using System.Text.Json;
using Shared.DTO;
using Shared.Models;
namespace Client_Tier1.Service;


public class ClientService : IClientService
{
    private readonly HttpClient client = new ();

    private LocalClient lClient;

    public ClientService()
    {
        lClient = new LocalClient("", "", false);
    }
    
    public async Task<List<Bill>> GetBillsByUsername(string username, string companyname)
    {
        SubscribedCompanyDto clientData = new()
        {
            username = username,
            companyname = companyname
        };
        
        string dataAsJson = JsonSerializer.Serialize(clientData);
        StringContent content = new(dataAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:8090/client/getBills", content);
        string responseContent = await responseMessage.Content.ReadAsStringAsync();

        List<Bill> desirableValue = JsonSerializer.Deserialize<List<Bill>>(responseContent)!;
        return desirableValue;
    }

    public async Task RegisterAsync(ClientCreation client)
    {
        lClient.username = client.username;
        lClient.password = client.password;
        lClient.authorized = true;
        
        string userAsJson = JsonSerializer.Serialize(client);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await this.client.PostAsync("http://localhost:8090/client/register", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
    }

    public async Task<int> LoginAsync(string username, string password)
    {
        UserLoginDto userLoginDto = new()
        {
            username = username,
            password = password
        };

        string userAsJson = JsonSerializer.Serialize(userLoginDto);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:8090/client/login", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        return JsonSerializer.Deserialize<int>(responseContent);
    }

    public async Task LogoutAsync()
    {
        lClient.authorized = false;
    }
}