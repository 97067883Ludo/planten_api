using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planten_api.Models;

public class SoilMoisture
{
    [Key]
    public int Id { get; set; }
    
    public int Moisture { get; set; }
    public DateTime? createdAt { get; set; }

    public Device device { get; set; }
}