namespace Shared.DTO;

public class ClientCreation
{
    public string Username { get; }
    public string Password { get; }
    
    public string FullName { get; }
    public string Email { get; }
    public DateTime DOB { get; }
    public long PhoneNumber { get; }

    public ClientCreation(string username, string password, string fullName, string email, DateTime dob,
        long phoneNumber)
    {
        this.Username = username;
        this.Password = password;
        this.FullName = fullName;
        this.Email = email;
        this.DOB = dob;
        this.PhoneNumber = phoneNumber;
    }
}