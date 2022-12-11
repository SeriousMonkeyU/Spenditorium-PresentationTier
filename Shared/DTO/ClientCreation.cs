namespace Shared.DTO;

public class ClientCreation
{
    public string username { get; }
    public string password { get; }
    
    public string name { get; }
    public string email { get; }
    public string dob { get; }
    public long phoneNumber { get; }
    public bool[] suscriptions { get; } // 0 - Electricity, 1 - Heating, 2 - Housing, 3 - Water

    public ClientCreation(string username, string password, string name, string email, string dob,
        long phoneNumber, bool[] subscriptions)
    {
        this.username = username;
        this.password = password;
        this.name = name;
        this.email = email;
        this.dob = dob;
        this.phoneNumber = phoneNumber;
        this.suscriptions = new bool[4];
        this.suscriptions = subscriptions;
    }

    public override String ToString()
    {
        return username + " " + password + " " + name + " " + email + " " + dob + " " + phoneNumber + " " + suscriptions;
    }
}