using System.Text.Json.Serialization;

namespace myvoc_webapi.Models;

public class Transcription
{
    [JsonPropertyName("transcription")]
    public string? Text { get; set; }

    [JsonPropertyName("notation")]
    public string? Notation { get; set; }
}