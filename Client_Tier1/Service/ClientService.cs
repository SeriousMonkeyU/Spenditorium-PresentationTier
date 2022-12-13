using System.Text;
using System.Text.Json;
using Shared.DTO;
using Shared.Models;
namespace Client_Tier1.Service;


public class ClientService : IClientService
{
    private readonly HttpClient client = new ();

    public async Task<List<Bill>> GetBillsById(int clientid, string provider)
    {
        
        string dataAsJson = JsonSerializer.Serialize(clientid + provider);
        StringContent content = new(dataAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:8090/client/getBills", content);
        string responseContent = await responseMessage.Content.ReadAsStringAsync();

        List<Bill> desirableValue = JsonSerializer.Deserialize<List<Bill>>(responseContent)!;
        return desirableValue;
    }

    public async Task<List<bool>> GetSubscriptionsById(int clientid)
    {
        string dataAsJson = JsonSerializer.Serialize(clientid);
        StringContent content = new(dataAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:8090/client/getBills", content);
        string responseContent = await responseMessage.Content.ReadAsStringAsync();

        List<bool> desirableValue = JsonSerializer.Deserialize<List<bool>>(responseContent)!;
        return desirableValue;
    }

    public async Task RegisterAsync(ClientCreation client)
    {
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
        int tempClientId = -2;
        
        var textBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new string(username + "/" + password)));
        StringContent content = new(Convert.ToBase64String(textBytes), Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("http://localhost:8090/client/login", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            tempClientId = JsonSerializer.Deserialize<int>(responseContent);
        }

        return tempClientId;
    }
}