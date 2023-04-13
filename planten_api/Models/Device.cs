using System.ComponentModel.DataAnnotations;

namespace planten_api.Models;

public class Device
{
    [Key]
    public int id { get; set; }

    public string name { get; set; }

    public string ip { get; set; }
}