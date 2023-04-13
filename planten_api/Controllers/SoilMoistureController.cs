using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


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
    public ActionResult<List<SoilMoisture>> Get()
    {
        var data = _db.SoilMoistures.ToList();

        return Ok(data);
    }

    [HttpPost]
    public IActionResult Post(SoilMoisture soilMoisture)
    { 
        /*int ID = (from i in _db.SoilMoistures
                select i.SoilMoistureId).Max();
        
        soilMoisture.SoilMoistureId = ID + 1;*/
        
        Console.WriteLine(soilMoisture.Id);
        
        soilMoisture.createdAt = DateTime.Now;
        
        _db.SoilMoistures.Add(soilMoisture);
        
        _db.SaveChanges();

        return Ok();
    }
}