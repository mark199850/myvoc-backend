using System.ComponentModel;
using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class Entry
{
    [JsonPropertyName("entry")]
    public string? Word { get; set; }

    [JsonPropertyName("pronunciations")]
    public List<Pronunciation>? Pronunciations { get; set; }

    [JsonPropertyName("interpretations")]
    public List<Interpretation>? Interpretations { get; set; }

    [JsonPropertyName("lexemes")]
    public List<Lexeme>? Lexemes { get; set; }

    [JsonPropertyName("license")]
    public License? License { get; set; }

    [JsonPropertyName("sourceUrls")]
    public List<string>? SourceUrls { get; set; }
}