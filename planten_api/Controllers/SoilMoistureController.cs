using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using planten_api.Data;
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
        var test = _db.SoilMoistures
            .Include(moisture => moisture.device);

        return Ok(test);
    }

    [HttpPost]
    public async Task<ActionResult> Post(SoilMoisture soilMoisture)    
    {
        soilMoisture.createdAt = DateTime.Now;
        
        _db.SoilMoistures.Add(soilMoisture);
        
        await _db.SaveChangesAsync();

        return Ok();
    }
}