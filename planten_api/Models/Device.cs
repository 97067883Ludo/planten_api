using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace planten_api.Models;

public class Device
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Ip { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<SoilMoisture>? SoilMoisture { get; set; }

    public bool? AutoDetected { get; set; } = false;

    public bool ActiveDevice { get; set; } = true;

    public DateTime ?ActivatedAt { get; set; }
}