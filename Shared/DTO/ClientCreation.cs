namespace Shared.DTO;

public class ClientCreation
{
    public string username { get; }
    public string password { get; }
    
    public string name { get; }
    public string email { get; }
    public DateTime dob { get; }
    public long phoneNumber { get; }

    public ClientCreation(string username, string password, string name, string email, DateTime dob,
        long phoneNumber)
    {
        this.username = username;
        this.password = password;
        this.name = name;
        this.email = email;
        this.dob = dob;
        this.phoneNumber = phoneNumber;
    }

    public override String ToString()
    {
        return username + " " + password + " " + name + " " + email + " " + dob + " " + phoneNumber;
    }
}