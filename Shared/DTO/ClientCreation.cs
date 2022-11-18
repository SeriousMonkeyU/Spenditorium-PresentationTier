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
        Username = username;
        Password = password;
        FullName = fullName;
        Email = email;
        DOB = dob;
        PhoneNumber = phoneNumber;
    }

    public override String ToString()
    {
        return Username + " " + Password + " " + FullName + " " + Email + " " + DOB + " " + PhoneNumber;
    }
}