namespace planten_api.Dto.Device;

public class AutoDeviceDiscoveryDto
{
    public int ?Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string Ip { get; set; } = string.Empty;
}