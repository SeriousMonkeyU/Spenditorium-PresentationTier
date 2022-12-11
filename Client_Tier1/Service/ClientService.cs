using System.Text;
using System.Text.Json;
using Shared.DTO;
using Shared.Models;

namespace Client_Tier1.Service;

public class ClientService : IClientService
{
    private readonly HttpClient client = new ();

    public async Task<Bills> GetBillsById(int id, string companyname)
    {
        SubscribedCompanyDto clientData = new()
        {
            id = id,
            companyname = companyname
        };
        
        string dataAsJson = JsonSerializer.Serialize(clientData);
        StringContent content = new(dataAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:8090/client/getBills", content);
        string responseContent = await responseMessage.Content.ReadAsStringAsync();

        Bills desirableValue = JsonSerializer.Deserialize<Bills>(responseContent)!;
        return desirableValue;
    }
}