using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class RelationInfo
{
    [JsonPropertyName("entry")]
    public string Entry { get; set; }
    
    [JsonPropertyName("relation")]
    public string Relation { get; set; }
    
    [JsonPropertyName("normalizedEntry")]
    public string NormalizedEntry { get; set; }
}