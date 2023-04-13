using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace planten_api;

public class SoilMoisture
{
    [Key]
    public int Id { get; set; }
    
    public int Moisture { get; set; }
    public DateTime? createdAt { get; set; }
}