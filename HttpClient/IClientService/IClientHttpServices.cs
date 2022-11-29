using System.Security.Claims;
using Shared.DTO;
using Shared.Models;

namespace HttpClient.IClientService;

public interface IClientHttpServices
{
    public Task<Client> Create(ClientCreation dto);
    public Task Login(string username, string password);
    public Task Logout();
    public Task<ClaimsPrincipal> GetAuthAsync();
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}