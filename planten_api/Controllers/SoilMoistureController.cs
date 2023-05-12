using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using planten_api.Data;
using planten_api.Dto.SoilMoisture;
using planten_api.Models;

namespace planten_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SoilMoistureController : ControllerBase
{
    private readonly SoilMoistureContext _db;

    public SoilMoistureController (SoilMoistureContext soilMoistureContext)
    {
        _db = soilMoistureContext;
    }

    [EnableCors("Cors")]
    [HttpGet]
    public  ActionResult<List<SoilMoisture>> Get()
    {
        var soilMoisture = _db.SoilMoistures
            .Include(moisture => moisture.Device);

        return Ok(soilMoisture);
    }

    [EnableCors("Cors")]
    [HttpGet("{id:int}")]
    public ActionResult<List<SoilMoisture>> Get(int id)
    {
        var soilMoistures = _db.SoilMoistures.Find(id);

        if (soilMoistures == null)
        {
            return NotFound();
        }
        
        return Ok(soilMoistures);
    }

    [HttpPost]
    public async Task<ActionResult> Post(SoilMoisturePostRequest soilMoisturePostRequest)
    {

        var device = _db.Devices.Find(soilMoisturePostRequest.DeviceId);

        if (device == null)
        {
            return NotFound("device not found");
        }
        
        SoilMoisture soilMoisture = new SoilMoisture
        {
            Moisture = soilMoisturePostRequest.Moisture,
            Device = device,
        };

        _db.SoilMoistures.Add(soilMoisture);
        
        await _db.SaveChangesAsync();

        return Ok();
    }
}