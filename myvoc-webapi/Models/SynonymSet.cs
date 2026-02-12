using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class SynonymSet
{
    [JsonPropertyName("sense")]
    public string sense { get; set; }
    
    [JsonPropertyName("synonyms")]
    public List<string> synonyms { get; set; }
}