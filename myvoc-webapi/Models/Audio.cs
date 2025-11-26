using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class Audio
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("sourceUrl")]
    public string? SourceUrl { get; set; }
}