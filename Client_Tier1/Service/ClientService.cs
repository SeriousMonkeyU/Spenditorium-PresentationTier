using System.Text;
using System.Text.Json;
using Shared.DTO;
using Shared.Models;

namespace Client_Tier1.Service;

public class ClientService : IClientService
{
    private readonly HttpClient client = new ();

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
}