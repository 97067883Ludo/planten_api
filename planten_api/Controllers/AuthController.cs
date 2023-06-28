using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using planten_api.Dto.User;

namespace planten_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly DbContext _db;
    
    public AuthController(DbContext context)
    {
        _db = context;
    }

    [HttpPost]
    public ActionResult<UserDto> Register(UserDto userDto)
    {
        

        return Ok(userDto);
    }
}