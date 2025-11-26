using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class Sense
{
    [JsonPropertyName("definition")]
    public string definition { get; set; }
    
    [JsonPropertyName("labels")]
    public List<string> labels { get; set; }
    
    [JsonPropertyName("context")]
    public Context context { get; set; }
    
    [JsonPropertyName("subSenses")]
    public List<Sense> subSenses { get; set; }
    
    [JsonPropertyName("usageExamples")]
    public List<string> usageExamples { get; set; }
    
    [JsonPropertyName("synonyms")]
    public List<string> synonyms { get; set; }
}