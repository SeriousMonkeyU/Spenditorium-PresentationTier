using Shared.Models;

namespace Domain.DAOInterfaces;

public interface IClientDao
{
    Task<Client> CreateAsync(Client client);
}