using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class Interpretation
{
    [JsonPropertyName("lemma")]
    public string? Lemma { get; set; }

    [JsonPropertyName("normalizedLemmas")]
    public List<NormalizedLemma> normalizedLemmas { get; set; }

    [JsonPropertyName("partOfSpeech")]
    public string? PartOfSpeech { get; set; }
    
    [JsonPropertyName("grammar")]
    public List<GrammarBlock> Grammar { get; set; }
}