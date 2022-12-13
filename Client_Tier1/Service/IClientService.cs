using Shared.DTO;
using Shared.Models;

namespace Client_Tier1.Service;

public interface IClientService
{
    public Task<List<Bill>> GetBillsById(int id, string company);
    public Task RegisterAsync(ClientCreation client);
    public Task<int> LoginAsync(string username, string password);
}