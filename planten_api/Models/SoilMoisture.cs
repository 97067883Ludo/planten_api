using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace planten_api.Models;

public class SoilMoisture
{
    [Key]
    public int Id { get; set; }
    public int Moisture { get; set; }
    public DateTime? createdAt { get; set; }
    public int? DeviceId { get; set; }
    [JsonIgnore]
    public Device? Device { get; set; }
}
