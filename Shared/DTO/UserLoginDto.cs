namespace Shared.DTO;

public class UserLoginDto
{
    public string username { get; init; }
    public string password { get; init; }

    public UserLoginDto(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}