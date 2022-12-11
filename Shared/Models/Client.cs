namespace Shared.Models;

public class Client
{
    public string username { get; set; }
    public string password { get; set; }
    
    public string name { get; set; }
    public string email { get; set; }
    public string dob { get; set; }
    public long phoneNumber { get; set; }
    
    // test subscription system below
    public bool subscriptions { get; set; }
}