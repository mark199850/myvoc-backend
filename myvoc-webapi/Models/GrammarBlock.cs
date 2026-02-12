using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class GrammarBlock
{
    [JsonPropertyName("number")]
    public List<string> Number { get; set; }
    
    [JsonPropertyName("case_")]
    public List<string> Case_ { get; set; }  // "case" is reserved in C#
    
    [JsonPropertyName("person")]
    public List<string> Person { get; set; }
    
    [JsonPropertyName("verbForm")]
    public List<string> VerbForm { get; set; }
    
    [JsonPropertyName("tense")]
    public List<string> Tense { get; set; }
    
    [JsonPropertyName("mood")]
    public List<string> Mood { get; set; }
}