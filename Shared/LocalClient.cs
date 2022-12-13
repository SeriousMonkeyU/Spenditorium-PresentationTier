namespace Shared.Models;

public class LocalClient
{
    public int id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    
    public bool authorized { get; set; }

    public LocalClient(string username, string password, bool authorized)
    {
        this.username = username;
        this.password = password;
        this.authorized = authorized;
    }

    public void setId(int id)
    {
        this.id = id;
    }
}