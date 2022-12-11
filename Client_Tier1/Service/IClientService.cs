using Shared.Models;

namespace Client_Tier1.Service;

public interface IClientService
{
    public Task<Bills> GetBillsById(int id, string company);
}