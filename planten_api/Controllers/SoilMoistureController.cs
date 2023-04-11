using Microsoft.AspNetCore.Mvc;


namespace planten_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SoilMoistureController : ControllerBase
{

    public SoilMoistureController(SoilMoistureContext soilMoistureContext)
    {
        _db = soilMoistureContext;
    }

    private readonly SoilMoistureContext _db;

    [HttpGet]
    public ActionResult<List<SoilMoisture>> Get()
    {
        return _db.SoilMoistures.ToList();
    }

    [HttpPost]
    public IActionResult Post(SoilMoisture soilMoisture)
    {
        soilMoisture.createdAt = DateTime.Now;
        
        _db.SoilMoistures.Add(soilMoisture);
            
        _db.SaveChanges();

        return Ok();
    }
}