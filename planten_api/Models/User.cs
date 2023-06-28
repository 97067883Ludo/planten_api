using System.ComponentModel.DataAnnotations;

namespace planten_api.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    public String Username { get; set; } = string.Empty;

    public String Password { get; set; } = string.Empty;

    public String Email { get; set; } = String.Empty;
}