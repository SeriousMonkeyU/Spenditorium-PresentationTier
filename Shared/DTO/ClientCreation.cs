using Shared.Models;

namespace Shared.DTO;

public class ClientCreation
{
    public string username { get; }
    public string password { get; }
    
    public string name { get; }
    public string email { get; }
    public string dob { get; }
    public string phoneNumber { get; }
    public List<Bill> bills { get; }
    public bool[] suscriptions { get; } // 0 - Electricity, 1 - Heating, 2 - Housing, 3 - Water

    public ClientCreation(string username, string password, string name, string email, string dob,
        string phoneNumber, List<Bill> bills, bool[] subscriptions)
    {
        this.username = username;
        this.password = password;
        this.name = name;
        this.email = email;
        this.dob = dob;
        this.phoneNumber = phoneNumber;
        this.suscriptions = new bool[4];
        this.suscriptions = subscriptions;
        this.bills = new List<Bill>();
    }

    public override String ToString()
    {
        return username + " " + password + " " + name + " " + email + " " + dob + " " + phoneNumber + " " + suscriptions[0] + " " + suscriptions[1] + " " + suscriptions[2] + " " + suscriptions[3] + " " + bills;
    }
}