using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Client
{
    public string Username { get; set; }
    public string Password { get; set; }
    
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateOnly DOB { get; set; }
    public long PhoneNumber { get; set; }
}