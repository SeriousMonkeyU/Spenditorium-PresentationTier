using Shared.DTO;
using Shared.Models;

namespace Domain.LogicInterfaces;

public interface IClientLogic
{
    public Task<Client> CreateAsync(ClientCreation dto);
}