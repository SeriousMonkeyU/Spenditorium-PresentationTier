using Shared.Models;

namespace Shared.DTO;

public class ClientCreation
{
    public string username { get; }
    public string password { get; }
    
    public string name { get; }
    public string email { get; }
    public string dob { get; }
    public string phonenumber { get; }
    public List<Bill> bills { get; }
    public bool[] subscriptions { get; } // 0 - Electricity, 1 - Heating, 2 - Housing, 3 - Water

    public ClientCreation(string username, string password, string name, string email, string dob,
        string phoneNumber, List<Bill> bills, bool[] subscriptions)
    {
        this.username = username;
        this.password = password;
        this.name = name;
        this.email = email;
        this.dob = dob;
        this.phonenumber = phoneNumber;
        this.subscriptions = new bool[4];
        this.subscriptions = subscriptions;
        this.bills = new List<Bill>();
    }

    public override String ToString()
    {
        return username + " " + password + " " + name + " " + email + " " + dob + " " + phonenumber + " " + subscriptions[0] + " " + subscriptions[1] + " " + subscriptions[2] + " " + subscriptions[3] + " " + bills;
    }
}