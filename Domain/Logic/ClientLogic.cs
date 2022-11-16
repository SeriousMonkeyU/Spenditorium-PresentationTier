using Domain.DAOInterfaces;
using Domain.LogicInterfaces;
using Shared.DTO;
using Shared.Models;

namespace Domain.Logic;

public class ClientLogic : IClientLogic
{
    private readonly IClientDao clientDao;

    public ClientLogic(IClientDao clientDao)
    {
        this.clientDao = clientDao;
    }

    public async Task<Client> CreateAsync(ClientCreation dto)
    {
        Client? existing = null; // CHECK IF THE USER ALREADY EXISTS
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        Client toCreate = new Client
        {
            Username = dto.Username,
            Password = dto.Password
        };

        Client created = await clientDao.CreateAsync(toCreate);

        return created; 
    }
    
    private static void ValidateData(ClientCreation userToCreate)
    {
        string userName = userToCreate.Username;
        string password = userToCreate.Password;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
        if (password.Length < 3)
            throw new Exception("Password must be at least 3 characters!");
        if (password.Length > 20)
            throw new Exception("Password must be less than 21 characters!");
    }
}