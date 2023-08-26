using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using planten_api.Data;
using planten_api.Dto.User;
using planten_api.Models;


namespace planten_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly SoilMoistureContext _db;
    
    private readonly IConfiguration _configuration;

    public AuthController(SoilMoistureContext context, IConfiguration configuration)
    {
        _db = context;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("register")]
    public ActionResult<User> Register(UserRegisterDto userRegisterDto)
    {
        User user = new User()
        {
            Username = userRegisterDto.Username,
            Password = userRegisterDto.Password,
            Email = userRegisterDto.Email,
        };

        _db.Users.Add(user);

        _db.SaveChanges();
        
        return Ok(user);
    }

    [HttpPost]
    [Route("login")]
    public ActionResult Login(UserLoginDto credentails)
    {
        User? User = _db.Users.FirstOrDefault(user => user.Username == credentails.Username);

        if (User == null)
        {
            return BadRequest("Credentails are not correct");
        }

        if (BCrypt.Net.BCrypt.EnhancedVerify(credentails.Password, User.Password, HashType.SHA256))
        {
            return BadRequest("Credentails are not correct");
        }

        String jwt = CreateAuthToken(User);

        return Ok(jwt);
    }
    
    private string CreateAuthToken(User user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Username)
        };
        
        var dotnetJwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:DOTNET_JWT_KEY").Value!
        ));
        
        var credentials = new SigningCredentials(dotnetJwtKey, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );
        
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        
        return jwt;
    }
}