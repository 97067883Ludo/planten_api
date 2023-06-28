using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace planten_api.Dto.User;

public class UserDto
{
    public required String Username { get; set; }

    public required String Password
    {
        get { return HashedPassword; }
        set { HashPassword(); }
    }

    [JsonIgnore] public String HashedPassword { get; set; } = String.Empty;

    private void HashPassword()
    {
        this.HashedPassword = BCrypt.Net.BCrypt.HashPassword(this.Password);
    }
}