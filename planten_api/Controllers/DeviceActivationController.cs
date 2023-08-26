using System.Numerics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using planten_api.Data;
using planten_api.Dto.Device;
using planten_api.Models;

namespace planten_api.Controllers;

[ApiController]
[Route("/api/activate-device")]
public class DeviceActivationController : ControllerBase
{

    private SoilMoistureContext _db;

    public DeviceActivationController(SoilMoistureContext context)
    {
        _db = context;
    }

    [HttpPut]
    [EnableCors("Cors")]
    
    public ActionResult Put(DeviceActivationDto activateDevice)
    {
        Device ?device = _db.Devices.Find(activateDevice.Id);
        
        if (device == null)
        {
            return NotFound();
        }

        device.ActiveDevice = true;
        device.ActivatedAt = DateTime.Now;
        _db.SaveChanges();
        
        return Ok(device);
    }
}