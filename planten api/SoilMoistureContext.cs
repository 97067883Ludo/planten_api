using Microsoft.EntityFrameworkCore;

namespace planten_api;

public class SoilMoistureContext : DbContext
{
    private readonly IConfiguration _configuration;
    public SoilMoistureContext(IConfiguration configuration)
    {
        _configuration = configuration;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    public DbSet<SoilMoisture> SoilMoistures { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("defaultConnection"));
    }
}