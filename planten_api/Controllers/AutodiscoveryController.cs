using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using planten_api.Data;
using planten_api.Dto.Device;
using planten_api.Models;

namespace planten_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AutodiscoveryController : ControllerBase
{
    private readonly SoilMoistureContext _db;

    public AutodiscoveryController(SoilMoistureContext context)
    {
        _db = context;
    }

    [EnableCors("Cors")]
    [HttpPost]
    public ActionResult Post(AutoDeviceDiscoveryDto device)
    {
        if (device.Id == null)
        {
            var findDevice = _db.Devices.FirstOrDefault(device1 => device1.Name == device.Name);

            if (findDevice == null)
            {
                var newDevice = new Device()
                {
                    Name = device.Name,
                    Ip = device.Ip,
                    AutoDetected = true,
                    ActiveDevice = false,
                };

                _db.Add(newDevice);
                _db.SaveChanges();
                
                return Ok(newDevice);
            }

            return UnprocessableEntity("Name Already in use...");
        }
        
        var foundDevice = _db.Devices.Find(device.Id);

        if (foundDevice == null)
        {
            return NotFound("something is going terribly wrong, or you just deleted the thing.");
        }

        return Ok(foundDevice);
    }

    [HttpPut]
    [Route("/api/startup-checkin")]
    public ActionResult Put(AutoDeviceDiscoveryDto newDevice)
    {
        if (newDevice.Id == null)
        {
            return UnprocessableEntity("you cant update a device without an id");
        }

        Device ?device = _db.Devices.Find(newDevice.Id);

        if (device == null)
        {
            return NotFound();
        }

        if (newDevice.Ip != device.Ip)
        {
            device.Ip = newDevice.Ip;
            _db.SaveChanges();
        }
        
        return Ok();
    }
}