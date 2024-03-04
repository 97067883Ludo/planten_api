using System.Text.Json.Serialization;

namespace planten_api.Dto.User;

public class UserLoginDto
{
    public String Username { get; set; } = String.Empty;
    
    public String AuthToken { get; set; } = String.Empty;
    
    public required String Password { get; set; }
}