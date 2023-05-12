using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace planten_api.Models;

public class SoilMoisture
{
    [Key]
    public int Id { get; set; }
    public int Moisture { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public int? DeviceId { get; set; }
    [JsonIgnore]
    public Device? Device { get; set; }
}
