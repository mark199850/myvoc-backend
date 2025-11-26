using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class Context
{
    [JsonPropertyName("regions")]
    public List<string>? Regions { get; set; }
}