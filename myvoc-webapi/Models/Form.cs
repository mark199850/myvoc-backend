using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class Form
{
    [JsonPropertyName("form")]
    public string form { get; set; }
    
    [JsonPropertyName("grammar")]
    public List<GrammarBlock> grammar { get; set; }
}