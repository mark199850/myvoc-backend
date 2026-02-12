using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class NormalizedLemma
{
    [JsonPropertyName("lemma")]
    public string Lemma { get; set; }
    
    [JsonPropertyName("homographNumber")]
    public int? HomographNumber { get; set; }
    
    [JsonPropertyName("relation")]
    public List<RelationInfo> Relation { get; set; }
}