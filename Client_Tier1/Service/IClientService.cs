using Shared.Models;

namespace Client_Tier1.Service;

public interface IClientService
{
    public Task<List<Bill>> GetBillsByUsername(string username, string company);
}