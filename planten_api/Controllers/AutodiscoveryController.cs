using Microsoft.AspNetCore.Http.HttpResults;
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
}