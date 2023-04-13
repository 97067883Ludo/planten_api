using Microsoft.EntityFrameworkCore;
using planten_api.Models;

namespace planten_api.Data;

public class DeviceContext : DbContext
{

    public DbSet<Device> Device { get; set; }

    private readonly IConfiguration _configuration;

    public DeviceContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }
}