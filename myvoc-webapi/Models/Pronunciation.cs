using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;


public class Pronunciation
{
    [JsonPropertyName("transcriptions")]
    public List<Transcription>? Transcriptions { get; set; }

    [JsonPropertyName("audio")]
    public Audio? Audio { get; set; }

    [JsonPropertyName("context")]
    public Context? Context { get; set; }
}