using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace planten_api;

public class SoilMoisture : DbContext
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    public int Moisture { get; set; }
    public DateTime? createdAt { get; set; }
}