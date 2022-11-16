using Shared.DTO;
using Shared.Models;

namespace HttpClient.IClientService;

public interface IClientHttpServices
{
    Task<Client> Create(ClientCreation dto);
}