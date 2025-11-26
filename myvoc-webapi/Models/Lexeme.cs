using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;


public class Lexeme
{
    [JsonPropertyName("lemma")]
    public string? Lemma { get; set; }

    [JsonPropertyName("partOfSpeech")]
    public string? PartOfSpeech { get; set; }
    
    [JsonPropertyName("homographNumber")]
    public int homographNumber { get; set; }

    [JsonPropertyName("senses")]
    public List<Sense> senses { get; set; }
    
    [JsonPropertyName("forms")]
    public List<Form> forms { get; set; }
    
    [JsonPropertyName("synonymSets")]
    public List<SynonymSet> synonymSets { get; set; }
}