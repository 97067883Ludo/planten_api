using System.Text.Json.Serialization;

public class UserRegisterDto
{
    public required String Username { get; set; }

    public required String Email { get; set; }

    public required String Password
    {
        get { return HashedPassword; }
        set { this.HashedPassword = BCrypt.Net.BCrypt.HashPassword(this.Password); }
    }

    [JsonIgnore] public String HashedPassword { get; set; } = String.Empty;
}