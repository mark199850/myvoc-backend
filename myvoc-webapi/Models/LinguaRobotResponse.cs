namespace myvoc_webapi.Models;

using System.Collections.Generic;
using System.Text.Json.Serialization;

public class LinguaRobotResponse
{
    [JsonPropertyName("entries")]
    public List<Entry>? Entries { get; set; }
}