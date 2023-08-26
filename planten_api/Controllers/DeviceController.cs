using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using planten_api.Data;
using planten_api.Dto.Device;
using planten_api.Dto.Errors;
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
    [EnableCors("Cors")]
    public ActionResult<Device> Post(DeviceCreationDto deviceCreationDto)
    {
        if (deviceCreationDto.Name.Length < 1 || deviceCreationDto.Ip.Length < 1)
        {
            return UnprocessableEntity( new UnprocessableErrorDto("Naam en Ip moet worden gevuld"));
        }
        
        Device device = new Device
        {
            Name = deviceCreationDto.Name,
            Ip = deviceCreationDto.Ip,
            ActivatedAt = DateTime.Now
        };

        _db.Devices.Add(device);

        _db.SaveChanges();
        
        return Ok(device);
    }
    
    [EnableCors("Cors")]
    [HttpPut]
    public ActionResult<Device?> Put(DeviceEditDto deviceEdit)
    {
        var device = _db.Devices.Find(deviceEdit.Id);

        if (device == null)
        {
            return NotFound();
        }
        
        device.Name = deviceEdit.Name;
        device.Ip = deviceEdit.Ip;

        _db.Devices.Update(device);
        _db.SaveChanges();

        return Ok(device);
    }
}