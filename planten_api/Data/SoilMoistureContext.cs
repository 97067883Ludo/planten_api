using Microsoft.EntityFrameworkCore;
using planten_api.Models;
namespace planten_api.Data;

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
    
    public DbSet<Device> Devices { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("defaultConnection"));
    }
}