namespace Shared.Models;

public class Client
{
    public string username { get; set; }
    public string password { get; set; }
    
    public string name { get; set; }
    public string email { get; set; }
    public string dob { get; set; }
    public string phoneNumber { get; set; }
    public bool[] subscriptions { get; set; } // 0 - Electricity, 1 - Heating, 2 - Housing, 3 - Water
}