using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using planten_api.Data;
using planten_api.Dto.Device;
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
    
    [EnableCors("Cors")]
    [HttpGet]
    public ActionResult<Device> Get()
    {
        var devices = _db.Devices
            .ToList();
        
        return Ok(devices);
    }

    [EnableCors("Cors")]
    [HttpGet("{id:int}")]
    public ActionResult<Device> Get(int id)
    {
        var test = _db.Devices.Find(id);

        if (test == null)
        {
            return NotFound();
        }

        return Ok(test);
    }

    [HttpPost]
    public ActionResult<Device> Post(DeviceCreationDto deviceCreationDto)
    {
        if (deviceCreationDto.Name.Length < 1 || deviceCreationDto.Ip.Length < 1)
        {
            return UnprocessableEntity();
        }

        Device device = new Device
        {
            Name = deviceCreationDto.Name,
            Ip = deviceCreationDto.Ip
        };

        _db.Devices.Add(device);

        _db.SaveChanges();
        
        return Ok();
    }
}