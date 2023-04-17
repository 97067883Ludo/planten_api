using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using planten_api.Data;
using planten_api.Models;

namespace planten_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeviceController : ControllerBase
{
    private readonly SoilMoistureContext _db;

    public DeviceController(SoilMoistureContext context)
    {
        _db = context;
    }

    
    [HttpGet]
    public ActionResult<Device> Get()
    {
        var devices = _db.Devices.ToList();
        return Ok(devices);
    }

        
}